$(document).ready(function () {
    //Lista de Variables para filtros
    var productoInput = $("#id_producto");
    var productoCod = $("#id_codProducto");
    var clienteInput = $("#id_cliente");
    var clienteCod = $("#id_codCliente");
    var vendedores = $(".id_vendedor");
    var estado = $("#id_estado");
    var fechaInicial = $("#id_fechaI");
    var fechaFinal = $("#id_fechaF");
    //Variables para registrar cabecera
    var id_fecha_vigI = $("#id_fecha_vigI");
    var id_fecha_vigF = $("#id_fecha_vigF");
    var id_horaI = $("#id_horaI");
    var id_horaF = $("#id_horaF");
    var id_activado = $("#id_activado");
    var id_desactivado = $("#id_desactivado");
    //Variables para registrar el descuento
    var id_Producto_reg = $("#id_Producto_reg");
    var id_codProducto_reg = $("#id_codProducto_reg");
    var id_unidadBase = $("#id_unidadBase");
    var id_cantidad = $("#id_cantidad");
    var id_monto = $("#id_monto");
    var id_tipoMonto = $("#id_tipoMonto");
    //Variables para registrar datos adicionales
    var id_vendedorReg = $("#id_vendedorReg");
    var id_ck_vendedor = $("#id_ck_vendedor");
    var id_cliente_reg = $("#id_cliente_reg");
    var id_codCliente_reg = $("#id_codCliente_reg");
    var id_ck_cliente = $("#id_ck_cliente");
    var id_veces_dec = $("#id_veces_dec");
    var id_ck_veces_desc = $("#id_ck_veces_desc");
    var id_veces_vend = $("#id_veces_vend");
    var id_ck_veces_vend = $("#id_ck_veces_vend");
    var id_veces_clie = $("#id_veces_clie");
    var id_ck_veces_clie = $("#id_ck_veces_clie");
    //Variables modal detalle
    var MDesDescuento = $("#MDesDescuento");
    var MDetalleVenedor = $("#MDetalleVenedor");
    var MDetalleCliente = $("#MDetalleCliente");
    var MDetalleDescuento = $("#MDetalleDescuento");
    var MNtra_descuento = $("#MNtra_descuento");
    var MEstado = $("#MEstado");
    var MFecha_Inicial = $("#MFecha_Inicial");
    var MFecha_Fin = $("#MFecha_Fin");
    var MHora_Inicio = $("#MHora_Inicio");
    var MHora_Fin = $("#MHora_Fin");
    var MProducto = $("#MProducto");
    var Munidad = $("#Munidad");
    var MCodPro = $("#MCodPro");
    //Variables modal editar
    var id_tituloDesc = $("#id_tituloDesc");
    // Variables adicionales
    var proceso = 0;
    var ntraDescuento = 0;
    var flagestado = 0;
    var msjFecha = $("#msjFecha");
    var msjFechaEdit = $("#msjFechaEdit");
    var msjHoraEdit = $("#msjHoraEdit");
    //Variables para Botones
    var btnAgregar = $("#btnAgregar");
    var btnBuscar = $("#btnBuscar");
    var btnRegistrar = $("#id_btnregistrar");
    var btnCancelar = $("#id_btncancelar");
    //Variables para botones
    var btnVer = ' <button type="button" title="Ver" class="icon-eye btnEye btnDetalle" data-toggle="modal"  data-target="#modalVer" ></button>';
    var btnEditar = ' <button type="button" title="Editar" class="icon-pencil btnEditar btnModificar" data-toggle="modal" data-target="#modalDescuento"></button>';
    var btnAnular = ' <button type="button" title="Activar/desactivar" class="icon-blocked btnBlocked btnAnular" data-toggle="modal" data-target="#modalAnular"></button>';
    //Variables para tablas
    var tbldescuento = $("#id_tblDescuento");



    btnAgregar.click(function () {
        limpiarReg_Edit();
        id_tituloDesc.html("REGISTRAR DESCUENTO");
        btnRegistrar.html("GUARDAR");
        ntraDescuento = 0;
        proceso = 1;
        id_Producto_reg.prop('disabled', false);
        id_unidadBase.prop('disabled', false);
    });

    function validarRegistroDescuento() {
        btnRegistrar.click(function () {

            var codTipoMonto = id_tipoMonto.find("option:selected").val();

            if (id_fecha_vigI.val() === "") {
                swal("Debe seleccionar la fecha inicial", {
                    icon: "error"
                });
            } else {
                if (id_fecha_vigF.val() === "") {
                    //event.preventDefault();
                    swal("Debe seleccionar la fecha final", {
                        icon: "error"
                    });
                } else {
                    if (id_horaI.val() === "") {
                        swal("Debe seleccionar la hora inicial", {
                            icon: "error"
                        });
                    } else {
                        if (id_horaF.val() === "") {
                            swal("Debe seleccionar la hora final", {
                                icon: "error"
                            });
                        } else {
                            if (id_Producto_reg.val() === "") {
                                //event.preventDefault();
                                swal("Debe seleccionar un producto", {
                                    icon: "error"
                                });
                            } else {
                                if (id_cantidad.val() === "") {
                                    //event.preventDefault();
                                    swal("Debe ingresar la cantidad", {
                                        icon: "error"
                                    });
                                } else {
                                    if (id_monto.val() === "") {
                                        //event.preventDefault();
                                        swal("Debe ingresar el descuento", {
                                            icon: "error"
                                        });
                                    } else {
                                        if (codTipoMonto === '0') {
                                            //event.preventDefault();
                                            swal("Debe ingresar el tipo de descuento", {
                                                icon: "error"
                                            });
                                        } else {
                                            obtnerDataRegistrar();
                                        }

                                    }
                                }
                            }
                        }
                    }

                }
            }
        });
    }
    validarRegistroDescuento();

    function obtnerDataRegistrar() {
        var codfecha_vigI = id_fecha_vigI.val();
        var codfecha_vigF = id_fecha_vigF.val();
        var codhoraI = id_horaI.val();
        var codhoraF = id_horaF.val();

        var cdoTipo_venta = 0;
        var codProducto = id_codProducto_reg.val();
        var codUnidadBase = id_unidadBase.find("option:selected").val();
        var codCantidad = id_cantidad.val();
        var codMonto = id_monto.val();
        var codTipoMonto = id_tipoMonto.find("option:selected").val();

        var tipoCant = codUnidadBase === '0' ? 2 : 1;

        var descripcion = "Por la compra de " + codCantidad + " " + id_unidadBase.find("option:selected").text() + " de " + id_Producto_reg.val() + " a mas, obtendra un descuento de " + codMonto + id_tipoMonto.find("option:selected").text();

        var codVendedorReg = id_vendedorReg.find("option:selected").val();

        var codCliente_reg = 0;
        if (id_codCliente_reg.val() === "") {
            codCliente_reg = 0;
        } else {
            codCliente_reg = id_codCliente_reg.val();
        }

        var cod_veces_dec = 0;
        if (id_veces_dec.val() === "") {
            cod_veces_dec = 0;
        } else {
            cod_veces_dec = id_veces_dec.val();
        }

        var cod_veces_vend = 0;
        if (id_veces_vend.val() === "") {
            cod_veces_vend = 0;
        } else {
            cod_veces_vend = id_veces_vend.val();
        }

        var cod_veces_clie = 0;
        if (id_veces_clie.val() === "") {
            cod_veces_clie = 0;
        } else {
            cod_veces_clie = id_veces_clie.val();
        }

        var jsonReg = JSON.stringify({
            datosDescuento: {
                proceso: proceso, descripcion: descripcion, fechaVigenciaI: codfecha_vigI, fechaVigenciaF: codfecha_vigF, horaI: codhoraI,
                horaF: codhoraF, flagestado: flagestado, cdoTipo_venta: cdoTipo_venta, codProducto: codProducto, codCantidad: codCantidad,
                tipoCant: tipoCant, codUnidadBase: codUnidadBase, codMonto: codMonto, codTipoMonto: codTipoMonto, codVendedorReg: codVendedorReg,
                codCliente_reg: codCliente_reg, cod_veces_dec: cod_veces_dec, cod_veces_vend: cod_veces_vend, cod_veces_clie: cod_veces_clie,
                ntraDescuento: ntraDescuento
            }
        });
        registrarEditarDescuento(jsonReg);
        //console.log(jsonReg);
    }
    //obtnerDataRegistrar();

    function registrarEditarDescuento(datos) {
        //DESCRIPCION : Funcion que me trae la lista de clientes -----------------------------------------------------------------
        $.ajax({
            type: "POST",
            url: "frmMantDescuento.aspx/registrarEditarDescuento",
            data: datos,
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                mostrarMensajeConfirmacion(data.d);
                //console.log(data.d);
            }
        });
    }

    function mostrarMensajeConfirmacion(respuesta) {        //@#cambio
        swal({
            title: respuesta.mensaje,
            text: "EL DESCUENTO CON CODIGO: " + respuesta.ntraDescuento,
            icon: "success"
        }).then((willDelete) => {
            if (willDelete) {
                btnBuscar.click();
                btnCancelar.click();
            }
        });
    }

    //Convertimos la tabla preventa en dataTable y le pasamos parametros
    tbldescuento.DataTable({
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
        order: [[3, "asc"]],
        columnDefs: [
            {
                "width": "10%",
                "targets": [0, 3, 4, 5, 6]
            },
            {
                "width": "15%",
                "targets": [1]
            },
            {
                "width": "35%",
                "targets": [2]
            },
            {
                "targets": [7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23],
                "visible": false,
                "searchable": false
            },
            {
                "className": "text-center", "targets": [3, 4]
            }
        ]
    });
    //creo variables despues de que el DataTable este creado en el DOM.
    var tabla = tbldescuento.dataTable(); //funcion jquery
    var table = tbldescuento.DataTable(); //funcion DataTable-libreria
    table.columns.adjust().draw();

    function enviarDatos() {
        //DECRIPCION: Obtener los datos de los filtros y enviarlos para listar los descuento
        btnBuscar.click(function () {

            if ((fechaInicial.val() !== "" && fechaFinal.val() === "") || (fechaInicial.val() === "" && fechaFinal.val() !== "")) {
                mensValFechaHora(msjFecha, "Debe completar las dos fechas");
            } else {
                var codProducto = productoCod.val();
                var codCliente = clienteCod.val();
                var codVendedor = vendedores.find("option:selected").val();
                var codEstado = estado.find("option:selected").val();
                var codFechaI = fechaInicial.val();
                var codFechaF = fechaFinal.val();
                var jsonData = JSON.stringify({
                    codProd: codProducto, codVendedor: codVendedor, codCliente: codCliente, codEstado: codEstado,
                    codFechaI: codFechaI, codFechaF: codFechaF
                });
                listarDescuentos(jsonData);
            }
        });

    }
    enviarDatos();

    function listarDescuentos(datos) {
        //DESCRIPCION: Obtener los descuentos de la base de datos
        $.ajax({
            type: "POST",
            url: "frmMantDescuento.aspx/ListarDescuento",
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
        //DECRIPCION: Llenar la tabla de descuentos
        var botones = btnVer + btnEditar + btnAnular;
        for (var i = 0; i < data.length; i++) {
            tabla.fnAddData([
                data[i].codProd,    //0
                data[i].desProd,
                data[i].descripcion,
                data[i].fechaInicial,
                data[i].fechaFin,
                data[i].desEstado,  //5
                botones,
                data[i].ntraDescuento,
                data[i].horaInicial,
                data[i].horaFin,
                data[i].codEstado,  //10
                data[i].codUnidad,
                data[i].desUnidad,
                data[i].cant,
                data[i].tipoCant,
                data[i].descuento,  //15
                data[i].tipodesc,
                data[i].codVen,
                data[i].vendedor,
                data[i].codCli,
                data[i].cliente,    //20
                data[i].vecesDes,
                data[i].vecesVen,
                data[i].vecesCli
            ]);
        }
    }
    $('body').on('click', '.btnAnular', function () {
        var tr3 = $(this).parent().parent();
        let ntraDesc = table.row(tr3).data()[7];
        let estadoAyD = table.row(tr3).data()[10] === 1 ? 2 : 1;
        cambiarEstado(ntraDesc, estadoAyD);

    });
    $('body').on('click', '.btnModificar', function () {
        limpiarReg_Edit();
        id_tituloDesc.html("EDITAR DESCUENTO");
        btnRegistrar.html("ACTUALIZAR");
        proceso = 2;

        var tr2 = $(this).parent().parent();

        ntraDescuento = table.row(tr2).data()[7];

        let estad = table.row(tr2).data()[10];
        if (estad === 1) {
            id_activado.click();
        } else {
            id_desactivado.click();
        }

        let fechI = table.row(tr2).data()[3];
        let fechF = table.row(tr2).data()[4];
        id_fecha_vigI.val(fechI);
        id_fecha_vigF.val(fechF);

        id_horaI.val(table.row(tr2).data()[8]);
        id_horaF.val(table.row(tr2).data()[9]);

        id_codProducto_reg.val(table.row(tr2).data()[0]);
        id_Producto_reg.val(table.row(tr2).data()[1]).prop('disabled', true);
        id_cantidad.val(table.row(tr2).data()[13]);

        let aux = table.row(tr2).data()[14];
        if (aux === 1) {
            var optionSelected = id_unidadBase.find("option");
            for (let i = 0; i < optionSelected.length; i++) {
                if (optionSelected[i].value !== '0') {
                    optionSelected[i].remove();
                }
            }
            id_unidadBase.append("<option value=" + table.row(tr2).data()[11] + ">" + table.row(tr2).data()[12] + "</option>");
            id_unidadBase.val(table.row(tr2).data()[11]).prop('disabled', true);
        } else {
            id_unidadBase.val('0').prop('disabled', true);
        }

        id_monto.val(table.row(tr2).data()[15]);
        id_tipoMonto.val(table.row(tr2).data()[16]);

        //verificar datos adicionañes vendedor
        let aux2 = table.row(tr2).data()[17];
        let aux3 = table.row(tr2).data()[22];
        if (aux2 !== 0) {
            id_ck_vendedor.click();
            id_vendedorReg.val(aux2);
            if (aux3 !== 0) {
                id_ck_veces_vend.click();
                id_veces_vend.val(aux3);
            }
        }
        //verificar datos adicionañes cliente
        let aux4 = table.row(tr2).data()[19];
        let aux5 = table.row(tr2).data()[23];
        if (aux4 !== 0) {
            id_ck_cliente.click();
            id_cliente_reg.val(table.row(tr2).data()[20]);
            id_codCliente_reg.val(aux4);
            if (aux5 !== 0) {
                id_ck_veces_clie.click();
                id_veces_clie.val(aux5);
            }
        }
        //verificar datos adicionales descuento
        let aux6 = table.row(tr2).data()[21];
        if (aux6 !== 0) {
            id_ck_veces_desc.click();
            id_veces_dec.val(aux6);
        }

    });
    $('body').on('click', '.btnDetalle', function () {
        limpiarModalDetalle();
        var tr = $(this).parent().parent();
        MNtra_descuento.val(table.row(tr).data()[7]);
        MEstado.val(table.row(tr).data()[5]);
        MFecha_Inicial.val(table.row(tr).data()[3]);
        MFecha_Fin.val(table.row(tr).data()[4]);
        MHora_Inicio.val(table.row(tr).data()[8]);
        MHora_Fin.val(table.row(tr).data()[9]);
        MProducto.val(table.row(tr).data()[1]);
        Munidad.val(table.row(tr).data()[12]);
        MDesDescuento.html(table.row(tr).data()[2]);
        MCodPro.val(table.row(tr).data()[0]);

        if (table.row(tr).data()[21] !== 0) {
            let msj = "El descuento puede utilizarse maximo " + table.row(tr).data()[21] + " veces ";
            MDetalleDescuento.html(msj);
        } else {
            MDetalleDescuento.html("No hay restricciones de descuento");
        }
        if (table.row(tr).data()[17] !== 0) {
            let msj1 = "El vendedor " + table.row(tr).data()[18] + " tiene acceso a este descuento ";
            if (table.row(tr).data()[22] !== 0) {
                msj1 = msj1 + " maximo " + table.row(tr).data()[22] + " veces";
            }
            MDetalleVenedor.html(msj1);
        } else {
            MDetalleVenedor.html("No hay restricciones de vendedor");
        }
        if (table.row(tr).data()[19] !== 0) {
            let msj2 = "El cliente " + table.row(tr).data()[20] + " tiene acceso a este descuento ";
            if (table.row(tr).data()[23] !== 0) {
                msj2 = msj2 + " maximo " + table.row(tr).data()[23] + " veces";
            }
            MDetalleCliente.html(msj2);
        } else {
            MDetalleCliente.html("No hay restricciones de cliente");
        }
    });

    function cambiarEstado(idDesc, nuevoEstado) {
        //DESCRIPCION : Funcion pra cambiar el estado del descuento
        $.ajax({
            type: "POST",
            url: "frmMantDescuento.aspx/cambiarEstado",
            data: "{'idDesc': '" + idDesc + "' , 'estado': '" + nuevoEstado + "'}",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                mensajeEstado(data.d);
            }
        });
    }
    function mensajeEstado(resp) {
        swal({
            title: resp.mensaje,
            text: "EL DESCUENTO CON CODIGO: " + resp.ntraDescuento,
            icon: "success"
        }).then((willDelete) => {
            if (willDelete) {
                btnBuscar.click();
            }
        });
    }

    function convertDateFormat(strFecha) {
        var info = strFecha.split('/');
        return info[2] + '-' + info[1] + '-' + info[0];
    }

    //LISTAR CAMPOS -----------------------------------------------------------------------------------------------------------------------
    clienteInput.keyup(function () {
        var cad = $(this).val();
        if (cad.length === 0) {
            clienteCod.val("0");
        } else {
            buscarClienteNombre(cad);
        }
    });
    function buscarClienteNombre(cadena) {
        //DESCRIPCION: Listas los cientes con autocomplete
        clienteInput.autocomplete({
            minLength: 2,
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
                clienteInput.val(ui.item.label);
                clienteCod.val(ui.item.codCliente);
            }
            , change: function (event, ui) {
                if (!ui.item) {
                    clienteInput.val('');
                    clienteCod.val('0');
                }
            }
        });
    }

    id_cliente_reg.keyup(function () {
        var cad = $(this).val();
        if (cad.length === 0) {
            id_codCliente_reg.val("0");
        } else {
            buscarClienteNombre2(cad);
        }
    });
    function buscarClienteNombre2(cadena) {
        //DESCRIPCION: Listas los cientes con autocomplete
        id_cliente_reg.autocomplete({
            minLength: 2,
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
                id_cliente_reg.val(ui.item.label);
                id_codCliente_reg.val(ui.item.codCliente);
            },
            appendTo: $("#modalDescuento"),
            change: function (event, ui) {
                if (!ui.item) {
                    id_cliente_reg.val('');
                    id_codCliente_reg.val('0');
                }
            }
        });
    }

    productoInput.keyup(function () {
        var cad = $(this).val();
        if (cad.length === 0) {
            productoCod.val("");
        } else {
            buscarProductoNombre(cad);
        }
    });
    function buscarProductoNombre(cadena) {
        //DESCRIPCION: Listas los productos con autocomplete
        productoInput.autocomplete({
            minLength: 2,
            source:
                function (request, response) {
                    $.ajax({
                        type: "POST",
                        url: "frmMantDescuento.aspx/ListarProductosTipo",
                        data: JSON.stringify({ cadena: cadena }),
                        dataType: "json",
                        contentType: 'application/json; charset=utf-8',
                        error: function (xhr, ajaxOtions, thrownError) {
                            console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
                        },
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                var obj = new Object();
                                obj.label = item.codigo + "  -  " + item.descripcion;
                                obj.value = item.codigo + "  -  " + item.descripcion;
                                obj.codigo = item.codigo;
                                return obj;
                            }));
                        }
                    });
                },
            select: function (event, ui) {
                productoInput.val(ui.item.label);
                productoCod.val(ui.item.codigo);
            }
            , change: function (event, ui) {
                if (!ui.item) {
                    productoInput.val('');
                    productoCod.val('');
                }
            }
        });
    }

    function limpiarDatosSeleccionProducto() {
        id_codProducto_reg.val("");
        var optionSelected = id_unidadBase.find("option");
        for (var i = 0; i < optionSelected.length; i++) {
            if (optionSelected[i].value !== '0') {
                optionSelected[i].remove();
            }
        }
    }

    id_Producto_reg.keyup(function () {
        var cad2 = $(this).val();
        if (cad2.length === 0) {
            limpiarDatosSeleccionProducto();
        } else {
            buscarProductoNombre2(cad2);
        }
    });
    function buscarProductoNombre2(cadena2) {
        //DESCRIPCION: Listas los productos con autocomplete
        id_Producto_reg.autocomplete({
            minLength: 2,
            source:
                function (request, response) {
                    $.ajax({
                        type: "POST",
                        url: "frmMantDescuento.aspx/ListarProductosTipo",
                        data: JSON.stringify({ cadena: cadena2 }),
                        dataType: "json",
                        contentType: 'application/json; charset=utf-8',
                        error: function (xhr, ajaxOtions, thrownError) {
                            console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
                        },
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                var obj = new Object();
                                obj.label = item.descripcion;
                                obj.value = item.descripcion;
                                obj.codigo = item.codigo;
                                return obj;
                            }));
                        }
                    });
                },
            select: function (event, ui) {
                id_Producto_reg.val(ui.item.label);
                id_codProducto_reg.val(ui.item.codigo);
                unidadBaseProducto(ui.item.codigo);
            },
            appendTo: $("#modalDescuento"),
            change: function (event, ui) {
                if (!ui.item) {
                    id_Producto_reg.val('');
                    id_codProducto_reg.val('');
                }
            }
        });
    }

    function cargarComboUnidades(data) {
        //DESCRIPCION : Funcion para llenar la lista de opciones del select unidades
        id_unidadBase.append("<option value=" + data.correlativo + ">" + data.descripcion + "</option>");
    }

    function unidadBaseProducto(codProducto) {
        console.log(codProducto);
        //DESCRIPCION : Funcion que me trae la lista de vendedores
        $.ajax({
            type: "POST",
            url: "frmMantDescuento.aspx/obtenerUnidadBaseProducto",
            data: "{'codProducto': '" + codProducto + "' }",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                console.log(data.d);
                cargarComboUnidades(data.d);
            }
        });
    }

    function ListarVendedores() {
        //DESCRIPCION : Funcion que me trae la lista de clientes -----------------------------------------------------------------
        $.ajax({
            type: "POST",
            url: "frmMantDescuento.aspx/ListarCoceptos",
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
        //DESCRIPCION : Funcion para llenar la lista de opciones del select de clientes.
        for (var i = 0; i < data.length; i++) {
            vendedores.append("<option value=" + data[i]["correlativo"] + ">" + data[i]["descripcion"] + "</option>");
        }

    }

    function ListarEstados() {
        //DESCRIPCION : Funcion que me trae la lista de clientes -----------------------------------------------------------------
        $.ajax({
            type: "POST",
            url: "frmMantDescuento.aspx/ListarEstado",
            data: "{'flag': '33' }",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                addSelectEstado(data.d);
            }
        });
    }
    ListarEstados();
    function addSelectEstado(data) {
        //DESCRIPCION : Funcion para llenar la lista de opciones del select de clientes.
        for (var i = 0; i < data.length; i++) {
            estado.append("<option value=" + data[i]["correlativo"] + ">" + data[i]["descripcion"] + "</option>");
        }

    }

    //VALIDACIONES -----------------------------------------------------------------------------------------------------------------------
    function limpiarReg_Edit() {
        id_fecha_vigI.val("").attr("readonly", true);
        id_fecha_vigF.val("").attr("readonly", true);
        id_horaI.val("08:00");
        id_horaF.val("20:00");
        id_activado.click();
        id_Producto_reg.val("");
        id_codProducto_reg.val("");
        id_cantidad.val("");
        id_monto.val("");
        id_tipoMonto.val("0");
        limpiarDatosSeleccionProducto();
        if (id_ck_veces_desc.is(':checked')) {
            id_ck_veces_desc.click();
        }
        if (id_ck_vendedor.is(':checked')) {
            id_ck_vendedor.click();
        }
        if (id_ck_cliente.is(':checked')) {
            id_ck_cliente.click();
        }
    }

    function limpiarModalDetalle() {
        //Limpiar campos de la modal ver descuento
        MDesDescuento.val("");
        MNtra_descuento.val("");
        MEstado.val("");
        MFecha_Inicial.val("");
        MFecha_Fin.val("");
        MHora_Inicio.val("");
        MHora_Fin.val("");
        MProducto.val("");
        Munidad.val("");
        MDesDescuento.html("");
        MDetalleVenedor.html("");
        MDetalleCliente.html("");
        MCodPro.val("");
    }

    function validarActivacion() {
        id_activado.click(function () {
            flagestado = 1;
        });
        id_desactivado.click(function () {
            flagestado = 2;
        });

        id_ck_veces_desc.click(function () {
            if ($(this).is(':checked')) {
                id_veces_dec.prop("disabled", false);
            } else {
                id_veces_dec.prop("disabled", true);
                id_veces_dec.val("");
            }
        });

        id_ck_vendedor.click(function () {
            if ($(this).is(':checked')) {
                id_vendedorReg.prop("disabled", false);
                id_ck_veces_vend.attr("disabled", false);

            } else {
                id_vendedorReg.val('0');
                id_vendedorReg.prop("disabled", true);
                if (id_ck_veces_vend.is(':checked')) {
                    id_ck_veces_vend.click();
                }
                id_ck_veces_vend.attr("disabled", true);
            }
        });
        id_ck_veces_vend.click(function () {
            if ($(this).is(':checked')) {
                id_veces_vend.prop("disabled", false);
            } else {
                id_veces_vend.val("");
                id_veces_vend.prop("disabled", true);
            }
        });

        id_ck_cliente.click(function () {
            if ($(this).is(':checked')) {
                id_cliente_reg.prop("disabled", false);
                id_ck_veces_clie.attr("disabled", false);
            } else {
                id_cliente_reg.val("");
                id_codCliente_reg.val("");
                id_cliente_reg.prop("disabled", true);
                if (id_ck_veces_clie.is(':checked')) {
                    id_ck_veces_clie.click();
                }
                id_ck_veces_clie.attr("disabled", true);
            }
        });
        id_ck_veces_clie.click(function () {
            if ($(this).is(':checked')) {
                id_veces_clie.prop("disabled", false);
            } else {
                id_veces_clie.val("");
                id_veces_clie.prop("disabled", true);
            }
        });
    }
    validarActivacion();

    $(".fvalidar").datepicker(
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
            language: "es",
            showAnim: "show"
        }
    );
    function validarfecha() {
        $('.fvalidar').change(function () {
            var minR = fechaInicial.val();
            var maxR = fechaFinal.val();
            var expreFormato = /^(0[1-9]|[1-2]\d|3[01])(\/)(0[1-9]|1[012])\2(\d{4})$/;
            if ((minR !== "" && maxR !== "")) {
                if (!(expreFormato.test(minR.trim())) || !(expreFormato.test(maxR.trim()))) {
                    mensValFechaHora(msjFecha, "Debe ingresar el formato valido (dd/mm/yyyy)");
                    fechaInicial.val("");
                    fechaFinal.val("");
                }
                else if ($.datepicker.parseDate('dd/mm/yy', maxR) < $.datepicker.parseDate('dd/mm/yy', minR)) {
                    mensValFechaHora(msjFecha, "Fecha inicial debe ser menor a la fecha final");
                    fechaFinal.val("");
                }
            }
        });
    }
    validarfecha();

    $('.fvalidarEdit').datepicker({
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
        showAnim: "show",
        minDate: 0
    });
    function valfechaEdit() {
        $('.fvalidarEdit').change(function () {
            var minR = id_fecha_vigI.val();
            var maxR = id_fecha_vigF.val();
            var expreFormato = /^(0[1-9]|[1-2]\d|3[01])(\/)(0[1-9]|1[012])\2(\d{4})$/;
            if ((minR !== "" && maxR !== "")) {
                if (!(expreFormato.test(minR.trim())) || !(expreFormato.test(maxR.trim()))) {
                    mensValFechaHora(msjFechaEdit, "Debe ingresar el formato valido (dd/mm/yyyy)");
                    id_fecha_vigI.val("");
                    id_fecha_vigF.val("");
                }
                else if ($.datepicker.parseDate('dd/mm/yy', maxR) < $.datepicker.parseDate('dd/mm/yy', minR)) {
                    mensValFechaHora(msjFechaEdit, "Fecha inicial debe ser menor a la fecha final");
                    id_fecha_vigF.val("");
                }
            }
        });
    }
    valfechaEdit();

    function valhoraEdit() {
        $('.hvalidarEdit').blur(function () {
            var minR = id_horaI.val();
            var maxR = id_horaF.val();
            if ((minR !== "" && maxR !== "") && (maxR < minR)) {
                mensValFechaHora(msjHoraEdit, "Hora inicial debe ser menor a la hora final");
                //id_horaI.val("");
                id_horaF.val("");
                //id_horaI.focus();
            }
        });
    }
    valhoraEdit();

    function mensValFechaHora(idmens, mensaje) {
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

    function validarCamposNum() {
        id_cantidad.change(function () {
            if (id_cantidad.val() < 1) {
                id_cantidad.val("");
            }
        });
        id_monto.change(function () {
            if (id_monto.val() < 1) {
                id_monto.val("");
            }
        });
        id_veces_dec.change(function () {
            if (id_veces_dec.val() < 1) {
                id_veces_dec.val("");
            }
        });
        id_veces_vend.change(function () {
            if (id_veces_vend.val() < 1) {
                id_veces_vend.val("");
            }
        });
        id_veces_clie.change(function () {
            if (id_veces_clie.val() < 1) {
                id_veces_clie.val("");
            }
        });
    }
    validarCamposNum();

});

