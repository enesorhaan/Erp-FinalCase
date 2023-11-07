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
    public class ExpensesController : ControllerBase
    {
        private IMediator mediator;
        public ExpensesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet()]
        [Authorize(Roles = "dealer")]
        public async Task<ApiResponse<List<ExpenseResponse>>> GetAll()
        {
            var dealerId = (User.Identity as ClaimsIdentity).FindFirst("Id").Value;

            var operation = new GetAllExpenseQuery(int.Parse(dealerId));
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "dealer")]
        public async Task<ApiResponse<ExpenseResponse>> Get(int id)
        {
            var dealerId = (User.Identity as ClaimsIdentity).FindFirst("Id").Value;

            var operation = new GetExpenseByIdQuery(id, int.Parse(dealerId));
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpPost]
        [Authorize(Roles = "dealer")]
        public async Task<ApiResponse<ExpenseResponse>> Post([FromBody] ExpenseRequest request)
        {
            var dealerId = (User.Identity as ClaimsIdentity).FindFirst("Id").Value;

            var operation = new CreateExpenseCommand(request, int.Parse(dealerId));
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "dealer")]
        public async Task<ApiResponse> Put(int id, [FromBody] ExpenseRequest request)
        {
            var dealerId = (User.Identity as ClaimsIdentity).FindFirst("Id").Value;

            var operation = new UpdateExpenseCommand(request, id, int.Parse(dealerId));
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "dealer")]
        public async Task<ApiResponse> Delete(int id)
        {
            var dealerId = (User.Identity as ClaimsIdentity).FindFirst("Id").Value;

            var operation = new DeleteExpenseCommand(id, int.Parse(dealerId));
            var result = await mediator.Send(operation);
            return result;
        }

    }
}
