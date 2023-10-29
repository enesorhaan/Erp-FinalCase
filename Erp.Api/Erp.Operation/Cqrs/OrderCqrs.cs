using Erp.Base.Response;
using Erp.Dto;
using MediatR;

namespace Erp.Operation.Cqrs
{
    public record CreateOrderCommand(OrderRequest Model) : IRequest<ApiResponse<OrderResponse>>;
    public record UpdateOrderCommand(OrderRequest Model, int Id) : IRequest<ApiResponse>;
    public record DeleteOrderCommand(int Id) : IRequest<ApiResponse>;

    public record GetAllOrderQuery() : IRequest<ApiResponse<List<OrderResponse>>>;
    public record GetOrderByIdQuery(int Id) : IRequest<ApiResponse<OrderResponse>>;

}
