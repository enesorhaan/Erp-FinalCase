using AutoMapper;
using Erp.Base.Response;
using Erp.Data.Context;
using Erp.Data.Entities;
using Erp.Dto;
using Erp.Operation.Cqrs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.Infrastructure;

namespace Erp.Operation.Command
{
    public class MessageCommandHandler :
        IRequestHandler<CreateAdminMessageCommand, ApiResponse<MessageResponse>>,
        IRequestHandler<CreateDealerMessageCommand, ApiResponse<MessageResponse>>,
        IRequestHandler<UpdateMessageCommand, ApiResponse>,
        IRequestHandler<DeleteMessageCommand, ApiResponse>
    {
        private readonly MyDbContext dbContext;
        private readonly IMapper mapper;

        public MessageCommandHandler(MyDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<MessageResponse>> Handle(CreateAdminMessageCommand request, CancellationToken cancellationToken)
        {
            var checkReceiverUser = await CheckUser(request.Model.ReceiverId, cancellationToken);
            var checkTransmitterUser = await dbContext.Set<Company>().Where(x => x.Id == 1).FirstOrDefaultAsync(cancellationToken);

            if (!checkReceiverUser.Success)
            {
                return new ApiResponse<MessageResponse>(checkReceiverUser.Message);
            }

            Message messageFrom = new Message();
            messageFrom.CompanyId = 1;
            messageFrom.DealerId = checkReceiverUser.Response.Id;
            messageFrom.Email = checkTransmitterUser.Email;
            messageFrom.TransmitterMessage = request.Model.TransmitterMessage;
            messageFrom.MessageDate = DateTime.Now;

            Message messageTo = new Message();
            messageTo.CompanyId = 1;
            messageTo.DealerId = checkReceiverUser.Response.Id;
            messageTo.Email = checkReceiverUser.Response.Email;
            messageTo.ReceiverMessage = request.Model.TransmitterMessage;
            messageTo.MessageDate = DateTime.Now;

            await dbContext.Set<Message>().AddAsync(messageFrom, cancellationToken);
            await dbContext.Set<Message>().AddAsync(messageTo, cancellationToken);

            await dbContext.SaveChangesAsync(cancellationToken);

            var response = mapper.Map<MessageResponse>(request.Model);
            response.Dealer = checkReceiverUser.Response.DealerName;

            return new ApiResponse<MessageResponse>(response);
        }

        public async Task<ApiResponse<MessageResponse>> Handle(CreateDealerMessageCommand request, CancellationToken cancellationToken)
        {
            var checkTransmitterUser = await CheckUser(request.id, cancellationToken);
            var checkReceiverUser = await dbContext.Set<Company>().Where(x => x.Id == 1).FirstOrDefaultAsync(cancellationToken);

            if (!checkTransmitterUser.Success)
            {
                return new ApiResponse<MessageResponse>(checkTransmitterUser.Message);
            }

            Message messageFrom = new Message();
            messageFrom.CompanyId = 1;
            messageFrom.DealerId = checkTransmitterUser.Response.Id;
            messageFrom.Email = checkTransmitterUser.Response.Email;
            messageFrom.TransmitterMessage = request.Model.TransmitterMessage;
            messageFrom.MessageDate = DateTime.Now;

            Message messageTo = new Message();
            messageTo.CompanyId = 1;
            messageTo.DealerId = checkTransmitterUser.Response.Id;
            messageTo.Email = checkReceiverUser.Email;
            messageTo.ReceiverMessage = request.Model.TransmitterMessage;
            messageTo.MessageDate = DateTime.Now;

            await dbContext.Set<Message>().AddAsync(messageFrom, cancellationToken);
            await dbContext.Set<Message>().AddAsync(messageTo, cancellationToken);

            await dbContext.SaveChangesAsync(cancellationToken);

            var response = mapper.Map<MessageResponse>(request.Model);
            response.Dealer = checkTransmitterUser.Response.DealerName;

            return new ApiResponse<MessageResponse>(response);
        }

        private async Task<ApiResponse<Dealer>> CheckUser(int delaerId, CancellationToken cancellationToken)
        {
            var dealer = await dbContext.Set<Dealer>().Where(x => x.Id == delaerId).FirstOrDefaultAsync(cancellationToken);

            if (dealer == null)
            {
                return new ApiResponse<Dealer>("Invalid User");
            }

            if (!dealer.IsActive)
            {
                return new ApiResponse<Dealer>("Invalid User");
            }

            return new ApiResponse<Dealer>(dealer);
        }

        public async Task<ApiResponse> Handle(UpdateMessageCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Set<Message>().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null)
                return new ApiResponse("Record not found!");

            entity.UpdateDate = DateTime.Now;
            entity.TransmitterMessage = request.Model.TransmitterMessage;

            await dbContext.SaveChangesAsync(cancellationToken);
            return new ApiResponse();
        }

        public async Task<ApiResponse> Handle(DeleteMessageCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Set<Message>().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null)
                return new ApiResponse("Record not found!");

            entity.IsActive = false;

            await dbContext.SaveChangesAsync(cancellationToken);
            return new ApiResponse();
        }
    }
}
