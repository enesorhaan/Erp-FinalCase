using Erp.Base.Response;
using Erp.Dto;
using MediatR;

namespace Erp.Operation.Cqrs
{
    public record CreateLoginCommand(LoginRequest Model) : IRequest<ApiResponse<LoginResponse>>;
}
