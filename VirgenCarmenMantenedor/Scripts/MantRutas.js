
$(document).ready(function () {
    //Lista de Variables
    var btnGuardar = $("#btnGuardarM");
    var Mmensaje = $("#Mmensaje");
    var Mpmensaje = $("#Mpmensaje");
    var Mmensaje2 = $("#Mmensaje2");
    var Mpmensaje2 = $("#Mpmensaje2");
    var btnActualizar = $("#btnModifica");
    var btnEditar = '<button type="button" title="Editar" class="icon-pencil btnEditar" data-toggle="modal"  data-target="#exampleModal2" ></button>'
    var btnEliminar = ' <button type="button" id="" class="icon-bin btnDelete" data-toggle="tooltip"  title="Eliminar" ></button>'
    var btnCancelar = $("#btnCancelar");

    //var tableBody = $("#tbl_body_table");
    var buttonModal = $("#buttonModal");
    //var McodOrden = $("#McodOrden");
    //var MRutaAnterior = $("#MRutaAnterior");
    //var MmensajeOrden = $('#MmensajeOrden');

    //var sucursales = $(".sucursales");
    var ruta = $("#Ruta");
    var abreviatura = $("#Abreviatura");

    var rutaM = $("#Mruta");
    var abreviaturaM = $("#Mabreviatura");
    var codigoM = $("#Mcodigo");

    
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
        dom: 'lBfrtip',
        buttons: [
            {
                extend: 'excelHtml5',
                text: '<span class="icon-file-excel"></span>',
                titleAttr: 'Excel',
                title: 'Reporte de Rutas',
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
                    $('row c[r*="20"]', sheet).attr('s', '25');
                    $('row c[r*="21"]', sheet).attr('s', '25');
                    $('row c[r*="22"]', sheet).attr('s', '25');
                    $('row c[r*="23"]', sheet).attr('s', '25');
                    $('row c[r*="24"]', sheet).attr('s', '25');
                    $('row c[r*="25"]', sheet).attr('s', '25');
                    $('row c[r*="26"]', sheet).attr('s', '25');
                    $('row c[r*="27"]', sheet).attr('s', '25');
                    $('row c[r*="28"]', sheet).attr('s', '25');
                    $('row c[r*="29"]', sheet).attr('s', '25');
                    $('row c[r*="32"]', sheet).attr('s', '25');

                },
                //Para que excel solo me exporte ciertas columnas
                exportOptions: {
                    columns: [0, 1, 2]
                }
            }],
        //Para que el DataTable no me muestre ciertas Columnas.
        columnDefs: [
            {
                "width": "1%",
                "targets": [0]
            },
            {
                "width": "54%",
                "targets": [1]
            },
            {
                "width": "35%",
                "targets": [2]
            },
            {
                "width": "5%",
                "targets": [3]
            }   
        ]
    });

    //creo variables despues de que el DataTable este creado en el DOM.
    var tabla = $("#tb_rutas").dataTable(); //funcion jquery
    var table = $("#tb_rutas").DataTable(); //funcion DataTable-libreria

    table.columns.adjust().draw();

    function addRowDT(data) {

        //DESCRIPCION : Funcion que me crea el listado de rutas en el body del DataTable
        for (var i = 0; i < data.length; i++) {
            tabla.fnAddData([
                data[i].ntraRutas,
                data[i].descripcion,
                data[i].pseudonimo,
                btnEditar + btnEliminar
            ]);

            if (data[i].estado == 1) {

                var trcolor = $("#tbl_body_table tr")[i];
                trcolor.setAttribute('class', 'colortr');
                var trasig = $(".colortr");
                trasig.css('background', '#77c0ff');
            }
        }
        //Evento clcick para Editar una ruta.
        //Lleno los inputs del Modal desde el tr seleccionado.


        $("body").on('click', '.btnEditar', function () {
            Mmensaje2.css("display", "none")
            var tr = $(this).parent().parent(); 

            codigoM.val(table.row(tr).data()[0]);
            rutaM.val(table.row(tr).data()[1]);
            abreviaturaM.val(table.row(tr).data()[2]);
        });


        //Evento clcick para Eliminar una ruta, Hago el llamado de
        //ElimiarRutas y envio el parametro segun la confirmacion del modal
        //Ejecuta libreria sweet alert

        $("body").on('click', '.btnDelete', function () {
            //Obtengo los valores de mi tr seleccionado.
            var tr = $(this).parent().parent();
            var codRuta = table.row(tr).data()[0];-

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
                        ElimiarRutas(codRuta)
                        swal("Se elimino Registro", {
                            icon: "success",
                        });

                    } else {
                        swal("Se Cancelo la eliminación");
                    }
                });
        });
    }

    function CargarDatos() {
        //DESCRIPCION: Cargar Datos a la Tabla
        $.ajax({
            type: "POST",
            url: "frmMantRutas.aspx/CargarTabla",
            data: "{'flag': '3' }",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                //console.log(data.d);
                table.clear().draw();
                addRowDT(data.d);
            }
        })
    }

    CargarDatos();

    //Eliminar Registro
    function ElimiarRutas(codRuta) {

        var json = JSON.stringify({ codRuta: codRuta });
        $.ajax({
            type: "POST",
            url: "frmMantRutas.aspx/EliminarRutas",
            data: json,
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
            },
            success: function () {
                CargarDatos();
            }
        })
    };


    function InsertarRutas(data) {
        //Descricion : Recibo los parametros del evento click del GuardadoDeDatosModal
        //los envio por Ajax 
        $.ajax({
            type: "POST",
            url: "frmMantRutas.aspx/InsertarRutas",
            data: data,
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (response) {

                if (response.d == 0) {
                    Mpmensaje.html("Se registro correctamente");
                    Mpmensaje.css("color", "#ffffff");
                    Mmensaje.css("background-color", "#337ab7")
                        .css("border-color", "#2e6da4");
                    Mmensaje.css("display", "block");

                    // Actualizo la tabla para mostrar la nueva ruta asignada

                    CargarDatos();   
                    ruta.val('') ;
                    abreviatura.val('');

                    //McodOrden.val(""); // Limpio el valor codOrden
                    var dataJson = jQuery.parseJSON(data);
                    //var codOrden = parseInt(dataJson.codOrden, Number) + 1;
                    //////////////////////////////////////////////////////////7
                } else {

                    Mpmensaje.css("color", "rgba(179, 10, 10, 0.69)");
                    Mmensaje.css("background-color", "rgba(255, 0, 0, 0.51)")
                        .css("border-color", "rgb(203, 46, 46)");
                    Mpmensaje.html("No se pudo reristrar la ruta");
                    Mmensaje.css("display", "block");

                }

            }
        });
    }

    function GurdarDatosModal() {
        //DESCRIPCION : Esta funcion me dispara un evento click,
        // para hacer el guardado de datos, Llamando a la funcion InsertarRutasAsignadas
        btnGuardar.click(function () {

            ruta.val();
            abreviatura.val();
            var json = JSON.stringify({ descripcion: ruta.val(), pseudonimo: abreviatura.val(), codSucursal:1 }); //TENER CUIDADO CON EL VALOR DEL COD DE SUCURSAL PORQUE ESTÁ EN DURO
            if (ruta.val() != "" && abreviatura.val() != "") {

                    //Envio los valores del modal en un json
                InsertarRutas(json, ruta.val());

            } else {
                selectRutas.attr("required", "required");
            }
        });
    }
    GurdarDatosModal();


    function ActualizarRutas(data) {
        //Descricion : Recibo los parametros del evento click del ActualizarRutaDelVendedor
        //los envio por Ajax 
        $.ajax({
            type: "POST",
            url: "frmMantRutas.aspx/ActualizarRutas",
            data: data,
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (response) {

                if (response.d == 0) {
                    
                    rutaM.val();
                    abreviaturaM.val();
                    codigoM.val();
                    
                    Mpmensaje2.html("Se Actualizo correctamente");

                    Mpmensaje2.css("color", "#ffffff");
                    Mmensaje2.css("background-color", "#337ab7")
                            .css("border-color", "#2e6da4");
                    Mmensaje2.css("display", "block") 

                    CargarDatos();

                    //////////////////////////////////////////////////////////7

                } else {
                    Mpmensaje.css("color", "rgba(179, 10, 10, 0.69)");
                    Mmensaje.css("background-color", "rgba(255, 0, 0, 0.51)")
                        .css("border-color", "rgb(203, 46, 46)");
                    Mpmensaje.html("No se pudo actualizar ");
                    Mmensaje.css("display", "block");
                }
            }
        });
    }

    function ActualizarRutaDeBase() {
        //DESCRIPCION : Funcion que me ejecuta el evento click del boton Editar.
        //evento ejecuta la actualizacion de ruta al llamar a ActualizarRutasAsignadas
        btnActualizar.click(function () {

            codigoM.val();
            rutaM.val();
            abreviaturaM.val();

            var json = JSON.stringify({ descripcion: rutaM.val(), pseudonimo: abreviaturaM.val(), ntraRutas: codigoM.val() });
            if (rutaM.val() != "" && abreviaturaM.val() != "") {

                    console.log(json);
                    //Envio los valores del modal en un json y el codVendedor.
                    ActualizarRutas(json);

            } else {
                selectRutas.attr("required", "required");
            }

        });
    }
    //EXEC FUC
    ActualizarRutaDeBase();

    buttonModal.click(function () {
        Mmensaje.css('display', 'none');

    })  



});

