namespace Erp.Dto
{
    public class MessageRequest
    {
        public int DealerId { get; set; }
        public int CompanyId { get; set; }
        public string Messages { get; set; }
    }

    public class MessageResponse
    {
        public int DealerId { get; set; }
        public string Dealer { get; set; }
        public int CompanyId { get; set; }
        public string Company { get; set; }
        public string Messages { get; set; }
    }
}
