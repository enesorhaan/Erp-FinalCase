using Erp.Base.Response;
using Erp.Dto;
using MediatR;

namespace Erp.Operation.Cqrs
{
    public record CreateOrderCommand(OrderCreateRequest Model, int DealerId) : IRequest<ApiResponse<OrderResponse>>;
    public record UpdateOrderCommand(OrderUpdateRequest Model, int Id) : IRequest<ApiResponse>;
    public record DeleteOrderCommand(int Id) : IRequest<ApiResponse>;

    public record GetAllOrderQuery() : IRequest<ApiResponse<List<OrderResponse>>>;
    public record GetOrderByIdQuery(int Id) : IRequest<ApiResponse<OrderResponse>>;

}
