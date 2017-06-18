using BrownsIntranetApps.API.Helpers.ResponseBuilder;
using BrownsIntranetApps.BL;
using BrownsIntranetApps.BL.Interface;
using BrownsIntranetApps.DTO;
using System.Net.Http;
using System.Web.Http;

namespace BrownsIntranetApps.API.Controllers
{
    public class PartsController : ApiController
    {
        private IPartBL _partBL;
        private IHttpResponseMessageBuilder _httpResponseMessageBuilder;

        public PartsController()
        {
            _partBL = new PartBL();
            _httpResponseMessageBuilder = new HttpResponseMessageBuilder();
        }

        //  [Route("API/Part/Search/{searchTerm}/SearchMode/{searchMode}")]
        [Route("API/Part/Search/")]
        [HttpGet]
        public HttpResponseMessage Get(string searchTerm, string searchMode)
        {
            var partsList = _partBL.GetParts(searchTerm, searchMode);

            return _httpResponseMessageBuilder.GetResponse(partsList, Request);
        }

        [Route("API/Part/Add/")]
        [HttpPost]
        public HttpResponseMessage Post(PartDTO partDTO)
        {
            var partID = _partBL.Add(partDTO);
            return _httpResponseMessageBuilder.GetSimpleResponse(partID, Request);
        }

        [Route("API/Part/Edit/")]
        [HttpPut]
        public HttpResponseMessage Put(PartDTO partDTO)
        {
            var part = _partBL.Update(partDTO);
            return _httpResponseMessageBuilder.GetSimpleResponse(part, Request);
        }

        [Route("API/Part/Delete/")]
        [HttpPut]
        public HttpResponseMessage Delete(PartDTO partDTO)
        {
            var partID = _partBL.Delete(partDTO);
            return _httpResponseMessageBuilder.GetSimpleResponse(partID, Request);
        }

        //[Route("API/Part/GetReportDetails/")]
        ////  [HttpPost]
        //public HttpResponseMessage GetReportDetails(PartDTO partDTO)
        //{
        //    var partsList = _partBL.GetReportDetails(partDTO);

        //    return _httpResponseMessageBuilder.GetResponse(partsList, Request);
        //}

        //[Route("API/Part/GetReportDetails/")]
        //[HttpGet]
        //public HttpResponseMessage GetReportDetails(PartDTO partDTO)
        //{
        //    var partsList = _partBL.GetReportDetails(partDTO);

        //    return new HttpResponseMessage()
        //    {
        //        Content = new StringContent(JsonConvert.SerializeObject(partsList), Encoding.UTF8, "application/json")
        //    };
        //}

        [HttpPost]
        [Route("API/Part/GetPartsDetails/")]
        public HttpResponseMessage GetPartsDetails(PartDTO partDTO)
        {
            //PartDTO partDTO = new PartDTO();
            var partsList = _partBL.GetReportDetails(partDTO);
            return _httpResponseMessageBuilder.GetResponse(partsList, Request);
        }
    }
}