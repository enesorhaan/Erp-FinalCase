using Erp.Base.Response;
using Erp.Dto;
using Erp.Operation.Cqrs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Erp.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IMediator mediator;
        public ProductsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = "admin, dealer")]
        public async Task<ApiResponse<List<ProductResponse>>> GetAll()
        {
            var role = (User.Identity as ClaimsIdentity).FindFirst("Role").Value;
            var id = (User.Identity as ClaimsIdentity).FindFirst("Id").Value;

            var operation = new GetAllProductQuery(role, int.Parse(id));
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ApiResponse<ProductResponse>> Get(int id)
        {
            var operation = new GetProductByIdQuery(id);
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ApiResponse<ProductResponse>> Post([FromBody] ProductRequest request)
        {
            var operation = new CreateProductCommand(request);
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ApiResponse> Put(int id, [FromBody] ProductRequest request)
        {
            var operation = new UpdateProductCommand(request, id);
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ApiResponse> Delete(int id)
        {
            var operation = new DeleteProductCommand(id);
            var result = await mediator.Send(operation);
            return result;
        }

    }
}
