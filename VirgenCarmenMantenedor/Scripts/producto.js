$(document).ready(function () {
    var categoria = $("#categoria");                //filtro de categoria
    var subcategoria = $("#subcategoria");          //filtro de subcategoria
    var categoriaX = $("#dllcategoria");
    var subcategoriaX = $("#dllsubcategoria");
    var fabricante = $("#fabricante");               //filtro de búsqueda de fabricante
    var fabricanteX = $("#dllfabricante");
    var proveedor = $("#proveedor");                  //filtro de búsqueda de proveedor
    var proveedormodal = $("#dllproveedor");
    var tipoProducto = $("#tipoProducto")
    var PresentacionProduc = $(".presentacion")
    var descripcionP = $("#txtProducto")              //busqueda 
    var descProducto = $("#Mdescripcion");
    var munidadBase = $("#unidadbase");

    var flagVenta = $("#flagVenta");
    var Mpmensaje = $("#Mpmensaje");
    var Mmensaje = $("#Mmensaje");
    var tblProducto = $("#id_tblProducto");
    var btnBuscar = $("#btnBuscar");

    var btnGuardar = $("#buttonModal");
    var codigoM = $("#Msku");

    var btnEditar = ' <button type="button" title="Editar" class="icon-pencil btnEditar" data-toggle="modal" data-target="#productoEditarModal"></button>';
    var btnEliminar = ' <button type="button" title="Anular" class="icon-bin btnDelete" data-toggle="modal" data-target="#modalAnular"></button>';

    //Variables de editar modal producto
    var categoriaE = $("#dllcategoriaE");
    var subcategoriE = $("#dllsubcategoriaE");
    var descripcionE = $("#MdescripcionE");
    var proveedorE = $("#dllproveedorE");
    var fabricanteE = $("#dllfabricanteE");
    var UnidadBaseE = $("#unidadbaseE");
    var presentacionE = $("#presentacionE");
    var flagE = $("#flagVentaE");
    var tipoProductoE = $("#tipoProductoE");

    var MpmensajeE = $("#MpmensajeE");
    var MmensajeE = $("#MmensajeE");
    //Variables de detalle de producto
    var PresentacionProducX = $("#presentacion");



    var codProdutoE = $("#MskuE");



    var btnagregar = $("#btnAgregar");    //BOTON DE AGREGAR PRESENTACIÓN DE PRODUCTO

    /* INICIO----------------------FUNCIONES DE CARGAR LOS SELECT---------------------------------------------------------------------*/
    function cargarFlag() {
        //DESCRIPCIÓN: función para cargar en el select el flag 0 y 1
        var flag = ["VENTA", "AGREGADO"];
        flag.sort();
        for (var i in flag) {
            document.getElementById("flagVenta").innerHTML += "<option value='" + i + "'>" + flag[i] + "</option>";
            document.getElementById("flagVentaE").innerHTML += "<option value='" + i + "'>" + flag[i] + "</option>";
        }
    }

    cargarFlag();

    function addSelectCategoria(data) {
        //DESCRIPCIÓN: función para llenar la lista de categoria
        for (var i = 0; i < data.length; i++) {
            categoria.append("<option value=" + data[i]["codCategoria"] + ">" + data[i]["descCategoria"] + "</option>");
        }

    }

    function ListarCategoria() {
        $.ajax({
            type: "POST",
            url: "frmMantProducto.aspx/ListarCategorias",
            data: "{'flag': '5'}",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                addSelectCategoria(data.d);
            }
        })

        categoria.change(function () {

        })

    }

    function addSelectCategoriax(data) {
        //DESCRIPCIÓN: función para llenar la lista de categoria
        for (var i = 0; i < data.length; i++) {
            categoriaX.append("<option value=" + data[i]["codCategoria"] + ">" + data[i]["descCategoria"] + "</option>");
            categoriaE.append("<option value=" + data[i]["codCategoria"] + ">" + data[i]["descCategoria"] + "</option>");
        }
    }


    //inicio: Desde aqui se declara a la tabla del listado del detalle//

    $("#idDatePresentacionEdit").DataTable({
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
                "width": "30%",
                "targets": [2, 3]
            },
            {
                "targets": [0,1],
                "visible": false,
                "searchable": false
            }
        ]

    })

    ///LLENADO DE TABLA PRESENTACIÓN DESDE LA CONSULTA DE LA BD tblDetallePresentacion
    var tablaPresentEdit = $("#idDatePresentacionEdit").dataTable(); //funcion jquery 
    var tablePresentEdit = $("#idDatePresentacionEdit").DataTable(); //funcion DataTable-libreria
    tablePresentEdit.columns.adjust().draw();



    function ListarCategoriax() {
        $.ajax({
            type: "POST",
            url: "frmMantProducto.aspx/ListarCategorias",
            data: "{'flag': '5'}",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                addSelectCategoriax(data.d);
            }
        })
        categoriaX.change(function () {

        })

    }

    ListarCategoria();
    obtenerfabricante();
    obtenerfabricanteX();
    obtenerProveedor();
    obtenerTipoProducto();
    ObtenerPresentacionProducto();
    ListarCategoriax();
    obtenerDetalleProduct();

    $("#categoria").change(function () {
        let codigo = $(".categoria").val();
        obtenerSubCategoria(codigo);
    });
    $("#dllcategoria").change(function () {
        let codigo = $("#dllcategoria").val();
        obtenerSubCategoriaX(codigo);
    });


    function obtenerSubCategoria(codigo) {
        if (codigo == '0') {
            subcategoria.children().remove();
            subcategoria.append("<option value='0'>-Seleccionar-</option>");

        } else {
            $.ajax({
                type: "POST",
                url: "frmMantProducto.aspx/ListarSubCategoria",
                data: "{'codCat': '" + codigo + "'}",
                contentType: 'application/json; charset=utf-8',
                error: function (xhr, ajaxOtions, thrownError) {
                    console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
                },
                success: function (data) {
                    listarSubCategora(data.d);
                }
            });
        }

    }

    function listarSubCategora(data) {
        $(".subcategoria option").remove();
        subcategoria.append("<option value='0'>-Seleccionar-</option>");
        for (var i = 0; i < data.length; i++) {
            subcategoria.append("<option value=" + data[i]["NtraSubcategoria"] + ">" + data[i]["DescSubcategoria"] + "</option>");
        }
    }

    function obtenerSubCategoriaX(codigo) {
        if (codigo == '0') {
            subcategoriaX.children().remove();
            subcategoriaX.append("<option value='0'>-Seleccionar-</option>");

        } else {
            $.ajax({
                type: "POST",
                url: "frmMantProducto.aspx/ListarSubCategoria",
                data: "{'codCat': '" + codigo + "'}",
                contentType: 'application/json; charset=utf-8',
                error: function (xhr, ajaxOtions, thrownError) {
                    console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
                },
                success: function (data) {
                    listarSubCategoraX(data.d);
                }
            });
        }

    }

    function listarSubCategoraX(data) {
        $("#dllsubcategoria option").remove();
        subcategoriaX.append("<option value='0'>-Seleccionar-</option>");
        for (var i = 0; i < data.length; i++) {
            subcategoriaX.append("<option value=" + data[i]["NtraSubcategoria"] + ">" + data[i]["DescSubcategoria"] + "</option>");

        }
    }

    // Inicio: cargar select de subcategoria---------------------------------------------
    $("#dllcategoriaE").change(function () {
        let codigo = $("#dllcategoriaE").val();
        obtenerSubCategoriaEditar(codigo);
    });

    function obtenerSubCategoriaEditar(codigo) {
        if (codigo == '0') {
            subcategoriE.children().remove();
            subcategoriE.append("<option value='0'>-Seleccionar-</option>");
            console.log("Entro a 0");
        } else {
            console.log("Entro a consulta" + codigo);
            $.ajax({
                type: "POST",
                url: "frmMantProducto.aspx/ListarSubCategoria",
                data: "{'codCat': '" + codigo + "'}",
                contentType: 'application/json; charset=utf-8',
                error: function (xhr, ajaxOtions, thrownError) {
                    console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
                },
                success: function (data) {
                    console.log("VALUE " + data);
                    listarSubCategoriaEditar(data.d);
                }
            });
        }

    }

    //function listarSubCategoriaEditar(data) {
    //    //$("#dllsubcategoriaE option").remove();
    //    //subcategoriE.append("<option value='0'>-Seleccionar-</option>");

    //    for (var i = 0; i <= data.length; i++) {

    //        subcategoriE.append("<option value=" + data[i]["ntraSubcategoria"] + ">" + data[i]["descripcion"] + "</option>");
    //    }
    //}


    function listarSubCategoriaEditar(data) {
        $("#dllsubcategoriaE option").remove();
        subcategoriE.append("<option value='0'>-Seleccionar-</option>");
        for (var i = 0; i < data.length; i++) {
            subcategoriE.append("<option value=" + data[i]["NtraSubcategoria"] + ">" + data[i]["DescSubcategoria"] + "</option>");

        }
    }


    //Fin: cargar select de subcategoria -----------------------------------------------------
    function obtenerfabricante() {
        $.ajax({
            type: "POST",
            url: "frmMantProducto.aspx/ListaFabricante",
            data: "{'flag': '27'}",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                listarFabricante(data.d);
            }
        })
    }

    function obtenerfabricanteX() {
        $.ajax({
            type: "POST",
            url: "frmMantProducto.aspx/ListaFabricante",
            data: "{'flag': '27'}",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                listarFabricanteX(data.d);
            }
        })
    }

    function listarFabricante(data) {
        for (var i = 0; i < data.length; i++) {
            fabricante.append("<option value=" + data[i]["codigoFabricante"] + ">" + data[i]["descFabricante"] + "</option>");
        }
    }

    function listarFabricanteX(data) {
        for (var i = 0; i < data.length; i++) {
            fabricanteX.append("<option value=" + data[i]["codigoFabricante"] + ">" + data[i]["descFabricante"] + "</option>");
            fabricanteE.append("<option value=" + data[i]["codigoFabricante"] + ">" + data[i]["descFabricante"] + "</option>");
        }
    }

    function obtenerProveedor() {
        $.ajax({
            type: "POST",
            url: "frmMantProducto.aspx/ListaProveedor",
            data: "{'flag': '23'}",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                listarProveedor(data.d);
            }
        })
    }

    function listarProveedor(data) {
        for (var i = 0; i < data.length; i++) {
            proveedor.append("<option value=" + data[i]["codigoProveedor"] + ">" + data[i]["descproveedor"] + "</option>");
            proveedormodal.append("<option value=" + data[i]["codigoProveedor"] + ">" + data[i]["descproveedor"] + "</option>");
            proveedorE.append("<option value=" + data[i]["codigoProveedor"] + ">" + data[i]["descproveedor"] + "</option>");
        }
    }

    function obtenerTipoProducto() {
        $.ajax({
            type: "POST",
            url: "frmMantProducto.aspx/ListaCampos",
            data: "{'flag': '29'}",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                ListaTipoProducto(data.d);
            }
        })
    }
    //funcion tipo producto
    function ListaTipoProducto(data) {
        var tipoProducto = $("#tipoProducto");
        for (var i = 0; i < data.length; i++) {
            tipoProducto.append("<option value=" + data[i]["correlativo"] + ">" + data[i]["descripcion"] + "</option>");
            tipoProductoE.append("<option value=" + data[i]["correlativo"] + ">" + data[i]["descripcion"] + "</option>");
        }
    }

    function ObtenerPresentacionProducto() {
        $.ajax({
            type: "POST",
            url: "frmMantProducto.aspx/ListaCampos",
            data: "{'flag': '26'}",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                ListaPresentacionProduct(data.d);
            }
        })
    }
    function ListaPresentacionProduct(data) {
        for (var i = 0; i < data.length; i++) {
            PresentacionProduc.append("<option value=" + data[i]["correlativo"] + ">" + data[i]["descripcion"] + "</option>");
        }
    }

    function obtenerDetalleProduct() {
        $.ajax({
            type: "POST",
            url: "frmMantProducto.aspx/ListaCampos",
            data: "{'flag': '26'}",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                ListaPresentacionProductX(data.d);
            }
        })
    }
    function ListaPresentacionProductX(data) {
        for (var i = 0; i < data.length; i++) {
            PresentacionProducX.append("<option value=" + data[i]["correlativo"] + ">" + data[i]["descripcion"] + "</option>");
            UnidadBaseE.append("<option value=" + data[i]["correlativo"] + ">" + data[i]["descripcion"] + "</option>");
            presentacionE.append("<option value=" + data[i]["correlativo"] + ">" + data[i]["descripcion"] + "</option>");
        }
    }
    /*-FIN-------------------------FUNCIONES DE CARGAR LOS SELECT----------------------------------------------------------------*/
    //Convertimos la tabla producto en dataTable y le pasamos parametros
    tblProducto.DataTable({
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
        dom: 'lBfrtip',
        buttons: [
            {
                extend: 'excelHtml5',
                text: '<span class="icon-file-excel"></span>',
                titleAttr: 'Excel',
                title: 'Lista de Productos',
                customize: function (xlsx) {
                    var sheet = xlsx.xl.worksheets['sheet1.xml'];
                    //All cells
                    $('row c', sheet).attr('s', '25');
                    //First row
                    $('row:first c', sheet).attr('s', '32');
                    //Second row
                    $('row c[r*="2"]', sheet).attr('s', '47');
                    //doce row
                    $('row c[r*="12"]', sheet).attr('s', '25');
                    $('row c[r*="24"]', sheet).attr('s', '25');
                },
                //Para que excel solo me exporte ciertas columnas
                exportOptions: {
                    columns: [0, 2, 4, 6, 8, 9, 10, 12, 13]
                }
            }],
        columnDefs: [
            {

                "width": "2%",
                "targets": [0]
            },
            {
                "width": "25%",
                "targets": [9]
            },
            {
                "width": "15%",
                "targets": [2, 4, 6, 8, 10, 12, 13, 14]
            },
            {
                "targets": [1, 3, 5, 7, 11],
                "visible": false,
                "searchable": false
            }

        ]
    })

    //creación de variables de que dataTable este creado en el DOM
    var tabla = $("#id_tblProducto").dataTable(); //funcion jquery
    var table = $("#id_tblProducto").DataTable(); //funcion DataTable-libreria
    table.columns.adjust().draw();

    function ListarProductos(datos) {
        //DESCRIPCIÓN: Función de listar los productos
        $.ajax({
            type: "POST",
            url: "frmMantProducto.aspx/ListaProductos",
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
    var data;
    var codigoProducto;
    function llenarTabla(data) {
        //DESCRIPCION : Funcion para llenar la tabla de productos
        //console.log(data);
        var botones = btnEditar + btnEliminar;
        for (var i = 0; i < data.length; i++) {
            tabla.fnAddData([
                data[i].codProducto,                                               //0
                data[i].codCategoria,                                              //1
                data[i].descCategoria,                                             //2
                data[i].codSubCategoria,                                           //3
                data[i].descSubCategoria,                                          //4
                data[i].codProveedor,                                              //5
                data[i].descProveedor,                                             //6
                data[i].codFabricante,                                             //7
                data[i].descFabricante,                                            //8
                data[i].descProducto,                                              //9
                data[i].descUndBase,                                               //10
                data[i].tipoProducto,                                              //11
                data[i].desctipoProducto,                                          //12
                data[i].flagVenta,                //13
                //  ((data[i].flagVenta == 1) ? "VENTA" : "AGREGADO"),                //13
                botones
            ]);
        }
        //Evento click para eliminar un producto
        //Ejecuta libreria sweet alert
        $("body").on('click', '.btnDelete',function () {
            
            //Obtengo los valores del producto seleccionado        
            var tr = $(this).parent().parent();
            var codProduct = table.row(tr).data()[0];
            console.log(codProduct);
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
                        EliminarProducto(codProduct)
                        swal("Se elimino Registro", {
                            icon: "success",
                        });
                        EnviarDatos();
                    } else {
                        swal("Se Cancelo la eliminación");

                    }
                });
        });

        //$(".btnEditar").click(function () {
         $("body").on('click', '.btnEditar', function () {
            MmensajeE.css('display', 'none');
            var tr = $(this).parent().parent();

           //  var codProducto = table.row(tr).data()[0];
             //AQUI MUESTRO LOS DATOS EN LA MODAL DE UN PRODUCTO SELECCIONADO.
             //codProdutoE.val(table.row(tr).data()[0]);

             codProdutoE.val(table.row(tr).data()[0]);

            descripcionE.val(table.row(tr).data()[9]);
            UnidadBaseE.val(table.row(tr).data()[11]);
            console.log("Categoria: " + table.row(tr).data()[1]);
            categoriaE.val(table.row(tr).data()[1]);

            proveedorE.val(table.row(tr).data()[5]);
            fabricanteE.val(table.row(tr).data()[7]);
            tipoProductoE.val(table.row(tr).data()[11]);

            let codigo = table.row(tr).data()[1];
            obtenerSubCategoriaEditar(codigo);
            subcategoriE.val(table.row(tr).data()[3]);
           
            console.log("SUB Categoria: " + table.row(tr).data()[13]);
            flagE.val(table.row(tr).data()[13]);


            codigoProducto = table.row(tr).data()[0];
            console.log(codigoProducto);

            ListarPresentacionDetalleProduct(codigoProducto);
            BotonActualizar(codigoProducto);

            //Fin: Visualización de botones y tabla

        });

        $(function () {
            $('[data-toggle="#exampleModal"]').tooltip()
        })

        var tr = $("#tbl_body_table tr");
    }

    function ActualizarProducto(codigo) {

        var optionSelectUnidBase = UnidadBaseE.find("option:selected");
        var valueSelectUniBase = optionSelectUnidBase.val();
        var optionSeleccionCat = categoriaE.find("option:selected");
        var valueSelectCat = optionSeleccionCat.val();
        var optionSeleccionsubCat = subcategoriE.find("option:selected");
        var valueSelectsubCat = optionSeleccionsubCat.val();
        var optionSelectProveedor = proveedorE.find("option:selected");
        var valueSelectProveedor = optionSelectProveedor.val();
        var optionselectTipProduc = tipoProductoE.find("option:selected");
        var valueSelectTipProduct = optionselectTipProduc.val();
        var optionSelectFabricante = fabricanteE.find("option:selected");
        var valueSelectFabricant = optionSelectFabricante.val();
        var optionSelectFlag = flagE.find("option:selected");
        var valueSelectFlag = optionSelectFlag.val();

        var obj = JSON.stringify({
            codProducto: codigo, descripcion: $("#MdescripcionE").val(), codUnidadBase: valueSelectUniBase, codCategoria: valueSelectCat,
            codsubcat: valueSelectsubCat, tipoProduct: valueSelectTipProduct, flag: valueSelectFlag, codFabricant: valueSelectFabricant, codProveedor: valueSelectProveedor
        });
       // console.log(obj);
        $.ajax({
            type: "POST",
            url: "frmMantProducto.aspx/ActualizarProduct",
            data: obj,
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (response) {
              //  console.log("respuest" + response);
                
                if (response.d[0] != 0 || response.d[0] == 0) {
                    for (let i = 0; i < arregloDetalleProducto.length; i++) {
                        ///aqui recorreremos el arreglo q  tiene nuestra tabla para guardar los datos
                        var json = JSON.stringify({
                          //  codProducto: response.d[1],
                            codProducto: codigo,
                            codPresentacion: arregloDetalleProducto[i].codDetPresents,
                            cantUB: arregloDetalleProducto[i].idcontubase
                        });

                        LlenarDetallesProducto(json);
                        //console.log("este es para ver si captura el valor para re:", json);
                    }


                    MpmensajeE.html("Se Actualizo correctamente");
                    MpmensajeE.css("color", "#ffffff");
                    MmensajeE.css("background-color", "#337ab7")
                        .css("border-color", "#2e6da4");
                    MmensajeE.css("display", "block")

                } else {
                    MpmensajeE.css("color", "rgba(179, 10, 10, 0.69)");
                    MmensajeE.css("background-color", "rgba(255, 0, 0, 0.51)")
                        .css("border-color", "rgb(203, 46, 46)");
                    MpmensajeE.html("No se pudo actualizar ");
                    MmensajeE.css("display", "block");
                }
            }
            
        });
    }

    function EliminarPresentacionActualizar(codProduct, codPesent) {
        //DESCRIPCIÓN: recibo el código del producto(SKU) y cambia la marca baja
        var json = JSON.stringify({ cod: codProduct, codP: codPesent});
        $.ajax({
            type: "POST",
            url: "frmMantProducto.aspx/EliminarPresentacionProductActualizar",
            data: json,
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                //console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (response) {

                if (response.d > 0) {
                    ListarPresentacionDetalleProduct(codProduct);
                }
            }
        })
    }

    function BotonActualizar(codigo) {
        //DESCRIPCIÓN: esta función me dispara el evento click, para actalizar los productos
        $("#btnActualizar").click(function () {
            console.log(codigo);
            ActualizarProducto(codigo);
         //   limpiarDatosActualizar();
        })
    }
    //function limpiarDatosActualizar() {
    //    descProducto.val("");
    //    flagVenta.val("");
    //    //limpiar los selected ( con el seleccionar)
    //    var optionSelectUnidBase = presentacionE.find("option:selected");
    //    var optionSeleccionCat = categoriaE.find("option:selected");
    //    var optionSeleccionsubCat = subcategoriE.find("option:selected");
    //    var optionSelectProveedor = proveedorE.find("option:selected");
    //    var optionselectTipProduc = tipoProductoE.find("option:selected");
    //    var optionSelectFabricante = fabricanteE.find("option:selected");            


    //    // optionSelectUnidBase.val(0);       
    //    categoriaE.val(0);
    //    subcategoriE.val(0);
    //    proveedorE.val(0);
    //    tipoProductoE.val(0);
    //    fabricanteE.val(0);        
    //    UnidadBaseE.val(0);

    //    descripcionE.focus();
    //}

    function listarDatosByCodProduc(codProducto) {
        //DESCIPCIÓN: datos de productos con detalle buscando con el sku del producto (NO ULITIZADA)
        var json = JSON.stringify({ 'codProducto': codProducto });
        //      console.log(json);    
        $.ajax({
            type: "POST",
            url: "frmMantProducto.aspx/ListaProductoByCod",
            data: json,
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                console.log(data.d);
            }
        })
    }
    function EnviarDatos() {
        //DESCRIPCIÓN: Función para enviar los datos de los filtros 
        $("#btnBuscar").on('click', function () {
            var codCategoria = categoria.find("option:selected").val();
            var codSubcategoria = subcategoria.find("option:selected").val();
            var codigoFabricante = fabricante.find("option:selected").val();
            var codigoProveedor = proveedor.find("option:selected").val();
            var descripcion = descripcionP.val();

            var json = JSON.stringify({

                codCategoria: codCategoria, codSubcategoria: codSubcategoria,
                codigoFabricante: codigoFabricante, codigoProveedor: codigoProveedor, descripcion: descripcion
            });
            //console.log("datos: "+json);          
            ListarProductos(json);
            LimpiarSelectBusqueda(); //limpio despues de cada click en buscar
        });
        //Sino presiona el boton buscar debe cargar tabla con datos
        //  TRAE LA DATA
        var json = JSON.stringify({

            codCategoria: 0, codSubcategoria: 0,
            codigoFabricante: 0, codigoProveedor: 0, descripcion: ''
        });
        ListarProductos(json);
    }

    function LimpiarSelectBusqueda() {
        //DESCRIPCIÓN: esta función es para limpiar los select después de la búsqueda realizada
        categoria.val(0);
        subcategoria.val(0);
        proveedor.val(0);
        fabricante.val(0);
        descripcionP.val("");
    }
    EnviarDatos();

    function Evento() {
        $("#buttonModal").click(function () {
            //DESCIPCIÓN: este evento sirve al dar click en el boton agregar un NUEVO PRODUCTO
            limpiarDatos();
            limpiardetalle();
            //tableDet.clear();
            $("#btnGuardar").show();
         
        });
    }
    Evento();

    function EliminarProducto(codProduct) {
        //DESCRIPCIÓN: recibo el código del producto(SKU) y cambia la marca baja
        var json = JSON.stringify({ Cod: codProduct });
        $.ajax({
            type: "POST",
            url: "frmMantProducto.aspx/EliminarProducto",
            data: json,
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                //console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (response) {

                if (response.d > 0) {
                    ListarProductos(codProduct);
                }
            }
        })
    }

    function LlenarDetallesProducto(datos) {
        console.log(datos);
        $.ajax({
            type: "POST",
            url: "frmMantProducto.aspx/InsertDetalleProducto",
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

    function InsertarProducto(data) {
        //Descricion : Recibo los parametros del evento click del GuardadoDeDatosModal
        $.ajax({
            type: "POST",
            url: "frmMantProducto.aspx/InsertarProduct",
            data: data,
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (response) {
                //Hasta aca tenemos el SKU 
                if (response.d[0] == 0) {
                    for (let i = 0; i < arregloDetalleProducto.length; i++) {
                        ///aqui recorreremos el arreglo q  tiene nuestra tabla para guardar los datos
                        var json = JSON.stringify({
                            codProducto: response.d[1],
                            codPresentacion: arregloDetalleProducto[i].idpresentacion,
                            cantUB: arregloDetalleProducto[i].idcontubase
                        });

                        LlenarDetallesProducto(json);
                    }
                    Mpmensaje.html("Se registro correctamente");
                    Mpmensaje.css("color", "#ffffff");
                    Mmensaje.css("background-color", "#337ab7")
                        .css("border-color", "#2e6da4");
                    Mmensaje.css("display", "block");

                } else {
                    Mpmensaje.css("color", "rgba(179, 10, 10, 0.69)");
                    Mmensaje.css("background-color", "rgba(255, 0, 0, 0.51)")
                        .css("border-color", "rgb(203, 46, 46)");
                    Mpmensaje.html("Error al registrar " + codProduct);
                    Mmensaje.css("display", "block");
                }

            }
        });
    }

    function GuardarDatosModal() {
        //DESCRIPCION : Esta funcion me dispara un evento click,
        // para hacer el guardado de datos, Llamando a la funcion InsertarProduct                
        $("#btnGuardar").click(function () {

            //obtención valores del modal
            var descripcion = descProducto.val();
            var optionSelectUnidBase = PresentacionProduc.find("option:selected");
            var valueSelectUniBase = optionSelectUnidBase.val();
            var optionSeleccionCat = categoriaX.find("option:selected");
            var valueSelectCat = optionSeleccionCat.val();
            var optionSeleccionsubCat = subcategoriaX.find("option:selected");
            var valueSelectsubCat = optionSeleccionsubCat.val();
            var optionSelectProveedor = proveedormodal.find("option:selected");
            var valueSelectProveedor = optionSelectProveedor.val();
            var optionselectTipProduc = tipoProducto.find("option:selected");
            var valueSelectTipProduct = optionselectTipProduc.val();
            var optionSelectFabricante = fabricanteX.find("option:selected");
            var valueSelectFabricant = optionSelectFabricante.val();
            var optionSelectFlag = flagVenta.find("option:selected");
            var valueSelectFlag = optionSelectFlag.val();
            var descr;

            if (descripcion.length == 0) {
                swal("Debe agregar descripción de producto", {
                    icon: "info"
                });
                descProducto.focus();
            }
            else {
                if (valueSelectUniBase == 0) {
                    swal("Debe seleccionar la unidad Base", {
                        icon: "info"
                    });
                    PresentacionProduc.focus();
                }
                else {
                    if (valueSelectCat == 0) {
                        swal("Debe seleccionar categoria", {
                            icon: "info"
                        });
                        categoriaX.focus();
                    }
                    else {
                        if (valueSelectsubCat == 0) {
                            swal("Debe seleccionar subcategoria", {
                                icon: "info"
                            });
                            subcategoriaX.focus();
                        }
                        else {
                            if (valueSelectTipProduct == 0) {
                                swal("Debe seleccionar tipo Producto", {
                                    icon: "info"
                                });
                                tipoProducto.focus();
                            }
                            else {
                                if (valueSelectFlag < 0) {
                                    swal("Debe seleccionar Flag Producto", {
                                        icon: "info"
                                    });
                                    flagVenta.focus();
                                }
                                else {
                                    if (valueSelectFabricant == 0) {
                                        swal("Debe seleccionar Fabricante", {
                                            icon: "info"
                                        });
                                        fabricanteX.focus();
                                    }
                                    else {
                                        if (valueSelectProveedor == 0) {
                                            swal("Debe seleccionar Proveedor", {
                                                icon: "info"
                                            });
                                            fabricanteX.focus();

                                        }
                                        else {
                                            if (valueSelectTipProduct == 2) {
                                                var nombrePromocion = "PROMOCION";
                                                descr = (nombrePromocion + " " + descripcion).toUpperCase();

                                                var json = JSON.stringify({
                                                    descripcion: descr,
                                                    codUnidadBase: valueSelectUniBase,
                                                    codCategoria: valueSelectCat,
                                                    codsubcat: valueSelectsubCat,
                                                    tipoProduct: valueSelectTipProduct,
                                                    flag: valueSelectFlag,
                                                    codFabricant: valueSelectFabricant,
                                                    codProveedor: valueSelectProveedor

                                                });

                                                InsertarProducto(json);
                                                limpiarDatos();
                                                limpiardetalle();                                               
                                            } else {
                                                descr = descripcion.toUpperCase();
                                                var json = JSON.stringify({
                                                    descripcion: descr,
                                                    codUnidadBase: valueSelectUniBase,
                                                    codCategoria: valueSelectCat,
                                                    codsubcat: valueSelectsubCat,
                                                    tipoProduct: valueSelectTipProduct,
                                                    flag: valueSelectFlag,
                                                    codFabricant: valueSelectFabricant,
                                                    codProveedor: valueSelectProveedor

                                                });
                                                InsertarProducto(json);
                                                limpiarDatos();
                                                limpiardetalle();                                               
                                            }

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
        descProducto.val("");
        flagVenta.val("");
        //limpiar los selected ( con el seleccionar)
        var optionSelectUnidBase = PresentacionProduc.find("option:selected");
        var optionSeleccionCat = categoriaX.find("option:selected");
        var optionSeleccionsubCat = subcategoriaX.find("option:selected");
        var optionSelectProveedor = proveedormodal.find("option:selected");
        var optionselectTipProduc = tipoProducto.find("option:selected");
        var optionSelectFabricante = fabricanteX.find("option:selected");

        // optionSelectUnidBase.val(0);       
        categoriaX.val(0);
        subcategoriaX.val(0);
        proveedormodal.val(0);
        tipoProducto.val(0);
        fabricanteX.val(0);
        PresentacionProduc.val(0);

        descProducto.focus();
    }
   

    $("#idDateTablePresentacion").DataTable({
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

                "targets": [0],
                "visible": false,
                "searchable": false
            },
            {
                "width": "30%",
                "targets": [1, 2, 3]
            }

        ]
    })

    //creación de variables de que dataTable este creado en el DOM
    var tablaDet = $("#idDateTablePresentacion").dataTable(); //funcion jquery
    var tableDet = $("#idDateTablePresentacion").DataTable(); //funcion DataTable-libreria
    tableDet.columns.adjust().draw();

    function llenarTablaDet() {
        //DESCRIPCIÓN: LLENADO DE TABLA DE PRESENTACION DE UNIDAD DEL PRODUCTO
        $("#btnAgregar").click(function () {
            //DESCRIPCION: Lleno los inputs del Modal desde el tr seleccionado.

            var optionSelectedPresentacion = $("#presentacion").find("option:selected");
            var valueSelectedPresentacion = optionSelectedPresentacion.val();

            //for (let i = 0; i < arregloDetalleProducto.length; i++) {

                tablaDet.fnAddData([

                    $("#presentacion").val(),
                    $("#presentacion")[0].options[valueSelectedPresentacion].text,
                    $("#Mcant").val(),
                    '<button onclick="eliminarDetalle  class="btn icon-bin btn-danger"></button>'

                ]);

            //}


            const objDetalleProducto = new Object();
            objDetalleProducto.idpresentacion = $("#presentacion").val();
            objDetalleProducto.idcontubase = $("#Mcant").val();
            objDetalleProducto.nom = $('#presentacion option:selected').text();
            arregloDetalleProducto.push(objDetalleProducto);

            console.log('Producto llenarTablaDet:imprimiendo arreglo de objetos');
            console.log(arregloDetalleProducto);

            listarDatosDetalle();
            limpiardetalle();
        });
       
    }

    llenarTablaDet();

    function limpiardetalle() {
        var cantUB = $("#Mcant");
        cantUB.val("");
        var optionSelectUnidB = PresentacionProducX.find("option:selected");
        optionSelectUnidB.val(0);

        //if (optionSelectUnidB.value != 0) {
        //   optionSelectUnidB.remove();
        //}

        optionSelectUnidB.focus();      
    }

    function limpiardetalleE() {
        var cantUB = $("#McantE");
        cantUB.val("");
        var optionSelectUnidB = presentacionE.find("option:selected");
        optionSelectUnidB.val(0);

        //if (optionSelectUnidB.value != 0) {
        //    optionSelectUnidB.remove();
        //}

        optionSelectUnidB.focus();
    }

    function ListarPresentacionDetalleProduct(codProducto) {
        //DESCRIPCIÓN: Función de listar las presentación de producto  de la tblDetallePresentacion
        var json = JSON.stringify({ codProductos: codProducto });
        $.ajax({
            type: "POST",
            url: "frmMantProducto.aspx/ListaDetallePresentacionProduct",
            data: json,
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                ObtenerListaDetallePresentProduct(data.d);
            }
        });
    }

    function ObtenerListaDetallePresentProduct(data) {
        //DESCRIPCIÓN: lista el detalle del producto  de lA BD
        var btnEliminarE = ' <button type="button" title="Eliminar" class="btn icon-bin btn-danger" data-toggle="modal" data-target="#modalAnular"></button>';

        console.log(data);
        tablePresentEdit.clear().draw();
      
        for (var i = 0; i < data.length; i++) {
            //aqui recorre la tabla para el llenado 

            tablaPresentEdit.fnAddData([
                data[i].codProductos,
                data[i].codDetPresents,
                data[i].nom,
                data[i].cantUniBases,
                btnEliminarE
            ]);
        }
        $(".btn-danger").click(function () {
            //Obtengo los valores del producto seleccionado del detalle, cambia marca baja a 9
            var tr = $(this).parent().parent();
            console.log(tr);
            var codProduct = tablePresentEdit.row(tr).data()[0];
            var codPesent = tablePresentEdit.row(tr).data()[1];

            console.log(codProduct);
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
                        EliminarPresentacionActualizar(codProduct, codPesent);
                        swal("Se elimino Registro", {
                            icon: "success",
                        });
                        ListarPresentacionDetalleProduct(codProduct);
                    } else {
                        swal("Se Cancelo la eliminación");

                    }
                });
        });
    }


    //TABLA DEL MODAL ACTUALIZAR
    const arregloDetalleProductoEdit = [];

    function llenarTablaDetEditar() {
        //DESCRIPCIÓN: LLENADO DE TABLA DE PRESENTACION DE UNIDAD DEL PRODUCTO

     //   var codProduct = tablePresentEdit.row(tr).data()[0];

        $("#btnAgregarE").click(function () {
            //DESCRIPCION: Lleno los inputs del Modal desde el tr seleccionado.

            var btnEliminarE = ' <button type="button" title="Eliminar" class="btn icon-bin btn-danger" data-toggle="modal" data-target="#modalAnular"></button>';

            var boton = btnEliminarE

            var optionSelectedPresentacion = $("#presentacionE").find("option:selected");
            var valueSelectedPresentacion = optionSelectedPresentacion.val();


            tablaPresentEdit.fnAddData([

                $("#MskuE").val(),
                $("#presentacionE").val(),
                $("#presentacionE")[0].options[valueSelectedPresentacion].text,
                $("#McantE").val(),
                boton

            ]);



            const objDetalleProducto = new Object();

            objDetalleProducto.codProductos = $("#MskuE").val();
            objDetalleProducto.codDetPresents = $("#presentacionE").val();
            objDetalleProducto.idcontubase = $("#McantE").val();

            arregloDetalleProducto.push(objDetalleProducto);

            console.log('Producto llenarTablaDet:imprimiendo arreglo de objetos');
            console.log(arregloDetalleProducto);    //Array con todo los datos de la tabla en el d[0]

            limpiardetalleE();
        });

    }
    llenarTablaDetEditar();
});

const arregloDetalleProducto = [];

function listarDatosDetalle() {
    //DESCRIPCIÓN: lista el detalle del producto (PARA AGREGAR NUEVO DETALLE)
    var tablaDet = $("#idDateTablePresentacion").dataTable(); //funcion jquery
    var tableDet = $("#idDateTablePresentacion").DataTable(); //funcion DataTable-libreria

    tableDet.clear().draw();

    for (let i = 0; i < arregloDetalleProducto.length; i++) {
        //aqui recorre la tabla para el llenado 
        tablaDet.fnAddData([
            arregloDetalleProducto[i].idpresentacion,
            arregloDetalleProducto[i].nom,
            arregloDetalleProducto[i].idcontubase,
            '<button onclick="eliminarDetalle(' + i + ')" class="btn icon-bin btn-danger"></button>'
        ]);
    }
}

function eliminarDetalle(index) {
    //DESCRIPCIÓN: función para eliminar una presentación del producto (tabla temporal)
    swal({
        title: "Se eliminara el presentación de producto",
        text: "¿Esta seguro que desea eliminar el registro?",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
        .then((willDelete) => {
            if (willDelete) {
                arregloDetalleProducto.splice(index, 1);
                listarDatosDetalle();
                // console.log("esto es el arreglo despues de elimanarlo: " + arregloDetalleProducto.length);
                swal("Se elimino el presentación", {
                    icon: "success",
                });

            } else {
                swal("Se Cancelo la eliminacion", {
                    icon: "info"
                });
            }

        });
}
