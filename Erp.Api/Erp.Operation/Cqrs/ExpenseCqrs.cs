using Erp.Base.Response;
using Erp.Dto;
using MediatR;

namespace Erp.Operation.Cqrs
{
    public record CreateExpenseCommand(ExpenseRequest Model, int DealerId) : IRequest<ApiResponse<ExpenseResponse>>;
    public record UpdateExpenseCommand(ExpenseRequest Model, int Id, int DealerId) : IRequest<ApiResponse>;
    public record DeleteExpenseCommand(int Id, int DealerId) : IRequest<ApiResponse>;

    public record GetAllExpenseQuery(int DealerId) : IRequest<ApiResponse<List<ExpenseResponse>>>;
    public record GetExpenseByIdQuery(int Id, int DealerId) : IRequest<ApiResponse<ExpenseResponse>>;
}
