using BrownsIntranetApps.BL;
using BrownsIntranetApps.BL.Interface;
using BrownsIntranetApps.Presentation.Mapper;
using BrownsIntranetApps.Presentation.Models.Repair;
using System;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace BrownsIntranetApps.Presentation.Controllers
{
    public class RepairController : BaseController
    {
        private readonly IRepairBL _repairBL;

        public RepairController()
        {
            _repairBL = new RepairBL();
        }
        // GET: Repair
        public ActionResult ViewRepair()
        {
            return View();
        }

        public ActionResult CreateRepair()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View("Create", new RepairVM
            {
                InvoiceDate = DateTime.Now
            });
        }
        [HttpPost]
        public ActionResult Create(RepairVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.InvoiceDate == null)
                        model.InvoiceDate = DateTime.Now;
                    if (model.ServiceReportBillFileBase != null)
                    {
                        model.ServiceReportBillFile = model.ServiceReportBillFileBase.FileName;
                    }

                    if (model.VendorInvoicesFileBase != null)
                    {
                        model.VendorInvoicesFile = model.VendorInvoicesFileBase.FileName;
                    }
                    var invoiceId = _repairBL.Add(RepairMapper.Map(model));
                    if (invoiceId > 0)
                    {
                        var filePath = ConfigurationManager.AppSettings["RepairFilePath"] + invoiceId + "\\";
                        UploadFile(model.VendorInvoicesFileBase, filePath);
                        UploadFile(model.ServiceReportBillFileBase, filePath);
                    }
                }
                else
                {
                    return View("Create", model);
                }
                TempData["Success"] = "Entry added successfully";

                return View("../RepairHome/RepairHome");
            }
            catch 
            {
                TempData["Exception"] = "The server encountered an error while processing the request. Please contact the technical team.";
                return View("Create", model);
            }
        }

        public ActionResult Details(int id)
        {
            var repair = RepairMapper.Map(_repairBL.Get(id));
            return View("Details", repair);
        }

        public ActionResult Edit(int id)
        {
            var repair = RepairMapper.Map(_repairBL.Get(id));
            return View("Edit", repair);
        }

        [HttpPost]
        public ActionResult Edit(RepairVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                      
                    if (model.ServiceReportBillFileBase != null)
                    {
                        model.ServiceReportBillFile = model.ServiceReportBillFileBase.FileName;
                    }

                    if (model.VendorInvoicesFileBase != null)
                    {
                        model.VendorInvoicesFile = model.VendorInvoicesFileBase.FileName;
                    }

                    var invoiceId = _repairBL.Update(RepairMapper.Map(model));
                    if (invoiceId > 0)
                    {
                        var filePath = ConfigurationManager.AppSettings["RepairFilePath"] + invoiceId + "\\";
                        UploadFile(model.VendorInvoicesFileBase, filePath);
                        UploadFile(model.ServiceReportBillFileBase, filePath);
                        TempData["Success"] = "Entry saved successfully";
                    }
                    else
                    {
                        return View("Edit", model);
                    }

                }
                else
                {
                    return View("Edit", model);
                }

                return View("../RepairHome/RepairHome");
            }
            catch
            {
                TempData["Exception"] = "The server encountered an error while processing the request. Please contact the technical team.";
                return View("Edit", model);
            }
        }


        [HttpPost]
        public ActionResult Delete(int Id)
        {
            try
            {
                if (Id != 0)
                {
                    var isDeleted = _repairBL.Delete(Id);
                    if (isDeleted)
                    {
                        TempData["Success"] = "Entry deleted successfully";
                        return View("../RepairHome/RepairHome");
                    }
                }
                return RedirectToAction("Details", Id);
            }
            catch
            {
                TempData["Exception"] = "The server encountered an error while processing the request. Please contact the technical team.";
                var repair = RepairMapper.Map(_repairBL.Get(Id));
                return View("Details", repair);
            }
        }


        public FileResult DownloadFile(int Id, string filename)
        {
            var filePath = ConfigurationManager.AppSettings["RepairFilePath"] + Id + "\\";

            return File(filePath + filename, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }
        private bool UploadFile(HttpPostedFileBase file, string filePath)
        {
            bool successFlag = false;

            try
            {
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                file.SaveAs(filePath + file.FileName);
                successFlag = true;
            }
            catch (Exception ex)
            {
                successFlag = false;
                WrapLogException(ex);
            }

            return successFlag;
        }

    }
}