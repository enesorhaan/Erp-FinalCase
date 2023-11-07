namespace Erp.Dto
{
    public class OrderItemRequest
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class OrderItemUpdateRequest
    {
        public int Quantity { get; set; }
    }

    public class OrderItemResponse
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public decimal MarginPrice { get; set; }
        public int Quantity { get; set; }
    }
}
