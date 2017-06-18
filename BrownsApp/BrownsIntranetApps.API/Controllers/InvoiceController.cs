using BrownsIntranetApps.API.Helpers.ResponseBuilder;
using BrownsIntranetApps.BL;
using BrownsIntranetApps.BL.Interface;
using BrownsIntranetApps.Common;
using BrownsIntranetApps.DTO;
using System;
using System.Net.Http;
using System.Web.Http;

namespace BrownsIntranetApps.API.Controllers
{
    public class InvoiceController : ApiController
    {
        private IInvoiceBL _invoiceBL;
        private IHttpResponseMessageBuilder _httpResponseMessageBuilder;

        public InvoiceController()
        {
            _invoiceBL = new InvoiceBL();
            _httpResponseMessageBuilder = new HttpResponseMessageBuilder();
        }

        [Route("API/Invoice/Parts/Get/")]
        [HttpGet]
        public HttpResponseMessage Get(string invoiceNumber)
        {
            var response = _invoiceBL.Get(invoiceNumber);
            return _httpResponseMessageBuilder.GetSimpleResponse(response, Request);
        }

        [Route("API/Invoice/GetAllDashboardInvoices/")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            var response = _invoiceBL.GetAllDashboardInvoices();

            return _httpResponseMessageBuilder.GetSimpleResponse(response, Request);
        }

        [Route("API/Invoice/GetInvoiceGeneralReportData/")]
        [HttpGet]
        public HttpResponseMessage GetInvoiceGeneralReportData(DateTime? fromDate=null, DateTime? toDate=null, string invoiceType = "", string partsDescription = "", string customerName = "")
        {
            var response = _invoiceBL.GetInvoiceGeneralReportData(fromDate, toDate, invoiceType, partsDescription, customerName);

            return _httpResponseMessageBuilder.GetResponse(response, Request);
        }

        [Route("API/Invoice/Add/")]
        [HttpPost]
        public HttpResponseMessage Post(InvoiceDTO invoiceDTO)
        {
            try
            {
                if (invoiceDTO == null)
                    return null;

                long invoiceID = 0;
                if (invoiceDTO.ID == 0)
                {
                    invoiceID = _invoiceBL.Add(invoiceDTO);
                }
                else if (invoiceDTO.ID > 0)
                {
                    invoiceID = _invoiceBL.Update(invoiceDTO);
                }
                return _httpResponseMessageBuilder.GetSimpleResponse(invoiceID, Request);
            }
            catch (System.Exception ex)
            {
                ExceptionHandler exceptionHandler = new ExceptionHandler();
                exceptionHandler = new ExceptionHandler();
                exceptionHandler.WrapLogException(ex);
                return null;
            }
        }

        [Route("API/Invoice/Delete/")]
        [HttpDelete]
        public HttpResponseMessage Delete(string invoiceNumber, string APIKey)
        {
            if (APIKey == "BHEAPI")
            {
                var partID = _invoiceBL.Delete(invoiceNumber);
                return _httpResponseMessageBuilder.GetSimpleResponse(partID, Request);
            }
            else
            {
                return null;
            }
        }
    }
}