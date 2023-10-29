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
    public class OrderItemCommandHandler :
        IRequestHandler<CreateOrderItemCommand, ApiResponse<OrderItemResponse>>,
        IRequestHandler<UpdateOrderItemCommand, ApiResponse>,
        IRequestHandler<DeleteOrderItemCommand, ApiResponse>
    {
        private readonly MyDbContext dbContext;
        private readonly IMapper mapper;

        public OrderItemCommandHandler(MyDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<OrderItemResponse>> Handle(CreateOrderItemCommand request, CancellationToken cancellationToken)
        {
            OrderItem mapped = mapper.Map<OrderItem>(request.Model);

            var entity = await dbContext.Set<OrderItem>().AddAsync(mapped, cancellationToken);
            entity.Entity.InsertDate = DateTime.Now;
            await dbContext.SaveChangesAsync(cancellationToken);

            var response = mapper.Map<OrderItemResponse>(entity.Entity);
            return new ApiResponse<OrderItemResponse>(response);
        }

        public async Task<ApiResponse> Handle(UpdateOrderItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Set<OrderItem>().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null)
                return new ApiResponse("Record not found!");

            entity.UpdateDate = DateTime.Now;
            entity.MarginPrice = request.Model.MarginPrice;
            entity.Quantity = request.Model.Quantity;

            await dbContext.SaveChangesAsync(cancellationToken);
            return new ApiResponse();
        }

        public async Task<ApiResponse> Handle(DeleteOrderItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Set<OrderItem>().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null)
                return new ApiResponse("Record not found!");

            entity.IsActive = false;

            await dbContext.SaveChangesAsync(cancellationToken);
            return new ApiResponse();
        }
    }
}
