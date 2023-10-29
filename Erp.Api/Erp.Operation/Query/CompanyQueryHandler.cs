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
    public class CompanyQueryHandler :
        IRequestHandler<GetAllCompanyQuery, ApiResponse<List<CompanyResponse>>>,
        IRequestHandler<GetCompanyByIdQuery, ApiResponse<CompanyResponse>>
    {
        private readonly MyDbContext dbContext;
        private readonly IMapper mapper;

        public CompanyQueryHandler(MyDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<List<CompanyResponse>>> Handle(GetAllCompanyQuery request, CancellationToken cancellationToken)
        {
            List<Company> list = await dbContext.Set<Company>()
                .Include(x => x.Dealers)
                .Include(x => x.Products)
                .Include(x => x.Messages)
                .Include(x => x.CurrentAccounts)
                .ToListAsync(cancellationToken);
            var mapped = mapper.Map<List<CompanyResponse>>(list);

            return new ApiResponse<List<CompanyResponse>>(mapped);
        }

        public async Task<ApiResponse<CompanyResponse>> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
        {
            Company? entity = await dbContext.Set<Company>()
                .Include(x => x.Dealers)
                .Include(x => x.Products)
                .Include(x => x.Messages)
                .Include(x => x.CurrentAccounts)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity is null)
                return new ApiResponse<CompanyResponse>("Record not found!");

            var mapped = mapper.Map<CompanyResponse>(entity);

            return new ApiResponse<CompanyResponse>(mapped);
        }
    }
}
