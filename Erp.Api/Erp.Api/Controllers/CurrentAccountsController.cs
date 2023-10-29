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
    public class CurrentAccountsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private IMediator mediator;
        public CurrentAccountsController(IUnitOfWork unitOfWork, IMediator mediator)
        {
            this.unitOfWork = unitOfWork;
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ApiResponse<List<CurrentAccountResponse>>> GetAll()
        {
            var operation = new GetAllCurrentAccountQuery();
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ApiResponse<CurrentAccountResponse>> Get(int id)
        {
            var operation = new GetCurrentAccountByIdQuery(id);
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpPost]
        public async Task<ApiResponse<CurrentAccountResponse>> Post([FromBody] CurrentAccountRequest request)
        {
            var operation = new CreateCurrentAccountCommand(request);
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpPut("{id}")]
        public async Task<ApiResponse> Put(int id, [FromBody] CurrentAccountRequest request)
        {
            var operation = new UpdateCurrentAccountCommand(request, id);
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpDelete("{id}")]
        public async Task<ApiResponse> Delete(int id)
        {
            var operation = new DeleteCurrentAccountCommand(id);
            var result = await mediator.Send(operation);
            return result;
        }

    }
}
