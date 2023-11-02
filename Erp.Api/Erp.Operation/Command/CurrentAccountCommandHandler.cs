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
    public class CurrentAccountCommandHandler :
        IRequestHandler<CreateCurrentAccountCommand, ApiResponse<CurrentAccountResponse>>,
        IRequestHandler<UpdateCurrentAccountCommand, ApiResponse>,
        IRequestHandler<DeleteCurrentAccountCommand, ApiResponse>
    {
        private readonly MyDbContext dbContext;
        private readonly IMapper mapper;

        public CurrentAccountCommandHandler(MyDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<CurrentAccountResponse>> Handle(CreateCurrentAccountCommand request, CancellationToken cancellationToken)
        {
            CurrentAccount mapped = mapper.Map<CurrentAccount>(request.Model);

            mapped.CompanyId = 1;
            mapped.Company = await dbContext.Set<Company>().FirstOrDefaultAsync(x => x.Id == mapped.CompanyId, cancellationToken);
            mapped.Dealer = await dbContext.Set<Dealer>().FirstOrDefaultAsync(x => x.Id == request.Model.DealerId, cancellationToken);
            
            var Dealer = await dbContext.Set<CurrentAccount>().FirstOrDefaultAsync(x => x.DealerId == request.Model.DealerId, cancellationToken);

            if (Dealer != null)
                return new ApiResponse<CurrentAccountResponse>("Dealer Account already exists!");

            var entity = await dbContext.Set<CurrentAccount>().AddAsync(mapped, cancellationToken);
            entity.Entity.InsertDate = DateTime.Now;
            await dbContext.SaveChangesAsync(cancellationToken);

            var response = mapper.Map<CurrentAccountResponse>(entity.Entity);
            return new ApiResponse<CurrentAccountResponse>(response);
        }

        public async Task<ApiResponse> Handle(UpdateCurrentAccountCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Set<CurrentAccount>().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null)
                return new ApiResponse("Record not found!");

            entity.UpdateDate = DateTime.Now;
            entity.CreditLimit = request.Model.CreditLimit;

            await dbContext.SaveChangesAsync(cancellationToken);
            return new ApiResponse();
        }

        public async Task<ApiResponse> Handle(DeleteCurrentAccountCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Set<CurrentAccount>().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null)
                return new ApiResponse("Record not found!");

            entity.IsActive = false;

            await dbContext.SaveChangesAsync(cancellationToken);
            return new ApiResponse();
        }
    }
}
