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
    public class ExpenseQueryHandler :
        IRequestHandler<GetAllExpenseQuery, ApiResponse<List<ExpenseResponse>>>,
        IRequestHandler<GetExpenseByIdQuery, ApiResponse<ExpenseResponse>>,
        IRequestHandler<GetAllActiveExpenseQuery, ApiResponse<List<ExpenseResponse>>>,
        IRequestHandler<GetAllPastExpenseQuery, ApiResponse<List<ExpenseResponse>>>
    {
        private readonly MyDbContext dbContext;
        private readonly IMapper mapper;

        public ExpenseQueryHandler(MyDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<List<ExpenseResponse>>> Handle(GetAllExpenseQuery request, CancellationToken cancellationToken)
        {
            List<Expense> list = await dbContext.Set<Expense>()
                .Include(x => x.Dealer)
                .Where(x => x.DealerId == request.DealerId)
                .ToListAsync(cancellationToken);

            

            var mapped = mapper.Map<List<ExpenseResponse>>(list);

            return new ApiResponse<List<ExpenseResponse>>(mapped);
        }

        public async Task<ApiResponse<ExpenseResponse>> Handle(GetExpenseByIdQuery request, CancellationToken cancellationToken)
        {
            Expense? entity = await dbContext.Set<Expense>()
                .Include(x => x.Dealer)
                .Where(x => x.DealerId == request.DealerId)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity is null)
                return new ApiResponse<ExpenseResponse>("Record not found!");

            var mapped = mapper.Map<ExpenseResponse>(entity);

            return new ApiResponse<ExpenseResponse>(mapped);
        }

        public async Task<ApiResponse<List<ExpenseResponse>>> Handle(GetAllActiveExpenseQuery request, CancellationToken cancellationToken)
        {
            List<Expense> list = await dbContext.Set<Expense>()
                .Include(x => x.Dealer)
                .Where(x => x.DealerId == request.DealerId && x.IsActive == true)
                .ToListAsync(cancellationToken);

            if (list.Count == 0)
                return new ApiResponse<List<ExpenseResponse>>("Record not found!");

            var mapped = mapper.Map<List<ExpenseResponse>>(list);

            return new ApiResponse<List<ExpenseResponse>>(mapped);
        }

        public async Task<ApiResponse<List<ExpenseResponse>>> Handle(GetAllPastExpenseQuery request, CancellationToken cancellationToken)
        {
            List<Expense> list = await dbContext.Set<Expense>()
                .Include(x => x.Dealer)
                .Where(x => x.DealerId == request.DealerId && x.IsActive == false)
                .ToListAsync(cancellationToken);

            if (list.Count == 0)
                return new ApiResponse<List<ExpenseResponse>>("Record not found!");

            var mapped = mapper.Map<List<ExpenseResponse>>(list);

            return new ApiResponse<List<ExpenseResponse>>(mapped);
        }
    }
}
