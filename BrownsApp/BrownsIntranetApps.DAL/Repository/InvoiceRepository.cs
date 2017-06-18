using BrownsIntranetApps.DAL.Interface;
using BrownsIntranetApps.Entity.SQL;
using System.Linq;
using System;
using System.Data;
using System.Data.SqlClient;
using BrownsIntranetApps.Common;
using System.Configuration;
namespace BrownsIntranetApps.DAL.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private BrownsAppDBEntities1 _bheDBContext;

        public InvoiceRepository(BrownsAppDBEntities1 bheDBContext)
        {
            _bheDBContext = bheDBContext;
        }

        public long Add(Invoice invoice)
        {
            return _bheDBContext.Invoices.Add(invoice).ID;
        }

        public long Delete(Invoice invoice)
        {
            _bheDBContext.Invoices.Attach(invoice);
            return _bheDBContext.Invoices.Remove(invoice).ID;
        }

        public IQueryable<Invoice> Query()
        {
            return _bheDBContext.Invoices;
        }

        public DataSet GetInvoiceGeneralReportData(DateTime? fromDate, DateTime? toDate, string invoiceType = "", string partsDescription = "", string customerName = "")
        {
            try
            {
                SqlCommand command = new SqlCommand();
                ISqlConnectionHelper sqlHelper = new SqlConnectionHelper(ConfigurationManager.ConnectionStrings["BrownsAppDBConnectionString"].ConnectionString);
                DataTable dtResults = new DataTable();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Billing.GeneralReport";
                command.Parameters.AddWithValue("@InvoiceType", string.IsNullOrEmpty(invoiceType) ? null : invoiceType.Trim());
                command.Parameters.AddWithValue("@PartDescription", string.IsNullOrEmpty(partsDescription) ? null : partsDescription.Trim());
                command.Parameters.AddWithValue("@CustomerName", string.IsNullOrEmpty(customerName) ? null : customerName.Trim());
                command.Parameters.AddWithValue("@FromDate", fromDate);
                command.Parameters.AddWithValue("@ToDate", toDate);

                return sqlHelper.ExecuteStoredProcedure(command);

            }
            catch (Exception ex)
            {
                ExceptionHandler exceptionHandler = new ExceptionHandler();
                exceptionHandler.WrapLogException(ex);
                return null;
            }
        }


    }
}