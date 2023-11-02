using Erp.Base.Response;
using Erp.Data.Entities;
using Erp.Dto;
using MediatR;

namespace Erp.Operation.Cqrs
{
    public record CreateOrderItemCommand(OrderItemRequest Model, int DealerId) : IRequest<ApiResponse<OrderItemResponse>>;
    public record UpdateOrderItemCommand(OrderItemUpdateRequest Model, int Id,int DealerId) : IRequest<ApiResponse>;
    public record DeleteOrderItemCommand(int Id, int DealerId) : IRequest<ApiResponse>;

    public record GetAllOrderItemQuery(int DealerId) : IRequest<ApiResponse<List<OrderItemResponse>>>;
    public record GetOrderItemByIdQuery(int Id, int DealerId) : IRequest<ApiResponse<OrderItemResponse>>;

}
