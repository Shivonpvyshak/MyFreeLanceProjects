using System;
using System.Configuration;
using System.Web.Mvc;

namespace BrownsIntranetApps.Presentation.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            if ((Session["PartsAuthorize"] != null && Session["PartsAuthorize"].ToString().ToLower() == "false"))
            {
                ViewBag.LoginError = "Unauthorized access to Parts App. Please Login !!";
                ViewBag.IsPartsAuthorize = "false";
            }
            else if ((Session["PartsAuthorize"] != null && Session["PartsAuthorize"].ToString().ToLower() == "true"))
            {
                ViewBag.IsPartsAuthorize = "true";
            }
            else
            {
                ViewBag.IsPartsAuthorize = "false";
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult PartsLogin(string username, string password)
        {
            try
            {
                //var x = 0;
                //var y = 5 / x;
                if ((Session["PartsAuthorize"] != null && Session["PartsAuthorize"].ToString().ToLower() == "true"))
                {
                    return RedirectToAction("Index", "Parts");
                }

                string partsUserName = ConfigurationManager.AppSettings["PartsUserName"];
                string partsPassword = ConfigurationManager.AppSettings["PartsPassword"];

                if (username.Trim().ToLower() == partsUserName && password.Trim() == partsPassword)
                {
                    Session["PartsAuthorize"] = true;
                    return RedirectToAction("Index", "Parts");
                }
                else
                {
                    Session["PartsAuthorize"] = false;
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                WrapLogException(ex);
                Session["PartsAuthorize"] = false;
                return RedirectToAction("Index", "Parts");
            }
        }

        public ActionResult BillingHomeLogin()
        {
            return RedirectToAction("Index", "BillingHome");
        }

        public ActionResult RepairHomeLogin()
        {
            return RedirectToAction("RepairHome", "RepairHome");
        }

        public ActionResult CustomerHomeLogin()
        {
            return RedirectToAction("CustomerHome", "CustomerHome");
        }

        public ActionResult Logout()
        {
            Session["PartsAuthorize"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}