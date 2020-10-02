$(document).ready(function () {
    var modalPago = $('#exampleModal').modal({ backdrop: 'static', keyboard: false });
    modalPago.modal('show');

    var m_fechafin = $("#id_fechafin_m");
    var m_fechainicio = $("#id_fechainicio_m");
    var m_cliente = $("#id_cliente_m");
    var m_codcliente = $("#id_codcliente_m");
    var m_vendedores = $("#id_vendedor_m");
    var m_codventa = $("#id_codigoventa_m");
    var m_serie = $("#id_serie_m");
    var m_numero = $("#id_numero_m");
    var m_btnNotaCredito = ' <button type="button" id="" class="icon-checkmark btnCheck" data-toggle="tooltip"  title="AplicarNC" ></button>' //data-dismiss="modal"
    var m_arr_ventas = new Array();
    var btncancelar_m = $("#btncancelar_m");

    //VARIABLES MODAL EDIT PRODUCTO
    var modalEditarProducto = $('#ModalEditProduct')
    var mp_cantidad = $("#id_cantidad_m_p");
    var mp_cant_original = $("#id_original_m_p");
    var mp_btnguardar = $("#id_btnguardar_m_p");
    var mp_producto = $("#id_producto_m_p");

    //VARIABLES NOTA CREDITO
    var tipoVenta = 0;
    var id_codventa = $("#id_codventa");
    var id_tipocambio = $("#id_tipocambio");
    var id_serie = $("#id_serie");
    var id_numero = $("#id_numero");
    var id_cliente = $("#id_cliente");
    var id_vendedor = $("#id_vendedor");
    var id_total = $("#id_total");
    var id_recargo = $("#id_recargo");
    var id_descuento = $("#id_descuento");
    var id_subtotal = $("#id_subtotal");
    var id_igv = $("#id_igv");
    var id_motivo = $("#id_motivo");
    var id_importe = $("#id_importe");

    var arr_detalle_venta = new Array();
    var arr_detalle_salvado = new Array();
    var arr_backup = new Array();
    var btnEliminar = ' <button type="button" id="" class="icon-bin btnDelete" data-toggle="tooltip"  title="Eliminar" disabled></button>'
    var btnEditar = '<button type="button" title="Editar" class="icon-pencil btnEditar" data-toggle="modal"  data-target="#ModalEditProduct" disabled></button>'
    var arr_venta_promo = new Array();
    var arr_venta_promo_salvado = new Array();
    var arr_venta_descu = new Array();
    var arr_venta_descu_salvado = new Array();
    var ntraUsuario = 0;
    var ntraSucursal = 0;
    var nombreUsuario = "";
    var p_flag_recargo = 0;
    //var p_igv = 0.0;
    var p_porcentaje_recargo = 0.0;

    var items = 0;

    //VARIABLES DE IMPORTE
    var i_importe = 0;
    var i_total_original = 0;
    //var i_descuento_original = 0;
    var i_total_salvado = 0;
    var i_total = 0;
    var i_recargo = 0;
    var i_igv = 0;
    var i_subtotal = 0;
    var i_descuento = 0;

    //PARAMETROS
    var p_igv = 0;

    function addComboMotivosNC(data) {
        for (var i = 0; i < data.length; i++) {
            id_motivo.append("<option value=" + data[i]["codigoMotivo"] + ">" + data[i]["descripcion"] + "</option>");
        }
    }

    function listarMotivosNC() {
        $.ajax({
            type: "POST",
            url: "frmNotaCredito.aspx/obtenerMotivosNC",
            data: "{}",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                addComboMotivosNC(data.d);
            }
        })
    }
    listarMotivosNC();

    // PARAMETROS
    function obtenerParametrosPreventa() {
        $.ajax({
            type: "POST",
            url: "registrarpreventa.aspx/obtenerParametrosPreventa",
            data: "{}",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                //p_flag_recargo = data.d.flagRecargo;
                p_porcentaje_recargo = data.d.porcentajeRecargo;
                //p_igv = data.d.igv;
            }
        })
    }
    obtenerParametrosPreventa();

    function obtenerParametros(flag, sucursal) {
        $.ajax({
            type: "POST",
            url: "frmNotaCredito.aspx/obtenerParametros",
            data: "{'parametros':{'flag':'" + flag + "', 'codSucursal':'" + sucursal + "'}}",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                p_igv = data.d.igv;
            }
        })
    }

    function obtenerUsuario() {
        $.ajax({
            type: "POST",
            url: "login.aspx/getSession",
            data: "{}",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                ntraUsuario = data.d[0].ntraUsuario;
                ntraSucursal = data.d[0].sucursal;
                nombreUsuario = data.d[0].nombre;
                obtenerParametros(2, ntraSucursal);
            }
        })
    }
    obtenerUsuario();
    //

    // MODAL INICIO #######################################################################

    function cancelarProceso() {
        btncancelar_m.click(function () {
            $("#btnCancelar").prop("disabled", true);
            $("#btnGuardar").prop("disabled", true);
            $("#id_motivo").prop("disabled", true);
            modalPago.modal('hide');
        });
    }
    cancelarProceso();

    $('#id_venta_m').DataTable({
        //paging: false,
        ordering: false,
        info: false,
        searching: false,
        language: {
            lengthMenu: "Mostrar _MENU_ registros",
            zeroRecords: "No hay ventas encontradas",
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
            //nextText: "Siguiente",
            //prevText: "Anterior"
        }/*,
        columnDefs: [
            {
                //"width": "1%",
                //"targets": [0,3]
            }
        ]*/
    });

    var m_tabla = $("#id_venta_m").dataTable(); //funcion jquery
    var m_table = $("#id_venta_m").DataTable(); //funcion DataTable-libreria
    //m_table.columns.adjust().draw();


    function addSelectVendedor(data) {
        //DESCRIPCION : Funcion para llenar la lista de opciones del select del Vendedor.
        for (var i = 0; i < data.length; i++) {
            m_vendedores.append("<option value=" + data[i]["ntraUsuario"] + ">" + data[i]["vendedor"] + "</option>");
        }
    }

    function ListarVendedores() {
        //DESCRIPCION : Funcion que me trae la lista de vendedores
        $.ajax({
            type: "POST",
            url: "frmRutasAsignadas.aspx/ListarVendedores",
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

    $(function () {
        var f = new Date();
        var d = parseInt(f.getDate()) * -1 + 1;

        var m = new Date(f.getFullYear(), f.getMonth() + 1, 0).getDate();
        //var m = new Date(2020, 4, 0).getDate();
        var ud = parseInt(m) - parseInt(d) * -1 - 1;
        //console.log(ud);
        $("#id_fechainicio_m").datepicker({
            minDate: d,
            maxDate: "+" + ud + "D",
            regional: "es",
            closeText: 'Cerrar',
            prevText: 'Anterior',
            nextText: 'Siguiente',
            currentText: 'Hoy',
            monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
            monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
            dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'],
            dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mié', 'Juv', 'Vie', 'Sáb'],
            dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sá'],
            weekHeader: 'Sm',
            dateFormat: 'dd/mm/yy',
            firstDay: 1,
            isRTL: false,
            showMonthAfterYear: false,
            yearSuffix: ''
        });
    });

    $(function () {
        var f = new Date();
        var d = parseInt(f.getDate()) * -1 + 1;
        var m = new Date(f.getFullYear(), f.getMonth() + 1, 0).getDate();
        var ud = parseInt(m) - parseInt(d) * -1 - 1;
        $("#id_fechafin_m").datepicker({
            minDate: d,
            maxDate: "+" + ud + "D",
            regional: "es",
            closeText: 'Cerrar',
            prevText: 'Anterior',
            nextText: 'Siguiente',
            currentText: 'Hoy',
            monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
            monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
            dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'],
            dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mié', 'Juv', 'Vie', 'Sáb'],
            dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sá'],
            weekHeader: 'Sm',
            dateFormat: 'dd/mm/yy',
            firstDay: 1,
            isRTL: false,
            showMonthAfterYear: false,
            yearSuffix: ''
        });
    });

    function verificarFecha() {
        m_fechafin.change(function () {
            //console.log("A");
            //console.log(new Date(m_fechafin.val().slice(6, 10) + "-" + m_fechafin.val().slice(3, 5) + "-" + m_fechafin.val().slice(0, 2)).getTime());
            //console.log(new Date(m_fechainicio.val().slice(6, 10) + "-" + m_fechainicio.val().slice(3, 5) + "-" + m_fechainicio.val().slice(0, 2)).getTime());

            if (m_fechainicio.val() == "") {
                swal("Debe ingresar la Fecha Inicial");
                m_fechafin.val("");
                m_fechainicio.focus();
            } else {
                if (!validarFormatoFecha(m_fechafin.val())) {
                    swal("Formato de Fecha Fin incorrecta");
                    m_fechafin.val("");
                    m_fechainicio.focus();
                } else {
                    if (new Date(m_fechafin.val().slice(6, 10) + "-" + m_fechafin.val().slice(3, 5) + "-" + m_fechafin.val().slice(0, 2)).getTime() <
                        new Date(m_fechainicio.val().slice(6, 10) + "-" + m_fechainicio.val().slice(3, 5) + "-" + m_fechainicio.val().slice(0, 2)).getTime()
                    ) {
                        swal("Fecha Fin debe ser mayor o igual a la Fecha Inicio");
                        m_fechafin.val("");
                        m_fechainicio.focus();
                    }
                }
            }
        });
    }
    verificarFecha()

    function verificarFechaInicio() {
        m_fechainicio.change(function () {
            if (m_fechainicio.val() != "") {
                if (!validarFormatoFecha(m_fechainicio.val())) {
                    swal("Formato de Fecha Inicio incorrecta");
                    m_fechainicio.val("");
                    m_fechainicio.focus();
                }
            }
        });
    }
    verificarFechaInicio()

    function validarFormatoFecha(campo) {
        var RegExPattern = /^\d{1,2}\/\d{1,2}\/\d{2,4}$/;
        if ((campo.match(RegExPattern)) && (campo != '')) {
            return true;
        } else {
            return false;
        }
    }

    m_cliente.keyup(function (event) {
        codigo = m_cliente.val();
        if (codigo.length == 0) {
            m_codcliente.val("");
            //limpiar combo (dejando el seleccionar)
            /*var optionSelected = puntosEntrega.find("option");
            for (var i = 0; i < optionSelected.length; i++) {
                if (optionSelected[i].value != 0) {
                    optionSelected[i].remove();
                }
            }*/
        } else {
            buscarClienteDocumento(codigo);
        }

    });

    function buscarClienteDocumento(cadena) {
        m_cliente.autocomplete({
            appendTo: "#exampleModal",
            minLength: 2,
            source:
                function (request, response) {
                    $.ajax({
                        type: "POST",
                        url: "frmNotaCredito.aspx/buscarCliente",
                        data: "{'cadena': '" + cadena + "' }",
                        contentType: 'application/json; charset=utf-8',
                        error: function (xhr, ajaxOtions, thrownError) {
                            console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
                        },
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                var obj = new Object();
                                obj.label = item.nombres;
                                obj.value = item.nombres;
                                //obj.tipoListaPrecio = item.tipoListaPrecio;
                                obj.codCliente = item.codCliente;
                                //obj.numDocumento = item.numDocumento;
                                return obj;
                            }));
                        }

                    });
                },
            select: function (event, ui) {
                m_codcliente.val(ui.item.codCliente);
                m_cliente.val(ui.item.value);
            }
        });
    }

    function cargarArrayBusqueda(data) {
        //console.log(data.length);
        //console.log(data);
        m_arr_ventas = null;
        m_arr_ventas = new Array();
        var obj = new Object();
        for (var i = 0; i < data.length; i++) {
            obj = new Object();
            obj.ntraventa = data[i]["ntraVenta"];
            obj.nombres = data[i]["nombres"];
            obj.accion = m_btnNotaCredito;
            m_arr_ventas.push(obj);
            //obj = null;
        }
        //console.log(m_arr_ventas);
        recargarTablaBusqueda();
    }

    function recargarTablaBusqueda() {
        m_table.clear().draw();
        for (var i = 0; i < m_arr_ventas.length; i++) {
            m_tabla.fnAddData([
                m_arr_ventas[i].ntraventa,
                m_arr_ventas[i].nombres,
                m_arr_ventas[i].accion
            ]);
        }
        //$(".btnEditar").click(function () {
        $("body").on('click', '.btnCheck', function () {
            var tr = $(this).parent().parent();
            var a = m_table.row(tr).data()[0];
            $.ajax({
                type: "POST",
                url: "frmNotaCredito.aspx/validarVenta",
                data: "{'codigo': '" + a + "'}",
                contentType: 'application/json; charset=utf-8',
                error: function (xhr, ajaxOtions, thrownError) {
                    console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
                },
                success: function (data) {
                    if (data.d.flag == 0) {
                        swal({
                            title: "No es posible aplicar Nota de Credito",
                            text: data.d.msje,
                            icon: "error"
                        })
                    } else {
                        cargarDatosVentaPromocion(m_table.row(tr).data()[0]);
                        cargarDatosVentaDescuento(m_table.row(tr).data()[0]);
                        cargarDatosVenta(m_table.row(tr).data()[0]);
                        cargarDatosDetalleVenta(m_table.row(tr).data()[0]);
                        modalPago.modal('hide');
                    }
                }
            })
        });
        /*m_arr_ventas.forEach(function (elemento, indice, array) {
            m_tabla.fnAddData([
                elemento.ntraventa,
                elemento.nombres,
                elemento.accion
            ]);

            $(".btnEditar").click(function () {
                console.log("AAAA");
                var tr = $(this).parent().parent();
                cargarDatosVentaPromocion(m_table.row(tr).data()[0]);
                cargarDatosVentaDescuento(m_table.row(tr).data()[0]);
                cargarDatosVenta(m_table.row(tr).data()[0]);
                cargarDatosDetalleVenta(m_table.row(tr).data()[0]);
                //calcularTotales();
            });
        });*/

    }

    function buscarVenta() {
        $("#btnbuscar_m").click(function () {
            //agregar validaciones
            var codventa = m_codventa.val();
            var serie = m_serie.val();
            var numero = m_numero.val();
            var fechainicio = m_fechainicio.val();
            var fechafin = m_fechafin.val();
            var codcliente = m_codcliente.val();

            var optionSelected = m_vendedores.find("option:selected");
            var codvendedor = optionSelected.val();


            $.ajax({
                type: "POST",
                url: "frmNotaCredito.aspx/buscarVentas",
                data: "{'parametros': { 'codVenta':'" + codventa + "', 'serie':'" + serie + "', 'numero':'" + numero + "', 'fechaInicio':'" + fechainicio + "', 'fechaFin':'" + fechafin + "', 'codCliente':'" + codcliente + "', 'codVendedor':'" + codvendedor + "' } }",
                contentType: 'application/json; charset=utf-8',
                error: function (xhr, ajaxOtions, thrownError) {
                    console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
                },
                success: function (data) {
                    //console.log(data);
                    //console.log(data.d);
                    cargarArrayBusqueda(data.d);
                }
            })

        });
    }
    buscarVenta();

    mp_cantidad.keypress(function (evt) {
        evt.preventDefault();
    });

    function cantidadProducto() {
        mp_cantidad.change(function () {
            var ori = parseInt(mp_cant_original.val());
            var can = parseInt(mp_cantidad.val());

            if (can < 1)
                mp_cantidad.val(1);

            if (can > ori)
                mp_cantidad.val(ori);
        });
    }
    cantidadProducto();

    function guardarNuevaCantidad() {
        mp_btnguardar.click(function () {
            var ori = parseInt(mp_cant_original.val());
            var can = mp_cantidad.val();
            if (can.length == "") {
                swal("Debe ingresar la cantidad");
            } else {
                can = parseInt(mp_cantidad.val());
                if (can <= ori) {
                    //FUNCION
                    //if (can != ori) {
                    var tot = 0;
                    var des = 0;
                    var flag = 0;
                    for (var i = 0; i < arr_detalle_venta.length; i++) {
                        if (arr_detalle_venta[i].codProducto == mp_producto.val()) {
                            /*
                            
                            obj.cantidadPresentacion = data[i]["cantidadPresentacion"];
                            obj.cantidad_ori = data[i]["cantidadPresentacion"];
                            obj.can_ub = parseFloat(data[i]["cantidadUnidadBase"]) / parseFloat(data[i]["cantidadPresentacion"]);
                            obj.cantidadUnidadBase = data[i]["cantidadUnidadBase"];
                            obj.precioVenta = parseFloat(Math.round(parseFloat(data[i]["precioVenta"]) * 100) / 100).toFixed(2);
                            
                            
                            cantUB = parseFloat(obj.cantidadUnidadBase);
                            precio = parseFloat(obj.precioVenta);
                            obj.subTotal = parseFloat(Math.round(cantUB * precio * 100) / 100).toFixed(2);
                             */
                            if (arr_detalle_venta[i].flagDescu == 1 && arr_detalle_venta[i].flag_disp == 1) {
                                tot = obtenerTotal(mp_producto.val());
                                des = obtenerDescuento(mp_producto.val());
                                tot = tot + parseFloat(mp_cantidad.val()) * parseFloat(arr_detalle_venta[i].precioVenta) * parseInt(arr_detalle_venta[i].can_ub);
                                //des = des + parseFloat(arr_detalle_venta[i].impo_descu);

                                if (tot <= des) {
                                    flag = 1;
                                    swal({
                                        title: "Cantidad no permitida",
                                        text: "Con la cantidad elegida el total es menor/igual al importe descuento.",
                                        icon: "error"
                                    });
                                    break;
                                }
                            }

                            if (flag == 0) {
                                arr_detalle_venta[i].cantidadPresentacion = mp_cantidad.val();
                                arr_detalle_venta[i].cantidadUnidadBase = parseInt(mp_cantidad.val()) * parseInt(arr_detalle_venta[i].can_ub);
                                arr_detalle_venta[i].subTotal = parseInt(arr_detalle_venta[i].cantidadUnidadBase) * parseFloat(arr_detalle_venta[i].precioVenta);
                                arr_detalle_venta[i].subTotal = parseFloat(Math.round(parseFloat(arr_detalle_venta[i].subTotal) * 100) / 100).toFixed(2);
                                arr_detalle_venta[i].can_devueltos = parseInt(arr_detalle_venta[i].can_original_devu) + parseInt(mp_cant_original.val()) - parseInt(mp_cantidad.val());
                                arr_detalle_venta[i].can_disponible = mp_cantidad.val();

                                if (arr_detalle_venta[i].can_disponible == 0) {
                                    if (arr_detalle_venta[i].flagPromo != 1) {
                                        arr_detalle_venta[i].accion = btnEditar;
                                    } else {
                                        arr_detalle_venta[i].accion = '';
                                    }
                                } else {
                                    arr_detalle_venta[i].accion = btnEliminar + btnEditar;
                                }
                            }

                            /*
                            if (arr_detalle_venta[i].can_disponible == 0 && arr_detalle_venta[i].flagPromo != 1) {
                                arr_detalle_venta[i].accion = btnEditar;
                            } else {



                                if (arr_detalle_venta[i].flagPromo != 1) {
                                    arr_detalle_venta[i].accion = btnEliminar + btnEditar;
                                } else {
                                    arr_detalle_venta[i].accion = btnEliminar;
                                }
                                
                            }*/
                            break;
                        }
                    }
                    //}
                    if (flag == 0) {
                        recargarTabla();
                        //procesoDescuentos();
                        procesoPromociones();
                        calcularTotales();
                        $(".btnDelete").prop("disabled", false);
                        $(".btnEditar").prop("disabled", false);
                        modalEditarProducto.modal('hide');
                    }
                }
            }
        });
    }
    guardarNuevaCantidad();

    function procesoPromociones() {
        var obj = new Object();
        var flag = 0;
        var flag3 = 0;
        //verificar si producto genera promocion
        for (var i = 0; i < arr_detalle_venta.length; i++) {
            if (arr_detalle_venta[i].codProducto == mp_producto.val()) {
                if (arr_detalle_venta[i].flagPromo == 9 && arr_detalle_venta[i].flag_disp == 1) {
                    flag = 1;
                    if (arr_detalle_venta[i].can_disponible == arr_detalle_venta[i].can_original_disp)
                        flag3 = 1;
                    obj = arr_detalle_venta[i];
                    break;
                }
            }
        }

        var flag2 = 0;
        if (flag == 1) {

            if (flag3 == 1) {
                for (var i = 0; i < arr_detalle_venta.length; i++) {
                    if (arr_detalle_venta[i].flagPromo == 1 && arr_detalle_venta[i].codPromo == mp_producto.val()
                        && arr_detalle_venta[i].flag_disp == 1) {
                        //flag2 = 1;
                        arr_detalle_venta[i].can_disponible = arr_detalle_venta[i].can_original_disp;
                        arr_detalle_venta[i].cantidadPresentacion = arr_detalle_venta[i].can_original_disp;
                        arr_detalle_venta[i].can_devueltos = 0;
                        arr_detalle_venta[i].accion = btnEliminar;
                        //break;
                    }
                }
                recargarTabla();
                calcularTotales();
                $(".btnDelete").prop("disabled", false);
                $(".btnEditar").prop("disabled", false);
            } else {
                //verificar si tiene productos
                for (var i = 0; i < arr_detalle_venta.length; i++) {
                    if (arr_detalle_venta[i].flagPromo == 1 && arr_detalle_venta[i].codPromo == mp_producto.val()
                        && arr_detalle_venta[i].can_disponible > 0 && arr_detalle_venta[i].flag_disp == 1) {
                        flag2 = 1;
                        break;
                    }
                }

                if (flag2 == 1) {
                    swal({
                        title: "El producto tiene promociones",
                        text: "¿Desea que se quiten los productos promocion?",
                        icon: "warning",
                        /*buttons: true,
                        dangerMode: true,*/
                        buttons: {
                            cancel: "No",
                            defeat: "Si",
                        },
                    })
                        //Promesa que me trae el valor true al confirmar OK.
                        .then((willDelete) => {
                            switch (willDelete) {
                                case "cancel":

                                    break;
                                case "defeat":
                                    for (var i = 0; i < arr_detalle_venta.length; i++) {
                                        if (arr_detalle_venta[i].flagPromo == 1 && arr_detalle_venta[i].codPromo == mp_producto.val()
                                            && arr_detalle_venta[i].can_disponible > 0 && arr_detalle_venta[i].flag_disp == 1) {
                                            //flag2 = 1;
                                            arr_detalle_venta[i].can_disponible = 0;
                                            arr_detalle_venta[i].cantidadPresentacion = 0;
                                            arr_detalle_venta[i].can_devueltos = arr_detalle_venta[i].can_original_disp;
                                            arr_detalle_venta[i].accion = '';
                                            //break;
                                        }
                                    }

                                    swal("Se quitaron productos promocion", {
                                        icon: "success",
                                    });

                                    recargarTabla();
                                    calcularTotales();
                                    $(".btnDelete").prop("disabled", false);
                                    $(".btnEditar").prop("disabled", false);

                                    break;
                            }
                        });
                }
            }
        }
        recargarTabla();
        calcularTotales();
    }

    function continuar_proceso_promocion(obj, flag2, data) {
        var flag3 = 0;
        var can = parseInt(mp_cantidad.val()) * parseInt(obj.can_ub);
        var imp = parseInt(mp_cantidad.val()) * parseFloat(obj.precioVenta) * parseInt(obj.can_ub);
        if (data.tipo == 1) { //cantidad
            if (can >= parseInt(data.valor)) {
                flag3 = 1;
            }
        } else {
            if (data.tipo == 2) {
                if (imp >= parseFloat(data.valor)) {
                    flag3 = 1;
                }
            }
        }

        if (flag2 == 0) { //no hay productos promo en tabla
            if (flag3 == 1) {
                //poner productos
                agregarProductosPromocion();
            }
        } else { //si hay productos promo en tabla
            if (flag3 == 0) {
                //quitar productos
                quitarProductosPromocion();
            }
        }
        recargarTabla();
        calcularTotales();
        $(".btnDelete").prop("disabled", false);
        $(".btnEditar").prop("disabled", false);
        console.log(arr_detalle_venta);
    }

    function agregarProductosPromocion() {
        var item = arr_detalle_venta.length;
        var obj = new Object();
        for (var i = 0; i < arr_detalle_salvado.length; i++) {
            obj = new Object();
            if (arr_detalle_salvado[i].codPromo == mp_producto.val() && arr_detalle_salvado[i].flagPromo == 1) {
                obj = arr_detalle_salvado[i];
                item = item + 1;
                obj.itemVenta = item;
                arr_detalle_venta.push(obj);
            }
        }
    }

    function quitarProductosPromocion() {
        var item = 0;
        //var obj = new Object();
        var arr = new Array();
        var cont = 0;
        var cont2 = 0;
        for (var i = 0; i < arr_detalle_venta.length; i++) {
            //obj = new Object();
            if (arr_detalle_venta[i].codPromo == mp_producto.val() && arr_detalle_venta[i].flagPromo == 1) {
                if (cont == 0)
                    item = arr_detalle_venta[i].itemVenta;
                cont = cont + 1;
            } else {
                arr.push(arr_detalle_venta[i]);
                arr[cont2].itemVenta = cont2 + 1;
                cont2 = cont2 + 1;
            }
        }
        arr_detalle_venta = arr.slice();
        //
        for (var i = 0; i < arr_detalle_venta.length; i++) {
            if (arr_detalle_venta[i].flagPromo == 1 && arr_detalle_venta[i].itemVenta > item) {
                arr_detalle_venta[i].item_preventa = parseInt(arr_detalle_venta[i].item_preventa) - cont;
            }
        }
    }

    function obtenerValoresPromocion(obj, flag2) {
        $.ajax({
            type: "POST",
            url: "frmNotaCredito.aspx/obtenerValoresPromocion",
            data: "{'codigo': '" + obj.cod_promocion + "' }",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                continuar_proceso_promocion(obj, flag2, data.d);
            }
        })
    }

    function procesoDescuentos() {
        var obj = new Object();
        var flag = 0;
        var flag3 = 0;
        //verificar si producto tiene descuento
        for (var i = 0; i < arr_detalle_venta.length; i++) {
            if (arr_detalle_venta[i].codProducto == mp_producto.val()) {
                if (arr_detalle_venta[i].flagDescu == 1 && arr_detalle_venta[i].flag_disp == 1) {
                    flag = 1;
                    if (arr_detalle_venta[i].can_disponible == arr_detalle_venta[i].can_original_disp)
                        flag3 = 1;
                    obj = arr_detalle_venta[i];
                    break;
                }
            }
        }

        if (flag == 1) {
            if (flag3 == 1) {
                for (var i = 0; i < arr_detalle_venta.length; i++) {
                    if (arr_detalle_venta[i].flagDescu == 1 && arr_detalle_venta[i].codProducto == mp_producto.val()
                        && arr_detalle_venta[i].flag_disp == 1) {
                        arr_detalle_venta[i].impo_descu = parseFloat(Math.round(parseFloat(arr_detalle_venta[i].dscto_ori) * 100) / 100).toFixed(2);
                        break;
                    }
                }
                recargarTabla();
                calcularTotales();
                $(".btnDelete").prop("disabled", false);
                $(".btnEditar").prop("disabled", false);

            } else {
                var tot = 0;
                var flag4 = 0;
                for (var i = 0; i < arr_detalle_venta.length; i++) {
                    if (arr_detalle_venta[i].flagDescu == 1 && arr_detalle_venta[i].codProducto == mp_producto.val()
                        && arr_detalle_venta[i].flag_disp == 1) {
                        tot = parseFloat(arr_detalle_venta[i].can_disponible) * parseFloat(arr_detalle_venta[i].precioVenta) * parseInt(arr_detalle_venta[i].can_ub);
                        if (tot > parseFloat(arr_detalle_venta[i].dscto_ori))
                            flag4 = 1;
                        break;
                    }
                }

                if (flag4 == 1) {
                    swal({
                        title: "El producto tiene descuento",
                        text: "¿Desea eliminar el descuento?",
                        icon: "warning",
                        /*buttons: true,
                        dangerMode: true,*/
                        buttons: {
                            cancel: "No",
                            defeat: "Si",
                        },
                    })
                        //Promesa que me trae el valor true al confirmar OK.
                        .then((willDelete) => {
                            switch (willDelete) {
                                case "cancel":

                                    break;
                                case "defeat":
                                    for (var i = 0; i < arr_detalle_venta.length; i++) {
                                        if (arr_detalle_venta[i].flagDescu == 1 && arr_detalle_venta[i].codProducto == mp_producto.val()
                                            && arr_detalle_venta[i].flag_disp == 1) {
                                            arr_detalle_venta[i].impo_descu = parseFloat(Math.round(0 * 100) / 100).toFixed(2);;
                                            break;
                                        }
                                    }

                                    swal("Se elimino el descuento", {
                                        icon: "success",
                                    });

                                    recargarTabla();
                                    calcularTotales();
                                    $(".btnDelete").prop("disabled", false);
                                    $(".btnEditar").prop("disabled", false);

                                    break;
                            }
                        });
                } else {
                    for (var i = 0; i < arr_detalle_venta.length; i++) {
                        if (arr_detalle_venta[i].flagDescu == 1 && arr_detalle_venta[i].codProducto == mp_producto.val()
                            && arr_detalle_venta[i].flag_disp == 1) {
                            arr_detalle_venta[i].impo_descu = parseFloat(Math.round(0 * 100) / 100).toFixed(2);;
                            break;
                        }
                    }
                    recargarTabla();
                    calcularTotales();
                    $(".btnDelete").prop("disabled", false);
                    $(".btnEditar").prop("disabled", false);
                }


            }


            //obtenerValoresDescuento(obj);
        }
        console.log(arr_detalle_venta);
        console.log(arr_detalle_salvado);
    }

    function continuar_proceso_descuento(obj, data) {
        var flag3 = 0;
        var can = parseInt(mp_cantidad.val()) * parseInt(obj.can_ub);
        var imp = parseInt(mp_cantidad.val()) * parseFloat(obj.precioVenta) * parseInt(obj.can_ub);
        if (data.tipo == 1) { //cantidad
            if (can >= parseInt(data.valor)) {
                flag3 = 1;
            }
        } else {
            if (data.tipo == 2) {
                if (imp >= parseFloat(data.valor)) {
                    flag3 = 1;
                }
            }
        }
        var descu = 0;
        if (flag3 == 1) {
            if (data.tipoDescuento == 1) {
                descu = parseFloat(data.valorDescuento);
            } else {
                descu = parseFloat(imp) * parseFloat(data.valorDescuento) / 100;
            }

            for (var i = 0; i < arr_detalle_venta.length; i++) {
                if (arr_detalle_venta[i].codProducto == mp_producto.val()) {
                    arr_detalle_venta[i].impo_descu = parseFloat(Math.round(descu * 100) / 100).toFixed(2);
                    break;
                }
            }
        } else {
            for (var i = 0; i < arr_detalle_venta.length; i++) {
                if (arr_detalle_venta[i].codProducto == mp_producto.val()) {
                    arr_detalle_venta[i].impo_descu = parseFloat(Math.round(0 * 100) / 100).toFixed(2);
                    break;
                }
            }
        }

        recargarTabla();
        calcularTotales();
        $(".btnDelete").prop("disabled", false);
        $(".btnEditar").prop("disabled", false);
        console.log(arr_detalle_venta);
    }

    function obtenerValoresDescuento(obj) {
        $.ajax({
            type: "POST",
            url: "frmNotaCredito.aspx/obtenerValoresDescuento",
            data: "{'codigo': '" + obj.cod_descu + "' }",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                continuar_proceso_descuento(obj, data.d);
            }
        })
    }

    function cargarDatosVenta(codigo) {
        $.ajax({
            type: "POST",
            url: "frmNotaCredito.aspx/obtenerVenta",
            data: "{'codigo': '" + codigo + "' }",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                id_codventa.val(data.d.ntraVenta);
                id_tipocambio.val(data.d.tipoCambio);
                id_serie.val(data.d.serie);
                id_numero.val(data.d.nroDocumento);
                id_cliente.val(data.d.nomCliente);
                id_vendedor.val(data.d.nomVendedor);
                id_total.val(parseFloat(Math.round(data.d.importeTotal * 100) / 100).toFixed(2));
                id_recargo.val(parseFloat(Math.round(data.d.importeRecargo * 100) / 100).toFixed(2));
                i_total = data.d.importeTotal;
                i_total_salvado = i_total;
                i_recargo = data.d.importeRecargo;
                if (parseFloat(i_recargo) > 0) {
                    p_flag_recargo = 1;
                }
                tipoVenta = data.d.tipoVenta
            }
        })
    }

    function llenarArrayDetalleVenta(data) {
        arr_detalle_venta = null;
        arr_detalle_salvado = null;
        arr_detalle_venta = new Array();
        arr_detalle_salvado = new Array();
        var obj = new Object();
        var cantUB = 0.0;
        var precio = 0.0;
        for (var i = 0; i < data.length; i++) {
            obj = new Object();
            obj.itemVenta = data[i]["itemVenta"];
            obj.codProducto = data[i]["codProducto"];
            obj.descProducto = data[i]["descProducto"];
            obj.can_disponible = data[i]["can_disponible"];
            obj.can_devueltos = data[i]["can_devueltos"];

            obj.cantidadPresentacion = obj.can_disponible;
            obj.can_original_disp = obj.can_disponible;
            obj.can_original_devu = obj.can_devueltos;

            if (parseInt(obj.can_disponible) > 0) {
                obj.flag_disp = 1;
            } else {
                obj.flag_disp = 0;
            }
            obj.dscto_ori = parseFloat(Math.round(parseFloat(data[i]["descuento_disponible"]) * 100) / 100).toFixed(2);
            obj.cantidad_ori = data[i]["cantidadPresentacion"];
            obj.can_ub = parseFloat(data[i]["cantidadUnidadBase"]) / parseFloat(data[i]["cantidadPresentacion"]);
            obj.cantidadUnidadBase = data[i]["cantidadUnidadBase"];
            obj.precioVenta = parseFloat(Math.round(parseFloat(data[i]["precioVenta"]) * 100) / 100).toFixed(2);
            obj.descAlmacen = data[i]["descAlmacen"];
            obj.descUnidadBase = data[i]["descUnidadBase"];
            cantUB = parseFloat(obj.cantidadUnidadBase);
            precio = parseFloat(obj.precioVenta);
            obj.subTotal = parseFloat(Math.round(obj.can_ub * parseInt(obj.can_disponible) * precio * 100) / 100).toFixed(2);
            obj.tipoProducto = data[i]["tipoProducto"];
            obj.descTipoProducto = data[i]["descTipoProducto"];


            if (parseInt(obj.can_disponible) == 0) {
                obj.flagPromo = 0;
                obj.flagDescu = 0;
                obj.accion = '';
            } else {
                switch (obj.tipoProducto) {
                    case 1:
                        //obj.descTipoProducto = "NORMAL";
                        obj.flagPromo = 0;
                        obj.flagDescu = 0;
                        obj.accion = btnEliminar + btnEditar;
                        break;
                    case 2:
                        //obj.descTipoProducto = "DESCUENTO";
                        obj.flagPromo = 0;
                        if (parseFloat(obj.dscto_ori) > 0)
                            obj.flagDescu = 1;
                        else
                            obj.flagDescu = 0;
                        obj.accion = btnEliminar + btnEditar;
                        break;
                    case 3:
                        //obj.descTipoProducto = "PROMOCION";
                        obj.flagPromo = 1;
                        obj.flagDescu = 0;
                        obj.accion = btnEliminar;
                        break;
                }
            }

            //
            obj.codPromo = ""; //producto que genera promocion
            obj.cod_promocion = 0;
            obj.item_preventa = 0;
            obj.impo_descu = parseFloat(Math.round(parseFloat(data[i]["descuento_disponible"]) * 100) / 100).toFixed(2);
            obj.cod_descu = 0;
            //

            arr_detalle_venta.push(obj);
            arr_detalle_salvado.push(obj);
            if (obj.flag_disp == 1) {
                i_total_original = i_total_original + parseFloat(obj.subTotal);
                i_total_original = i_total_original - parseFloat(obj.impo_descu);
            }
            //if (obj.flag_disp == 1)

        }
        i_total_original = i_total_original + parseFloat(i_recargo);
        completarArray();
        //arr_detalle_salvado = arr_detalle_venta;
        items = arr_detalle_venta.length;
        cargarTablaDetalleVenta();
        calcularTotales();
    }

    function completarArray() {
        var codProd = "";
        var ite = 0;
        var codprom = 0;
        if (arr_venta_promo.length > 0) {
            for (var i = 0; i < arr_venta_promo.length; i++) {
                for (var j = 0; j < arr_detalle_venta.length; j++) {
                    //if (arr_detalle_venta[j].tipoProducto == 1) {
                    if (arr_detalle_venta[j].tipoProducto != 3) {
                        if (arr_detalle_venta[j].itemVenta == arr_venta_promo[i].itemVenta) {
                            codProd = arr_detalle_venta[j].codProducto;
                            ite = arr_detalle_venta[j].itemVenta;
                            arr_detalle_venta[j].codPromo = codProd;
                            arr_detalle_venta[j].flagPromo = 9;
                            arr_detalle_venta[j].cod_promocion = arr_venta_promo[i].codPromocion;

                            arr_detalle_salvado[j].codPromo = codProd;
                            arr_detalle_salvado[j].flagPromo = 9;
                            arr_detalle_salvado[j].cod_promocion = arr_venta_promo[i].codPromocion;
                        }
                    } else {
                        if (arr_detalle_venta[j].tipoProducto == 3) {
                            if (arr_detalle_venta[j].itemVenta == arr_venta_promo[i].itemPromocionado) {
                                arr_detalle_venta[j].codPromo = codProd;
                                arr_detalle_venta[j].cod_promocion = arr_venta_promo[i].codPromocion;
                                arr_detalle_venta[j].item_preventa = ite;

                                arr_detalle_salvado[j].codPromo = codProd;
                                arr_detalle_salvado[j].cod_promocion = arr_venta_promo[i].codPromocion;
                                arr_detalle_salvado[j].item_preventa = ite;
                            }
                        }
                    }

                }
            }
        }

        /*if (arr_venta_descu.length > 0) {
            for (var i = 0; i < arr_venta_descu.length; i++) {
                for (var j = 0; j < arr_detalle_venta.length; j++) {
                    if (arr_detalle_venta[j].tipoProducto == 2) {
                        if (arr_detalle_venta[j].itemVenta == arr_venta_descu[i].itemVenta) {
                            arr_detalle_venta[j].cod_descu = arr_venta_descu[i].codDescuento;
                            arr_detalle_venta[j].impo_descu = parseFloat(Math.round(parseFloat(arr_venta_descu[i].importe) * 100) / 100).toFixed(2);
                            if (arr_detalle_venta[j].flag_disp == 1)
                                i_total_original = i_total_original - parseFloat(arr_venta_descu[i].importe);
                            arr_detalle_salvado[j].cod_descu = arr_venta_descu[i].codDescuento;
                            arr_detalle_salvado[j].impo_descu = parseFloat(Math.round(parseFloat(arr_venta_descu[i].importe) * 100) / 100).toFixed(2);
                        }
                    }
                }
            }
        }*/
        /*console.log(arr_detalle_venta);
        console.log(arr_detalle_salvado);*/

        //arr_backup = JSON.parse(JSON.stringify(arr_detalle_venta));

        //arr_backup = arr_detalle_venta.slice();


    }

    function llenarArrayDetalleVentaBU(data) {
        var obj = new Object();
        var cantUB = 0.0;
        var precio = 0.0;
        for (var i = 0; i < data.length; i++) {
            obj = new Object();
            obj.itemVenta = data[i]["itemVenta"];
            obj.codProducto = data[i]["codProducto"];
            obj.descProducto = data[i]["descProducto"];
            obj.can_disponible = data[i]["can_disponible"];
            obj.can_devueltos = data[i]["can_devueltos"];

            obj.cantidadPresentacion = obj.can_disponible;
            obj.can_original_disp = obj.can_disponible;
            obj.can_original_devu = obj.can_devueltos;

            if (parseInt(obj.can_disponible) > 0) {
                obj.flag_disp = 1;
            } else {
                obj.flag_disp = 0;
            }
            obj.dscto_ori = parseFloat(Math.round(parseFloat(data[i]["descuento_disponible"]) * 100) / 100).toFixed(2);
            obj.cantidad_ori = data[i]["cantidadPresentacion"];
            obj.can_ub = parseFloat(data[i]["cantidadUnidadBase"]) / parseFloat(data[i]["cantidadPresentacion"]);
            obj.cantidadUnidadBase = data[i]["cantidadUnidadBase"];
            obj.precioVenta = parseFloat(Math.round(parseFloat(data[i]["precioVenta"]) * 100) / 100).toFixed(2);
            obj.descAlmacen = data[i]["descAlmacen"];
            obj.descUnidadBase = data[i]["descUnidadBase"];
            cantUB = parseFloat(obj.cantidadUnidadBase);
            precio = parseFloat(obj.precioVenta);
            obj.subTotal = parseFloat(Math.round(obj.can_ub * parseInt(obj.can_disponible) * precio * 100) / 100).toFixed(2);
            obj.tipoProducto = data[i]["tipoProducto"];
            obj.descTipoProducto = data[i]["descTipoProducto"];


            if (parseInt(obj.can_disponible) == 0) {
                obj.flagPromo = 0;
                obj.flagDescu = 0;
                obj.accion = '';
            } else {
                switch (obj.tipoProducto) {
                    case 1:
                        //obj.descTipoProducto = "NORMAL";
                        obj.flagPromo = 0;
                        obj.flagDescu = 0;
                        obj.accion = btnEliminar + btnEditar;
                        break;
                    case 2:
                        //obj.descTipoProducto = "DESCUENTO";
                        obj.flagPromo = 0;
                        obj.flagDescu = 1;
                        obj.accion = btnEliminar + btnEditar;
                        break;
                    case 3:
                        //obj.descTipoProducto = "PROMOCION";
                        obj.flagPromo = 1;
                        obj.flagDescu = 0;
                        obj.accion = btnEliminar;
                        break;
                }
            }

            //
            obj.codPromo = ""; //producto que genera promocion
            obj.cod_promocion = 0;
            obj.item_preventa = 0;
            obj.impo_descu = parseFloat(Math.round(parseFloat(data[i]["descuento_disponible"]) * 100) / 100).toFixed(2);
            obj.cod_descu = 0;
            //

            arr_backup.push(obj);
        }
        //i_total_original = i_total_original + parseFloat(i_recargo);
        completarArrayUB();
        //arr_detalle_salvado = arr_detalle_venta;
        //items = arr_detalle_venta.length;
        //cargarTablaDetalleVenta();
        //calcularTotales();
    }

    function completarArrayUB() {
        var codProd = "";
        var ite = 0;
        var codprom = 0;
        if (arr_venta_promo.length > 0) {
            for (var i = 0; i < arr_venta_promo.length; i++) {
                for (var j = 0; j < arr_backup.length; j++) {
                    //if (arr_backup[j].tipoProducto == 1) {
                    if (arr_backup[j].tipoProducto != 3) {
                        if (arr_backup[j].itemVenta == arr_venta_promo[i].itemVenta) {
                            codProd = arr_backup[j].codProducto;
                            ite = arr_backup[j].itemVenta;
                            arr_backup[j].codPromo = codProd;
                            arr_backup[j].flagPromo = 9;
                            arr_backup[j].cod_promocion = arr_venta_promo[i].codPromocion;
                        }
                    } else {
                        if (arr_backup[j].tipoProducto == 3) {
                            if (arr_backup[j].itemVenta == arr_venta_promo[i].itemPromocionado) {
                                arr_backup[j].codPromo = codProd;
                                arr_backup[j].cod_promocion = arr_venta_promo[i].codPromocion;
                                arr_backup[j].item_preventa = ite;
                            }
                        }
                    }

                }
            }
        }

        /*if (arr_venta_descu.length > 0) {
            for (var i = 0; i < arr_venta_descu.length; i++) {
                for (var j = 0; j < arr_backup.length; j++) {
                    if (arr_backup[j].tipoProducto == 2) {
                        if (arr_backup[j].itemVenta == arr_venta_descu[i].itemVenta) {
                            arr_backup[j].cod_descu = arr_venta_descu[i].codDescuento;
                            arr_backup[j].impo_descu = parseFloat(Math.round(parseFloat(arr_venta_descu[i].importe) * 100) / 100).toFixed(2);
                            //i_total_original = i_total_original - parseFloat(arr_venta_descu[i].importe);
                        }
                    }
                }
            }
        }*/

    }


    function cargarDatosDetalleVenta(codigo) {
        $.ajax({
            type: "POST",
            url: "frmNotaCredito.aspx/obtenerDetalleVenta",
            data: "{'codigo': '" + codigo + "' }",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                llenarArrayDetalleVenta(data.d);
                llenarArrayDetalleVentaBU(data.d);
            }
        })
    }

    function llenarArrayVentaPromocion(data) {
        arr_venta_promo = null;
        arr_venta_promo_salvado = null;
        arr_venta_promo = new Array();
        arr_venta_promo_salvado = new Array();
        var obj = new Object();
        for (var i = 0; i < data.length; i++) {
            obj = new Object();
            obj.codPromocion = data[i]["codPromocion"];
            obj.itemVenta = data[i]["itemVenta"];
            obj.itemPromocionado = data[i]["itemPromocionado"];
            arr_venta_promo.push(obj);
        }
        arr_venta_promo_salvado = arr_venta_promo;

    }

    function cargarDatosVentaPromocion(codigo) {
        $.ajax({
            type: "POST",
            url: "frmNotaCredito.aspx/obtenerVentaPromocion",
            data: "{'codigo': '" + codigo + "' }",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                llenarArrayVentaPromocion(data.d);
            }
        })
    }

    function llenarArrayVentaDescuento(data) {
        arr_venta_descu = null;
        arr_venta_descu_salvado = null;
        arr_venta_descu = new Array();
        arr_venta_descu_salvado = new Array();
        var obj = new Object();
        for (var i = 0; i < data.length; i++) {
            obj = new Object();
            obj.codDescuento = data[i]["codDescuento"];
            obj.itemVenta = data[i]["itemVenta"];
            obj.importe = data[i]["importe"];
            arr_venta_descu.push(obj);
        }
        arr_venta_descu_salvado = arr_venta_descu;

    }

    function cargarDatosVentaDescuento(codigo) {
        $.ajax({
            type: "POST",
            url: "frmNotaCredito.aspx/obtenerVentaDescuento",
            data: "{'codigo': '" + codigo + "' }",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                llenarArrayVentaDescuento(data.d);
            }
        })
    }

    // MODAL FIN #######################################################################

    $('#id_carrito_venta').DataTable({
        paging: false,
        ordering: false,
        info: false,
        searching: false,
        language: {
            lengthMenu: "Mostrar _MENU_ registros",
            zeroRecords: "No hay ventas encontradas",
            info: "Mostrando la página _PAGE_ de _PAGES_",
            infoEmpty: "No hay registros disponibles.",
            infoFiltered: "(filtered from _MAX_ total records)",
            search: "Busqueda rapida: "
        },
        columnDefs: [
            {
                "width": "1%",
                "targets": [0, 1, 3, 6, 7, 9, 10]
            },
            {
                "targets": [4],
                "visible": false,
                "searchable": false
            },
            {
                "targets": [6],
                "visible": false,
                "searchable": false
            },
            {
                "targets": [15],
                "visible": false,
                "searchable": false
            }
        ],
        rowCallback: function (row, data, index) {
            switch (data[15]) {
                case 0:
                    $(row).find('td').css('color', 'red');
                    break;
                case 1:
                    if (data[3] == 0) {
                        $(row).find('td').css('color', 'orange');
                    } else {

                        if (data[3] != data[4]) {
                            $(row).find('td').css('color', 'blue');
                        } else {
                            $(row).find('td').css('color', 'black');
                        }
                    }
                    break;
            }

        }
    });
    var tabla = $("#id_carrito_venta").dataTable(); //funcion jquery
    var table = $("#id_carrito_venta").DataTable(); //funcion DataTable-libreria
    table.columns.adjust().draw();


    function cargarTablaDetalleVenta() {
        table.clear().draw();
        for (var i = 0; i < arr_detalle_salvado.length; i++) {
            tabla.fnAddData([
                arr_detalle_salvado[i].itemVenta,
                arr_detalle_salvado[i].codProducto,
                arr_detalle_salvado[i].descProducto,
                arr_detalle_salvado[i].cantidadPresentacion,
                arr_detalle_salvado[i].can_original_disp,
                arr_detalle_salvado[i].cantidad_ori,
                arr_detalle_salvado[i].can_ub,
                arr_detalle_salvado[i].precioVenta,
                arr_detalle_salvado[i].impo_descu,
                arr_detalle_salvado[i].descAlmacen,
                arr_detalle_salvado[i].descUnidadBase,
                arr_detalle_salvado[i].subTotal,
                //elemento.tipoProducto,
                arr_detalle_salvado[i].descTipoProducto,
                arr_detalle_salvado[i].can_devueltos,
                arr_detalle_salvado[i].accion,
                arr_detalle_salvado[i].flag_disp
            ]);
        }

        $(".btnEditar").click(function () {
            var tr = $(this).parent().parent(); //obtengo el padre(td) del padre (tr) del boton 

            mp_cant_original.val(table.row(tr).data()[4]);
            mp_cantidad.val(table.row(tr).data()[3]);
            mp_producto.val(table.row(tr).data()[1]);
            console.log(table.row(tr).data()[4]);
        });

        $(".btnDelete").click(function () {
            //Obtengo los valores de mi tr seleccionado.
            var tr = $(this).parent().parent();
            var cod = tr[0].cells[1].innerText;

            if (validarEliminacion(cod)) {
                if (validarEli(cod)) {
                    swal({
                        title: "Se eliminara el producto " + cod,
                        text: "¿Esta seguro que desea eliminar el producto?",
                        icon: "warning",
                        buttons: true,
                        dangerMode: true,
                    })
                        //Promesa que me trae el valor true al confirmar OK.
                        .then((willDelete) => {
                            if (willDelete) {
                                var flag = 0;
                                for (var i = 0; i < arr_detalle_venta.length; i++) {
                                    if (arr_detalle_venta[i].codProducto == cod) {
                                        arr_detalle_venta[i].cantidadPresentacion = 0;
                                        arr_detalle_venta[i].can_disponible = 0;
                                        arr_detalle_venta[i].subTotal = parseFloat(Math.round(0 * 100) / 100).toFixed(2);
                                        arr_detalle_venta[i].can_devueltos = arr_detalle_venta[i].can_original_disp + arr_detalle_venta[i].can_original_devu;
                                        if (arr_detalle_venta[i].flagPromo != 1) {
                                            arr_detalle_venta[i].accion = btnEditar;
                                        } else {
                                            arr_detalle_venta[i].accion = '';
                                        }


                                        if (arr_detalle_venta[i].flagPromo == 9 && arr_detalle_venta[i].flag_disp == 1) {
                                            flag = 1;
                                        }
                                    }
                                }

                                if (flag == 1) {
                                    for (var i = 0; i < arr_detalle_venta.length; i++) {
                                        if (arr_detalle_venta[i].flagPromo == 1 && arr_detalle_venta[i].codPromo == cod
                                            && arr_detalle_venta[i].flag_disp == 1) {
                                            arr_detalle_venta[i].can_disponible = 0;
                                            arr_detalle_venta[i].cantidadPresentacion = 0;
                                            arr_detalle_venta[i].can_devueltos = arr_detalle_venta[i].can_original_disp;
                                            arr_detalle_venta[i].accion = '';
                                        }
                                    }
                                }

                                swal("Se elimino el producto", {
                                    icon: "success",
                                });

                                recargarTabla();
                                $(".btnDelete").prop("disabled", false);
                                $(".btnEditar").prop("disabled", false);
                                calcularTotales();

                            } else {
                                swal("Se Cancelo la eliminacion", {
                                    icon: "info"
                                });
                            }
                        });
                } else {
                    swal({
                        title: "No es posible eliminar",
                        text: "Si elimina el producto el total será menor/igual al importe descuento.",
                        icon: "error"
                    });
                }
            } else {
                swal("Imposible eliminar producto", "Para eliminar todos los productos haga una NC Total", "info");
            }

        });
        /*arr_detalle_salvado.forEach(function (elemento, indice, array) {
            tabla.fnAddData([
                elemento.itemVenta,
                elemento.codProducto,
                elemento.descProducto,
                elemento.cantidadPresentacion,
                elemento.can_original_disp,
                elemento.cantidad_ori,
                elemento.can_ub,
                elemento.precioVenta,
                elemento.impo_descu,
                elemento.descAlmacen,
                elemento.descUnidadBase,
                elemento.subTotal,
                //elemento.tipoProducto,
                elemento.descTipoProducto,
                elemento.can_devueltos,
                elemento.accion,
                elemento.flag_disp
            ]);

            $(".btnEditar").click(function () {
                var tr = $(this).parent().parent(); //obtengo el padre(td) del padre (tr) del boton 

                mp_cant_original.val(table.row(tr).data()[4]);
                mp_cantidad.val(table.row(tr).data()[3]);
                mp_producto.val(table.row(tr).data()[1]);
                console.log(table.row(tr).data()[4]);
            });

            $(".btnDelete").click(function () {
                //Obtengo los valores de mi tr seleccionado.
                var tr = $(this).parent().parent();
                var cod = tr[0].cells[1].innerText;

                if (validarEliminacion(cod)) {
                    swal({
                        title: "Se eliminara el producto " + cod,
                        text: "¿Esta seguro que desea eliminar el producto?",
                        icon: "warning",
                        buttons: true,
                        dangerMode: true,
                    })
                        //Promesa que me trae el valor true al confirmar OK.
                        .then((willDelete) => {
                            if (willDelete) {
                                var flag = 0;
                                for (var i = 0; i < arr_detalle_venta.length; i++) {
                                    if (arr_detalle_venta[i].codProducto == cod) {
                                        arr_detalle_venta[i].cantidadPresentacion = 0;
                                        arr_detalle_venta[i].can_disponible = 0;
                                        arr_detalle_venta[i].subTotal = parseFloat(Math.round(0 * 100) / 100).toFixed(2);
                                        arr_detalle_venta[i].can_devueltos = arr_detalle_venta[i].can_original_disp + arr_detalle_venta[i].can_original_devu;
                                        if (arr_detalle_venta[i].flagPromo != 1) {
                                            arr_detalle_venta[i].accion = btnEditar;
                                        } else {
                                            arr_detalle_venta[i].accion = '';
                                        }


                                        if (arr_detalle_venta[i].flagPromo == 9 && arr_detalle_venta[i].flag_disp == 1) {
                                            flag = 1;
                                        }
                                    }
                                }

                                if (flag == 1) {
                                    for (var i = 0; i < arr_detalle_venta.length; i++) {
                                        if (arr_detalle_venta[i].flagPromo == 1 && arr_detalle_venta[i].codPromo == cod
                                            && arr_detalle_venta[i].flag_disp == 1) {
                                            arr_detalle_venta[i].can_disponible = 0;
                                            arr_detalle_venta[i].cantidadPresentacion = 0;
                                            arr_detalle_venta[i].can_devueltos = arr_detalle_venta[i].can_original_disp;
                                            arr_detalle_venta[i].accion = '';
                                        }
                                    }
                                }

                                swal("Se elimino el producto", {
                                    icon: "success",
                                });

                                recargarTabla();
                                $(".btnDelete").prop("disabled", false);
                                $(".btnEditar").prop("disabled", false);
                                calcularTotales();

                            } else {
                                swal("Se Cancelo la eliminacion", {
                                    icon: "info"
                                });
                            }
                        });
                } else {
                    swal("Imposible eliminar producto", "Para eliminar todos los productos haga una NC Total", "info");
                }

            });
        });
        */
    }

    function recargarTabla() {
        table.clear().draw();
        for (var i = 0; i < arr_detalle_venta.length; i++) {
            tabla.fnAddData([
                arr_detalle_venta[i].itemVenta,
                arr_detalle_venta[i].codProducto,
                arr_detalle_venta[i].descProducto,
                arr_detalle_venta[i].cantidadPresentacion,
                arr_detalle_venta[i].can_original_disp,
                arr_detalle_venta[i].cantidad_ori,
                arr_detalle_venta[i].can_ub,
                arr_detalle_venta[i].precioVenta,
                arr_detalle_venta[i].impo_descu,
                arr_detalle_venta[i].descAlmacen,
                arr_detalle_venta[i].descUnidadBase,
                arr_detalle_venta[i].subTotal,
                //elemento.tipoProducto,
                arr_detalle_venta[i].descTipoProducto,
                arr_detalle_venta[i].can_devueltos,
                arr_detalle_venta[i].accion,
                arr_detalle_venta[i].flag_disp
            ]);
        }

        $(".btnEditar").click(function () {
            var tr = $(this).parent().parent(); //obtengo el padre(td) del padre (tr) del boton 

            mp_cant_original.val(table.row(tr).data()[4]);
            mp_cantidad.val(table.row(tr).data()[3]);
            mp_producto.val(table.row(tr).data()[1]);
        });

        $(".btnDelete").click(function () {
            //Obtengo los valores de mi tr seleccionado.
            var tr = $(this).parent().parent();
            var cod = tr[0].cells[1].innerText;

            if (validarEliminacion(cod)) {
                if (validarEli(cod)) {
                    swal({
                        title: "Se eliminara el producto " + cod,
                        text: "¿Esta seguro que desea eliminar el producto?",
                        icon: "warning",
                        buttons: true,
                        dangerMode: true,
                    })
                        //Promesa que me trae el valor true al confirmar OK.
                        .then((willDelete) => {
                            if (willDelete) {
                                var flag = 0;
                                for (var i = 0; i < arr_detalle_venta.length; i++) {
                                    if (arr_detalle_venta[i].codProducto == cod) {
                                        arr_detalle_venta[i].cantidadPresentacion = 0;
                                        arr_detalle_venta[i].can_disponible = 0;
                                        arr_detalle_venta[i].subTotal = parseFloat(Math.round(0 * 100) / 100).toFixed(2);
                                        arr_detalle_venta[i].can_devueltos = arr_detalle_venta[i].can_original_disp + arr_detalle_venta[i].can_original_devu;
                                        if (arr_detalle_venta[i].flagPromo != 1) {
                                            arr_detalle_venta[i].accion = btnEditar;
                                        } else {
                                            arr_detalle_venta[i].accion = '';
                                        }

                                        if (arr_detalle_venta[i].flagPromo == 9 && arr_detalle_venta[i].flag_disp == 1) {
                                            flag = 1;
                                        }
                                    }
                                }

                                if (flag == 1) {
                                    for (var i = 0; i < arr_detalle_venta.length; i++) {
                                        if (arr_detalle_venta[i].flagPromo == 1 && arr_detalle_venta[i].codPromo == cod
                                            && arr_detalle_venta[i].flag_disp == 1) {
                                            arr_detalle_venta[i].can_disponible = 0;
                                            arr_detalle_venta[i].cantidadPresentacion = 0;
                                            arr_detalle_venta[i].can_devueltos = arr_detalle_venta[i].can_original_disp;
                                            arr_detalle_venta[i].accion = '';
                                        }
                                    }
                                }

                                swal("Se elimino el producto", {
                                    icon: "success",
                                });

                                recargarTabla();
                                $(".btnDelete").prop("disabled", false);
                                $(".btnEditar").prop("disabled", false);
                                calcularTotales();

                            } else {
                                swal("Se Cancelo la eliminacion", {
                                    icon: "info"
                                });
                            }
                        });
                } else {
                    swal({
                        title: "No es posible eliminar",
                        text: "Si elimina el producto el total será menor/igual al importe descuento.",
                        icon: "error"
                    });
                }
            } else {
                swal("Imposible eliminar producto", "Para eliminar todos los productos haga una NC Total", "info");
            }

        });

        /*arr_detalle_venta.forEach(function (elemento, indice, array) {
            tabla.fnAddData([
                elemento.itemVenta,
                elemento.codProducto,
                elemento.descProducto,
                elemento.cantidadPresentacion,
                elemento.can_original_disp,
                elemento.cantidad_ori,
                elemento.can_ub,
                elemento.precioVenta,
                elemento.impo_descu,
                elemento.descAlmacen,
                elemento.descUnidadBase,
                elemento.subTotal,
                //elemento.tipoProducto,
                elemento.descTipoProducto,
                elemento.can_devueltos,
                elemento.accion,
                elemento.flag_disp
            ]);

            $(".btnEditar").click(function () {
                var tr = $(this).parent().parent(); //obtengo el padre(td) del padre (tr) del boton 

                mp_cant_original.val(table.row(tr).data()[4]);
                mp_cantidad.val(table.row(tr).data()[3]);
                mp_producto.val(table.row(tr).data()[1]);
            });

            $(".btnDelete").click(function () {
                //Obtengo los valores de mi tr seleccionado.
                var tr = $(this).parent().parent();
                var cod = tr[0].cells[1].innerText;

                if (validarEliminacion(cod)) {
                    swal({
                        title: "Se eliminara el producto " + cod,
                        text: "¿Esta seguro que desea eliminar el producto?",
                        icon: "warning",
                        buttons: true,
                        dangerMode: true,
                    })
                        //Promesa que me trae el valor true al confirmar OK.
                        .then((willDelete) => {
                            if (willDelete) {
                                var flag = 0;
                                for (var i = 0; i < arr_detalle_venta.length; i++) {
                                    if (arr_detalle_venta[i].codProducto == cod) {
                                        arr_detalle_venta[i].cantidadPresentacion = 0;
                                        arr_detalle_venta[i].can_disponible = 0;
                                        arr_detalle_venta[i].subTotal = parseFloat(Math.round(0 * 100) / 100).toFixed(2);
                                        arr_detalle_venta[i].can_devueltos = arr_detalle_venta[i].can_original_disp + arr_detalle_venta[i].can_original_devu;
                                        if (arr_detalle_venta[i].flagPromo != 1) {
                                            arr_detalle_venta[i].accion = btnEditar;
                                        } else {
                                            arr_detalle_venta[i].accion = '';
                                        }

                                        if (arr_detalle_venta[i].flagPromo == 9 && arr_detalle_venta[i].flag_disp == 1) {
                                            flag = 1;
                                        }
                                    }
                                }

                                if (flag == 1) {
                                    for (var i = 0; i < arr_detalle_venta.length; i++) {
                                        if (arr_detalle_venta[i].flagPromo == 1 && arr_detalle_venta[i].codPromo == cod
                                            && arr_detalle_venta[i].flag_disp == 1) {
                                            arr_detalle_venta[i].can_disponible = 0;
                                            arr_detalle_venta[i].cantidadPresentacion = 0;
                                            arr_detalle_venta[i].can_devueltos = arr_detalle_venta[i].can_original_disp;
                                            arr_detalle_venta[i].accion = '';
                                        }
                                    }
                                }

                                swal("Se elimino el producto", {
                                    icon: "success",
                                });

                                recargarTabla();
                                $(".btnDelete").prop("disabled", false);
                                $(".btnEditar").prop("disabled", false);
                                calcularTotales();

                            } else {
                                swal("Se Cancelo la eliminacion", {
                                    icon: "info"
                                });
                            }
                        });
                } else {
                    swal("Imposible eliminar producto", "Para eliminar todos los productos haga una NC Total", "info");
                }

            });
        });
        */
    }

    function flujoNotaCredito() {
        id_motivo.change(function () {
            var optionSelected = id_motivo.find("option:selected");
            switch (optionSelected.val()) {
                case "04": //GLOBAL
                    //arr_detalle_venta = arr_detalle_salvado.slice();
                    //console.log(arr_detalle_venta);
                    //console.log(arr_backup);
                    //recargarArray();
                    //recargarTabla();
                    //calcularTotales();
                    procesoReversionTotal();
                    id_importe.val(parseFloat(Math.round((i_total_original + i_recargo) * 100) / 100).toFixed(2));
                    //$(".btnDelete").prop("disabled", true);
                    //$(".btnEditar").prop("disabled", true);
                    //console.log(arr_detalle_venta);
                    //console.log(arr_detalle_salvado);
                    id_motivo.prop("disabled", true);
                    break;
                case "05": //ITEM
                    //arr_detalle_venta = arr_detalle_salvado.slice();
                    //recargarArray();
                    //recargarTabla();
                    calcularTotales();
                    $(".btnDelete").prop("disabled", false);
                    $(".btnEditar").prop("disabled", false);
                    id_importe.val("0.00");
                    //console.log(arr_detalle_venta);
                    //console.log(arr_detalle_salvado);
                    id_motivo.prop("disabled", true);
                    break;
                default: //OPCION 0
                    //arr_detalle_venta = arr_detalle_salvado.slice();
                    //recargarArray();
                    //recargarTabla();
                    calcularTotales();
                    $(".btnDelete").prop("disabled", true);
                    $(".btnEditar").prop("disabled", true);
                    id_importe.val("0.00");
                    break;
            }
        });
    }
    flujoNotaCredito();

    function procesoReversionTotal() {
        for (var i = 0; i < arr_backup.length; i++) {
            if (arr_detalle_venta[i].can_disponible > 0 && arr_detalle_venta[i].flag_disp == 1) {
                arr_detalle_venta[i].can_disponible = 0;
                arr_detalle_venta[i].cantidadPresentacion = 0;
                arr_detalle_venta[i].can_devueltos = arr_detalle_venta[i].can_original_disp + arr_detalle_venta[i].can_original_devu;
                arr_detalle_venta[i].accion = '';
                arr_detalle_venta[i].subTotal = parseFloat(Math.round(0 * 100) / 100).toFixed(2);
                if (arr_detalle_venta[i].flagDescu == 1 && arr_detalle_venta[i].impo_descu > 0) {
                    arr_detalle_venta[i].impo_descu = parseFloat(Math.round(0 * 100) / 100).toFixed(2);
                }
            }
        }
        i_recargo = 0;
        recargarTabla();
        calcularTotales();
        $(".btnDelete").prop("disabled", true);
        $(".btnEditar").prop("disabled", true);
    }

    function recargarArray() {
        arr_detalle_venta = arr_backup.slice();
        /*for (var i = 0; i < arr_backup.length; i++) {
            arr_detalle_venta[i] = arr_backup[i];
        }*/
    }

    function calcularTotales() {
        i_total_salvado = 0;
        i_total = 0;
        //i_recargo = 0;
        i_igv = 0;
        i_subtotal = 0;
        i_descuento = 0;

        for (var j = 0; j < arr_detalle_venta.length; j++) {
            if (arr_detalle_venta[j].flag_disp == 1) {
                i_total = i_total + parseFloat(arr_detalle_venta[j].subTotal);
                i_descuento = i_descuento + parseFloat(arr_detalle_venta[j].impo_descu);
            }
        }
        //if (parseInt(p_flag_recargo) == 1) {
        //    i_recargo = (i_total * p_porcentaje_recargo / 100);
        //}
        i_total = i_total + parseFloat(i_recargo) - i_descuento;
        i_total_salvado = i_total;
        if (p_igv > 0)
            i_igv = i_total - (i_total / (p_igv));
        i_subtotal = i_total - i_igv;
        i_importe = i_total_original - i_total;

        id_total.val(parseFloat(Math.round(i_total * 100) / 100).toFixed(2));
        id_subtotal.val(parseFloat(Math.round(i_subtotal * 100) / 100).toFixed(2));
        id_igv.val(parseFloat(Math.round(i_igv * 100) / 100).toFixed(2));
        id_recargo.val(parseFloat(Math.round(i_recargo * 100) / 100).toFixed(2));
        id_descuento.val(parseFloat(Math.round(i_descuento * 100) / 100).toFixed(2));
        id_importe.val(parseFloat(Math.round(i_importe * 100) / 100).toFixed(2));
    }



    function guardarNotaCredito() {
        $("#btnGuardar").click(function () {
            var optionSelected = id_motivo.find("option:selected");
            var motivo = optionSelected.val();

            if (motivo == "0") {
                swal("Debe seleccionar un motivo", {
                    icon: "info"
                });
            } else {
                if (parseFloat(id_importe.val()) <= 0) {
                    swal("Debe quitar al menos un producto", {
                        icon: "info"
                    });
                } else {
                    guardarNC();
                }
            }
        });
    }
    guardarNotaCredito()

    function guardarNC() {
        var optionSelected = id_motivo.find("option:selected");
        var motivo = optionSelected.val();

        var tipo = 0;
        if (motivo == "04") // total
            tipo = 1;
        else
            tipo = 2; // parcial

        var flagReversion = 0;

        if (tipo == 1) {
            swal({
                title: "Nota Credito Total",
                text: "¿Desea revertir la preventa?",
                icon: "warning",
                buttons: {
                    cancel: "No",
                    defeat: "Si",
                },
            })
                //Promesa que me trae el valor true al confirmar OK.
                .then((willDelete) => {
                    switch (willDelete) {
                        case "cancel":

                            break;
                        case "defeat":
                            flagReversion = 1;
                            break;
                    }
                    enviarDatos(flagReversion);
                });
        } else {
            enviarDatos(flagReversion)
        }


    }

    function validarEliminacion(codProducto) {
        var flag = 0;
        for (var i = 0; i < arr_detalle_venta.length; i++) {
            if (arr_detalle_venta[i].codProducto != codProducto) {
                if (parseInt(arr_detalle_venta[i].can_disponible) > 0 && parseInt(arr_detalle_venta[i].flagPromo) != 1) {
                    flag = 1;
                }
            }
        }

        if (flag == 0) {
            return false;
        } else {
            return true;
        }
    }

    function enviarDatos(flagReversion) {
        var optionSelected = id_motivo.find("option:selected");
        var d = new Date();
        var month = d.getMonth() + 1;
        var day = d.getDate();

        //parametros de salida
        var codVenta = id_codventa.val();
        var motivo = optionSelected.val();
        var fecha = (day < 10 ? '0' : '') + day + "/" + (month < 10 ? '0' : '') + month + "/" + d.getFullYear();
        var tipo = 0;
        if (motivo == "04") // total
            tipo = 1;
        else
            tipo = 2; // parcial
        var importe = id_importe.val();
        var usuario = ntraUsuario;
        var codSucursal = ntraSucursal;
        var codUsuario = ntraUsuario;

        var flagp = 0;
        var cadena = "'listaDevueltos':["
        var can = 0;
        var can_ub = 0;
        var flag_des = 0;
        var flag_pro = 0;
        for (var i = 0; i < arr_detalle_venta.length; i++) {
            can = 0;
            can_ub = 0;
            flag_des = 0;
            flag_pro = 0;
            if (arr_detalle_venta[i].flag_disp == 1 && arr_detalle_venta[i].can_devueltos != arr_backup[i].can_devueltos) {
                can = parseInt(arr_detalle_venta[i].can_devueltos) - parseInt(arr_backup[i].can_devueltos);
                can_ub = can * parseInt(arr_detalle_venta[i].can_ub);
                if (arr_detalle_venta[i].flagDescu == 1 && arr_detalle_venta[i].impo_descu == 0)
                    flag_des = 1;

                if (arr_detalle_venta[i].flagPromo == 1)
                    flag_pro = 1;

                if (flagp == 0) {
                    cadena = cadena + "{'itemVenta':'" + arr_detalle_venta[i].itemVenta + "','codProducto':'" + arr_detalle_venta[i].codProducto + "','cantidad':'" + can + "','cantidad_ub':'" + can_ub + "', 'flag_des':'" + flag_des + "', 'flag_pro':'" + flag_pro + "'}";
                } else {
                    cadena = cadena + ",{'itemVenta':'" + arr_detalle_venta[i].itemVenta + "','codProducto':'" + arr_detalle_venta[i].codProducto + "','cantidad':'" + can + "','cantidad_ub':'" + can_ub + "', 'flag_des':'" + flag_des + "', 'flag_pro':'" + flag_pro + "'}";
                }
                flagp = flagp + 1;
            }
        }
        cadena = cadena.trim() + "]";

        var cad_data = " { 'nc': {'flagReversion': '" + flagReversion + "','codVenta':'" + codVenta + "', 'tipoVenta': '" + tipoVenta + "', 'codMotivo':'" + motivo + "','fecha':'" + fecha + "','tipo':'" + tipo + "', 'importe':'" + importe +
            "','usuario':'" + usuario + "', 'ip': '', 'mac':'', 'codSucursal':'" + codSucursal + "', 'codUsuario':'" + codUsuario + "', " + cadena + " } }"

        console.log(cad_data);

        $.ajax({
            type: "POST",
            url: "frmNotaCredito.aspx/registrarNC",
            data: cad_data,
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                //descragar(data.d.ntraNC);
                mostrarMensajeConfirmacion(data.d.ntraNC);
            }
        })

    }

    function descargarPDF(codigo) {
        $.ajax({
            type: "POST",
            url: "frmNotaCredito.aspx/generarNotaCreditoPDF",
            data: "{'codNotaCredito':'" + codigo + "'}",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                var bytes = new Uint8Array(data.d);
                enviarpdf("nota_credito_" + codigo + "_.pdf", bytes);
                generacionPDFCorrecta();
            }
        })
    }

    function enviarpdf(nomPdf, datos) {
        var blob = new Blob([datos]);
        var link = document.createElement("a");
        link.href = window.URL.createObjectURL(blob);
        var fileName = nomPdf;
        link.download = fileName;
        link.click();
    }

    function mostrarMensajeConfirmacion(codigoNC) {
        swal({
            title: "Nota De Credito Registrada",
            text: "Se registro la nota de credito correctamente con codigo: " + codigoNC + ". ¿Desea generar impresion de la NC?",
            icon: "success",
            buttons: {
                cancel: "No",
                defeat: "Si",
            },
        })
            //Promesa que me trae el valor true al confirmar OK.
            .then((willDelete) => {
                switch (willDelete) {
                    case "cancel":
                        location.reload();
                        break;
                    case "defeat":
                        descargarPDF(codigoNC);
                        break;
                    default:
                        location.reload();
                        break;
                }
            });

        /*swal("Nota De Credito Registrada", "Se registro la nota de credito correctamente con codigo: " + codigoNC + ". ¿Desea generar impresion de la NC?", "success").then((willDelete) => {
            if (willDelete) {
                location.reload();
            } else {
                location.reload();
            }
        });*/

    }

    function generacionPDFCorrecta() {
        swal("Se genero la impresion de la nota de credito correctamente", {
            icon: "success",
        }).then((willDelete) => {
            if (willDelete) {
                location.reload();
            } else {
                location.reload();
            }
        });
    }

    function obtenerTotal(codigo) {
        var ii_total = 0;

        for (var j = 0; j < arr_detalle_venta.length; j++) {
            if (arr_detalle_venta[j].codProducto != codigo) {
                if (arr_detalle_venta[j].flag_disp == 1) {
                    ii_total = ii_total + parseFloat(arr_detalle_venta[j].can_disponible) * parseFloat(arr_detalle_venta[j].precioVenta) * parseInt(arr_detalle_venta[j].can_ub);
                }
            }
        }
        ii_total = ii_total + parseFloat(i_recargo);
        return ii_total;
    }

    function obtenerDescuento(codigo) {
        var ii_descuento = 0;

        for (var j = 0; j < arr_detalle_venta.length; j++) {
            //if (arr_detalle_venta[j].codProducto != codigo) {
            if (arr_detalle_venta[j].flag_disp == 1) {
                ii_descuento = ii_descuento + parseFloat(arr_detalle_venta[j].impo_descu);
            }
            //}
        }

        return ii_descuento;
    }

    function obtenerTotalEliminar(codigo) {
        var ii_total = 0;
        var flag = 0;

        for (var j = 0; j < arr_detalle_venta.length; j++) {
            if (arr_detalle_venta[j].codProducto == codigo) {
                if (arr_detalle_venta[j].flag_disp == 1) {
                    if (arr_detalle_venta[j].flagPromo == 9) { //genera promocion
                        flag = 1;
                    }
                }
                break;
            }
        }

        if (flag == 0) {
            for (var j = 0; j < arr_detalle_venta.length; j++) {
                if (arr_detalle_venta[j].codProducto != codigo) {
                    if (arr_detalle_venta[j].flag_disp == 1) {
                        ii_total = ii_total + parseFloat(arr_detalle_venta[j].can_disponible) * parseFloat(arr_detalle_venta[j].precioVenta) * parseInt(arr_detalle_venta[j].can_ub);
                    }
                }
            }
        } else {
            for (var j = 0; j < arr_detalle_venta.length; j++) {
                if (arr_detalle_venta[j].codProducto != codigo) {
                    if (arr_detalle_venta[j].flag_disp == 1) {
                        if (arr_detalle_venta[j].codPromo != codigo) {
                            ii_total = ii_total + parseFloat(arr_detalle_venta[j].can_disponible) * parseFloat(arr_detalle_venta[j].precioVenta) * parseInt(arr_detalle_venta[j].can_ub);
                        }
                    }
                }
            }
        }


        ii_total = ii_total + parseFloat(i_recargo);
        return ii_total;
    }

    function validarEli(codigo) {
        var tot = 0;
        var des = 0;
        tot = obtenerTotalEliminar(codigo);
        des = obtenerDescuento(codigo);

        if (tot <= des) {
            return false;
        }
        return true;
    }

    function procesoCancelar() {
        $("#btnCancelar").click(function () {
            swal({
                title: "Confirmacion para cancelar proceso",
                text: "¿Desea cancelar la nota de credito?",
                icon: "info",
                buttons: {
                    cancel: "No",
                    defeat: "Si",
                },
            })
                //Promesa que me trae el valor true al confirmar OK.
                .then((willDelete) => {
                    switch (willDelete) {
                        case "cancel":

                            break;
                        case "defeat":
                            location.reload();
                            break;
                    }
                });

        });
    }
    procesoCancelar();

});