using Erp.Base.Model;

namespace Erp.Data.Entities
{
    public class Product : BaseModel
    {
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductStock { get; set; }

        public virtual List<ProductOrder> ProductOrders { get; set; }
    }
}
