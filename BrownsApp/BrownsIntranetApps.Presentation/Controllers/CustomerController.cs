using System.Web.Mvc;

namespace BrownsIntranetApps.Presentation.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewCustomer()
        {
            return View();
        }

        public ActionResult CreateCustomer()
        {
            return View();
        }

        public ActionResult SearchCustomer(int customerId)
        {
            return View();
        }
    }
}