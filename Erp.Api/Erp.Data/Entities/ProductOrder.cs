using Erp.Base.Model;

namespace Erp.Data.Entities
{
    public class ProductOrder : BaseModel
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        public int Quantity { get; set; }
        public decimal MarginPrice { get; set; }
    }

    //public class ProductOrderConfiguration : IEntityTypeConfiguration<ProductOrder>
    //{
    //    public void Configure(EntityTypeBuilder<ProductOrder> builder)
    //    {
    //        builder.HasKey(x => new { x.ProductId, x.OrderId });

    //        builder.HasOne(x => x.Product)
    //            .WithMany(x => x.ProductOrders)
    //            .HasForeignKey(x => x.ProductId);

    //        builder.HasOne(x => x.Order)
    //            .WithMany(x => x.ProductOrders)
    //            .HasForeignKey(x => x.OrderId);
    //    }
    //}
}
