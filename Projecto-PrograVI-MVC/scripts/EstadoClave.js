﻿
$(document).ready(function () {

    $("#btnlogin").click(function () {
        var txtlogin=$("#txtlogin").val()
       // console.warn(txtPrueba)

            url: '/Account/EstadoClave',
                
                $("#estado").val(Correo)
               // $("#nombre").val(Nom_Tarjeta)
            },
            error: function (error) {
                console.error(error)
            }
        });
    });
});

