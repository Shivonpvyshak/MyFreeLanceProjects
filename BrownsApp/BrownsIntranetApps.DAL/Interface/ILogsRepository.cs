using BrownsIntranetApps.Entity.SQL;
using System.Linq;

namespace BrownsIntranetApps.DAL.Interface
{
    public interface ILogsRepository
    {
        IQueryable<ExceptionHistory> Query();
    }
}