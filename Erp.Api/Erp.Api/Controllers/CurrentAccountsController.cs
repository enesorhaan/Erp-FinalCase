using Erp.Base.Response;
using Erp.Dto;
using Erp.Operation.Cqrs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Erp.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class CurrentAccountsController : ControllerBase
    {
        private IMediator mediator;
        public CurrentAccountsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<ApiResponse<List<CurrentAccountResponse>>> GetAll()
        {
            var operation = new GetAllCurrentAccountQuery();
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ApiResponse<CurrentAccountResponse>> Get(int id)
        {
            var operation = new GetCurrentAccountByIdQuery(id);
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ApiResponse<CurrentAccountResponse>> Post([FromBody] CurrentAccountRequest request)
        {
            var operation = new CreateCurrentAccountCommand(request);
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ApiResponse> Put(int id, [FromBody] CurrentAccountUpdateRequest request)
        {
            var operation = new UpdateCurrentAccountCommand(request, id);
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ApiResponse> Delete(int id)
        {
            var operation = new DeleteCurrentAccountCommand(id);
            var result = await mediator.Send(operation);
            return result;
        }

    }
}
