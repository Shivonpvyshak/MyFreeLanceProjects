using BrownsIntranetApps.Common;
using BrownsIntranetApps.Presentation.Helpers;
using System;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace BrownsIntranetApps.Presentation.Controllers
{
    public class ImportDataController : BaseController
    {
        private ExcelUploadHelper _uploadHelper;
        private CommonMethods commonMethods;

        // GET: ImportData
        public ActionResult Index()
        {
            //  return View();
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

        [HttpPost]
        // public JsonResult SaveFiles(string fileType)
        public JsonResult SaveFiles()
        {
            string Message = "";
            commonMethods = new CommonMethods();
            bool successFlag = false;
            string fileName = "";
            try
            {
                if (Request.Files != null)
                {
                    if (Request.Form["fileType"] != null)
                    {
                        if (Request.Form["fileType"] == "PART")
                        {
                            string companyID = Request.Form["companyID"];
                            var company = commonMethods.GetCompanyName(companyID);
                            fileName = "PartsFile_" + company;
                        }
                        else if (Request.Form["fileType"] == "PARTPRICE")
                            fileName = "PartsPriceFile";
                    }
                    successFlag = UploadFile(Request.Files[0], fileName);

                    if (successFlag)
                    {
                        Message = "File uploaded successfully";
                    }
                    else
                        Message = "File upload failed! Please try again";
                }
            }
            catch (Exception ex)
            {
                Message = "File upload failed! Please try again";
                WrapLogException(ex);
            }

            return new JsonResult { Data = new { Message = Message, Status = successFlag } };
        }

        private bool UploadFile(HttpPostedFileBase file, string fileName)
        {
            bool successFlag = false;

            try
            {
                fileName = fileName + Path.GetExtension(file.FileName);
                string upLoadFolder = ConfigurationManager.AppSettings["UploadFolder"];
                file.SaveAs(upLoadFolder + fileName);
                successFlag = true;
            }
            catch (Exception ex)
            {
                successFlag = false;
                WrapLogException(ex);
            }

            return successFlag;
        }

        public JsonResult ImportPartData(string makeID)
        {
            string Message = "";
            bool successFlag = false;
            try
            {
                _uploadHelper = new ExcelUploadHelper();
                if (_uploadHelper.InsertPartsExcelRecords(makeID))
                {
                    successFlag = true;
                }
                else
                {
                    successFlag = false;
                }
            }
            catch (Exception ex)
            {
                WrapLogException(ex);
                ViewBag.ImportPartsStatus = "false";
                throw ex;
            }

            return new JsonResult { Data = new { Message = Message, Status = successFlag } };
        }

        public JsonResult ImportPartPriceData()
        {
            int updateCount = 0;
            try
            {
                _uploadHelper = new ExcelUploadHelper();
                updateCount = _uploadHelper.UpdatePartsPriceExcelRecords();
            }
            catch (Exception ex)
            {
                WrapLogException(ex);
                ViewBag.ImportPartPriceStatus = "false";
                throw ex;
            }

            return new JsonResult { Data = new { UpdateCount = updateCount } };
        }
    }
}