$(document).ready(function () {
    var tblMeta = $("#id_tblMetas");
    var btnBuscar = $("#btnBuscar");
    var codProveedor = $("codProveedor");
    var codEstado = $("codEstado");
    var rspta = true;
    var btnEditar = ' <button type="button" title="Editar" class="icon-pencil btnEditar" data-toggle="modal" data-target="#metaModal"></button>';
    var btnEliminar = ' <button type="button" title="Anular" class="icon-bin btnDelete" data-toggle="modal" data-target="#modalAnular"></button>';
    $("#min-date").datepicker(
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

    $("#max-date").datepicker(
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
    $("#min-dateR").datepicker(
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

    $("#max-dateR").datepicker(
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
    
    tblMeta.DataTable({
        ordering: false,
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

                "width": "5%",
                "class": "text-center",
                "targets": [0]
            },
            {
                "width": "15%",
                "class": "text-center",
                "targets": [4]
            },
            {
                "class": "text-center",
                targets: [2],
                render: function (data) {
                    return moment(data).format('DD/MM/YYYY');
                }
            },
            {
                "class": "text-center",
                targets: [3],
                render: function (data) {
                    return moment(data).format('DD/MM/YYYY');
                }
            },
        ]
    }) 

    var tabla = $("#id_tblMetas").dataTable(); //funcion jquery
    var table = $("#id_tblMetas").DataTable(); //funcion DataTable-libreria

    function agregarMeta(data) {
        for (var i = 0; i < data.length; i++) {
            tabla.fnAddData([
                data[i].codMeta,
                data[i].descripcion,
                data[i].fechaInicio,
                data[i].fechaFin,
                btnEditar + btnEliminar
            ]);
        }

        $('.date-range-filter').change(function () {          
            validar($('#min-date').val(), $('#max-date').val());
        });
    }
   
    function ListarMetas(codProveedor, codEstado, fechainicio, fechaFin) {
        var json = JSON.stringify({
            codProveedor: codProveedor,
            codEstado: codEstado,
            fechaInicio: fechainicio,
            fechaFin: fechaFin
        });
        $.ajax({
            type: "POST",
            url: "frmMantMetas_1.aspx/ListarMetas",
            data: json,
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                table.clear().draw();
                agregarMeta(data.d);
            }
        })
    }

    function validar(min, max) {
        var minr = min.split('/').join('-');
        var maxr = max.split('/').join('-');
        var minf = moment(minr, 'DD-MM-YYYY').format("YYYY-MM-DD");
        var maxf = moment(maxr, 'DD-MM-YYYY').format("YYYY-MM-DD");
        var startDate = moment(minf, "YYYY-MM-DD");
        var endDate = moment(maxf, "YYYY-MM-DD");
        if ((min != "" && max != "") && (endDate < startDate)) {
            $('#max-date').val("");
            swal("La fecha inicial debe ser mayor a la fecha final", {
                icon: "error"
            });
            rspta = false;
            return rspta;
        } else {
            rspta = true;
            return rspta; 
        }
    }

    ListarMetas(0, 0, "", "")

    btnBuscar.click(function () {
        var optionCodProveedor = codProveedor.find("option:selected");
        var valueSelectedProveedor = optionCodProveedor.val();

        var optionCodEstado = codEstado.find("option:selected");
        var valueSelectedEstado = optionCodEstado.val();

        if (valueSelectedProveedor == undefined) {
            valueSelectedProveedor = 0
        }

        if (valueSelectedEstado == undefined) {
            valueSelectedEstado = 0
        }

        var min = $('#min-date').val();
        var max = $('#max-date').val();

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

        if (valueSelectedProveedor == 0 && valueSelectedEstado == 0 && min == "" && max == "") {
            ListarMetas( 0, 0, "", "")
        } else {
            if (min != "" && max == "") {
                swal("Debe Ingresar una fecha final o Borrar la fecha inicial", {
                    icon: "info"
                });
            } else {
                ListarMetas(0, 0, startDate, endDate)
            }          
        }
    })
    
    function InsertarMetas(data) {    
        $.ajax({
            type: "POST",
            url: "frmMantMetas_1.aspx/InsertarMeta",
            data: data,
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function () {
                swal("Registro Exitoso", {
                    icon: "success"
                });
            }

        });
    }

    function GuardarMeta() {
        $("#btnGuardar").click(function () {
            var descripcion = $("#Mdescripcion").val();
            var fechaI = $("#min-dateR").val();
            var fechaF = $("#max-dateR").val();
            var minr = fechaI.split('/').join('-');
            var maxr = fechaF.split('/').join('-');
            var minf = moment(minr, 'DD-MM-YYYY').format("YYYY-MM-DD");
            var maxf = moment(maxr, 'DD-MM-YYYY').format("YYYY-MM-DD");
            var startDate = moment(minf, "YYYY-MM-DD");
            var endDate = moment(maxf, "YYYY-MM-DD");
            var json = JSON.stringify({ descripcion: descripcion, fechaInicio: startDate, fechaFin: endDate});                       

            if (descripcion.length == 0) {
                swal("Debe agregar descripción de la meta", {
                   icon: "info"
                });
            }
            else {
                if (fechaI.length == 0) {
                    swal("Debe agregar fecha de inicio", {
                        icon: "info"
                    });
                }
                else {
                    if (fechaF.length == 0) {
                        swal("Debe agregar fecha de fin", {
                            icon: "info"
                        });
                    }
                    else {
                        validar($('#min-dateR').val(), $('#max-dateR').val())
                        if (rspta) {
                            InsertarMetas(json);
                            limpiarcampos();
                            ListarMetas(0, 0, "", "");
                        }                       
                    }
                }
            }
        })
    }

    GuardarMeta();

    function limpiarcampos() {
        $("#Mdescripcion").val("");
        $("#min-dateR").val("");
        $("#max-dateR").val("");
        $("#metaModal").modal('hide');//ocultamos el modal
        $('body').removeClass('modal-open');//eliminamos la clase del body para poder hacer scroll
        $('.modal-backdrop').remove();//eliminamos el backdrop del moda
    }
});