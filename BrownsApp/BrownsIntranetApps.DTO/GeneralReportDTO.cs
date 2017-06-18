using System;

namespace BrownsIntranetApps.DTO
{
    public class GeneralReportDTO
    {
        public string InvoiceType { get; set; }
        public string InvoiceNumber { get; set; }
        public string Name { get; set; }
        public decimal PartsSubTotal { get; set; }
        public decimal LaborSubTotal { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public decimal Total { get; set; }
        public decimal BalanceDue { get; set; }
        
    }
}
