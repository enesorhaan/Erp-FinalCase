using Erp.Base.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities
{
    [Table("Product", Schema = "dbo")]
    public class Product : BaseModel
    {
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductStock { get; set; }

        //public virtual List<OrderItem> OrderItems { get; set; }
    }
}
