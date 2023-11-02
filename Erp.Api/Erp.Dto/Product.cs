namespace Erp.Dto
{
    public class ProductRequest
    {
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductStock { get; set; }
    }

    public class ProductResponse
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductStock { get; set; }
    }

    public class ProductDetailResponse
    {
        public string ProductName { get; set; }
        public int ProductStock { get; set; }
    }
}
