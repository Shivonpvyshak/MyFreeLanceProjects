using System.Data;
using System.Data.SqlClient;

namespace BrownsIntranetApps.Common
{
    public interface ISqlConnectionHelper
    {
        SqlConnection BHESQLConnection { get; set; }

        DataSet ExecuteStoredProcedure(SqlCommand command);
    }
}