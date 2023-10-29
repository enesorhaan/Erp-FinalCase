using Erp.Base.Response;
using Erp.Dto;
using MediatR;

namespace Erp.Operation.Cqrs
{
    public record CreateMessageCommand(MessageRequest Model) : IRequest<ApiResponse<MessageResponse>>;
    public record UpdateMessageCommand(MessageRequest Model, int Id) : IRequest<ApiResponse>;
    public record DeleteMessageCommand(int Id) : IRequest<ApiResponse>;

    public record GetAllMessageQuery() : IRequest<ApiResponse<List<MessageResponse>>>;
    public record GetMessageByIdQuery(int Id) : IRequest<ApiResponse<MessageResponse>>;

}
