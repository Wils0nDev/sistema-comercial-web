$(document).ready(function () {
    var btnVer = '<button type="button" title="Ver" class="icon-eye btnEye" data-toggle="modal"  data-target="#modalAccion" ></button>'
    var btnEditar = '<button type="button" title="Editar" class="icon-pencil btnEditar" data-toggle="modal"  data-target="#modalAccion" ></button>'
    var btnEditarApertura = '<button type="button" title="Editar Apertura" class="icon-pencil btnEdAp" data-toggle="modal"  data-target="#modalAccion" ></button>'
    var btnIniciarProcesoApertura = '<button type="button" title="Iniciar Proceso" class="icon-cloud-download btnCloudD" data-toggle="tooltip" ></button>'
    var lblProcesado = '<label  class="label label-default">Procesado</label>'
    var chkTipoMov = '<input type="checkbox" name="chkTipoMov" title="Seleccionar" class="chkTipoMov" />'
    var selectEstadoCaja = $("#selectEstadoCaja");
    var selectCaja = $("#selectCaja");
    var selectEncargado = $("#selectEncargado");
    var minDate = $("#min-date");
    var maxDate = $("#max-date");
    var btnBuscar = $("#btnBuscar");
    var btnCrearCaja = $("#btnCrearCaja");
    var btnAperturarCaja = $("#btnAperturarCaja");
    var MmensajeOrdenFecha = $('#MmensajeOrdenFecha');

    // CAMPOS MODAL
    var lblTitle = $("#lblTitle");
    var Mpmensaje = $('#Mpmensaje');
    var Mmensaje = $('#Mmensaje');
    var divRegEditCaja = $("#divRegEditCaja");
    var txtNtraCaja = $("#txtNtraCaja");
    var txtDesc = $("#txtDesc");
    var selectEncargado_Modal = $("#selectEncargado_Modal");
    var divAperturaCaja = $("#divAperturaCaja");
    var divCajaAp = $("#divCajaAp");
    var txtNtraAperturaCaja = $("#txtNtraAperturaCaja");
    var selectCajaMA = $("#selectCajaMA");
    var txtImpSoles = $("#txtImpSoles");
    var txtImpDolares = $("#txtImpDolares");
    var divVerCaja = $("#divVerCaja");
    var txtDescCaja = $("#txtDescCaja");
    var txtEncCaja = $("#txtEncCaja");
    var divDetApCaja = $("#divDetApCaja");
    var txtFecApCaja = $("#txtFecApCaja");
    var txtSaldoSCaja = $("#txtSaldoSCaja");
    var txtSaldoDCaja = $("#txtSaldoDCaja");
    var btnGuardar = $("#btnGuardar");
    var btnGuardarA = $("#btnGuardarA");
    var btnRegistrar = $("#btnRegistrar");
    var btnAperturar = $("#btnAperturar");

    var valorFIltroFecha = true; 

    minDate.datepicker(
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
            showOn: "button",
            buttonImage: "Imagenes/calendar.gif",
            buttonImageOnly: true,
            buttonText: "Select date",
            language: "es"

        }
    );

    maxDate.datepicker(
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
            showOn: "button",
            buttonImage: "Imagenes/calendar.gif",
            buttonImageOnly: true,
            buttonText: "Select date",
            language: "es"

        }
    );

    $('#tb_caja').DataTable({
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
                "width": "15%",
                targets: [1,2,3,5,7,9]
            },
            {
                "width": "10%",
                targets: [8]
            },
            {
                targets: [0, 4,6],
                "visible": false,
                "searchable": false
            }

        ]

    });

    //tabla de tipos de movimientos de caja en registrar/editar
    var idTiposMovCaja = $("#id_table_tipos_mov_caja");
    idTiposMovCaja.DataTable({
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

        //Para que el DataTable no me muestre ciertas Columnas.
        columnDefs: [
            {
                targets: [0],
                "visible": false,
                "searchable": false
            }

        ]

    });

    //creo variables despues de que el DataTable este creado en el DOM.
    var tabla = $("#tb_caja").dataTable(); //funcion jquery
    var table = $("#tb_caja").DataTable(); //funcion DataTable-libreria
    //creo variables despues de que el DataTable este creado en el DOM.
    var tablaTiposMov = $("#id_table_tipos_mov_caja").dataTable(); //funcion jquery
    var tableTiposMov = $("#id_table_tipos_mov_caja").DataTable(); //funcion DataTable-libreria
    //////////////////////////////////////////////////////////////////

    /////LENADO DE TABLA POR DEFECTO ////
    function addRowDT(data) {

        //DESCRIPCION : Funcion que me crea el listado de rutas en el body del DataTable


        for (var i = 0; i < data.length; i++) {

            var btns;
            if (data[i].codEstado == 2) {
                btns = btnVer + btnEditar
            } else {
                btns = btnVer
            }


            tabla.fnAddData([
                data[i].ntraCaja,
                data[i].fechaCreacion + ' ' + data[i].horaCreacion,
                data[i].descripcion,
                data[i].sucursal,
                data[i].codEstado,
                data[i].estado,
                data[i].ntraUsuario,
                data[i].nombreCompleto,
                data[i].users,
                btns

            ]);
        }
        $("body").on('click', '.btnEditar', function () {
            lblTitle.text("Actualizar Caja");
            divRegEditCaja.css("display", "block");
            divAperturaCaja.css("display", "none");
            divVerCaja.css("display", "none");
            btnGuardar.css("display", "block");
            btnRegistrar.css("display", "none");
            btnAperturar.css("display", "none");
            btnGuardarA.css("display", "none");
            Mmensaje.css('display', 'none');

            $("input[name=chkTipoMov]").each(function (index) {
                    $(this).prop('checked', false);
            });

            var tr = $(this).parent().parent();

            txtNtraCaja.val(table.row(tr).data()[0]);
            txtDesc.val(table.row(tr).data()[2]);
            selectEncargado_Modal.val(table.row(tr).data()[6]);

            listarDetalleMovsCaja()
        });

        $("body").on('click', '.btnEye', function () {
            lblTitle.text("Ver Detalle Caja");
            divRegEditCaja.css("display", "none");
            divAperturaCaja.css("display", "none");
            divVerCaja.css("display", "block");
            btnGuardar.css("display", "none");
            btnRegistrar.css("display", "none");
            btnAperturar.css("display", "none");
            btnGuardarA.css("display", "none");
            Mmensaje.css('display', 'none');

            var tr = $(this).parent().parent();

            if (table.row(tr).data()[4] == 1) {
                divDetApCaja.css("display", "block");
            } else {
                divDetApCaja.css("display", "none");
            }

            txtDescCaja.val(table.row(tr).data()[2]);
            txtEncCaja.val(table.row(tr).data()[7]);

            ListarDetalle_ApCaja(table.row(tr).data()[0], 1)
            ListarDetalle_CiCaja(table.row(tr).data()[0], 1)
            ListarDetalle_TrCaja(table.row(tr).data()[0], "", 1)
            listarDetalleLmCaja(table.row(tr).data()[0])
        });

        $.fn.dataTableExt.afnFiltering.push(

            function (settings, data, dataIndex) {
                var min = $('#min-date').val();
                var minr = min.split('/').join('-');
                var max = $('#max-date').val()
                var maxr = max.split('/').join('-');
                var createdAt = data[1] || 0;
                var createdAtr = createdAt.split('/').join('-');
                var createdAtf = moment(createdAtr, 'DD-MM-YYYY').format("YYYY-MM-DD");
                var minf = moment(minr, 'DD-MM-YYYY').format("YYYY-MM-DD");
                var maxf = moment(maxr, 'DD-MM-YYYY').format("YYYY-MM-DD");
                //createdAt=createdAt.split(" ");
                var startDate = moment(minf, "YYYY-MM-DD");
                var endDate = moment(maxf, "YYYY-MM-DD");
                var diffDate = moment(createdAtf, "YYYY-MM-DD");
                //console.log(startDate);
                if ((min != "" && max != "") && (endDate < startDate)) {
                    return true;

                } else {
                    if ((min == "" || max == "") || (diffDate.isBetween(startDate, endDate, null, '[]'))) {
                        return true;

                    }
                    return false;
                }


            });


        // Re-draw the table when the a date range filter changes
        $('.date-range-filter').change(function () {
            var min = $('#min-date').val();
            var minr = min.split('/').join('-');
            var max = $('#max-date').val()
            var maxr = max.split('/').join('-');
            var minf = moment(minr, 'DD-MM-YYYY').format("YYYY-MM-DD");
            var maxf = moment(maxr, 'DD-MM-YYYY').format("YYYY-MM-DD");
            //createdAt=createdAt.split(" ");
            var startDate = moment(minf, "YYYY-MM-DD");
            var endDate = moment(maxf, "YYYY-MM-DD");
            if ((min != "" && max != "") && (endDate < startDate)) {
                MmensajeOrdenFecha.css('opacity', '1')
                    .css('height', '40px');
                setTimeout(function () {
                    MmensajeOrdenFecha.css('opacity', '0');
                }, 3000);
                setTimeout(function () {
                    MmensajeOrdenFecha.css('height', '0px')
                }, 4000)
                valorFIltroFecha = false;
                return valorFIltroFecha;
            } else {

                valorFIltroFecha = true;
                return valorFIltroFecha;

            }

        });

    }

    function listarDetalleMovsCaja() {
        //DESCRICION : Funcion que obtiene la lista de movimientos de caja 
        var json = JSON.stringify({
            objCENCaja: {
                ntraCaja: txtNtraCaja.val()
            }
        });

        $.ajax({
            type: "POST",
            url: "frmMaestroCajas.aspx/ListarTipos_Mov_Asig_Caja",
            data: json,
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                // console.log(data.d);

                $.each(data.d.listaTipoMovimientos, function (index, objTM) {
                    $("input[name=chkTipoMov]").each(function (index1) {
                        if (objTM.ntraTipoMovimiento == tableTiposMov.row(index1).data()[0]) {
                            $(this).prop('checked', true);
                        }
                    });
                });

            }
        })
    }

    btnBuscar.click(function () {

        var optionSelectCaja = selectCaja.find("option:selected");
        var valueSelectedCaja = optionSelectCaja.val();

        var optionSelectEstado = selectEstadoCaja.find("option:selected");
        var valueSelectedEstado = optionSelectEstado.val();

        var optionSelectEncargado = selectEncargado.find("option:selected");
        var valueSelectedEncargado = optionSelectEncargado.val();

        var min = minDate.val();
        var max = maxDate.val();

        if (min == "") {
            startDate = "";
        } else {
            var minr = min.split('/').join('-');
            var minf = moment(minr, 'DD-MM-YYYY').format("YYYY-MM-DD");
            var startDate = moment(minf, "YYYY-MM-DD");
        }

        if (max == "") {
            endDate = "";
        } else {
            var maxr = max.split('/').join('-');
            var maxf = moment(maxr, 'DD-MM-YYYY').format("YYYY-MM-DD");
            var endDate = moment(maxf, "YYYY-MM-DD");
        }

        if (valueSelectedCaja == 0 && valueSelectedEstado == 0 && valueSelectedEncargado == 0 && min == "" && max == "" ) {
            ListarCajas(0, 0, 0, "", "")
        } else {
            if (valorFIltroFecha == true) {
                ListarCajas(valueSelectedCaja, valueSelectedEstado, valueSelectedEncargado, startDate, endDate)
            }

        }
    });

    ListarCajas(0,0,0,"","")

    function ListarCajas(ntraCaja, estadoCaja, ntraUsuario, fechaInicial, fechaFinal) {
            //DESCRICION : Funcion que obtiene la lista de movimientos de caja 

        var json = JSON.stringify({
            ntraCaja: ntraCaja,
                estadoCaja: estadoCaja,
                ntraUsuario: ntraUsuario,
                fechaInicial: fechaInicial,
                fechaFinal: fechaFinal
            });

            $.ajax({
                type: "POST",
                url: "frmMaestroCajas.aspx/ListarCajas",
                data: json,
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

    //Llenado de tabla lista de movimientos


    /////LENADO DE TABLA TIPOS MOVIMIENTOS POR DEFECTO ////
    function addRowDTTiposMov(data) {

        //DESCRIPCION : Funcion que me crea el listado de rutas en el body del DataTable


        for (var i = 0; i < data.length; i++) {

            tablaTiposMov.fnAddData([
                data[i].ntraTipoMovimiento,
                data[i].descripcion,
                data[i].tipoRegistro,
                chkTipoMov

            ]);
        }
        
    }

    ListarTiposMovimientosCaja()

    function ListarTiposMovimientosCaja() {
        //DESCRICION : Funcion que obtiene la lista de movimientos de caja 

        $.ajax({
            type: "POST",
            url: "frmTIposMovimientosCaja.aspx/ListarTiposMovimientosCaja",
            data: "{'flag': '0' }",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                // console.log(data.d);
                tableTiposMov.clear().draw();
                addRowDTTiposMov(data.d);
            }
        })
    }

        /////////////////////////////////////////////////////////////////////

        /////////FILTROS////

        function addSelectEstadosCaja(data) {
            //DESCRIPCION : Funcion para llenar la lista de opciones del select de estados de caja.
            for (var i = 0; i < data.length; i++) {
                selectEstadoCaja.append("<option value=" + data[i]["correlativo"] + ">" + data[i]["descripcion"] + "</option>");
            }
        }

        function ListarEstadosCaja() {
            //DESCRIPCION : Funcion que trae la lista de registro
            $.ajax({
                type: "POST",
                url: "frmMaestroCajas.aspx/ListarxFlag",
                data: "{'flag': '38' }",
                contentType: 'application/json; charset=utf-8',
                error: function (xhr, ajaxOtions, thrownError) {
                    console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
                },
                success: function (data) {
                    addSelectEstadosCaja(data.d);
                }
            })

        }
    ListarEstadosCaja();

    function addSelectEncargados(data) {
        //DESCRIPCION : Funcion para llenar la lista de opciones del select de encargados.
        for (var i = 0; i < data.length; i++) {
            selectEncargado.append("<option value=" + data[i]["ntraUsuario"] + ">" + data[i]["vendedor"] + "</option>");
            selectEncargado_Modal.append("<option value=" + data[i]["ntraUsuario"] + ">" + data[i]["vendedor"] + "</option>");
        }
    }

    function ListarEncargados() {
        //DESCRIPCION : Funcion que trae la lista de registro
        $.ajax({
            type: "POST",
            url: "frmMaestroCajas.aspx/ListarCajeros_Sucursal",
            data: {}, 
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {

                addSelectEncargados(data.d);
            }
        })

    }
    ListarEncargados();

    function addSelectCajas(data) {
        //DESCRIPCION : Funcion para llenar la lista de opciones del select de cajas.
        for (var i = 0; i < data.length; i++) {
            selectCaja.append("<option value=" + data[i]["ntraCaja"] + ">" + data[i]["descripcion"] + "</option>");
        }
    }

    function ListarCajasSelect(ntraCaja, estadoCaja, ntraUsuario, fechaInicial, fechaFinal) {
        //DESCRICION : Funcion que obtiene la lista de movimientos de caja 

        var json = JSON.stringify({
            ntraCaja: ntraCaja,
            estadoCaja: estadoCaja,
            ntraUsuario: ntraUsuario,
            fechaInicial: fechaInicial,
            fechaFinal: fechaFinal
        });

        $.ajax({
            type: "POST",
            url: "frmMaestroCajas.aspx/ListarCajas",
            data: json,
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                addSelectCajas(data.d);
            }
        })
    }

    ListarCajasSelect(0, 0, 0, "", "")

    function addSelectCajasCerradas(data) {
        //DESCRIPCION : Funcion para llenar la lista de opciones del select de cajas.
        for (var i = 0; i < data.length; i++) {
            selectCajaMA.append("<option value=" + data[i]["ntraCaja"] + ">" + data[i]["descripcion"] + "</option>");
        }
    }
    
    function ListarCajasCerradas(ntraCaja, estadoCaja, ntraUsuario, fechaInicial, fechaFinal) {
        //DESCRICION : Funcion que obtiene la lista de movimientos de caja 

        var json = JSON.stringify({
            ntraCaja: ntraCaja,
            estadoCaja: estadoCaja,
            ntraUsuario: ntraUsuario,
            fechaInicial: fechaInicial,
            fechaFinal: fechaFinal
        });

        $.ajax({
            type: "POST",
            url: "frmMaestroCajas.aspx/ListarCajas",
            data: json,
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                // console.log(data.d);
                $('option', selectCajaMA).remove();
                selectCajaMA.append('<option value="0">SELECCIONE UNA CAJA</option>');
                addSelectCajasCerradas(data.d);
            }
        })
    }

    ListarCajasCerradas(0, 2, 0, "", "")

    function limpiarCampos() {
        txtDesc.val("");
        selectEncargado_Modal.prop('selectedIndex', 0);
        selectCajaMA.prop('selectedIndex', 0);
        txtImpSoles.val("0.0");
        txtImpDolares.val("0.0");
    }

    btnCrearCaja.click(function () {
        lblTitle.text("Registrar Caja");
        divRegEditCaja.css("display", "block");
        divAperturaCaja.css("display", "none");
        divVerCaja.css("display", "none");
        btnGuardar.css("display", "none");
        btnRegistrar.css("display", "block");
        btnAperturar.css("display", "none");
        btnGuardarA.css("display", "none");
        Mmensaje.css('display', 'none');
        limpiarCampos();
        });

    btnRegistrar.click(function () {
        var encargadoSelect = selectEncargado_Modal.find("option:selected");
        encargadoValue = encargadoSelect.val();
        var descripcionValue = txtDesc.val();
        var listaTM = new Array();
        var cantH = 0;

        $("input[name=chkTipoMov]").each(function (index) {
            const CENTipoMovimiento = new Object();
            if ($(this).is(':checked')) {
                CENTipoMovimiento.ntraTipoMovimiento = tableTiposMov.row(index).data()[0];
                CENTipoMovimiento.marcaBaja = 0;
                cantH++;
            } else {
                CENTipoMovimiento.ntraTipoMovimiento = tableTiposMov.row(index).data()[0];
                CENTipoMovimiento.marcaBaja = 9;
            }
            listaTM.push(CENTipoMovimiento)
        });

        
        if (descripcionValue.length > 0) {
            if (encargadoValue > 0) {
                if (cantH > 0) {
                    RegistrarCaja(encargadoValue, descripcionValue, listaTM)
                } else {
                    Mpmensaje.css("color", "rgba(179, 10, 10, 0.69)");
                    Mmensaje.css("background-color", "rgba(255, 0, 0, 0.51)")
                        .css("border-color", "rgb(203, 46, 46)");
                    Mpmensaje.html("Debe seleccionar al menos un elemento de la lista");
                    Mmensaje.css("display", "block");
                    setTimeout(function () {
                        Mmensaje.css('display', 'none');
                    }, 2000);
                } 
            } else {
                selectEncargado_Modal.attr("required", "required");
                Mpmensaje.css("color", "rgba(179, 10, 10, 0.69)");
                Mmensaje.css("background-color", "rgba(255, 0, 0, 0.51)")
                    .css("border-color", "rgb(203, 46, 46)");
                Mpmensaje.html("Debe seleccionar un encargado");
                Mmensaje.css("display", "block");
                setTimeout(function () {
                    Mmensaje.css('display', 'none');
                }, 2000);
            }
             } else {
                    txtDesc.attr("required", "required");
             }
        
            
        });

        btnGuardar.click(function () {
            var encargadoSelect = selectEncargado_Modal.find("option:selected");
            encargadoValue = encargadoSelect.val();
            var descripcionValue = txtDesc.val();
            var ntraCajaValue = txtNtraCaja.val();

            var listaTM = new Array();
            var cantH = 0;

            $("input[name=chkTipoMov]").each(function (index) {
                const CENTipoMovimiento = new Object();
                if ($(this).is(':checked')) {
                    CENTipoMovimiento.ntraTipoMovimiento = tableTiposMov.row(index).data()[0];
                    CENTipoMovimiento.marcaBaja = 0;
                    cantH++;
                } else {
                    CENTipoMovimiento.ntraTipoMovimiento = tableTiposMov.row(index).data()[0];
                    CENTipoMovimiento.marcaBaja = 9;
                }
                listaTM.push(CENTipoMovimiento)
            });
            if (descripcionValue.length > 0) {
                if (encargadoValue > 0) {
                    if (cantH) {
                        ActualizarCaja(ntraCajaValue, encargadoValue, descripcionValue, listaTM)
                    } else {
                        Mpmensaje.css("color", "rgba(179, 10, 10, 0.69)");
                        Mmensaje.css("background-color", "rgba(255, 0, 0, 0.51)")
                            .css("border-color", "rgb(203, 46, 46)");
                        Mpmensaje.html("Debe seleccionar al menos un elemento de la lista");
                        Mmensaje.css("display", "block");
                        setTimeout(function () {
                            Mmensaje.css('display', 'none');
                        }, 2000);
                    }
                } else {
                    selectEncargado_Modal.attr("required", "required");
                    Mpmensaje.css("color", "rgba(179, 10, 10, 0.69)");
                    Mmensaje.css("background-color", "rgba(255, 0, 0, 0.51)")
                        .css("border-color", "rgb(203, 46, 46)");
                    Mpmensaje.html("Debe seleccionar un encargado");
                    Mmensaje.css("display", "block");
                    setTimeout(function () {
                        Mmensaje.css('display', 'none');
                    }, 2000);
                }
                } else {
                    txtDesc.attr("required", "required");
                }
            

        });

    function RegistrarCaja(encargadoValue, descripcionValue, listaTM) {

        var json = JSON.stringify({
            objCENCaja: {
                descripcion: descripcionValue,
                ntraUsuario: encargadoValue,
                listaTipoMovimientos: listaTM

            }
        });

        $.ajax({
            type: "POST",
            url: "frmMaestroCajas.aspx/RegistrarCaja",
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
                    ListarCajas(0, 0, 0, "", "")
                    ListarCajasCerradas(0, 2, 0, "", "")

                    limpiarCampos()

                } else {

                    Mpmensaje.css("color", "rgba(179, 10, 10, 0.69)");
                    Mmensaje.css("background-color", "rgba(255, 0, 0, 0.51)")
                        .css("border-color", "rgb(203, 46, 46)");
                    Mpmensaje.html("No se pudo registrar la caja");
                    Mmensaje.css("display", "block");

                    limpiarCampos()

                }

            }
        });
    }

    function ActualizarCaja(ntraCaja, encargadoValue, descripcionValue, listaTM) {

        var json = JSON.stringify({
            objCENCaja: {
                ntraCaja: ntraCaja,
                descripcion: descripcionValue,
                ntraUsuario: encargadoValue,
                listaTipoMovimientos: listaTM

            }
        });

        $.ajax({
            type: "POST",
            url: "frmMaestroCajas.aspx/ActualizarCaja",
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
                    ListarCajas(0, 0, 0, "", "")

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

    // APERTURA DE CAJA

    $('.decimales').on('input', function () {
        this.value = this.value.replace(/[^0-9,.]/g, '').replace(/,/g, '.');
    });

    //tabla de tipos de movimientos de caja en registrar/editar
    var tbCajasAperturadas = $("#tb_cajas_aperturadas");
    tbCajasAperturadas.DataTable({
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

        //Para que el DataTable no me muestre ciertas Columnas.
        columnDefs: [
            {
                targets: [0],
                "visible": false,
                "searchable": false
            }

        ]

    });

    //creo variables despues de que el DataTable este creado en el DOM.
    var tablaCajasAp = $("#tb_cajas_aperturadas").dataTable(); //funcion jquery
    var tableCajasAp = $("#tb_cajas_aperturadas").DataTable(); //funcion DataTable-libreria
    //////////////////////////////////////////////////////////////////

    /////LENADO DE TABLA POR DEFECTO //// 
    function addRowDTCA(data) {

        //DESCRIPCION : Funcion que crea el listado de cajas aperturadas en el body del DataTable


        for (var i = 0; i < data.length; i++) {

            var btns;
            if (data[i].codEstado == 1) {
                btns = btnEditarApertura + btnIniciarProcesoApertura
            } else {
                btns = lblProcesado
            }


            tablaCajasAp.fnAddData([
                data[i].ntraAperturaCaja,
                data[i].fecha + ' ' + data[i].hora,
                data[i].caja,
                data[i].saldoSoles,
                data[i].saldoDolares,
                btns

            ]);
        }

        $("body").on('click', '.btnEdAp', function () {
            lblTitle.text("Actualizar Apertura de Caja");
            divRegEditCaja.css("display", "none");
            divAperturaCaja.css("display", "block");
            divVerCaja.css("display", "none");
            btnGuardar.css("display", "none");
            btnRegistrar.css("display", "none");
            btnAperturar.css("display", "none");
            btnGuardarA.css("display", "block");
            Mmensaje.css('display', 'none');
            divCajaAp.css("display", "none");

            var tr = $(this).parent().parent();

            txtNtraAperturaCaja.val(tableCajasAp.row(tr).data()[0]);
            txtImpSoles.val(tableCajasAp.row(tr).data()[3]);
            txtImpDolares.val(tableCajasAp.row(tr).data()[4]);

        });

    }

    ListarCajasAperturadas(0,0)

    function ListarCajasAperturadas(ntraCaja, flag) {
        //DESCRICION : Funcion que obtiene la lista de cajas aperturadas

        var json = JSON.stringify({
            ntraCaja: ntraCaja,
            flag: flag
        });

        $.ajax({
            type: "POST",
            url: "frmMaestroCajas.aspx/ListarCajasAperturadas",
            data: json,
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                // console.log(data.d);
                var b = false;
                var fechaActual = new Date();
                fechaActual.setHours(0, 0, 0, 0);
                for (var i = 0; i < data.d.length; i++) {
                    var date = data.d[i].fecha.split("/"); 

                    var dd = date[0];
                    var mm = date[1] - 1;
                    var yyyy = date[2];
                    var fecha = new Date(yyyy, mm, dd); 

                    if (fechaActual.getTime() > fecha.getTime()) {
                        b = true;
                    } 
                }

                if (b) {
                    swal({
                        title: "CAJAS NO CERRADAS",
                        text: "Se ha detectado que algunas cajas no han sido cerradas, por lo que no se podrá crear ni aperturar cajas.",
                        icon: "warning",
                        buttons: {

                            cancel: {
                                text: "Cancelar",
                                visible: false,
                            },
                            confirm: {
                                text: "Aceptar",
                                visible: true,
                            },
                        },

                        dangerMode: true,

                    });

                    btnCrearCaja.prop("disabled", true);
                    btnAperturarCaja.prop("disabled", true);
                } else {
                    btnCrearCaja.prop("disabled", false);
                    btnAperturarCaja.prop("disabled", false);
                }

                tableCajasAp.clear().draw();
                addRowDTCA(data.d);
            }
        })
    }

    btnAperturarCaja.click(function () {
        lblTitle.text("Aperturar Caja");
        divRegEditCaja.css("display", "none");
        divAperturaCaja.css("display", "block");
        divVerCaja.css("display", "none");
        btnGuardar.css("display", "none");
        btnRegistrar.css("display", "none");
        btnAperturar.css("display", "block");
        btnGuardarA.css("display", "none");
        Mmensaje.css('display', 'none');
        divCajaAp.css("display", "block");
        limpiarCampos();
    });

    btnAperturar.click(function () {
        var cajaSelect = selectCajaMA.find("option:selected");
        cajaValue = cajaSelect.val();
        var impSolesValue = txtImpSoles.val();
        var impDolaresValue = txtImpDolares.val();

        if (cajaValue > 0) {
            if (impSolesValue >= 0) {
                if (impDolaresValue >= 0) {
                    AperturarCaja(cajaValue, impSolesValue, impDolaresValue)
                } else {
                    txtImpDolares.attr("required", "required");
                }
            } else {
                txtImpSoles.attr("required", "required");
            }
        } else {
            selectCajaMA.attr("required", "required");
            Mpmensaje.css("color", "rgba(179, 10, 10, 0.69)");
            Mmensaje.css("background-color", "rgba(255, 0, 0, 0.51)")
                .css("border-color", "rgb(203, 46, 46)");
            Mpmensaje.html("Debe seleccionar una caja");
            Mmensaje.css("display", "block");
            setTimeout(function () {
                Mmensaje.css('display', 'none');
            }, 2000);
        }

    });

    btnGuardarA.click(function () {
        var impSolesValue = txtImpSoles.val();
        var impDolaresValue = txtImpDolares.val();
        var ntraAperturaCaja = txtNtraAperturaCaja.val();

            if (impSolesValue >= 0) {
                if (impDolaresValue >= 0) {
                    ActualizarAperturaCaja(ntraAperturaCaja, impSolesValue, impDolaresValue)
                } else {
                    txtImpDolares.attr("required", "required");
                }
            } else {
                txtImpSoles.attr("required", "required");
            }

    });

    function AperturarCaja(cajaValue, impSolesValue, impDolaresValue) {

        var json = JSON.stringify({
            objCENAperturaCaja: {
                ntraCaja: cajaValue,
                saldoSoles: impSolesValue,
                saldoDolares: impDolaresValue

            }
        });

        $.ajax({
            type: "POST",
            url: "frmMaestroCajas.aspx/RegistrarAperturaCaja",
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

                    tableCajasAp.clear().draw();
                    ListarCajasAperturadas(0,0)
                    ListarCajasCerradas(0, 2, 0, "", "")
                    ListarCajas(0, 0, 0, "", "")

                    limpiarCampos()

                } else {

                    Mpmensaje.css("color", "rgba(179, 10, 10, 0.69)");
                    Mmensaje.css("background-color", "rgba(255, 0, 0, 0.51)")
                        .css("border-color", "rgb(203, 46, 46)");
                    Mpmensaje.html("No se pudo registrar la apertura de caja");
                    Mmensaje.css("display", "block");

                    limpiarCampos()

                }

            }
        });
    }

    function ActualizarAperturaCaja(ntraAperturaCaja, impSolesValue, impDolaresValue) {

        var json = JSON.stringify({
            objCENAperturaCaja: {
                ntraAperturaCaja: ntraAperturaCaja,
                saldoSoles: impSolesValue,
                saldoDolares: impDolaresValue

            }
        });

        $.ajax({
            type: "POST",
            url: "frmMaestroCajas.aspx/ActualizarAperturaCaja",
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

                    tableCajasAp.clear().draw();
                    ListarCajasAperturadas(0,0)

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

   // VER DETALLE CAJA

    //Llenado de tabla aperturas de caja

    //creo variables despues de que el DataTable este creado en el DOM.
    var tablaApCaja = $("#id_table_ver_ap_caja").dataTable(); //funcion jquery
    var tableApCaja = $("#id_table_ver_ap_caja").DataTable(); //funcion DataTable-libreria
    //////////////////////////////////////////////////////////////////

    /////LENADO DE TABLA APERTURAS DE CAJA POR DEFECTO ////
    function addRowDTApCaja(data) {

        //DESCRIPCION : Funcion que me crea el listado de aperturas de caja en el body del DataTable

        var apCaja = null;

        for (var i = 0; i < data.length; i++) {

            tablaApCaja.fnAddData([
                data[i].fecha + ' ' + data[i].hora,
                data[i].saldoSoles,
                data[i].saldoDolares

            ]);

            if (data[i].marcaBaja == 0) {
                apCaja = data[i];
            }

        }

        if (apCaja != null) {
            txtFecApCaja.val(apCaja.fecha)
            txtSaldoSCaja.val(apCaja.saldoSoles)
            txtSaldoDCaja.val(apCaja.saldoDolares)
        }

    }

    function ListarDetalle_ApCaja(ntraCaja, flag) {
        //DESCRICION : Funcion que obtiene la lista de cajas aperturadas

        var json = JSON.stringify({
            ntraCaja: ntraCaja,
            flag: flag
        });

        $.ajax({
            type: "POST",
            url: "frmMaestroCajas.aspx/ListarCajasAperturadas",
            data: json,
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                // console.log(data.d);
                tableApCaja.clear().draw();
                addRowDTApCaja(data.d);
            }
        })
    }

    //Llenado de tabla cierres de caja

    //creo variables despues de que el DataTable este creado en el DOM.
    var tablaCiCaja = $("#id_table_ver_ci_caja").dataTable(); //funcion jquery
    var tableCiCaja = $("#id_table_ver_ci_caja").DataTable(); //funcion DataTable-libreria
    //////////////////////////////////////////////////////////////////

    /////LENADO DE TABLA CIERRES DE CAJA POR DEFECTO ////
    function addRowDTCiCaja(data) {

        //DESCRIPCION : Funcion que me crea el listado de cierres de caja en el body del DataTable


        for (var i = 0; i < data.length; i++) {

            var vS = "";
            var vD = "";

            if (data[i].saldoSolesCierre == data[i].saldoSoles) {
                vS = "";
            } else if (data[i].saldoSolesCierre < data[i].saldoSoles) {
                vS = " faltantes";
            } else {
                vS = " sobrantes";
            }

            if (data[i].saldoDolaresCierre == data[i].saldoDolares) {
                vD = "";
            } else if (data[i].saldoDolaresCierre < data[i].saldoDolares) {
                vD = " faltantes";
            } else {
                vD = " sobrantes";
            }

            tablaCiCaja.fnAddData([
                data[i].fecha + ' ' + data[i].hora,
                data[i].saldoSolesCierre,
                data[i].saldoSoles,
                data[i].difSaldoSoles + vS,
                data[i].saldoDolares,
                data[i].saldoDolaresCierre,
                data[i].difSaldoDolares + vD

            ]);
        }

    }

    function ListarDetalle_CiCaja(ntraCaja, flag) {
        //DESCRICION : Funcion que obtiene la lista de cajas cerradas

        var json = JSON.stringify({
            ntraCaja: ntraCaja,
            flag: flag
        });

        $.ajax({
            type: "POST",
            url: "frmMaestroCajas.aspx/ListarCajasCerradas",
            data: json,
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                // console.log(data.d);
                tableCiCaja.clear().draw();
                addRowDTCiCaja(data.d);
            }
        })
    }

    //Llenado de tabla transacciones de caja

    //creo variables despues de que el DataTable este creado en el DOM.
    var tablaTrCaja = $("#id_table_ver_movs_caja").dataTable(); //funcion jquery
    var tableTrCaja = $("#id_table_ver_movs_caja").DataTable(); //funcion DataTable-libreria
    //////////////////////////////////////////////////////////////////

    /////LENADO DE TABLA TRANSACCIONES DE CAJA POR DEFECTO ////
    function addRowDTTrCaja(data) {

        //DESCRIPCION : Funcion que me crea el listado de transacciones de caja en el body del DataTable


        for (var i = 0; i < data.length; i++) {

            var estado;
            if (data[i].marcaBaja == 0) {
                estado = "ACTIVO"
            } else {
                estado = "ANULADO"
            }

            tablaTrCaja.fnAddData([
                data[i].fechaTransaccion + ' ' + data[i].horaTransaccion,
                data[i].tipoRegistro,
                data[i].tipoMovimieno,
                data[i].importe,
                data[i].tipoMoneda,
                data[i].modoPago,
                data[i].tipoTransaccion,
                estado

            ]);
        }

    }

    function ListarDetalle_TrCaja(ntraCaja, fechaTransaccion, flag) {
        //DESCRICION : Funcion que obtiene la lista de transacciones de cajas

        var json = JSON.stringify({
            ntraCaja: ntraCaja,
            fechaTransaccion: fechaTransaccion,
            flag: flag
        });

        $.ajax({
            type: "POST",
            url: "frmMaestroCajas.aspx/ListarTransaccionesCajas",
            data: json,
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                // console.log(data.d);
                tableTrCaja.clear().draw();
                addRowDTTrCaja(data.d);
            }
        })
    }


    //Llenado de tabla lista de movimientos de caja

    //creo variables despues de que el DataTable este creado en el DOM.
    var tablaLmCaja = $("#id_table_ver_tipos_mov_caja").dataTable(); //funcion jquery
    var tableLmCaja = $("#id_table_ver_tipos_mov_caja").DataTable(); //funcion DataTable-libreria
    //////////////////////////////////////////////////////////////////

    /////LENADO DE TABLA LISTA DE MOVIMIENTOS DE CAJA POR DEFECTO ////
    function addRowDTLmCaja(data) {

        //DESCRIPCION : Funcion que me crea el listado de lista de movimientos de caja en el body del DataTable

        for (var i = 0; i < data.length; i++) {
            tablaLmCaja.fnAddData([
                data[i].descripcion,
                data[i].tipoRegistro

            ]);
        }

    }

    function listarDetalleLmCaja(ntraCaja) {
        //DESCRICION : Funcion que obtiene la lista de movimientos de caja 
        var json = JSON.stringify({
            objCENCaja: {
                ntraCaja: ntraCaja
            }
        });

        $.ajax({
            type: "POST",
            url: "frmMaestroCajas.aspx/ListarTipos_Mov_Asig_Caja",
            data: json,
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                // console.log(data.d);
                tableLmCaja.clear().draw();
                addRowDTLmCaja(data.d.listaTipoMovimientos);

            }
        })
    }

});