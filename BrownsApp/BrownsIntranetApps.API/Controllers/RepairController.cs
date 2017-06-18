using BrownsIntranetApps.API.Helpers.ResponseBuilder;
using BrownsIntranetApps.BL;
using BrownsIntranetApps.BL.Interface;
using BrownsIntranetApps.DTO;
using System.Net.Http;
using System.Web.Http;

namespace BrownsIntranetApps.API.Controllers
{
    public class RepairController : ApiController
    {
        private IRepairBL _repairBL;
        private IHttpResponseMessageBuilder _httpResponseMessageBuilder;

        public RepairController()
        {
            _repairBL = new RepairBL();
            _httpResponseMessageBuilder = new HttpResponseMessageBuilder();
        }

        [Route("API/Repair/GetAll/")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            return _httpResponseMessageBuilder.GetResponse(_repairBL.GetAll(), Request);
        }

        [Route("API/Repair/Home/GetAll/")]
        [HttpGet]
        public HttpResponseMessage GetAllForHome()
        {
            return _httpResponseMessageBuilder.GetResponse(_repairBL.GetAll(), Request);
        }

        [Route("API/Repair/Add/")]
        [HttpPost]
        public HttpResponseMessage Post(RepairDTO partDTO)
        {
            var partID = _repairBL.Add(partDTO);
            return _httpResponseMessageBuilder.GetSimpleResponse(partID, Request);
        }
    }
}