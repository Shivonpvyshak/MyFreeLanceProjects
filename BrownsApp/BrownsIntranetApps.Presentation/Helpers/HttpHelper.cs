using BrownsIntranetApps.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Web.Script.Serialization;

namespace BrownsIntranetApps.Presentation.Helpers
{
    public class HttpHelper
    {
        private HttpClient _client;

        public HttpHelper()
        {
            string apiPath = ConfigurationManager.AppSettings["API"];
            _client = new HttpClient();
            _client.BaseAddress = new Uri(apiPath);
        }

        public List<PartDTO> GetPartListforReport(PartDTO partDTO)
        {
            HttpResponseMessage response = null;
            List<PartDTO> plist = null;

            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            response = _client.PostAsync("Part/GetReportDetails", new StringContent(
                       new JavaScriptSerializer().Serialize(partDTO), Encoding.UTF8, "application/json")).Result;

            if (response.IsSuccessStatusCode)
            {
                plist = response.Content.ReadAsAsync<List<PartDTO>>().Result;
            }

            return plist;
        }
    }
}