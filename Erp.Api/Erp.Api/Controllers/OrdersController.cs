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

        [HttpGet("byCompany")]
        [Authorize(Roles = "admin")]
        public async Task<ApiResponse<List<OrderResponse>>> GetAllByCompany()
        {
            var operation = new GetAllOrderByCompanyQuery();
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpGet("byDealer")]
        [Authorize(Roles = "dealer")]
        public async Task<ApiResponse<List<OrderResponse>>> GetAllByDealer()
        {
            var dealerId = (User.Identity as ClaimsIdentity).FindFirst("Id").Value;

            var operation = new GetAllOrderByDealerQuery(int.Parse(dealerId));
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
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

        [HttpPut("byCompany/{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ApiResponse> PutByCompany(int id, [FromBody] OrderUpdateRequest request)
        {
            var operation = new UpdateOrderCommandByCompany(request, id);
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpPut("byDealer/{id}")]
        [Authorize(Roles = "dealer")]
        public async Task<ApiResponse> PutByDealer(int id, [FromBody] OrderUpdateRequest request)
        {
            var dealerId = (User.Identity as ClaimsIdentity).FindFirst("Id").Value;

            var operation = new UpdateOrderCommandByDealer(request, int.Parse(dealerId), id);
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ApiResponse> Delete(int id)
        {
            var operation = new DeleteOrderCommand(id);
            var result = await mediator.Send(operation);
            return result;
        }

    }
}
