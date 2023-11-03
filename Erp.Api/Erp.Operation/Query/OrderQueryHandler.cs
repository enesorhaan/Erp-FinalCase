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
    public class OrderQueryHandler :
        IRequestHandler<GetAllOrderByCompanyQuery, ApiResponse<List<OrderResponse>>>,
        IRequestHandler<GetAllOrderByDealerQuery, ApiResponse<List<OrderResponse>>>,
        IRequestHandler<GetOrderByIdQuery, ApiResponse<OrderResponse>>
    {
        private readonly MyDbContext dbContext;
        private readonly IMapper mapper;

        public OrderQueryHandler(MyDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<List<OrderResponse>>> Handle(GetAllOrderByCompanyQuery request, CancellationToken cancellationToken)
        {
            List<Order> list = await dbContext.Set<Order>()
                .Include(x => x.Dealer)
                .Include(x => x.OrderItems)
                .ToListAsync(cancellationToken);

            if (list.Count == 0)
                return new ApiResponse<List<OrderResponse>>("Record not found!");

            var mapped = mapper.Map<List<OrderResponse>>(list);

            return new ApiResponse<List<OrderResponse>>(mapped);
        }

        public async Task<ApiResponse<List<OrderResponse>>> Handle(GetAllOrderByDealerQuery request, CancellationToken cancellationToken)
        {
            List<Order> list = await dbContext.Set<Order>()
                .Include(x => x.Dealer)
                .Include(x => x.OrderItems)
                .Where(x => x.DealerId == request.DealerId)
                .ToListAsync(cancellationToken);

            if (list.Count == 0)
                return new ApiResponse<List<OrderResponse>>("Record not found!");

            foreach (var item in list)
            {
                item.Dealer = await dbContext.Set<Dealer>().FirstOrDefaultAsync(x => x.Id == item.DealerId, cancellationToken);
            }

            var mapped = mapper.Map<List<OrderResponse>>(list);

            return new ApiResponse<List<OrderResponse>>(mapped);
        }

        public async Task<ApiResponse<OrderResponse>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            Order? entity = await dbContext.Set<Order>()
                .Include(x => x.OrderItems)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity is null)
                return new ApiResponse<OrderResponse>("Record not found!");

            var mapped = mapper.Map<OrderResponse>(entity);

            return new ApiResponse<OrderResponse>(mapped);
        }
    }
}
