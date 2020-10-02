$(document).ready(function () {


    /*---------------------- FILTROS--------------------------------*/

    var estado = $("#idEstado");

    // var lblNumDoc             =      $("#id_lblNumDoc");
    var btnBuscarFiltro = $("#id_btnBuscar");
    var codUsuarioSelect;
    /*---------------------- Titulos--------------------------------*/
    var exampleModalLabel_detalle = $("#exampleModalLabel_detalle");
    var exampleModalLabel_editar = $("#exampleModalLabel_editar");
    var exampleModalLabel_agregar = $("#exampleModalLabel_agregar");
    /*---------------------- MODAL--------------------------------*/;
    /*---DATOS PERSONALES---*/;
    var tipoPersoModal = $("#tipPer");
    var tipoDocModal = $("#tipDoc");
    var numDocModal = $("#docPer");
    var nombPersoModal = $("#nomPer");
    var apepPersoModal = $("#appPer");
    var apemPersoModal = $("#apmPer");
    var fecnPersoModal = $("#fecPer");
    var direPersoModal = $("#dirPer");
    var emaiPersoModal = $("#emaPer");
    var estcPersoModal = $("#etcPer");
    var asifPersoModal = $("#asfPer");
    var telePersoModal = $("#telPer");
    var celuPersoModal = $("#celPer");
    var rucPersoModal = $("#rucPer");
    /*---DATOS LABORALES---*/;
    var areaTrabModal = $("#areaTrab");
    var tipoTrabModal = $("#tipoTrab");
    var estaTrabModal = $("#estaTrab");
    var cargTrabModal = $("#cargTrab");
    var fpagTrabModal = $("#fpagTrab");
    var ncueTrabModal = $("#ncueTrab");
    var tregTrabModal = $("#tregTrab");
    var rpenTrabModal = $("#rpenTrab");
    var irpeTrabModal = $("#irpeTrab");
    var bremTrabModal = $("#bremTrab");
    var eplaTrabModal = $("#eplaTrab");
    /*---CONTRATOS---*/;
    var modcTrabModal = $("#modcTrab");
    var periTrabModal = $("#periTrab");
    var inicTrabModal = $("#inicTrab");
    var fincTrabModal = $("#fincTrab");
    var fingTrabModal = $("#finiTrab");
    var suelTrabModal = $("#suelTrab");
    /**********Button*******/
    var btnActualizar = $("#btnActualizar");
    var btnGuardar = $("#btnGuardar");
    var btnCancelar = $("#btnCancelar");

    var buttonModal = $("#buttonModal") // btnAgregar

    /*---------------------- SWingert Alert-------------------------------*/
    var Mmensaje = $("#Mmensaje");
    var msjAlert = $("#msjAlert");
    var msjAlertp = $("#msjAlert");
    /*---------------------- TABLA--------------------------------*/
    var btnver = '<button type="button" id="" class="icon-search btnSearch" data-toggle="modal"  data-target="#exampleModal"> </button>'
    var btnEditar = '<button type="button" title="Editar" class="icon-pencil btnEditar" data-toggle="modal"  data-target="#exampleModal"></button>'
    var btnEliminar = '<button type="button" id="" class="icon-cancel-circle btnCancel"  data-toggle="tooltip"></button>'

    var tableBody = $("#tbl_body_table");

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /* ----------------------------------------------------------------Propiedades para el DataTable--------------------------------------------------------*/
    $('#tbl_usuario').DataTable({
        //paging: false,
        //ordering: false,
        info: false,
        language: {
            lengthMenu: "Mostrar _MENU_ registros",
            zeroRecords: "No hay registros",
            info: "Mostrando la página _PAGE_ de _PAGES_",
            infoEmpty: "No hay registros disponibles.",
            infoFiltered: "(filtered from _MAX_ total records)",
            search: "Busqueda rapida: ",
            paginate: {
                previous: "Atras",
                next: "Siguiente"
            }
        },
        dom: 'lBfrtip',

        //Para que el DataTable no me muestre ciertas Columnas.
        columnDefs: [
            {
                //"width": "2%",
                "targets": [1, 2, 3, 4, 5, 6, 7, 8, 9]
            },
            {
                //"width": "12%",
                "targets": [0],
                "visible": false,
                "searchable": false
            }


        ]
    });
    /* ----------------------------------------------------------------Termina propiedades para el DataTable--------------------------------------------------------*/

    //creo variables despues de que el DataTable este creado en el DOM.
    var tabla = $("#tbl_usuario").dataTable(); //funcion jquery
    var table = $("#tbl_usuario").DataTable(); //funcion DataTable-libreria
    table.columns.adjust().draw();
    /* -----------------------------------------------------------------------------------------------------------------------------------------------------*/

    /* ----------------------------------------------------------------Trama cargar datos de los datos en la tabla,parametros para filtros y botones ver, editar y eliminar--------------------------------------------------------*/

    function addRowDT(data) {
        //DESCRIPCION : Funcion que lee, recorre y modifica el JSON que trae los datos del usuario en el body del DataTable
        for (var i = 0; i < data.length; i++) {
            tabla.fnAddData([
                data[i].codPersona,
                data[i].ntraUsuario,
                data[i].numDocumento,
                data[i].nomUser,
                data[i].codSucursal,
                data[i].desSucursal,
                data[i].usuarioPersona,
                data[i].correo,
                data[i].celular,
                data[i].telefono,
                data[i].codPerfil,
                data[i].desPerfil,
                data[i].codEstado,
                data[i].desEstado,
                btnver + btnEditar + btnEliminar
            ]);
        }
        // Boton detalle en la tabla
        $(".btnVer").click(function () {
            //$("#dniPer").prop('disabled',true);

        });

        // funcion para obtener datos de silvestre ramos
        $(".btnEditar").click(function () {
            Mmensaje.css('display', 'none');
            var tr = $(this).parent().parent(); //obtengo el padre(td) del padre (tr) del boton
            //$("#dniPer").prop('disabled',false);     
            estadoModal.prop('selectedIndex', table.row(tr).data()[12]);
            selectPerfilmodal.prop('selectedIndex', table.row(tr).data()[10]);
            numDocModal.val(table.row(tr).data()[2]);
            nomUsuarioModal.val(table.row(tr).data()[3]);
            nomPersonaModal.val(table.row(tr).data()[6]);
            telefonoModal.val(table.row(tr).data()[8]);
            celularModal.val(table.row(tr).data()[9]);
            selectSucurModal.prop('selectedIndex', table.row(tr).data()[4]);
            //document.getElementById("#exampleModalLabel").style.display= "none";
            //$("#h5_editar_Usuario").css("display", "none");

            //btnActualizar.css("display", "block")
            //btnBloquear.css("display", "block") 
            //btnGuardar.css("display", "none");
            exampleModalLabel_editar.css('display', 'block');
            exampleModalLabel_detalle.css('display', 'none');
            exampleModalLabel_agregar.css('display', 'none');

        });

        // Boton bloquear en la tabla
        $(".btnCancel").click(function () {
            //Obtengo los valores de mi tr seleccionado.
            /*
            var tr = $(this).parent().parent();
            var codUsuarioT = table.row(tr).data()[6];
            var coodRutaT = table.row(tr).data()[5];
            var posicion = tr[0].sectionRowIndex;
            var cantidadFilas = parseInt(table.rows().count());
            
           // var restantes = parseInt(cantidadFilas - Orden)
            */

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
                        ElimiarRutasAsignadas(codUsuarioT, coodRutaT)
                        swal("Se elimino Registro", {
                            icon: "success",
                        });
                        RestarOrden(posicion, cantidadFilas);
                    } else {
                        swal("Se Cancelo la eliminaciòn");
                    }
                });
        });


        $(function () {
            $('[data-toggle="#exampleModal"]').tooltip()
        })
        var tr = $("#tbl_body_table tr");
    }


    CargarDatos(1, 0, 0);

    function CargarDatos(flagFiltro, codEstado, codUsuario)
    //DESCRIPCION: Cargar Datos de la listar usuarios a la Tabla y para hacer mis filtros
    {
        var json = JSON.stringify(
            {
                flagFiltro: flagFiltro,
                codEstado: codEstado,
                codUsuario: codUsuario
            }
        );
        console.log(json);
        $.ajax(
            {
                type: "POST",
                url: "frmMantUsuario.aspx/CargarTabla",
                data: json,
                contentType: 'application/json; charset=utf-8',
                error: function (xhr, ajaxOtions, thrownError) {
                    console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
                },
                success: function (data) {
                    console.log(data.d);
                    table.clear().draw();
                    addRowDT(data.d);

                }
            }
        )
    }

    /* ----------------------------------------------------------------Termina trama cargar datos de los datos en la tabla,parametros para mis filtros y botones ver, editar y eliminar--------------------------------------------------------*/


    /* ---------------------------------------------------------------------Tramas para cargar datos en los filtros de busqueda----------------------------------------------------- */


    function ListarEstado()
    //DESCRIPCION : Funcion que me trae la lista de estados de los estados d un usuario
    {
        $.ajax(
            //llamo al metodo ajax para realizar peticiones (request-response) al servidor 
            //utilizamos <$.ajax({objeto-configurable})>  esta forma de llamar al metodo ajax que nos da jquery
            {
                type: "POST",
                url: "frmMantUsuario.aspx/ListarEstado",
                data: "{'flag': '24'}",  //reutilizando CEN,CAD,CLN listar dias por tabla concepto para estado de usuarios                                                       
                contentType: 'application/json; charset=utf-8',
                error: function (xhr, ajaxOtions, thrownError) {
                    console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
                },
                success: function (data)
                //trae los datos de la tramaSQL en formato JSON --->(data)
                {
                    addSelectEstado(data.d);

                }
            }
        );
    }

    ListarEstado();

    function addSelectEstado(data) {
        //DESCRIPCION : Funcion para llenar la lista de opciones del select del estado.
        for (var i = 0; i < data.length; i++) {
            estado.append("<option value=" + data[i]["correlativo"] + ">" + data[i]["descripcion"] + "</option>");
        }
    }

    //function CargarSelectEstadoTrabajador() {
    //    //DESCRIPCION: Cargar Datos a la combobox EstadoTrabajador
    //    $.ajax(
    //        {
    //            type: "POST",
    //            url: "frmMantTrabajador.aspx/CargarConceptos",
    //            data: "{'flag': '42'}",
    //            contentType: 'application/json; charset=utf-8',
    //            error: function (xhr, ajaxOtions, thrownError) {
    //                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
    //            },
    //            //trae os datos en formato JSON (data)
    //            success: function (data) {
    //                console.log(data.d);
    //                //table.clear().draw();
    //                addSelectEstadoTrabajador(data.d);
    //            }
    //        }
    //    )
    //}

    //CargarSelectEstadoTrabajador()
    //function addSelectEstadoTrabajador(data) {
    //    //DESCRIPCION : Funcion para llenar la lista de opciones del select de EstadoTrabajador
    //    for (var i = 0; i < data.length; i++) {
    //        estaTrabModal.append("<option value=" + data[i]["correlativo"] + ">" + data[i]["descripcion"] + "</option>");
    //    }
    //}

    /**********************************************************************FIN *****************************************************/

    /**********************************************************************INICIO CARGAR DATOS COMBOBOX DEL REGISTRO  *****************************************************/

    function CargarSelectTipoPersona() {
        //DESCRIPCION: Cargar Datos a la combobox TipoPersona
        $.ajax(
            {
                type: "POST",
                url: "frmMantTrabajador.aspx/CargarConceptos",
                data: "{'flag': '11'}",
                contentType: 'application/json; charset=utf-8',
                error: function (xhr, ajaxOtions, thrownError) {
                    console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
                },
                //trae os datos en formato JSON (data)
                success: function (data) {
                    console.log(data.d);
                    //table.clear().draw();
                    addSelectTipoPersona(data.d);
                }
            }
        )
    }

    CargarSelectTipoPersona()
    function addSelectTipoPersona(data) {
        //DESCRIPCION : Funcion para llenar la lista de opciones del select de TipoPersona
        for (var i = 0; i < data.length; i++) {
            tipoPersoModal.append("<option value=" + data[i]["correlativo"] + ">" + data[i]["descripcion"] + "</option>");
        }
    }

    function CargarSelectTipoDocumento() {
        //DESCRIPCION: Cargar Datos a la combobox TipoDocumento
        $.ajax(
            {
                type: "POST",
                url: "frmMantTrabajador.aspx/CargarConceptos",
                data: "{'flag': '2'}",
                contentType: 'application/json; charset=utf-8',
                error: function (xhr, ajaxOtions, thrownError) {
                    console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
                },
                //trae os datos en formato JSON (data)
                success: function (data) {
                    console.log(data.d);
                    //table.clear().draw();
                    addSelectTipoDocumento(data.d);
                }
            }
        )
    }

    CargarSelectTipoDocumento()
    function addSelectTipoDocumento(data) {
        //DESCRIPCION : Funcion para llenar la lista de opciones del select de TipoDocumento
        for (var i = 0; i < data.length; i++) {
            tipoDocModal.append("<option value=" + data[i]["correlativo"] + ">" + data[i]["descripcion"] + "</option>");
        }
    }

    function CargarSelectAsignacionFamiliar() {
        //DESCRIPCION: Cargar Datos a la combobox AsignacionFamiliar
        $.ajax(
            {
                type: "POST",
                url: "frmMantTrabajador.aspx/CargarConceptos",
                data: "{'flag': '40'}",
                contentType: 'application/json; charset=utf-8',
                error: function (xhr, ajaxOtions, thrownError) {
                    console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
                },
                //trae os datos en formato JSON (data)
                success: function (data) {
                    console.log(data.d);
                    //table.clear().draw();
                    addSelectAsignacionFamiliar(data.d);
                }
            }
        )
    }

    CargarSelectAsignacionFamiliar()
    function addSelectAsignacionFamiliar(data) {
        //DESCRIPCION : Funcion para llenar la lista de opciones del select de AsignacionFamiliar
        for (var i = 0; i < data.length; i++) {
            asifPersoModal.append("<option value=" + data[i]["correlativo"] + ">" + data[i]["descripcion"] + "</option>");
        }
    }

    function CargarSelectEstadoCivil() {
        //DESCRIPCION: Cargar Datos a la combobox estadoCivil
        $.ajax(
            {
                type: "POST",
                url: "frmMantTrabajador.aspx/CargarConceptos",
                data: "{'flag': '39'}",
                contentType: 'application/json; charset=utf-8',
                error: function (xhr, ajaxOtions, thrownError) {
                    console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
                },
                //trae os datos en formato JSON (data)
                success: function (data) {
                    console.log(data.d);
                    //table.clear().draw();
                    addSelectEstadoCivil(data.d);
                }
            }
        )
    }

    CargarSelectEstadoCivil()
    function addSelectEstadoCivil(data) {
        //DESCRIPCION : Funcion para llenar la lista de opciones del select de perfiles.
        for (var i = 0; i < data.length; i++) {
            estcPersoModal.append("<option value=" + data[i]["correlativo"] + ">" + data[i]["descripcion"] + "</option>");
        }
    }

    function CargarSelectArea() {
        //DESCRIPCION: Cargar Datos a la combobox Area
        $.ajax(
            {
                type: "POST",
                url: "frmMantTrabajador.aspx/CargarConceptos",
                data: "{'flag': '41'}",
                contentType: 'application/json; charset=utf-8',
                error: function (xhr, ajaxOtions, thrownError) {
                    console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
                },
                //trae os datos en formato JSON (data)
                success: function (data) {
                    console.log(data.d);
                    //table.clear().draw();
                    addSelectArea(data.d);
                }
            }
        )
    }

    CargarSelectArea()
    function addSelectArea(data) {
        //DESCRIPCION : Funcion para llenar la lista de opciones del select de Area
        for (var i = 0; i < data.length; i++) {
            areaTrabModal.append("<option value=" + data[i]["correlativo"] + ">" + data[i]["descripcion"] + "</option>");
        }
    }

    function CargarSelectTipoTrabajador() {
        //DESCRIPCION: Cargar Datos a la combobox TipoTrabajador
        $.ajax(
            {
                type: "POST",
                url: "frmMantTrabajador.aspx/CargarConceptos",
                data: "{'flag': '43'}",
                contentType: 'application/json; charset=utf-8',
                error: function (xhr, ajaxOtions, thrownError) {
                    console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
                },
                //trae os datos en formato JSON (data)
                success: function (data) {
                    console.log(data.d);
                    //table.clear().draw();
                    addSelectTipoTrabajador(data.d);
                }
            }
        )
    }

    CargarSelectTipoTrabajador()
    function addSelectTipoTrabajador(data) {
        //DESCRIPCION : Funcion para llenar la lista de opciones del select de TipoTrabajador
        for (var i = 0; i < data.length; i++) {
            tipoTrabModal.append("<option value=" + data[i]["correlativo"] + ">" + data[i]["descripcion"] + "</option>");
        }
    }

    function CargarSelectEstadoTrabajador() {
        //DESCRIPCION: Cargar Datos a la combobox EstadoTrabajador
        $.ajax(
            {
                type: "POST",
                url: "frmMantTrabajador.aspx/CargarConceptos",
                data: "{'flag': '42'}",
                contentType: 'application/json; charset=utf-8',
                error: function (xhr, ajaxOtions, thrownError) {
                    console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
                },
                //trae os datos en formato JSON (data)
                success: function (data) {
                    console.log(data.d);
                    //table.clear().draw();
                    addSelectEstadoTrabajador(data.d);
                }
            }
        )
    }

    CargarSelectEstadoTrabajador()
    function addSelectEstadoTrabajador(data) {
        //DESCRIPCION : Funcion para llenar la lista de opciones del select de EstadoTrabajador
        for (var i = 0; i < data.length; i++) {
            estaTrabModal.append("<option value=" + data[i]["correlativo"] + ">" + data[i]["descripcion"] + "</option>");
        }
    }

    function CargarSelectCargo() {
        //DESCRIPCION: Cargar Datos a la combobox Cargo
        $.ajax(
            {
                type: "POST",
                url: "frmMantTrabajador.aspx/CargarConceptos",
                data: "{'flag': '44'}",
                contentType: 'application/json; charset=utf-8',
                error: function (xhr, ajaxOtions, thrownError) {
                    console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
                },
                //trae os datos en formato JSON (data)
                success: function (data) {
                    console.log(data.d);
                    //table.clear().draw();
                    addSelectCargo(data.d);
                }
            }
        )
    }

    CargarSelectCargo()
    function addSelectCargo(data) {
        //DESCRIPCION : Funcion para llenar la lista de opciones del select de Cargo
        for (var i = 0; i < data.length; i++) {
            cargTrabModal.append("<option value=" + data[i]["correlativo"] + ">" + data[i]["descripcion"] + "</option>");
        }
    }

    function CargarSelectFormaPago() {
        //DESCRIPCION: Cargar Datos a la combobox FormaPago
        $.ajax(
            {
                type: "POST",
                url: "frmMantTrabajador.aspx/CargarConceptos",
                data: "{'flag': '45'}",
                contentType: 'application/json; charset=utf-8',
                error: function (xhr, ajaxOtions, thrownError) {
                    console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
                },
                //trae os datos en formato JSON (data)
                success: function (data) {
                    console.log(data.d);
                    //table.clear().draw();
                    addSelectFormaPago(data.d);
                }
            }
        )
    }

    CargarSelectFormaPago()
    function addSelectFormaPago(data) {
        //DESCRIPCION : Funcion para llenar la lista de opciones del select de FormaPago
        for (var i = 0; i < data.length; i++) {
            fpagTrabModal.append("<option value=" + data[i]["correlativo"] + ">" + data[i]["descripcion"] + "</option>");
        }
    }

    function CargarSelectTipoRegimen() {
        //DESCRIPCION: Cargar Datos a la combobox TipoRegimen
        $.ajax(
            {
                type: "POST",
                url: "frmMantTrabajador.aspx/CargarConceptos",
                data: "{'flag': '46'}",
                contentType: 'application/json; charset=utf-8',
                error: function (xhr, ajaxOtions, thrownError) {
                    console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
                },
                //trae os datos en formato JSON (data)
                success: function (data) {
                    console.log(data.d);
                    //table.clear().draw();
                    addSelectTipoRegimen(data.d);
                }
            }
        )
    }

    CargarSelectTipoRegimen()
    function addSelectTipoRegimen(data) {
        //DESCRIPCION : Funcion para llenar la lista de opciones del select de TipoRegimen
        for (var i = 0; i < data.length; i++) {
            tregTrabModal.append("<option value=" + data[i]["correlativo"] + ">" + data[i]["descripcion"] + "</option>");
        }
    }

    function CargarSelectRegimenPension() {
        //DESCRIPCION: Cargar Datos a la combobox RegimenPensionario
        $.ajax(
            {
                type: "POST",
                url: "frmMantTrabajador.aspx/CargarConceptos",
                data: "{'flag': '47'}",
                contentType: 'application/json; charset=utf-8',
                error: function (xhr, ajaxOtions, thrownError) {
                    console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
                },
                //trae os datos en formato JSON (data)
                success: function (data) {
                    console.log(data.d);
                    //table.clear().draw();
                    addSelectRegimenPension(data.d);
                }
            }
        )
    }

    CargarSelectRegimenPension()
    function addSelectRegimenPension(data) {
        //DESCRIPCION : Funcion para llenar la lista de opciones del select de RegimenPensionario
        for (var i = 0; i < data.length; i++) {
            rpenTrabModal.append("<option value=" + data[i]["correlativo"] + ">" + data[i]["descripcion"] + "</option>");
        }
    }

    function CargarSelectBancoRemuneracion() {
        //DESCRIPCION: Cargar Datos a la combobox BancoRemuneracion
        $.ajax(
            {
                type: "POST",
                url: "frmMantTrabajador.aspx/CargarConceptos",
                data: "{'flag': '48'}",
                contentType: 'application/json; charset=utf-8',
                error: function (xhr, ajaxOtions, thrownError) {
                    console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
                },
                //trae os datos en formato JSON (data)
                success: function (data) {
                    console.log(data.d);
                    //table.clear().draw();
                    addSelectBancoRemuneracion(data.d);
                }
            }
        )
    }

    CargarSelectBancoRemuneracion()
    function addSelectBancoRemuneracion(data) {
        //DESCRIPCION : Funcion para llenar la lista de opciones del select de BancoRemuneracion
        for (var i = 0; i < data.length; i++) {
            bremTrabModal.append("<option value=" + data[i]["correlativo"] + ">" + data[i]["descripcion"] + "</option>");
        }
    }

    function CargarSelectEstadoPlanilla() {
        //DESCRIPCION: Cargar Datos a la combobox EstadoPlanilla
        $.ajax(
            {
                type: "POST",
                url: "frmMantTrabajador.aspx/CargarConceptos",
                data: "{'flag': '49'}",
                contentType: 'application/json; charset=utf-8',
                error: function (xhr, ajaxOtions, thrownError) {
                    console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
                },
                //trae os datos en formato JSON (data)
                success: function (data) {
                    console.log(data.d);
                    //table.clear().draw();
                    addSelectEstadoPlanilla(data.d);
                }
            }
        )
    }

    CargarSelectEstadoPlanilla()
    function addSelectEstadoPlanilla(data) {
        //DESCRIPCION : Funcion para llenar la lista de opciones del select de EstadoPlanilla
        for (var i = 0; i < data.length; i++) {
            eplaTrabModal.append("<option value=" + data[i]["correlativo"] + ">" + data[i]["descripcion"] + "</option>");
        }
    }

    function CargarSelectModalidadContrato() {
        //DESCRIPCION: Cargar Datos a la combobox ModalidadContrato
        $.ajax(
            {
                type: "POST",
                url: "frmMantTrabajador.aspx/CargarConceptos",
                data: "{'flag': '50'}",
                contentType: 'application/json; charset=utf-8',
                error: function (xhr, ajaxOtions, thrownError) {
                    console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
                },
                //trae os datos en formato JSON (data)
                success: function (data) {
                    console.log(data.d);
                    //table.clear().draw();
                    addSelectModalidadContrato(data.d);
                }
            }
        )
    }

    CargarSelectModalidadContrato()
    function addSelectModalidadContrato(data) {
        //DESCRIPCION : Funcion para llenar la lista de opciones del select de ModalidadContrato
        for (var i = 0; i < data.length; i++) {
            modcTrabModal.append("<option value=" + data[i]["correlativo"] + ">" + data[i]["descripcion"] + "</option>");
        }
    }

    function CargarSelectPeriodo() {
        //DESCRIPCION: Cargar Datos a la combobox Periodo
        $.ajax(
            {
                type: "POST",
                url: "frmMantTrabajador.aspx/CargarConceptos",
                data: "{'flag': '51'}",
                contentType: 'application/json; charset=utf-8',
                error: function (xhr, ajaxOtions, thrownError) {
                    console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
                },
                //trae os datos en formato JSON (data)
                success: function (data) {
                    console.log(data.d);
                    //table.clear().draw();
                    addSelectPeriodo(data.d);
                }
            }
        )
    }

    CargarSelectPeriodo()
    function addSelectPeriodo(data) {
        //DESCRIPCION : Funcion para llenar la lista de opciones del select de Periodo
        for (var i = 0; i < data.length; i++) {
            periTrabModal.append("<option value=" + data[i]["correlativo"] + ">" + data[i]["descripcion"] + "</option>");
        }
    }

    /**********************************************************************FIN CARGAR DATOS COMBOBOX DEL REGISTRO *****************************************************/

    /*----------------------------------------------------------------------------Evento Autocompletar nombres/usuario---------------------------------------------------------------------------------------- */

    $("#id_lblNombres").keyup(function (event)
    //evento para capturar las las teclas que se van digitando en el input
    {
        var cad = $(this).val();
        buscarUsuarioNombre(cad);

    }
    );

    function buscarUsuarioNombre(cadena) {
        $("#id_lblNombres").autocomplete(
            //evento autocoplete de jquery para que me traiga las considencias
            {
                minLength: 2,
                //delay: 500,
                source:
                function (request, response) {
                    $.ajax(
                        {
                            type: "POST",
                            url: "frmMantUsuario.aspx/buscarUsuario",
                            data: "{'cadena': '" + cadena + "' }",
                            contentType: 'application/json; charset=utf-8',
                            error: function (xhr, ajaxOtions, thrownError) {
                                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
                            },
                            success: function (data) {
                                console.log(data);
                                response($.map(data.d, function (item) {
                                    var obj = new Object();
                                    obj.label = item.nombres;
                                    obj.value = item.nombres;
                                    obj.codUsuario = item.codUsuario;
                                    obj.numDoc = item.numDoc;
                                    return obj;
                                }
                                )
                                );
                            }
                        }
                    );
                },
                select: function (event, ui) {
                    //alert(ui.item.value);
                    $("#id_lblNumDoc").val(ui.item.numDoc);
                    codUsuarioSelect = ui.item.codUsuario

                }

            }
        );
    }

    /*----------------------------------------------------------------------------Termina evento Autocompletar nombres/usuario---------------------------------------------------------------------------------------- */

     /*---------------------------------------------------------------------------INICIO DE VALIDACION DE FECHAS EN REGISTRAR TRABAJADOR---------------------------------------------------------------------------------------- */

    $("#fecPer").datepicker(
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
            language: "es",
            minDate: '0D'//,
            //maxDate: '+30D'//,
            //yearRange: '-100',
        }
    );

    $("#irpeTrab").datepicker(
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
            language: "es",
            minDate: '0D'//,
            //maxDate: '+30D'//,
            //yearRange: '-100',
        }
    );

    $("#inicTrab").datepicker(
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
            language: "es",
            minDate: '0D'//,
            //maxDate: '+30D'//,
            //yearRange: '-100',
        }
    );

    $("#fincTrab").datepicker(
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
            language: "es",
            minDate: '0D'//,
            //maxDate: '+30D'//,
            //yearRange: '-100',
        }
    );

    $("#finiTrab").datepicker(
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
            language: "es",
            minDate: '0D'//,
            //maxDate: '+30D'//,
            //yearRange: '-100',

        }
    );

     /*----------------------------------------------------------------------------FINNNNNNN---------------------------------------------------------------------------------------- */

    /*----------------------------------------------------------------------------Validacion para mi filtro---------------------------------------------------------------------------------------- */

    //// se cae el sistema cuando borro el autocompleta , tengo que limpiar el codUser
    //btnBuscarFiltro.click(function () {
    //    var optionCodEstado = estado.find("option:selected");
    //    var valueSelectedEstado = optionCodEstado.val();

    //    if ((valueSelectedEstado == 0 || codUsuarioSelect == 0) && (valueSelectedEstado === undefined || codUsuarioSelect === undefined)) {

    //        CargarDatos(1, 0, 0);
    //    }

    //    if ((valueSelectedEstado === undefined || valueSelectedEstado == 0) && codUsuarioSelect != 0) {

    //        CargarDatos(2, 0, codUsuarioSelect)

    //    }
    //    else {
    //        //console.log(json)
    //        if (valueSelectedEstado != 0 && codUsuarioSelect === undefined) {

    //            CargarDatos(2, valueSelectedEstado, 0);
    //        }
    //    }
    //}
    //)

    /*----------------------------------------------------------------------------Termina validacion para mi filtro---------------------------------------------------------------------------------------- */

    /*----------------------------- Funcion Limpiar Campos----------------------------------------------------- */
    function limpiarCampos() {
        selectPerfilmodal.prop('selectedIndex', "");
        numDocModal.val("");


        estadoModal = $("#id_Estado");
        numDocModal = $("#dniPer");
        nomUsuarioModal = $("#nomUser");
        nomPersonaModal = $("#nomPer");
        telefonoModal = $("#telPer");
        celularModal = $("#celPer");
        selectSucurModal = $("#id_sucursal");
        pass = $("#pass");
    }

    /*--------------------------------Botan Agragar------------------------------------ */

    buttonModal.click(function () {
        //Mmensaje.css('display', 'none');

        exampleModalLabel_editar.css('display', 'none');
        exampleModalLabel_detalle.css('display', 'none');
        exampleModalLabel_agregar.css('display', 'block');
        //var tableBodyTR = $("#tbl_body_table tr");

        //var optionSelected = vendedores.find("option:selected");
        //var optionSelectedText = optionSelected.text();
        //var optionSelectedVal = optionSelected.val();
        //var codOrden;


        //Mvendedor.val(optionSelectedText);
        //McodVendedor.val(optionSelectedVal);
        //if (isNaN(tableBodyTR.last()[0].cells[0].innerText)) {

        //codOrden = 1;
        //} else {
        //codOrden = parseInt(tableBodyTR.last()[0].cells[0].innerText) + 1;
        //}

        //McodOrden.val(codOrden);
        //perfiles.prop('selectedIndex', "");
        //id_sucursal.prop('selectedIndex', "");
        //Mabreviatura.val("");
        //selectDias.val("");

        //limpiarCampos();
        numDocModal.prop("disabled", false);

        btnActivar.css("display", "none");
        btnBloquear.css("display", "none");
        btnActualizar.css("display", "none");
        //btnCancelar.css("margin-right", "90px");
        btnCancelar.css("display", "block")
            .css("float", "right");

        btnGuardar.css("display", "block")
            .css("float", "right");
        //.css("margin-top", "-34px")
        //.css("margin-left", "460px");

    });

    /* ***************************************************Guardar Informacion************************************************************************************ */


    btnGuardar.click(function () {

        var json = JSON.stringify({
             tipoPersona: tipoPersoModal.val(),
             tipoDocumento: tipoDocModal.val(),
             numeroDocumento: numDocModal.val(),
             nombres: nombPersoModal.val(),
             apellidoPaterno: apepPersoModal.val(),
             apellidoMaterno: apemPersoModal.val(),
             fechaNacimiento: fecnPersoModal.val(),
             estadoCivil: estcPersoModal.val(),
             direccion: direPersoModal.val(),
             correo: emaiPersoModal.val(),
             asignacionFamilia: asifPersoModal.val(),
             telefono: telePersoModal.val(),
             celular: celuPersoModal.val(),
             ruc: rucPersoModal.val(),
            
             area: areaTrabModal.val(),
             estadoTrabajador: areaTrabModal.val(),
             tipoTrabajador: tipoTrabModal.val(),
             cargo: estaTrabModal.val(),
             formaPago: cargTrabModal.val(),
             numeroCuenta: fpagTrabModal.val(),
             tipoRegimen: tregTrabModal.val(),
             regimenPensionario: rpenTrabModal.val(),
             inicioRegimen: irpeTrabModal.val(),
             bancoRemuneracion: bremTrabModal.val(),
             estadoPlanilla: eplaTrabModal.val(),
             modalidadContrato: modcTrabModal.val(),
             periodicidad: periTrabModal.val(),
             inicioContrato: inicTrabModal.val(),
             finContrato: fincTrabModal.val(),
             fechaIngreso: fingTrabModal.val(),
             sueldo: suelTrabModal.val()})

        console.log(json);

        $.ajax(
            {
                type: "POST",
                url: "frmMantTrabajador.aspx/registrarTrabajador",
                data: json,
                contentType: 'application/json; charset=utf-8',
                error: function (xhr, ajaxOtions, thrownError) {
                    console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
                },
                //trae os datos en formato JSON (data)
                success: function (data) {
                    console.log(data.d);

                    var flag = data.d

                    if (flag === 1) {
                        swal({
                            title: "MENSAJE REGISTRO",
                            text: "REGISTRO Existoso",
                            icon: "success",
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

                            dangerMode: false,

                        });
                    } else {
                        swal({
                            title: "MENSAJE REGISTRO",
                            text: "Error de registro",
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
                    }

                    
                }
            }
        )


      /*
        if (valuedniPer != "" && valuedniPer.length == 8) {
            if (valueSelectedPerfil > 0) {
                if (valuenomUser != "") {
                    if (valuePass != "") {
                        if (valueSelectedSucursal > 0) {
                            if (valueSelectedEstado > 0) {
                                if (valuenomPer != "") {
                                    if (valuetelPer != "" && valuedniPer.length == 9) {
                                        if (valuecelPer != "" && valuedniPer.length == 9) {
                                            RegistrarUsuario(json);
                                        } else {
                                            celularModal.attr("required", "required");
                                            msjAlert.removeAttr("hidden");
                                            msjAlert.html("<h5>Celular debe tener 9 dígitos</h5>");
                                            msjAlert.css('height', '30px');
                                            msjAlert.css("color", "#ffffff");
                                            msjAlert.css("background-color", "#EC340F")
                                                .css("border-color", "#2e6da4");
                                            setTimeout(function () {
                                                msjAlert.attr("hidden", true);
                                            }, 3000);
                                        }
                                    } else {
                                        celularModal.attr("required", "required");
                                        msjAlert.removeAttr("hidden");
                                        msjAlert.html("<h5>Teléfono debe tener 9 dígitos</h5>");
                                        msjAlert.css('height', '30px');
                                        msjAlert.css("color", "#ffffff");
                                        msjAlert.css("background-color", "#EC340F")
                                            .css("border-color", "#2e6da4");
                                        setTimeout(function () {
                                            msjAlert.attr("hidden", true);
                                        }, 3000);
                                    }
                                } else {
                                    nomPersonaModal.attr("required", "required");
                                }
                            } else {
                                estadoModal.attr("required", "required");
                            }
                        } else {
                            selectSucurModal.attr("required", "required");
                        }
                    } else {
                        msjAlert.removeAttr("hidden");
                        msjAlert.html("<h5>Debe dar clic en el botón generar contraseña aleatoria</h5>");
                        msjAlert.css('height', '50px');
                        msjAlert.css("color", "#ffffff");
                        msjAlert.css("background-color", "#EC340F")
                            .css("border-color", "#2e6da4");
                        setTimeout(function () {
                            msjAlert.attr("hidden", true);
                        }, 3000);
                    }
                } else {
                    nomPersonaModal.attr("required", "required");
                }
            } else {
                selectPerfilmodal.attr("required", "required");
            }
        } else {
            numDocModal.attr("required", "required");
            msjAlert.removeAttr("hidden");
            msjAlert.html("<h5>DNI debe tener 8 dígitos</h5>");
            msjAlert.css('height', '30px');
            msjAlert.css("color", "#ffffff");
            msjAlert.css("background-color", "#EC340F")
                .css("border-color", "#2e6da4");
            setTimeout(function () {
                msjAlert.attr("hidden", true);
            }, 3000);
            numDocModal.focus();
        }*/

    });

    /* ***************************************************Termina Guardar Informacion************************************************************************************ */

    /* listar filtros*/
    function CargarSelectPerfil() {
        //DESCRIPCION: Cargar Datos a la al combobox perfil
        $.ajax(
            {
                type: "POST",
                url: "frmMantUsuario.aspx/CargarPerfil",
                data: "{'flag': '42'}",
                contentType: 'application/json; charset=utf-8',
                error: function (xhr, ajaxOtions, thrownError) {
                    console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
                },
                //trae os datos en formato JSON (data)
                success: function (data) {
                    console.log(data.d);
                    //table.clear().draw();
                    addSelectPerfil(data.d);

                }
            }
        )
    }

    CargarSelectPerfil()
    function addSelectPerfil(data) {
        //DESCRIPCION : Funcion para llenar la lista de opciones del select de perfiles.
        for (var i = 0; i < data.length; i++) {
            selectPerfilmodal.append("<option value=" + data[i]["codPerfil"] + ">" + data[i]["despsnPerfil"] + "</option>");

        }

    }
});