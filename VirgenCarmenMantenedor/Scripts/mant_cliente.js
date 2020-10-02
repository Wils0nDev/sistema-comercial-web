
var holderID = "ContentPlaceHolder1_";
var txtMrmNumDocumento = document.getElementById(holderID + "txtMrmNumDocumento");
    function display() {
        var btnGuardarMapPentrega = $('#btnGuardarMapPE');
        var btnGuardarMap = $("#btnGuardarMap");
        btnGuardarMap.css("display", "block");
        btnGuardarMapPentrega.css("display", "none");
}

function displaytwo() {
    var btnGuardarMapPentrega = $('#btnGuardarMapPE');
    var btnGuardarMap = $("#btnGuardarMap");

    btnGuardarMap.css("display", "none");
    btnGuardarMapPentrega.css("display", "block");
}


const showLoading = function () {
    swal({
        title: "Now loading",
        allowEscapeKey: false,
        allowOutsideClick: false,
        timer: 2000,
        onOpen: () => {
            swal.showLoading();
        }
    }).then(
        () => { },
        (dismiss) => {
            if (dismiss === "timer") {
                console.log("closed by timer!!!!");
                swal({
                    title: "Finished!",
                    type: "success",
                    timer: 2000,
                    showConfirmButton: false
                });
            }
        }
    );
};

$(document).ready(function () {
    //showLoading();
    $("#mensaje_consulta_reniec").hide();
    $("#mensaje_consulta_sunat").hide();
});

function keyClienteReniec() {

    //showLoading();

    var txtMrmNumDocumento = document.getElementById(holderID + "txtMrmNumDocumento");
    var valorNumdoc = $("#" + holderID+"txtMrmNumDocumento");
    var objcbMrmTipoDoc = document.getElementById(holderID+"cbMrmTipoDocumento");
    var objcbMrmTipoPersona = document.getElementById(holderID+"cbMrmTipoPersona");

    if (valorNumdoc.val().trim().length == 8 && objcbMrmTipoDoc.value == 1) {

        
        var numDocumento = "";
        var tipoDoc = objcbMrmTipoDoc.value;
        var tipoPer = objcbMrmTipoPersona.value;
        numDocumento = txtMrmNumDocumento.value.trim();
        ValidarExisteCliente(numDocumento, tipoDoc, tipoPer);

        //BuscarClienteReniec(valorNumdoc.val());
    }
}

function BuscarClienteReniec(numDocumento) {
    $('#mensaje_consulta_reniec').html('Consultando datos...');
    //$('<p>Consultando datos...</p>').appendTo('#mensaje_consulta_reniec');
    $("#mensaje_consulta_reniec").show();

    //DESCRIPCION : Funcion que me trae la lista de rutas.
    $.ajax({
        type: "POST",
        url: "frmMantCliente.aspx/BuscarClienteReniec",
        data: "{'numDocumento': '" + numDocumento + "'}",
        contentType: 'application/json; charset=utf-8',
        error: function (xhr, ajaxOtions, thrownError) {
            $("#mensaje_consulta_reniec").hide();
        },
        success: function (data) {
            console.log(data.d);
            $("#mensaje_consulta_reniec").hide();
            
            LlenarDatosReniec(data.d);


        }
    });
}

function LlenarDatosReniec(data) {
    var valNombreCliente = $("#" +holderID +"txtMrmNombres");
    var valAppPatCliente = $("#" + holderID + "txtMrmApellPaterno");
    var valAppMatCliente = $("#" + holderID + "txtMrmApellMaterno");
    if (data.ErrorWebSer.CodigoErr == 2000) {
        valNombreCliente.val(data.respuestaWsReniec.nombres);
        valAppPatCliente.val(data.respuestaWsReniec.apellido_paterno);
        valAppMatCliente.val(data.respuestaWsReniec.apellido_materno);
        

    } else {
        console.log("Sin datos devueltos reniec");
    }

}

//sunat
function keyClienteSunat() {

    var valorRuc = document.getElementById(holderID+"txtMrmRUC");
    var objcbMrmTipoPersona = document.getElementById(holderID+"cbMrmTipoPersona");
    var objcbMrmTipoDoc = document.getElementById(holderID+"cbMrmTipoDocumento");

    if (valorRuc.value.trim().length == 11) {


        var numDocumento = "";
        var tipoDoc = objcbMrmTipoDoc.value;
        var tipoPer = objcbMrmTipoPersona.value;
        numDocumento = valorRuc.value.trim();
        ValidarExisteCliente(numDocumento, tipoDoc, tipoPer);
        
    }

}

function BuscarClienteSunat(numDocumento) {
    $('#mensaje_consulta_sunat').html('Consultando datos...');
    $("#mensaje_consulta_sunat").show();
    $.ajax({
        type: "POST",
        url: "frmMantCliente.aspx/BuscarClienteSunat",
        data: "{'numDocumento': '" + numDocumento + "'}",
        contentType: 'application/json; charset=utf-8',
        error: function (xhr, ajaxOtions, thrownError) {
            $("#mensaje_consulta_sunat").hide();
        },
        success: function (data) {
            console.log("sunat");
            console.log(data.d);
            $("#mensaje_consulta_sunat").hide();
            LlenarDatosSunat(data.d);


        }
    });
}

function LlenarDatosSunat(data) {
    var valRucCliente = $("#" + holderID + "txtMrmRazonSocial");
    if (data.ErrorWebSer.CodigoErr == 2000) {
        valRucCliente.val(data.respuestaWsSunat.razon_social);
    } else {
        console.log("Sin datos devueltos sunat");
    }

}


function validarOrdenAtencion(e) {
    var key = window.Event ? e.which : e.keyCode
   
    return (key >= 48 && key <= 57)
}

function soloNumeros(e) {
    var key = window.Event ? e.which : e.keyCode
    return (key >= 48 && key <= 57)
}

function select_TipPersona() {

    
    var txtMrmNumDocumento = document.getElementById(holderID + "txtMrmNumDocumento");
    var txtMrmRUC = document.getElementById(holderID + "txtMrmRUC");
    var txtMrmRazonSocial = document.getElementById(holderID + "txtMrmRazonSocial");
    var objcbMrmTipoPersona = document.getElementById(holderID +"cbMrmTipoPersona");
    var objcbMrmTipoDoc = document.getElementById(holderID+"cbMrmTipoDocumento");
    var objtxtMrmNombres = document.getElementById(holderID+"txtMrmNombres");
    var objtxtMrmApepat = document.getElementById(holderID+"txtMrmApellPaterno");
    var objtxtMrmApemat = document.getElementById(holderID+"txtMrmApellMaterno");

    if (objcbMrmTipoPersona.value == 1) {
        objcbMrmTipoDoc.disabled = false;
        objcbMrmTipoDoc.value = 1;
        txtMrmNumDocumento.disabled = false;
        txtMrmRUC.disabled = false;
        txtMrmRazonSocial.disabled = false;
        objtxtMrmNombres.disabled = false;
        objtxtMrmApepat.disabled = false;
        objtxtMrmApemat.disabled = false;
    }
    else if (objcbMrmTipoPersona.value == 2) {
        objcbMrmTipoDoc.disabled = true;
        objcbMrmTipoDoc.value = 3;
        txtMrmNumDocumento.disabled = true;
        txtMrmRUC.disabled = false;
        txtMrmRazonSocial.disabled = false;
        objtxtMrmNombres.disabled = true;
        objtxtMrmApepat.disabled = true;
        objtxtMrmApemat.disabled = true;

    }
}

function jsValidarCliente() {
    var respuesta = true;
    var txtMrmNumDocumento = document.getElementById(holderID + "txtMrmNumDocumento");
    var objcbMrmTipoPersona = document.getElementById(holderID+"cbMrmTipoPersona");
    var objcbMrmTipoDoc = document.getElementById(holderID+"cbMrmTipoDocumento");
    var objtxtMrmNombres = document.getElementById(holderID+"txtMrmNombres");
    var objtxtMrmApepat = document.getElementById(holderID+"txtMrmApellPaterno");
    var objtxtMrmApemat = document.getElementById(holderID+"txtMrmApellMaterno");
    var objtxtMrmRUC = document.getElementById(holderID+"txtMrmRUC");
    var objtxtMrmRazonSocial = document.getElementById(holderID+"txtMrmRazonSocial");
    var objtxtMrmOrdenAtencion = document.getElementById(holderID+"txtMrmOrdenAtencion");
    var objtxtMrmDireccion = document.getElementById(holderID+"txtMrmDireccion");

    var objcbMrmDepartamento = document.getElementById(holderID+"cbMrmDepartamento");
    var objcbMrmProvincia = document.getElementById(holderID+"cbMrmProvincia");
    var objcbMrmDistrito = document.getElementById(holderID+"cbMrmDistrito");

    if (objtxtMrmOrdenAtencion.value.trim() == "") {
        mostrarMensajeError("Ingrese orden de atención");
        return false;
    }

    if (objcbMrmTipoPersona.value == 1) {
        //if (objcbMrmTipoDoc.value = 1) {
            if (txtMrmNumDocumento.value.trim() == "") {
                mostrarMensajeError("Ingrese número de documento");
                //txtMrmNumDocumento.focus();
                return false;
            }
            if (objtxtMrmNombres.value.trim() == "") {
                mostrarMensajeError("Ingrese nombre");
                return false;
            }
            if (objtxtMrmApepat.value.trim() == "") {
                mostrarMensajeError("Ingrese apellido paterno");
                return false;
            }
            if (objtxtMrmApemat.value.trim() == "") {
                mostrarMensajeError("Ingrese apellido materno");
                return false;
            }
        //}
        

    } else if (objcbMrmTipoPersona.value = 2) {
        if (objtxtMrmRUC.value.trim() == "") {
            mostrarMensajeError("Ingrese RUC");
            return false;
        }
        if (objtxtMrmRazonSocial.value.trim() == "") {
            mostrarMensajeError("Ingrese razón social");
            return false;
        }
    }
    
    if (objtxtMrmDireccion.value.trim() == "") {
        mostrarMensajeError("Ingrese dirección");
        return false;
    }

    if (objcbMrmDepartamento.value == "00") {
        mostrarMensajeError("Ingrese departamento");
        return false;
    }
    if (objcbMrmProvincia.value == "0000") {
        mostrarMensajeError("Ingrese provincia");
        return false;
    }
    if (objcbMrmDistrito.value == "000000") {
        mostrarMensajeError("Ingrese distrito");
        return false;
    }

    var numDocumento = "";
    var tipoDoc = objcbMrmTipoDoc.value;
    if (tipoDoc == 1) {
        numDocumento = txtMrmNumDocumento.value.trim();
    } else if (tipoDoc == 3) {
        numDocumento = objtxtMrmRUC.value.trim();
    }
    /*
    console.log("respuas meodo :  " + ValidarExisteCliente(numDocumento, tipoDoc));
    if (ValidarExisteCliente(numDocumento, tipoDoc) == "false") {
        alert("false");
        mostrarMensajeError("Cliente ya se encuentra registrado");
        return false;
    } else {
        alert("true");
    }
    */

    return respuesta;
}

function ValidarExisteCliente(numDocumento, tipoDoc, tipoPer) {
    //DESCRIPCION : Funcion que me trae la lista de rutas.
    var valorRuc = document.getElementById(holderID + "txtMrmRUC");
    var txtMrmNumDocumento = document.getElementById(holderID + "txtMrmNumDocumento");
    var estadoCli = true;
    var json = JSON.stringify({
        numDocumento: numDocumento, 
        tipoDoc: tipoDoc, tipoPer: tipoPer
    });
    
    $.ajax({
        type: "POST",
        url: "frmMantCliente.aspx/ValidarExisteCliente",
        data: json,
        contentType: 'application/json; charset=utf-8',
        error: function (xhr, ajaxOtions, thrownError) {
           // console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            estadoCli = true;
            return estadoCli;
        },
        success: function (data) {
            //console.log("respuesta: " + data.d);
            estadoCli = data.d;
            if (tipoDoc == 1) {
                if (data.d == false) {
                    mostrarMensajeError("Documento del cliente ya se encuentra registrado");
                    txtMrmNumDocumento.value = "";
                } else {
                    BuscarClienteReniec(numDocumento);
                }
            }

            if (tipoDoc == 3 || tipoPer ==2) {
                if (data.d == false) {
                    mostrarMensajeError("RUC del cliente ya se encuentra registrado");
                    valorRuc.value = "";
                } else {
                    BuscarClienteSunat(numDocumento);
                }
            }
            
            return estadoCli;
            //var bytes = new Uint8Array(data.d);

        }
    });
    //return estadoCli;
}


function mostrarMensajeError(mensaje) {
    swal("", mensaje, "error");//.then((willDelete);
    /*=> {
        if (willDelete) {
            //vendedores.focus();
            //location.reload();
        }
    });*/
}

