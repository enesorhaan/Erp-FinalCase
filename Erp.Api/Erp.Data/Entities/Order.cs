using Erp.Base.Enum;
using Erp.Base.Model;

namespace Erp.Data.Entities
{
    public class Order : BaseModel
    {
        public int DealerId { get; set; }
        public virtual Dealer Dealer { get; set; }

        public string BillingNumber { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public virtual List<ProductOrder> ProductOrders { get; set; }
    }
}
