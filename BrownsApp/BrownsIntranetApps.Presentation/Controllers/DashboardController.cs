using System.Web.Mvc;

namespace BrownsIntranetApps.Presentation.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}