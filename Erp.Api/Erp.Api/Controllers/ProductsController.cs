using Erp.Base.Response;
using Erp.Data.UoW;
using Erp.Dto;
using Erp.Operation.Cqrs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Erp.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private IMediator mediator;
        public ProductsController(IUnitOfWork unitOfWork, IMediator mediator)
        {
            this.unitOfWork = unitOfWork;
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ApiResponse<List<ProductResponse>>> GetAll()
        {
            var operation = new GetAllProductQuery();
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ApiResponse<ProductResponse>> Get(int id)
        {
            var operation = new GetProductByIdQuery(id);
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpPost]
        public async Task<ApiResponse<ProductResponse>> Post([FromBody] ProductRequest request)
        {
            var operation = new CreateProductCommand(request);
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpPut("{id}")]
        public async Task<ApiResponse> Put(int id, [FromBody] ProductRequest request)
        {
            var operation = new UpdateProductCommand(request, id);
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpDelete("{id}")]
        public async Task<ApiResponse> Delete(int id)
        {
            var operation = new DeleteProductCommand(id);
            var result = await mediator.Send(operation);
            return result;
        }

    }
}
