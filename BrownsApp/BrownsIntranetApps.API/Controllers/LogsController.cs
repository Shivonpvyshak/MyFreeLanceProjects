using BrownsIntranetApps.API.Helpers.ResponseBuilder;
using BrownsIntranetApps.BL;
using BrownsIntranetApps.BL.Interface;
using System;
using System.Net.Http;
using System.Web.Http;

namespace BrownsIntranetApps.API.Controllers
{
    public class LogsController : ApiController
    {
        private ILogsBL _logsBL;
        private IHttpResponseMessageBuilder _httpResponseMessageBuilder;

        public LogsController()
        {
            _logsBL = new LogsBL();
            _httpResponseMessageBuilder = new HttpResponseMessageBuilder();
        }

        [Route("API/Logs/GetExceptionLogs/")]
        [HttpGet]
        public HttpResponseMessage Get(string fromDate)
        {
            DateTime frmDate;
            if (!DateTime.TryParse(fromDate, out frmDate))
            {
                frmDate = DateTime.Now;
            }

            var partsList = _logsBL.GetPartsExceptionLogs(frmDate);

            return _httpResponseMessageBuilder.GetResponse(partsList, Request);
        }
    }
}