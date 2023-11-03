using Erp.Base.Enum;
using Erp.Base.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities
{
    [Table("Orders", Schema = "dbo")]
    public class Order : BaseModel
    {
        public int DealerId { get; set; }
        public virtual Dealer Dealer { get; set; }

        public string? BillingNumber { get; set; }
        public decimal? TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public virtual List<OrderItem> OrderItems { get; set; }
    }

    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(x => x.InsertDate).IsRequired();
            builder.Property(x => x.UpdateDate).IsRequired(false);
            builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true);

            builder.Property(x => x.BillingNumber).IsRequired(false).HasMaxLength(50);
            builder.Property(x => x.TotalPrice).HasPrecision(18, 2).IsRequired(false);
            builder.Property(x => x.OrderDate).IsRequired();
            builder.Property(x => x.PaymentMethod).IsRequired();
            builder.Property(x => x.OrderStatus).IsRequired();

            builder.HasIndex(x => x.BillingNumber).IsUnique(true);

            builder.HasMany(x => x.OrderItems)
                   .WithOne(x => x.Order)
                   .HasForeignKey(x => x.OrderId);
        }
    }
}
