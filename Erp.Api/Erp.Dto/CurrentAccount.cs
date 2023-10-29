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
        public int Id { get; set; }
        public int DealerId { get; set; }
        public string Dealer { get; set; }
        public int CompanyId { get; set; }
        public int Company { get; set; }
        public decimal CreditLimit { get; set; }
    }
}
