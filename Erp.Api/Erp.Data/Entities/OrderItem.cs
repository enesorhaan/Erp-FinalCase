using Erp.Base.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities
{
    [Table("OrderItem", Schema = "dbo")]
    public class OrderItem : BaseModel
    {
        public int? OrderId { get; set; }
        public virtual Order Order { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int DealerId { get; set; }
        public virtual Dealer Dealer { get; set; }

        public decimal? MarginPrice { get; set; }
        public int Quantity { get; set; }
    }

    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.Property(x => x.InsertDate).IsRequired();
            builder.Property(x => x.UpdateDate).IsRequired(false);
            builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true);

            builder.Property(x => x.OrderId).IsRequired(false);
            builder.Property(x => x.ProductId).IsRequired();
            builder.Property(x => x.DealerId).IsRequired();
            builder.Property(x => x.MarginPrice).HasPrecision(18, 2).IsRequired();
            builder.Property(x => x.Quantity).IsRequired();

            builder.HasIndex(x => new { x.OrderId, x.ProductId });

            builder.HasOne(x => x.Order)
                   .WithMany(x => x.OrderItems)
                   .HasForeignKey(x => x.OrderId)
                   .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(x => x.Product)
                   .WithMany(x => x.OrderItems)
                   .HasForeignKey(x => x.ProductId)
                   .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
