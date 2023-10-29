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
    public class OrderCommandHandler :
        IRequestHandler<CreateOrderCommand, ApiResponse<OrderResponse>>,
        IRequestHandler<UpdateOrderCommand, ApiResponse>,
        IRequestHandler<DeleteOrderCommand, ApiResponse>
    {
        private readonly MyDbContext dbContext;
        private readonly IMapper mapper;

        public OrderCommandHandler(MyDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<OrderResponse>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            Order mapped = mapper.Map<Order>(request.Model);

            var entity = await dbContext.Set<Order>().AddAsync(mapped, cancellationToken);

            entity.Entity.InsertDate = DateTime.Now;
            await dbContext.SaveChangesAsync(cancellationToken);

            var response = mapper.Map<OrderResponse>(entity.Entity);
            return new ApiResponse<OrderResponse>(response);
        }

        public async Task<ApiResponse> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Set<Order>().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null)
                return new ApiResponse("Record not found!");

            entity.UpdateDate = DateTime.Now;
            entity.OrderStatus = request.Model.OrderStatus;

            await dbContext.SaveChangesAsync(cancellationToken);
            return new ApiResponse();
        }

        public async Task<ApiResponse> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Set<Order>().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null)
                return new ApiResponse("Record not found!");

            entity.IsActive = false;

            await dbContext.SaveChangesAsync(cancellationToken);
            return new ApiResponse();
        }
    }
}
