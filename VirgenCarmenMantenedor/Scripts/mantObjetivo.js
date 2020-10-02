$(document).ready(function () {
    var tblObjetivo = $("#id_tblObjetivos");
    var TipoIndicador = $("#tindicador");    //variable para cargar el tipo de indicador
    var TipoindicadorM = $("#tindicadorM");
    var indicadorM = $("#indicadorM");
    var perfil = $("#perfil");
    var perfilM = $("#perfilM");
    var trabajador = $("#trabajador");
    var trabajadorM = $("#trabajadorM");
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

    tblObjetivo.DataTable({
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
                "width": "8%",
                "class": "text-center",
                "targets": [2]
            },
            {
                "width": "8%",
                "class": "text-center",
                "targets": [3]
            },
            {
                "width": "8%",
                "class": "text-center",
                "targets": [4]
            },
            {
                "width": "10%",
                "class": "text-center",
                "targets": [5]
            },
            {
                "width": "8%",
                "class": "text-center",
                targets: [7],
                render: function (data) {
                    return moment(data).format('DD/MM/YYYY');
                }
            },
            {
                "width": "15%",
                "class": "text-center",
                "targets": [8]
            },
        ]
    }) 

    var tabla = $("#id_tblObjetivos").dataTable(); //funcion jquery
    var table = $("#id_tblObjetivos").DataTable(); //funcion DataTable-libreria

    function agregarObjetivo(data) {
        for (var i = 0; i < data.length; i++) {
            tabla.fnAddData([
                data[i].codObjetivo,
                data[i].descripcion,
                data[i].descTipoIndicador,
                data[i].descIndicador,
                data[i].valorIndicador,
                data[i].descPerfil,
                data[i].descTrabajador,
                data[i].fechaRegistro,
                btnEditar + btnEliminar
            ]);
        }

        $('.date-range-filter').change(function () {
            validar($('#min-date').val(), $('#max-date').val());
        });
    }

    function ListarObjetivos(codTipoIndicador, codIndicador, codPerfil, codTrabajador, fechainicio, fechaFin) {
        var json = JSON.stringify({
            codTipoIndicador: codTipoIndicador,
            codIndicador: codIndicador,
            codPerfil: codPerfil,
            codTrabajador: codTrabajador,
            fechaInicio: fechainicio,
            fechaFin: fechaFin
        });
        $.ajax({
            type: "POST",
            url: "frmMantObjetivo.aspx/ListarObjetivos",
            data: json,
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                table.clear().draw();
                agregarObjetivo(data.d);
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

    ListarObjetivos(0, 0, 0, 0, "", "")
    ListarTipoIndicador();
    ListarPerfil();  

    function addlistarTipoIndicador(data) {
        //función listar el tipo de indicador del objetivo
        for (var i = 0; i < data.length; i++) {
            TipoIndicador.append("<option value=" + data[i]["correlativo"] + ">" + data[i]["descripcion"] + "</option>");
            TipoindicadorM.append("<option value=" + data[i]["correlativo"] + ">" + data[i]["descripcion"] + "</option>");
        }
    }
    function ListarTipoIndicador() {
        $.ajax({
            type: "POST",
            url: "frmMantObjetivo.aspx/ListaConceptos",
            data: "{'flag': '35'}",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                addlistarTipoIndicador(data.d);
            }
        })
    }

    function addlistarIndicador(data) {
        indicadorM.append("<option value='0'>-Seleccionar-</option>");
        for (var i = 0; i < data.length; i++) {
            indicadorM.append("<option value=" + data[i]["correlativo"] + ">" + data[i]["descripcion"] + "</option>");
        }
    }
    function ListarIndicador(codigo) {
        indicadorM.children().remove();
        if (codigo == '0') {           
            indicadorM.append("<option value='0'>-Seleccionar-</option>");
        } else {
            if (codigo == '1') {
                $.ajax({
                    type: "POST",
                    url: "frmMantObjetivo.aspx/ListaConceptos",
                    data: "{'flag': '52'}",
                    contentType: 'application/json; charset=utf-8',
                    error: function (xhr, ajaxOtions, thrownError) {
                        console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
                    },
                    success: function (data) {
                        addlistarIndicador(data.d);
                    }
                });
            } else {
                $.ajax({
                    type: "POST",
                    url: "frmMantObjetivo.aspx/ListaConceptos",
                    data: "{'flag': '26'}",
                    contentType: 'application/json; charset=utf-8',
                    error: function (xhr, ajaxOtions, thrownError) {
                        console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
                    },
                    success: function (data) {
                        addlistarIndicador(data.d);
                    }
                });
            }
        }        
    }

    $("#tindicadorM").change(function () {
        let codigo = $("#tindicadorM").val();
        ListarIndicador(codigo);
    });
    
    function addlistarPerfil(data) {
        //función listar el tipo de indicador del objetivo
        for (var i = 0; i < data.length; i++) {
            perfil.append("<option value=" + data[i]["correlativo"] + ">" + data[i]["descripcion"] + "</option>");
            perfilM.append("<option value=" + data[i]["correlativo"] + ">" + data[i]["descripcion"] + "</option>");
        }
    }
    function ListarPerfil() {
        $.ajax({
            type: "POST",
            url: "frmMantObjetivo.aspx/ListaConcecptosPerfil",
            data: "{'flag': '32'}",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                addlistarPerfil(data.d);
            }
        })
    } 

    function addlistarTrabajador(data) {
        trabajadorM.append("<option value='0'>-Seleccionar-</option>");
        for (var i = 0; i < data.length; i++) {
            trabajadorM.append("<option value=" + data[i]["codPersona"] + ">" + data[i]["nombres"] + "</option>");
        }
    }
    function ListarTrabajador(codigo) {      
        trabajadorM.children().remove();
        if (codigo == '0') {           
            trabajadorM.append("<option value='0'>-Seleccionar-</option>");
        } else {
            $.ajax({
                type: "POST",
                url: "frmMantObjetivo.aspx/ListarTrabajador",
                data: "{'codPer': '" + codigo + "'}",
                contentType: 'application/json; charset=utf-8',
                error: function (xhr, ajaxOtions, thrownError) {
                    console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
                },
                success: function (data) {
                    addlistarTrabajador(data.d);
                }
            });
        }
    }
    
    $("#perfilM").change(function () {
        let codigo = $("#perfilM").val();
        ListarTrabajador(codigo);
    });

    function InsertarObjetivo(data) {
        $.ajax({
            type: "POST",
            url: "frmMantObjetivo.aspx/InsertarObjetivo",
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
            var tindicador = $("#tindicadorM").val();
            var indicador = $("#indicadorM").val();
            var vaIndicador = $("#vindicador").val();
            var perfil = $("#perfilM").val();
            var trabajador = $("#trabajadorM").val();

            var json = JSON.stringify({
                descripcion: descripcion, tipoIndicador: tindicador, indicador: indicador,
                valorIndicador: vaIndicador, perfil: perfil, trabajador: trabajador});
            
            if (descripcion.length == 0) {
                swal("Debe Ingresar una Descripción", {
                    icon: "info"
                });
            }
            else {
                if (tindicador == 0) {
                    swal("Debe Seleccionar un Tipo de indicador", {
                        icon: "info"
                    });
                } else {
                    if (indicador == 0) {
                        swal("Debe Seleccionar un Indicador", {
                            icon: "info"
                        });
                    } else {
                        if (vaIndicador.length == 0) {
                            swal("Debe Ingresar el Valor del Indicador", {
                                icon: "info"
                            });
                        } else {
                            if (perfil == 0) {
                                swal("Debe Seleccionar un Perfil", {
                                    icon: "info"
                                });
                            } else {
                                if (trabajador == 0) {
                                    swal("Debe Seleccionar un Trabajador", {
                                        icon: "info"
                                    });
                                } else {
                                    InsertarObjetivo(json);
                                    limpiarcampos();
                                    //ListarMetas(0, 0, "", "")
                                }
                            }
                        }
                    }
                }            
            }
        })
    }

    GuardarMeta();

    function limpiarcampos() {
        $("#Mdescripcion").val("");
        $("#tindicadorM").val() == 0;
        $("#indicadorM").val() == 0;
        $("#vindicador").val("");
        $("#perfilM").val() == 0;
        $("#trabajadorM").val() == 0;
        $("#objetivoModal").modal('hide');//ocultamos el modal
        $('body').removeClass('modal-open');//eliminamos la clase del body para poder hacer scroll
        $('.modal-backdrop').remove();//eliminamos el backdrop del moda
    }
});