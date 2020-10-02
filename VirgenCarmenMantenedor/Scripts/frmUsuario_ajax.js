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
    /*---------------------- MODAL--------------------------------*/
    var selectPerfilmodal = $("#Perfiles");
    var estadoModal = $("#id_Estado");
    var numDocModal = $("#dniPer");
    var nomUsuarioModal = $("#nomUser");
    var nomPersonaModal = $("#nomPer");
    var telefonoModal = $("#telPer");
    var celularModal = $("#celPer");
    var selectSucurModal = $("#id_sucursal");
    var pass = $("#pass");
    /**********Button*******/
    var btnGuardar = $("#btnGuardar");
    var btnActualizar = $("#btnActualizar");
    var btnActivar = $("#btnActivar");
    var btnBloquear = $("#btnBloquear");
    var btnCancelar = $("#btnCancelar");

    var buttonModal = $("#buttonModal") // btnAgregar
    var btnGeneraPass = $("#btnGeneraPass");

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
        /* buttons: [
             {
                 extend: 'excelHtml5',
                 text: '<span class="icon-file-excel"></span>',
                 titleAttr: 'Excel',
                 title: 'Rutas Asignadas al Vendedor',
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
                     columns: [0, 1, 2,3, 4]
                 }
             }],
         */
        //Para que el DataTable no me muestre ciertas Columnas.
        columnDefs: [
            {
                //"width": "2%",
                "targets": [2, 3, 5, 6, 7, 8, 11, 13, 14]
            },
            {
                //"width": "12%",
                "targets": [0, 1, 4, 9, 10, 12],
                "visible": false,
                "searchable": false
            }


        ]
    });
    /* ----------------------------------------------------------------Termina propiedades para el DataTable--------------------------------------------------------*/


    /* ---------------------------------------------------------------------------------------------------------------------------------------*/
    //creo variables despues de que el DataTable este creado en el DOM.
    var tabla = $("#tbl_usuario").dataTable(); //funcion jquery
    var table = $("#tbl_usuario").DataTable(); //funcion DataTable-libreria
    table.columns.adjust().draw();
    /* -----------------------------------------------------------------------------------------------------------------------------------------------------*/


    /* ----------------------------------------------------------------Trama cargar datos de los datos en la tabla,parametros apra mi filtros y botones ver, editar y eliminar--------------------------------------------------------*/

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

            // btnActualizar.css("display", "block")
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

    /* ----------------------------------------------------------------Termina trama cargar datos de los datos en la tabla,parametros apra mi filtros y botones ver, editar y eliminar--------------------------------------------------------*/


    /* ---------------------------------------------------------------------Tramas para cargar datos en comboxSelect----------------------------------------------------- */


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
            estadoModal.append("<option value=" + data[i]["correlativo"] + ">" + data[i]["descripcion"] + "</option>");
        }

    }
    /**********************************************************************termino listar estador de usuario *****************************************************/


    function CargarSelectPerfil() {
        //DESCRIPCION: Cargar Datos a la al combobox perfil
        $.ajax(
            {
                type: "POST",
                url: "frmMantUsuario.aspx/CargarPerfil",
                data: "{'flag': '32'}",
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
    /**********************************************************************termino listar perfiles de usuario*****************************************************/



    function cargarSelectSucursal()
    //DESCRIPCION : Funcion que me trae la lista las sucursales
    {
        $.ajax({
            type: "POST",
            url: "frmMantUsuario.aspx/cargarSucursal",
            data: "{'flag' : '18'}",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                console.log(data.d);
                addSelectSucursal(data.d);
            }

        })
    }

    cargarSelectSucursal();

    function addSelectSucursal(data) {
        //DESCRIPCION : Funcion para llenar la lista de opciones del select de de sucursales.
        for (var i = 0; i < data.length; i++) {
            selectSucurModal.append("<option value=" + data[i]["ntraSucursal"] + ">" + data[i]["descripcion"] + "</option>");

        }
    }
    /**********************************************************************termino listar sucursales*****************************************************/
    /* ---------------------------------------------------------------------Termino Tramas para cargar datos en comboxSelect----------------------------------------------------- */

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


    /*----------------------------------------------------------------------------Validacion para mi filtro---------------------------------------------------------------------------------------- */

    // se cae el sistema cuando borro el autocompleta , tengo que limpiar el codUser
    btnBuscarFiltro.click(function () {
        var optionCodEstado = estado.find("option:selected");
        var valueSelectedEstado = optionCodEstado.val();

        if ((valueSelectedEstado == 0 || codUsuarioSelect == 0) && (valueSelectedEstado === undefined || codUsuarioSelect === undefined)) {

            CargarDatos(1, 0, 0);
        }

        if ((valueSelectedEstado === undefined || valueSelectedEstado == 0) && codUsuarioSelect != 0) {

            CargarDatos(2, 0, codUsuarioSelect)

        }
        else {
            //console.log(json)
            if (valueSelectedEstado != 0 && codUsuarioSelect === undefined) {

                CargarDatos(2, valueSelectedEstado, 0);
            }
        }
    }
    )

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

        limpiarCampos();
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



    /****************************************************Generar Contrseña *********************************************************************** */

    /////////////////////////////////////GENERACIÓN CONTRASEÑA - INICIO//////////////////////////////////

    var tamanyo_password = 15;			// definimos el tamaño que tendrá nuestro password

    var caracteres_conseguidos = 0;			// contador de los caracteres que hemos conseguido
    var caracter_temporal = '';
    var array_caracteres = new Array();// array para guardar los caracteres de forma temporal


    for (var i = 0; i < tamanyo_password; i++) {		// inicializamos el array con el valor null
        array_caracteres[i] = null;
    }

    var password_definitivo = '';

    // función que genera un número aleatorio entre los límites superior e inferior pasados por parámetro
    function genera_aleatorio(i_numero_inferior, i_numero_superior) {
        var i_aleatorio = Math.floor((Math.random() * (i_numero_superior - i_numero_inferior + 1)) + i_numero_inferior);
        return i_aleatorio;
    }


    // función que genera un tipo de caracter en base al tipo que se le pasa por parámetro (mayúscula, minúscula, número, símbolo o aleatorio)
    function genera_caracter(tipo_de_caracter) {
        // hemos creado una lista de caracteres específica, que además no tiene algunos caracteres como la "i" mayúscula ni la "l" minúscula para evitar errores de transcripción
        var lista_de_caracteres = '$+=?@_23456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnpqrstuvwxyz';
        var caracter_generado = '';
        var valor_inferior = 0;
        var valor_superior = 0;

        switch (tipo_de_caracter) {
            case 'minúscula':
                valor_inferior = 38;
                valor_superior = 61;
                break;
            case 'mayúscula':
                valor_inferior = 14;
                valor_superior = 37;
                break;
            case 'número':
                valor_inferior = 6;
                valor_superior = 13;
                break;
            case 'símbolo':
                valor_inferior = 0;
                valor_superior = 5;
                break;
            case 'aleatorio':
                valor_inferior = 0;
                valor_superior = 61;

        } // fin del switch

        caracter_generado = lista_de_caracteres.charAt(genera_aleatorio(valor_inferior, valor_superior));
        return caracter_generado;
    } // fin de la función genera_caracter()
    ////////////////////////////////////termina contrasea de inicio/////////////////////////////////////////////////

    // función que guarda en una posición vacía aleatoria el caracter pasado por parámetro
    function guarda_caracter_en_posicion_aleatoria(caracter_pasado_por_parametro) {
        var guardado_en_posicion_vacia = false;
        var posicion_en_array = 0;

        while (guardado_en_posicion_vacia != true) {
            posicion_en_array = genera_aleatorio(0, tamanyo_password - 1);	// generamos un aleatorio en el rango del tamaño del password

            // el array ha sido inicializado con null en sus posiciones. Si es una posición vacía, guardamos el caracter
            if (array_caracteres[posicion_en_array] == null) {
                array_caracteres[posicion_en_array] = caracter_pasado_por_parametro;
                guardado_en_posicion_vacia = true;
            }
        }
    }


    // función que se inicia una vez que la página se ha cargado
    function generar_contrasenya() {

        caracteres_conseguidos = 0;			// contador de los caracteres que hemos conseguido
        caracter_temporal = '';

        array_caracteres = new Array();// array para guardar los caracteres de forma temporal

        for (var i = 0; i < tamanyo_password; i++) {		// inicializamos el array con el valor null
            array_caracteres[i] = null;
        }

        password_definitivo = '';

        // generamos los distintos tipos de caracteres y los metemos en un password_temporal
        caracter_temporal = genera_caracter('minúscula');
        guarda_caracter_en_posicion_aleatoria(caracter_temporal);
        caracteres_conseguidos++;

        caracter_temporal = genera_caracter('mayúscula');
        guarda_caracter_en_posicion_aleatoria(caracter_temporal);
        caracteres_conseguidos++;

        caracter_temporal = genera_caracter('número');
        guarda_caracter_en_posicion_aleatoria(caracter_temporal);
        caracteres_conseguidos++;

        caracter_temporal = genera_caracter('símbolo');
        guarda_caracter_en_posicion_aleatoria(caracter_temporal);
        caracteres_conseguidos++;

        // si no hemos generado todos los caracteres que necesitamos, de forma aleatoria añadimos los que nos falten
        // hasta llegar al tamaño de password que nos interesa
        while (caracteres_conseguidos < tamanyo_password) {
            caracter_temporal = genera_caracter('aleatorio');
            guarda_caracter_en_posicion_aleatoria(caracter_temporal);
            caracteres_conseguidos++;
        }

        // ahora pasamos el contenido del array a la variable password_definitivo
        for (var i = 0; i < array_caracteres.length; i++) {
            password_definitivo = password_definitivo + array_caracteres[i];
        }

        return password_definitivo;
    }

    //GENERACIÓN CONTRASEÑA - FIN
    btnGeneraPass.click(function () {
        $("#pass").val(generar_contrasenya());
    });


    /**************************************************** Termina Generar Contrseña *********************************************************************** */

    /* ***************************************************Guardar Informacion************************************************************************************ */
    btnGuardar.click(function () {
        var valuedniPer = numDocModal.val();
        var optionSelectedPerfil = selectPerfilmodal.find("option:selected");
        var valueSelectedPerfil = optionSelectedPerfil.val();
        var valuenomUser = nomUsuarioModal.val();
        var valuePass = pass.val();
        var optionSelectedSucursal = selectSucurModal.find("option:selected");
        var valueSelectedSucursal = optionSelectedSucursal.val();

        var optionSelectedEstado = estadoModal.find("option:selected");
        var valueSelectedEstado = optionSelectedEstado.val();
        var valuenomPer = nomPersonaModal.val();
        var valuetelPer = telefonoModal.val();
        var valuecelPer = celularModal.val();
        /*var json = JSON.stringify({
            usuario: {
                nomUsuario: nomUser,
                estado: valueSelectedEstado,
                desPerfil: ,
                desSucursal: ,
                codPerfil: valueSelectedPerfil,
                codSucursal: valueSelectedSucursal,
                codPersona: valuedniPer,
                telefono: valuetelPer,
                celular: valuecelPer
            }
            });*/

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
        }

    });
    /* ***************************************************Termina Guardar Informacion************************************************************************************ */


});