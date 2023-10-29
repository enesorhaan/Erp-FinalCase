using Erp.Base.Response;
using Erp.Dto;
using MediatR;

namespace Erp.Operation.Cqrs
{
    public record CreateOrderItemCommand(OrderItemRequest Model) : IRequest<ApiResponse<OrderItemResponse>>;
    public record UpdateOrderItemCommand(OrderItemRequest Model, int Id) : IRequest<ApiResponse>;
    public record DeleteOrderItemCommand(int Id) : IRequest<ApiResponse>;

    public record GetAllOrderItemQuery() : IRequest<ApiResponse<List<OrderItemResponse>>>;
    public record GetOrderItemByIdQuery(int Id) : IRequest<ApiResponse<OrderItemResponse>>;

}
