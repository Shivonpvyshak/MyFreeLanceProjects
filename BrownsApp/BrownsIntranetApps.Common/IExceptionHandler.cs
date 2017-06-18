using System;

namespace BrownsIntranetApps.Common
{
    public interface IExceptionHandler
    {
        bool WrapLogException(Exception ex, bool rethrow = true);
    }
}