namespace Erp.Dto
{
    public class CurrentAccountRequest
    {
        public int DealerId { get; set; }
        public decimal CreditLimit { get; set; }
    }
    public class CurrentAccountUpdateRequest
    {
        public decimal CreditLimit { get; set; }
    }
    public class CurrentAccountResponse
    {
        public int Id { get; set; }
        public string Dealer { get; set; }
        public decimal CreditLimit { get; set; }
    }
}
