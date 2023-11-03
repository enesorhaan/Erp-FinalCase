using AutoMapper;
using Erp.Base.Response;
using Erp.Data.Context;
using Erp.Data.Entities;
using Erp.Dto;
using Erp.Operation.Cqrs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Erp.Operation.Command
{
    public class OrderItemCommandHandler :
        IRequestHandler<CreateOrderItemCommand, ApiResponse<OrderItemResponse>>,
        IRequestHandler<UpdateOrderItemCommand, ApiResponse>,
        IRequestHandler<DeleteOrderItemCommand, ApiResponse>
    {
        private readonly MyDbContext dbContext;
        private readonly IMapper mapper;

        public OrderItemCommandHandler(MyDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<OrderItemResponse>> Handle(CreateOrderItemCommand request, CancellationToken cancellationToken)
        {
            OrderItem mapped = mapper.Map<OrderItem>(request.Model);

            Product product = await dbContext.Set<Product>().FirstOrDefaultAsync(x => x.Id == request.Model.ProductId, cancellationToken);
            
            if (product == null || !product.IsActive)
                return new ApiResponse<OrderItemResponse>("Product not found.");

            if (product.ProductStock < request.Model.Quantity)
                return new ApiResponse<OrderItemResponse>("Not enough Product Stock.");

            product.ProductStock -= request.Model.Quantity;
            product.UpdateDate = DateTime.Now;

            Dealer dealer = await dbContext.Set<Dealer>().FirstOrDefaultAsync(x => x.Id == request.DealerId, cancellationToken);
            mapped.DealerId = dealer.Id;
            mapped.MarginPrice = request.Model.Quantity * (product.ProductPrice + (product.ProductPrice * dealer.MarginPercentage) / 100);

            var entity = await dbContext.Set<OrderItem>().AddAsync(mapped, cancellationToken);
            entity.Entity.InsertDate = DateTime.Now;
            await dbContext.SaveChangesAsync(cancellationToken);

            var response = mapper.Map<OrderItemResponse>(entity.Entity);
            return new ApiResponse<OrderItemResponse>(response);
        }

        public async Task<ApiResponse> Handle(UpdateOrderItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Set<OrderItem>().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null)
                return new ApiResponse("Record not found!");

            Product product = await dbContext.Set<Product>().FirstOrDefaultAsync(x => x.Id == entity.ProductId, cancellationToken);
            Dealer dealer = await dbContext.Set<Dealer>().FirstOrDefaultAsync(x => x.Id == entity.DealerId, cancellationToken);

            product.ProductStock += entity.Quantity;
            product.UpdateDate = DateTime.Now;

            if (product.ProductStock < request.Model.Quantity)
                return new ApiResponse("Not enough Product Stock.");

            product.ProductStock -= request.Model.Quantity;

            entity.MarginPrice = request.Model.Quantity * (product.ProductPrice + (product.ProductPrice * dealer.MarginPercentage) / 100);
            entity.UpdateDate = DateTime.Now;
            entity.Quantity = request.Model.Quantity;

            await dbContext.SaveChangesAsync(cancellationToken);
            return new ApiResponse();
        }

        public async Task<ApiResponse> Handle(DeleteOrderItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Set<OrderItem>().FirstOrDefaultAsync(x => x.Id == request.Id && x.DealerId == request.DealerId, cancellationToken);

            if (entity == null)
                return new ApiResponse("Record not found!");

            Product product = await dbContext.Set<Product>().FirstOrDefaultAsync(x => x.Id == entity.ProductId, cancellationToken);

            product.ProductStock += entity.Quantity;
            product.UpdateDate = DateTime.Now;
            dbContext.Set<OrderItem>().Remove(entity);

            await dbContext.SaveChangesAsync(cancellationToken);
            return new ApiResponse();
        }
    }
}
