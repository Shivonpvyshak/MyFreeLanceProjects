using BrownsIntranetApps.Common;
using System;
using System.Web.Mvc;

namespace BrownsIntranetApps.Presentation.Controllers
{
    public class BaseController : Controller
    {
        public IExceptionHandler exceptionHandler = null;

        public bool WrapLogException(Exception ex)
        {
            exceptionHandler = new ExceptionHandler();
            return exceptionHandler.WrapLogException(ex);
        }
    }
}