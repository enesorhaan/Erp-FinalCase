using Erp.Base.Enum;
using Erp.Base.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities
{
    [Table("Company", Schema = "dbo")]
    public class Company : BaseModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string CompanyName { get; set; }
        public UserRole Role { get; set; }
        public DateTime LastActivityDate { get; set; }
        public int PasswordRetryCount { get; set; }

        public virtual List<Dealer> Dealers { get; set; }
        public virtual List<Product> Products { get; set; }
        public virtual List<Message> Messages { get; set; }
        public virtual List<CurrentAccount> CurrentAccounts { get; set; }
    }

    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.Property(x => x.InsertDate).IsRequired();
            builder.Property(x => x.UpdateDate).IsRequired(false);
            builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true);

            builder.Property(x => x.Email).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(50);
            builder.Property(x => x.CompanyName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Role).IsRequired();
            builder.Property(x => x.LastActivityDate).IsRequired();
            builder.Property(x => x.PasswordRetryCount).IsRequired().HasDefaultValue(0);

            builder.HasIndex(x => x.Email).IsUnique(true);

            builder.HasMany(x => x.Dealers)
                   .WithOne(x => x.Company)
                   .HasForeignKey(x => x.CompanyId);

            builder.HasMany(x => x.Products)
                   .WithOne(x => x.Company)
                   .HasForeignKey(x => x.CompanyId);

            builder.HasMany(x => x.Messages)
                   .WithOne(x => x.Company)
                   .HasForeignKey(x => x.CompanyId);

            builder.HasMany(x => x.CurrentAccounts)
                   .WithOne(x => x.Company)
                   .HasForeignKey(x => x.CompanyId);
        }
    }
}
