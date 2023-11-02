using Erp.Base.Enum;
using Erp.Base.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities
{
    [Table("Dealer", Schema = "dbo")]
    public class Dealer : BaseModel
    {
        public int CompanyId { get; set; } = 1;
        public virtual Company Company { get; set; }

        public int? CurrentAccountId { get; set; }
        public virtual CurrentAccount CurrentAccount { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string DealerName { get; set; }
        public string Address { get; set; }
        public string BillingAddress { get; set; }
        public string TaxOffice { get; set; }
        public int? TaxNumber { get; set; }
        public decimal? MarginPercentage { get; set; }
        public UserRole Role { get; set; } = UserRole.dealer;
        public DateTime LastActivityDate { get; set; }
        public int PasswordRetryCount { get; set; }

        public virtual List<Order> Orders { get; set; }
        public virtual List<Message> Messages { get; set; }
        public virtual List<Expense> Expenses { get; set; }
        public virtual List<OrderItem> OrderItems { get; set; }
    }

    public class DealerConfiguration : IEntityTypeConfiguration<Dealer>
    {
        public void Configure(EntityTypeBuilder<Dealer> builder)
        {
            builder.Property(x => x.InsertDate).IsRequired();
            builder.Property(x => x.UpdateDate).IsRequired(false);
            builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true);

            builder.Property(x => x.Email).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(50);
            builder.Property(x => x.DealerName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Address).IsRequired().HasMaxLength(250);
            builder.Property(x => x.BillingAddress).IsRequired().HasMaxLength(250);
            builder.Property(x => x.TaxOffice).IsRequired().HasMaxLength(50);
            builder.Property(x => x.TaxNumber).IsRequired(false);
            builder.Property(x => x.MarginPercentage).HasPrecision(18, 2).IsRequired(false);
            builder.Property(x => x.Role).IsRequired();
            builder.Property(x => x.LastActivityDate).IsRequired();
            builder.Property(x => x.PasswordRetryCount).IsRequired().HasDefaultValue(0);

            builder.HasIndex(x => x.CompanyId);
            builder.HasIndex(x => x.Email).IsUnique(true);

            builder.HasMany(x => x.Orders)
                   .WithOne(x => x.Dealer)
                   .HasForeignKey(x => x.DealerId);

            builder.HasMany(x => x.Messages)
                   .WithOne(x => x.Dealer)
                   .HasForeignKey(x => x.DealerId);

            builder.HasMany(x => x.Expenses)
                   .WithOne(x => x.Dealer)
                   .HasForeignKey(x => x.DealerId);

            builder.HasMany(x => x.OrderItems)
                   .WithOne(x => x.Dealer)
                   .HasForeignKey(x => x.DealerId);

            builder.HasOne(x => x.CurrentAccount)
                   .WithOne(x => x.Dealer)
                   .HasForeignKey<CurrentAccount>(x => x.DealerId);
        }
    }
}
