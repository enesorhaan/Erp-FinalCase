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
    public class CompanyCommandHandler :
        IRequestHandler<CreateCompanyCommand, ApiResponse<CompanyResponse>>,
        IRequestHandler<UpdateCompanyCommand, ApiResponse>,
        IRequestHandler<DeleteCompanyCommand, ApiResponse>
    {
        private readonly MyDbContext dbContext;
        private readonly IMapper mapper;

        public CompanyCommandHandler(MyDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<CompanyResponse>> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            Company mapped = mapper.Map<Company>(request.Model);

            var company = await dbContext.Set<Company>().FirstOrDefaultAsync(x => x.Email == mapped.Email, cancellationToken);

            if (company != null)
                return new ApiResponse<CompanyResponse>("Email already exists!");

            var entity = await dbContext.Set<Company>().AddAsync(mapped, cancellationToken);
            entity.Entity.InsertDate = DateTime.Now;
            await dbContext.SaveChangesAsync(cancellationToken);

            var response = mapper.Map<CompanyResponse>(entity.Entity);
            return new ApiResponse<CompanyResponse>(response);
        }

        public async Task<ApiResponse> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Set<Company>().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null)
                return new ApiResponse("Record not found!");

            entity.UpdateDate = DateTime.Now;
            entity.Email = request.Model.Email;

            await dbContext.SaveChangesAsync(cancellationToken);
            return new ApiResponse();
        }

        public async Task<ApiResponse> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Set<Company>().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null)
                return new ApiResponse("Record not found!");

            entity.IsActive = false;

            await dbContext.SaveChangesAsync(cancellationToken);
            return new ApiResponse();
        }
    }
}
