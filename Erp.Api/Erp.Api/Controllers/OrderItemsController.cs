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
        public async Task<ApiResponse<List<OrderItemResponse>>> GetAll()
        {
            var operation = new GetAllOrderItemQuery();
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ApiResponse<OrderItemResponse>> Get(int id)
        {
            var operation = new GetOrderItemByIdQuery(id);
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpPost]
        public async Task<ApiResponse<OrderItemResponse>> Post([FromBody] OrderItemRequest request)
        {
            var operation = new CreateOrderItemCommand(request);
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpPut("{id}")]
        public async Task<ApiResponse> Put(int id, [FromBody] OrderItemRequest request)
        {
            var operation = new UpdateOrderItemCommand(request, id);
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpDelete("{id}")]
        public async Task<ApiResponse> Delete(int id)
        {
            var operation = new DeleteOrderItemCommand(id);
            var result = await mediator.Send(operation);
            return result;
        }

    }
}
