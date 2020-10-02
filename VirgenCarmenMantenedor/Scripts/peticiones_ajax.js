
$(document).ready(function () {


    //Lista de Variables
    var vendedores = $("#vendedores");
    var selectRutas = $("#rutas");
    var Mabreviatura = $("#Mabreviatura");
    var McodVendedorVal = $("#McodVendedor");
    var Mvendedor = $("#Mvendedor");
    var selectDias = $("#dias");
    var btnGuardar = $("#btnGuardar");
    var Mmensaje = $("#Mmensaje");
    var Mpmensaje = $("#Mpmensaje");
    var btnActualizar = $("#btnActualizar");
    var btnEditar = '<button type="button" title="Editar" class="icon-pencil btnEditar" data-toggle="modal"  data-target="#exampleModal" ></button>'
    var btnEliminar = ' <button type="button" id="" class="icon-bin btnDelete" data-toggle="tooltip"  title="Eliminar" ></button>'
    var btnCancelar = $("#btnCancelar");
    var tableBody = $("#tbl_body_table");
    var buttonModal = $("#buttonModal");
    var McodOrden = $("#McodOrden");
    var MRutaAnterior = $("#MRutaAnterior");
    var MmensajeOrden = $('#MmensajeOrden');
    /////////////////////////////////////////
    
    
    //Propiedades para el DataTable
    $('#tb_rutasAsignadas').DataTable({
        paging: false,
        ordering: false,
        info: false,
        language: {
            lengthMenu: "Mostrar _MENU_ registros",
           zeroRecords: "No hay registros",
            info: "Mostrando la página _PAGE_ de _PAGES_",
            infoEmpty: "No hay registros disponibles.",
            infoFiltered: "(filtered from _MAX_ total records)",
            search: "Busqueda rapida: ",
           /* paginate: {
                previous: "Atras",
                next : "Siguiente"
            }*/
        },
       dom: 'lBfrtip',
        buttons: [
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
      //Para que el DataTable no me muestre ciertas Columnas.
        columnDefs: [
            {
                "width": "2%",
                "targets": [0]
            },
            {
                "width": "12%",
                "targets": [1]
            },
            {   
                "width": "11%",
                "targets": [2]
            },
          
            {
                "width": "5%",
                "targets": [4,8]
            },
            {
                "width": "50%",
                "targets": [3]
            },
           {
                "targets": [5],
                "visible": false,
                "searchable": false
            },
            {
                "targets": [6],
                "visible": false,
                "searchable": false
           },
            {
               "targets": [7],
               "visible": false,
               "searchable": false
           }
        ]
    });
    //creo variables despues de que el DataTable este creado en el DOM.
    var tabla = $("#tb_rutasAsignadas").dataTable(); //funcion jquery
    var table = $("#tb_rutasAsignadas").DataTable(); //funcion DataTable-libreria
    table.columns.adjust().draw();

    function addRowDT(data) {
       
    //DESCRIPCION : Funcion que me crea el listado de rutas en el body del DataTable
        for (var i = 0; i < data.length; i++) {
            tabla.fnAddData([
                data[i].ORDEN,
                data[i].ABREVIATURA,
                data[i].VENDEDOR,
                data[i].RUTA,
                data[i].DIA,
                data[i].ntraRutas,
                data[i].ntraUsuario,
                data[i].correlativo,
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
        $(".btnEditar").click(function () {
            Mmensaje.css('display', 'none');
           var tr =  $(this).parent().parent(); //obtengo el padre(td) del padre (tr) del boton 
            //table.row(tr).data()[6] -> me optiene la data de la fila y columna(6) selecciona
            McodVendedorVal.val(table.row(tr).data()[6]);
            Mvendedor.val(table.row(tr).data()[2]);
            MRutaAnterior.val(table.row(tr).data()[5]);
            selectRutas.prop('selectedIndex', table.row(tr).data()[5]);
            Mabreviatura.val(table.row(tr).data()[1]);
            selectDias.prop('selectedIndex', table.row(tr).data()[7]);
            btnGuardar.css("display", "none");
            btnCancelar.css("margin-right", "90px");
            btnActualizar.css("display", "block")
                .css("margin-top", "-34px")
                .css("margin-left", "460px");
            
            
        });
        //Evento clcick para Eliminar una ruta, Hago el llamado de
        //ElimiarRutasAsignadas y envio los parametros segun la confirmacion del modal
        //Ejecuta libreria sweet alert
        $(".btnDelete").click(function () {
            //Obtengo los valores de mi tr a donde se le hizo el click en el boton eliminar
            var tr = $(this).parent().parent();
            //Obtengo la data de la columna 5 y 6 del tr a donde se le hizo el click en el boton eliminar
            var codUsuarioT = table.row(tr).data()[6];
            var coodRutaT = table.row(tr).data()[5];
            ///////////
            //obtengo la posicion del tr a donde se le hizo el click en el boton eliminar
            var posicion = tr[0].sectionRowIndex;
            //obtengo la cantidad de filas de la tabla
            var cantidadFilas = parseInt(table.rows().count());
            
           // var restantes = parseInt(cantidadFilas - Orden)
            
            
            swal({
                title: "Se eliminara el registro",
                text: "¿Esta seguro que desea eliminar el registro?",
                icon: "warning",
                buttons: {
                   
                    cancel: {
                        text: "Cancelar",
                        visible: true,
                    },
                    confirm: {
                        text: "Aceptar",
                        visible: true,
                    },
                },
               
                dangerMode: true,

                
                
            })
            //Promesa que me trae el valor true al confirmar OK.
                .then((willDelete) => {
                    if (willDelete) {
                        ElimiarRutasAsignadas(codUsuarioT, coodRutaT)
                        swal("Se elimino Registro", {
                            icon: "success",
                        });
                        //envio la posicion y la cantidad de filas para poder restar el orden y ajustar el nuevo body de la tabla
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
        //console.log(tr)
        VistaAnterior(tr);  
        
    } 
    //Restar Orden al Eliminar
    function RestarOrden(posicion, cantidadFilas) {
        //obtengo el tr donde se hizo el click (tr = fila completa)
        var tr = $(".btnDelete").parent().parent();
        //Parseo el dato del orden a entero COLUMNA(ORDEN) del tr donde se hizo click
        var OrdenSelec = parseInt(tr[posicion].cells[0].innerText);
        //resto la cantidad de filas - el orden parseado
        var restantes = cantidadFilas - OrdenSelec;
        var cont = 1;
        var BodyActual = $("#tbl_body_table tr");
        var jsonCodOrdenUpdate = new Array();
       
        for (var i = 1; i <= restantes; i++) {
            var newposicion = parseInt(tr[posicion + i].cells[0].innerText) - cont;
            tr[posicion + i].cells[0].innerText = newposicion.toString();
            var newCodOrden = tr[posicion + i].cells[0].innerText;
            jsonCodOrdenUpdate.push
                (

                {
                        codUsuario: table.row(BodyActual[posicion + i]).data()[6],
                        codOrden: parseInt(newCodOrden),
                        codRuta: table.row(BodyActual[posicion + i]).data()[5]
                }
                );
        }
        console.log(jsonCodOrdenUpdate);
        ActualizarOrdenRutas(jsonCodOrdenUpdate);
    }
    function SeleccionarVendedor() {
    //DESCRICION : Funcion que me obtiene la lista de rutas asignadas segun el vendedor seleccionado.
        vendedores.change(function () {
            var optionSelected = $(this).find("option:selected");
            var valueSelected = optionSelected.val();

            $.ajax({
                type: "POST",
                url: "frmRutasAsignadas.aspx/ListarRutasAsignadas",
                data: "{'codUsuario':" + valueSelected + "}",
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

        });
    }
    SeleccionarVendedor();
   

    function addSelectVendedor(data) {
    //DESCRIPCION : Funcion para llenar la lista de opciones del select del Vendedor.
        for (var i = 0; i < data.length; i++) {
            vendedores.append("<option value=" + data[i]["ntraUsuario"] + ">" + data[i]["vendedor"] + "</option>");
        }

    }
    //LLAMANDO A LA FUNCIO NDE AJAX VENDEDORES
    function ListarVendedores() {
     //DESCRIPCION : Funcion que me trae la lista de vendedores
        $.ajax({
            type: "POST",
            url: "frmRutasAsignadas.aspx/ListarVendedores",
            data: "{'flag': '1' }",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
               console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                addSelectVendedor(data.d);
            }
        })

    }
    ListarVendedores();
   
    function addSelectRutas(data) {
    //DESCRIPCION : Funcion que me crea las opciones en el select con la las lista de rutas.
        var arrayAbreviaura = new Array();
        for (var i = 0; i < data.length; i++) {
            selectRutas.append("<option value=" + data[i]["ntraRutas"] + ">" + data[i]["descripcion"] + "</option>");
            //Hago el llenado en un array las abreviaturas obtenidas.
            arrayAbreviaura.push(data[i]["pseudonimo"]);
            
            
        }
        //Envio el array a la funcion que interactura con el array.
        searchAbreviatura(arrayAbreviaura)

    }

    function searchAbreviatura(data) {
    //DESCRIPCION : Funcion que obtiene la abreviatura de la ruta seleccionada, 
    //sin tener que ir a consultar a bd,lo busca en un array creado.
        $("#rutas").change(function () {

            var optionSelected = $(this).find("option:selected");
            var valueSelected = optionSelected.val();
            var valueSelectedText = optionSelected.text();

            var existe = data[valueSelected - 1];
            Mabreviatura.val(existe);
        });
    } 

    function ListarRutas() {
    //DESCRIPCION : Funcion que me trae la lista de rutas.
        $.ajax({
            type: "POST",
            url: "frmRutasAsignadas.aspx/ListarRutas",
            data: "{'flag': '3' }",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                addSelectRutas(data.d);
             }
        });

    }
    ListarRutas();
    function addSelectDias(data) {
    //DESCRIPCION : Funcion que me crea las opciones en el select con la las lista de dias.
        for (var i = 0; i < data.length; i++) {
            selectDias.append("<option value=" + data[i]["correlativo"] + ">" + data[i]["descripcion"] + "</option>");

        }
    }
    function ListarDias() {
     //DESCRIPCION : Funcion que me obtiene la lista de manera asincrona los Dias.
        $.ajax({
            type: "POST",
            url: "frmRutasAsignadas.aspx/ListarDias",
            data: "{'flag': '4' }",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                //envio los datos a addSelectDias
                addSelectDias(data.d);
                

            }
        })
    }
    ListarDias();
    function ActualizarTabla(codUsuario) { 
    //Descriocion : Funcion que me actualiza la tabla despues de un evento INSERT, UPDATE, DELETE

            $.ajax({
                type: "POST",
                url: "frmRutasAsignadas.aspx/ListarRutasAsignadas",
                data: "{'codUsuario':" + codUsuario + "}",
                contentType: 'application/json; charset=utf-8',
                error: function (xhr, ajaxOtions, thrownError) {
                    console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
                },
                success: function (data) { 
                    table.clear().draw();
                    addRowDT(data.d);
                }
            });

    }
    
    function InsertarRutasAsignadas(data,codUsuario) {
    //Descricion : Recibo los parametros del evento click del GuardadoDeDatosModal
     //los envio por Ajax 
        $.ajax({
            type: "POST",
            url: "frmRutasAsignadas.aspx/InsertarRutasAsignadas",
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
                    ActualizarTabla(codUsuario); 

                    //Obtengo el codOrden y le sumo + 1 para obtener el siguiente orden.//
                    McodOrden.val(""); // Limpio el valor codOrden
                    var dataJson = jQuery.parseJSON(data);
                    var codOrden = parseInt(dataJson.codOrden, Number) + 1;
                    McodOrden.val(codOrden)
                    //////////////////////////////////////////////////////////7
                } else {        
                    
                    
                    var arrayVendedores = vendedores.find("option");
                    
                    for (var i = 0; i < arrayVendedores.length; i++) {
                        if (parseInt(arrayVendedores[i].value) === response.d) {                        
                       var  nombreVendedor = arrayVendedores[i].text;
                    }
                    }
                    //var nombreVendedor  = arrayVendedores[response.d].text;
                    
                    Mpmensaje.css("color", "rgba(179, 10, 10, 0.69)");
                    Mmensaje.css("background-color", "rgba(255, 0, 0, 0.51)")
                        .css("border-color", "rgb(203, 46, 46)");
                    Mpmensaje.html("La ruta ya esta  asignada al vendedor " + nombreVendedor);
                    Mmensaje.css("display", "block");
                    
                }
                
            }
        });
    }

    function GurdarDatosModal() {
     //DESCRIPCION : Esta funcion me dispara un evento click,
    // para hacer el guardado de datos, Llamando a la funcion InsertarRutasAsignadas
        btnGuardar.click(function () {
            //obtengo los valores del modal
            var optionSelectedDia = selectDias.find("option:selected");
            var valueSelectedDia = optionSelectedDia.val();
            var McodOrdenValue = McodOrden.val();
            var opitionSelectedRuta = selectRutas.find("option:selected");
            var valueSelectedRuta = opitionSelectedRuta.val();
            var json = JSON.stringify({ codUsuario: McodVendedorVal.val(), codRuta: valueSelectedRuta, codOrden: McodOrdenValue, diaSemana: valueSelectedDia });

            if (valueSelectedRuta > 0) {

                if (valueSelectedDia > 0) {
                    //Envio los valores del modal en un json y el codVendedor.
                    InsertarRutasAsignadas(json, McodVendedorVal.val());
                } else {
                    selectDias.attr("required", "required");
                }

            } else {
                selectRutas.attr("required", "required");
            }

        });
    }

    GurdarDatosModal();
    
    function ActualizarRutaDelVendedor() {
    //DESCRIPCION : Funcion que me ejecuta el evento click del boton Editar.
    //evento ejecuta la actualizacion de ruta al llamar a ActualizarRutasAsignadas
        btnActualizar.click(function () {

            var optionSelectedDia = selectDias.find("option:selected");
            var valueSelectedDia = optionSelectedDia.val();

            var opitionSelectedRuta = selectRutas.find("option:selected");
            var valueSelectedRuta = opitionSelectedRuta.val();
            var valueCodVendedor = McodVendedorVal.val();
            var valueRutaAnterior = MRutaAnterior.val();

            var json = JSON.stringify({ codUsuario: valueCodVendedor, codRutaAnterior: valueRutaAnterior, codRuta: valueSelectedRuta, diaSemana: valueSelectedDia });

            if (valueSelectedRuta > 0) {

                if (valueSelectedDia > 0) {
                    console.log(json);
                //Envio los valores del modal en un json y el codVendedor.
                    ActualizarRutasAsignadas(json, valueCodVendedor);
                } else {
                    selectDias.attr("required", "required");
                }

            } else {
                selectRutas.attr("required", "required");
            }

        });
    }
    //EXEC FUC
    ActualizarRutaDelVendedor();
    
    function ActualizarRutasAsignadas(data, codUsuario) {
     //Descricion : Recibo los parametros del evento click del ActualizarRutaDelVendedor
     //los envio por Ajax 
        $.ajax({
            type: "POST",
            url: "frmRutasAsignadas.aspx/ActualizarRutasAsignadas",
            data: data,
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            error: function (xhr, ajaxOtions, thrownError) {
               console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (response) {
                if (response.d == 0) {
                    Mpmensaje.html("Se Actualizo correctamente");
                    Mpmensaje.css("color", "#ffffff");
                    Mmensaje.css("background-color", "#337ab7")
                        .css("border-color", "#2e6da4");
                    Mmensaje.css("display", "block");
                    ActualizarTabla(codUsuario);
                   // Limpio el valor codRuta y le paso el codRuta Anterior.
                    MRutaAnterior.val(""); 
                    var opitionSelectedRuta = selectRutas.find("option:selected");
                    var valueSelectedRuta = opitionSelectedRuta.val();
                    MRutaAnterior.val(valueSelectedRuta)
                    //////////////////////////////////////////////////////////7

                } else {
                    //console.log(response.d);

                    var arrayVendedores = vendedores.find("option");
                    for (var i = 0; i < arrayVendedores.length; i++) {
                        if (parseInt(arrayVendedores[i].value) === response.d) {
                           var  nombreVendedor = arrayVendedores[i].text;
                        }
                    }

                    Mpmensaje.css("color", "rgba(179, 10, 10, 0.69)");
                    Mmensaje.css("background-color", "rgba(255, 0, 0, 0.51)")
                        .css("border-color", "rgb(203, 46, 46)");
                    Mpmensaje.html("La ruta ya esta  asignada al vendedor " + nombreVendedor);
                    Mmensaje.css("display", "block");

                }

            }
        });
    }

    //Eliminar Registro
    function ElimiarRutasAsignadas(codUsuarioT, coodRutaT) {
    //Descricion : Recibo los parametros del evento click del ActualizarRutaDelVendedor
     //los envio por Ajax 
        var json = JSON.stringify({ codUsuario: codUsuarioT, codRuta: coodRutaT });
        $.ajax({
            type: "POST",
            url: "frmRutasAsignadas.aspx/EliminarRutasAsignadas",    
            data: json,
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                //console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (response) {

                if (response.d > 0) {
                    ActualizarTabla(codUsuarioT);
                }
            }
        })

    };

   //////////////////////////////////////////ALGORITMO DE ORDENAMIENTO DE RUTAS JS////////////////////////////////
    //DESCRIPCION: ESTA FUNCION ME PERMITE REALIZAR EL EVENTO DE ORDENAMIENTO
    function VistaAnterior(tableBodyAnterior) {
      var codOrden = tableBodyAnterior;
        tableBody.sortable({
            placeholder: "highlight",
            
            start: function (event, ui) {
                var tableBodyTD = $("#tbl_body_table tr td");
                
                tableBodyTD.css("border-radius", "5px");
                ui.item.toggleClass("highlight");
                
            },
            stop: function (event, ui) {
                ui.item.toggleClass("highlight");
            },
            update: function (event, ui) {
                
                var lengthBodyA = tableBodyAnterior.length;
                var arrayBodyAnterior = new Array();
                var arrayBodyActual = new Array();
                var BodyActual = $("#tbl_body_table tr");
                var jsonCodOrdenCodRuta = new Array();
                var lengthBodyB = BodyActual.length;

                if (lengthBodyA == lengthBodyB) {

                    for (i = 0; i < lengthBodyA; i++) {
                        
                        var codOrdenAnterior = codOrden[i].cells[0].innerText;

                        arrayBodyAnterior.push(codOrdenAnterior);
                       
                    }
                    
                    for (i = 0; i < lengthBodyB; i++) {

                        arrayBodyActual.push(BodyActual[i].cells[0].innerText);
                        BodyActual[i].cells[0].innerText = arrayBodyAnterior[i];

                        if (table.row(codOrden[i]).data()[5] != table.row(BodyActual[i]).data()[5]) {               
                            jsonCodOrdenCodRuta.push
                                (

                                {
                                    codUsuario: table.row(BodyActual[i]).data()[6],
                                    codOrden: parseInt(arrayBodyAnterior[i]),
                                    codRuta: table.row(BodyActual[i]).data()[5]
                                }
                                );
                        }
                    }
                   
                    arrayBodyAnterior = [];
                    codOrden = $("#tbl_body_table tr");
                    ActualizarOrdenRutas(jsonCodOrdenCodRuta)

                }
               
            }
              
        });
        
    }

    function ActualizarOrdenRutas(jsonCodOrdenCodRuta) {
        //DESCRIPION : FUNCION QUE ME ENVIA AL ARRAY DE OBJETOS OBTENIDOS AL SERVIDOR POR AJAX
        var opitionSelectedVendedores = vendedores.find("option:selected");
        var valueSelectedVendedor = opitionSelectedVendedores.val();
        var json = JSON.stringify({ arrayData: jsonCodOrdenCodRuta });
        $.ajax({
            type: "POST",
            url: "frmRutasAsignadas.aspx/ActualizaOrdenRutasAsignadas",
            data: json,
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                //console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (response) {
                if (response.d == 0) {
                    ActualizarTabla(valueSelectedVendedor);
                    MmensajeOrden.css('opacity', '1')
                        .css('height', '40px');
                    setTimeout(function () {
                        MmensajeOrden.css('opacity', '0');
                    }, 2000);
                    setTimeout(function () {
                        MmensajeOrden.css('height', '0px')
                    }, 3000)
                }
            }
        });
    }
    ////////////////////////AQUÍ TERMINA EL ALGORITMO DE ORDENAR RUTAS
});

