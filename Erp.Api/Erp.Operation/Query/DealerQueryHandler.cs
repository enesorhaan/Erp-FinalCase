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
    public class DealerQueryHandler :
        IRequestHandler<GetAllDealerQuery, ApiResponse<List<DealerResponse>>>,
        IRequestHandler<GetDealerByIdQuery, ApiResponse<DealerResponse>>
    {
        private readonly MyDbContext dbContext;
        private readonly IMapper mapper;

        public DealerQueryHandler(MyDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<List<DealerResponse>>> Handle(GetAllDealerQuery request, CancellationToken cancellationToken)
        {
            List<Dealer> list = await dbContext.Set<Dealer>()
                .Where(x => x.IsActive)
                .ToListAsync(cancellationToken);
            
            foreach (var item in list)
            {
                item.Company = await dbContext.Set<Company>()
                    .FirstOrDefaultAsync(x => x.Id == item.CompanyId, cancellationToken);
            }

            var mapped = mapper.Map<List<DealerResponse>>(list);

            return new ApiResponse<List<DealerResponse>>(mapped);
        }

        public async Task<ApiResponse<DealerResponse>> Handle(GetDealerByIdQuery request, CancellationToken cancellationToken)
        {
            Dealer? entity = await dbContext.Set<Dealer>()
                .Where(x => x.IsActive)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity is null)
                return new ApiResponse<DealerResponse>("Record not found!");


            var mapped = mapper.Map<DealerResponse>(entity);

            return new ApiResponse<DealerResponse>(mapped);
        }
    }
}
