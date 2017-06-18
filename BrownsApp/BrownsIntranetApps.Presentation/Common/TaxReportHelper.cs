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
    public class TaxReportHelper
    {
        public List<TaxReportDTO> GetTaxReport(string fromDate, string toDate, string taxJurisdiction)
        {
            try
            {
                if (taxJurisdiction.Trim() == "")
                    taxJurisdiction = null;

                SqlCommand command = new SqlCommand();

                ISqlConnectionHelper sqlHelper = new SqlConnectionHelper(ConfigurationManager.ConnectionStrings["BrownsAppDBConnectionString"].ConnectionString);
                DataTable dtResults = new DataTable();
                DataSet dsResults = new DataSet();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Billing.InvoiceTaxReport";

                command.Parameters.AddWithValue("@FromDate", fromDate);
                command.Parameters.AddWithValue("@ToDate", toDate);
                command.Parameters.AddWithValue("@TaxJurisdiction", taxJurisdiction);

                dsResults = sqlHelper.ExecuteStoredProcedure(command);
                if (dsResults != null && dsResults.Tables.Count > 0)
                {
                    return ConvertToTaxReportList(dsResults);
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

        private List<TaxReportDTO> ConvertToTaxReportList(DataSet dsResults)
        {
            List<TaxReportDTO> taxReports = new List<TaxReportDTO>();
            taxReports = (from DataRow dr in dsResults.Tables[0].Rows
                          select new TaxReportDTO()
                          {
                              County = dr["County"].ToString(),
                              Customer = dr["Customer"].ToString(),
                              DateBilled = dr["DateBilled"].ToString(),
                              DatePaid = dr["DatePaid"].ToString(),
                              Farming = Convert.ToDecimal(dr["Farming"]),
                              Freight = Convert.ToDecimal(dr["Freight"]),
                              Government = Convert.ToDecimal(dr["Government"]),
                              Labor = Convert.ToDecimal(dr["Labor"]),
                              Manufacturing = Convert.ToDecimal(dr["Manufacturing"]),
                              OutofState = Convert.ToDecimal(dr["OutOfState"]),
                              Parts = Convert.ToDecimal(dr["Parts"]),
                              Resale = Convert.ToDecimal(dr["Resale"]),
                              TravelExpense = Convert.ToDecimal(dr["TravelExpense"]),
                              InvoiceNumber = dr["InvoiceNumber"].ToString(),
                              Tax = Convert.ToDecimal(dr["Tax"])
                          }).ToList();

            return taxReports;
        }
    }
}