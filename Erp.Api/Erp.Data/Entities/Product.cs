using Erp.Base.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities
{
    [Table("Product", Schema = "dbo")]
    public class Product : BaseModel
    {
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public string ProductName { get; set; }
        public decimal? ProductPrice { get; set; }
        public int? ProductStock { get; set; }

        public virtual List<OrderItem> OrderItems { get; set; }
    }

    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.InsertDate).IsRequired();
            builder.Property(x => x.UpdateDate).IsRequired(false);
            builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true);

            builder.Property(x => x.ProductName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.ProductPrice).HasPrecision(18, 2).IsRequired(false);
            builder.Property(x => x.ProductStock).IsRequired(false);

            builder.HasIndex(x => x.ProductName).IsUnique(true);

            builder.HasMany(x => x.OrderItems)
                   .WithOne(x => x.Product)
                   .HasForeignKey(x => x.ProductId);
        }
    }
}
