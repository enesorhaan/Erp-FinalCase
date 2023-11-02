using Erp.Base.Response;
using Erp.Data.UoW;
using Erp.Dto;
using Erp.Operation.Cqrs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace Erp.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private IMediator mediator;
        public OrderItemsController(IUnitOfWork unitOfWork, IMediator mediator)
        {
            this.unitOfWork = unitOfWork;
            this.mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = "dealer")]
        public async Task<ApiResponse<List<OrderItemResponse>>> GetAll()
        {
            var dealerId = (User.Identity as ClaimsIdentity).FindFirst("Id").Value;

            var operation = new GetAllOrderItemQuery(int.Parse(dealerId));
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "dealer")]
        public async Task<ApiResponse<OrderItemResponse>> Get(int id)
        {
            var dealerId = (User.Identity as ClaimsIdentity).FindFirst("Id").Value;

            var operation = new GetOrderItemByIdQuery(id, int.Parse(dealerId));
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpPost]
        [Authorize(Roles = "dealer")]
        public async Task<ApiResponse<OrderItemResponse>> Post([FromBody] OrderItemRequest request)
        {
            var dealerId = (User.Identity as ClaimsIdentity).FindFirst("Id").Value;

            var operation = new CreateOrderItemCommand(request, int.Parse(dealerId));
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "dealer")]
        public async Task<ApiResponse> Put(int id, [FromBody] OrderItemUpdateRequest request)
        {
            var dealerId = (User.Identity as ClaimsIdentity).FindFirst("Id").Value;

            var operation = new UpdateOrderItemCommand(request, id, int.Parse(dealerId));
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "dealer")]
        public async Task<ApiResponse> Delete(int id)
        {
            var dealerId = (User.Identity as ClaimsIdentity).FindFirst("Id").Value;

            var operation = new DeleteOrderItemCommand(id, int.Parse(dealerId));
            var result = await mediator.Send(operation);
            return result;
        }

    }
}
