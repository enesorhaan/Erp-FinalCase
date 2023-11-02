using Erp.Base.Response;
using Erp.Dto;
using MediatR;

namespace Erp.Operation.Cqrs
{
    public record CreateAdminMessageCommand(AdminMessageRequest Model) : IRequest<ApiResponse<MessageResponse>>;
    public record CreateDealerMessageCommand(DealerMessageRequest Model, int id) : IRequest<ApiResponse<MessageResponse>>;
    public record UpdateMessageCommand(AdminMessageRequest Model, int Id) : IRequest<ApiResponse>;
    public record DeleteMessageCommand(int Id) : IRequest<ApiResponse>;

    public record GetAllMessageQueryByAdmin(int AdminId) : IRequest<ApiResponse<List<MessageResponse>>>;
    public record GetAllMessageQueryByDealer(int DealerId) : IRequest<ApiResponse<List<MessageResponse>>>;
    public record GetMessageByIdQuery(int Id) : IRequest<ApiResponse<MessageResponse>>;

}
