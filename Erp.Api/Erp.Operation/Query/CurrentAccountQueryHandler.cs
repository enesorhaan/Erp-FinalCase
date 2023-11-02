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
    public class CurrentAccountQueryHandler :
        IRequestHandler<GetAllCurrentAccountQuery, ApiResponse<List<CurrentAccountResponse>>>,
        IRequestHandler<GetCurrentAccountByIdQuery, ApiResponse<CurrentAccountResponse>>
    {
        private readonly MyDbContext dbContext;
        private readonly IMapper mapper;

        public CurrentAccountQueryHandler(MyDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<List<CurrentAccountResponse>>> Handle(GetAllCurrentAccountQuery request, CancellationToken cancellationToken)
        {
            List<CurrentAccount> list = await dbContext.Set<CurrentAccount>()
                .ToListAsync(cancellationToken);

            foreach (var item in list)
            {
                item.Company = await dbContext.Set<Company>().FirstOrDefaultAsync(x => x.Id == item.CompanyId, cancellationToken);
                item.Dealer = await dbContext.Set<Dealer>().FirstOrDefaultAsync(x => x.Id == item.DealerId, cancellationToken);
            }

            var mapped = mapper.Map<List<CurrentAccountResponse>>(list);

            return new ApiResponse<List<CurrentAccountResponse>>(mapped);
        }

        public async Task<ApiResponse<CurrentAccountResponse>> Handle(GetCurrentAccountByIdQuery request, CancellationToken cancellationToken)
        {
            CurrentAccount? entity = await dbContext.Set<CurrentAccount>()
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity is null)
                return new ApiResponse<CurrentAccountResponse>("Record not found!");

            entity.Company = await dbContext.Set<Company>().FirstOrDefaultAsync(x => x.Id == entity.CompanyId, cancellationToken);
            entity.Dealer = await dbContext.Set<Dealer>().FirstOrDefaultAsync(x => x.Id == entity.DealerId, cancellationToken);

            var mapped = mapper.Map<CurrentAccountResponse>(entity);

            return new ApiResponse<CurrentAccountResponse>(mapped);
        }
    }
}
