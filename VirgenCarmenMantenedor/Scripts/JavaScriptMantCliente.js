

let activo = -1;
let tipo = 0;
var holderID = "ContentPlaceHolder1_";
//var rbNumDocumento = $("#" + holderID + "rbNumDocumento");
//var rbNombres = $("#" + holderID +"rbNombres");
//var txtNumDoc_Ruc = $("#" + holderID+"txtNumDoc_Ruc");

var txtMrmNumDocumento = document.getElementById(holderID + "txtMrmNumDocumento");
//ContentPlaceHolder1_txtNumDoc_Ruc
//ContentPlaceHolder1_rbNombres
function desactiva1() {
    var txtNumDoc_Ruc = $("#ContentPlaceHolder1_txtNumDoc_Ruc");
    var rbNumDocumento = $("#" + holderID + "rbNumDocumento");
    var cbTipoDocumento = $("#" + holderID + "cbTipoDocumento");
    var txtNombres = $("#" + holderID + "txtNombres");
    //var rbNombres = $("#" + holderID + "rbNombres");
    //debugger;
    //if (rbNumDocumento.checked == true) {
    
        //rbNombres.checked = false;
        //cbTipoDocumento.disabled = false;
        //txtNombres.disabled = true;
        //txtNombres.value = "";
        //txtNumDoc_Ruc.value = "cambio";
        //txtNumDoc_Ruc.disabled = false;

        $("#" + holderID + "rbNombres").attr("checked", false);
        $("#" + holderID+ "txtNumDoc_Ruc").attr("disabled", false);
        $("#" + holderID + "txtNombres").attr("disabled", true);
        $("#" + holderID + "rbNombres").prop("checked", false); 
        $("#" + holderID + "cbTipoDocumento").prop("disabled", false); 
        $("#" + holderID + "txtNombres").val('');
        // creamos un variable que hace referencia al select--
        var select = document.getElementById(holderID+"cbTipoDocumento");
        // seleccionamos el valor
        select.selectedIndex = 0;
    //}
}

function desactiva2() {
    //if (rbNombres.checked == true) {

    //rbNumDocumento.checked = false;
    //cbTipoDocumento.disabled = true;
    $("#ContentPlaceHolder1_rbNumDocumento").prop("checked", false); 
    //$("#" + holderID + "rbNumDocumento").attr("checked", false);
    $("#" + holderID + "cbTipoDocumento").prop("disabled", true); 
    $("#" + holderID + "txtNumDoc_Ruc").attr("disabled", true);
    $("#" + holderID + "txtNombres").attr("disabled", false);
    $("#" + holderID + "txtNumDoc_Ruc").val('');
      //  txtNumDoc_Ruc.disabled = true;
       // txtNumDoc_Ruc.value = "";
       // txtNombres.value = "";
       // txtNombres.disabled = false;

    //}
}

function valida_NumDoc_Ruc(source, arguments) {

    var objTxtNumDoc_Ruc = document.getElementById(holderID+"txtNumDoc_Ruc");
    var objCvNumDoc_Ruc = document.getElementById(holderID+"cvNumDoc_Ruc");
    var opcion = document.getElementById(holderID+"cbTipoDocumento").value;

    var Valor = objTxtNumDoc_Ruc.value;

    switch (opcion) {
        case 'DNI':
            //Comprobación de valor numerico
            if (isNaN(Valor)) {
                objCvNumDoc_Ruc.textContent = "El DNI debe ser numérico";
                arguments.IsValid = false;
                return;
            }

            //Comprobación de valor negativo
            if (Valor < 0) {
                objCvNumDoc_Ruc.textContent = "El DNI con formato no válido";
                arguments.IsValid = false;
                return;
            }

            //Comprobacion de valor decimal
            var entero = parseInt(Valor);
            if (Valor != entero && Valor.toString() != entero.toString()) {
                objCvNumDoc_Ruc.textContent = "El DNI con formato no válido";
                arguments.IsValid = false;
                return;
            }

            //Comprobación de cantidad de caracteres
            if (Valor.length == 8) {
                arguments.IsValid = true;
                return;
            }
            else {
                objCvNumDoc_Ruc.textContent = "El DNI debe tener 8 dígitos";
                arguments.IsValid = false; //mostrar mensaje 
                return;
            }


        case 'CARNET EXTRANJERIA':
            if (objTxtNumDoc_Ruc.value.length >= 8 && objTxtNumDoc_Ruc.value.length <= 12) {
                arguments.IsValid = true;
                return;
            }
            else {
                objCvNumDoc_Ruc.textContent = "El Carnet Extranjería debe tener entre 8 a 12 caracteres";
                arguments.IsValid = false; //mostrar mensaje 
                return;
            }


        case 'RUC':
            //Comprobación de valor numerico
            if (isNaN(Valor)) {
                objCvNumDoc_Ruc.textContent = "El RUC debe ser numérico";
                arguments.IsValid = false;
                return;
            }

            //Comprobación de valor negativo
            if (Valor < 0) {
                objCvNumDoc_Ruc.textContent = "El RUC con formato no válido";
                arguments.IsValid = false
                return;
            }

            var entero = parseInt(Valor);
            if (Valor != entero && Valor.toString() != entero.toString()) {
                objCvNumDoc_Ruc.textContent = "El RUC con formato no válido";
                arguments.IsValid = false;
                return;
            }

            if (objTxtNumDoc_Ruc.value.length == 11) {
                arguments.IsValid = true;
                return;
            }
            else {
                objCvNumDoc_Ruc.textContent = "El RUC debe tener 11 dígitos";
                arguments.IsValid = false; //mostrar mensaje 
                return;
            }


        default: document.write("No esta definido el tipo de documento<br />")
    }

}

function alertaConfirmar() {
    swal(" ¿Estás seguro de que quieres hacer esto? ", {
        botones: [" ¡Oh noez! ", "¡ Aww sí! "],
    });
}

function alertaConfirmarEliminarCliente() {
    var seleccion = confirm("¿ Esta seguro de eliminar al cliente ?");
    if (seleccion == true) {
        return true;
    }
    else {
        return false;
    }
}

function alertaConfirmarEliminarPE() {
    var seleccion = confirm("¿ Esta seguro de eliminar el Punto de Entrega ?");
    if (seleccion == true) {
        return true;
    }
    else {
        return false;
    }
}

function mensajeConfirmacion() {
    var alert = alertify.alert("ALERTA", "SE HA MODIFICADO CORRECTAMENTE!").set('label', 'Aceptar');
    alert.set({ transition: 'zoom' }); //slide, zoom, flipx, flipy, fade, pulse (default)
    alert.set('modal', false);  //al pulsar fuera del dialog se cierra o no	
}

function mensajeConfirmacionRegistrar() {
    var alert = alertify.alert("ALERTA", "SE HA REGISTRADO CORRECTAMENTE!").set('label', 'Aceptar');
    alert.set({ transition: 'zoom' }); //slide, zoom, flipx, flipy, fade, pulse (default)
    alert.set('modal', false);  //al pulsar fuera del dialog se cierra o no	
}

function mensajeExisteCliente() {
    var alert = alertify.alert("ALERTA", "DNI DEL CLIENTE YA EXISTE!").set('label', 'Aceptar');
    alert.set({ transition: 'zoom' }); //slide, zoom, flipx, flipy, fade, pulse (default)
    alert.set('modal', false);  //al pulsar fuera del dialog se cierra o no	
}

function mensajeAgregarPE() {
    var alert = alertify.alert("ALERTA", "Llenar por lo menos un campo").set('label', 'Aceptar');
    alert.set({ transition: 'zoom' }); //slide, zoom, flipx, flipy, fade, pulse (default)
    alert.set('modal', false);  //al pulsar fuera del dialog se cierra o no	
}

function valida_txtMrmNumDocumento(source, arguments) {
    var objtxtMrmNumDocumento = document.getElementById(holderID+"txtMrmNumDocumento");
    var objCvMrmNumDocumento = document.getElementById(holderID+"cvMrmNumDocumento");
    var objbtnCancelarMdRegMod = document.getElementById(holderID+"btnCancelarMdRegMod");
    var opcion = document.getElementById(holderID+"cbMrmTipoDocumento").value;

    //Se activa al presionar click en regresar
    if (tipo != 1) {
        switch (opcion) {
            case "1":
                if (objtxtMrmNumDocumento.value.trim() != "") {

                    if (isNaN(objtxtMrmNumDocumento.value)) {
                        objCvMrmNumDocumento.textContent = "El DNI debe ser numérico";
                        arguments.IsValid = false;
                        return;
                    }

                    if (objtxtMrmNumDocumento.value < 0) {
                        objCvMrmNumDocumento.textContent = "El DNI con formato no válido";
                        arguments.IsValid = false;
                        return;
                    }

                    if (objtxtMrmNumDocumento.value.trim() != "") {
                        var entero = parseInt(objtxtMrmNumDocumento.value);
                        if (objtxtMrmNumDocumento.value != entero && objtxtMrmNumDocumento.value.toString() != entero.toString()) {
                            objCvMrmNumDocumento.textContent = "El DNI con formato no válido";
                            arguments.IsValid = false;
                            return;
                        }
                    }

                    //Comprobación de cantidad de caracteres
                    if (objtxtMrmNumDocumento.value.length == 8) {
                        arguments.IsValid = true;
                        return;
                    }
                    else {
                        objCvMrmNumDocumento.textContent = "El DNI debe tener 8 dígitos";
                        arguments.IsValid = false; //mostrar mensaje 
                        return;
                    }

                }
                else {
                    if (activo != 2) {
                        objCvMrmNumDocumento.textContent = "Debe ingresar DNI";
                        arguments.IsValid = false;
                        return;
                    }
                }

            case "2":
                if (objtxtMrmNumDocumento.value.trim() != "") {
                    if (objtxtMrmNumDocumento.value.length >= 8 && objtxtMrmNumDocumento.value.length <= 12) {
                        arguments.IsValid = true;
                        return;
                    }
                    else {
                        objCvMrmNumDocumento.textContent = "El Carnet Extranjería debe tener entre 8 a 12 caracteres";
                        arguments.IsValid = false; //mostrar mensaje 
                        return;
                    }
                }
                else {
                    if (activo != 2) {
                        objCvMrmNumDocumento.textContent = "Debe ingresar Carnet Extranjería";
                        arguments.IsValid = false;
                        return;
                    }
                }

        }
    }
    else {
        arguments.IsValid = true;
        return;
    }
}

function valida_txtMrmRUC(source, arguments) {
    var objtxtMrmRUC = document.getElementById(holderID+"txtMrmRUC");
    var objCvMrmRUC = document.getElementById(holderID+"cvMrmRUC");
    var objcbMrmTipoPersona = document.getElementById(holderID+"cbMrmTipoPersona");
    var opcion = document.getElementById(holderID+"cbMrmTipoDocumento").value;

    if (tipo != 1) {
        if (opcion) {
            if (objtxtMrmRUC.value.trim() != "") {
                if (objtxtMrmRUC.value < 0) {
                    objCvMrmRUC.textContent = "El RUC con formato no válido";
                    arguments.IsValid = false;
                    return;
                }

                if (objtxtMrmRUC.value.trim() != "") {
                    var entero = parseInt(objtxtMrmRUC.value);
                    if (objtxtMrmRUC.value != entero && objtxtMrmRUC.value.toString() != entero.toString()) {
                        objCvMrmRUC.textContent = "El RUC con formato no válido";
                        arguments.IsValid = false;
                        return;
                    }
                }

                if (objtxtMrmRUC.value.length == 11) {
                    arguments.IsValid = true;
                    return;
                }
                else {
                    objCvMrmRUC.textContent = "El RUC debe tener 11 dígitos";
                    arguments.IsValid = false; //mostrar mensaje 
                    return;
                }
            }
            else {
                if (activo != 2 && objcbMrmTipoPersona.value == 2) {
                    objCvMrmRUC.textContent = "Debe ingresar RUC";
                    arguments.IsValid = false;
                    return;
                }
            }
        }
    }
    else {
        arguments.IsValid = true;
        return;
    }
}

function valida_txtMrmCelular(source, arguments) {
    var objtxtMrmCelular = document.getElementById(holderID+"txtMrmCelular");
    var objCvMrmCelular = document.getElementById(holderID+"cvMrmCelular");
    var valor = objtxtMrmCelular.value;

    if (valor < 0) {
        objCvMrmCelular.textContent = "El celular con formato no válido";
        arguments.IsValid = false;
        return;
    }

    if (valor.trim() != "") {
        var entero = parseInt(valor);
        if (valor != entero && valor.toString() != entero.toString()) {
            objCvMrmCelular.textContent = "El celular con formato no válido";
            arguments.IsValid = false;
            return;
        }
    }

    if (valor.length == 9) {
        arguments.IsValid = true;
        return;
    }
    else {
        objCvMrmCelular.textContent = "El celular debe tener 9 dígitos";
        arguments.IsValid = false;
        return;
    }
}

function valida_txtMrmOrdenAtencion(source, arguments) {

    var objtxtMrmOrdenAtencion = document.getElementById(holderID+"txtMrmOrdenAtencion");
    var objCvMrmOrdenAtencion = document.getElementById(holderID+"cvMrmOrdenAtencion");
    var valor = objtxtMrmOrdenAtencion.value;

    if (isNaN(valor)) {
        objCvMrmOrdenAtencion.textContent = "El Orden Atención debe ser numérico";
        arguments.IsValid = false;
        return;
    }

    if (valor < 0) {
        objCvMrmOrdenAtencion.textContent = "El Orden Atención no debe ser negativo";
        arguments.IsValid = false;
        return;
    }

    var entero = parseInt(valor);
    if (valor == entero && valor.toString() == entero.toString()) {
        arguments.IsValid = true;
        return;
    }
    else {
        objCvMrmOrdenAtencion.textContent = "El Orden Atención debe ser número entero";
        arguments.IsValid = false;
        return;
    }
}

function actualizarUbigeoDf() {

    var objcbMrmDepa = document.getElementById(holderID+"cbMrmDepartamento");
    var objcbMrmProv = document.getElementById(holderID+"cbMrmProvincia");
    var objcbMrmDist = document.getElementById(holderID+"cbMrmDistrito");

    var valDist = objcbMrmDist.value;
    var valProv = valDist.substring(0, 4);
    var valDepa = valDist.substring(0, 2);

    objcbMrmProv.value = valProv;
    objcbMrmDepa.value = valDepa;
    txtMrmUbigeo.value = valDist;
}


function actualizarUbigeoPe(objcbMrmDist) {

    var valDist = objcbMrmDist.value;
    var valProv = valDist.substring(0, 4);
    var valDepa = valDist.substring(0, 2);

    var gv = document.getElementById(holderID+"gvMrmPuntosEntrega");
    var sl = gv.getElementsByTagName("select");

    //Acceder a los combos del FOOTER
    sl[1].value = valProv
    sl[0].value = valDepa;
}


function desactivaNumDoc_Ruc() {

    var objcbMrmTipoDoc = document.getElementById(holderID+"cbMrmTipoDocumento");
    var objcbMrmTipoPersona = document.getElementById(holderID+"cbMrmTipoPersona");

    if (objcbMrmTipoPersona.value == 2) {
        txtMrmNumDocumento.disabled = true;
        txtMrmRUC.disabled = false;
        txtMrmRazonSocial.disabled = false;
    }
    else {
        if (objcbMrmTipoDoc.value == 1) {
            txtMrmNumDocumento.disabled = false;
            txtMrmRUC.disabled = false;
            txtMrmRazonSocial.disabled = true;
        }
        else if (objcbMrmTipoDoc.value == 3) {
            objcbMrmTipoPersona.value = 2;
            objcbMrmTipoDoc.disabled = true;
        }
        else {
            txtMrmNumDocumento.disabled = false;
            txtMrmRUC.disabled = true;
            txtMrmRazonSocial.disabled = true;
        }

    }
}

function desactivaCbMrmTipoDoc() {

    var objcbMrmTipoPersona = document.getElementById(holderID+"cbMrmTipoPersona");
    var objcbMrmTipoDoc = document.getElementById(holderID+"cbMrmTipoDocumento");

    if (objcbMrmTipoPersona.value == 2) {
        if (objcbMrmTipoDoc.options.length < 3) {
            var option1 = document.createElement("option");
            option1.text = 'RUC';
            option1.value = '3';
            objcbMrmTipoDoc.options.add(option1);
        }

        objcbMrmTipoDoc.value = 3;
        objcbMrmTipoDoc.disabled = true;
        txtMrmNumDocumento.disabled = true;
        txtMrmNumDocumento.value = "";
        txtMrmRazonSocial.disabled = false;
        txtMrmRUC.disabled = false;
    }
    else {
        objcbMrmTipoDoc.remove(2);

        objcbMrmTipoDoc.value = 1;
        objcbMrmTipoDoc.disabled = false;
        txtMrmNumDocumento.disabled = false;
        txtMrmRazonSocial.disabled = true;
        txtMrmRazonSocial.value = "";
        txtMrmRUC.value = "";
    }
}


function valida_txtgvMrmOrdenEntrega(source, arguments) {

    var objtxtgvMrmOrdenEntrega = document.getElementById(holderID+"txtgvMrmOrdenEntrega");
    var objcvgvMrmOrdenEntrega = document.getElementById(holderID+"cvgvMrmOrdenEntrega");

    var gv = document.getElementById(holderID+"gvMrmPuntosEntrega");
    var ip = gv.getElementsByTagName("input");

    var valor = ip[0].value;

    var entero = parseInt(valor);
    if (valor != entero && valor.toString() != entero.toString()) {
        arguments.IsValid = false;
        return;
    }

    if (valor >= 0) {
        arguments.IsValid = true;
        return;
    }
    else {
        arguments.IsValid = false;
        return;
    }
}

function valida_txtMrmRazonSocial(source, arguments) {
    var objtxtMrmRazonSocial = document.getElementById(holderID+"txtMrmRazonSocial");
    var objCvMrmRazonSocial = document.getElementById(holderID+"cvMrmRazonSocial");
    var opcion = document.getElementById(holderID+"cbMrmTipoPersona").value;

    if (tipo != 1) {
        if (opcion == 2) {
            if (objtxtMrmRazonSocial.value.trim() != "") {
                arguments.IsValid = true;
                return;
            }
            else {
                if (activo != 2) {
                    objCvMrmRazonSocial.textContent = "Debe ingresar razón social";
                    arguments.IsValid = false;
                    return;
                }
                else {
                    activo = -1;
                }
            }
        }
    }
    else {
        arguments.IsValid = true;
        return;
    }
 }

function valida_txtMrmNombres(source, arguments) {
    var objtxtMrmNombres = document.getElementById(holderID+"txtMrmNombres");
    var objCvMrmNombres = document.getElementById(holderID+"cvMrmNombres");
    var objcbMrmTipoDoc = document.getElementById(holderID+"cbMrmTipoDocumento");

    if (tipo != 1) {
        if (objcbMrmTipoDoc.value == 1 || objcbMrmTipoDoc.value == 2) {
            if (objtxtMrmNombres.value.trim() != "") {
                arguments.IsValid = true;
                return;
            }
            else {
                if (activo != 2) {
                    objCvMrmNombres.textContent = "Debe ingresar nombres";
                    arguments.IsValid = false;
                    return;
                }
            }
        }
    }
    else {
        arguments.IsValid = true;
        return;
    }
}

function valida_txtMrmApellPaterno(source, arguments) {

    var objtxtMrmApellPaterno = document.getElementById(holderID+"txtMrmApellPaterno");
    var objCvMrmApellPaterno = document.getElementById(holderID+"cvMrmApellPaterno");
    var objcbMrmTipoDoc = document.getElementById(holderID+"cbMrmTipoDocumento");

    if (tipo != 1) {
        if (objcbMrmTipoDoc.value == 1 || objcbMrmTipoDoc.value == 2) {
            if (objtxtMrmApellPaterno.value.trim() != "") {
                arguments.IsValid = true;
                return;
            }
            else {
                if (activo != 2) {
                    objCvMrmApellPaterno.textContent = "Debe ingresar apellido paterno";
                    arguments.IsValid = false;
                    return;
                }
            }
        }
    }
    else {
        arguments.IsValid = true;
        return;
    }
}

function valida_txtMrmApellMaterno(source, arguments) {
    var objtxtMrmApellMaterno = document.getElementById(holderID+"txtMrmApellMaterno");
    var objCvMrmApellMaterno = document.getElementById(holderID+"cvMrmApellMaterno");
    var objcbMrmTipoDoc = document.getElementById(holderID+"cbMrmTipoDocumento");

    if (tipo != 1) {
        if (objcbMrmTipoDoc.value == 1 || objcbMrmTipoDoc.value == 2) {

            if (objtxtMrmApellMaterno.value.trim() != "") {
                arguments.IsValid = true;
                return;
            }
            else {
                if (activo != 2) {
                    objCvMrmApellMaterno.textContent = "Debe ingresar apellido materno";
                    arguments.IsValid = false;
                    return;
                }
                else {
                    activo = -1;
                }
            }

        }
    }
    else {
        arguments.IsValid = true;
        return;
    }

}


function valida_txtMrmTelefono(source, arguments) {
    var objtxtMrmTelefono = document.getElementById(holderID+"txtMrmTelefono");
    var objCvMrmTelefono = document.getElementById(holderID+"cvMrmTelefono");
    var numericMatchexpression = /^[8]{1}[1-9]{2}[0-9]{5}$/

    var re = new RegExp(numericMatchexpression);

    if (!re.test(objtxtMrmTelefono.value)) {
        objCvMrmTelefono.textContent = "Teléfono con formato no válido";
        arguments.IsValid = false;
        return;
    }
    else {
        arguments.IsValid = true;
        return;
    }
}

function lkbEditarCliente() {
    var objcbMrmTipoPersona = document.getElementById(holderID+"cbMrmTipoPersona");
    var objcbMrmTipoDoc = document.getElementById(holderID+"cbMrmTipoDocumento");

    cbMrnTipoDocumento.disabled = true;
    cbMrmTipoPersona.disabled = true;

    activo = 2;
}

function lkbVerDetalleCliente() {
    tipo = 1;
    activo = 2;
}

function btnCancelarDetalle() {
    tipo = 1;
    activo = 2;
}

function btnCancelarMdRegMod_Click() {
    tipo = 1;
    activo = 2;
}

function btnCancelarMdRegMod_Click() {
    tipo = 1;
    activo = 2;
}

function btnAgregar_Click() {

    cbMrnTipoDocumento.disabled = false;
    cbMrmTipoPersona.disabled = false;
    tipo = 0;
}