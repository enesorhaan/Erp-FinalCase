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
    public class ProductCommandHandler :
        IRequestHandler<CreateProductCommand, ApiResponse<ProductResponse>>,
        IRequestHandler<UpdateProductCommand, ApiResponse>,
        IRequestHandler<DeleteProductCommand, ApiResponse>
    {
        private readonly MyDbContext dbContext;
        private readonly IMapper mapper;

        public ProductCommandHandler(MyDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<ProductResponse>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Product mapped = mapper.Map<Product>(request.Model);

            var product = await dbContext.Set<Product>().FirstOrDefaultAsync(x => x.ProductName == mapped.ProductName, cancellationToken);

            if (product != null)
                return new ApiResponse<ProductResponse>("Product already exists!");

            var entity = await dbContext.Set<Product>().AddAsync(mapped, cancellationToken);
            entity.Entity.InsertDate = DateTime.Now;

            await dbContext.SaveChangesAsync(cancellationToken);

            var response = mapper.Map<ProductResponse>(entity.Entity);
            return new ApiResponse<ProductResponse>(response);
        }

        public async Task<ApiResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Set<Product>().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null)
                return new ApiResponse("Record not found!");

            entity.UpdateDate = DateTime.Now;
            entity.ProductName = request.Model.ProductName;
            entity.ProductPrice = request.Model.ProductPrice;
            entity.ProductStock = request.Model.ProductStock;

            await dbContext.SaveChangesAsync(cancellationToken);
            return new ApiResponse();
        }

        public async Task<ApiResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Set<Product>().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null)
                return new ApiResponse("Record not found!");

            entity.IsActive = false;

            await dbContext.SaveChangesAsync(cancellationToken);
            return new ApiResponse();
        }
    }
}
