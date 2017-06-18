namespace BrownsIntranetApps.DTO
{
    public class TaxReportDTO
    {
        public string DateBilled { get; set; }
        public string DatePaid { get; set; }
        public string InvoiceNumber { get; set; }
        public string Customer { get; set; }
        public decimal Freight { get; set; }
        public decimal TravelExpense { get; set; }
        public decimal Parts { get; set; }
        public decimal Labor { get; set; }
        public string County { get; set; }
        public decimal Manufacturing { get; set; }
        public decimal Government { get; set; }
        public decimal Resale { get; set; }
        public decimal OutofState { get; set; }
        public decimal Farming { get; set; }
        public decimal Tax { get; set; }
    }
}