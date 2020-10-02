$(document).ready(function () {
    var vendedores = $("#vendedores");
    //window.moment = require('moment');
    var rangoFecha = $("#rangoFecha");
    var MmensajeOrdenFecha = $('#MmensajeOrdenFecha');
    var map;

    //Para enviar la fecha Actual
    var fechaActual = new Date();
    var MesActual = fechaActual.getMonth() + 1;
    var fechaActualIncio = moment().format("YYYY-MM-DD");
    //
     
     

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
            language : "es"

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

        
   

    $('#tb_rutasBitacora').DataTable({
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
                title: 'Bitacora de Rutas del Vendedor',
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
                    columns: [0, 1, 2, 3, 4, 5]
                }
            }],
        //Para que el DataTable no me muestre ciertas Columnas.
        columnDefs: [

            {
                "width": "8%",
                targets: [0],
                
            },

            {
                "width": "8%",
                targets: [1],

            },

            {
                "width": "8%",
                targets: [2],

            },
            {
                "width": "5%",
                targets: [3],

            },
            {
                "width": "10%",
                targets: [3],

            },

            {
            "width": "2%",
            targets: [5],
                render: function (data) {
                    return moment(data).format('DD/MM/YYYY');
                }
            }],
        
    });



    //creo variables despues de que el DataTable este creado en el DOM.
    var tabla = $("#tb_rutasBitacora").dataTable(); //funcion jquery
    var table = $("#tb_rutasBitacora").DataTable(); //funcion DataTable-libreria

    

    
    //para ajustar el diseño de tabla
    table.columns.adjust().draw();

    function addRowDT(data) {
        
        //DESCRIPCION : Funcion que me crea el listado de rutas en el body del DataTable
        var clientRazonS;
        var replaceCli;
        var clientRuc;
        var visita;
        var motivo;
        for (var i = 0; i < data.length; i++) {

            replaceCli = data[i].cliente;
            clientRuc = replaceCli.replace(/ /g, "");
            

            if (clientRuc == "") {
                clientRazonS = data[i].razonsocial;
               
            }
            else {
                clientRazonS = data[i].cliente;
            }

            if (data[i].visita == 1) {
                visita = "Si";

            } else {
                visita = "No";
            }

            if (data[i].motivo == "") {
                motivo = "--";

            } else {
                motivo = data[i].motivo;
            }

            
            tabla.fnAddData([
                data[i].vendedor,
                data[i].descripcion,
                clientRazonS,
                visita,
                motivo,     
                data[i].fecha,
                data[i].coordenadaX,
                data[i].coordenadaY,
            ]);

            

           
        }       

        $.fn.dataTableExt.afnFiltering.push(
           
                function(settings, data, dataIndex) {
                    var min = $('#min-date').val();
                    var minr = min.split('/').join('-');
                    var max = $('#max-date').val()
                    var maxr = max.split('/').join('-');            
                    var createdAt = data[5] || 0; 
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
                }, 2000);
                setTimeout(function () {
                    MmensajeOrdenFecha.css('height', '0px')
                }, 4000)
            } else {

                if (min != "" && max != "") {
                    var optionSelected = $("#vendedores").find("option:selected");
                    var valueSelected = optionSelected.val();
                    ListarBitacoras(valueSelected, MesActual, 0, startDate, endDate);
                } else {
                   // table.draw();
                }
                
               
            }
            
        });
       
    }    

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

    function ListarBitacoras(idVendedor, Mes, flagFiltro,fechaIncio,fechaFin) {
        //DESCRICION : Funcion que me obtiene la lista de bitacoras 
     
       

        var json = JSON.stringify({
            codVendedor: idVendedor,
            fechaActual: Mes,
            flagFiltro: flagFiltro,
            fechaIncio: fechaIncio,
            fechaFin: fechaFin
        });
        $.ajax({
            type: "POST",
            url: "frmRutasBitacora.aspx/ListarRutasBitacora",
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


    function SeleccionarVendedor() {
        //DESCRICION : Funcion que me obtiene la lista de rutas asignadas segun el vendedor seleccionado.
        vendedores.change(function () {

            

            var optionSelected = $(this).find("option:selected");
            var valueSelected = optionSelected.val();
            ListarBitacoras(valueSelected, MesActual, 1, fechaActualIncio, fechaActualIncio);
           if (valueSelected > 0) {

                   rangoFecha.css("display", "block")
              
            } else {

               rangoFecha.css("display", "none");
            }
          
        });
    }
    SeleccionarVendedor();

    //GOOGLE MAPS


});