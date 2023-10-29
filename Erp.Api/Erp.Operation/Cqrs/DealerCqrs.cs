using Erp.Base.Response;
using Erp.Dto;
using MediatR;

namespace Erp.Operation.Cqrs
{
    public record CreateDealerCommand(DealerRequest Model) : IRequest<ApiResponse<DealerResponse>>;
    public record UpdateDealerCommand(DealerRequest Model, int Id) : IRequest<ApiResponse>;
    public record DeleteDealerCommand(int Id) : IRequest<ApiResponse>;

    public record GetAllDealerQuery() : IRequest<ApiResponse<List<DealerResponse>>>;
    public record GetDealerByIdQuery(int Id) : IRequest<ApiResponse<DealerResponse>>;

}
