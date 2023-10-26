using Erp.Base.Enum;
using Erp.Base.Model;

namespace Erp.Data.Entities
{
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
        public virtual List<CurrentAccount> CurrentAccounts { get; set; }
    }
}
