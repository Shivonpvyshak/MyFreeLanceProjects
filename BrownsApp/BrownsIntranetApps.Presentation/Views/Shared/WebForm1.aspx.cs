using System;

namespace BrownsIntranetApps.Presentation.Views.Shared
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    List<PartDTO> pList = new List<PartDTO>();
            //    PartDTO p = new PartDTO()
            //    {
            //        AddedBy = "Test",
            //        AddedDate = DateTime.Now,
            //        CompanyID = 1,
            //        IsDeleted = 0,
            //        ID = 111,
            //        ListPrice = "100",
            //        Make = "test Make",
            //        Model = "test model",
            //        PartDescription = "part Desc",
            //        PartManual = "test part manual",
            //        PartNumber = "test P#",
            //        SerialNumberRange = "SN Range"
            //    };

            //    pList.Add(p);

            //    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/BrownsReports/rpdPart.rdlc");
            //    ReportViewer1.LocalReport.DataSources.Clear();
            //    ReportDataSource rdc = new ReportDataSource("BHEDS", pList);

            //    ReportViewer1.LocalReport.DataSources.Add(rdc);
            //    ReportViewer1.LocalReport.Refresh();
            //}
        }
    }
}