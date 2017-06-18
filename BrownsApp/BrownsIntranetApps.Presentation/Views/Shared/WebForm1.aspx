<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="BrownsIntranetApps.Presentation.Views.Shared.WebForm1" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>ReportViwer in MVC4 Application</title>
    <script runat="server">
        void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<BrownsIntranetApps.Presentation.PartDTO> pList = new List<BrownsIntranetApps.Presentation.PartDTO>();
                BrownsIntranetApps.Presentation.PartDTO p = new BrownsIntranetApps.Presentation.PartDTO()
                {
                    AddedBy = "Test",
                    AddedDate = DateTime.Now,
                    CompanyID = 1,
                    IsDeleted = 0,
                    ID = 111,
                    ListPrice = "100",
                    Make = "test Make",
                    Model = "test model",
                    PartDescription = "part Desc",
                    PartManual = "test part manual",
                    PartNumber = "test P#",
                    SerialNumberRange = "SN Range"
                };

                pList.Add(p);

                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/BrownsReports/rpdPart.rdlc");
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource rdc = new ReportDataSource("BHEDS", pList);

                ReportViewer1.LocalReport.DataSources.Add(rdc);
                ReportViewer1.LocalReport.Refresh();
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" AsyncRendering="false" SizeToReportContent="true">
            </rsweb:ReportViewer>
        </div>
    </form>
</body>
</html>