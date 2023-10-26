using Erp.Base.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities
{
    [Table("CurrentAccount", Schema = "dbo")]
    public class CurrentAccount : BaseModel
    {

        public int DealerId { get; set; }
        public virtual Dealer Dealer { get; set; }

        public decimal CreditLimit { get; set; }
        //public string? BillingNumber { get; set; }
    }
}
