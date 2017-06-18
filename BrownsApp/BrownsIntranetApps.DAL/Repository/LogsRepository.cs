using BrownsIntranetApps.DAL.Interface;
using BrownsIntranetApps.Entity.SQL;
using System.Linq;

namespace BrownsIntranetApps.DAL.Repository
{
    public class LogsRepository : ILogsRepository
    {
        private BrownsAppDBEntities1 _bheDBContext;

        public LogsRepository(BrownsAppDBEntities1 bheDBContext)
        {
            _bheDBContext = bheDBContext;
        }

        public IQueryable<ExceptionHistory> Query()
        {
            return _bheDBContext.ExceptionHistories;
        }
    }
}