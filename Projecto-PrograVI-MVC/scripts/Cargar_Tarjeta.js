
$(document).ready(function () {

    $("#btnCargar").click(function () {
        var test=$("#txtcorreo").val()
       // console.warn(txtPrueba)

        var data={
            correo:test
      
        };
        $.ajax({
            url: '/Reparacion/CargarTarjeta',
            type: 'POST',
            data: data,
            success: function (numero,nombre,fecha,codigo) {
                 $("#txtNumero").val(numero)
                 $("#txtNombre").val(nombre)
                 $("#txtFecha").val(fecha)
                $("#txtCodigo").val(codigo)
            },
            error: function (error) {
                console.error(error)
            }
        });
    });
});


