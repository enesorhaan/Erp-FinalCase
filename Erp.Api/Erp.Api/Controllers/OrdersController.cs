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
    public class OrdersController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private IMediator mediator;
        public OrdersController(IUnitOfWork unitOfWork, IMediator mediator)
        {
            this.unitOfWork = unitOfWork;
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
        public async Task<ApiResponse<OrderResponse>> Post([FromBody] OrderRequest request)
        {
            var operation = new CreateOrderCommand(request);
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpPut("{id}")]
        public async Task<ApiResponse> Put(int id, [FromBody] OrderRequest request)
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
