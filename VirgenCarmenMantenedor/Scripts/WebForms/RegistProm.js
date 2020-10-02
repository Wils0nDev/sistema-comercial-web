
$(document).ready(function () {
    //Lista de Variables
    var vendedores = $(".vendedores");
    var selectRutas = $("#rutas");
    var Mabreviatura = $("#Mabreviatura");
    var McodVendedorVal = $("#McodVendedor");
    var Mvendedor = $("#Mvendedor");
    var selectDias = $("#dias");
    var btnGuardar = $("#btnGuardar");
    var Mmensaje = $("#Mmensaje");
    var Mpmensaje = $("#Mpmensaje");
    var btnActualizar = $("#btnActualizar");
    var btnEditar = '<button type="button" title="Editar" class="icon-pencil btnEditar" data-toggle="modal"  data-target="dfffdd" ></button>'
    var btnEliminar = ' <button type="button" id="" class="icon-bin btnDelete" data-toggle="tooltip"  title="Eliminar" ></button>'
    var btnVer = '<button type="button" title="Ver" class="icon-pencil btnEditar" data-toggle="modal"  data-target="#exampleModal" ></button>'
    var btnCancelar = $("#btnCancelar");
    var tableBody = $("#tbl_body_table");
    var buttonModal = $("#buttonModal");
    var McodOrden = $("#McodOrden");
    var MRutaAnterior = $("#MRutaAnterior");
    var MmensajeOrden = $('#MmensajeOrden');

   

    var producto = $('#producto');
    var producto_compra = $('.producto');
    

    var productoNombre = $('#productoNombre');
    var clienteNombre = $('#clienteNombre');
    var nombreVendedor = $('#nombreVendedor');
    var nombreVendedor = $('#nombreVendedor');

    var estado = $('#estado');
    var proveedor = $('#id_proveedor');
    var tipoVenta = $('#tipoVenta');
    var fechaInicial = $('#min_date');
    var fechaFinal = $('#max_date');
    var cliente = $('#cliente');
    var vendedor = $('#vendedor');
    var producto_principal = $('#producto_principal');

    var btnBuscar = $("#id_btnBuscar");

     
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
                "targets": [1, 5],
                "visible": false,
                "searchable": false
            }

        ]
    });


    //creo variables despues de que el DataTable este creado en el DOM.
    var tabla = $("#tb_rutas").dataTable(); //funcion jquery
    var table = $("#tb_rutas").DataTable(); //funcion DataTable-libreria
    table.columns.adjust().draw();



    function llenarTabla(data) {
        //DESCRIPCION : Funcion para llenar la tabla de preventas
        for (var i = 0; i < data.length; i++) {
            tabla.fnAddData([
                data[i].codPromocion,//correcto
                data[i].codProducto,
                data[i].producto,
                data[i].codfechaI, //correcto
                data[i].codfechaF,//correcto
                data[i].codProveedor,
                data[i].proveedor,

                btnVer + btnEditar + btnEliminar
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
    }




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

            var json = JSON.stringify({
                codfechaI: codfechaInicial, codfechaF: codfechaFinal, codProveedor: codProveedor, codTipoVenta: codTipoVenta, codProducto: codProducto, codVendedor: codVendedor, codCliente: codCliente, codEstado: codEstado
            });
            ListarPromociones(json);
        });
    }
    EnviarDatos();


    function ListarPromociones(datos) {
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
            vendedores.append("<option value=" + data[i]["ntraUsuario"] + ">" + data[i]["vendedor"] + "</option>");
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

    //----

    function ListarProducto() {
        //DESCRIPCION : Funcion que me trae la lista de productos
        $.ajax({
            type: "POST",
            url: "frmMantPreventa.aspx/ListarProductos",
            data: "{'flag': '7' }",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                addSelectProducto(data.d);
            }
        });
    }
    ListarProducto();
    function addSelectProducto(data) {
        //DESCRIPCION : Funcion para llenar la lista de opciones del select de productos.
        for (var i = 0; i < data.length; i++) {
            producto.append("<option value=" + data[i]["codigo"] + ">" + data[i]["descripcion"] + "</option>");
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








});

