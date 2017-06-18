using BrownsIntranetApps.DTO;
using System;
using System.Collections.Generic;

namespace BrownsIntranetApps.BL.Interface
{
    public interface IInvoiceBL
    {
        InvoiceDTO Get(string invoiceNumber);

        long Add(InvoiceDTO invoiceDTO);

        long Update(InvoiceDTO invoiceDTO);

        bool Delete(string invoiceNumber);

        BillingDashBoardDTO GetAllDashboardInvoices();

        List<GeneralReportDTO> GetInvoiceGeneralReportData(DateTime? fromDate, DateTime? toDate, string invoiceType = "", string partsDescription = "", string customerName = "");
    }
}