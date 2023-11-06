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
    public class ProductQueryHandler :
        IRequestHandler<GetAllProductQuery, ApiResponse<List<ProductResponse>>>,
        IRequestHandler<GetProductByIdQuery, ApiResponse<ProductResponse>>
    {
        private readonly MyDbContext dbContext;
        private readonly IMapper mapper;

        public ProductQueryHandler(MyDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<List<ProductResponse>>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            List<Product> list = await dbContext.Set<Product>()
                    .Where(x => x.IsActive)
                    .Include(x => x.OrderItems)
                    .ToListAsync(cancellationToken);

            Dealer? dealer = await dbContext.Set<Dealer>()
                .FirstOrDefaultAsync(x => x.Id == request.DealerId, cancellationToken);

            if (request.role == "dealer")
            {
                foreach (var item in list)
                {
                    item.ProductPrice += item.ProductPrice * dealer.MarginPercentage / 100;
                }
            }

            var mapped = mapper.Map<List<ProductResponse>>(list);

            return new ApiResponse<List<ProductResponse>>(mapped);
        }

        public async Task<ApiResponse<ProductResponse>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            Product? entity = await dbContext.Set<Product>()
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity is null)
                return new ApiResponse<ProductResponse>("Record not found!");

            var mapped = mapper.Map<ProductResponse>(entity);

            return new ApiResponse<ProductResponse>(mapped);
        }

        
    }
}
