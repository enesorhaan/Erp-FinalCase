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
    public class MessagesController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private IMediator mediator;
        public MessagesController(IUnitOfWork unitOfWork, IMediator mediator)
        {
            this.unitOfWork = unitOfWork;
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ApiResponse<List<MessageResponse>>> GetAll()
        {
            var operation = new GetAllMessageQuery();
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ApiResponse<MessageResponse>> Get(int id)
        {
            var operation = new GetMessageByIdQuery(id);
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpPost]
        public async Task<ApiResponse<MessageResponse>> Post([FromBody] MessageRequest request)
        {
            var operation = new CreateMessageCommand(request);
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpPut("{id}")]
        public async Task<ApiResponse> Put(int id, [FromBody] MessageRequest request)
        {
            var operation = new UpdateMessageCommand(request, id);
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpDelete("{id}")]
        public async Task<ApiResponse> Delete(int id)
        {
            var operation = new DeleteMessageCommand(id);
            var result = await mediator.Send(operation);
            return result;
        }

    }
}
