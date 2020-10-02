$(document).ready(function () {
    //Lista de Variables
    var preventa = $("#id_preventa");
    var vendedores = $("#id_vendedor");
    var productoInput = $("#id_producto");
    var productoCod = $("#id_codProducto");
    var clienteInput = $("#id_cliente");
    var clienteCod = $("#id_codCliente");
    var proveedor = $("#id_proveedor");
    var ruta = $("#id_ruta");
    var estado = $("#id_estado");
    var tipo_venta = $("#id_tipo_venta");
    var tipo_doc = $("#id_tipo_doc");
    var origen_venta = $("#id_origen_venta");
    var fechaEntregaI = $("#id_fechaEntregaI");
    var fechaEntregaF = $("#id_fechaEntregaF");
    var fechaRegistroI = $("#id_fechaRegistroI");
    var fechaRegistroF = $("#id_fechaRegistroF");
    var btnBuscar = $("#id_btnBuscar");
    //Variables del modal ver preventa
    var MVvendedor = $("#MVvendedor");
    var MVcliente = $("#MVcliente");
    var MVruta = $("#MVruta");
    var MVentrega = $("#MVentrega");
    var MVpreventa = $("#MVpreventa");
    var MVfechar = $("#MVfechar");
    var MVtventa = $("#MVtventa");
    var MVfechae = $("#MVfechae");
    var MVtdoc = $("#MVtdoc");
    var MVestado = $("#MVestado");
    var MVrecargo = $("#MVrecargo");
    var MVtotal = $("#MVtotal");
    var MVoventa = $("#MVoventa");
    var MVigv = $("#MVigv");
    var MVmoneda = $("#MVmoneda");
    var MVdescuento = $("#MVdescuento");
    var MVsubtotal = $("#MVsubtotal");
    var desc_detalle = $("#id_desc_detalle");
    var promo_detalle = $("#id_promo_detalle");

    var msjFechaE = $("#msjFechaE");
    var msjFechaR = $("#msjFechaR");

    var tblPreventa = $("#id_tblPreventa");
    var tblDetalle = $("#id_table_detalle");
    var btnVer = ' <button type="button" title="Ver" class="icon-eye btnEye btnVer" data-toggle="modal"  data-target="#modalVer" ></button>';
    var btnEditar = ' <button type="button" title="Editar" class="icon-pencil btnEditar btnModificar" data-toggle="modal" data-target="#modaEditar"></button>';
    var btnAnular = ' <button type="button" title="Anular" class="icon-cancel-circle btnCancel btnAnular" data-toggle="modal" data-target="#modalAnular"></button>';
    var btndescargar = ' <button type="button" title="Descargar" class="icon-file-pdf btnPdf btndescargar"></button>';


    //Convertimos la tabla preventa en dataTable y le pasamos parametros
    tblPreventa.DataTable({
        language: {
            lengthMenu: "Mostrar _MENU_ registros",
            zeroRecords: "No hay registros",
            info: "Mostrando la página _PAGE_ de _PAGES_",
            infoEmpty: "No hay registros disponibles.",
            infoFiltered: "(filtered from _MAX_ total records)",
            search: "Busqueda rapida: ",
            oPaginate: {
                "sFirst": "Primero",
                "sLast": "Último",
                "sNext": "Siguiente",
                "sPrevious": "Anterior"
            }
        },
        order: [[0, "desc"]],
        columnDefs: [
            {
                "width": "2%",
                "targets": [0]
            },
            {
                "width": "10%",
                "targets": [1, 4, 5]
            },
            {
                "width": "25%",
                "targets": [2, 3]
            },
            {
                "targets": [6, 7, 8, 9, 10, 11, 12, 13, 14, 16, 17, 18, 19, 20, 21, 22],
                "visible": false,
                "searchable": false
            },
            {
                "width": "15%",
                "targets": [15]
            },
            {
                "className": "text-right", "targets": [4]
            }
        ]
    });
    //creo variables despues de que el DataTable este creado en el DOM.
    var tabla = $("#id_tblPreventa").dataTable(); //funcion jquery
    var table = $("#id_tblPreventa").DataTable(); //funcion DataTable-libreria
    table.columns.adjust().draw();

    //Convertimos la tabla detalle preventa en dataTable y le pasamos parametros
    tblDetalle.DataTable({
        language: {
            lengthMenu: "Mostrar _MENU_ registros",
            zeroRecords: "No hay registros",
            info: "Mostrando la página _PAGE_ de _PAGES_",
            infoEmpty: "No hay registros disponibles.",
            infoFiltered: "(filtered from _MAX_ total records)",
            search: "Busqueda rapida: ",
            Paginate: {
                "sFirst": "Primero",
                "sLast": "Último",
                "sNext": "Siguiente",
                "sPrevious": "Anterior"
            }
        },
        columnDefs: [
            {
                "width": "1%",
                "targets": [0, 3, 4, 5, 6]
            },
            {
                "width": "4%",
                "targets": [1]
            },
            {
                "width": "30%",
                "targets": [2]
            },
            {
                "width": "2%",
                "targets": [7, 8]
            },
            {
                "className": "text-right", "targets": [5, 6, 8]
            },
            {
                "className": "text-center", "targets": [0, 3, 4]
            }
        ]
    });
    var tablaver = $("#id_table_detalle").dataTable(); //funcion jquery
    var tablever = $("#id_table_detalle").DataTable(); //funcion DataTable-libreria
    tablever.columns.adjust().draw();

    function detalle_preventa(npre) {
        //DESCRIPCION : Funcion que me trae la lista del detalle de la preventa por codigo de preventa
        $.ajax({
            type: "POST",
            url: "frmMantPreventa.aspx/ListarDetalle",
            data: "{'npre': '" + npre + "'}",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                tablever.clear().draw();
                llenarTablaVer(data.d);
            }
        });
    }

    function llenarTablaVer(data) {
        //DESCRIPCION: Funcion para llenar la tabla del modal ver.
        var tdesc = 0;
        var contDesc = 0;
        var contPro = 0;
        desc_detalle.html("");
        promo_detalle.html("");
        for (var i = 0; i < data.length; i++) {
            tdesc = tdesc + data[i].descuento;
            tablaver.fnAddData([
                data[i].item,
                data[i].codProducto,
                data[i].descripcion,
                data[i].cantidad,
                data[i].um,
                data[i].precio.toFixed(2),
                data[i].descuento.toFixed(2),
                data[i].tipo,
                (data[i].precio * data[i].cantidadUnidadBase - data[i].descuento).toFixed(2)
            ]);

        }
        var cont2 = 0;
        var milista = new Array();
        milista.push(0);
        for (var j = 0; j < data.length; j++) {
            if (data[j].codPro !== 0) {
                for (var k = 0; k < milista.length; k++) {
                    if (milista[k] === data[j].codPro) {
                        cont2++;
                    }
                }
                if (cont2 === 0) {
                    milista.push(data[j].codPro);
                    promo_detalle.append("<p>" + data[j].descrPro + "</p>");
                }
                cont2 = 0;
                contPro = 1;
            }
            if (data[j].codDec !== 0) {
                desc_detalle.append("<p>" + data[j].descrDesc + "</p>");
                contDesc = 1;
            }
        }
        if (contDesc === 0) { desc_detalle.append("<p>No hay descuentos en los productos de la preventa</p>"); }
        if (contPro === 0) { promo_detalle.append("<p>No hay promociones en los productos de la preventa</p>"); }
        MVdescuento.val(tdesc.toFixed(2));
    }
    fechaRegistroI.val("");
    fechaRegistroF.val("");
    fechaEntregaI.val("");
    fechaEntregaF.val("");

    //Lllenar tabla preventa------------------------------------------------------------------------------------------------------------------
    function EnviarDatos() {
        //DESCRIPCION : Funcion para enviar los datos de los filtros.
        $(btnBuscar).on('click', function () {

            if ((fechaEntregaI.val() !== "" && fechaEntregaF.val() === "") || (fechaEntregaI.val() === "" && fechaEntregaF.val() !== "")) {
                mensajeValFecha(msjFechaE, "Debe completar las dos fechas de entrega");
                fechaEntregaI.val("");
                fechaEntregaF.val("");
                //fechaEntregaI.focus();
            } else if ((fechaRegistroI.val() !== "" && fechaRegistroF.val() === "") || (fechaRegistroI.val() === "" && fechaRegistroF.val() !== "")) {
                mensajeValFecha(msjFechaR, "Debe completar las dos fechas de registro");
                fechaRegistroI.val("");
                fechaRegistroF.val("");
                //fechaRegistroI.focus();
            } else {
                var codfechaRegistroI = fechaRegistroI.val();
                var codfechaRegistroF = fechaRegistroF.val();
                validarDiasMaximo(codfechaRegistroI, codfechaRegistroF);
            }
        });
    }
    EnviarDatos();
    function validarDiasMaximo(fecha1, fecha2) {
        //DESCRIPCION : Funcion validad el rango maxino de la fecha de entrada
        var json = JSON.stringify({ fechaRegI: fecha1, fechaRegF: fecha2 });
        $.ajax({
            type: "POST",
            url: "frmMantPreventa.aspx/ValidarFecharR",
            data: json,
            //async: false,
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                recepcion(data.d);
            }
        });
    }
    function recepcion(datos) {
        if (datos.codigo === 0) {
            console.log(datos.codigo);
            console.log(datos.mensaje);
            mensajeValFecha(msjFechaR, datos.mensaje);
            fechaRegistroI.val("");
            fechaRegistroF.val("");
            //fechaRegistroI.focus();
        } else {
            var codPreventa = preventa.val();
            var codvendedor = vendedores.find("option:selected").val();
            var codProducto = productoCod.val();
            var codCliente = clienteCod.val();
            var codProveedor = proveedor.find("option:selected").val();
            var codRuta = ruta.find("option:selected").val();
            var codEstado = estado.find("option:selected").val();
            var codTipo_venta = tipo_venta.find("option:selected").val();
            var codTipo_doc = tipo_doc.find("option:selected").val();
            var codOrigen_venta = origen_venta.find("option:selected").val();
            var codfechaEntregaI = fechaEntregaI.val();
            var codfechaEntregaF = fechaEntregaF.val();
            var codfechaRegistroI = fechaRegistroI.val();
            var codfechaRegistroF = fechaRegistroF.val();
            var json = JSON.stringify({
                codPreventa: codPreventa, codvendedor: codvendedor, codProducto: codProducto, codCliente: codCliente, codProveedor: codProveedor,
                codRuta: codRuta, codEstado: codEstado, codTipo_venta: codTipo_venta, codTipo_doc: codTipo_doc,
                codOrigen_venta: codOrigen_venta, codfechaEntregaI: codfechaEntregaI, codfechaEntregaF: codfechaEntregaF,
                codfechaRegistroI: codfechaRegistroI, codfechaRegistroF: codfechaRegistroF
            });
            ListarPreventas(json);
        }
    }
    function ListarPreventas(datos) {
        //DESCRIPCION : Funcion que me trae la lista de preventas
        $.ajax({
            type: "POST",
            url: "frmMantPreventa.aspx/ListarPreventa",
            data: datos,
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                table.clear().draw();
                llenarTabla(data.d);
            }
        });
    }

    function llenarTabla(data) {
        //DESCRIPCION : Funcion para llenar la tabla de preventas
        for (var i = 0; i < data.length; i++) {
            if (data[i].codestado !== 1) {
                var botones = btnVer + btndescargar;
            } else {
                botones = btnVer + btnEditar + btnAnular + btndescargar;
            }
            tabla.fnAddData([
                data[i].ntraPreventa,
                data[i].FechaR,
                data[i].cliente,
                data[i].vendedor,
                data[i].total.toFixed(2),
                data[i].estado,
                data[i].ruta,
                data[i].PuntoEntrega,
                data[i].Tventa,
                data[i].Tdoc,
                data[i].Oven,
                data[i].FechaE,
                data[i].recargo.toFixed(2),
                data[i].igv.toFixed(2),
                data[i].moneda,
                botones,
                data[i].sucursal,
                data[i].tipoPersona,
                data[i].identificacion,
                data[i].codUbigeo,
                data[i].codUsuario,
                data[i].codCliente,
                data[i].codPuntoEntrega
            ]);
        }
    }

    $("body").on('click', '.btnVer', function () {
        limpiarModalVer();
        var tr = $(this).parent().parent();
        var npre = table.row(tr).data()[0];
        var subtotal = (table.row(tr).data()[4] - table.row(tr).data()[13]).toFixed(2);
        MVvendedor.val(table.row(tr).data()[3]);
        MVcliente.val(table.row(tr).data()[2]);
        MVruta.val(table.row(tr).data()[6]);
        MVentrega.val(table.row(tr).data()[7]);
        MVpreventa.val(table.row(tr).data()[0]);
        MVfechar.val(table.row(tr).data()[1]);
        MVtventa.val(table.row(tr).data()[8]);
        MVfechae.val(table.row(tr).data()[11]);
        MVtdoc.val(table.row(tr).data()[9]);
        MVestado.val(table.row(tr).data()[5]);
        MVrecargo.val(table.row(tr).data()[12]);
        MVtotal.val(table.row(tr).data()[4]);
        MVoventa.val(table.row(tr).data()[10]);
        MVigv.val(table.row(tr).data()[13]);
        MVmoneda.val(table.row(tr).data()[14]);
        MVsubtotal.val(subtotal);

        detalle_preventa(npre);
    });
    $("body").on('click', '.btnModificar', function () {
        var tr = $(this).parent().parent();
        var codPreventa = table.row(tr).data()[0];
        var codVendedor = table.row(tr).data()[20];
        window.location.href = "registrarpreventa.aspx?pre=" + codPreventa + "&ven=" + codVendedor;
    });
    $("body").on('click', '.btnAnular', function () {
        var tr_anu = $(this).parent().parent();
        var npre = table.row(tr_anu).data()[0];
        swal({
            title: "Se anularala Preventa",
            text: "¿Esta seguro que desea anular la preventa?",
            icon: "warning",
            buttons: true,
            dangerMode: true,
        })
            //Promesa que me trae el valor true al confirmar OK.
            .then((willDelete) => {
                if (willDelete) {
                    Anularpreventa(npre);
                    swal("Se anulo la preventa", {
                        icon: "success"
                    });

                } else {
                    swal("Se Cancelo la anulacion de la preventa");
                }
            });
    });
    $("body").on('click', '.btndescargar', function () {
        var tr_impr = $(this).parent().parent();
        var npre = table.row(tr_impr).data()[0];
        var jason2 = JSON.stringify({
            datosPre: {
                ntraPreventa: table.row(tr_impr).data()[0], vendedor: table.row(tr_impr).data()[3], cliente: table.row(tr_impr).data()[2],
                ruta: table.row(tr_impr).data()[6], PuntoEntrega: table.row(tr_impr).data()[7], Tventa: table.row(tr_impr).data()[8],
                Tdoc: table.row(tr_impr).data()[9], Oven: table.row(tr_impr).data()[10], estado: table.row(tr_impr).data()[5],
                FechaR: table.row(tr_impr).data()[1], FechaE: table.row(tr_impr).data()[11], recargo: table.row(tr_impr).data()[12],
                igv: table.row(tr_impr).data()[13], moneda: table.row(tr_impr).data()[14], total: table.row(tr_impr).data()[4],
                sucursal: table.row(tr_impr).data()[16], tipoPersona: table.row(tr_impr).data()[17],
                identificacion: table.row(tr_impr).data()[18], codUbigeo: table.row(tr_impr).data()[19]
            }
        });
        descargarPdf(jason2, npre);
    });


    function Anularpreventa(npre) {
        //DESCRIPCION: Funcion para anular la preventa selecionada
        $.ajax({
            type: "POST",
            url: "frmMantPreventa.aspx/anularPreventa",
            data: "{'npre': '" + npre + "' }",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                //console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (response) {
                if (response.d === 0) {
                    $(btnBuscar).click();
                }
            }
        });
    }

    //Listar los campos de filtros----------------------------------------------------------------------------------------------------
    function ListarProveedor() {
        //DESCRIPCION : Funcion que me trae la lista de proveedores.
        $.ajax({
            type: "POST",
            url: "frmMantPreventa.aspx/ListarCampos",
            data: "{'flag': '5' }",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                addSelectProveedor(data.d);
            }
        });
    }
    ListarProveedor();
    function addSelectProveedor(data) {
        //DESCRIPCION : Funcion para llenar la lista de opciones del select de proveedores.
        for (var i = 0; i < data.length; i++) {
            proveedor.append("<option value=" + data[i]["codigo"] + ">" + data[i]["descripcion"] + "</option>");
        }
    }

    function ListarEstado() {
        //DESCRIPCION : Funcion que me trae la lista de estados de la preventa
        $.ajax({
            type: "POST",
            url: "frmMantPreventa.aspx/ListarConcepto",
            data: "{'flag': '19'}",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                addSelectEstado(data.d);
            }
        });
    }
    ListarEstado();
    function addSelectEstado(data) {
        //DESCRIPCION : Funcion para llenar la lista de opciones del select del estado.
        for (var i = 0; i < data.length; i++) {
            estado.append("<option value=" + data[i]["correlativo"] + ">" + data[i]["descripcion"] + "</option>");
        }
    }

    function ListarTipoVenta() {
        //DESCRIPCION : Funcion que me trae la lista de tipo de venta de la preventa
        $.ajax({
            type: "POST",
            url: "frmMantPreventa.aspx/ListarConcepto",
            data: "{'flag': '21'}",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                addSelectTipoVenta(data.d);
            }
        });
    }
    ListarTipoVenta();
    function addSelectTipoVenta(data) {
        //DESCRIPCION : Funcion para llenar la lista de opciones del select del tipo de venta.
        for (var i = 0; i < data.length; i++) {
            tipo_venta.append("<option value=" + data[i]["correlativo"] + ">" + data[i]["descripcion"] + "</option>");
        }
    }

    function ListarTipoDocumento() {
        //DESCRIPCION : Funcion que me trae la lista de tipo de documento de la preventa.
        $.ajax({
            type: "POST",
            url: "frmMantPreventa.aspx/ListarConcepto",
            data: "{'flag': '22'}",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                addSelectTipoDocumento(data.d);
            }
        });
    }
    ListarTipoDocumento();
    function addSelectTipoDocumento(data) {
        //DESCRIPCION : Funcion para llenar la lista de opciones del select del tipode documento.
        for (var i = 0; i < data.length; i++) {
            tipo_doc.append("<option value=" + data[i]["correlativo"] + ">" + data[i]["descripcion"] + "</option>");
        }
    }

    function ListarOrigenVenta() {
        //DESCRIPCION : Funcion que me trae la lista de tipo de origen de venta.
        $.ajax({
            type: "POST",
            url: "frmMantPreventa.aspx/ListarConcepto",
            data: "{'flag': '20'}",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                addSelectOrigenVenta(data.d);
            }
        });
    }
    ListarOrigenVenta();
    function addSelectOrigenVenta(data) {
        //DESCRIPCION : Funcion para llenar la lista de opciones del select del origen de venta.
        for (var i = 0; i < data.length; i++) {
            origen_venta.append("<option value=" + data[i]["correlativo"] + ">" + data[i]["descripcion"] + "</option>");
        }
    }

    function ListarVendedores() {
        //DESCRIPCION : Funcion que me trae la lista de vendedores.
        $.ajax({
            type: "POST",
            url: "frmMantPreventa.aspx/ListarCampos",
            data: "{'flag': '1' }",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                addSelectVendedor(data.d);
            }
        });
    }
    ListarVendedores();
    function addSelectVendedor(data) {
        //DESCRIPCION : Funcion para llenar la lista de opciones del select del Vendedor.
        for (var i = 0; i < data.length; i++) {
            vendedores.append("<option value=" + data[i]["codigo"] + ">" + data[i]["descripcion"] + "</option>");
        }

    }

    function ListarRutas() {
        //DESCRIPCION : Funcion que me trae la lista de rutas.
        $.ajax({
            type: "POST",
            url: "frmMantPreventa.aspx/ListarCampos",
            data: "{'flag': '3' }",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                addSelectRuta(data.d);
            }
        });

    }
    ListarRutas();
    function addSelectRuta(data) {
        //DESCRIPCION : Funcion para llenar la lista de opciones del select de rutas.
        for (var i = 0; i < data.length; i++) {
            ruta.append("<option value=" + data[i]["codigo"] + ">" + data[i]["descripcion"] + "</option>");
        }
    }

    $("#id_cliente").keyup(function () {
        var cad = $(this).val();
        if (cad.length === 0) {
            $("#id_codCliente").val("0");
        } else {
            buscarClienteNombre(cad);
        }

    });
    function buscarClienteNombre(cadena) {
        //DESCRIPCION: Listas los cientes con autocomplete
        $("#id_cliente").autocomplete({
            minLength: 2,
            autoFocus: true,
            source:
                function (request, response) {
                    $.ajax({
                        type: "POST",
                        url: "frmMantPreventa.aspx/buscarCliente",
                        data: JSON.stringify({ cadena: cadena }),
                        dataType: "json",
                        contentType: 'application/json; charset=utf-8',
                        error: function (xhr, ajaxOtions, thrownError) {
                            console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
                        },
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                var obj = new Object();
                                obj.label = item.nombres;
                                obj.value = item.nombres;
                                obj.codCliente = item.codCliente;
                                return obj;
                            }));
                        }
                    });
                },
            select: function (event, ui) {
                $("#id_cliente").val(ui.item.label);
                $("#id_codCliente").val(ui.item.codCliente);
            }
            , change: function (event, ui) {
                if (!ui.item) {
                    $("#id_cliente").val('');
                    $("#id_codCliente").val('0');
                }
            }
        });
    }

    $("#id_producto").keyup(function () {
        var cad = $(this).val();
        if (cad.length === 0) {
            $("#id_codProducto").val("");
        } else {
            buscarProductoNombre(cad);
        }

    });
    function buscarProductoNombre(cadena) {
        //DESCRIPCION: Listas los productos con autocomplete
        $("#id_producto").autocomplete({
            minLength: 2,
            source:
                function (request, response) {
                    $.ajax({
                        type: "POST",
                        url: "frmMantPreventa.aspx/ListarProductos_Sku",
                        data: JSON.stringify({ cadena: cadena }),
                        dataType: "json",
                        contentType: 'application/json; charset=utf-8',
                        error: function (xhr, ajaxOtions, thrownError) {
                            console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
                        },
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                var obj = new Object();
                                obj.label = item.codProducto + "  -  " + item.descripcion;
                                obj.value = item.codProducto + "  -  " + item.descripcion;
                                obj.codProducto = item.codProducto;
                                return obj;
                            }));
                        }
                    });
                },
            select: function (event, ui) {
                $("#id_producto").val(ui.item.label);
                $("#id_codProducto").val(ui.item.codProducto);
            }
            , change: function (event, ui) {
                if (!ui.item) {
                    $("#id_producto").val('');
                    $("#id_codProducto").val('');
                }
            }
        });
    }

    //------------------------------------------------------------------------------------------------------------------------------------
    function limpiarModalVer() {
        //Limpiar campos de la modal ver preventa
        MVvendedor.val("");
        MVcliente.val("");
        MVruta.val("");
        MVentrega.val("");
        MVpreventa.val("");
        MVfechar.val("");
        MVtventa.val("");
        MVfechae.val("");
        MVestado.val("");
        MVrecargo.val("");
        MVtotal.val("");
        MVoventa.val("");
        MVigv.val("");
        MVmoneda.val("");
        MVdescuento.val("");
        MVsubtotal.val("");
        desc_detalle.html("");
        promo_detalle.html("");
    }

    function descargarPdf(jason2, npre) {
        //DESCRIPCION : Funcion que me trae la lista de rutas.
        var nomPdf = "Rep_preventa_" + npre + ".pdf";
        $.ajax({
            type: "POST",
            url: "frmMantPreventa.aspx/crearPdf",
            data: jason2,
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                var bytes = new Uint8Array(data.d);
                enviarpdf(nomPdf, bytes);
            }
        });
    }

    function enviarpdf(nomPdf, datos) {
        var blob = new Blob([datos]);
        var link = document.createElement("a");
        link.href = window.URL.createObjectURL(blob);
        var fileName = nomPdf;
        link.download = fileName;
        link.click();
    }

    //VALIDACIONES -----------------------------------------------------------------------------------------------------------------------
    $(".fEvalidar").datepicker(
        {
            changeMonth: true,
            changeYear: true,
            weekHeader: 'Sm',
            monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
            monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
            dayNames: ['Domingo', 'Lunes', 'Martes', 'Mi&eacute;rcoles', 'Jueves', 'Viernes', 'S&aacute;bado'],
            dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mi&eacute;', 'Juv', 'Vie', 'S&aacute;b'],
            dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'S&aacute;'],
            dateFormat: 'dd/mm/yy',
            //showWeek: true,
            firstDay: 1,
            language: "es",
            showAnim: "show"
        }
    );
    function validarfechaE() {
        $('.fEvalidar').change(function () {
            var minE = fechaEntregaI.val();
            var maxE = fechaEntregaF.val();
            var expreFormato = /^(0[1-9]|[1-2]\d|3[01])(\/)(0[1-9]|1[012])\2(\d{4})$/;

            if ((minE !== "" && maxE !== "")) {
                if (!(expreFormato.test(minE.trim())) || !(expreFormato.test(maxE.trim()))) {
                    mensajeValFecha(msjFechaE, "Debe ingresar el formato valido (dd/mm/yyyy)");
                    fechaEntregaI.val("");
                    fechaEntregaF.val("");
                }
                else if ($.datepicker.parseDate('dd/mm/yy', maxE) < $.datepicker.parseDate('dd/mm/yy', minE)) {
                    mensajeValFecha(msjFechaE, "Fecha inicial debe ser menor a la fecha final");
                    fechaEntregaF.val("");
                }
            }
        });
    }
    validarfechaE();

    $(".fRvalidar").datepicker(
        {
            changeMonth: true,
            changeYear: true,
            weekHeader: 'Sm',
            monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
            monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
            dayNames: ['Domingo', 'Lunes', 'Martes', 'Mi&eacute;rcoles', 'Jueves', 'Viernes', 'S&aacute;bado'],
            dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mi&eacute;', 'Juv', 'Vie', 'S&aacute;b'],
            dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'S&aacute;'],
            dateFormat: 'dd/mm/yy',
            //showWeek: true,
            firstDay: 1,
            language: "es",
            showAnim: "show"
        }
    );
    function validarfechaR() {
        $('.fRvalidar').change(function () {
            var minR = fechaRegistroI.val();
            var maxR = fechaRegistroF.val();
            var expreFormato = /^(0[1-9]|[1-2]\d|3[01])(\/)(0[1-9]|1[012])\2(\d{4})$/;

            if ((minR !== "" && maxR !== "")) {
                if (!(expreFormato.test(minR.trim())) || !(expreFormato.test(maxR.trim()))) {
                    mensajeValFecha(msjFechaR, "Debe ingresar el formato valido (dd/mm/yyyy)");
                    fechaRegistroI.val("");
                    fechaRegistroF.val("");
                }
                else if ($.datepicker.parseDate('dd/mm/yy', maxR) < $.datepicker.parseDate('dd/mm/yy', minR)) {
                    mensajeValFecha(msjFechaR, "Fecha inicial debe ser menor a la fecha final");
                    fechaRegistroF.val("");
                }
            }
        });
    }
    validarfechaR();

    function mensajeValFecha(idmens, mensaje) {
        idmens.removeAttr("hidden");
        idmens.html("<h5>" + mensaje + "</h5>");
        idmens.css('height', '30px');
        idmens.css("color", "#ffffff");
        idmens.css("background-color", "#EC340F")
            .css("border-color", "#2e6da4");
        setTimeout(function () {
            idmens.attr("hidden", true);
        }, 3000);
    }

});

