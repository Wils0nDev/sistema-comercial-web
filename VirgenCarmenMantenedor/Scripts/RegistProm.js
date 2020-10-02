
$(document).ready(function () {
    //Lista de Variables

    var vendedor = $(".vendedor");

    var selectRutas = $("#rutas");
    var Mabreviatura = $("#Mabreviatura");
    var McodVendedorVal = $("#McodVendedor");
    var Mvendedor = $("#Mvendedor");
    var selectDias = $("#dias");
    var btnGuardar = $("#btnGuardar");

    var btnActualizar = $("#btnActualizar");
    var btnEditar = '<button type="button" title="Editar" class="icon-pencil btnEditar" data-toggle="modal"  data-target="#exampleModal3" ></button>'
    var btnEliminar = ' <button type="button" id="" class="icon-bin btnDelete" data-toggle="tooltip"  title="Eliminar" ></button>'
    var btnVer = ' <button type="button" title="Ver" class="icon-eye btnEye btnVer" data-toggle="modal"  data-target="#exampleModal" ></button>';

    var btnEliminarDet = ' <button type="button" title="Anular" class="icon-bin btnDelete" data-toggle="modal" data-target="#modalAnular"></button>';


    //var producto = $('#producto');
    var producto_promocion = $('#producto_promocion');
    var producto_compra = $('.producto');

    var estado = $('#estado');
    var proveedor = $('#id_proveedor');
    var tipoVenta = $('#tipoVenta');
    var fechaInicial = $('#min_date');
    var fechaFinal = $('#max_date');
    var cliente = $('.cliente');
    var vendedor = $('#vendedor');
    var producto_principal = $('#producto_principal');


    var btnBuscar = $("#id_btnBuscar");

    var productoVer = $("#ProductoVer");
    var inicioVer = $("#InicioVer");
    var finVer = $("#FinVer");
    var maxP = $("#MaxP");
    var vendedorMax = $("#VendedorMax");
    var clienteMax = $("#ClienteMax");
    var cantM = $("#CantM");
    var ubase = $("#Ubase");
    var ubase = $("#Ubase");




    //--MODAL REGISTRA

    var descPromocion = $("#Nombre");
    var fechaInicio = $("#fecha-inicio");
    var fechaFin = $("#fecha-final");
    var horaInicio = $("#hora-inicio");
    var horaFin = $("#hora-fin");

    var radioActivo1 = $("#inlineRadio1");
    var radioActivo2 = $("#inlineRadio2");

    var id_codProducto_reg = $("#id_codProducto_reg");
    var id_Producto_reg = $("#id_Producto_reg");
    var cantidadPrincipal = $("#txt-cant");
    var id_unidadBase = $("#id_unidadBase");

    var clienteReg = $(".clientesM");
    var vendedoresM = $(".vendedores");
    var cantUsarMaxM = $("#txt-cantM");
    var cantVecesVendM = $("#txt-cantV");
    var cantVecesClienteM = $("#txt-cantC");

    var aplicaContado = $("#aplicaPara1");
    var aplicaCredito = $("#aplicaPara2");





    var id_unidadBase_promo = $("#id_unidadBase_promo");
    var id_Producto_promo = $("#id_Producto_promo");
    var id_codProducto_promo = $("#id_codProducto_promo");

    /////////////////////////////////////////


    //Propiedades para el DataTable
    $('#tb_rutas').DataTable({

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
        function(start, end, label) {
            maxDateFilter = end;
            minDateFilter = start;
            table.draw();
        },


        //Para que el DataTable no me muestre ciertas Columnas.
        columnDefs: [
            {
                "width": "5%",
                "targets": [0]
            },
            {
                "width": "35%",
                "targets": [2]
            },
            {
                "width": "15%",
                "targets": [3]
            },
            {
                "width": "15%",
                "targets": [4]
            },
            {
                "width": "20%",
                "targets": [6]
            },
            {
                "width": "10%",
                "targets": [7]
            },
            {
                "targets": [1, 5, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24],
                "visible": false,
                "searchable": false
            }

        ]
    });

    //creo variables despues de que el DataTable este creado en el DOM.
    var tabla = $("#tb_rutas").dataTable(); //funcion jquery
    var table = $("#tb_rutas").DataTable(); //funcion DataTable-libreria
    table.columns.adjust().draw();



    //Convertimos la tabla detalle preventa en dataTable y le pasamos parametros
    $('#tb_detalle').DataTable({
        //paging: false,
        //ordering: false,
        //info: false,
        language: {
            lengthMenu: "Mostrar _MENU_ registros",
            zeroRecords: "No hay registros",
            info: "Mostrando la página _PAGE_ de _PAGES_",
            infoEmpty: "No hay registros disponibles.",
            infoFiltered: "(filtered from _MAX_ total records)",
            search: "Busqueda: ",
            Paginate: {
                "sFirst": "Primero",
                "sLast": "Último",
                "sNext": "Siguiente",
                "sPrevious": "Anterior"
            }
        },
        columnDefs: [
            {
                "width": "96%",
                "targets": [1]
            },
            {
                "width": "1%",
                "targets": [2]
            },
            {
                "width": "2%",
                "targets": [3]
            },
            {
                "width": "1%",
                "targets": [4]
            },
            {
                "targets": [0],
                "visible": false,
                "searchable": false
            }
        ]
    });
    var tablaver = $("#tb_detalle").dataTable(); //funcion jquery
    var tablever = $("#tb_detalle").DataTable(); //funcion DataTable-libreria
    tablever.columns.adjust().draw();




    //Convertimos la tabla detalle preventa en dataTable y le pasamos parametros
    $('#tb_agregar').DataTable({
        //paging: false,
        //ordering: false,
        //info: false,
        language: {
            lengthMenu: "Mostrar _MENU_ registros",
            zeroRecords: "No hay registros",
            info: "Mostrando la página _PAGE_ de _PAGES_",
            infoEmpty: "No hay registros disponibles.",
            infoFiltered: "(filtered from _MAX_ total records)",
            search: "Busqueda: ",
            Paginate: {
                "sFirst": "Primero",
                "sLast": "Último",
                "sNext": "Siguiente",
                "sPrevious": "Anterior"
            }
        },
        columnDefs: [

            {
                "targets": [0,3],      //OCULTAR  0 Y 3
                "visible": false,
                "searchable": false
            }
        ]
    });
    var tablaagregagr = $("#tb_agregar").dataTable(); //funcion jquery
    var tableagregar = $("#tb_agregar").DataTable(); //funcion DataTable-libreria
    tableagregar.columns.adjust().draw();



    //Convertimos la tabla detalle preventa en dataTable y le pasamos parametros
    $('#tb_detalle_edit').DataTable({
        //paging: false,
        //ordering: false,
        //info: false,
        language: {
            lengthMenu: "Mostrar _MENU_ registros",
            zeroRecords: "No hay registros",
            info: "Mostrando la página _PAGE_ de _PAGES_",
            infoEmpty: "No hay registros disponibles.",
            infoFiltered: "(filtered from _MAX_ total records)",
            search: "Busqueda: ",
            Paginate: {
                "sFirst": "Primero",
                "sLast": "Último",
                "sNext": "Siguiente",
                "sPrevious": "Anterior"
            }
        },
        columnDefs: [

            {
                "targets": [0],
                "visible": false,
                "searchable": false
            }
        ]
    });
    var tablaedit = $("#tb_detalle_edit").dataTable(); //funcion jquery
    var tableedit = $("#tb_detalle_edit").DataTable(); //funcion DataTable-libreria
    tableedit.columns.adjust().draw();


    //function llenarTabla(data) {
    // est codigo va al final e la funcion llenar tabla
    $('body').on('click', '.btnEditar', function () {
        var tr = $(this).parent().parent();
        llenarModal(table.row(tr));
    });



    function detalle_promocionEdit(codPromocion) {
        //DESCRIPCION : Funcion que me trae la lista del detalle de la preventa por codigo de preventa
        $.ajax({
            type: "POST",
            url: "frmMantProm.aspx/ListarDetalle",
            data: "{'codPromocion': '" + codPromocion + "'}",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                tableedit.clear().draw();
                llenarTablaEdit(data.d);
            }
        });
    }

    function llenarTablaEdit(data) {
        //DESCRIPCION: Funcion para llenar la tabla del modal ver.

        for (var i = 0; i < data.length; i++) {
            var boton = btnEliminarDet;
            tablaedit.fnAddData([
                data[i].item,
                //data[i].codProductoProm,
                data[i].descripcionProd,
                data[i].cantidad,
                //data[i].presentacion,
                data[i].precio,
                //btnEliminar + btnEditar
                boton
            ]);
        }
    }

    function buscarProducto(codigo) {
        console.log(codigo);
        $.ajax({
            type: "POST",
            url: "frmMantDescuento.aspx/ListarProductosTipo",
            data: "{'cadena': '" + codigo + "' }",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                $("#id_codProducto_reg").val(data.d[0]['descripcion'])
            }
        });

    }



    function llenarModal(table) {
        console.log(table.data());
        $("#NombreEditar").val(table.data()[8]);
        $("#fecha-inicio-Editar").val(new Date(table.data()[3]));
        $("#fecha-final-Editar").val(table.data()[4]);
        $("#hora-inicio-Editar").val(table.data()[9]);
        $("#hora-fin-editar").val(table.data()[10]);


        if (table.data()[11] == 1) {
            $("#inlineRadio1-E").prop("checked", true);
        } else {
            $("#inlineRadio2-E").prop("checked", true);
        }
        buscarProducto(table.data()[1]);
        $("#txt-cant-edit").val(table.data()[13]);

        $("#id_unidadBase_edit option[value=" + table.data()[14] + "]").attr("selected", true)

        if (table.data()[16] == 0) {
            $("#checkbox-1").prop("checked", true);
        } else {
            $("#checkbox-2").prop("checked", true);
        }

        //llenado de tablade detalle promocion
        console.log("codigo promocion" + table.data()[0])
        detalle_promocionEdit(table.data()[0]);

        //busqueda de vendedor
        ListarVendedores();
        $(".vendedores option[value=" + table.data()[18] + "]").attr("selected", true)

        //busqueda de cliente
        ListarClientes();
        $(".clientesM option[value=" + table.data()[20] + "]").attr("selected", true)


        $("#txt-cantM_edit").val(table.data()[22]);
        $("#txt-cantV_edit").val(table.data()[23]);
        $("#txt-cantC_edit").val(table.data()[24]);

    }




    const arregloDetalleProducto = []; // arreglo vacio para recolectar datos


    function llenarTablaDet() {
        $("#btnAgregar").click(function () {
            //DESCRIPCION: Lleno los inputs del Modal desde el tr seleccionado.
            var boton = btnEliminarDet;

            var optionSelectedPresentacion = $("#id_unidadBase_promo").find("option:selected");
            var valueSelectedPresentacion = optionSelectedPresentacion.val();

            tablaagregagr.fnAddData([

                $("#id_codProducto_promo").val(),
                $("#id_Producto_promo").val(),
                $("#txt-cantidad").val(),
                valueSelectedPresentacion,
                $("#id_unidadBase_promo")[0].options[valueSelectedPresentacion].text,
                $("#txt-dinero").val(),
                boton

            ]);

            const objDetalleProducto = new Object();
            objDetalleProducto.descProdReg = $("#id_Producto_promo").val(),
                objDetalleProducto.idCantidadProducto = $("#txt-cantidad").val();
            objDetalleProducto.idCostoProducto = $("#txt-dinero").val();
            objDetalleProducto.idpCodProducto = $("#id_codProducto_promo").val();
            objDetalleProducto.idUnidadBaseProducto = $("#id_unidadBase_promo").val();

            arregloDetalleProducto.push(objDetalleProducto);

            console.log('Producto llenarTablaDet:imprimiendo arreglo de objetos');
            console.log(arregloDetalleProducto);    //Array con todo los datos de la tabla en el d[0]

            limpiardetalle();
        });

    }

    llenarTablaDet();


    function limpiardetalle() {

        var id_codProducto_promo = $("#id_codProducto_promo");
        var id_Producto_promo = $("#id_Producto_promo");
        var cantidad = $("#txt-cantidad");
        var id_unidadBase_promo = $("#id_unidadBase_promo");
        var dinero = $("#txt-dinero");

        id_codProducto_promo.val("");
        id_Producto_promo.val("");
        cantidad.val("");
        id_unidadBase_promo.val("");
        dinero.val("");

        var optionSelectUnidB = $("#id_unidadBase_promo").find("option:selected");

        if (optionSelectUnidB.value != 0) {
            optionSelectUnidB.remove();
        }

        optionSelectUnidB.focus();
    }


    function detalle_promocion(codPromocion) {
        //DESCRIPCION : Funcion que me trae la lista del detalle de la preventa por codigo de preventa
        $.ajax({
            type: "POST",
            url: "frmMantProm.aspx/ListarDetalle",
            data: "{'codPromocion': '" + codPromocion + "'}",
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

        for (var i = 0; i < data.length; i++) {

            tablaver.fnAddData([
                data[i].item,
                //data[i].codProductoProm,
                data[i].descripcionProd,
                data[i].cantidad,
                data[i].presentacion,
                data[i].precio
            ]);
        }
    }




    function llenarTabla(data) {
        //DESCRIPCION : Funcion para llenar la tabla de preventas
        for (var i = 0; i < data.length; i++) {

            if (data[i].codEstado == 1) {
                var botones = btnVer + btnEditar + btnEliminar;
            } else {
                botones = btnVer;
            }

            tabla.fnAddData([
                data[i].codPromocion,//correcto
                data[i].codProducto,
                data[i].producto,
                data[i].codfechaI, //correcto
                data[i].codfechaF,//correcto
                data[i].codProveedor,
                data[i].proveedor,
                botones,
                data[i].promocion,
                data[i].codhoraI,
                data[i].codhoraF,
                data[i].codEstado,
                data[i].estado,
                data[i].cantidadProd,
                data[i].codUnidadBase,
                data[i].desUnidadBase,
                data[i].tipoProm,
                data[i].detTipoProm,
                data[i].codVendAplica,
                data[i].desVendAplica,
                data[i].codClienteAplica,
                data[i].desClienetAplica,
                data[i].vecesUsarProm,
                data[i].vecesUsarPromXvend,
                data[i].vecesUsarPromXcliente
            ]);

            if (data[i].estado == 1) {

                var trcolor = $("#tbl_body_table tr")[i];
                trcolor.setAttribute('class', 'colortr');
                var trasig = $(".colortr");
                trasig.css('background', '#77c0ff');
            }

        }


        $("body").on('click', '.btnDelete', function () {
            var tr = $(this).parent().parent();
            var codPromocion = table.row(tr).data()[0]; -
                swal({
                    title: "Se eliminara el registro",
                    text: "¿Esta seguro que desea eliminar el registro?",
                    icon: "warning",
                    buttons: true,
                    dangerMode: true,
                })
                    //Promesa que me trae el valor true al confirmar OK.
                    .then((willDelete) => {
                        if (willDelete) {
                            ElimiarPromocion(codPromocion)
                            swal("Se elimino Registro", {
                                icon: "success",
                            });

                        } else {
                            swal("Se Cancelo la eliminación");
                        }
                    });
        });


        $("body").on('click', '.btnVer', function () {
            var tr = $(this).parent().parent();
            var codPromocion = table.row(tr).data()[0];

            productoVer.val(table.row(tr).data()[2]);
            inicioVer.val(table.row(tr).data()[3]);
            finVer.val(table.row(tr).data()[4]);
            cantM.val(table.row(tr).data()[13]);
            ubase.val(table.row(tr).data()[15]);

            maxP.val(table.row(tr).data()[22]);
            vendedorMax.val(table.row(tr).data()[23]);
            clienteMax.val(table.row(tr).data()[24]);

            detalle_promocion(codPromocion);
        });
    }


    //Eliminar Registro
    function ElimiarPromocion(codPromocion) {

        var json = JSON.stringify({ codPromocion: codPromocion });
        $.ajax({
            type: "POST",
            url: "frmMantProm.aspx/ElimiarPromocion",
            data: json,
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
            },
            success: function () {
                ListarPromociones();
            }
        })
    };

    function EnviarDatos() {
        //DESCRIPCION : Funcion para enviar los datos de los filtros.
        $(btnBuscar).on('click', function () {

            var codfechaInicial = fechaInicial.val();
            var codfechaFinal = fechaFinal.val();

            var codProveedor = proveedor.find("option:selected").val();
            var codTipoVenta = tipoVenta.find("option:selected").val();
            var codProducto = producto_principal.find("option:selected").val();
            var codVendedor = vendedor.find("option:selected").val();
            var codCliente = cliente.find("option:selected").val();
            var codEstado = estado.find("option:selected").val();

            //alert(codfechaInicial + ' ' + codfechaFinal + ' ' + codProveedor + ' ' + codTipoVenta + ' ' + codProducto + ' ' + codVendedor + ' ' + codCliente + ' ' + codEstado);
            var json = JSON.stringify({
                codfechaI: codfechaInicial, codfechaF: codfechaFinal, codProveedor: codProveedor, codTipoVenta: codTipoVenta, codProducto: codProducto, codVendedor: codVendedor, codCliente: codCliente, codEstado: codEstado
            });

            ListarPromociones(json);

        });

    }
    EnviarDatos();


    function ListarPromociones(datos) {
        //alert(datos);
        //DESCRIPCION : Funcion que me trae la lista de preventas
        $.ajax({
            type: "POST",
            url: "frmMantProm.aspx/ListarPromociones",
            data: datos,
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                table.clear().draw();
                llenarTabla(data.d);
                console.log(data.d);
            }
        });


    }






    //Restar Orden al Eliminar
    //function RestarOrden(posicion, cantidadFilas) {
    //    var tr = $(".btnDelete").parent().parent();
    //    var OrdenSelec = parseInt(tr[posicion].cells[0].innerText);
    //    var restantes = cantidadFilas - OrdenSelec;
    //    var cont = 1;
    //    var BodyActual = $("#tbl_body_table tr");
    //    var jsonCodOrdenUpdate = new Array();

    //    for (var i = 1; i <= restantes; i++) {
    //        var newposicion = parseInt(tr[posicion + i].cells[0].innerText) - cont;
    //        tr[posicion + i].cells[0].innerText = newposicion.toString();
    //        var newCodOrden = tr[posicion + i].cells[0].innerText;
    //        jsonCodOrdenUpdate.push
    //            (

    //            {
    //                codUsuario: table.row(BodyActual[posicion + i]).data()[6],
    //                codOrden: parseInt(newCodOrden),
    //                codRuta: table.row(BodyActual[posicion + i]).data()[5]
    //            }
    //            );
    //    }
    //    console.log(jsonCodOrdenUpdate);
    //    ActualizarOrdenRutas(jsonCodOrdenUpdate);
    //}




    //--FILTROS--

    function addSelectVendedor(data) {
        //DESCRIPCION : Funcion para llenar la lista de opciones del select del Vendedor.
        for (var i = 0; i < data.length; i++) {
            vendedor.append("<option value=" + data[i]["ntraUsuario"] + ">" + data[i]["vendedor"] + "</option>");
        }
    }

    //LLAMANDO A LA FUNCIO NDE AJAX VENDEDORES
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


    //--------------



    function addSelectVendedorM(data) {
        //DESCRIPCION : Funcion para llenar la lista de opciones del select del Vendedor.
        for (var i = 0; i < data.length; i++) {
            vendedoresM.append("<option value=" + data[i]["ntraUsuario"] + ">" + data[i]["vendedor"] + "</option>");
        }
    }

    //LLAMANDO A LA FUNCIO NDE AJAX VENDEDORES
    function ListarVendedoresM() {
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
                addSelectVendedorM(data.d);
            }
        })
    }
    ListarVendedoresM();



    //----

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
                addSelectEstadoProm(data.d);
            }
        });
    }
    ListarProveedor();
    function addSelectEstadoProm(data) {
        //DESCRIPCION : Funcion para llenar la lista de opciones del select de proveedores.
        for (var i = 0; i < data.length; i++) {
            proveedor.append("<option value=" + data[i]["codigo"] + ">" + data[i]["descripcion"] + "</option>");
        }
    }

    //----

    function ListarEstadoPrmocion() {
        //DESCRIPCION : Funcion que me trae la lista de proveedores.
        $.ajax({
            type: "POST",
            url: "frmMantProm.aspx/ListarEstadoPrmocion",
            data: "{'flag': '28' }",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                addSelectPromocion(data.d);
            }
        });
    }
    ListarEstadoPrmocion();
    function addSelectPromocion(data) {
        //DESCRIPCION : Funcion para llenar la lista de opciones del select de proveedores.
        for (var i = 0; i < data.length; i++) {
            estado.append("<option value=" + data[i]["estado"] + ">" + data[i]["desEstado"] + "</option>");
        }
    }

    //----

    function ListarProductoVenta() {
        //DESCRIPCION : Funcion que me trae la lista de productos
        $.ajax({
            type: "POST",
            url: "frmMantPreventa.aspx/ListarProductosCombo",
            data: "{'flag': '6' }",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                addSelectProductoVender(data.d);
            }
        });
    }
    ListarProductoVenta();
    function addSelectProductoVender(data) {
        //DESCRIPCION : Funcion para llenar la lista de opciones del select de productos.
        for (var i = 0; i < data.length; i++) {
            producto_compra.append("<option value=" + data[i]["codigo"] + ">" + data[i]["descripcion"] + "</option>");
        }
    }

    // ----    

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
            tipoVenta.append("<option value=" + data[i]["correlativo"] + ">" + data[i]["descripcion"] + "</option>");
        }
    }

    //-----

    function ListarClientes() {
        //DESCRIPCION : Funcion que me trae la lista de clientes.
        $.ajax({
            type: "POST",
            url: "frmMantPreventa.aspx/ListarCampos",
            data: "{'flag': '2' }",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                addSelectcliente(data.d);
            }
        });
    }

    ListarClientes();
    function addSelectcliente(data) {
        //DESCRIPCION : Funcion para llenar la lista de opciones del select de clientes.
        for (var i = 0; i < data.length; i++) {
            cliente.append("<option value=" + data[i]["codigo"] + ">" + data[i]["descripcion"] + "</option>");
        }
    }

    //----------------



    function ListarClientesReg() {
        //DESCRIPCION : Funcion que me trae la lista de clientes.
        $.ajax({
            type: "POST",
            url: "frmMantPreventa.aspx/ListarCamposReg",
            data: "{'flag': '2' }",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                addSelectclienteReg(data.d);
            }
        });
    }

    ListarClientesReg();
    function addSelectclienteReg(data) {
        //DESCRIPCION : Funcion para llenar la lista de opciones del select de clientes.
        for (var i = 0; i < data.length; i++) {
            clienteReg.append("<option value=" + data[i]["codigo"] + ">" + data[i]["descripcion"] + "</option>");
        }
    }

    //----------------


    function ListarProductoProm() {
        //DESCRIPCION : Funcion que me trae la lista de productos
        $.ajax({
            type: "POST",
            url: "frmMantPreventa.aspx/ListarProductosCombo",
            data: "{'flag': '10' }",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                addSelectProductoVenderProm(data.d);
            }
        });
    }
    ListarProductoProm();
    function addSelectProductoVenderProm(data) {
        //DESCRIPCION : Funcion para llenar la lista de opciones del select de productos.
        for (var i = 0; i < data.length; i++) {
            producto_promocion.append("<option value=" + data[i]["codigo"] + ">" + data[i]["descripcion"] + "</option>");
        }
    }

    //------------

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
                        console.log(data.d);
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
            appendTo: $("#exampleModal2"),
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
                cargarComboUnidades(data.d);
            }
        });
    }

    //---------------

    function limpiarDatosSeleccionProductoProm() {
        id_codProducto_promo.val("");
        var optionSelected = id_unidadBase_promo.find("option");
        for (var i = 0; i < optionSelected.length; i++) {
            if (optionSelected[i].value !== '0') {
                optionSelected[i].remove();
            }
        }
    }

    id_Producto_promo.keyup(function () {
        var cad2 = $(this).val();
        if (cad2.length === 0) {
            limpiarDatosSeleccionProductoProm();
        } else {
            buscarProductoNombre3(cad2);
        }
    });
    function buscarProductoNombre3(cadena2) {
        //DESCRIPCION: Listas los productos con autocomplete
        id_Producto_promo.autocomplete({
            minLength: 2,
            source:
            function (request, response) {
                $.ajax({
                    type: "POST",
                    url: "frmMantDescuento.aspx/ListarProductosTipo2",
                    data: JSON.stringify({ cadena: cadena2 }),
                    dataType: "json",
                    contentType: 'application/json; charset=utf-8',
                    error: function (xhr, ajaxOtions, thrownError) {
                        console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
                    },
                    success: function (data) {
                        console.log(data.d);
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
                id_Producto_promo.val(ui.item.label);
                id_codProducto_promo.val(ui.item.codigo);
                unidadBaseProductoPromo(ui.item.codigo);
            },
            appendTo: $("#exampleModal2"),
            change: function (event, ui) {
                if (!ui.item) {
                    id_Producto_promo.val('');
                    id_codProducto_promo.val('');
                }
            }
        });
    }

    function cargarComboUnidadesPromo(data) {
        //DESCRIPCION : Funcion para llenar la lista de opciones del select unidades
        id_unidadBase_promo.append("<option value=" + data.correlativo + ">" + data.descripcion + "</option>");
    }

    function unidadBaseProductoPromo(codProducto) {
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
                cargarComboUnidadesPromo(data.d);
            }
        });
    }





    function LlenarDetallesPromocion(datos) {
        console.log(datos);
        $.ajax({
            type: "POST",
            url: "frmMantProm.aspx/InsertDetallePromocion",
            data: datos,
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (response) {
                console.log(response);
            }
        });
    }



    function InsertarPromocion(data) {
        //Descricion : Recibo los parametros del evento click del GuardadoDeDatosModal
        $.ajax({
            type: "POST",
            url: "frmMantProm.aspx/InsertarPromocion",
            data: data,
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (response) {
                //Hasta aca tenemos el SKU 
                if (0 == 0) {
                    for (let i = 0; i < arregloDetalleProducto.length; i++) {
                        ///aqui recorreremos el arreglo q  tiene nuestra tabla para guardar los datos
                        var json = JSON.stringify({

                            descProductoReg: arregloDetalleProducto[i].descProdReg,
                            cantProductoRegalar: arregloDetalleProducto[i].idCantidadProducto,
                            costoProdRegalar: arregloDetalleProducto[i].idCostoProducto,
                            codProductoRegalar: arregloDetalleProducto[i].idpCodProducto,
                            idUnidadBaseProdReg: arregloDetalleProducto[i].idUnidadBaseProducto,

                        });

                        LlenarDetallesPromocion(json);
                    }

                    //Mpmensaje.html("Se registro correctamente");
                    //Mpmensaje.css("color", "#ffffff");
                    //Mmensaje.css("background-color", "#337ab7")
                    //    .css("border-color", "#2e6da4");
                    //Mmensaje.css("display", "block");

                } else {

                    //Mpmensaje.css("color", "rgba(179, 10, 10, 0.69)");
                    //Mmensaje.css("background-color", "rgba(255, 0, 0, 0.51)")
                    //    .css("border-color", "rgb(203, 46, 46)");
                    //Mpmensaje.html("Error al registrar " + codProduct);
                    //Mmensaje.css("display", "block");

                }

            }
        });
    }

    function GuardarDatosModal() {
        //DESCRIPCION : Esta funcion me dispara un evento click,
        // para hacer el guardado de datos, Llamando a la funcion InsertarProduct
        $("#btnGuardar").click(function () {
            //obtención valores del modal
            var descPromocionX = descPromocion.val();
            var fechaInicioX = fechaInicio.val();
            var fechaFinX = fechaFin.val();
            var horaInicioX = horaInicio.val();
            var horaFinX = horaFin.val();

            var codProductoPrinX = id_codProducto_reg.val();
            var descProductoPrinX = id_Producto_reg.val();
            var cantidadPrincipalX = cantidadPrincipal.val();
            var optionSelectUnidBase = id_unidadBase.find("option:selected");
            var unidadBasePrincialX = optionSelectUnidBase.val();

            //var combo = document.getElementById("#id_unidadBase");
            //var desUnidadBaseX = combo.options[combo.selectedIndex].text;

            //var desUnidadBaseX = $("#id_unidadBase")[0].options[unidadBasePrincialX].text;


            var optionSelectUnidBase = vendedoresM.find("option:selected");
            var vendedoresMX = optionSelectUnidBase.val();

            var optionSelectUnidBase = clienteReg.find("option:selected");
            var clienteRegX = optionSelectUnidBase.val();

            var cantUsarMaxMX = cantUsarMaxM.val();
            var cantVecesVendMX = cantVecesVendM.val();
            var cantVecesCClienteMX = cantVecesClienteM.val();



            var aplicaContadoX = aplicaContado.val();
            var aplicaCreditoX = aplicaCredito.val();


            //var valueSelectedVendedor = vendedoresMX.val();
            //var valueSelectedCliente = clienteRegX.val();

            if (descPromocionX.length == 0) {
                swal("Debe agregar nombre de la Promoción", {
                    icon: "info"
                });
                descPromocion.focus();
            }
            else {
                if (fechaInicioX == 0) {
                    swal("Debe agregar fecha inicial de la promoción", {
                        icon: "info"
                    });
                    fechaInicio.focus();
                }
                else {
                    if (fechaFinX == 0) {
                        swal("Debe agregar fecha final de la promoción", {
                            icon: "info"
                        });
                        fechaFin.focus();
                    }
                    else {
                        if (fechaFinX <= fechaInicioX) {
                            swal("La fecha final debe ser superior a la fecha inicial", {
                                icon: "info"
                            });
                            horaFin.focus();
                        }
                        else {
                            if (horaInicioX == 0) {
                                swal("Debe agregar hora inicial de la promoción", {
                                    icon: "info"
                                });
                                horaInicio.focus();
                            }
                            else {
                                if (horaFinX == 0) {
                                    swal("Debe agregar hora final de la promoción", {
                                        icon: "info"
                                    });
                                    horaFin.focus();
                                }
                                else {
                                    if (descProductoPrinX == 0) {
                                        swal("Debe seleccionar un producto principal", {
                                            icon: "info"
                                        });
                                        id_Producto_reg.focus();
                                    }
                                    else {
                                        if (cantidadPrincipalX == 0) {
                                            swal("Debe ingresar la cantidad mínima del producto", {
                                                icon: "info"
                                            });
                                            cantidadPrincipal.focus();

                                        }
                                        else {

                                            var json = JSON.stringify({
                                                promocion: descPromocionX,
                                                fechaInicial: fechaInicioX,
                                                fechaFinal: fechaFinX,
                                                horaInicio: horaInicioX,
                                                horaFin: horaFinX,
                                                activarProm: '1',                     //CAMBIAR EL DATO EN DURO

                                                descProductoPrin: descProductoPrinX,
                                                codProductoPrin: codProductoPrinX,

                                                cantidadPrincipal: cantidadPrincipalX,
                                                descUnidadBase: 'UNINDAD',
                                                unidadBasePrincipal: unidadBasePrincialX,

                                                desvendedorAplica: 'vendedor',      //CAMBIAR EL DATO EN DURO
                                                vendedorAplica: vendedoresMX,

                                                desclienteAplica: 'Cliente',        //CAMBIAR EL DATO EN DURO
                                                codclienteAplica: clienteRegX,

                                                cantMaxProm: cantUsarMaxMX,

                                                cantMaxVend: cantVecesVendMX,

                                                cantMaxCliente: cantVecesCClienteMX,

                                                contadoCredito: 'contado',          //CAMBIAR EL DATO EN DURO
                                                codContadoCredito: '1'                 //CAMBIAR EL DATO EN DURO

                                            });

                                            InsertarPromocion(json);
                                            limpiarDatos();

                                        }


                                    }
                                }
                            }
                        }
                    }
                }

            }

        })
    }

    GuardarDatosModal();

    function limpiarDatos() {
        //descProducto.val("");
        //flagVenta.val("");

        //var optionSelectUnidBase = PresentacionProduc.find("option:selected");
        //var optionSeleccionCat = categoriaX.find("option:selected");
        //var optionSeleccionsubCat = subcategoriaX.find("option:selected");
        //var optionSelectProveedor = proveedormodal.find("option:selected");
        //var optionselectTipProduc = tipoProducto.find("option:selected");
        //var optionSelectFabricante = fabricanteX.find("option:selected");

        //if (optionSelectUnidBase.value != 0) {
        //    optionSelectUnidBase.remove();
        //}

        //if (optionSeleccionCat.value != 0) {
        //    optionSeleccionCat.remove();
        //}

        //if (optionSeleccionsubCat.value != 0) {
        //    optionSeleccionsubCat.remove();
        //}

        //if (optionSelectProveedor.value != 0) {
        //    optionSelectProveedor.remove();
        //}

        //if (optionselectTipProduc.value != 0) {
        //    optionselectTipProduc.remove();
        //}

        //if (optionSelectFabricante.value != 0) {
        //    optionSelectFabricante.remove();
        //}
        //descProducto.focus();
    }




});

