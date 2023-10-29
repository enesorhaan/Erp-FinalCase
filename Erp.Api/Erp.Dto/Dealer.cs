using Erp.Base.Enum;

namespace Erp.Dto
{
    public class DealerRequest
    {
        public int CompanyId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string DealerName { get; set; }
        public string Address { get; set; }
        public string BillingAddress { get; set; }
        public string TaxOffice { get; set; }
        public int TaxNumber { get; set; }
        public decimal? MarginPercentage { get; set; }
        public UserRole Role { get; set; }
    }

    public class DealerResponse
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string DealerName { get; set; }
        public string Address { get; set; }
        public string BillingAddress { get; set; }
        public string TaxOffice { get; set; }
        public int TaxNumber { get; set; }
        public decimal? MarginPercentage { get; set; }
        public UserRole Role { get; set; }

        public virtual List<OrderResponse> Orders { get; set; }
        public virtual List<MessageResponse> Messages { get; set; }
    }
}
