using Erp.Base.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities
{
    [Table("OrderItem", Schema = "dbo")]
    public class OrderItem : BaseModel
    {
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        //public int ProductId { get; set; }
        //public virtual Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
