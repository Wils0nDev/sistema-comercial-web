
$(document).ready(function () {

    let select = document.getElementById('selectPerfil');
    let selectPerfilEditar = document.getElementById('selectPerfilEditar');
    let btnSeleccionar = '<input type="checkbox" class="form-control">';
    let permisos = []



    /********  CARGAR PERFILES *************/

    function cargarPerfil() {
        fetch('frmMantPermisos.aspx/cargaPerfil', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json; Scharset=utf-8'
            },
            body: "{'flag':32}"
        })
            .then(response => response.json())
            .then(data => llenarPerfil(data.d))
            .catch(e => console.log(e));
    }

    function llenarPerfil(datos) {

        let data = Object.values(datos);

        for (let i = 0; i < data.length; i++) {
            let option = document.createElement('option');
            option.value = data[i].codPerfil;
            option.text = data[i].perfil;
            select.appendChild(option)
        }

        for (let i = 0; i < data.length; i++) {
            let option = document.createElement('option');
            option.value = data[i].codPerfil;
            option.text = data[i].perfil;
            selectPerfilEditar.appendChild(option)
        }
    }

    cargarPerfil();

    /**** llenado de tabla de permisos   ***/

    let tblPermisos = $("#tblPermisos");

    //Convertimos la tabla preventa en dataTable y le pasamos parametros
    tblPermisos.DataTable({
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
        order: [[0, "asc"]],
        columnDefs: [
            {
                "width": "45%",
                "targets": [3, 4]
            },
            {
                "width": "5%",
                "targets": [0]
            },
            {
                "width": "15%",
                "targets": [5]
            },
            {
                "targets": [1, 2, 5],
                "visible": false,
                "searchable": false
            },
            {
                "className": "text-center", "targets": [0, 3, 4]
            }
        ]
    });
    //creo variables despues de que el DataTable este creado en el DOM.
    var tabla = tblPermisos.dataTable(); //funcion jquery
    var table = tblPermisos.DataTable(); //funcion DataTable-libreria
    table.columns.adjust().draw();



    /*************** BUSQUEDA DE MANTENEDORES *********/

    var tblPermisos_filter_search_label = document.getElementById('tblPermisos_filter').firstChild;
    var tblPermisos_filter_search = tblPermisos_filter_search_label.lastChild;



    tblPermisos_filter_search.addEventListener('keyup', function () {
        let cad2 = $(this).val();
        console.log(cad2);
        if (cad2.length !== 0) {
            //limpiarDatosSeleccionProducto();
        } else {
            buscarMantenedorPorNombre(cad2);
        }
    });
    function buscarMantenedorPorNombre(cadena2) {
        //DESCRIPCION: Listas los mantenedores
        tblPermisos_filter_search.autocomplete({
            minLength: 2,
            source:
                function (request, response) {
                    $.ajax({
                        type: "POST",
                        url: "frmMantPermisos.aspx/DataMantenedoresNombre",
                        data: JSON.stringify({ nombre: cadena2 }),
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

        });
    }





    function listarMantenedores() {
        fetch('frmMantPermisos.aspx/DataMenus', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json; Scharset=utf-8'
            }
        })
            .then(response => response.json())
            .then(data => {
                console.log(data);
                table.clear().draw();
                llenarTabla(data.d);
            })
            .catch(e => console.log(e));
    }

    function listarMantenedoresPorPerfil() {
        let perfil = selectPerfilEditar.value
        console.log("codPerfil: " + perfil)
        fetch('frmMantPermisos.aspx/DataMenusPorPerfil', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json; Scharset=utf-8'
            },
            body: JSON.stringify({ perfil: perfil })
        })
            .then(response => response.json())
            .then(data => {
                console.log(data);
                table.clear().draw();
                llenarTabla(data.d);
            })
            .catch(e => console.log(e));
    }

    function llenarTabla(data) {

        //DECRIPCION: Llenar la tabla de permisos
        var botones = btnSeleccionar;
        for (var i = 0; i < data.length; i++) {
            tabla.fnAddData([
                i,
                data[i].codigoModulo,     //codigo de modulo
                data[i].codigoSubMenu,    //codigo de menu
                data[i].nomSubMenu,       //nombre de menu
                data[i].nomModulo,        //nombre de modulo
                data[i].codPermisoFK,       //codigo de opearacion
                botones]);
        }


    }

    /****     FUNCION PARA EDITAR LOS PERMISOS            **/

    function validarDataEditar() {

        $("input:checkbox:checked").each(function () {
            let tr = $(this).parent().parent();
            console.log("codigo de operacion" + table.row(tr).data()[5]);

            seleccion = { codPermiso: table.row(tr).data()[5] }
            permisos.push(seleccion);
        });
        console.log(JSON.stringify(permisos))

        if (permisos.length == 0) {
            swal({
                title: "ADVERTENCIA",
                text: "Debe elegir los permisos que desea quitar",
                icon: "warning",
                buttons: true,
                dangerMode: true,
            });
        } else {

            editarPermisos(permisos);

        }

    }

    function editarPermisos(permisos) {
        fetch('frmMantPermisos.aspx/actualizarPermisos', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json; Scharset=utf-8'
            },
            body: JSON.stringify({ 'permisos': permisos })
        }).then(response => response.json())
            .then(data => {
                console.log(data.d);
                if (data.d == -1) {
                    swal({
                        title: "EXITO",
                        text: "Se quitaron todos los permisos ",
                        icon: "success",
                        buttons: true,
                    });
                    listarMantenedoresPorPerfil()
                } else {
                    swal({
                        title: "ERROR",
                        text: "No se pudo quitar los permisos",
                        icon: "warning",
                        buttons: true,
                        dangerMode: true,
                    });
                }


            })
            .catch(e => console.log(e))
    }


    /**********  AGREGAR NUEVOS PERMISOS ********** */

    function validarData() {

        if (select.value == 0) {
            swal({
                title: "ADVERTENCIA",
                text: "Debe elegir el perfil al que agregara el permiso ",
                icon: "warning",
                buttons: true,
                dangerMode: true,
            });
        } else {

            $("input:checkbox:checked").each(function () {
                let tr = $(this).parent().parent();
                console.log("cod de responsable" + select.value);
                console.log("codigo de menu" + table.row(tr).data()[2]);
                //cod menu                           //codResponsable                //opcion                            
                seleccion = { codPermiso: table.row(tr).data()[2], codResponsable: select.value, opcion: 1 }
                console.log(seleccion);
                permisos.push(seleccion);
            });

            if (permisos.length == 0) {
                swal({
                    title: "ADVERTENCIA",
                    text: "Debe elegir los permisos que desea registrar",
                    icon: "warning",
                    buttons: true,
                    dangerMode: true,
                });
            } else {

                guardarDatos(permisos);
                $("input:checkbox").each(function () {
                    $("input:checkbox").prop('checked', false);
                });

                console.log("ejecucion correcta: " + JSON.stringify(permisos));

            }



        }


    }


    function guardarDatos(permisos) {
        fetch('frmMantPermisos.aspx/InsertarPermisos', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json; Scharset=utf-8'
            },
            body: JSON.stringify({ 'permisos': permisos })
        }).then(response => response.json())
            .then(data => {
                console.log(data.d);
                if (data.d == -1) {
                    swal({
                        title: "EXITO",
                        text: "Se agregaron todos los permisos ",
                        icon: "success",
                        buttons: true,
                    });
                } else {
                    swal({
                        title: "ERROR",
                        text: "No se pudo agregar los permisos",
                        icon: "warning",
                        buttons: true,
                        dangerMode: true,
                    });
                }


            })
            .catch(e => console.log(e))
    }





    document.getElementById('selectPerfilEditar').addEventListener('change', listarMantenedoresPorPerfil);

    /****  evento de botones guardar y editar ***/
    document.getElementById('btnGuardar').addEventListener('click', validarData);
    document.getElementById('btnEditar').addEventListener('click', validarDataEditar);

    /*** eventos para limpiar a tabla cuando se cambia de tab **/
    document.getElementById('tab_guardar').addEventListener('click', listarMantenedores);
    document.getElementById('tab_editar').addEventListener('click', () => { table.clear().draw() });

    console.log(localStorage.getItem('user'));
    listarMantenedores();
});