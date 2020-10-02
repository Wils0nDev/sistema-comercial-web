$(document).ready(function () {
   
    var codUsuarioSelect;
/*---------------------- FILTROS--------------------------------*/ 

    var estado                  =      $("#idEstado");
    
   // var lblNumDoc               =      $("#id_lblNumDoc");
    var btnBuscarFiltro         =      $("#id_btnBuscar");
/*---------------------- MODAL--------------------------------*/ 
    var selectPerfilmodal       =      $("#Perfiles");
    var estadoModal             =      $("#id_Estado");
    var numDocModal             =       $("#dniPer");
    var nomUsuarioModal         =       $("#nomUser");
    var nomPersonaModal         =       $("#nomPer");
    var telefonoModal           =       $("#telPer");
    var celularModal            =       $("#celPer")

    var btnGuardar              =       $("#btnGuardar");
    var btnActualizar           =       $("#btnActualizar");
    var  btnActivar             =       $("#btnActivar");
    var  btnBloquear            =       $("#btnBloquear");
    var btnCancelar             =       $("#btnCancelar");
/*---------------------- MODAL--------------------------------*/ 

    var Mmensaje = $("#Mmensaje");
/*---------------------- TABLA--------------------------------*/ 
    var btnver                  =       '<button type="button" id="" class="icon-search btnSearch" data-toggle="modal"  data-target="#exampleModal"> </button>'
    var btnEditar               =       '<button type="button" title="Editar" class="icon-pencil btnEditar" data-toggle="modal"  data-target="#exampleModal"></button>'
    var btnEliminar             =       '<button type="button" id="" class="icon-cancel-circle btnCancel"  data-toggle="tooltip"></button>'
    
    var tableBody               =        $("#tbl_body_table");
 /*---------------------- TABLA--------------------------------*/ 
 
 
   /////////////////////////////////////////////////////////////////////////


    //Propiedades para el DataTable
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
                next : "Siguiente"
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
                "targets": [2,3,5,6,7,8,11,13,14]
            },
            {
                //"width": "12%",
                "targets": [0,1,4,9,10,12],
                "visible": false,
                "searchable": false
            }
            
            
        ]
    });




    //creo variables despues de que el DataTable este creado en el DOM.
    var tabla = $("#tbl_usuario").dataTable(); //funcion jquery
    var table = $("#tbl_usuario").DataTable(); //funcion DataTable-libreria
    table.columns.adjust().draw();
    /* ------------------------------------------------------------------------------*/



     //DESCRIPCION : Funcion que me crea el listado de usuario en el body del DataTable
    function addRowDT(data) {
    //DESCRIPCION : Funcion que me crea el listado de usuario en el body del DataTable
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
        $(".btnVer").click(function(){
            //$("#dniPer").prop('disabled',true);
           
        });
        
        // Boton Editar en la tabla
        $(".btnEditar").click(function () {
        Mmensaje.css('display', 'none');
        var tr =  $(this).parent().parent(); //obtengo el padre(td) del padre (tr) del boton
             //$("#dniPer").prop('disabled',false);     
              estadoModal.prop('selectedIndex', table.row(tr).data()[12]);
              selectPerfilmodal.prop('selectedIndex', table.row(tr).data()[10]);
              numDocModal.val(table.row(tr).data()[2]);  
              nomUsuarioModal.val(table.row(tr).data()[3]);
              nomPersonaModal.val(table.row(tr).data()[6]);
              telefonoModal.val(table.row(tr).data()[8]);
              celularModal.val(table.row(tr).data()[9]);
              //document.getElementById("#exampleModalLabel").style.display= "none";
              $("#h5_editar_Usuario").css("display","none");
             
             // btnActualizar.css("display", "block")
              //btnBloquear.css("display", "block") 
             //btnGuardar.css("display", "none");

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


    CargarDatos(1,0,0);

    //DESCRIPCION: Cargar Datos de la listar usuarios a la Tabla
    function CargarDatos(flagFiltro , codEstado, codUsuario) {
        //DESCRIPCION: Cargar Datos a la Tabla
        var json = JSON.stringify({
            flagFiltro: flagFiltro , 
            codEstado: codEstado, 
            codUsuario : codUsuario
        });
        console.log(json);
        $.ajax({
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
        })
    }
    

/* ---------------------------------------------------------------------------------- */

/* -----------------------Filtros----------------------------------------------------- */

        //DESCRIPCION : Funcion que me trae la lista de estados de la preventa
    function ListarEstado() {
        //DESCRIPCION : Funcion que me trae la lista de estados de la preventa
            $.ajax({
                type: "POST",
               //reutilizando webmetodo listar dias por tabla concepto para estadod de usuarios
                url: "frmMantUsuario.aspx/ListarEstado",
                //reutilizando webmetodo listar dias por tabla concepto para estadod de usuarios
                data: "{'flag': '24'}",
                contentType: 'application/json; charset=utf-8',
                error: function (xhr, ajaxOtions, thrownError) {
                    console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
                },
                success: function (data) {
                    addSelectEstado(data.d);
                    
                }
            });
        }
        ListarEstado();
        function addSelectEstado(data) {
        //DESCRIPCION : Funcion para llenar la lista de opciones del select del estado.
            for (var i = 0; i < data.length; i++) {
                estado.append("<option value=" + data[i]["correlativo"] + ">" + data[i]["descripcion"] + "</option>");
                estadoModal.append("<option value=" + data[i]["correlativo"] + ">" + data[i]["descripcion"] + "</option>");
            }
            
        }
        
    
        function CargarSelectPerfil() {
            //DESCRIPCION: Cargar Datos a la al combobox perfil
            $.ajax({
                type: "POST",
                url: "frmMantUsuario.aspx/CargarPerfil",
                data: "{'flag': '32'}" ,
                contentType: 'application/json; charset=utf-8',
                error: function (xhr, ajaxOtions, thrownError) {
                    console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
                },
                success: function (data) {
                    console.log(data.d);
                    //table.clear().draw();
                    addSelectPerfil(data.d);
                    
                }
            })
        }


        CargarSelectPerfil()

        function addSelectPerfil(data){
            //DESCRIPCION : Funcion para llenar la lista de opciones del select de perfiles.
            for (var i = 0; i < data.length; i++) {
                selectPerfilmodal.append("<option value=" + data[i]["codPerfil"] + ">" + data[i]["despsnPerfil"] + "</option>");
                
            }

        }
        

        $("#id_lblNombres").keyup(function(event) {
            var cad = $(this).val();
            buscarUsuarioNombre(cad);

        });

        function buscarUsuarioNombre(cadena){
            $("#id_lblNombres").autocomplete({
            minLength: 2,
            //delay: 500,
                source:
                    function (request, response) {
                        $.ajax({
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
                                }));
                            }

                        });
                    },
                    select: function (event, ui) {
                        //alert(ui.item.value);
                         $("#id_lblNumDoc").val(ui.item.numDoc);
                        codUsuarioSelect = ui.item.codUsuario
                    
                    }

            });
        }


        // se cae el sistema cuando borro el autocompleta , tengo que limpiar el codUser
        btnBuscarFiltro.click(function () {
            var optionCodEstado     = estado.find("option:selected");
            var valueSelectedEstado = optionCodEstado.val();

            if((valueSelectedEstado == 0 || codUsuarioSelect == 0)&&(valueSelectedEstado === undefined || codUsuarioSelect === undefined )){
               
                CargarDatos(1,0,0);
            }

            if((valueSelectedEstado  === undefined || valueSelectedEstado == 0) && codUsuarioSelect != 0){
               
                CargarDatos(2,0, codUsuarioSelect)
            
            }else{
                //console.log(json)
                
                if(valueSelectedEstado != 0 && codUsuarioSelect === undefined){
                    
                CargarDatos(2,valueSelectedEstado,0);
                }
            }
        })

});