using System.Collections.Generic;

namespace BrownsIntranetApps.DTO
{
    public class BillingDashBoardDTO
    {
        public IEnumerable<InvoiceDTO> InProgressInvoices { get; set; }

        public IEnumerable<InvoiceDTO> PendingValidationInvoices { get; set; }

        public IEnumerable<InvoiceDTO> ApprovedInvoices { get; set; }

        public IEnumerable<InvoiceDTO> PaymentPendingInvoices { get; set; }
    }
}