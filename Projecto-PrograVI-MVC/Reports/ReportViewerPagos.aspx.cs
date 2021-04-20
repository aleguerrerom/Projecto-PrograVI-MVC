using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projecto_PrograVI_MVC.Reports
{
    public partial class ReportViewerPagos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadReport();
            }
        }
        private void LoadReport()
        {
            var reportParam = (dynamic)HttpContext.Current.Session["ReportParam"];
            if (reportParam != null && !string.IsNullOrEmpty(reportParam.RptFileName))
            {
                Page.Title = "Report|" + reportParam.ReportTitle;
                var dt = new DataTable();
                dt = reportParam.DataSource;
                if (dt.Rows.Count > 0)
                {
                    GenerateReportDocument(reportParam, reportParam.ReportType, dt);
                }
                else
                {
                    ShowErrorMessage();
                }
            }
        }
        public void GenerateReportDocument(dynamic reportParm, string reportType, DataTable data)
        {
            string dsName = reportParm.DataSetName;
            ReportViewerPAGOS.LocalReport.DataSources.Clear();
            ReportViewerPAGOS.LocalReport.DataSources.Add(new ReportDataSource(dsName, data));
            ReportViewerPAGOS.LocalReport.ReportPath = Server.MapPath("~/" + "Reports//rpt//" + reportParm.RptFileName);
            ReportViewerPAGOS.DataBind();
            ReportViewerPAGOS.LocalReport.Refresh();
        }

        public void ShowErrorMessage()
        {
            ReportViewerPAGOS.LocalReport.DataSources.Clear();
            ReportViewerPAGOS.LocalReport.DataSources.Add(new ReportDataSource("", new DataTable()));
            ReportViewerPAGOS.LocalReport.ReportPath = Server.MapPath("~/" + "Reports//rpt//blank.rdlc");
            ReportViewerPAGOS.DataBind();
            ReportViewerPAGOS.LocalReport.Refresh();
        }
    }
}