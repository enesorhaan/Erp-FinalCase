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
    public class MessagesController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private IMediator mediator;
        public MessagesController(IUnitOfWork unitOfWork, IMediator mediator)
        {
            this.unitOfWork = unitOfWork;
            this.mediator = mediator;
        }

        [HttpGet("admin")]
        [Authorize(Roles = "admin")]
        public async Task<ApiResponse<List<MessageResponse>>> GetAllByAdmin()
        {
            var id = (User.Identity as ClaimsIdentity).FindFirst("Id").Value;

            var operation = new GetAllMessageQueryByAdmin(int.Parse(id));
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpGet("dealer")]
        [Authorize(Roles = "dealer")]
        public async Task<ApiResponse<List<MessageResponse>>> GetAllDealer()
        {
            var id = (User.Identity as ClaimsIdentity).FindFirst("Id").Value;

            var operation = new GetAllMessageQueryByDealer(int.Parse(id));
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ApiResponse<MessageResponse>> Get(int id)
        {
            var operation = new GetMessageByIdQuery(id);
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpPost("admin")]
        [Authorize(Roles = "admin")]
        public async Task<ApiResponse<MessageResponse>> PostAdmin([FromBody] AdminMessageRequest request)
        {
            var operation = new CreateAdminMessageCommand(request);
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpPost("dealer")]
        [Authorize(Roles = "dealer")]
        public async Task<ApiResponse<MessageResponse>> PostDealer([FromBody] DealerMessageRequest request)
        {
            var id = (User.Identity as ClaimsIdentity).FindFirst("Id").Value;

            var operation = new CreateDealerMessageCommand(request, int.Parse(id));
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ApiResponse> Put(int id, [FromBody] AdminMessageRequest request)
        {
            var operation = new UpdateMessageCommand(request, id);
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ApiResponse> Delete(int id)
        {
            var operation = new DeleteMessageCommand(id);
            var result = await mediator.Send(operation);
            return result;
        }

    }
}
