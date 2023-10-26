using Erp.Base.Model;

namespace Erp.Data.Entities
{
    public class CurrentAccount : BaseModel
    {
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public int DealerId { get; set; }
        public virtual Dealer Dealer { get; set; }

        public decimal CreditLimit { get; set; }
        //public string? BillingNumber { get; set; }
    }
}
