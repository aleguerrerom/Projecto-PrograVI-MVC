using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Projecto_PrograVI_MVC.Models
{
    public class ReportParms
    {
        public string RptFileName { get; set; }

        public string ReportTitle { get; set; }

        public string ReportType { get; set; }

        public DataTable DataSource { get; set; }

        public string IsHasParms { get; set; }

        public string DataSetName { get; internal set; }


    }
}