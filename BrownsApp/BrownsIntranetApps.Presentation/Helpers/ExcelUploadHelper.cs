using BrownsIntranetApps.Common;
using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace BrownsIntranetApps.Presentation.Helpers
{
    public class ExcelUploadHelper
    {
        private OleDbConnection _partFileconn;
        private OleDbConnection _partPriceFileconn;
        private CommonMethods commonMethods;

        private string constr;

        private OleDbConnection GetExcelConn(string filePath)
        {
            constr = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES;""", filePath);

            return new OleDbConnection(constr);
        }

        public bool InsertPartsExcelRecords(string companyID)
        {
            commonMethods = new CommonMethods();
            string filePath = ConfigurationManager.AppSettings["UploadFolder"];
            string fileName = "PartsFile_" + commonMethods.GetCompanyName(companyID) + ".xlsx";
            string partFilePath = filePath + fileName;
            _partFileconn = GetExcelConn(partFilePath);

            string query = ConfigurationManager.AppSettings["PartExcelSelectQuery"];

            OleDbCommand Ecom = new OleDbCommand(query, _partFileconn);
            _partFileconn.Open();

            DataSet ds = new DataSet();
            OleDbDataAdapter oda = new OleDbDataAdapter(query, _partFileconn);

            oda.Fill(ds);
            DataTable partsDt = ds.Tables[0];

            DataColumn addedByColumn = new System.Data.DataColumn("AddedBy", typeof(System.String));
            addedByColumn.DefaultValue = "DataImport";
            partsDt.Columns.Add(addedByColumn);

            DataColumn addedDateColumn = new System.Data.DataColumn("AddedDate", typeof(System.DateTime));
            addedDateColumn.DefaultValue = DateTime.Now;
            partsDt.Columns.Add(addedDateColumn);

            DataColumn companyIDColumn = new System.Data.DataColumn("CompanyID", typeof(System.Int32));
            companyIDColumn.DefaultValue = companyID;
            partsDt.Columns.Add(companyIDColumn);
            _partFileconn.Close();
            bool flag = UploadPartFile(partsDt);

            BackupFile(fileName);

            return flag;
        }

        public int UpdatePartsPriceExcelRecords()
        {
            string filePath = ConfigurationManager.AppSettings["UploadFolder"];
            string partPriceFilePath = filePath + "PartsPriceFile.xlsx";
            _partPriceFileconn = GetExcelConn(partPriceFilePath);
            string query = ConfigurationManager.AppSettings["PartPriceExcelSelectQuery"];

            OleDbCommand Ecom = new OleDbCommand(query, _partPriceFileconn);
            _partPriceFileconn.Open();

            DataSet ds = new DataSet();
            OleDbDataAdapter oda = new OleDbDataAdapter(query, _partPriceFileconn);
            _partPriceFileconn.Close();
            oda.Fill(ds);
            DataTable partsPriceDt = ds.Tables[0];

            int updatecount = UpdatePartsPrice(partsPriceDt);
            BackupFile("PartsPriceFile.xlsx");
            return updatecount;
        }

        private bool UploadPartFile(DataTable parts)
        {
            //Part File
            try
            {
                ISqlConnectionHelper sqlHelper = new SqlConnectionHelper(ConfigurationManager.ConnectionStrings["BrownsAppDBConnectionString"].ConnectionString);

                //creating object of SqlBulkCopy
                SqlBulkCopy objbulk = new SqlBulkCopy(sqlHelper.BHESQLConnection);
                //assigning Destination table name
                objbulk.DestinationTableName = "dbo.Parts";
                //Mapping Table column
                objbulk.ColumnMappings.Add("CompanyID", "CompanyID");
                objbulk.ColumnMappings.Add("Brand", "Make");
                objbulk.ColumnMappings.Add("Models", "Model");
                objbulk.ColumnMappings.Add("Snum", "SerialNumberRange");
                objbulk.ColumnMappings.Add("PartNumber", "PartNumber");
                objbulk.ColumnMappings.Add("PartManual", "PartManual");
                objbulk.ColumnMappings.Add("Description", "PartDescription");
                objbulk.ColumnMappings.Add("AddedBy", "AddedBy");
                objbulk.ColumnMappings.Add("AddedDate", "AddedDate");
                //inserting Datatable Records to DataBase
                sqlHelper.BHESQLConnection.Open();
                objbulk.WriteToServer(parts);
                sqlHelper.BHESQLConnection.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static void BackupFile(string fileName)
        {
            var directory = ConfigurationManager.AppSettings["UploadFolder"];
            var formattedDate = string.Format("{0:yyyy-MM-dd_hh-mm-ss-tt}", DateTime.Now);
            var newFileName = formattedDate + "_" + fileName;
            string sourceFile = directory + fileName;
            string targetPath = directory + "Backup\\";
            string destinationFile = targetPath + newFileName;

            if (!System.IO.Directory.Exists(targetPath))
            {
                System.IO.Directory.CreateDirectory(targetPath);
            }

            System.IO.File.Move(sourceFile, destinationFile);
        }

        private int UpdatePartsPrice(DataTable partsPriceDt)
        {
            //  partsPriceDt.DefaultView.ToTable(true, "PartNumber");
            int updatedCount = 0;
            int Count = 0;

            for (int i = 0; i <= partsPriceDt.Rows.Count; i++)
            {
                string partNumber = partsPriceDt.Rows[i]["PartNumber"].ToString();
                string listPrice = partsPriceDt.Rows[i]["ListPrice"].ToString();
                if (!string.IsNullOrEmpty(listPrice))
                {
                    SqlCommand command = new SqlCommand();

                    ISqlConnectionHelper sqlHelper = new SqlConnectionHelper(ConfigurationManager.ConnectionStrings["BrownsAppDBConnectionString"].ConnectionString);
                    DataTable dtResults = new DataTable();
                    DataSet dsResults = new DataSet();

                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "dbo.UpdatePartsPrice";

                    command.Parameters.AddWithValue("@PartNumber", partNumber);
                    command.Parameters.AddWithValue("@ListPrice", listPrice);

                    dsResults = sqlHelper.ExecuteStoredProcedure(command);
                    Count = dsResults.Tables[0].Rows[0]["UPDATEDCOUNT"] != null ? Convert.ToInt32(dsResults.Tables[0].Rows[0]["UPDATEDCOUNT"]) : 0;
                    updatedCount = updatedCount + Count;
                }
            }

            return updatedCount;
        }
    }
}