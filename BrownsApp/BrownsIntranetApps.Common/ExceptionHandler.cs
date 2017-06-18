using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BrownsIntranetApps.Common
{
    public class ExceptionHandler : IExceptionHandler
    {
        public bool WrapLogException(Exception ex, bool rethrow = true)
        {
            bool handleException = false;

            SqlCommand command = new SqlCommand();

            ISqlConnectionHelper sqlHelper = new SqlConnectionHelper(ConfigurationManager.ConnectionStrings["BrownsAppDBConnectionString"].ConnectionString);
            DataTable dtResults = new DataTable();
            DataSet dsResults = new DataSet();

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "dbo.AddException";

            command.Parameters.AddWithValue("@Source", ex.Source);
            command.Parameters.AddWithValue("@Message", ex.Message);
            command.Parameters.AddWithValue("@StackTrace", ex.ToString());
            command.Parameters.AddWithValue("@ExceptionDate", SqlDbType.DateTime).Value = DateTime.Now;

            dsResults = sqlHelper.ExecuteStoredProcedure(command);
            if (dsResults != null && dsResults.Tables.Count > 0)
            {
                handleException = true;
            }

            return handleException;
        }
    }
}