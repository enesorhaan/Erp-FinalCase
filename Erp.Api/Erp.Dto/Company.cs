using Erp.Base.Enum;

namespace Erp.Dto
{
    public class CompanyRequest 
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string CompanyName { get; set; }
        public UserRole Role { get; set; }
    }

    public class CompanyResponse
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string CompanyName { get; set; }
        public UserRole Role { get; set; }
        public DateTime LastActivityDate { get; set; }
        public int PasswordRetryCount { get; set; }

        public virtual List<DealerResponse> Dealers { get; set; }
        public virtual List<ProductResponse> Products { get; set; }
        public virtual List<MessageResponse> Messages { get; set; }
        public virtual List<CurrentAccountResponse> CurrentAccounts { get; set; }
    }
}
