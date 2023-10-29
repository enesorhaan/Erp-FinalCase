using Erp.Base.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities
{
    [Table("CurrentAccount", Schema = "dbo")]
    public class CurrentAccount : BaseModel
    {
        public int DealerId { get; set; }
        public virtual Dealer Dealer { get; set; }

        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public decimal? CreditLimit { get; set; }
        //public string? BillingNumber { get; set; }
    }

    public class CurrentAccountConfiguration : IEntityTypeConfiguration<CurrentAccount>
    {
        public void Configure(EntityTypeBuilder<CurrentAccount> builder)
        {
            builder.Property(x => x.InsertDate).IsRequired();
            builder.Property(x => x.UpdateDate).IsRequired(false);
            builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true);

            builder.Property(x => x.CreditLimit).HasPrecision(18, 2).IsRequired(false);
            //builder.Property(x => x.BillingNumber).IsRequired().HasMaxLength(50);

            builder.HasIndex(x => new { x.DealerId, x.CompanyId }).IsUnique(true);

            builder.HasOne(x => x.Dealer)
                   .WithOne(x => x.CurrentAccount)
                   .HasForeignKey<Dealer>(x => x.CurrentAccountId);

            builder.HasOne(x => x.Company)
                   .WithMany(x => x.CurrentAccounts)
                   .HasForeignKey(x => x.CompanyId);
        }
    }
}
