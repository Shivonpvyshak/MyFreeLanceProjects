using BrownsIntranetApps.Common;
using BrownsIntranetApps.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace BrownsIntranetApps.Presentation.Common
{
    public class InvoiceReportHelper
    {
        public List<SalesReportDTO> GetSalesReportData(string fromDate, string toDate)
        {
            try
            {
                SqlCommand command = new SqlCommand();

                ISqlConnectionHelper sqlHelper = new SqlConnectionHelper(ConfigurationManager.ConnectionStrings["BrownsAppDBConnectionString"].ConnectionString);
                DataTable dtResults = new DataTable();
                DataSet dsResults = new DataSet();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Billing.GetSalesReportData";

                command.Parameters.AddWithValue("@FromDate", fromDate);
                command.Parameters.AddWithValue("@ToDate", toDate);

                dsResults = sqlHelper.ExecuteStoredProcedure(command);
                if (dsResults != null && dsResults.Tables.Count > 0)
                {
                    return ConvertToList(dsResults);
                }
                else return null;
            }
            catch (Exception ex)
            {
                ExceptionHandler exceptionHandler = new ExceptionHandler();
                exceptionHandler.WrapLogException(ex);
                return null;
            }
        }

        public List<SalesReportDTO> GetCustomerReportData(string fromDate, string toDate, string customerName)
        {
            try
            {
                if (customerName.Trim() == "")
                    customerName = null;

                SqlCommand command = new SqlCommand();

                ISqlConnectionHelper sqlHelper = new SqlConnectionHelper(ConfigurationManager.ConnectionStrings["BrownsAppDBConnectionString"].ConnectionString);
                DataTable dtResults = new DataTable();
                DataSet dsResults = new DataSet();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Billing.GetCustomerReportData";

                command.Parameters.AddWithValue("@FromDate", fromDate);
                command.Parameters.AddWithValue("@ToDate", toDate);
                command.Parameters.AddWithValue("@CustomerName", customerName);

                dsResults = sqlHelper.ExecuteStoredProcedure(command);
                if (dsResults != null && dsResults.Tables.Count > 0)
                {
                    return ConvertToCustomerReportList(dsResults);
                }
                else return null;
            }
            catch (Exception ex)
            {
                ExceptionHandler exceptionHandler = new ExceptionHandler();
                exceptionHandler.WrapLogException(ex);
                return null;
            }
        }

        private List<SalesReportDTO> ConvertToList(DataSet dsResults)
        {
            List<SalesReportDTO> invoices = new List<SalesReportDTO>();
            invoices = (from DataRow dr in dsResults.Tables[0].Rows
                        select new SalesReportDTO()
                        {
                            InvoiceNumber = dr["InvoiceNumber"].ToString(),
                            InvoiceAmount = Convert.ToDecimal(dr["InvoiceAmount"]),
                            InvoiceDate = dr["InvoiceDate"].ToString(),
                            OutstandingBalance = Convert.ToDecimal(dr["OutstandingBalance"]),
                            CustomerName = dr["CustomerName"].ToString()
                        }).ToList();

            return invoices;
        }

        private List<SalesReportDTO> ConvertToCustomerReportList(DataSet dsResults)
        {
            List<SalesReportDTO> invoices = new List<SalesReportDTO>();
            invoices = (from DataRow dr in dsResults.Tables[0].Rows
                        select new SalesReportDTO()
                        {
                            InvoiceNumber = dr["InvoiceNumber"].ToString(),
                            InvoiceAmount = Convert.ToDecimal(dr["InvoiceAmount"]),
                            CustomerPO = dr["CustomerPO"].ToString(),
                            InvoiceDate = dr["InvoiceDate"].ToString(),
                            OutstandingBalance = Convert.ToDecimal(dr["OutstandingBalance"])
                        }).ToList();

            return invoices;
        }
    }
}