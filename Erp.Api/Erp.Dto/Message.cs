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
        public string Dealer { get; set; }
        public string ReceiverMessage { get; set; }
        public string TransmitterMessage { get; set; }
    }
}
