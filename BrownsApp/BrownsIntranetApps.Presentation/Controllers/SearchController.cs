using System.Web.Mvc;

namespace BrownsIntranetApps.Presentation.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
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

        public ActionResult AdvanceSearchIndex()
        {
            //return View("AdvanceSearchIndex");

            if ((Session["PartsAuthorize"] != null && Session["PartsAuthorize"].ToString().ToLower() == "true"))
            {
                return View("AdvanceSearchIndex");
            }
            else
            {
                Session["PartsAuthorize"] = false;
                return RedirectToAction("Index", "Home");
            }
        }
    }
}