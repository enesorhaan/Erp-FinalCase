using Erp.Base.Enum;

namespace Erp.Dto
{
    public class OrderRequest
    {
        public int DealerId { get; set; }
        public string BillingNumber { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }

    public class OrderResponse
    {
        public int DealerId { get; set; }
        public string BillingNumber { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public virtual List<OrderItemResponse> OrderItems { get; set; }
    }
}
