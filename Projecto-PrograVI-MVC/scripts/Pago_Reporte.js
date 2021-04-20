
$(document).ready(function () {
   
    $("#btnGenerar2").click(function () {
        console.warn("Test")
        ReportManager.GenerateReport();

    });
});


var ReportManager = {
    GenerateReport:function () {
        var jsonParam = "";
        var serviceURL = "../Account/GetPagoReport";
        ReportManager.GetReport(serviceURL, jsonParam, onFailed);

        function onFailed(error){
            alert(error);
        }

        //error: errorCallback
    },

    GetReport: function (serviceUrl, jsonParams, errorCalback)
    {
        jQuery.ajax({
            url: serviceUrl,
            async: false,
            type: "POST",
            data: "{" + jsonParams + "}",
            contentType: "application/json; charset=utf-8",
            success: function () {
            //    window.location.href = "../Reports/ReportViewer.aspx";
            window.open('../Reports/ReportViewerPagos.aspx');
    },
  //  error : errorCallback
});
}


};

var ReportHelper = {

};