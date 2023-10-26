using Erp.Base.Enum;
using Erp.Base.Model;

namespace Erp.Data.Entities
{
    public class Dealer : BaseModel
    {
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public int CurrentAccountId { get; set; }
        public virtual CurrentAccount CurrentAccount { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string DealerName { get; set; }
        public string Address { get; set; }
        public string BillingAddress { get; set; }
        public string TaxOffice { get; set; }
        public int TaxNumber { get; set; }
        public decimal MarginPercentage { get; set; }
        public decimal AccountLimit { get; set; }
        public UserRole Role { get; set; }
        public DateTime LastActivityDate { get; set; }
        public int PasswordRetryCount { get; set; }

        public virtual List<Order> Orders { get; set; }
    }
}
