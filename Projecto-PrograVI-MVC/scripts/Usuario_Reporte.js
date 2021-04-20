
$(document).ready(function () {
   
    $("#btnGenerar").click(function () {
        console.warn("Test")
        ReportManager.GenerateReport();

    });
});


var ReportManager = {
    GenerateReport:function () {
        var jsonParam = "";
        var serviceURL = "../Account/GetUserReport";
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
                //    window.location.href = "../Reports/ReportViewerUser.aspx";
            window.open('../Reports/ReportViewer.aspx');
    },
  //  error : errorCallback
});
}


};



var ReportHelper = {

};