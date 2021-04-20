<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportViewerPagos.aspx.cs" Inherits="Projecto_PrograVI_MVC.Reports.ReportViewerPagos" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManagerPAGOS" runat="server"></asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewerPAGOS" Width="100%" runat="server"></rsweb:ReportViewer>
    </div>
    </form>
</body>
</html>
