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
    public class DealerCommandHandler :
        IRequestHandler<CreateDealerCommand, ApiResponse<DealerResponse>>,
        IRequestHandler<UpdateDealerCommand, ApiResponse>,
        IRequestHandler<DeleteDealerCommand, ApiResponse>
    {
        private readonly MyDbContext dbContext;
        private readonly IMapper mapper;

        public DealerCommandHandler(MyDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<DealerResponse>> Handle(CreateDealerCommand request, CancellationToken cancellationToken)
        {
            Dealer mapped = mapper.Map<Dealer>(request.Model);

            var entity = await dbContext.Set<Dealer>().AddAsync(mapped, cancellationToken);
            entity.Entity.InsertDate = DateTime.Now;
            await dbContext.SaveChangesAsync(cancellationToken);

            var response = mapper.Map<DealerResponse>(entity.Entity);
            return new ApiResponse<DealerResponse>(response);
        }

        public async Task<ApiResponse> Handle(UpdateDealerCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Set<Dealer>().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null)
                return new ApiResponse("Record not found!");

            entity.UpdateDate = DateTime.Now;
            entity.MarginPercentage = request.Model.MarginPercentage;

            await dbContext.SaveChangesAsync(cancellationToken);
            return new ApiResponse();
        }

        public async Task<ApiResponse> Handle(DeleteDealerCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Set<Dealer>().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null)
                return new ApiResponse("Record not found!");

            entity.IsActive = false;

            await dbContext.SaveChangesAsync(cancellationToken);
            return new ApiResponse();
        }
    }
}
