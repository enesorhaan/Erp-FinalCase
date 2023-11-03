using Erp.Base.Response;
using Erp.Dto;
using MediatR;

namespace Erp.Operation.Cqrs
{
    public record CreateOrderCommand(OrderCreateRequest Model, int DealerId) : IRequest<ApiResponse<OrderResponse>>;
    public record UpdateOrderCommandByCompany(OrderUpdateRequest Model, int Id) : IRequest<ApiResponse>;
    public record UpdateOrderCommandByDealer(OrderUpdateRequest Model, int DealerId, int Id) : IRequest<ApiResponse>;
    public record DeleteOrderCommand(int Id) : IRequest<ApiResponse>;

    public record GetAllOrderByCompanyQuery() : IRequest<ApiResponse<List<OrderResponse>>>;
    public record GetAllOrderByDealerQuery(int DealerId) : IRequest<ApiResponse<List<OrderResponse>>>;
    public record GetOrderByIdQuery(int Id) : IRequest<ApiResponse<OrderResponse>>;

}
