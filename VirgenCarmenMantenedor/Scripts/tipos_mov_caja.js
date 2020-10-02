$(document).ready(function () {
    var btnEditar = '<button type="button" title="Editar" class="icon-pencil btnEditar" data-toggle="modal"  data-target="#modalAccion" ></button>'
    var btnDesactivar = ' <button type="button" id="" class="icon-blocked btnBlocked" data-toggle="tooltip"  title="Desactivar" ></button>'
    var btnActivar = ' <button type="button" id="" class="icon-checkmark btnCheck" data-toggle="tooltip"  title="Activar" ></button>'
    var tregistro = $("#tregistro");
    var pDescripcion = $("#pDescripcion");
    var pCodTipoMovimiento = $("#pCodTipoMovimiento")
    var btnRegistrar = $("#btnRegistrar");
    var btnGuardar = $("#btnGuardar");
    var buttonModal = $("#buttonModal");
    var Mpmensaje = $('#Mpmensaje');
    var Mmensaje = $('#Mmensaje');
    var lblTitle = $("#lblTitle");

    $("#divCodTMovimiento").css('display', 'none');

    $('#tb_tipo_movimiento_caja').DataTable({
        ordering: false,
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
        lengthMenu: [[10, 25, 50, -1], [10, 25, 50, "Todos"]],

        //Para que el DataTable no me muestre ciertas Columnas.
        columnDefs: [
            {
                "width": "50%",
                targets: [1],

            },
            {
                "width": "25%",
                targets: [3]
            },
            {
                "width": "25%",
                targets: [4]
            },
            {
                targets: [0, 2],
                "visible": false,
                "searchable": false
            }

        ]

    });

    //creo variables despues de que el DataTable este creado en el DOM.
    var tabla = $("#tb_tipo_movimiento_caja").dataTable(); //funcion jquery
    var table = $("#tb_tipo_movimiento_caja").DataTable(); //funcion DataTable-libreria

    /////LENADO DE TABLA POR DEFECTO //// 
    function addRowDT(data) {

        //DESCRIPCION : Funcion que me crea el listado de rutas en el body del DataTable


        for (var i = 0; i < data.length; i++) {

            var aux;
            if (data[i].marcaBaja == 0) {
                aux = btnEditar + btnDesactivar
            } else {
                aux = btnEditar + btnActivar
            }

            tabla.fnAddData([
                data[i].ntraTipoMovimiento,
                data[i].descripcion,
                data[i].codTipoRegistro,
                data[i].tipoRegistro,
                aux

            ]);
        }
        $("body").on('click', '.btnEditar', function () {
            lblTitle.text("Actualizar Tipo de Movimiento");
            btnGuardar.css("display", "block");
            btnRegistrar.css("display", "none");
            Mmensaje.css('display', 'none');

            var tr = $(this).parent().parent();

            pCodTipoMovimiento.val(table.row(tr).data()[0]);
            pDescripcion.val(table.row(tr).data()[1]);
            tregistro.val(table.row(tr).data()[2]);
        })

        $("body").on('click', '.btnBlocked', function () {
            //Obtengo los valores de mi tr seleccionado.
            var tr = $(this).parent().parent();
            var codTipoMovimiento = table.row(tr).data()[0];

                swal({
                    title: "Se desactivará el registro",
                    text: "¿Esta seguro que desea desactivar el registro?",
                    icon: "warning",
                    buttons: true,
                    dangerMode: true,
                })
                    //Promesa que me trae el valor true al confirmar OK.
                    .then((willDelete) => {
                        if (willDelete) {
                            DesactivarTipoMov(codTipoMovimiento)
                            swal("Se desactivó el Registro", {
                                icon: "success",
                            });

                        } else {
                            swal("Se canceló la desactivación");
                        }
                    });
        });

        $("body").on('click', '.btnCheck', function () {
            //Obtengo los valores de mi tr seleccionado.
            var tr = $(this).parent().parent();
            var codTipoMovimiento = table.row(tr).data()[0];

            swal({
                title: "Se activará el registro",
                text: "¿Esta seguro que desea activar el registro?",
                icon: "success",
                buttons: true,
                dangerMode: false,
            })
                //Promesa que me trae el valor true al confirmar OK.
                .then((result) => {
                    if (result) {
                        ActivarTipoMov(codTipoMovimiento)
                        swal("Se activó el Registro", {
                            icon: "success",
                        });

                    } else {
                        swal("Se canceló la activación");
                    }
                });
        });

    }

        

        ListarTiposMovimientosCaja()

        function ListarTiposMovimientosCaja() {
            //DESCRICION : Funcion que obtiene la lista de movimientos de caja 

            $.ajax({
                type: "POST",
                url: "frmTIposMovimientosCaja.aspx/ListarTiposMovimientosCaja",
                data: "{'flag': '1' }",
                contentType: 'application/json; charset=utf-8',
                error: function (xhr, ajaxOtions, thrownError) {
                    console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
                },
                success: function (data) {
                    // console.log(data.d);
                    table.clear().draw();
                    addRowDT(data.d);
                }
            })
        }

        /////////////////////////////////////////////////////////////////////

        /////////FILTROS////

        function addSelectTiposRegistro(data) {
            //DESCRIPCION : Funcion para llenar la lista de opciones del select de tipos de proceso.
            for (var i = 0; i < data.length; i++) {
                tregistro.append("<option value=" + data[i]["correlativo"] + ">" + data[i]["descripcion"] + "</option>");
            }
        }

        function ListarTiposRegistro() {
            //DESCRIPCION : Funcion que trae la lista de registro
            $.ajax({
                type: "POST",
                url: "frmTIposMovimientosCaja.aspx/ListarTiposRegistro",
                data: "{'flag': '37' }",
                contentType: 'application/json; charset=utf-8',
                error: function (xhr, ajaxOtions, thrownError) {
                    console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
                },
                success: function (data) {

                    addSelectTiposRegistro(data.d);
                }
            })

        }
    ListarTiposRegistro();

    function limpiarCampos() {
        pDescripcion.val("");
        tregistro.prop('selectedIndex', 0);
    }

    buttonModal.click(function () {
        lblTitle.text("Registrar Tipo de Movimiento");
            btnGuardar.css("display", "none");
            btnRegistrar.css("display", "block");
            Mmensaje.css('display', 'none');
        limpiarCampos();
        });

        btnRegistrar.click(function () {
            var tregistroSelect = tregistro.find("option:selected");
            tregistroValue = tregistroSelect.val();
            var descripcionValue = pDescripcion.val();

            if (tregistroValue > 0) {
                if (descripcionValue.length > 0) {
                    RegistrarTipoMovimientoCaja(tregistroValue, descripcionValue)
                } else {
                    pDescripcion.attr("required", "required");
                }
            } else {
                 tregistro.attr("required", "required");
            }
            
        });

        btnGuardar.click(function () {
            var tregistroSelect = tregistro.find("option:selected");
            tregistroValue = tregistroSelect.val();
            var descripcionValue = pDescripcion.val();
            var codTipoMovValue = pCodTipoMovimiento.val();

            if (tregistroValue > 0) {
                if (descripcionValue.length > 0) {
                    ActualizarTipoMovimientoCaja(codTipoMovValue, tregistroValue, descripcionValue)
                } else {
                    pDescripcion.attr("required", "required");
                }
            } else {
                tregistro.attr("required", "required");
            }

        });

    function RegistrarTipoMovimientoCaja(tipoRegistro, descripcion) {

        var json = JSON.stringify({
            tipoMov: {
                codTipoRegistro: tipoRegistro,
                descripcion: descripcion
            }
        });

        $.ajax({
            type: "POST",
            url: "frmTIposMovimientosCaja.aspx/RegistrarTipoMovimientoCaja",
            data: json,
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (response) {

                if (response.d === 0) {

                    Mpmensaje.html("El registro se realizó correctamente");
                    Mpmensaje.css("color", "#ffffff");
                    Mmensaje.css("background-color", "#337ab7")
                        .css("border-color", "#2e6da4");
                    Mmensaje.css("display", "block");

                    table.clear().draw();
                    ListarTiposMovimientosCaja()

                    limpiarCampos()

                } else {

                    Mpmensaje.css("color", "rgba(179, 10, 10, 0.69)");
                    Mmensaje.css("background-color", "rgba(255, 0, 0, 0.51)")
                        .css("border-color", "rgb(203, 46, 46)");
                    Mpmensaje.html("No se pudo registrar el tipo de movimiento");
                    Mmensaje.css("display", "block");

                    limpiarCampos()

                }

            }
        });
    }

    function ActualizarTipoMovimientoCaja(codTipoMov, tipoRegistro, descripcion) {

        var json = JSON.stringify({
            tipoMov: {
                ntraTipoMovimiento: codTipoMov,
                codTipoRegistro: tipoRegistro,
                descripcion: descripcion
            }
        });

        $.ajax({
            type: "POST",
            url: "frmTIposMovimientosCaja.aspx/ActualizarTipoMovimientoCaja",
            data: json,
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (response) {

                if (response.d === 0) {

                    Mpmensaje.html("El registro se actualizó correctamente");
                    Mpmensaje.css("color", "#ffffff");
                    Mmensaje.css("background-color", "#337ab7")
                        .css("border-color", "#2e6da4");
                    Mmensaje.css("display", "block");

                    table.clear().draw();
                    ListarTiposMovimientosCaja()

                } else {

                    Mpmensaje.css("color", "rgba(179, 10, 10, 0.69)");
                    Mmensaje.css("background-color", "rgba(255, 0, 0, 0.51)")
                        .css("border-color", "rgb(203, 46, 46)");
                    Mpmensaje.html("No se pudo actualizar el registro");
                    Mmensaje.css("display", "block");

                }

            }
        });
    }

    //Desactivar Registro
    function DesactivarTipoMov(codTipoMov) {

        var json = JSON.stringify({ tipoMov: { ntraTipoMovimiento: codTipoMov }, flag: 9 });
        $.ajax({
            type: "POST",
            url: "frmTIposMovimientosCaja.aspx/AltaBajaTipoMov",
            data: json,
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
            },
            success: function () {
                table.clear().draw();
                ListarTiposMovimientosCaja()
            }
        })
    }

    //Activar Registro
    function ActivarTipoMov(codTipoMov) {

        var json = JSON.stringify({ tipoMov: { ntraTipoMovimiento: codTipoMov }, flag: 0 });
        $.ajax({
            type: "POST",
            url: "frmTIposMovimientosCaja.aspx/AltaBajaTipoMov",
            data: json,
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
            },
            success: function () {
                table.clear().draw();
                ListarTiposMovimientosCaja()
            }
        })
    }
});