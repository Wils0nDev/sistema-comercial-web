
$(document).ready(function () {
    //VARIABLES
    var btnEditar = '<button type="button" title="Editar" class="icon-pencil btnEditar" data-toggle="modal"  data-target="#exampleModal" ></button>'
    var btnEliminar = ' <button type="button" id="" class="icon-bin btnDelete" data-toggle="tooltip"  title="Eliminar" ></button>'

    var vendedores = $("#id_vendedor");
    var unidades = $("#id_unidad");
    var almacenes = $("#id_almacen");
    var cantidadProducto = $("#id_cantidad");
    var stockProducto = $("#id_stock");
    var precio_Producto = $("#id_precio");
    var tipoProducto = $("#id_tipoProducto");
    var documentoCliente = $("#id_documento");
    var nombreCliente = $("#id_nomCliente");
    var codigoProducto = $("#id_codProducto");
    var venta_contado = $("#id_contado");
    var venta_credito = $("#id_credito");
    var venta_boleta = $("#id_boleta");
    var venta_factura = $("#id_factura");
    //var codigoProducto = $("#id_codProducto");
    var descripcionProducto = $("#id_desProducto");

    var codigoCliente = $("#id_codCliente");
    var puntosEntrega = $("#id_puntoEntrega");
    var flagRecargo = $("#id_flag_recargo");
    var fechaEntrega = $("#id_fecha");
    var hora = $("#id_hora");
    var minutos = $("#id_minu");

    var arr_stock = new Array();
    var arr_unidad_base = new Array();
    var arr_producto = new Array();

    var items = 0;
    var codigo;

    //VARIABLES MODAL
    var M_codPro = $("#id_codProM");
    var M_desPro = $("#id_desProM");
    var M_prePro = $("#id_preProM");
    var M_stoPro = $("#id_stoProM");
    var M_almPro = $("#id_almProM");
    var M_uniPro = $("#id_uniProM");
    var M_canPro = $("#id_canProM");
    var M_btnGuardar = $("#btnGuardarM");

    //CARRITO VENTA
    var arr_carrito = new Array();

    //VARIABLES DE VENTA
    var flag_tipoVenta = 1;
    var flag_documentoVenta = 1;
    var flag_recargo = 0;

    var p_flag_recargo = 0;
    var p_igv = 0.0;
    var p_porcentaje_recargo = 0.0;


    //VARIABLES DE IMPORTE
    var total = $("#id_total");
    var subtotal = $("#id_subtotal");
    var igv = $("#id_igv");
    var recargo = $("#id_recargo");
    var descuento = $("#id_descuento");

    var i_total_salvado = 0.0;
    var i_total = 0.0;
    var i_subtotal = 0.0;
    var i_igv = 0.0;
    var i_recargo = 0.0;
    var i_descuento = 0.0;

    //VARIABLES PROMOCION
    var arr_promociones = new Array();
    var arr_regalos = new Array();

    //VARIABLES DESCUENTO
    var arr_descuentos = new Array();
    var ntra_desc = 0;

    //#############################################################################################################################
    $("#tituloMant").html("REGISTRAR PREVENTA");
    $("#btnGuardar").html("GUARDAR");
    var tipo_proceso = 1;  //1: Registrar , 2: Actualizar
    var numero_preventa = 0;
    //------------------------------------------------------------------------------------------------------------
    var vendedor_defecto = 0;
    var recibido = location.search.length;  //Si es mayor a 0, es porque se va mando desde el mantPreventa un editar
    //------------------------------------------------------------------------------------------------------------
    if (recibido > 0) { //Si es mayor a 0, se va hacer un editar
        $("#tituloMant").html("EDITAR PREVENTA");   //se cambia el titulo a editar
        $("#btnGuardar").html("ACTUALIZAR");    //Se cambia el nombre del boton a actualizar

        var milista = new Array();
        cadVariables = location.search.substring(1, location.search.length);
        arrVariables = cadVariables.split("&");
        for (i = 0; i < arrVariables.length; i++) {
            milista.push(arrVariables[i].split("="));
        }

        var npre = milista[0][1];   //obtengo el numero de preventa a editar
        numero_preventa = npre;
        tipo_proceso = 2;   //Se envia 2 al tipo de proceso, es decir se va a editar

        vendedor_defecto = milista[1][1]; //Se obtiene el vendedor que hizo la preventa

        editarObtenerdata(npre);    //Se llama a la funcion obtener datos
    }
    //#############################################################################################################################

    function validarTipoVenta() {
        venta_contado.click(function () {
            $("#id_flag_recargo").prop("checked", false);
            $("#id_flag_recargo").prop("disabled", true);
            flag_tipoVenta = 1;
            flag_recargo = 0;
            calcularTotales();
        });

        venta_credito.click(function () {
            $("#id_flag_recargo").prop("checked", true);
            $("#id_flag_recargo").prop("disabled", false);
            flag_tipoVenta = 2;
            flag_recargo = 1;
            calcularTotales();
        });
    }
    validarTipoVenta();

    function validarTipoDocumentoVenta() {
        venta_boleta.click(function () {
            flag_documentoVenta = 1;
        });

        venta_factura.click(function () {
            flag_documentoVenta = 2;
        });
    }
    validarTipoDocumentoVenta();

    function validarCheckRecargo() {
        flagRecargo.change(function () {
            if ($(this).is(':checked')) {
                flag_recargo = 1;
            } else {
                flag_recargo = 0;
            }
            calcularTotales();
        });
    }
    validarCheckRecargo();

    function addSelectVendedor(data) {
        //DESCRIPCION : Funcion para llenar la lista de opciones del select del Vendedor.
        for (var i = 0; i < data.length; i++) {
            vendedores.append("<option value=" + data[i]["ntraUsuario"] + ">" + data[i]["vendedor"] + "</option>");
        }
        //Cuando se va a editar se asigna el vendedor y se bloquea el campo--------------------------------------------------------------------------
        if (numero_preventa !== 0) {     //@#cambio
            vendedores.val(vendedor_defecto).prop("disabled", true);
        }
    }

    //PARAMETROS ################################################################

    function obtenerParametrosPreventa(){
        $.ajax({
            type: "POST",
            url: "registrarpreventa.aspx/obtenerParametrosPreventa",
            data: "{}",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                p_flag_recargo = data.d.flagRecargo;
                p_porcentaje_recargo = data.d.porcentajeRecargo;
                p_igv = data.d.igv;
            }
        })
    }
    obtenerParametrosPreventa();

    //VENDEDORES ################################################################
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

    $("#id_documento").keyup(function (event) {
        codigo = $("#id_documento").val();
        if (codigo.length == 0) {
            $("#id_nomCliente").val("");
            $("#id_tipoListaPrecio").val("");
            $("#id_codCliente").val("");
            //limpiar combo (dejando el seleccionar)
            var optionSelected = puntosEntrega.find("option");
            for (var i = 0; i < optionSelected.length; i++) {
                if (optionSelected[i].value != 0) {
                    optionSelected[i].remove();
                }
            }
        } else {
            buscarClienteDocumento(codigo);
        }
        
    });

    function buscarClienteDocumento(cadena) {
        $("#id_documento").autocomplete({
            minLength: 2,
            //delay: 500,
            source:
                function (request, response) {
                    $.ajax({
                        type: "POST",
                        url: "registrarpreventa.aspx/buscarCliente",
                        data: "{'cadena': '" + cadena + "' }",
                        contentType: 'application/json; charset=utf-8',
                        error: function (xhr, ajaxOtions, thrownError) {
                            console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
                        },
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                var obj = new Object();
                                obj.label = item.nombres;
                                obj.value = item.numDocumento;
                                obj.tipoListaPrecio = item.tipoListaPrecio;
                                obj.codCliente = item.codCliente;
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
                $("#id_documento").val(ui.item.value);
                $("#id_nomCliente").val(ui.item.label);
                $("#id_tipoListaPrecio").val(ui.item.tipoListaPrecio);
                $("#id_codCliente").val(ui.item.codCliente);

                //limpiar combo (dejando el seleccionar)
                var optionSelected = puntosEntrega.find("option");
                for (var i = 0; i < optionSelected.length; i++) {
                    if (optionSelected[i].value != 0) {
                        optionSelected[i].remove();
                    }
                 }
                listarPuntosEntrega(ui.item.codCliente)
            }
        });
    }

    $("#id_nomCliente").keyup(function (event) {
        var cad = $(this).val();
        
        if (cad.length == 0) {
            $("#id_documento").val("");
            $("#id_tipoListaPrecio").val("");
            $("#id_codCliente").val("");
            $("#id_desProducto").prop("disabled", true);
            //limpiar combo (dejando el seleccionar)
            var optionSelected = puntosEntrega.find("option");
            for (var i = 0; i < optionSelected.length; i++) {
                if (optionSelected[i].value != 0) {
                    optionSelected[i].remove();
                }
            }
        } else {
            buscarClienteNombre(cad);
        }

    });

    function buscarClienteNombre(cadena) {
        $("#id_nomCliente").autocomplete({
            minLength: 2,
            //delay: 500,
            source:
                function (request, response) {
                    $.ajax({
                        type: "POST",
                        url: "registrarpreventa.aspx/buscarCliente",
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
                                obj.tipoListaPrecio = item.tipoListaPrecio;
                                obj.codCliente = item.codCliente;
                                obj.numDocumento = item.numDocumento;
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
                $("#id_desProducto").prop("disabled", false);
                $("#id_documento").val(ui.item.numDocumento);
                $("#id_nomCliente").val(ui.item.value);
                $("#id_tipoListaPrecio").val(ui.item.tipoListaPrecio);
                $("#id_codCliente").val(ui.item.codCliente);

                //limpiar combo (dejando el seleccionar)
                var optionSelected = puntosEntrega.find("option");
                for (var i = 0; i < optionSelected.length; i++) {
                    if (optionSelected[i].value != 0) {
                        optionSelected[i].remove();
                    }
                }

                listarPuntosEntrega(ui.item.codCliente)
            }
        });
    }

    function addSelectPuntosEntrega(data) {
        //DESCRIPCION : Funcion para llenar la lista de opciones del select de puntos de entrega.
        for (var i = 0; i < data.length; i++) {
            puntosEntrega.append("<option value=" + data[i]["codPuntoEntrega"] + ">" + data[i]["descripcion"] + "</option>");
        }
        data = [];
        
    }

    //LISTAR PUNTOS ENTREGA
    function listarPuntosEntrega(codPersona) {
        
        //DESCRIPCION : Funcion que me trae la lista de vendedores
        $.ajax({
            type: "POST",
            url: "registrarpreventa.aspx/listarPuntosEntregaCliente",
            data: "{'codCliente': '" + codPersona + "' }",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                addSelectPuntosEntrega(data.d);
            }
        })

    }


    //PRODUCTOS ####################################################################

    function verificarCliente() {
        $("#id_desProducto").focus(function () {
            var a = documentoCliente.val();
            if (a == "") {
                alert("Debe seleccionar un cliente");
                descripcionProducto.focus();
            }
        });
    }
    //verificarCliente()
    
    $("#id_codProducto").keyup(function (event) {
        codigo = $("#id_codProducto").val();
        if (codigo.length == 0) {
            $("#id_desProducto").val("");
        } else {
            buscarProductoCodigo(codigo);
        }

    });

    function buscarProductoCodigo(cadena) {
        $("#id_codProducto").autocomplete({
            minLength: 2,
            source:
                function (request, response) {
                    $.ajax({
                        type: "POST",
                        url: "registrarpreventa.aspx/listarProductos",
                        data: "{'cadena': '" + cadena + "' }",
                        contentType: 'application/json; charset=utf-8',
                        error: function (xhr, ajaxOtions, thrownError) {
                            console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
                        },
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                var obj = new Object();
                                obj.label = item.descripcion;
                                obj.value = item.codProducto;
                                return obj;
                            }));
                        }

                    });
                },
            select: function (event, ui) {
                $("#id_codProducto").val(ui.item.value);
                $("#id_desProducto").val(ui.item.label);

                //limpiar combo (dejando el seleccionar)
                var optionSelected = unidades.find("option");
                for (var i = 0; i < optionSelected.length; i++) {
                    if (optionSelected[i].value != 0) {
                        optionSelected[i].remove();
                    }
                }

                optionSelected = almacenes.find("option");
                for (var i = 0; i < optionSelected.length; i++) {
                    if (optionSelected[i].value != 0) {
                        optionSelected[i].remove();
                    }
                }

                var a = $("#id_tipoListaPrecio").val();
                precioProducto(ui.item.value, a);
                presentacionProducto(ui.item.value);
                almacenProducto(ui.item.value);
            }
        });
    }

    $("#id_desProducto").keyup(function (event) {
        codigo = $("#id_desProducto").val();
        if (codigo.length == 0) {
            //$("#id_codProducto").val("");
            limpiarDatosSeleccionProducto();
        } else {
            buscarProductoDesc(codigo);
        }

    });

    function buscarProductoDesc(cadena) {
        $("#id_desProducto").autocomplete({
            minLength: 2,
            source:
                function (request, response) {
                    $.ajax({
                        type: "POST",
                        url: "registrarpreventa.aspx/listarProductos",
                        data: "{'cadena': '" + cadena + "' }",
                        contentType: 'application/json; charset=utf-8',
                        error: function (xhr, ajaxOtions, thrownError) {
                            console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
                        },
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                var obj = new Object();
                                obj.label = item.descripcion;
                                obj.value = item.descripcion;
                                obj.codProducto = item.codProducto;
                                return obj;
                            }));
                        }

                    });
                },
            select: function (event, ui) {
                var flag = 0;
                var cod = ui.item.codProducto;
                arr_producto.forEach(function (elemento, indice, array) {
                    if (elemento.val == cod) {
                        flag = 1;
                    }
                });
                if (flag == 1) {
                    swal("Producto ya se agrego al carrito", {
                        icon: "info"
                    });
                    //alert("Producto ya se agrego al carrito");
                    /*ui.item.codProducto.val("");
                    ui.item.value.val("");
                    ui.item.value.label("");*/
                    descripcionProducto.val("");
                    //descripcionProducto.focus();
                } else {
                    $("#id_codProducto").val(ui.item.codProducto);
                    $("#id_desProducto").val(ui.item.value);

                    //limpiar combo (dejando el seleccionar)
                    var optionSelected = unidades.find("option");
                    for (var i = 0; i < optionSelected.length; i++) {
                        if (optionSelected[i].value != 0) {
                            optionSelected[i].remove();
                        }
                    }

                    optionSelected = almacenes.find("option");
                    for (var i = 0; i < optionSelected.length; i++) {
                        if (optionSelected[i].value != 0) {
                            optionSelected[i].remove();
                        }
                    }

                    var a = $("#id_tipoListaPrecio").val();
                    precioProducto(ui.item.codProducto, a);
                    presentacionProducto(ui.item.codProducto);
                    almacenProducto(ui.item.codProducto);
                    buscarPromociones();
                    buscarDescuentos();
                }

                
            }
        });
    }
    
    function precioProducto(codProducto, tipoListaPrecio) {
        //DESCRIPCION : Funcion que me trae la lista de vendedores
        $.ajax({
            type: "POST",
            url: "registrarpreventa.aspx/precioProducto",
            data: "{'codProducto': '" + codProducto + "', 'tipoListaPrecio': '" + tipoListaPrecio + "' }",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                $("#id_precio").val(parseFloat(Math.round(parseFloat(data.d.precio) * 100) / 100).toFixed(2)); //Math.round(parseFloat(data.d.precio) * 100) / 100).toFixed(2);
                $("#id_tipoProducto").val(data.d.tipoProducto);
            }
        })

    }

    function cargarComboUnidades(data) {
        //DESCRIPCION : Funcion para llenar la lista de opciones del select unidades
        var obj = new Object();
        arr_unidad_base = new Array();
        for (var i = 0; i < data.length; i++) {
            obj = new Object();
            unidades.append("<option value=" + data[i]["codPresentacion"] + ">" + data[i]["descripcion"] + "</option>");
            obj.val = data[i]["codPresentacion"];
            obj.cantidad = data[i]["cantidadUnidadBase"];
            arr_unidad_base.push(obj);
        }
    }

    function presentacionProducto(codProducto) {
        //DESCRIPCION : Funcion que me trae la lista de vendedores
        $.ajax({
            type: "POST",
            url: "registrarpreventa.aspx/presentacionProductos",
            data: "{'codProducto': '" + codProducto + "' }",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                cargarComboUnidades(data.d);
            }
        })

    }

    
    function cargarComboAlmacenes(data) {
        //DESCRIPCION : Funcion para llenar la lista de opciones del select unidades
        var obj = new Object();
        for (var i = 0; i < data.length; i++) {
            obj = new Object();
            almacenes.append("<option value=" + data[i]["codAlmacen"] + ">" + data[i]["descripcion"] + "</option>");
            obj.val = data[i]["codAlmacen"];
            obj.stock = data[i]["stock"];
            arr_stock.push(obj);
        }
    }

    function almacenProducto(codProducto) {
        //DESCRIPCION : Funcion que me trae la lista de almacenes
        $.ajax({
            type: "POST",
            url: "registrarpreventa.aspx/almacenProductos",
            data: "{'codProducto': '" + codProducto + "' }",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                cargarComboAlmacenes(data.d);
            }
        })

    }

    function seleccionarAlmacen() {
        almacenes.change(function () {
            cantidadProducto.val(1);
            var optionSelected = $(this).find("option:selected");
            var valueSelected = optionSelected.val();
            var flag = 0;
            arr_stock.forEach(function (elemento, indice, array) {
                if (elemento.val == valueSelected) {
                    $("#id_stock").val(elemento.stock);
                    flag = 1;
                }
            });
            if (flag == 0) {
                $("#id_stock").val("");
            }

            var flaga = 0;
            var flagb = 0;

            optionSelected = almacenes.find("option:selected");
            flaga = optionSelected.val();

            optionSelected = unidades.find("option:selected");
            flagb = optionSelected.val();

            if (flaga == 0) {
                deshabilitarPromociones();
            } else {
                if (flagb == 0) {
                    deshabilitarPromociones();
                } else {
                    promocionesActivadas();
                }
            }
                

            /*optionSelected = unidades.find("option:selected");
            valueSelected = optionSelected.val();
            if (flag == 1 && valueSelected != 0) {
                promocionesActivadas();
            }*/

        });
    }
    seleccionarAlmacen()

    function seleccionarUnidad() {
        unidades.change(function () {
            cantidadProducto.val(1);

            var flaga = 0;
            var flagb = 0;

            optionSelected = almacenes.find("option:selected");
            flaga = optionSelected.val();

            optionSelected = unidades.find("option:selected");
            flagb = optionSelected.val();

            if (flagb == 0) {
                deshabilitarPromociones();
            } else {
                if (flaga == 0) {
                    deshabilitarPromociones();
                } else {
                    promocionesActivadas();
                }
            }

        });
    }
    seleccionarUnidad()

    function cantidadProductos() {
        cantidadProducto.change(function () {
            var optionSelected = almacenes.find("option:selected");
            var valueSelected = optionSelected.val();

            var a = cantidadProducto.val();
            var b = stockProducto.val();
            var can_uni_base = 0;

            if (valueSelected == 0) {
                swal("Debe seleccionar un almacen", {
                    icon: "info"
                });
                //alert("Debe seleccionar un almacen");
                cantidadProducto.val(1);
                almacenes.focus();
            } else {
                optionSelected = unidades.find("option:selected");
                valueSelected = optionSelected.val();

                if (valueSelected == 0) {
                    swal("Debe seleccionar la unidad", {
                        icon: "info"
                    });
                    //alert("Debe seleccionar la unidad");
                    cantidadProducto.val(1);
                    unidades.focus();
                } else {
                    a = parseInt(a, 10);
                    b = parseInt(b, 10);

                    if (a < 1) {
                        cantidadProducto.val(1)
                    }

                    if (b != "") {
                        optionSelected = unidades.find("option:selected");
                        valueSelected = optionSelected.val();
                        arr_unidad_base.forEach(function (elemento, indice, array) {
                            if (elemento.val == valueSelected) {
                                can_uni_base = elemento.cantidad;
                            }
                        });
                        //can_uni_base = can_uni_base * cantidad.val();

                        if (a * can_uni_base > b) {
                            cantidadProducto.val(a-1);
                        }
                    }
                    promocionesActivadas();
                    


                }
            }
            
        });
    }
    cantidadProductos()

    //CARRITO DE VENTA ##############################################################################
    $('#id_carrito').DataTable({
        paging: false,
        ordering: false,
        info: false,
        language: {
            lengthMenu: "Mostrar _MENU_ registros",
            zeroRecords: "No hay productos agregados",
            info: "Mostrando la página _PAGE_ de _PAGES_",
            infoEmpty: "No hay registros disponibles.",
            infoFiltered: "(filtered from _MAX_ total records)",
            search: "Busqueda rapida: "
        },
        columnDefs: [
            {
                "width": "1%",
                "targets": [0,3]
            },
            {
                "width": "1%",
                "targets": [10, 13]
            },
            {
                "targets": [4],
                "visible": false,
                "searchable": false
            },
            {
                "targets": [7],
                "visible": false,
                "searchable": false
            },
            {
                "targets": [9],
                "visible": false,
                "searchable": false
            },
            {
                "targets": [12],
                "visible": false,
                "searchable": false
            }
        ]
    });



    var tabla = $("#id_carrito").dataTable(); //funcion jquery
    var table = $("#id_carrito").DataTable(); //funcion DataTable-libreria
    table.columns.adjust().draw();

    var codPro = $("#id_codProducto");
    var desPro = $("#id_desProducto");
    var cantidad = $("#id_cantidad");
    var stock = $("#id_stock");
    var precio = $("#id_precio");

    function obtenerData() {
        //obtener cantidad en unidades base
        var can_uni_base = 0;
        var des_almacen = "";
        var des_unidad = "";
        var des_tipo_pro = "";
        var obj = new Object();
        var objcarrito = new Object();

        var tipo = 1; // parseInt(tipoProducto.val(), 10);
        if (ntra_desc != 0) {
            tipo = 2;
            
        }
        //tipoProducto
        if (tipo == 1) {
            des_tipo_pro = "NORMAL"
        } else {
            if (tipo == 2) {
                des_tipo_pro = "DESCUENTO"
            }
        }

        var optionSelected = $("#id_unidad").find("option:selected");
        var valueSelected = optionSelected.val();
        des_unidad = optionSelected.text();
        arr_unidad_base.forEach(function (elemento, indice, array) {
            if (elemento.val == valueSelected) {
                can_uni_base = elemento.cantidad;
            }
        });
        can_uni_base = can_uni_base * parseInt(cantidad.val()); 

        var descu = 0;
        if (ntra_desc != 0) {
            arr_descuentos.forEach(function (elemento, indice, array) {
                if (elemento.ntra == ntra_desc) {
                    if (elemento.tipoDescuento == 1) {
                        descu = parseFloat(elemento.valorDescuento);
                    } else {
                        descu =  can_uni_base * parseFloat(precio.val()) * parseFloat(elemento.valorDescuento) / 100;
                    }
                }
            });
            i_descuento = i_descuento + descu;
        }

        //descripcion almacen seleccionado
        optionSelected = $("#id_almacen").find("option:selected");
        des_almacen = optionSelected.text();

        items = items + 1;

        i_total = i_total + (can_uni_base * precio.val()) - descu;
        i_total_salvado = i_total_salvado + (can_uni_base * precio.val()) - descu;
        //i_total = i_total - i_descuento;
        calcularTotales();
        //llenar tabla
        /*tabla.fnAddData([
            items,   //ITEM
            codPro.val(),   //CODIGO PRODUCTO
            desPro.val(),   //DESCRICION PROD
            cantidad.val(), //CANTIDAD
            can_uni_base,       //CANTIDAD UNIDAD BASE
            parseFloat(Math.round(parseFloat(precio.val()) * 100) / 100).toFixed(2),   //PRECIO
            des_almacen, //ALMACEN
            almacenes.val(),  //CODIGO ALMACEN
            des_unidad,     //UNIDAD
            unidades.val(), //CODIGO DE UNIDAD
            parseFloat(Math.round(parseFloat(cantidad.val() * can_uni_base * precio.val()) * 100) / 100).toFixed(2), //SUBTOTAL
            des_tipo_pro,   //TIPO PRODUCTO
            tipoProducto.val(), //CODIGO TIPO PRODUCTO
            btnEditar + btnEliminar
        ]);*/

        objcarrito.item = items;   //ITEM
        objcarrito.codPro = codPro.val();   //CODIGO PRODUCTO
        objcarrito.desPro = desPro.val();   //DESCRICION PROD
        objcarrito.cantidad = cantidad.val(); //CANTIDAD
        objcarrito.cantidadUB = can_uni_base;       //CANTIDAD UNIDAD BASE
        objcarrito.precio = parseFloat(Math.round(parseFloat(precio.val()) * 100) / 100).toFixed(2);   //PRECIO
        objcarrito.desAlmacen = des_almacen; //ALMACEN
        objcarrito.codAlmacen = almacenes.val();  //CODIGO ALMACEN
        objcarrito.desUnidad = des_unidad;     //UNIDAD
        objcarrito.codUnidad = unidades.val(); //CODIGO DE UNIDAD
        objcarrito.subTotal = parseFloat(Math.round(parseFloat(can_uni_base * precio.val()) * 100) / 100).toFixed(2); //SUBTOTAL
        objcarrito.desTipoProducto = des_tipo_pro;   //TIPO PRODUCTO
        objcarrito.tipoProducto = tipo; //CODIGO TIPO PRODUCTO
        objcarrito.accion = btnEliminar; //ACCION btnEditar + 
        objcarrito.flagPromo = 0; //ACCION
        objcarrito.codPromo = codPro.val(); //ACCION

        objcarrito.cod_promocion = 0;
        objcarrito.item_preventa = 0;

        if (ntra_desc != 0) {
            objcarrito.flagDescu = 1;
            objcarrito.impoDescu = descu;
            objcarrito.cod_descuento = ntra_desc;
        } else {
            objcarrito.flagDescu = 0;
            objcarrito.impoDescu = 0;
            objcarrito.cod_descuento = 0;
        }
        
        arr_carrito.push(objcarrito);

        //llenar array productos
        obj.val = codPro.val();
        arr_producto.push(obj);
        addRowDT(objcarrito);
        ntra_desc = 0;
    }

    //ADDROW COMENTADO ORIGINAL
    /*
    function addRowDT() {
        //obtener cantidad en unidades base
        var can_uni_base = 0;
        var des_almacen = "";
        var des_unidad = "";
        var des_tipo_pro = "";
        var obj = new Object();
        var objcarrito = new Object();

        var tipo = parseInt(tipoProducto.val(), 10);
        //tipoProducto
        if (tipo == 1) {
            des_tipo_pro = "NORMAL"
        } else {
            if (tipo == 2) {
                des_tipo_pro = "PROMOCION"
            }
        }

        var optionSelected = $("#id_unidad").find("option:selected");
        var valueSelected = optionSelected.val();
        des_unidad = optionSelected.text();
        arr_unidad_base.forEach(function (elemento, indice, array) {
            if (elemento.val == valueSelected) {
                can_uni_base = elemento.cantidad;
            }
        });
        //can_uni_base = can_uni_base * cantidad.val();

        //descripcion almacen seleccionado
        optionSelected = $("#id_almacen").find("option:selected");
        des_almacen = optionSelected.text();

        items = items + 1;

        i_total = i_total + (cantidad.val() * can_uni_base * precio.val());
        i_total_salvado = i_total_salvado + (cantidad.val() * can_uni_base * precio.val());
        calcularTotales();
        //llenar tabla
        tabla.fnAddData([
            items,   //ITEM
            codPro.val(),   //CODIGO PRODUCTO
            desPro.val(),   //DESCRICION PROD
            cantidad.val(), //CANTIDAD
            can_uni_base,       //CANTIDAD UNIDAD BASE
            parseFloat(Math.round(parseFloat(precio.val()) * 100) / 100).toFixed(2),   //PRECIO
            des_almacen, //ALMACEN
            almacenes.val(),  //CODIGO ALMACEN
            des_unidad,     //UNIDAD
            unidades.val(), //CODIGO DE UNIDAD
            parseFloat(Math.round(parseFloat(cantidad.val() * can_uni_base * precio.val()) * 100) / 100).toFixed(2), //SUBTOTAL
            des_tipo_pro,   //TIPO PRODUCTO
            tipoProducto.val(), //CODIGO TIPO PRODUCTO
            btnEditar + btnEliminar
        ]);

        objcarrito.item = items;   //ITEM
        objcarrito.codPro = codPro.val();   //CODIGO PRODUCTO
        objcarrito.desPro = desPro.val();   //DESCRICION PROD
        objcarrito.cantidad = cantidad.val(); //CANTIDAD
        objcarrito.cantidadUB = can_uni_base;       //CANTIDAD UNIDAD BASE
        objcarrito.precio = parseFloat(Math.round(parseFloat(precio.val()) * 100) / 100).toFixed(2);   //PRECIO
        objcarrito.desAlmacen = des_almacen; //ALMACEN
        objcarrito.codAlmacen = almacenes.val();  //CODIGO ALMACEN
        objcarrito.desUnidad = des_unidad;     //UNIDAD
        objcarrito.codUnidad = unidades.val(); //CODIGO DE UNIDAD
        objcarrito.subTotal = parseFloat(Math.round(parseFloat(cantidad.val() * can_uni_base * precio.val()) * 100) / 100).toFixed(2); //SUBTOTAL
        objcarrito.desTipoProducto = des_tipo_pro;   //TIPO PRODUCTO
        objcarrito.tipoProducto = tipoProducto.val(); //CODIGO TIPO PRODUCTO
        //objcarrito.accion = btnEditar + btnEliminar; //ACCION
        arr_carrito.push(objcarrito);

        //llenar array productos
        obj.val = codPro.val();
        arr_producto.push(obj);

        $(".btnEditar").click(function () {
            
            //var M_codPro = $("#id_codProM");
            //var M_desPro = $("#id_desProM");
            //var M_prePro = $("#id_preProM");
            //var M_stoPro = $("#id_stoProM");
            //var M_almPro = $("#id_almProM");
            //var M_uniPro = $("#id_uniProM");
            //var M_canPro = $("#id_canProM");
             
            var optionSelected = M_uniPro.find("option");
            for (var i = 0; i < optionSelected.length; i++) {
                if (optionSelected[i].value != 0) {
                    optionSelected[i].remove();
                }
            }

            optionSelected = M_almPro.find("option");
            for (var i = 0; i < optionSelected.length; i++) {
                if (optionSelected[i].value != 0) {
                    optionSelected[i].remove();
                }
            }

            var tr = $(this).parent().parent(); //obtengo el padre(td) del padre (tr) del boton 
            presentacionProductoModal(table.row(tr).data()[1], table.row(tr).data()[9]);
            almacenProductoModal(table.row(tr).data()[1], table.row(tr).data()[7]);
            M_codPro.val(table.row(tr).data()[1]);
            M_desPro.val(table.row(tr).data()[2]);
            M_prePro.val(table.row(tr).data()[5]);
            M_canPro.val(table.row(tr).data()[3]);
            //M_btnGuardar.css("display", "none");

        });

        $(".btnDelete").click(function () {
            //Obtengo los valores de mi tr seleccionado.
            var tr = $(this).parent().parent();
            
            swal({
                title: "Se eliminara el producto",
                text: "¿Esta seguro que desea eliminar el producto?",
                icon: "warning",
                buttons: true,
                dangerMode: true,
            })
            //Promesa que me trae el valor true al confirmar OK.
                .then((willDelete) => {
                    if (willDelete) {
                        swal("Se elimino el producto", {
                            icon: "success",
                        });

                        var cod = tr[0].cells[1].innerText;
                        var i = 0;
                        arr_producto.forEach(function (elemento, indice, array) {
                            if (elemento.val == cod) {
                                arr_producto.splice(indice, 1);
                            }
                        });
                        //quitar producto
                        arr_carrito.forEach(function (elemento, indice, array) {
                            if (elemento.codPro == cod) {
                                arr_carrito.splice(indice, 1);
                                i = elemento.item;
                            }
                        });
                        //disminuir item
                        arr_carrito.forEach(function (elemento, indice, array) {
                            if (elemento.item > i) {
                                arr_carrito[indice].item = elemento.item - 1;
                            }
                        });
                        items = items - 1;

                        i_total_salvado = i_total_salvado - parseFloat(tr[0].cells[7].innerText);
                        calcularTotales();
                        recargarTabla();
                        
                       
                    } else {
                        swal("Se Cancelo la eliminacion");
                    }
                });
        });
    }
    */

    function addRowDT(data) {
        //obtener cantidad en unidades base
        
        //llenar tabla
        tabla.fnAddData([
            data.item,
            data.codPro,
            data.desPro,
            data.cantidad,
            data.cantidadUB,
            data.precio,
            data.desAlmacen,
            data.codAlmacen,
            data.desUnidad,
            data.codUnidad,
            data.subTotal,
            data.desTipoProducto,
            data.tipoProducto,
            data.accion
        ]);

        $(".btnEditar").click(function () {

            //var M_codPro = $("#id_codProM");
            //var M_desPro = $("#id_desProM");
            //var M_prePro = $("#id_preProM");
            //var M_stoPro = $("#id_stoProM");
            //var M_almPro = $("#id_almProM");
            //var M_uniPro = $("#id_uniProM");
            //var M_canPro = $("#id_canProM");

            var optionSelected = M_uniPro.find("option");
            for (var i = 0; i < optionSelected.length; i++) {
                if (optionSelected[i].value != 0) {
                    optionSelected[i].remove();
                }
            }

            optionSelected = M_almPro.find("option");
            for (var i = 0; i < optionSelected.length; i++) {
                if (optionSelected[i].value != 0) {
                    optionSelected[i].remove();
                }
            }

            var tr = $(this).parent().parent(); //obtengo el padre(td) del padre (tr) del boton 
            presentacionProductoModal(table.row(tr).data()[1], table.row(tr).data()[9]);
            almacenProductoModal(table.row(tr).data()[1], table.row(tr).data()[7]);
            M_codPro.val(table.row(tr).data()[1]);
            M_desPro.val(table.row(tr).data()[2]);
            M_prePro.val(table.row(tr).data()[5]);
            M_canPro.val(table.row(tr).data()[3]);
            //M_btnGuardar.css("display", "none");

        });

        $(".btnDelete").click(function () {
            //Obtengo los valores de mi tr seleccionado.
            var tr = $(this).parent().parent();

            swal({
                title: "Se eliminara el producto",
                text: "¿Esta seguro que desea eliminar el producto?",
                icon: "warning",
                buttons: true,
                dangerMode: true,
            })
                //Promesa que me trae el valor true al confirmar OK.
                .then((willDelete) => {
                    if (willDelete) {
                        swal("Se elimino el producto", {
                            icon: "success",
                        });

                        var cod = tr[0].cells[1].innerText;
                        var i = 0;
                        //
                        //var tipo = parseInt(table.row(tr).data()[13]);
                        var flag = 0;
                        var contPro = 1;
                        var mon = 0.0;
                        var ind = 0;
                        var des = 0.0;
                        //quitar producto
                        //console.log(arr_carrito);
                        arr_carrito.forEach(function (elemento, indice, array) {
                            //console.log(indice + "E");
                            if (elemento.codPro == cod) {
                                //console.log(indice + "E2");
                                mon = mon + parseFloat(elemento.subTotal);
                                des = des + parseFloat(elemento.impoDescu);
                                arr_carrito.splice(indice, 1);
                                i = elemento.item;
                                ind = indice;
                                if (elemento.flagPromo == 0) { //producto genera promocion
                                    flag = 1;
                                }
                            }
                        });

                        if (flag == 1) {
                            arr_carrito.forEach(function (elemento, indice, array) {
                                //console.log(indice);
                                if (elemento.codPromo == cod) {
                                    //console.log(indice + "AA")
                                    mon = mon + parseFloat(elemento.subTotal);
                                    //arr_carrito.splice(indice, 1);
                                    contPro = contPro + 1;
                                }
                            });
                            arr_carrito.splice(ind, (contPro - 1));
                        }
                        //
                        //quitar producto de array de productos agregados ppor busqueda al carrito
                        arr_producto.forEach(function (elemento, indice, array) {
                            if (elemento.val == cod) {
                                arr_producto.splice(indice, 1);
                            }
                        });
                        /*//quitar producto
                        arr_carrito.forEach(function (elemento, indice, array) {
                            if (elemento.codPro == cod) {
                                arr_carrito.splice(indice, 1);
                                i = elemento.item;
                            }
                        });*/
                        //disminuir item
                        arr_carrito.forEach(function (elemento, indice, array) {
                            if (elemento.item > i) {
                                arr_carrito[indice].item = elemento.item - contPro;
                            }
                        });
                        items = items - contPro;

                        i_total_salvado = i_total_salvado - parseFloat(mon) + des;
                        i_descuento = i_descuento - des;
                        calcularTotales();
                        recargarTabla();

                    } else {
                        swal("Se Cancelo la eliminacion", {
                            icon: "info"
                        });
                    }
                });
        });
    }

    function recargarTabla() {
        table.clear().draw();
        arr_carrito.forEach(function (elemento, indice, array) {
            tabla.fnAddData([
                elemento.item,
                elemento.codPro,
                elemento.desPro,
                elemento.cantidad,
                elemento.cantidadUB,
                elemento.precio,
                elemento.desAlmacen,
                elemento.codAlmacen,
                elemento.desUnidad,
                elemento.codUnidad,
                elemento.subTotal,
                elemento.desTipoProducto,
                elemento.tipoProducto,
                //btnEditar + btnEliminar
                elemento.accion
            ]);
        });

        $(".btnEditar").click(function () {
            
            //var M_codPro = $("#id_codProM");
            //var M_desPro = $("#id_desProM");
            //var M_prePro = $("#id_preProM");
            //var M_stoPro = $("#id_stoProM");
            //var M_almPro = $("#id_almProM");
            //var M_uniPro = $("#id_uniProM");
            //var M_canPro = $("#id_canProM");
             
            var optionSelected = M_uniPro.find("option");
            for (var i = 0; i < optionSelected.length; i++) {
                if (optionSelected[i].value != 0) {
                    optionSelected[i].remove();
                }
            }

            optionSelected = M_almPro.find("option");
            for (var i = 0; i < optionSelected.length; i++) {
                if (optionSelected[i].value != 0) {
                    optionSelected[i].remove();
                }
            }

            var tr = $(this).parent().parent(); //obtengo el padre(td) del padre (tr) del boton 
            presentacionProductoModal(table.row(tr).data()[1], table.row(tr).data()[9]);
            almacenProductoModal(table.row(tr).data()[1], table.row(tr).data()[7]);
            M_codPro.val(table.row(tr).data()[1]);
            M_desPro.val(table.row(tr).data()[2]);
            M_prePro.val(table.row(tr).data()[5]);
            M_canPro.val(table.row(tr).data()[3]);


        });

        $(".btnDelete").click(function () {
            //Obtengo los valores de mi tr seleccionado.
            var tr = $(this).parent().parent();

            swal({
                title: "Se eliminara el producto",
                text: "¿Esta seguro que desea eliminar el producto?",
                icon: "warning",
                buttons: true,
                dangerMode: true,
            })
                //Promesa que me trae el valor true al confirmar OK.
                .then((willDelete) => {
                    if (willDelete) {
                        swal("Se elimino el producto", {
                            icon: "success",
                        });

                        var cod = tr[0].cells[1].innerText;
                        var i = 0;
                        //
                        //var tipo = parseInt(table.row(tr).data()[13]);
                        var flag = 0;
                        var contPro = 1;
                        var mon = 0.0;
                        var ind = 0;
                        var des = 0.0;
                        //quitar producto
                        //console.log(arr_carrito);
                        arr_carrito.forEach(function (elemento, indice, array) {
                            //console.log(indice + "E");
                            if (elemento.codPro == cod) {
                                //console.log(indice + "E2");
                                mon = mon + parseFloat(elemento.subTotal);
                                des = des + parseFloat(elemento.impoDescu);
                                arr_carrito.splice(indice, 1);
                                i = elemento.item;
                                ind = indice;
                                if (elemento.flagPromo == 0) { //producto genera promocion
                                    flag = 1;
                                }
                            }
                        });

                        if (flag == 1) {
                            arr_carrito.forEach(function (elemento, indice, array) {
                                //console.log(indice);
                                if (elemento.codPromo == cod) {
                                    //console.log(indice + "AA")
                                    mon = mon + parseFloat(elemento.subTotal);
                                    //arr_carrito.splice(indice, 1);
                                    contPro = contPro + 1;
                                }
                            });
                            arr_carrito.splice(ind, (contPro - 1));
                        }
                        //
                        //quitar producto de array de productos agregados ppor busqueda al carrito
                        arr_producto.forEach(function (elemento, indice, array) {
                            if (elemento.val == cod) {
                                arr_producto.splice(indice, 1);
                            }
                        });
                        /*//quitar producto
                        arr_carrito.forEach(function (elemento, indice, array) {
                            if (elemento.codPro == cod) {
                                arr_carrito.splice(indice, 1);
                                i = elemento.item;
                            }
                        });*/
                        //disminuir item
                        arr_carrito.forEach(function (elemento, indice, array) {
                            if (elemento.item > i) {
                                arr_carrito[indice].item = elemento.item - contPro;
                            }
                        });
                        items = items - contPro;

                        i_total_salvado = i_total_salvado - parseFloat(mon) + des;
                        i_descuento = i_descuento - des;
                        calcularTotales();
                        recargarTabla();

                    } else {
                        swal("Se Cancelo la eliminacion", {
                            icon: "info"
                        });
                    }
                });
        });
    }


    $("#id_btnAgregar").click(function () {
        var doc = documentoCliente.val();
        var pro = codigoProducto.val();

        var optionSelected = almacenes.find("option:selected");
        var valueSelected = optionSelected.val();

        if (doc.length == 0) {
            swal("Debe seleccionar un cliente", {
                icon: "info"
            });
            //alert("Debe seleccionar un cliente");
            nombreCliente.focus();
        } else {
            if (pro.length == 0) {
                swal("Debe seleccionar un producto", {
                    icon: "info"
                });
                //alert("Debe seleccionar un producto");
                descripcionProducto.focus();
            } else {
                if (valueSelected == 0) {
                    swal("Debe seleccionar el almacen", {
                        icon: "info"
                    });
                    //alert("Debe seleccionar el almacen");
                    almacenes.focus();
                } else {
                    optionSelected = unidades.find("option:selected");
                    valueSelected = optionSelected.val();
                    if (valueSelected == 0) {
                        swal("Debe seleccionar la unidad", {
                            icon: "info"
                        });
                        //alert("Debe seleccionar la unidad");
                        unidades.focus();
                    } else {
                        
                        //addRowDT();
                        ntra_desc = 0;
                        if ($("#formulario input[name='descuentos']:radio").is(':checked')) {
                            ntra_desc = $('input:radio[name=descuentos]:checked').val()
                            //var c = $("#id_codProducto").val();
                            //obtenerProductosRegalo(parseInt(ntra), c);
                        }
                        obtenerData();
                        if ($("#formulario input[name='promociones']:radio").is(':checked')) {
                            var ntra = $('input:radio[name=promociones]:checked').val()
                            var c = $("#id_codProducto").val();
                            obtenerProductosRegalo(parseInt(ntra), c);
                        }
                        limpiarDatosProducto();
                    }
                }
            }
        }
        
    });

    /*function agregarProducto() {
        //verificar si producto ya esta agregado
        var flag = 0;
        arr_producto.forEach(function (elemento, indice, array) {
            if (elemento.val == codPro.val()) {
                flag = 1;
            }
        });
        if (flag == 1) {
            alert("Producto ya se agrego al carrito");
            descripcionProducto.val("");
            descripcionProducto.focus();
        } else {

        }
    }*/

    function limpiarDatosSeleccionProducto() {
        //descripcionProducto.val("");
        codigoProducto.val("");
        stockProducto.val("");
        tipoProducto.val("");
        precio_Producto.val("");
        cantidadProducto.val(1);

        //limpiar combo (dejando el seleccionar)
        var optionSelected = almacenes.find("option");
        for (var i = 0; i < optionSelected.length; i++) {
            if (optionSelected[i].value != 0) {
                optionSelected[i].remove();
            }
        }
        optionSelected = unidades.find("option");
        for (var i = 0; i < optionSelected.length; i++) {
            if (optionSelected[i].value != 0) {
                optionSelected[i].remove();
            }
        }
        $("#promos").empty();
        $("#dsctos").empty();
        ntra_desc = 0;
        //descripcionProducto.focus();

    }

    function limpiarDatosProducto() {
        descripcionProducto.val("");
        codigoProducto.val("");
        stockProducto.val("");
        tipoProducto.val("");
        precio_Producto.val("");
        cantidadProducto.val(1);

        //limpiar combo (dejando el seleccionar)
        var optionSelected = almacenes.find("option");
        for (var i = 0; i < optionSelected.length; i++) {
            if (optionSelected[i].value != 0) {
                optionSelected[i].remove();
            }
        }
        optionSelected = unidades.find("option");
        for (var i = 0; i < optionSelected.length; i++) {
            if (optionSelected[i].value != 0) {
                optionSelected[i].remove();
            }
        }
        $("#promos").empty();
        $("#dsctos").empty();
        ntra_desc = 0;
        descripcionProducto.focus();

    }

    function calcularTotales() {
        //calcular recargo si es venta al credito y sumarlo al total
        i_recargo = 0.0;
        if (flag_recargo == 1) {
            i_total = i_total_salvado;
            i_recargo = (i_total * p_porcentaje_recargo / 100);
            i_total = i_total + i_recargo;
        } else {
            i_recargo = 0.0;
            i_total = i_total_salvado;
        }

        //IGV
        i_igv = i_total - (i_total / (p_igv));
        //SUB TOTAL
        i_subtotal = i_total - i_igv;


        total.val(parseFloat(Math.round(i_total * 100) / 100).toFixed(2));
        subtotal.val(parseFloat(Math.round(i_subtotal * 100) / 100).toFixed(2));
        igv.val(parseFloat(Math.round(i_igv * 100) / 100).toFixed(2));
        recargo.val(parseFloat(Math.round(i_recargo * 100) / 100).toFixed(2));
        descuento.val(parseFloat(Math.round(i_descuento * 100) / 100).toFixed(2));
    }

    //GUARDAR PREVENTA ##############################################################

    function validarRegistroPreventa() {
        $("#btnGuardar").click(function () {
            var optionSelected = vendedores.find("option:selected");
            var valueSelected = optionSelected.val();

            if (valueSelected == 0) {
                //event.preventDefault();
                swal("Debe seleccionar un vendedor", {
                    icon: "error"
                });
            } else {
                if (fechaEntrega.val() == "") {
                    //event.preventDefault();
                    swal("Debe seleccionar la fecha de entrega", {
                        icon: "error"
                    });
                } else {
                    if (hora.val() == "") {
                        swal("Debe seleccionar la hora de entrega", {
                            icon: "error"
                        });
                    } else {
                        if (minutos.val() == "") {
                            swal("Debe seleccionar la hora de entrega", {
                                icon: "error"
                            });
                        } else {
                            if (documentoCliente.val() == "") {
                                //event.preventDefault();
                                swal("Debe seleccionar un cliente", {
                                    icon: "error"
                                });
                            } else {
                                optionSelected = puntosEntrega.find("option:selected");
                                valueSelected = optionSelected.val();

                                if (valueSelected == 0) {
                                    //event.preventDefault();
                                    swal("Debe seleccionar un punto de entrega", {
                                        icon: "error"
                                    });
                                } else {
                                    if (arr_carrito.length == 0) {
                                        //event.preventDefault();
                                        swal("Debe agregar productos", {
                                            icon: "error"
                                        });
                                    } else {
                                        guardarPreventa();
                                    }
                                }
                            }
                        }
                    }
                    
                }
            }
        });
    }
    validarRegistroPreventa();

    function guardarPreventa() {
        //$("#btnGuardar").click(function () {
            var obj = new Object();
            var arr_detalle = new Array();
            var cad_detalle = "";
            var cad_cabecera = "";
            var valPuntoEntrega = puntosEntrega.find("option:selected");
            var valUsuario = vendedores.find("option:selected");

            $("#id_carrito tbody tr").each(function (index) {
                obj = new Object();
                $(this).children("td").each(function (index2) {
                    /*obj.cant_unidad_base = table.row($(this)).data()[4]
                    console.log(obj.cant_unidad_base);
                    obj.codAlmacen = table.row($(this)).data()[7]
                    console.log(obj.codAlmacen);
                    obj.codUnidadB = table.row($(this)).data()[9]
                    console.log(obj.codUnidadB);
                    obj.tipoProducto = table.row($(this)).data()[12]
                    console.log(obj.tipoProducto);*/
                    switch (index2) {
                        /*
            0 items,   //ITEM
            1 codPro.val(),   //CODIGO PRODUCTO
            2 desPro.val(),   //DESCRICION PROD
            3 cantidad.val(), //CANTIDAD
            4 can_uni_base,       //CANTIDAD UNIDAD BASE
            5 parseFloat(Math.round(parseFloat(precio.val()) * 100) / 100).toFixed(2),   //PRECIO
            6 des_almacen, //ALMACEN
            7 almacenes.val(),  //CODIGO ALMACEN
            8 des_unidad,     //UNIDAD
            9 unidades.val(), //CODIGO DE UNIDAD
            10 cantidad.val() * can_uni_base * precio.val(), //SUBTOTAL
            11 des_tipo_pro,   //TIPO PRODUCTO
            12 tipoProducto.val(), //CODIGO TIPO PRODUCTO
                         */
                        case 0:
                            obj.item = $(this).text();
                            console.log(obj.item);
                            obj.cant_unidad_base = table.row($(this)).data()[4]
                            console.log(obj.cant_unidad_base);
                            obj.codAlmacen = table.row($(this)).data()[7]
                            console.log(obj.codAlmacen);
                            obj.codUnidadB = table.row($(this)).data()[9]
                            console.log(obj.codUnidadB);
                            obj.tipoProducto = table.row($(this)).data()[12]
                            console.log(obj.tipoProducto);
                            break;
                        case 1:
                            obj.codProducto = $(this).text();
                            console.log(obj.codProducto);
                            break;
                        case 3:
                            obj.cantidad = $(this).text();
                            console.log(obj.cantidad);
                            break;
                        case 4:
                            obj.precio = $(this).text();
                            console.log(obj.precio);
                            break;
                        /*default:
                            
                            break;*/
                    }
                });
                arr_detalle.push(obj);
            });

        var hour = hora.val() + ":" + minutos.val() + ":00"

        var d = new Date();
        var month = d.getMonth() + 1;
        var day = d.getDate();
        var fechaActual = (day < 10 ? '0' : '') + day + "/" + (month < 10 ? '0' : '') + month + "/" + d.getFullYear();


            var cad_promocion = "'listPrevPromocion':["
            var flagp = 0;
            arr_carrito.forEach(function (elemento, indice, array) {
                if (elemento.flagPromo == 1) {
                    if (flagp == 0) {
                        cad_promocion = cad_promocion + "{'codPreventa':'" + numero_preventa +"','codPromocion':'" + elemento.cod_promocion + "','itemPreventa':'" + elemento.item_preventa + "','itemPromocionado':'" + elemento.item + "'}";
                    } else {
                        cad_promocion = cad_promocion + ",{'codPreventa':'" + numero_preventa +"','codPromocion':'" + elemento.cod_promocion + "','itemPreventa':'" + elemento.item_preventa + "','itemPromocionado':'" + elemento.item + "'}";
                    }
                    flagp = flagp + 1;
                }
            });
            cad_promocion = cad_promocion.trim() + "]";
            console.log(cad_promocion);

            var cad_descuento = "'listPrevDescuento':["
            flagp = 0;
            arr_carrito.forEach(function (elemento, indice, array) {
                if (elemento.flagDescu == 1) {
                    if (flagp == 0) {
                        cad_descuento = cad_descuento + "{'codPreventa':'" + numero_preventa +"','codDescuento':'" + elemento.cod_descuento + "','itemPreventa':'" + elemento.item + "','importe':'" + elemento.impoDescu + "'}";
                    } else {
                        cad_descuento = cad_descuento + ",{'codPreventa':'" + numero_preventa +"','codDescuento':'" + elemento.cod_descuento + "','itemPreventa':'" + elemento.item + "','importe':'" + elemento.impoDescu + "'}";
                    }
                    flagp = flagp + 1;
                }
            });
            cad_descuento = cad_descuento.trim() + "]";
            console.log(cad_descuento);

             cad_detalle = "'listDetPreventa':["
            arr_detalle.forEach(function (elemento, indice, array) {
                if (indice == 0) {
                    cad_detalle = cad_detalle + "{'cantidadPresentacion':'" + elemento.cantidad + "','cantidadUnidadBase':'" + elemento.cant_unidad_base + "','codAlmacen':'" + elemento.codAlmacen + "','codPresentacion':'" + elemento.codUnidadB + "','codPreventa':'" + numero_preventa +"','codProducto':'" + elemento.codProducto + "','itemPreventa':'" + elemento.item + "','precioVenta':'" + elemento.precio + "','TipoProducto':'" + elemento.tipoProducto + "'}"
                } else {
                    cad_detalle = cad_detalle + ",{'cantidadPresentacion':'" + elemento.cantidad + "','cantidadUnidadBase':'" + elemento.cant_unidad_base + "','codAlmacen':'" + elemento.codAlmacen + "','codPresentacion':'" + elemento.codUnidadB + "','codPreventa':'" + numero_preventa +"','codProducto':'" + elemento.codProducto + "','itemPreventa':'" + elemento.item + "','precioVenta':'" + elemento.precio + "','TipoProducto':'" + elemento.tipoProducto + "'}"
                }
            });
            cad_detalle = cad_detalle.trim() + "]";
            console.log(cad_detalle);

        cad_cabecera = "{ 'preventa': {'proceso': '" + tipo_proceso + "','codCliente':'" + codigoCliente.val() + "', 'codPuntoEntrega': '" + valPuntoEntrega.val() + "', 'codUsuario':'" + valUsuario.val() + "','estado':'1','fecha':'" + fechaActual+"', 'fechaEntrega':'" + fechaEntrega.val() + "', 'fechaPago':null, 'horaEntrega':'" + hour + "', 'codSucursal':'1','igv':'" + igv.val() + "','isc':'0.0'," +
            "'ntraPreventa':'" + numero_preventa + "', 'recargo': '" + recargo.val() + "', 'tipoDocumentoVenta': '" + flag_documentoVenta + "', 'tipoMoneda': '1', 'tipoVenta': '" + flag_tipoVenta + "', 'total': '" + total.val() + "', 'flagRecargo': '" + flag_recargo + "', 'origenVenta': '2', 'usuario':'" + valUsuario.val() + "', 'ip': '', 'mac':'', " + cad_detalle + ", " + cad_promocion + ", " + cad_descuento + " } }"
            /*cad_cabecera = "{'proceso': '1','codCliente':'" + codigoCliente.val() + "', 'codPuntoEntrega': '" + valPuntoEntrega.val() + "', 'codUsuario':'" + valUsuario.val() + "','estado':'1','fecha':'05/03/2020', 'fechaEntrega':'05/03/2020', 'fechaPago':null, 'horaEntrega':'08:30:00', 'codSucursal':'1','igv':'" + igv.val() + "','isc':'0.0'," +
                "'ntraPreventa':'0', 'recargo': '" + recargo.val() + "', 'tipoDocumentoVenta': '" + flag_documentoVenta + "', 'tipoMoneda': '1', 'tipoVenta': '" + flag_tipoVenta + "', 'total': '" + total.val() + "', 'flagRecargo': '" + flag_recargo + "', 'origenVenta': '2', 'usuario':'" + valUsuario.val() + "', 'ip': '', 'mac':'', " + cad_detalle + " }" * /
            /*cad_cabecera = "{'proceso': '1','codCliente':'" + codigoCliente.val() + "', 'codPuntoEntrega': '" + valPuntoEntrega.val() + "', 'codUsuario':'" + valUsuario.val() + "','estado':'1','fecha':'05/03/2020', 'fechaEntrega':'05/03/2020', 'fechaPago':null, 'horaEntrega':'08:30:00', 'codSucursal':'1','igv':'" + igv.val() + "','isc':'0.0'," +
                "'ntraPreventa':'0', 'recargo': '" + recargo.val() + "', 'tipoDocumentoVenta': '" + flag_documentoVenta + "', 'tipoMoneda': '1', 'tipoVenta': '" + flag_tipoVenta + "', 'total': '" + total.val() + "', 'flagRecargo': '" + flag_recargo + "', 'origenVenta': '2', 'usuario':'" + valUsuario.val() + "', 'ip': '', 'mac':'', " + cad_detalle + " }"*/
            console.log(cad_cabecera);
            //'listPrevDescuento': [], 'listPrevPromocion': [], 

            /*preventa.proceso = 1;
            preventa.codCliente = codigoCliente.val();
            preventa.codPuntoEntrega = valPuntoEntrega.val();
            preventa.codUsuario = valUsuario.val();
            preventa.estado = 1;
            preventa.fecha = '05/03/2020';
            preventa.fechaEntrega = '05/03/2020';
            preventa.fechaPago = null;
            preventa.horaEntrega = '08:30:00';
            preventa.codSucursal = 1;
            preventa.igv = igv.val();
            preventa.isc = 0.0;
            preventa.ntraPreventa = 0;
            preventa.recargo = recargo.val();
            preventa.tipoDocumentoVenta = flag_documentoVenta;
            preventa.tipoMoneda = 1;
            preventa.tipoVenta = flag_tipoVenta;
            preventa.total = total.val();
            preventa.flagRecargo = flag_recargo;
            preventa.origenVenta = 2;
            preventa.usuario = valUsuario.val();
            preventa.ip= '',
            preventa.mac= '';
            preventa.listPrevDetalle= listPrevDet;
            
            var json = JSON.stringify({ Data: preventa });*/
            $.ajax({
                type: "POST",
                url: "registrarpreventa.aspx/registrarPreventa",
                data: cad_cabecera,
                contentType: 'application/json; charset=utf-8',
                error: function (xhr, ajaxOtions, thrownError) {
                    console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
                },
                success: function (data) {
                    mostrarMensajeConfirmacion(data.d.ntraPreventa);
                    //alert("Preventa registrada" + data.d.ntraPreventa);
                }
            });
            
        //});
    }
    //guardarPreventa()

    function mostrarMensajeConfirmacion(codigoPreventa) {
        if (numero_preventa === 0) {
            swal("Preventa Registrada", "Se registro la preventa correctamente con codigo: " + codigoPreventa, "success").then((willDelete) => {
                if (willDelete) {
                    vendedores.focus();
                    location.reload();
                }
            });
        } else {
            swal("Preventa Actualizada", "Se actualizo la preventa correctamente con codigo: " + codigoPreventa, "success").then((willDelete) => {
                if (willDelete) {
                    window.location.href = "frmMantPreventa.aspx";
                }
            });
        }

        /*{
            title: "Preventa Registrada",
            text: "Se registro la preventa correctamente con codigo " + codigoPreventa,
            icon: "warning",
            buttons: true,
            dangerMode: true,
        })
            //Promesa que me trae el valor true al confirmar OK.
            .then((willDelete) => {
                if (willDelete) {
                    ElimiarRutasAsignadas(codUsuarioT, coodRutaT)
                    swal("Se elimino Registro", {
                        icon: "success",
                    });

                    RestarOrden(posicion, cantidadFilas);



                } else {
                    swal("Se Cancelo la eliminaciòn");

                }
            });*/
    }
    

    // UNIDADES MODAL INICIO
    function cargarComboUnidadesModal(data, cod) {
        //DESCRIPCION : Funcion para llenar la lista de opciones del select unidades
        var obj = new Object();
        var a = 0;
        arr_unidad_base = null;
        arr_unidad_base = new Array();
        for (var i = 0; i < data.length; i++) {
            obj = new Object();
            M_uniPro.append("<option value=" + data[i]["codPresentacion"] + ">" + data[i]["descripcion"] + "</option>");
            obj.val = data[i]["codPresentacion"];
            obj.cantidad = data[i]["cantidadUnidadBase"];
            arr_unidad_base.push(obj);
            if (data[i]["codPresentacion"] == cod) {
                a = i + 1;
            }
        }
        M_uniPro.prop('selectedIndex', a);
    }

    function presentacionProductoModal(codProducto, pos) {
        //DESCRIPCION : Funcion que me trae la lista de vendedores
        $.ajax({
            type: "POST",
            url: "registrarpreventa.aspx/presentacionProductos",
            data: "{'codProducto': '" + codProducto + "' }",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                cargarComboUnidadesModal(data.d, pos);
            }
        })

    }

    function cargarComboAlmacenesModal(data, cod) {
        //DESCRIPCION : Funcion para llenar la lista de opciones del select unidades
        var obj = new Object();
        var a = 0;
        arr_stock = null;
        arr_stock = new Array();
        for (var i = 0; i < data.length; i++) {
            obj = new Object();
            M_almPro.append("<option value=" + data[i]["codAlmacen"] + ">" + data[i]["descripcion"] + "</option>");
            obj.val = data[i]["codAlmacen"];
            obj.stock = data[i]["stock"];
            arr_stock.push(obj);
            if (cod == data[i]["codAlmacen"]) {
                a = i + 1;
            }
        }
        arr_stock.forEach(function (elemento, indice, array) {
            if (elemento.val == cod) {
                M_stoPro.val(elemento.stock);
            }
        });
        M_almPro.prop('selectedIndex', a);
    }

    function almacenProductoModal(codProducto, pos) {
        //DESCRIPCION : Funcion que me trae la lista de almacenes
        $.ajax({
            type: "POST",
            url: "registrarpreventa.aspx/almacenProductos",
            data: "{'codProducto': '" + codProducto + "' }",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                cargarComboAlmacenesModal(data.d, pos);
            }
        })

    }

    function seleccionarAlmacenModal() {
        M_almPro.change(function () {
            M_canPro.val(1);
            var optionSelected = $(this).find("option:selected");
            var valueSelected = optionSelected.val();
            var flag = 0;
            arr_stock.forEach(function (elemento, indice, array) {
                if (elemento.val == valueSelected) {
                    M_stoPro.val(elemento.stock);
                    flag = 1;
                }
            });
            if (flag == 0) {
                M_stoPro.val("");
            }

        });
    }
    seleccionarAlmacenModal()

    function seleccionarUnidadModal() {
        M_uniPro.change(function () {
            M_canPro.val(1);
        });
    }
    seleccionarUnidadModal()

    function cantidadProductosModal() {
        M_canPro.change(function () {
            var optionSelected = M_almPro.find("option:selected");
            var valueSelected = optionSelected.val();

            var a = M_canPro.val();
            var b = M_stoPro.val();
            var can_uni_base = 0;

            if (valueSelected == 0) {
                swal("Debe seleccionar un almacen", {
                    icon: "info"
                });
                //alert("Debe seleccionar un almacen");
                M_canPro.val(1);
                M_almPro.focus();
            } else {
                optionSelected = M_uniPro.find("option:selected");
                valueSelected = optionSelected.val();

                if (valueSelected == 0) {
                    swal("Debe seleccionar la unidad", {
                        icon: "info"
                    });
                    //alert("Debe seleccionar la unidad");
                    M_canPro.val(1);
                    M_uniPro.focus();
                } else {
                    a = parseInt(a, 10);
                    b = parseInt(b, 10);

                    if (a < 1) {
                        M_canPro.val(1)
                    }

                    if (b != "") {
                        optionSelected = M_uniPro.find("option:selected");
                        valueSelected = optionSelected.val();
                        arr_unidad_base.forEach(function (elemento, indice, array) {
                            if (elemento.val == valueSelected) {
                                can_uni_base = elemento.cantidad;
                            }
                        });
                        //can_uni_base = can_uni_base * cantidad.val();

                        if (a * can_uni_base > b) {
                            M_canPro.val(a - 1);
                        }
                    }




                }
            }

        });
    }
    cantidadProductosModal()

    /*
     objcarrito.item = items;   //ITEM
        objcarrito.codPro = codPro.val();   //CODIGO PRODUCTO
        objcarrito.desPro = desPro.val();   //DESCRICION PROD
        objcarrito.cantidad = cantidad.val(); //CANTIDAD
        objcarrito.cantidadUB = can_uni_base;       //CANTIDAD UNIDAD BASE
        objcarrito.precio = parseFloat(Math.round(parseFloat(precio.val()) * 100) / 100).toFixed(2);   //PRECIO
        objcarrito.desAlmacen = des_almacen; //ALMACEN
        objcarrito.codAlmacen = almacenes.val();  //CODIGO ALMACEN
        objcarrito.desUnidad = des_unidad;     //UNIDAD
        objcarrito.codUnidad = unidades.val(); //CODIGO DE UNIDAD
        objcarrito.subTotal = parseFloat(Math.round(parseFloat(cantidad.val() * can_uni_base * precio.val()) * 100) / 100).toFixed(2); //SUBTOTAL
        objcarrito.desTipoProducto = des_tipo_pro;   //TIPO PRODUCTO
        objcarrito.tipoProducto = tipoProducto.val(); //CODIGO TIPO PRODUCTO
     * */

    function guardarCambioProductoModal() {
        M_btnGuardar.click(function () {
            var can_uni_base = 0;
            var can = M_canPro.val();
            var optionSelected = M_uniPro.find("option:selected");
            var val_unidad = optionSelected.val();
            var des_unidad = optionSelected.text();

            optionSelected = M_almPro.find("option:selected");
            var val_almacen = optionSelected.val();
            var des_almacen = optionSelected.text();

            arr_unidad_base.forEach(function (elemento, indice, array) {
                if (elemento.val == val_unidad) {
                    can_uni_base = elemento.cantidad;
                }
            });
            var subtotal = 0;
            var subtotal2 = 0;
            var a = M_codPro.val();
            var i = 0;
            arr_carrito.forEach(function (elemento, indice, array) {
                if (elemento.codPro == a) {
                    //subtotal = arr_carrito[indice].subTotal;
                    //subtotal2 = parseFloat(Math.round(parseFloat(can * can_uni_base * arr_carrito[indice].precio) * 100) / 100).toFixed(2);
                    //arr_carrito[indice].desAlmacen = des_almacen;
                    //arr_carrito[indice].codAlmacen = val_almacen;
                    //arr_carrito[indice].desUnidad = des_unidad;
                    //arr_carrito[indice].codUnidad = val_unidad;
                    //arr_carrito[indice].cantidad = can;
                    //arr_carrito[indice].cantidadUB = can_uni_base;
                    //arr_carrito[indice].subTotal = parseFloat(Math.round(parseFloat(can * can_uni_base * arr_carrito[indice].precio) * 100) / 100).toFixed(2);
                    i = indice;
                }
            });
            subtotal = arr_carrito[i].subTotal;
            subtotal2 = parseFloat(Math.round(parseFloat(parseInt(can) * can_uni_base * parseFloat(arr_carrito[i].precio)) * 100) / 100).toFixed(2);
            arr_carrito[i].desAlmacen = des_almacen;
            arr_carrito[i].codAlmacen = val_almacen;
            arr_carrito[i].desUnidad = des_unidad;
            arr_carrito[i].codUnidad = val_unidad;
            arr_carrito[i].cantidad = can;
            arr_carrito[i].cantidadUB = can_uni_base;
            arr_carrito[i].subTotal = parseFloat(Math.round(parseFloat(can * can_uni_base * arr_carrito[i].precio) * 100) / 100).toFixed(2);

            i_total_salvado = i_total_salvado - parseFloat(subtotal) + parseFloat(subtotal2);
            calcularTotales();
            recargarTabla();
        });
    }
    guardarCambioProductoModal()

    // MODAL FIN

    //PROMOCIONES #################################################################3#######
    function cargarRadioButton(data) {
        var obj = new Object();
        $("#promos").empty();
        arr_promociones = null;
        arr_promociones = new Array();

        for (var i = 0; i < data.length; i++) {
            obj = new Object();
            $("#promos").append("<input id='P" + data[i]["ntraPromocion"] + "' disabled type='radio' name = 'promociones' value = '" + data[i]["ntraPromocion"] + "'>" + data[i]["descPromocion"] + "</br>" );
            obj.ntra = data[i]["ntraPromocion"];
            obj.desc = data[i]["descPromocion"];
            obj.valor = data[i]["valor"];
            obj.tipo = data[i]["tipo"];
            arr_promociones.push(obj);
        }
        
    }

    function buscarPromociones() {
        var codPro = codigoProducto.val();
        var optionSelected = vendedores.find("option:selected");
        var codVendedor = optionSelected.val();
        var codCliente = codigoCliente.val();

        $.ajax({
            type: "POST",
            url: "registrarpreventa.aspx/obtenerPromocionesProducto",
            data: "{'parametro':{'codProducto': '" + codPro + "', 'codUsuario':'" + codVendedor + "', 'codCliente':'" + codCliente + "', 'tipoVenta':'" + flag_tipoVenta + "'}}",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                cargarRadioButton(data.d);
            }
        })


    }

    function promocionesActivadas() {
        var a = parseInt(cantidadProducto.val());
        //var b = parseInt(stockProducto.val());
        var c = parseFloat(precio_Producto.val());
        var can_uni_base = 0;
        var optionSelected = unidades.find("option:selected");
        var valueSelected = optionSelected.val();
        arr_unidad_base.forEach(function (elemento, indice, array) {
            if (elemento.val == valueSelected) {
                can_uni_base = elemento.cantidad;
            }
        });
        var can = a * parseInt(can_uni_base);
        var imp = a * parseInt(can_uni_base) * c;
        var id = "";
        arr_promociones.forEach(function (elemento, indice, array) {
            id = "#P" + elemento.ntra;
            if (elemento.tipo == 1) { //cantidad
                if (can >= parseInt(elemento.valor)) {
                    $(id).prop("disabled", false);
                }
                else {
                    $(id).prop("disabled", true);
                    $(id).prop("checked", false);
                }
            } else {
                if (elemento.tipo == 2) {
                    if (imp >= parseFloat(elemento.valor)) {
                        $(id).prop("disabled", false);
                    } else {
                        $(id).prop("disabled", true);
                        $(id).prop("checked", false);
                    }
                }
            }
        });

        arr_descuentos.forEach(function (elemento, indice, array) {
            id = "#D" + elemento.ntra;
            if (elemento.tipo == 1) { //cantidad
                if (can >= parseInt(elemento.valor)) {
                    $(id).prop("disabled", false);
                }
                else {
                    $(id).prop("disabled", true);
                    $(id).prop("checked", false);
                }
            } else {
                if (elemento.tipo == 2) {
                    if (imp >= parseFloat(elemento.valor)) {
                        $(id).prop("disabled", false);
                    } else {
                        $(id).prop("disabled", true);
                        $(id).prop("checked", false);
                    }
                }
            }
        });
    }

    function deshabilitarPromociones() {
        arr_promociones.forEach(function (elemento, indice, array) {
            id = "#P" + elemento.ntra;
            $(id).prop("disabled", true);
            $(id).prop("checked", false);
        });

        arr_descuentos.forEach(function (elemento, indice, array) {
            id = "#D" + elemento.ntra;
            $(id).prop("disabled", true);
            $(id).prop("checked", false);
        });
    }

    function cargarProductosRegalo(data, c, ntraPromocion) {
        /*
<th scope="col">ITEM</th>
<th scope="col">CODIGO</th>
<th scope="col">DESCRIPCION</th>
<th scope="col">CANTIDAD</th>
<th scope="col">CANTIDADUNIDADBASE</th>
<th scope="col">PRECIO</th>
<th scope="col">ALMACEN</th>
<th scope="col">CODALMACEN</th>
<th scope="col">UNIDAD</th>
<th scope="col">CODPRESENTACION</th>
<th scope="col">SUBTOTAL</th>
<th scope="col">TIPO</th>
<th scope="col">CODIGOTIPOPRODUCTO</th>
<th scope="col">ACCION</th>
         */
        var can_uni_base = 1;
        var obj = new Object();
        var objcarrito = new Object();
        arr_regalos = null;
        arr_regalos = new Array();
        var ip = items;
        for (var i = 0; i < data.length; i++) {
            obj = new Object();
            objcarrito = new Object();
            obj.cant = data[i]["valorEntero1"];
            obj.alma = data[i]["valorEntero2"];
            obj.prec = data[i]["valorMoneda1"];
            obj.prod = data[i]["valorCadena1"];
            obj.cod_pre = data[i]["codUnidadBase"];
            obj.desc_pro = data[i]["descProducto"];
            obj.desc_alm = data[i]["descAlmacen"];
            obj.desc_uni = data[i]["descUnidadBase"];
            arr_regalos.push(obj);

            items = items + 1;

            i_total = i_total + (parseInt(obj.cant) * can_uni_base * parseFloat(obj.prec));
            i_total_salvado = i_total_salvado + (parseInt(obj.cant) * can_uni_base * parseFloat(obj.prec));
            calcularTotales();

            objcarrito.item = items;
            objcarrito.codPro = obj.prod;
            objcarrito.desPro = obj.desc_pro;
            objcarrito.cantidad = obj.cant;
            objcarrito.cantidadUB = can_uni_base;
            objcarrito.precio = obj.prec;
            objcarrito.desAlmacen = obj.desc_alm;
            objcarrito.codAlmacen = obj.alma;
            objcarrito.desUnidad = obj.desc_uni;
            objcarrito.codUnidad = obj.cod_pre;
            //objcarrito.subTotal = ();
            objcarrito.subTotal = parseFloat(Math.round(parseFloat(parseInt(obj.cant) * can_uni_base * parseFloat(obj.prec)) * 100) / 100).toFixed(2);;
            objcarrito.desTipoProducto = "PROMOCION";
            objcarrito.tipoProducto = 3;
            objcarrito.accion = btnEliminar;
            objcarrito.flagPromo = 1;
            objcarrito.codPromo = c;
            
            objcarrito.cod_promocion = ntraPromocion;
            objcarrito.item_preventa = ip;

            objcarrito.flagDescu = 0;
            objcarrito.impoDescu = 0;
            objcarrito.cod_descuento = 0;

            arr_carrito.push(objcarrito);
            addRowDT(objcarrito);
        }
    }

    function obtenerProductosRegalo(ntraPromocion, c) {
        $.ajax({
            type: "POST",
            url: "registrarpreventa.aspx/obtenerProductosRegalo",
            data: "{'ntraPromocion': '" + ntraPromocion + "'}",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                cargarProductosRegalo(data.d, c, ntraPromocion);
            }
        })
    }

    //DESCUENTOS ####################################################################

    function cargarRadioButtonDescuento(data) {
        var obj = new Object();
        $("#dsctos").empty();
        arr_descuentos = null;
        arr_descuentos = new Array();

        for (var i = 0; i < data.length; i++) {
            obj = new Object();
            $("#dsctos").append("<input id='D" + data[i]["ntraDescuento"] + "' disabled type='radio' name = 'descuentos' value = '" + data[i]["ntraDescuento"] + "'>" + data[i]["descDescuento"] + "</br>");
            obj.ntra = data[i]["ntraDescuento"];
            obj.desc = data[i]["descDescuento"];
            obj.valor = data[i]["valor"];
            obj.tipo = data[i]["tipo"];
            obj.tipoDescuento = data[i]["tipoDescuento"];
            obj.valorDescuento = data[i]["valorDescuento"];
            arr_descuentos.push(obj);
        }

    }

    function buscarDescuentos() {
        var codPro = codigoProducto.val();
        var optionSelected = vendedores.find("option:selected");
        var codVendedor = optionSelected.val();
        var codCliente = codigoCliente.val();
        ntra_desc = 0;
        $.ajax({
            type: "POST",
            url: "registrarpreventa.aspx/obtenerDescuentosProducto",
            data: "{'parametro':{'codProducto': '" + codPro + "', 'codUsuario':'" + codVendedor + "', 'codCliente':'" + codCliente + "', 'tipoVenta':'" + flag_tipoVenta + "', 'tipoDescuento':'1'}}",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                cargarRadioButtonDescuento(data.d);
            }
        })


    }

    $(function () {
        $("#id_fecha").datepicker({
            minDate: 0,
            maxDate: "+5M +10D",
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

    function verificarHora() {
        hora.change(function () {
            var a = parseInt(hora.val());
            if (a < 0) {
                hora.val("00");
            }

            if (a > 20) {
                hora.val(20);
            }

            switch (a) {
                case 0:
                    hora.val("00");
                    break;
                case 1:
                    hora.val("01");
                    break;
                case 2:
                    hora.val("02");
                    break;
                case 3:
                    hora.val("03");
                    break;
                case 4:
                    hora.val("04");
                    break;
                case 5:
                    hora.val("05");
                    break;
                case 6:
                    hora.val("06");
                    break;
                case 7:
                    hora.val("07");
                    break;
                case 8:
                    hora.val("08");
                    break;
                case 9:
                    hora.val("09");
                    break;
            }
        });
    }
    verificarHora()

    function verificarMinutos() {
        minutos.change(function () {
            var a = parseInt(minutos.val());

            if (a < 0 ) {
                minutos.val("00");
            }

            if (a > 59) {
                minutos.val(59);
            }

            switch (a) {
                case 0:
                    minutos.val("00");
                    break;
                case 1:
                    minutos.val("01");
                    break;
                case 2:
                    minutos.val("02");
                    break;
                case 3:
                    minutos.val("03");
                    break;
                case 4:
                    minutos.val("04");
                    break;
                case 5:
                    minutos.val("05");
                    break;
                case 6:
                    minutos.val("06");
                    break;
                case 7:
                    minutos.val("07");
                    break;
                case 8:
                    minutos.val("08");
                    break;
                case 9:
                    minutos.val("09");
                    break;
            }
        });
    }
    verificarMinutos()


    //######################################## EDITAR PREVENTA ############################################################
    function editarObtenerdata(npre) {
        //Descripcion: Obtener los datos de la preventa 
        $.ajax({
            type: "POST",
            url: "registrarpreventa.aspx/obtenerPreventa",
            data: "{'npre': '" + npre + "' }",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                //editarAgregarData(data.d);
                setTimeout(function () { editarAgregarData(data.d); },5000);
            }
        });
    }
    function editarAgregarData(datos) {
        //Descripcion: Agregar los datos al formulario
        var EditHora = datos.horaEntrega.substring(0, 2);
        var EditMinu = datos.horaEntrega.substring(3, 5);


        if (datos.tipoVenta === 1) {
            venta_contado.attr('checked', true);
            venta_credito.attr('checked', false).prop('disabled', true);
        } else {
            venta_contado.attr('checked', false).prop('disabled', true);
            venta_credito.attr('checked', true);
        }

        if (datos.tipoDocumentoVenta === 1) {
            venta_boleta.attr('checked', true);
            venta_factura.attr('checked', false).prop('disabled', true);
        } else {
            venta_boleta.attr('checked', false).prop('disabled', true);
            venta_factura.attr('checked', true);
        }

        flag_tipoVenta = datos.tipoVenta;
        flag_documentoVenta = datos.tipoDocumentoVenta;

        fechaEntrega.val(datos.fechaEntrega).prop('disabled', true);
        hora.val(EditHora).prop('disabled', true);
        minutos.val(EditMinu).prop('disabled', true);

        nombreCliente.val(datos.cliente).prop('disabled', true);
        codigoCliente.val(datos.codCliente);
        documentoCliente.val(datos.identificacion);
        puntosEntrega.append("<option value=" + datos.codPuntoEntrega + ">" + datos.direccion + "</option>");
        puntosEntrega.val(datos.codPuntoEntrega).prop('disabled', true);
        descripcionProducto.prop('disabled', false);

        $("#id_tipoListaPrecio").val(datos.tipoListaPrecio);

        flag_recargo = datos.flagRecargo;
        if (flag_recargo === 1) {
            $("#id_flag_recargo").prop("checked", true);
            $("#id_flag_recargo").prop("disabled", true);
        }

        //Obtener el detalle de la preventa
        $.ajax({
            type: "POST",
            url: "frmMantPreventa.aspx/ListarDetalle",
            data: "{'npre': '" + datos.ntraPreventa + "'}",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                //tablever.clear().draw();
                editarObtenerDetalle(data.d);
            }
        });
    }

    function editarObtenerDetalle(datoDet) {
        //Descripcion: Agregar el detalle a la tabla de prodcutos del formulario
        for (var k = 0; k < datoDet.length; k++) {
            var obj = new Object();
            var objcarrito = new Object();
            items = items + 1;

            objcarrito.item = items;
            objcarrito.codPro = datoDet[k].codProducto;
            objcarrito.desPro = datoDet[k].descripcion;
            objcarrito.cantidad = datoDet[k].cantidad;
            objcarrito.cantidadUB = datoDet[k].cantidadUnidadBase;
            objcarrito.precio = datoDet[k].precio;
            objcarrito.desAlmacen = datoDet[k].descAlmacen;
            objcarrito.codAlmacen = datoDet[k].codAlmacen;
            objcarrito.desUnidad = datoDet[k].um;
            objcarrito.codUnidad = datoDet[k].codUnidad;
            objcarrito.subTotal = parseFloat(Math.round(parseFloat(datoDet[k].cantidadUnidadBase * datoDet[k].precio) * 100) / 100).toFixed(2);
            objcarrito.desTipoProducto = datoDet[k].tipo;
            objcarrito.tipoProducto = datoDet[k].codTipo;
            objcarrito.accion = btnEliminar;

            if (datoDet[k].codTipo !== 3) {

                i_total = i_total + (datoDet[k].cantidadUnidadBase * datoDet[k].precio) - datoDet[k].descuento;
                i_total_salvado = i_total_salvado + (datoDet[k].cantidadUnidadBase * datoDet[k].precio) - datoDet[k].descuento;

                objcarrito.flagPromo = 0;
                objcarrito.codPromo = datoDet[k].codProducto;
                objcarrito.cod_promocion = 0;
                objcarrito.item_preventa = 0;

                if (datoDet[k].codDec !== 0) {
                    objcarrito.flagDescu = 1;
                    objcarrito.impoDescu = datoDet[k].descuento;
                    objcarrito.cod_descuento = datoDet[k].codDec;
                    i_descuento = i_descuento + (datoDet[k].descuento);
                } else {
                    objcarrito.flagDescu = 0;
                    objcarrito.impoDescu = 0;
                    objcarrito.cod_descuento = 0;
                }

                calcularTotales();

                arr_carrito.push(objcarrito);

                obj.val = datoDet[k].codProducto;
                arr_producto.push(obj);

                addRowDT(objcarrito);

                ntra_desc = 0;

            } else {

                i_total = i_total + (parseInt(datoDet[k].cantidad) * datoDet[k].cantidadUnidadBase * parseFloat(datoDet[k].precio));
                i_total_salvado = i_total_salvado + (parseInt(datoDet[k].cantidad) * datoDet[k].cantidadUnidadBase * parseFloat(datoDet[k].precio));

                objcarrito.flagPromo = 1;
                objcarrito.codPromo = datoDet[k].codProdPrincipal;
                objcarrito.cod_promocion = datoDet[k].codPro;
                objcarrito.item_preventa = datoDet[k].itempreventa;

                objcarrito.flagDescu = 0;
                objcarrito.impoDescu = 0;
                objcarrito.cod_descuento = 0;

                obj.cant = datoDet[k].cantidad;
                obj.alma = datoDet[k].codAlmacen;
                obj.prec = datoDet[k].precio;
                obj.prod = datoDet[k].codProducto;
                obj.cod_pre = datoDet[k].codUnidad;
                obj.desc_pro = datoDet[k].descripcion;
                obj.desc_alm = datoDet[k].descAlmacen;
                obj.desc_uni = datoDet[k].um;

                calcularTotales();
                arr_regalos.push(obj);
                arr_carrito.push(objcarrito);

                //obj.val = datoDet[k].codProducto;
                //arr_producto.push(obj);
                addRowDT(objcarrito);
            }
        }
    }
    //##########################################################################################################################

});

