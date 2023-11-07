namespace Erp.Dto
{
    public class ExpenseRequest
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime ExpenseDate { get; set; }
    }

    public class ExpenseResponse
    {
        public int Id { get; set; }
        public string DealerName { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime ExpenseDate { get; set; }
        public bool IsActive { get; set; }
    }
}
