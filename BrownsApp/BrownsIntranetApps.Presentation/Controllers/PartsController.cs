using System.Web.Mvc;

namespace BrownsIntranetApps.Presentation.Controllers
{
    public class PartsController : Controller
    {
        // GET: Parts
        public ActionResult Index()
        {
            if ((Session["PartsAuthorize"] != null && Session["PartsAuthorize"].ToString().ToLower() == "true"))
            {
                return View();
            }
            else
            {
                Session["PartsAuthorize"] = false;
                return RedirectToAction("Index", "Home");
            }
        }
    }
}