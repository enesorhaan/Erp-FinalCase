using Erp.Base.Response;
using Erp.Dto;
using MediatR;

namespace Erp.Operation.Cqrs
{
    public record CreateProductCommand(ProductRequest Model) : IRequest<ApiResponse<ProductResponse>>;
    public record UpdateProductCommand(ProductRequest Model, int Id) : IRequest<ApiResponse>;
    public record DeleteProductCommand(int Id) : IRequest<ApiResponse>;

    public record GetAllProductQuery() : IRequest<ApiResponse<List<ProductResponse>>>;
    public record GetProductByIdQuery(int Id) : IRequest<ApiResponse<ProductResponse>>;

}
