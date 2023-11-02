using AutoMapper;
using Erp.Base.Response;
using Erp.Data.Context;
using Erp.Data.Entities;
using Erp.Dto;
using Erp.Operation.Cqrs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Erp.Operation.Query
{
    public class OrderItemQueryHandler :
        IRequestHandler<GetAllOrderItemQuery, ApiResponse<List<OrderItemResponse>>>,
        IRequestHandler<GetOrderItemByIdQuery, ApiResponse<OrderItemResponse>>
    {
        private readonly MyDbContext dbContext;
        private readonly IMapper mapper;

        public OrderItemQueryHandler(MyDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<List<OrderItemResponse>>> Handle(GetAllOrderItemQuery request, CancellationToken cancellationToken)
        {
            List<OrderItem> list = await dbContext.Set<OrderItem>()
                .Where(x => x.DealerId == request.DealerId && x.IsActive)
                .ToListAsync(cancellationToken);

            foreach (var item in list)
            {
                item.Product = await dbContext.Set<Product>().FirstOrDefaultAsync(x => x.Id == item.ProductId, cancellationToken);
                item.Dealer = await dbContext.Set<Dealer>().FirstOrDefaultAsync(x => x.Id == item.DealerId, cancellationToken);
            }

            var mapped = mapper.Map<List<OrderItemResponse>>(list);

            return new ApiResponse<List<OrderItemResponse>>(mapped);
        }

        public async Task<ApiResponse<OrderItemResponse>> Handle(GetOrderItemByIdQuery request, CancellationToken cancellationToken)
        {
            OrderItem? entity = await dbContext.Set<OrderItem>()
                .FirstOrDefaultAsync(x => x.Id == request.Id && x.DealerId == request.DealerId && x.IsActive, cancellationToken);

            if (entity is null)
                return new ApiResponse<OrderItemResponse>("Record not found!");

            entity.Product = await dbContext.Set<Product>().FirstOrDefaultAsync(x => x.Id == entity.ProductId, cancellationToken);
            entity.Dealer = await dbContext.Set<Dealer>().FirstOrDefaultAsync(x => x.Id == entity.DealerId, cancellationToken);

            var mapped = mapper.Map<OrderItemResponse>(entity);

            return new ApiResponse<OrderItemResponse>(mapped);
        }
    }
}
