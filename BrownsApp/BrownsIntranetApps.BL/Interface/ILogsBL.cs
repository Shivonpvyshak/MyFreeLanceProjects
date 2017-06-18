using BrownsIntranetApps.DTO;
using System;
using System.Collections.Generic;

namespace BrownsIntranetApps.BL.Interface
{
    public interface ILogsBL
    {
        IEnumerable<LogsDTO> GetPartsExceptionLogs(DateTime asofDate);
    }
}