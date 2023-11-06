using Erp.Base.Response;
using Erp.Dto;
using MediatR;

namespace Erp.Operation.Cqrs
{
    public record CreateCurrentAccountCommand(CurrentAccountRequest Model) : IRequest<ApiResponse<CurrentAccountResponse>>;
    public record UpdateCurrentAccountCommand(CurrentAccountUpdateRequest Model, int Id) : IRequest<ApiResponse>;
    public record DeleteCurrentAccountCommand(int Id) : IRequest<ApiResponse>;

    public record GetAllCurrentAccountQuery() : IRequest<ApiResponse<List<CurrentAccountResponse>>>;
    public record GetCurrentAccountByIdQuery(int Id) : IRequest<ApiResponse<CurrentAccountResponse>>;

}
