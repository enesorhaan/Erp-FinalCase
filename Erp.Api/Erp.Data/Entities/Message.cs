using Erp.Base.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities
{
    [Table("Message", Schema = "dbo")]
    public class Message : BaseModel
    {
        public int DealerId { get; set; }
        public virtual Dealer Dealer { get; set; }

        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public string Messages { get; set; }
    }

    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.Property(x => x.InsertDate).IsRequired();
            builder.Property(x => x.UpdateDate).IsRequired(false);
            builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true);

            builder.Property(x => x.Messages).IsRequired().HasMaxLength(500);

            builder.HasIndex(x => new { x.DealerId, x.CompanyId }).IsUnique(true);

            builder.HasOne(x => x.Dealer)
                   .WithMany(x => x.Messages)
                   .HasForeignKey(x => x.DealerId)
                   .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(x => x.Company)
                   .WithMany(x => x.Messages)
                   .HasForeignKey(x => x.CompanyId)
                   .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
