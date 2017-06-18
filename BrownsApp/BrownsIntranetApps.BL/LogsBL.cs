using BrownsIntranetApps.BL.Interface;
using BrownsIntranetApps.DAL.UOW;
using BrownsIntranetApps.DTO;
using BrownsIntranetApps.Entity.SQL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BrownsIntranetApps.BL
{
    public class LogsBL : ILogsBL
    {
        private readonly BHEUnitOfWork _bheUOW;

        public LogsBL()
        {
            BrownsAppDBEntities1 _bheDBContext = new BrownsAppDBEntities1();
            _bheUOW = new BHEUnitOfWork(_bheDBContext);
        }

        public IEnumerable<LogsDTO> GetPartsExceptionLogs(DateTime fromDate)
        {
            var logs = _bheUOW.LogsRepository
                       .Query()
                       .Where(x => x.ExceptionDate >= fromDate)
                       .OrderByDescending(x => x.ExceptionDate)
                       .ToList().ConvertAll(LogsDTOMapper);
            return logs;
        }

        private LogsDTO LogsDTOMapper(ExceptionHistory exceptionLog)
        {
            return new LogsDTO()
            {
                ExceptionDate = exceptionLog.ExceptionDate,
                ID = exceptionLog.ID,
                Message = exceptionLog.Message,
                Source = exceptionLog.Source,
                StackTrace = exceptionLog.StackTrace
            };
        }
    }
}