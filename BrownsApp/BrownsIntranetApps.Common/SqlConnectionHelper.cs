using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BrownsIntranetApps.Common
{
    public class SqlConnectionHelper : ISqlConnectionHelper
    {
        public SqlConnectionHelper(string connectionString = "")
        {
            if (connectionString == "")
            {
                connectionString = ConfigurationManager.ConnectionStrings["BrownsAppDBConnectionString"].ConnectionString;
            }
            // _connetionString = ConfigurationManager.ConnectionStrings["BrownsAppDBConnectionString"].ConnectionString;
            // BHESQLConnection = new SqlConnection(_connetionString);
            BHESQLConnection = new SqlConnection(connectionString);
        }

        public SqlConnection BHESQLConnection { get; set; }

        public DataSet ExecuteStoredProcedure(SqlCommand command)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet dsResult = new DataSet();
            BHESQLConnection.Open();
            command.Connection = BHESQLConnection;
            command.CommandTimeout = 0;
            //Fill the DataAdapter with a SelectCommand
            adapter.SelectCommand = command;
            adapter.Fill(dsResult);
            BHESQLConnection.Close();
            return dsResult;
        }
    }
}