namespace BrownsIntranetApps.DTO
{
    public class InvoiceItemsDTO : BaseDTO
    {
        public int InvoiceID { get; set; }
        public string Description { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public string RecordStatus { get; set; }
    }
}