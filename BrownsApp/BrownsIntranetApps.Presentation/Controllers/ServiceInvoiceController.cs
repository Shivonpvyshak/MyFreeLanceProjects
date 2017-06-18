using System.Web.Mvc;

namespace BrownsIntranetApps.Presentation.Controllers
{
    public class ServiceInvoiceController : Controller
    {
        // GET: ServiceInvoice
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewServiceInvoice(int partNumber = 0)
        {
            return View();
        }

        public ActionResult SearchServiceInvoice()
        {
            return View();
        }
    }
}