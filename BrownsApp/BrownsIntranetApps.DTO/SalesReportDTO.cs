namespace BrownsIntranetApps.DTO
{
    public class SalesReportDTO
    {
        public string InvoiceNumber { get; set; }
        public string InvoiceDate { get; set; }
        public string CustomerName { get; set; }
        public decimal InvoiceAmount { get; set; }
        public decimal OutstandingBalance { get; set; }

        public string CustomerPO { get; set; }
    }
}