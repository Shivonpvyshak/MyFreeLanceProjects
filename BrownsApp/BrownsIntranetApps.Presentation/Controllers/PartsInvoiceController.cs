using BrownsIntranetApps.BL;
using BrownsIntranetApps.BL.Interface;
using BrownsIntranetApps.Common;
using BrownsIntranetApps.DTO;
using System.Web.Mvc;

namespace BrownsIntranetApps.Presentation.Controllers
{
    public class PartsInvoiceController : Controller
    {
        // GET: PartsInvoice
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SearchPartsInvoice()
        {
            return View();
        }

        public ActionResult ViewPartsInvoice(int partNumber = 0)
        {
            return View();
        }

        [HttpPost]
        public JsonResult SavePartInvoice(InvoiceDTO invoiceDTO)
        {
            try
            {
                IInvoiceBL _invoiceBL = new InvoiceBL();
                var invoiceID = _invoiceBL.Add(invoiceDTO);
                return new JsonResult { Data = new { invoiceID = invoiceID } };
            }
            catch (System.Exception ex)
            {
                ExceptionHandler exceptionHandler = new ExceptionHandler();
                exceptionHandler.WrapLogException(ex);
                return null;
            }
        }
    }
}