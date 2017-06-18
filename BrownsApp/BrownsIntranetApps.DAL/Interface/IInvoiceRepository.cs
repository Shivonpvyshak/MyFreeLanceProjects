using BrownsIntranetApps.Entity.SQL;
using System;
using System.Data;
using System.Linq;

namespace BrownsIntranetApps.DAL.Interface
{
    public interface IInvoiceRepository
    {
        long Add(Invoice invoice);

        IQueryable<Invoice> Query();

        long Delete(Invoice invoice);

        //DataSet GetInvoiceGeneralReportData(string invoiceType="", string partsDescription="", string customerName="", DateTime? fromDate, DateTime? toDate);
        DataSet GetInvoiceGeneralReportData(DateTime? fromDate, DateTime? toDate,string invoiceType = "", string partsDescription = "", string customerName = "");



    }
}