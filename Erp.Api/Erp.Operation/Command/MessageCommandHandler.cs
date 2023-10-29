using AutoMapper;
using Erp.Base.Response;
using Erp.Data.Context;
using Erp.Data.Entities;
using Erp.Dto;
using Erp.Operation.Cqrs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Erp.Operation.Command
{
    public class MessageCommandHandler :
        IRequestHandler<CreateMessageCommand, ApiResponse<MessageResponse>>,
        IRequestHandler<DeleteMessageCommand, ApiResponse>
    {
        private readonly MyDbContext dbContext;
        private readonly IMapper mapper;

        public MessageCommandHandler(MyDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<MessageResponse>> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            Message mapped = mapper.Map<Message>(request.Model);

            var entity = await dbContext.Set<Message>().AddAsync(mapped, cancellationToken);
            entity.Entity.InsertDate = DateTime.Now;
            await dbContext.SaveChangesAsync(cancellationToken);

            var response = mapper.Map<MessageResponse>(entity.Entity);
            return new ApiResponse<MessageResponse>(response);
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
