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
    public class Parts
    {
        public List<PartDTO> GetPartData(PartDTO partDTO)
        {
            try
            {
                SqlCommand command = new SqlCommand();

                ISqlConnectionHelper sqlHelper = new SqlConnectionHelper(ConfigurationManager.ConnectionStrings["BrownsAppDBConnectionString"].ConnectionString);
                DataTable dtResults = new DataTable();
                DataSet dsResults = new DataSet();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetPartReportData";

                command.Parameters.AddWithValue("@Make", string.IsNullOrEmpty(partDTO.Make) ? null : partDTO.Make.Trim());
                command.Parameters.AddWithValue("@Model", string.IsNullOrEmpty(partDTO.Model) ? null : partDTO.Model.Trim());
                command.Parameters.AddWithValue("@SerialNumberRange", string.IsNullOrEmpty(partDTO.SerialNumberRange) ? null : partDTO.SerialNumberRange.Trim());
                command.Parameters.AddWithValue("@PartNumber", string.IsNullOrEmpty(partDTO.PartNumber) ? null : partDTO.PartNumber.Trim());
                command.Parameters.AddWithValue("@PartManual", string.IsNullOrEmpty(partDTO.PartManual) ? null : partDTO.PartManual.Trim());
                command.Parameters.AddWithValue("@PartDescription", string.IsNullOrEmpty(partDTO.PartDescription) ? null : partDTO.PartDescription.Trim());

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

        private List<PartDTO> ConvertToList(DataSet dsResults)
        {
            List<PartDTO> parts = new List<PartDTO>();
            parts = (from DataRow dr in dsResults.Tables[0].Rows
                     select new PartDTO()
                     {
                         ListPrice = dr["ListPrice"].ToString(),
                         Make = dr["Make"].ToString(),
                         Model = dr["Model"].ToString(),
                         PartDescription = dr["PartDescription"].ToString(),
                         PartManual = dr["PartManual"].ToString(),
                         PartNumber = dr["PartNumber"].ToString(),
                         SerialNumberRange = dr["SerialNumberRange"].ToString()
                     }).ToList();

            return parts;
        }
    }
}