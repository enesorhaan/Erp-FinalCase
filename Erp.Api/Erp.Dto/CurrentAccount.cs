namespace Erp.Dto
{
    public class CurrentAccountRequest
    {
        public int DealerId { get; set; }
        public int CompanyId { get; set; }
        public decimal CreditLimit { get; set; }
    }
    public class CurrentAccountResponse
    {
        public int DealerId { get; set; }
        public int CompanyId { get; set; }
        public decimal CreditLimit { get; set; }
    }
}
