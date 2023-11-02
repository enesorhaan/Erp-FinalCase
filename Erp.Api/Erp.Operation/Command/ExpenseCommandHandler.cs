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
    public class ExpenseCommandHandler :
        IRequestHandler<CreateExpenseCommand, ApiResponse<ExpenseResponse>>,
        IRequestHandler<UpdateExpenseCommand, ApiResponse>,
        IRequestHandler<DeleteExpenseCommand, ApiResponse>
    {
        private readonly MyDbContext dbContext;
        private readonly IMapper mapper;

        public ExpenseCommandHandler(MyDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<ExpenseResponse>> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
        {
            Expense mapped = mapper.Map<Expense>(request.Model);
            mapped.DealerId = request.DealerId;

            var entity = await dbContext.Set<Expense>().AddAsync(mapped, cancellationToken);

            entity.Entity.InsertDate = DateTime.Now;
            await dbContext.SaveChangesAsync(cancellationToken);

            var response = mapper.Map<ExpenseResponse>(entity.Entity);
            return new ApiResponse<ExpenseResponse>(response);
        }

        public async Task<ApiResponse> Handle(UpdateExpenseCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Set<Expense>().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null)
                return new ApiResponse("Record not found!");

            if (entity.DealerId != request.DealerId)
                return new ApiResponse("You are not authorized to update this record!");

            entity.UpdateDate = DateTime.Now;
            entity.Description = request.Model.Description;
            entity.Amount = request.Model.Amount;
            entity.ExpenseDate = request.Model.ExpenseDate;

            await dbContext.SaveChangesAsync(cancellationToken);
            return new ApiResponse();
        }

        public async Task<ApiResponse> Handle(DeleteExpenseCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Set<Expense>().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null)
                return new ApiResponse("Record not found!");

            if (entity.DealerId != request.DealerId)
                return new ApiResponse("You are not authorized to delete this record!");

            entity.IsActive = false;

            await dbContext.SaveChangesAsync(cancellationToken);
            return new ApiResponse();
        }
    }
}
