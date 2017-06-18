namespace BrownsIntranetApps.DTO
{
    public class InvoiceLaborDTO : BaseDTO
    {
        public int InvoiceID { get; set; }
        public TypeCodeDTO LaborType { get; set; }
        public double Hours { get; set; }
        public decimal Rate { get; set; }
        public decimal? Amount { get; set; }
        public string RecordStatus { get; set; }
    }
}