

function llenarSubCategoriaVista(response) {
    var array = [];
    array = JSON.parse(response.d);
    $.each(array, function (key, value) {
        $('#ddlSubcategoria').append($("<option></option>").val(value["NtraSubcategoria"]).html(value["DescSubcategoria"]));
    });

}

function AgregarDataComboSubcategoria(list, control) {
    if (list.length > 0) {
        control.removeAttr("disabled");
        control.empty().append('<option selected="selected" value="0">Please select</option>');
        $.each(list, function () {
            control.append($("<option></option>").val(this['Value']).html(this['Text']));
        });
    }
    else {
        control.empty().append('<option selected="selected" value="0">Not available<option>');
    }
}

function mensajeInformativo(FLAG, FILA, CODIGO, MENSAJE) {

    if (FLAG == 1) {
        var alert = alertify.alert("Importante", "" + MENSAJE + "");
        alert.set({ transition: 'zoom' }); //slide, zoom, flipx, flipy, fade, pulse (default)
        alert.set('modal', false);  //al pulsar fuera del dialog se cierra o no	

    }

    if (FLAG == 2) {
        var alert = alertify.alert("Importante", "" + MENSAJE + "");
        alert.set({ transition: 'zoom' }); //slide, zoom, flipx, flipy, fade, pulse (default)
        alert.set('modal', false);  //al pulsar fuera del dialog se cierra o no	

    }

    if (FLAG == 3) {
        var alert = alertify.alert("Importante", "" + MENSAJE + "");
        alert.set({ transition: 'zoom' }); //slide, zoom, flipx, flipy, fade, pulse (default)
        alert.set('modal', false);  //al pulsar fuera del dialog se cierra o no	

    }

    if (FLAG == 4) {
        var alert = alertify.alert("Importante", "" + MENSAJE + "" + FILA);
        alert.set({ transition: 'zoom' }); //slide, zoom, flipx, flipy, fade, pulse (default)
        alert.set('modal', false);  //al pulsar fuera del dialog se cierra o no	

    }

    if (FLAG == 5) {
        var alert = alertify.alert("Importante", "" + MENSAJE + "");
        alert.set({ transition: 'zoom' }); //slide, zoom, flipx, flipy, fade, pulse (default)
        alert.set('modal', false);  //al pulsar fuera del dialog se cierra o no	

    }

    if (FLAG == 6) {
        var alert = alertify.alert("Importante", "" + MENSAJE + "" + CODIGO);
        alert.set({ transition: 'zoom' }); //slide, zoom, flipx, flipy, fade, pulse (default)
        alert.set('modal', false);  //al pulsar fuera del dialog se cierra o no	

    }

    if (FLAG == 7) {
        var alert = alertify.alert("Importante", "" + MENSAJE + "");
        alert.set({ transition: 'zoom' }); //slide, zoom, flipx, flipy, fade, pulse (default)
        alert.set('modal', false);  //al pulsar fuera del dialog se cierra o no	

    }

    if (FLAG == 8) {
        var alert = alertify.alert("Importante", "" + MENSAJE + "" + FILA);
        alert.set({ transition: 'zoom' }); //slide, zoom, flipx, flipy, fade, pulse (default)
        alert.set('modal', false);  //al pulsar fuera del dialog se cierra o no	

    }

    if (FLAG == 9) {
        var alert = alertify.alert("Importante", "" + MENSAJE + "" + CODIGO);
        alert.set({ transition: 'zoom' }); //slide, zoom, flipx, flipy, fade, pulse (default)
        alert.set('modal', false);  //al pulsar fuera del dialog se cierra o no	

    }

    if (FLAG == 10) {
        var alert = alertify.alert("Importante", "" + MENSAJE + "" + FILA);
        alert.set({ transition: 'zoom' }); //slide, zoom, flipx, flipy, fade, pulse (default)
        alert.set('modal', false);  //al pulsar fuera del dialog se cierra o no	

    }

    if (FLAG == 11) {
        var alert = alertify.alert("Importante", "" + MENSAJE + "" + FILA);
        alert.set({ transition: 'zoom' }); //slide, zoom, flipx, flipy, fade, pulse (default)
        alert.set('modal', false);  //al pulsar fuera del dialog se cierra o no	

    }

    if (FLAG == -999) {
        var alert = alertify.alert("ALERTA", "Se ha producido un Error... Por favor vuelva a intentarlo mas tarde.");
        alert.set({ transition: 'zoom' }); //slide, zoom, flipx, flipy, fade, pulse (default)
        alert.set('modal', false);  //al pulsar fuera del dialog se cierra o no	

    }

}

function validarPrecioVenta(e) {
    var precio = e.value;
    var patron = /((\d+)((\.\d{1,2})?))$/;

    precio = precio.trim();

    if (precio != "") {
        if (!patron.test(precio)) {
            alert("Número incorrecto");
        }
    }
    else {
        alert("Debe ingresar un número");

    }



}

function validarFormatoDecimalServidor(MENSAJE) {
    alert(MENSAJE);
}

function validarRefrescarPagina() {
    var cadenaAleatoria = generadorSecuenciaAleatoria();
    var campoOcultoCargaMasiva = document.getElementById("campoOcultoCargaMasiva");
    campoOcultoCargaMasiva.value = cadenaAleatoria;
}

function generadorSecuenciaAleatoria() {
    var g = "";
    for (var i = 0; i < 32; i++)
        g += Math.floor(Math.random() * 0xF).toString(0xF)

    return g;
}


