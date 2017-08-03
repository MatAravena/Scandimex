<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>RptView</title>
    <script runat="server">
        void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Scandimex.Models.Cotizaciones> _cot = null;
                using (Scandimex.Models.ScandimexContexto dc = new Scandimex.Models.ScandimexContexto())
                {
                    _cot = dc.Cotizacion.OrderBy(a => a.CotizacionId).ToList();
                    RptView.LocalReport.ReportPath = Server.MapPath("~/Reportes/Report1.rdlc");
                    RptView.LocalReport.DataSources.Clear();
                    ReportDataSource rdc = new ReportDataSource("DsCotizaciones", _cot);
                    RptView.LocalReport.DataSources.Add(rdc);
                    RptView.LocalReport.Refresh();
                }
            }
        }
    </script>
</head>
<body>
    <div>
        <form runat="server">


         <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
        <rsweb:ReportViewer ID="RptView" runat="server" AsyncRendering="false" SizeToReportContent="true">
        </rsweb:ReportViewer>
        </form>
    </div>
</body>
</html>
