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
    public class OrdersController : ControllerBase
    {
        private IMediator mediator;
        public OrdersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ApiResponse<List<OrderResponse>>> GetAll()
        {
            var operation = new GetAllOrderQuery();
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ApiResponse<OrderResponse>> Get(int id)
        {
            var operation = new GetOrderByIdQuery(id);
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpPost]
        [Authorize(Roles = "dealer")]
        public async Task<ApiResponse<OrderResponse>> Post([FromBody] OrderCreateRequest request)
        {
            var dealerId = (User.Identity as ClaimsIdentity).FindFirst("Id").Value;

            var operation = new CreateOrderCommand(request, int.Parse(dealerId));
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpPut("{id}")]
        public async Task<ApiResponse> Put(int id, [FromBody] OrderUpdateRequest request)
        {
            var operation = new UpdateOrderCommand(request, id);
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpDelete("{id}")]
        public async Task<ApiResponse> Delete(int id)
        {
            var operation = new DeleteOrderCommand(id);
            var result = await mediator.Send(operation);
            return result;
        }

    }
}
