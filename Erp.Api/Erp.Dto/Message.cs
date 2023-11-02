namespace Erp.Dto
{
    public class AdminMessageRequest
    {
        public int ReceiverId { get; set; }
        public string TransmitterMessage { get; set; }
    }

    public class DealerMessageRequest
    {
        public string TransmitterMessage { get; set; }
    }

    public class MessageResponse
    {
        public int Id { get; set; }
        public int DealerId { get; set; }
        public string Dealer { get; set; }
        public int CompanyId { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string ReceiverMessage { get; set; }
        public string TransmitterMessage { get; set; }
    }
}
