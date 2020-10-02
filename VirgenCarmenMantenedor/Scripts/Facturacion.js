$(document).ready(function () {
    //Campos principales
    var sumaDescuento = 0;
    $(".ocultar").hide();
    var mdVendedor = $("#mdVendedor");
    var nombreCliente = $("#mdCliente");
    var codigo;
    var modalPago = $('#modalFiltroFactura');
    modalPago.modal('show');
    //modalPago.modal({ backdrop: 'static', keyboard: false })
    //Campos de los parametros de filtro
    var preventaCod = $("#mdCodigo");
    var clienteCod = $("#mdcodCliente");
    var clienteCodForm = $("#codCliente"); //Codigo de cliente
    var fechaRegistroI = $("#mdmin-date");
    var fechaRegistroF = $("#mdmax-date");
    var fechaPago = $("#fecCompromiso");//fecha de pago
    var vendedorCod = $("#codVendedor");//Codigo de vendedor
    var tipMoneda = $("#tipMoneda"); //tipo de moneda
    var montoRecargo = $("#montoRecargo"); //Recargo
    var montoIGV = $("#montoIGV"); //IGV
    var montoTotal = $("#montoTotal"); //Total
    var montoSubTotal = $("#montoSubtotal"); //SubTotal
    var codSucursal = $("#codSucursal"); // sucursal
    var montoDescuento = $("#montoDescuento"); //Monto total de descuento
    var codDocVenta = $("#codDocVenta"); //tipo de documento de venta
    var codPuntoEntrega = $("#codPuntoEntrega"); // codigo de punto de entrega
    var btnSeleccionar = ' <button type="button" title="Seleccionar" class="icon-checkmark btnCheck" data-toggle="modal"  data-target="#modalVer" ></button>'

    var idDateTable = $("#idDateTablPreventasModal");
    var idDateTableProd = $("#idDateTablProducto");
    var codtipVenta = $("#codTipVenta");
    //Convertimos la tabla en dataTable y le pasamos parametros
    idDateTable.DataTable({
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
            },

        },
        order: [[0, "desc"]],
        columnDefs: [

            {
                "targets": [5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20],
                "visible": false,
                "searchable": false
            }
        ]
    });

    idDateTableProd.DataTable({
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
            },

        },

        columnDefs: [

            {
                "className": "text-center", "targets": [2]
            },
            {
                "className": "text-right", "targets": [5, 6, 7]
            }
        ]
    });

    //TABLA MODAL creo variables despues de que el DataTable este creado en el DOM.
    var tablaModal = $("#idDateTablPreventasModal").dataTable(); //funcion jquery
    var tableModal = $("#idDateTablPreventasModal").DataTable(); //funcion DataTable-libreria
    tableModal.columns.adjust().draw();

    //TABLA LISTA DE PRODUCTOS 
    var tablaProd = $("#idDateTablProducto").dataTable(); //funcion jquery
    var tableProd = $("#idDateTablProducto").DataTable(); //funcion DataTable-libreria
    tableProd.columns.adjust().draw();

    function EnviarDatosParametros() {
        //DESCRIPCION : Funcion para enviar los datos de los filtros.
        var codPreventa = preventaCod.val();
        var codCliente = clienteCod.val();
        var codVendedor = mdVendedor.find("option:selected").val();
        var codFechaI = fechaRegistroI.val();
        var codFechaF = fechaRegistroF.val();

        if (nombreCliente.val().trim().length == 0) {
            codCliente = "";
        }

        var json = JSON.stringify({
            codPreventa: codPreventa, codCliente: codCliente, codVendedor: codVendedor, codFechaI: codFechaI,
            codFechaF: codFechaF
        });
        ListarPreventas(json);
    }

    function ListarPreventas(datos) {
        //DESCRIPCION : Funcion que me trae la lista de preventas
        $.ajax({
            type: "POST",
            url: "frmRegistroVenta.aspx/ListarPreventa",
            data: datos,
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                //console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                tableModal.clear().draw();
                llenarTablaModal(data.d);
            }
        });
    }

    function llenarTablaModal(data) {
        //DESCRIPCION : Funcion para llenar la tabla de preventas
        for (var i = 0; i < data.length; i++) {
            tablaModal.fnAddData([
                data[i].ntraPreventa,
                data[i].cliente,
                data[i].vendedor,
                data[i].total.toFixed(2),
                btnSeleccionar,
                data[i].tipoMoneda,
                data[i].moneda,
                data[i].codUsuario,
                data[i].vendedor,
                data[i].codCliente,
                data[i].cliente,
                data[i].tVenta,
                data[i].tDoc,
                data[i].fechaEntrega,
                data[i].recargo,
                data[i].igv,
                data[i].total,
                data[i].tipoVenta,
                data[i].ntraSucursal,
                data[i].tipoDocumentoVenta,
                data[i].codPuntoEntrega
            ]);
        }



    }

    $("body").on('click', '.btnCheck', function () {
        //limpiarModalVer();
        var tr = $(this).parent().parent();
        //var npre = tableModal.row(tr).data()[0];
        $("#codPreventa").val(tableModal.row(tr).data()[0]);
        $("#tipMoneda").val(tableModal.row(tr).data()[5]);
        $("#descMoneda").val(tableModal.row(tr).data()[6]);
        $("#fechaEntrega").val(tableModal.row(tr).data()[13]);
        $("#tipVenta").val(tableModal.row(tr).data()[11]);
        $("#docVenta").val(tableModal.row(tr).data()[12]);
        $("#nomCliente").val(tableModal.row(tr).data()[10]);
        $("#nomVendedor").val(tableModal.row(tr).data()[8]);
        $("#codCliente").val(tableModal.row(tr).data()[9]);
        $("#codVendedor").val(tableModal.row(tr).data()[7]);
        $("#codTipVenta").val(tableModal.row(tr).data()[17]);
        montoRecargo.val((tableModal.row(tr).data()[14]).toFixed(2));
        montoIGV.val((tableModal.row(tr).data()[15]).toFixed(2));
        montoTotal.val((tableModal.row(tr).data()[16]).toFixed(2));
        montoSubTotal.val((tableModal.row(tr).data()[16] - tableModal.row(tr).data()[15]).toFixed(2));
        codSucursal.val(tableModal.row(tr).data()[18]);
        codDocVenta.val(tableModal.row(tr).data()[19]);
        codPuntoEntrega.val(tableModal.row(tr).data()[20]);
        if (tableModal.row(tr).data()[17] == 1) {
            //boleta
            fechaPago.val(tableModal.row(tr).data()[13]);
            // $('#groupFechaPago').hide();
            // $('#groupFechaContraE').show();
        } else if (tableModal.row(tr).data()[17] == 2) {
            //factura
            // $('#groupFechaPago').show();
            // $('#groupFechaContraE').hide();
        }
        //Buscar productos
        detalle_productos_preventa(tableModal.row(tr).data()[0]);
        //recargar productos

        modalPago.modal('hide');

    });


    function detalle_productos_preventa(npre) {
        //DESCRIPCION : Funcion que me trae la lista del detalle de la preventa por codigo de preventa
        $.ajax({
            type: "POST",
            url: "frmRegistroVenta.aspx/ListarDetalleProductos",
            data: "{'npre': '" + npre + "'}",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                //console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                tableProd.clear().draw();
                llenarTablaSeleccionar(data.d);
            }
        });
    }

    function llenarTablaSeleccionar(data) {
        //DESCRIPCION : Funcion para llenar la tabla de producto
        for (var i = 0; i < data.length; i++) {
            tablaProd.fnAddData([
                data[i].codProducto,
                data[i].descripcion,
                data[i].cantidad,
                data[i].um,
                data[i].tipo,
                data[i].descuento.toFixed(2),
                data[i].precio.toFixed(2),
                (data[i].precio * data[i].cantidadUnidadBase - data[i].descuento).toFixed(2)


            ]);
            sumaDescuento = sumaDescuento + data[i].descuento;

        }
        montoDescuento.val(sumaDescuento.toFixed(2));


    }



    $("#mdmin-date").datepicker(
        {
            changeMonth: true,
            changeYear: true,
            monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio',
                'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'
            ],
            monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun',
                'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'
            ],
            dayNames: ['Domingo', 'Lunes', 'Martes', 'Mi&eacute;rcoles', 'Jueves', 'Viernes', 'S&aacute;bado'],
            dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mi&eacute;', 'Juv', 'Vie', 'S&aacute;b'],
            dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'S&aacute;'],
            weekHeader: 'Sm',
            dateFormat: 'dd/mm/yy',
            //showOn: "button",
            // buttonImage: "Imagenes/calendar.gif",
            // buttonImageOnly: true,
            //buttonText: "Select date",
            language: "es"

        }
    );

    $("#mdmax-date").datepicker(
        {
            changeMonth: true,
            changeYear: true,
            monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio',
                'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'
            ],
            monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun',
                'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'
            ],
            dayNames: ['Domingo', 'Lunes', 'Martes', 'Mi&eacute;rcoles', 'Jueves', 'Viernes', 'S&aacute;bado'],
            dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mi&eacute;', 'Juv', 'Vie', 'S&aacute;b'],
            dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'S&aacute;'],
            weekHeader: 'Sm',
            dateFormat: 'dd/mm/yy',
            // showOn: "button",
            //buttonImage: "Imagenes/calendar.gif",
            //buttonImageOnly: true,
            //buttonText: "Select date",
            language: "es"

        }
    );

    $("#fecCompromiso").datepicker(
        {
            changeMonth: true,
            changeYear: true,
            monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio',
                'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'
            ],
            monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun',
                'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'
            ],
            dayNames: ['Domingo', 'Lunes', 'Martes', 'Mi&eacute;rcoles', 'Jueves', 'Viernes', 'S&aacute;bado'],
            dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mi&eacute;', 'Juv', 'Vie', 'S&aacute;b'],
            dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'S&aacute;'],
            weekHeader: 'Sm',
            dateFormat: 'dd/mm/yy',
            language: "es",
            minDate: '0D'//,
            //maxDate: '+30D'//,
            //yearRange: '-100',

        }
    );



    $('.date-range-filter').change(function () {
        var min = $('#min-date').val();
        var max = $('#max-date').val();
        if ((min != "" && max != "") && (max < min)) {
            MmensajeOrdenFecha.css('opacity', '1')
                .css('height', '40px');
            setTimeout(function () {
                MmensajeOrdenFecha.css('opacity', '0');
            }, 2000);
            setTimeout(function () {
                MmensajeOrdenFecha.css('height', '0px')
            }, 4000)
        } else {
            table.draw();
        }

    });

    //LISTA DE VENDEDOR
    function addSelectVendedor(data) {
        //DESCRIPCION : Funcion para llenar la lista de opciones del select del Vendedor.
        for (var i = 0; i < data.length; i++) {
            mdVendedor.append("<option value=" + data[i]["ntraUsuario"] + ">" + data[i]["vendedor"] + "</option>");
        }

    }

    //LLAMANDO A LA FUNCIO NDE AJAX VENDEDORES
    function ListarVendedores() {
        //DESCRIPCION : Funcion que me trae la lista de vendedores
        $.ajax({
            type: "POST",
            url: "frmRegistroVenta.aspx/ListarVendedores",
            data: "{'flag': '1' }",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                addSelectVendedor(data.d);
            }
        })

    }
    ListarVendedores();

    //FILTRO DE CLIENTE
    $("#mdCliente").keyup(function (event) {
        codigo = $("#mdCliente").val();
        /*
        if (codigo.length == 0) {
            $("#mdCliente").val("");
        } else {
            buscarClienteNombre(codigo);
        }*/
        buscarClienteNombre(codigo);
    });

    function buscarClienteNombre(cadena) {
        $("#mdCliente").autocomplete({
            minLength: 2,
            //delay: 500,
            source:
                function (request, response) {
                    $.ajax({
                        type: "POST",
                        url: "frmRegistroVenta.aspx/buscarCliente",
                        data: "{'cadena': '" + cadena + "' }",
                        contentType: 'application/json; charset=utf-8',
                        error: function (xhr, ajaxOtions, thrownError) {
                            // console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
                        },
                        success: function (data) {
                            //console.log("data: " + data);
                            response($.map(data.d, function (item) {
                                //console.log("data: " + item.nombres);
                                var obj = new Object();
                                obj.label = item.nombres;
                                obj.value = item.nombres;
                                obj.numDocumento = item.numDocumento;
                                //obj.tipoListaPrecio = item.tipoListaPrecio;
                                obj.codCliente = item.codCliente;
                                //obj.numDocumento = item.numDocumento;
                                return obj;
                                //return item.nombres;
                                /*return {
                                    label: item.nombres,
                                    value: item.codCliente
                                };*/
                            }));
                        }

                    });
                },
            select: function (event, ui) {
                //alert(ui.item.value);
                $("#mdcodCliente").val(ui.item.codCliente);
                $("#mdCliente").val(ui.item.value);
                //$("#id_tipoListaPrecio").val(ui.item.tipoListaPrecio);
                //$("#id_codCliente").val(ui.item.codCliente);

                //limpiar combo (dejando el seleccionar)
                /*
                var optionSelected = puntosEntrega.find("option");
                for (var i = 0; i < optionSelected.length; i++) {
                    if (optionSelected[i].value != 0) {
                        optionSelected[i].remove();
                    }
                }

                listarPuntosEntrega(ui.item.codCliente)
                */
            }
        });
        $(".addresspicker").autocomplete("option", "appendTo", ".frmBuscarPreventa");
    }

    $('#btnBuscarPreventa').on("click", function () {
        EnviarDatosParametros();
    });

    EnviarDatosParametros();

    //REGISTRAR VENTA

    $('#btnGuardarVenta').on("click", function () {
        if (validarCamposRegistro()) {
            EnviarDatosVenta();
        }

    });
    function validarCamposRegistro() {
        var divFechaPago = $("#valFecha");

        if (fechaPago.val().trim().length == 0) {
            divFechaPago.show();
            divFechaPago.html("<h5>Debe ingresar una fecha</h5>");
            divFechaPago.css("color", "#ffffff");
            divFechaPago.css("background-color", "#EC340F")
                .css("border-color", "#2e6da4");
            setTimeout(function () {
                divFechaPago.hide();
            }, 3000);
            return false;
        }
        if (fechaPago.val().trim().length != 10) {
            divFechaPago.show();
            divFechaPago.html("<h5>Fecha incorrecta </h5>");
            divFechaPago.css("color", "#ffffff");
            divFechaPago.css("background-color", "#EC340F")
                .css("border-color", "#2e6da4");
            setTimeout(function () {
                divFechaPago.hide();
            }, 3000);
            fechaPago.val("");
            return false;
        }
        var vregexNaix = /^(0[1-9]|[1-2]\d|3[01])(\/)(0[1-9]|1[012])\2(\d{4})$/;
        if (!(vregexNaix.test(fechaPago.val().trim()))) {
            divFechaPago.show();
            divFechaPago.html("<h5>Formato incorrecto de fecha </h5>");
            divFechaPago.css("color", "#ffffff");
            divFechaPago.css("background-color", "#EC340F")
                .css("border-color", "#2e6da4");
            setTimeout(function () {
                divFechaPago.hide();
            }, 3000);
            fechaPago.val("");
            return false;
        }


        return true;
    }

    function validarfechaR() {
        $('.fRvalidar').change(function () {
            var minR = fechaRegistroI.val();
            var maxR = fechaRegistroF.val();
            if ((minR !== "" && maxR !== "") && (maxR < minR)) {
                msjFechaR.removeAttr("hidden");
                msjFechaR.html("<h5>Fecha de registro inicial  debe ser menor a la fecha registro final</h5>");
                msjFechaR.css('height', '30px');
                msjFechaR.css("color", "#ffffff");
                msjFechaR.css("background-color", "#EC340F")
                    .css("border-color", "#2e6da4");
                setTimeout(function () {
                    msjFechaR.attr("hidden", true);
                }, 3000);
                fechaRegistroI.val("");
                fechaRegistroF.val("");
                fechaRegistroI.focus();
            }
        });

    }


    function EnviarDatosVenta() {
        //DESCRIPCION : Funcion para enviar los datos de los filtros.
        var codPreventa = $("#codPreventa").val();
        var codCliente = clienteCodForm.val();
        var codVendedor = vendedorCod.val();
        var fechPag = fechaPago.val();
        var tipoVenta = codtipVenta.val();
        var tipoMoneda = tipMoneda.val();
        var recargo = montoRecargo.val();
        var IGV = montoIGV.val();
        var total = montoTotal.val();
        var sucursal = codSucursal.val();
        var tipoDocumentoVenta = codDocVenta.val();
        var codPuntoEnt = codPuntoEntrega.val();
        var json = JSON.stringify({
            codPreventa: codPreventa, codCliente: codCliente, codVendedor: codVendedor, fechPag: fechPag,
            tipoVenta: tipoVenta, tipoMoneda: tipoMoneda, recargo: recargo, IGV: IGV, total: total, sucursal: sucursal,
            tipoDocumentoVenta: tipoDocumentoVenta, codPuntoEntrega: codPuntoEnt
        });

        RegistrarVenta(json);
    }

    function RegistrarVenta(datos) {
        //DESCRIPCION : Funcion que me trae la lista de preventas
        $.ajax({
            type: "POST",
            url: "frmRegistroVenta.aspx/RegistrarVenta",
            data: datos,
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                mostrarMensajeError("HUBO UN ERROR AL CARGAR LOS DATOS DE LA PREVENTA. INTENTELO EN UNOS MOMENTOS");;
            },
            success: function (data) {
                if (data.d.flag == 0) {
                    //mostrarMensajeConfirmacion(data.d.msje);
                    mostrarOpcionCorrectoVenta(data.d.msje, data.d.venta)
                } else {
                    //Hubo un error
                    mostrarMensajeError(data.d.msje);
                }
            }
        });
    }

    function mostrarOpcionCorrectoVenta(mensaje, codigo) {
        swal({
            title: mensaje,
            text: "¿Desea descargar la venta realizada?",
            icon: "success",
            showCancelButton: true,
            buttons: true,
            dangerMode: true,
            cancelButtonText: "Cancelar",
            confirmButtonText: "Aceptar"
        })
            //Promesa que me trae el valor true al confirmar OK.
            .then((willDelete) => {
                if (willDelete) {
                    descargarPdfVenta(codigo);
                    swal("Venta descargada", {
                        icon: "success",
                    });
                    //descargarPdfVenta(codigo);
                    //sleep(2000);

                } else {
                    swal("Venta finalizada");
                    //location.reload();
                    LimpiarVenta();
                    modalPago.modal('show');
                }
            });
        $(".swal-button.swal-button--confirm.swal-button--danger").html("Descargar");
        $(".swal-button.swal-button--cancel").html("Finalizar");
    }

    function descargarPdfVenta(codigo) {
        //DESCRIPCION : Funcion que me trae la lista de rutas.
        var nomPdf = "Venta_" + codigo + ".pdf";
        $.ajax({
            type: "POST",
            url: "frmMantDetalleFactura.aspx/generarVentaPdf",
            data: "{'codigo': '" + codigo + "'}",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                var bytes = new Uint8Array(data.d);
                enviarpdf(nomPdf, bytes);
                //Limpiar campos
                LimpiarVenta();
                modalPago.modal('show');

            }
        });
    }
    function LimpiarVenta() {
        $("#codPreventa").val("");
        clienteCodForm.val("");
        vendedorCod.val("");
        fechaPago.val("");
        codtipVenta.val("");
        tipMoneda.val("");
        montoRecargo.val("");
        montoIGV.val("");
        montoTotal.val("");
        codSucursal.val("");
        codDocVenta.val("");
        codPuntoEntrega.val("");
        tableProd.clear().draw();
        montoDescuento.val("");
        preventaCod.val("");
        clienteCod.val("");
        //$("#mdVendedor option[value=0").attr("selected", true);
        //mdVendedor.find('select option:eq(0)').prop('selected', true);
        //mdVendedor.find("option:selected").val();
        fechaRegistroI.val("");
        fechaRegistroF.val("");

        $("#codPreventa").val("");
        $("#tipMoneda").val("");
        $("#descMoneda").val("");
        $("#fechaEntrega").val("");
        $("#tipVenta").val("");
        $("#docVenta").val("");
        $("#nomCliente").val("");
        $("#nomVendedor").val("");
        $("#codCliente").val("");
        $("#codVendedor").val("");
        $("#codTipVenta").val("");
        montoSubTotal.val("");
        nombreCliente.val("");
        EnviarDatosParametros();
    }
    function enviarpdf(nomPdf, datos) {
        var blob = new Blob([datos]);
        var link = document.createElement("a");
        link.href = window.URL.createObjectURL(blob);
        var fileName = nomPdf;
        link.download = fileName;
        link.click();
    }

    function mostrarMensajeConfirmacion(mensaje) {
        swal("Operación exitosa", mensaje, "success").then((willDelete) => {
            if (willDelete) {
                //vendedores.focus();
                location.reload();
            }
        });
    }

    function mostrarMensajeError(mensaje) {
        swal("Error en la Operación", mensaje, "error").then((willDelete) => {
            if (willDelete) {
                //vendedores.focus();
                //location.reload();
            }
        });
    }


});