
$(document).ready(function () {

    $("#btnlogin").click(function () {
        var txtlogin=$("#txtlogin").val()
       // console.warn(txtPrueba)
        var data={            Correo: txtlogin              };        $.ajax({
            url: '/Account/EstadoClave',            type: 'POST',            data: data,            success: function (Correo) {
                
                $("#estado").val(Correo)
               // $("#nombre").val(Nom_Tarjeta)
            },
            error: function (error) {
                console.error(error)
            }
        });
    });
});


