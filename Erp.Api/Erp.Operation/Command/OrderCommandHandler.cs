using AutoMapper;
using Azure.Core;
using Erp.Base.Enum;
using Erp.Base.Response;
using Erp.Data.Context;
using Erp.Data.Entities;
using Erp.Dto;
using Erp.Operation.Cqrs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Dapper.SqlMapper;

namespace Erp.Operation.Command
{
    public class OrderCommandHandler :
        IRequestHandler<CreateOrderCommand, ApiResponse<OrderResponse>>,
        IRequestHandler<UpdateOrderCommandByCompany, ApiResponse>,
        IRequestHandler<UpdateOrderCommandByDealer, ApiResponse>,
        IRequestHandler<DeleteOrderCommand, ApiResponse>
    {
        private readonly MyDbContext dbContext;
        private readonly IMapper mapper;

        public OrderCommandHandler(MyDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<OrderResponse>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            List<OrderItem> orderItems = await dbContext.Set<OrderItem>().Where(x => x.DealerId == request.DealerId && x.IsActive).ToListAsync(cancellationToken);

            if (orderItems == null || orderItems.Count == 0)
                return new ApiResponse<OrderResponse>("Order items not found!");

            Order mapped = mapper.Map<Order>(request.Model);

            decimal? totalPrice = 0;
            foreach (var item in orderItems)
            {
                totalPrice += item.MarginPrice;
                item.IsActive = false;
            }

            mapped.DealerId = request.DealerId;
            mapped.OrderDate = DateTime.Now;
            mapped.TotalPrice = totalPrice;
            mapped.OrderItems = orderItems;

            var paymentOperation = await PaymentOperation(mapped, cancellationToken);

            if (!paymentOperation.Success)
                return new ApiResponse<OrderResponse>(paymentOperation.Message);
            else
                mapped = paymentOperation.Response;

            var entity = await dbContext.Set<Order>().AddAsync(mapped, cancellationToken);

            entity.Entity.InsertDate = DateTime.Now;
            await dbContext.SaveChangesAsync(cancellationToken);

            var response = mapper.Map<OrderResponse>(entity.Entity);
            return new ApiResponse<OrderResponse>(response);
        }
        
        private async Task<ApiResponse<Order>> PaymentOperation(Order order, CancellationToken cancellationToken)
        {
            Dealer dealer = await dbContext.Set<Dealer>().Include(x => x.CurrentAccount).FirstOrDefaultAsync(x => x.Id == order.DealerId, cancellationToken);

            switch (order.PaymentMethod)
            {
                case PaymentMethod.Remittance:
                    order.OrderStatus = OrderStatus.WaitingForApproval;
                    break;
                case PaymentMethod.CreditCard:
                    order.OrderStatus = OrderStatus.WaitingForApproval;
                    break;
                case PaymentMethod.OpenAccount:
                    if (dealer.CurrentAccount == null)
                        return new ApiResponse<Order>("Dealer account not found!");
                    if (order.TotalPrice > dealer.CurrentAccount.CreditLimit)
                        order.OrderStatus = OrderStatus.Rejected;
                    else
                    {
                        dealer.CurrentAccount.CreditLimit -= order.TotalPrice;
                        dealer.UpdateDate = DateTime.Now;
                        order.OrderStatus = OrderStatus.WaitingForApproval;
                    }
                    break;
                default:
                    return new ApiResponse<Order>("Payment method not found!");
            }

            await dbContext.SaveChangesAsync(cancellationToken);

            return new ApiResponse<Order>(order);
        }

        public async Task<ApiResponse> Handle(UpdateOrderCommandByCompany request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Set<Order>().FirstOrDefaultAsync(x => x.Id == request.Id && x.IsActive, cancellationToken);

            if (entity == null)
                return new ApiResponse("Record not found!");

            var dealer = await dbContext.Set<Dealer>().Include(x => x.CurrentAccount).FirstOrDefaultAsync(x => x.Id == entity.DealerId, cancellationToken);

            if (request.Model.OrderStatus == OrderStatus.Approved)
            {
                entity.BillingNumber = Guid.NewGuid().ToString().Replace("-", "").ToLower();
                entity.IsActive = false;
                entity.OrderStatus = (entity.PaymentMethod == PaymentMethod.Remittance) ? OrderStatus.WaitingForPayment : OrderStatus.Approved;
            }
            else if (request.Model.OrderStatus == OrderStatus.Rejected)
            {
                entity.OrderStatus = OrderStatus.Rejected;
                dealer.CurrentAccount.CreditLimit = (entity.PaymentMethod == PaymentMethod.OpenAccount) ? (dealer.CurrentAccount.CreditLimit + entity.TotalPrice) : dealer.CurrentAccount.CreditLimit;
                entity.IsActive = false;
                var response = await OrderCancelOperation(entity, cancellationToken);
                if (!response.Success)
                    return new ApiResponse(response.Message);
            }
            else
                return new ApiResponse("Invalid status request!");
                
            entity.UpdateDate = DateTime.Now;

            await dbContext.SaveChangesAsync(cancellationToken);
            return new ApiResponse();
        }

        private async Task<ApiResponse<Order>> OrderCancelOperation(Order order, CancellationToken cancellationToken)
        {

            var orderItems = await dbContext.Set<OrderItem>().Where(x => x.DealerId == order.DealerId && x.OrderId == order.Id).ToListAsync(cancellationToken);
            var dealer = await dbContext.Set<Dealer>().Include(x => x.CurrentAccount).FirstOrDefaultAsync(x => x.Id == order.DealerId, cancellationToken);

            if (orderItems == null || orderItems.Count == 0)
                return new ApiResponse<Order>("Order items not found!");

            dealer.CurrentAccount.CreditLimit = (order.PaymentMethod == PaymentMethod.OpenAccount) ? (dealer.CurrentAccount.CreditLimit + order.TotalPrice) : dealer.CurrentAccount.CreditLimit;

            foreach (var item in orderItems)
            {
                item.IsActive = false;
                var product = await dbContext.Set<Product>().FirstOrDefaultAsync(x => x.Id == item.ProductId && x.IsActive, cancellationToken);
                product.ProductStock += item.Quantity;
            }

            await dbContext.SaveChangesAsync(cancellationToken);
            return new ApiResponse<Order>(order);
        }

        public async Task<ApiResponse> Handle(UpdateOrderCommandByDealer request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Set<Order>().FirstOrDefaultAsync(x => x.Id == request.Id && x.DealerId == request.DealerId && x.IsActive, cancellationToken);

            if (entity == null)
                return new ApiResponse("Record not found!");

            if (entity.BillingNumber != null)
                return new ApiResponse("Order already approved!");

            if (request.Model.OrderStatus != OrderStatus.Cancelled)
                return new ApiResponse("Invalid status request!");

            entity.IsActive = false;
            entity.UpdateDate = DateTime.Now;
            entity.OrderStatus = request.Model.OrderStatus;

            var response = await OrderCancelOperation(entity, cancellationToken);

            if (!response.Success)
                return new ApiResponse(response.Message);

            await dbContext.SaveChangesAsync(cancellationToken);
            return new ApiResponse();
        }

        public async Task<ApiResponse> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Set<Order>().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null)
                return new ApiResponse("Record not found!");

            entity.IsActive = false;

            await dbContext.SaveChangesAsync(cancellationToken);
            return new ApiResponse();
        }
    }
}
