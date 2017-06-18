using BrownsIntranetApps.DTO;
using BrownsIntranetApps.Presentation.Common;
using Microsoft.Reporting.WebForms;

//using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace BrownsIntranetApps.Presentation.Controllers
{
    public class ReportsController : BaseController
    {
        #region Parts Reports

        private ReportViewer _reportViewer = null;

        // GET: Reports
        public ActionResult Index()
        {
            ViewBag.OnLoad = "OnLoad";

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

        public ActionResult GetPartsReport(PartDTO part)
        {
            try
            {
                Parts parts = new Parts();
                InitializeReportViewer();
                //List<PartDTO> parts = GetPartData(part);
                List<PartDTO> partsList = parts.GetPartData(part);

                if (partsList != null && partsList.Count > 0)
                {
                    if (partsList.Count > 10000)
                    {
                        ViewBag.MaxRecordExceed = " Search results exceed maximum limit of 10,000 records, please refine the 'Search Terms' and try again";
                    }
                    else
                    {
                        string path = Path.Combine(Server.MapPath("~/BrownsReports"), "rpdPart.rdlc");
                        _reportViewer.LocalReport.ReportPath = path;
                        _reportViewer.LocalReport.DataSources.Add(new ReportDataSource("BHEDS", partsList));
                        ViewBag.ReportViewer = _reportViewer;
                    }
                }
                ViewBag.OnLoad = "OnReportLoading";

                return View("Index");
            }
            catch (Exception ex)
            {
                WrapLogException(ex);
                return null;
            }
        }

        private void InitializeReportViewer()
        {
            _reportViewer = new ReportViewer()
            {
                SizeToReportContent = true,
                Width = Unit.Percentage(100),
                Height = Unit.Percentage(100),
            };
            _reportViewer.ProcessingMode = ProcessingMode.Local;
        }

        #endregion Parts Reports

        #region Billing Report

        public ActionResult SalesReport()
        {
            return View();
        }

        public ActionResult CustomerReport()
        {
            return View();
        }

        public ActionResult GeneralReport()
        {
            return View();
        }

        public ActionResult TaxReport()
        {
            return View();
        }

        public ActionResult GetSalesReport(string fromDate, string toDate)
        {
            try
            {
                InvoiceReportHelper invHelper = new InvoiceReportHelper();
                InitializeReportViewer();
                //List<PartDTO> parts = GetPartData(part);
                List<SalesReportDTO> reportDataList = invHelper.GetSalesReportData(fromDate, toDate);

                if (reportDataList != null && reportDataList.Count > 0)
                {
                    if (reportDataList.Count > 10000)
                    {
                        ViewBag.MaxRecordExceed = " Search results exceed maximum limit of 10,000 records, please refine the 'Search Terms' and try again";
                    }
                    else
                    {
                        string path = Path.Combine(Server.MapPath("~/BrownsReports"), "rptSalesReport.rdlc");
                        _reportViewer.LocalReport.ReportPath = path;
                        _reportViewer.LocalReport.DataSources.Add(new ReportDataSource("dsSalesReport", reportDataList));
                        ViewBag.ReportViewer = _reportViewer;
                    }
                }
                ViewBag.OnLoad = "OnReportLoading";

                return View("SalesReport");
            }
            catch (Exception ex)
            {
                WrapLogException(ex);
                return null;
            }
        }

        public ActionResult GetCustomerReport(string fromDate, string toDate, string customerName)
        {
            try
            {
                InvoiceReportHelper invHelper = new InvoiceReportHelper();
                InitializeReportViewer();
                //List<PartDTO> parts = GetPartData(part);
                List<SalesReportDTO> reportDataList = invHelper.GetCustomerReportData(fromDate, toDate, customerName);

                if (reportDataList != null && reportDataList.Count > 0)
                {
                    if (reportDataList.Count > 10000)
                    {
                        ViewBag.MaxRecordExceed = " Search results exceed maximum limit of 10,000 records, please refine the 'Search Terms' and try again";
                    }
                    else
                    {
                        string path = Path.Combine(Server.MapPath("~/BrownsReports"), "rptCustomerReport.rdlc");
                        _reportViewer.LocalReport.ReportPath = path;
                        _reportViewer.LocalReport.DataSources.Add(new ReportDataSource("dsCustomerReport", reportDataList));
                        ViewBag.ReportViewer = _reportViewer;
                    }
                }
                ViewBag.OnLoad = "OnReportLoading";

                return View("CustomerReport");
            }
            catch (Exception ex)
            {
                WrapLogException(ex);
                return null;
            }
        }


        public ActionResult GetTaxReport(string fromDate, string toDate, string taxJurisdiction)
        {
            try
            {
                TaxReportHelper invHelper = new TaxReportHelper();
                InitializeReportViewer();
                //List<PartDTO> parts = GetPartData(part);
                List<TaxReportDTO> reportDataList = invHelper.GetTaxReport(fromDate, toDate, taxJurisdiction);

                if (reportDataList != null && reportDataList.Count > 0)
                {
                    if (reportDataList.Count > 10000)
                    {
                        ViewBag.MaxRecordExceed = " Search results exceed maximum limit of 10,000 records, please refine the 'Search Terms' and try again";
                    }
                    else
                    {
                        string path = Path.Combine(Server.MapPath("~/BrownsReports"), "rptTaxReport.rdlc");
                        _reportViewer.LocalReport.ReportPath = path;
                        _reportViewer.LocalReport.DataSources.Add(new ReportDataSource("dsTaxReport", reportDataList));
                        ViewBag.ReportViewer = _reportViewer;
                    }
                }
                ViewBag.OnLoad = "OnReportLoading";

                return View("TaxReport");
            }
            catch (Exception ex)
            {
                WrapLogException(ex);
                return null;
            }
        }




        #endregion Billing Report
    }
}