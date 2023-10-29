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
                .ToListAsync(cancellationToken);
            var mapped = mapper.Map<List<OrderItemResponse>>(list);

            return new ApiResponse<List<OrderItemResponse>>(mapped);
        }

        public async Task<ApiResponse<OrderItemResponse>> Handle(GetOrderItemByIdQuery request, CancellationToken cancellationToken)
        {
            OrderItem? entity = await dbContext.Set<OrderItem>()
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity is null)
                return new ApiResponse<OrderItemResponse>("Record not found!");

            var mapped = mapper.Map<OrderItemResponse>(entity);

            return new ApiResponse<OrderItemResponse>(mapped);
        }
    }
}
