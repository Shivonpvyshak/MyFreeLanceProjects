using BrownsIntranetApps.BL;
using BrownsIntranetApps.BL.Interface;
using BrownsIntranetApps.Presentation.Helpers;
using BrownsIntranetApps.Presentation.Mapper;
using BrownsIntranetApps.Presentation.Models.Repair;
using DataTables.AspNet.Core;
using DataTables.AspNet.Mvc5;
using System.Web.Mvc;

namespace BrownsIntranetApps.Presentation.Controllers
{
    public class RepairHomeController : Controller
    {
        private readonly IRepairBL _repairBL;

        public RepairHomeController()
        {
            _repairBL = new RepairBL();
        }

        // GET: RepairHome
         public ActionResult RepairHome()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetRepairList(IDataTablesRequest request)
        {
            var allData = RepairMapper.Map(_repairBL.GetAll());
            var response = DataTableServerSideHelper<RepairVM>.ProcessData(allData, request);
            return new DataTablesJsonResult(response, JsonRequestBehavior.AllowGet);
        }
        //public JsonResult GetRepairList()
        //{
        //    var allData = RepairMapper.Map(_repairBL.GetAll());
        //    var response = DataTableServerSideHelper<RepairVM>.ProcessData(allData, null);
        //    return new DataTablesJsonResult(response, JsonRequestBehavior.AllowGet);
        //}
    }
}