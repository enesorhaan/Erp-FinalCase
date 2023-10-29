using AutoMapper;
using Erp.Base.Response;
using Erp.Data.Context;
using Erp.Data.Entities;
using Erp.Dto;
using Erp.Operation.Cqrs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Erp.Operation.Query
{
    public class MessageQueryHandler :
        IRequestHandler<GetAllMessageQuery, ApiResponse<List<MessageResponse>>>,
        IRequestHandler<GetMessageByIdQuery, ApiResponse<MessageResponse>>
    {
        private readonly MyDbContext dbContext;
        private readonly IMapper mapper;

        public MessageQueryHandler(MyDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<List<MessageResponse>>> Handle(GetAllMessageQuery request, CancellationToken cancellationToken)
        {
            List<Message> list = await dbContext.Set<Message>()
                .ToListAsync(cancellationToken);
            var mapped = mapper.Map<List<MessageResponse>>(list);

            return new ApiResponse<List<MessageResponse>>(mapped);
        }

        public async Task<ApiResponse<MessageResponse>> Handle(GetMessageByIdQuery request, CancellationToken cancellationToken)
        {
            Message? entity = await dbContext.Set<Message>()
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity is null)
                return new ApiResponse<MessageResponse>("Record not found!");

            var mapped = mapper.Map<MessageResponse>(entity);

            return new ApiResponse<MessageResponse>(mapped);
        }
    }
}
