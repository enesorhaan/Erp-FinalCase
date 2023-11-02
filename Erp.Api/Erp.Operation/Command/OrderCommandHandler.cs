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

namespace Erp.Operation.Command
{
    public class OrderCommandHandler :
        IRequestHandler<CreateOrderCommand, ApiResponse<OrderResponse>>,
        IRequestHandler<UpdateOrderCommand, ApiResponse>,
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

            mapped.DealerId = request.DealerId;

            foreach (var item in orderItems)
            {
                mapped.TotalPrice += item.MarginPrice;
            }

            var order = await PaymentOperation(mapped, cancellationToken);

            

            var entity = await dbContext.Set<Order>().AddAsync(mapped, cancellationToken);

            entity.Entity.InsertDate = DateTime.Now;
            await dbContext.SaveChangesAsync(cancellationToken);

            var response = mapper.Map<OrderResponse>(entity.Entity);
            return new ApiResponse<OrderResponse>(response);
        }
        
        private async Task<ApiResponse<Order>> PaymentOperation(Order order, CancellationToken cancellationToken)
        {
            Dealer dealer = await dbContext.Set<Dealer>()
                .Include(x => x.CurrentAccount)
                .FirstOrDefaultAsync(x => x.Id == order.DealerId, cancellationToken);

            if (order.PaymentMethod == PaymentMethod.Remittance)
            {
                order.OrderStatus = OrderStatus.WaitingForPayment;
            }
            else if (order.PaymentMethod == PaymentMethod.CreditCard)
            {
                order.OrderStatus = OrderStatus.WaitingForApproval;
            }
            else if (order.PaymentMethod == PaymentMethod.OpenAccount)
            {
                if (order.TotalPrice > dealer.CurrentAccount.CreditLimit)
                {
                    order.OrderStatus = OrderStatus.Rejected;
                }
                else
                {
                    dealer.CurrentAccount.CreditLimit -= order.TotalPrice;
                    order.OrderStatus = OrderStatus.WaitingForApproval;
                }
            }
            else
            {
                return new ApiResponse<Order>("Payment method not found!");
            }


            return new ApiResponse<Order>(order);
        }

        public async Task<ApiResponse> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Set<Order>().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null)
                return new ApiResponse("Record not found!");

            entity.UpdateDate = DateTime.Now;
            entity.OrderStatus = request.Model.OrderStatus;

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
