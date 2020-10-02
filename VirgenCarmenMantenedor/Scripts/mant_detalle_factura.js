$(document).ready(function () {
    var fechaActual = new Date();
    var MesActual = fechaActual.getMonth() + 1;
    var codEstado = $("#codEstado");
    var btnVer = '<button type="button" title="Ver" class="icon-eye btnEye" data-toggle="modal"  data-target="#modalVer" ></button>'
    var btnAnular = ' <button type="button" id="" class="icon-blocked btnBlocked" data-toggle="tooltip"  title="Anular" ></button>'
    var btnPagar = ' <button type="button" id="" class="icon-cart btnCart" data-toggle="modal"  title="Pagar" ></button>'
    var btndescargar = ' <button type="button" title="Descargar" class="icon-file-pdf btnPdf btndescargar"></button>';
    var codClienteSelect;
    var vendedores = $("#vendedores");
    var MmensajeOrdenFecha = $('#MmensajeOrdenFecha');
    var btnBuscar = $("#btnBuscar");
    var fechaActualIncio = moment().format("YYYY-MM-DD");
    var valorFIltroFecha = true;                    
    var codDocumento = $("#codDocumento");
    var mpagos = $("#mpagos");
    var import_pago = $(".import-pago");
    var Vuelto = $("#Vuelto");
    var ImportPago = $("#ImportPago");
    var ImporteTotal;
    var valorVuelto;
    var pImporte = $("#pImporte");
    var pVendedor = $("#pVendedor");
    var pCLiente = $("#pCLiente");
    var pFactura = $("#pFactura");
    var pDoc = $("#pDoc");
    var pRazonS = $("#pRazonS");
    var fechaTransact;
    var fechaPago;
    var codTipoVenta = $("#codTipoVenta");
    var btnGuardar = $("#btnGuardar");
    var codtipoVenta = $("#codTipoVenta");
    var idTipoVenta;
    var importeTotalValue;
    var importePagoValue;
    var ntraVenta;
    var codPrestamo;
    var mpagosValue;
    var estadoV;
    var pigv = $("#pigv");
    var igv;
    var tipoMoneda;
    var estadoPago;
    var Mpmensaje = $('#Mpmensaje');
    var Mmensaje = $('#Mmensaje');
    var ImportPagoTrans = $("#ImportPagoTrans");
    var ImporteNC;
    var ImportePagar;
    var pImporteNC = $("#pImporteNC");
    var pImporteCP = $("#pImporteCP");
    var descMoneda;
    var codTipoMoneda = $("#codTipoMoneda");
    var tipoVen;
    var nCuota;
    var fechaCuota;
    var codFactura;
    var btnRennvSunat = $("#btnReenviarSunat");

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

    $('#tb_documento_venta').DataTable({
        ordering: false,
        language: {
            lengthMenu: "Mostrar _MENU_ registros",
            zeroRecords: "No hay registros",
            info: "Mostrando la página _PAGE_ de _PAGES_",
            infoEmpty: "No hay registros disponibles.",
            infoFiltered: "(filtrado de  _MAX_ registros en total)",
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
                "width": "4%",
                targets: [0],

            },
            {
                "width": "4%",
                targets: [1],

            },
            {
                "width": "10%",                
                targets: [2]               
                
            },
            {
                "width": "12%",
                targets: [3]               
            },            
            {
                "width": "4%",
                "class": "text-center",
                targets: [5],
                render: function (data) {
                    return moment(data).format('DD/MM/YYYY');
                }
            },
            {
                "width": "4%",
                "class": "text-center",
                targets: [6],
                render: function (data) {
                    return moment(data).format('DD/MM/YYYY');
                }
            },
            {
                "width": "4%",
                "class": "text-center",
                targets: [7]
            },
            {
               targets: [9, 10, 12, 13, 14,15,16,17,18],         
                "visible": false,
                "searchable": false
            }
           
        ],

    });
    //Capitalizar los textos
    function capitalizeFLetter(valor) {
        var input = valor;
        
    } 
    //tabla de detalle de venta en ver
    var idDateProducto = $("#id_table_detalle");
    idDateProducto.DataTable({
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
        }

    });
    //Propiedades para el DataTable
    $('#tb_cronograma_prestamo').DataTable({
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
        //Para que el DataTable no me muestre ciertas Columnas.
        columnDefs: [

            {
                "width": "4%",
                "class": "text-center",
                targets: [1],
                render: function (data) {
                    return moment(data).format('DD/MM/YYYY');
                }
            },
           
          	 {
                "targets": [4],
                "visible": false,
                
            }
        ]
    });
    //tabla de coronograma
    var tablaCronograma = $("#tb_cronograma_prestamo").dataTable();
    var tableCronograma = $("#tb_cronograma_prestamo").DataTable();
    //creo variables despues de que el DataTable este creado en el DOM.
    var tabla = $("#tb_documento_venta").dataTable(); //funcion jquery
    var table = $("#tb_documento_venta").DataTable(); //funcion DataTable-libreria
    //creo variables despues de que el DataTable este creado en el DOM.
    var tablaDetalle = $("#id_table_detalle").dataTable(); //funcion jquery
    var tableDetalle = $("#id_table_detalle").DataTable(); //funcion DataTable-libreria
    //////////////////////////////////////////////////////////////////

    /////LENADO DE TABLA POR DEFECTO //// FILTRADO PRO LA FECHA ACTUAL (MES)//////
    function addRowDT(data) {
        
        //DESCRIPCION : Funcion que me crea el listado de rutas en el body del DataTable
        var importeVenta;

       

        for (var i = 0; i < data.length; i++) {

            if (data[i].tipoMoneda == 1) {
                importeVenta = data[i].importeTotal.toFixed(2) + " S/.";
            } else {
                importeVenta = data[i].importeTotal.toFixed(2) + " $.";
            }
            tabla.fnAddData([
                data[i].serie + '-' + data[i].nroDocumento,
                data[i].descdocumento,
                data[i].cliente,
                data[i].razonSocial,
                data[i].vendedor,
                data[i].fechaTransaccion,
                data[i].fechaPago,  
                data[i].importeTotal.toFixed(2),
                data[i].estado,
                data[i].ntraVenta,
                data[i].tipoVenta,
                data[i].descriptipoventa,
                data[i].estadov,
                data[i].igv.toFixed(2),
                data[i].tipoMoneda,
                data[i].estadoc,
                data[i].importecxc.toFixed(2),
                data[i].importeP.toFixed(2),
                data[i].estadoP,
                data[i].moneda,
                btnVer + btnPagar + btndescargar
            ]);
        }
        $("#tb_documento_venta").on('click', '.btnCart', function () {
            limpiarCampos();
            mpagos.prop('selectedIndex', 0);
            import_pago.css('display', 'none');
            $("#divTransferencia").css('display', 'none');
            $("#fpago").val("");
            ImportPago.val("");
            Vuelto.val("");
            $("#fech-pago").val("");
            $("#msjFechaPago").remove();
            $('#msjMediPago').remove();
            $("#msjVUelto").remove();
            btnGuardar.css("display", "block");
            $("#codpr").val("");    

            var tr = $(this).parent().parent();
            
            ImporteTotal = table.row(tr).data()[7];
            tipoVen = parseInt(table.row(tr).data()[10]);
            codVenta = table.row(tr).data()[9];
            estadoV = parseInt(table.row(tr).data()[15]);

            if (tipoVen == 1) {
                ImportePagar = table.row(tr).data()[16];
                ImporteNC = (ImporteTotal - ImportePagar).toFixed(2);
                var fCuota = moment(table.row(tr).data()[6]).format('DD/MM/YYYY');
                $('#fpago').val(fCuota);
                $("#ncuota").css('display', 'none');
                $("#lblcodnCuota").css('display', 'none');
                $("#divCronograma").css('display', 'none');
                $("#tblCronograma").css('display', 'none');
            } else if (tipoVen == 2) {
                ListarCronograma(1, codVenta, function (data) {
                    $("#divCronograma").css('display', 'block');
                    $("#tblCronograma").css('display', 'block');
                    for (var i = 0; i < data.length; i++) {

                        tablaCronograma.fnAddData([
                            data[i].codPrestamo,
                            data[i].fechaPago,
                            data[i].nroCuota,
                            data[i].importe.toFixed(2),
                            data[i].estado,
                            data[i].descestado
                        ]);
                    }
                    
                    var bodyTr = $("#tbl_body_cronograma_prestamo tr");                    
                    var arrCuota = new Array();
                    for (var i = 0; i < bodyTr.length; i++) {

                        if (tableCronograma.row(i).data()[4] == 1) {
                            arrCuota.push(tableCronograma.row(i).data()[2]);
                        }

                    }
                    var nroCuotamin = Math.min.apply(null, arrCuota);

                    for (var i = 0; i < bodyTr.length; i++) {

                        if (tableCronograma.row(i).data()[2] == nroCuotamin) {
                            ImportePagar = tableCronograma.row(i).data()[3];
                            ImporteNC = ImporteTotal - ImportePagar;
                            nCuota = tableCronograma.row(i).data()[2];
                            fechaCuota = tableCronograma.row(i).data()[1];
                            codPrestamo = tableCronograma.row(i).data()[0];
                        }

                    }

                    pImporteCP.val(ImportePagar);
                    pImporteNC.val(ImporteNC);
                    $('#ncuota').val(nCuota);
                    var fCuota = moment(fechaCuota).format('DD/MM/YYYY');
                    $('#fpago').val(fCuota);
                    arrCuota = [];
                    $("#ncuota").css('display', 'block');
                    $("#lblcodnCuota").css('display', 'block');
                    $("#codpr").val(codPrestamo);
                    
                    
                });
                
                
                //ImportePagar = tableCronograma.row(tr).data()[3];
                //ImporteNC = ImporteTotal - ImportePagar;
            }

            var tMoneda = parseInt(table.row(tr).data()[14]);

            if (tMoneda == 1) {
                descMoneda = "SOLES";
            }
            if (tMoneda ==2 ) {
                descMoneda = "DOLARES";
            }
            
            
            if (estadoV == 0)   {
                estadoV = parseInt(table.row(tr).data()[18]);
            }
            
            /*fechaTransact = table.row(tr).data()[5];
           fechaPago = $("#fpago").val();
            var fechaT = fechaTransact.split('/').join('-');
            var fechaP = fechaPago.split('/').join('-');
            var fechaTf = moment(fechaT, 'MM-DD-YYYY').format("YYYY-MM-DD");
            var fechaPf = moment(fechaP, 'DD-MM-YYYY').format("YYYY-MM-DD");
            
            //createdAt=createdAt.split(" ");
            var fechaTr = moment(fechaTf, "YYYY-MM-DD");
            var fechaPa= moment(fechaPf, "YYYY-MM-DD");*/
            
            
            switch (estadoV){  

                case 1:

                    $("#divFechaPago").css("display", "block");

                    //modal
                   /* if (fechaPa > fechaTr) {
                        $("#divFechaPago").css("display", "block");
                    } else {
                        $("#divFechaPago").css("display", "none");
                    }*/
                    
                    $("#divMPagos").css("display", "block");
                    $('#divEfectivo').css("display", "block");
                    Mmensaje.css("display", "none");

                    $("#modalPago").modal();
                    pDoc.val(table.row(tr).data()[1]);
                    pFactura.val(table.row(tr).data()[0]);
                    pCLiente.val(table.row(tr).data()[2]);
                    pRazonS.val(table.row(tr).data()[3]);
                    pImporte.val(ImporteTotal);
                    pVendedor.val(table.row(tr).data()[4]);
                    codtipoVenta.val(table.row(tr).data()[11])
                    pigv.val(table.row(tr).data()[13]);
                    pImporteNC.val(ImporteNC);
                    pImporteCP.val(ImportePagar);
                    codTipoMoneda.val(descMoneda);
                    ntraVenta = table.row(tr).data()[9]
                    fechaTransact = table.row(tr).data()[5];
                    fechaPago = $("#fpago").val();
                    
                    idTipoVenta = table.row(tr).data()[10];
                    igv = parseFloat(table.row(tr).data()[13]).toFixed(2);
                    tipoMoneda = parseInt(table.row(tr).data()[14]);
                    estadoV = parseInt(table.row(tr).data()[12]);

                   break;
                case 2:

                    swal({
                        title: "PAGADO",
                        text: "La venta ya ha sido pagada.",
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
                    break;
                case 3:
                    swal({
                        title: "REVERTIDO POR NOTA DE CREDITO",
                        text: "La venta ha sido revertida por NC.",
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
                    break;


            }  

        })          

        $.fn.dataTableExt.afnFiltering.push(

            function (settings, data, dataIndex) {
                var min = $('#min-date').val();
                var minr = min.split('/').join('-');
                var max = $('#max-date').val()
                var maxr = max.split('/').join('-');
                var createdAt = data[4] || 0;
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

    ListarDocumentosVenta(1, MesActual, 0, 0, 0, "", "",0,0,'',0)

    function ListarDocumentosVenta(flagFiltro, MesActual, codEstado,
        codCliente, codVendedor, fechaInicial, fechaFinal, codTipoDoc, ntraVenta, serie, numdoc) {
        //DESCRICION : Funcion que me obtiene la lista de bitacoras 
        var json = JSON.stringify({
            flagFiltro: flagFiltro,
            fechaActual: MesActual,
            codEstado: codEstado,
            codCliente: codCliente,
            codVendedor: codVendedor,
            fechaInicial: fechaInicial,
            fechaFinal: fechaFinal,
            codTipoDoc: codTipoDoc,
            ntraVenta: ntraVenta,
            serie: serie,
            numdoc: numdoc
        });
        $.ajax({
            type: "POST",
            url: "frmMantDetalleFactura.aspx/ListarDocumentosVenta",
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
    /////////////////////////////////////////////////////////////////////

    /////////FILTROS////

    //---ESTADOS--///

    function addSelectEstados(data) {
        //DESCRIPCION : Funcion para llenar la lista de opciones del select del Vendedor.
        for (var i = 0; i < data.length; i++) {
            codEstado.append("<option value=" + data[i]["correlativo"] + ">" + data[i]["descripcion"] + "</option>");
        }
    }

    function ListarEstados() {
        //DESCRIPCION : Funcion que me trae la lista de vendedores
        $.ajax({
            type: "POST",
            url: "frmMantDetalleFactura.aspx/ListarEstados",
            data: "{'flag': '30' }",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {

                addSelectEstados(data.d);
            }
        })

    }
    ListarEstados();

    function addSelectMediosPago(data) {
        //DESCRIPCION : Funcion para llenar la lista de opciones del select del Vendedor.
        for (var i = 0; i < data.length; i++) {
            mpagos.append("<option value=" + data[i]["correlativo"] + ">" + data[i]["descripcion"] + "</option>");
        }
    }
            
    function ListarMediosPago() {
        //DESCRIPCION : Funcion que me trae la lista de vendedores
        $.ajax({
            type: "POST",
            url: "frmMantDetalleFactura.aspx/ListarEstados",
            data: "{'flag': '31' }",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {

                addSelectMediosPago(data.d);
            }
        })

    }
    ListarMediosPago();

 
    function addSelectDocumentos(data) {
        //DESCRIPCION : Funcion para llenar la lista de opciones del select del Vendedor.
        for (var i = 0; i < data.length; i++) {
            codDocumento.append("<option value=" + data[i]["correlativo"] + ">" + data[i]["descripcion"] + "</option>");
        }
    }

    function ListarDocumento() {
        //DESCRIPCION : Funcion que me trae la lista de vendedores
        $.ajax({
            type: "POST",
            url: "frmMantDetalleFactura.aspx/ListarEstados",
            data: "{'flag': '22' }",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {

                addSelectDocumentos(data.d);
            }
        })

    }
    ListarDocumento();

    $("#codCliente").keyup(function (event) {
        var cad = $(this).val();
        buscarClienteNombre(cad);

        if ($("#codCliente").val() == "") {
            $("#id_documento").val('');
            codClienteSelect = 0;
        }


    });

    function buscarClienteNombre(cadena) {
        $("#codCliente").autocomplete({
            minLength: 2,
            //delay: 500,
            source:
                function (request, response) {
                    $.ajax({
                        type: "POST",
                        url: "registrarpreventa.aspx/buscarCliente",
                        data: "{'cadena': '" + cadena + "' }",
                        contentType: 'application/json; charset=utf-8',
                        error: function (xhr, ajaxOtions, thrownError) {
                            console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
                        },
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                var obj = new Object();
                                obj.label = item.nombres;
                                obj.value = item.nombres;
                                obj.tipoListaPrecio = item.tipoListaPrecio;
                                obj.codCliente = item.codCliente;
                                obj.numDocumento = item.numDocumento;
                                return obj;
                            }));
                        }

                    });
                },
            select: function (event, ui) {
                //alert(ui.item.value);

                $("#id_documento").val(ui.item.numDocumento);
                
                //$("#id_codCliente").val(ui.item.codCliente);
                codClienteSelect = ui.item.codCliente
                

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

    
    btnBuscar.click(function () {

        var codSerie = $("#codSerie").val();
        var codNumDoc = $("#codNumDoc").val();

        var codFacturaINT = parseInt($("#codFactura").val());


        if ($("#codFactura").val() == "") {
            var elemnt = $("#codFactura").get(0);
            elemnt.setCustomValidity("");
            codFactura = 0;
            valorFIltroFecha = true
        } else {
            if (isNaN(codFacturaINT) || codFacturaINT < 0 ) {
                var elemnt = $("#codFactura").get(0);
                elemnt.setCustomValidity('Debe ingresar números positivos');
                valorFIltroFecha = false
               
            } else {
                var elemnt = $("#codFactura").get(0);
                elemnt.setCustomValidity("");                
                codFactura = parseInt($("#codFactura").val());
                valorFIltroFecha = true
            }

        }



        var codNumDocf

        if ($("#codNumDoc").val() == "") {
            var elemnt = $("#codNumDoc").get(0);
            elemnt.setCustomValidity("");
            codNumDocf = 0;
        } else {
            if (isNaN(parseInt(codNumDoc)) || parseInt(codNumDoc) < 0     ) {
                var elemntCodNumDoc = $("#codNumDoc").get(0);
                elemntCodNumDoc.setCustomValidity('Debe ingresar números positivos');
                valorFIltroFecha = false;
               
            } else {
                var elemnt = $("#codNumDoc").get(0);
                elemnt.setCustomValidity("");
                codNumDocf = codNumDoc;
                valorFIltroFecha = true
            }

        } 
        var optionCodEstado = codEstado.find("option:selected");
        var valueSelectedEstado = optionCodEstado.val();

        var optionCodVendedor = vendedores.find("option:selected");
        var valueSelectedCodVendedor = optionCodVendedor.val();

        var optionCodDocumento = codDocumento.find("option:selected");
        var valueSelectedCodDocumento = optionCodDocumento.val();

        if (codClienteSelect === undefined) {
            codClienteSelect = 0;
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
            
            if (valueSelectedEstado == 0 && codClienteSelect == 0 &&
            valueSelectedCodVendedor == 0 && min == "" && max == "" && valueSelectedCodDocumento == 0 && codFactura == 0 && 
            codSerie == "" && codNumDocf == 0 ) {
            ListarDocumentosVenta(1, MesActual, 0, 0, 0, "", "",0,0,'',0)
        } else {
            
            if (valorFIltroFecha == true) {
                ListarDocumentosVenta(2, MesActual, valueSelectedEstado,
                    codClienteSelect, valueSelectedCodVendedor, startDate, endDate, valueSelectedCodDocumento, codFactura, codSerie, codNumDocf)
            }
            
        }
    });

    //PROCESO DE PAGO


    mpagos.change(function () {
        var mpagosSelect = $(this).find("option:selected");
        mpagosValue = mpagosSelect.val();
        $("#msjVUelto").remove();
        if (mpagosValue == 1) {

            import_pago.css('display', 'block');
            $("#divTransferencia").css('display', 'none');
            $("#msjMediPago").remove();
        } else if (mpagosValue == 2) {
            $("#msjMediPago").remove();
            import_pago.css('display', 'none');
            $("#divTransferencia").css('display', 'block');


        } else {
            $("#divTransferencia").css('display', 'none');
            import_pago.css('display', 'none');
        }        
    }); 

    

    ImportPago.keyup(function (e) {

        var tecla = e.keyCode || e. which;
        if (tecla >= 48 && tecla <= 59 || tecla >= 96 && tecla <= 105 || tecla == 190 || tecla == 8 || tecla == 110) {
            importeTotalValue = parseFloat(ImportePagar).toFixed(2);
            importePagoValue = parseFloat(ImportPago.val());         

            if (ImportPago.val() != "" && (importePagoValue >= importeTotalValue)) {
                valorVuelto = (importePagoValue - importeTotalValue).toFixed(2);
                Vuelto.val(valorVuelto);
                $("#msjVUelto").remove();
                
            } else {
                               
                valorVuelto = (importePagoValue - importeTotalValue).toFixed(2)
                Vuelto.val(valorVuelto);
                if (ImportPago.val() == "") {
                    Vuelto.val("");
                }
                valorVuelto = false;
            }

            
           // ImportPago.val();
        } else {
            Vuelto.val("");
            ImportPago.val("");            
        }

    });

    ImportPagoTrans.keyup(function (e) {

        var tecla = e.keyCode || e.which;
        if (tecla >= 48 && tecla <= 59 || tecla >= 96 && tecla <= 105 || tecla == 190 || tecla == 8 || tecla == 110) {
            importeTotalValue = parseFloat(ImportePagar).toFixed(2);
            importePagoValue = parseFloat(ImportPagoTrans.val()).toFixed(2);

            if (ImportPagoTrans.val() != "" && (importePagoValue == importeTotalValue)) {
               /* valorVuelto = (importePagoValue - importeTotalValue).toFixed(2)
                Vuelto.val(valorVuelto);*/
                $("#msjVUelto").remove();
                valorVuelto = true;
            } else {

              //  valorVuelto = (importePagoValue - importeTotalValue).toFixed(2)
               // Vuelto.val(valorVuelto);
                valorVuelto = false;
            }


            // ImportPago.val();
        } else {        

            ImportPagoTrans.val("");           
            
        }

    });


    $("#fech-pago").datepicker(
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


    // Re-draw the table when the a date range filter changes
    $('.date-range-filter#fech-pago').change(function () {
        $("#msjFechaPago").remove();

    });
    function btnGuardarDatos(tipoCambio) {
        
        btnGuardar.click(function () {
            var numPrestamo = $("#codpr").val();
            console.log(numPrestamo);
            estadoPago = 2;
            var mpagosSelect = mpagos.find("option:selected");
            mpagosValue = mpagosSelect.val();

            var fechaPago = $("#fpago").val();
            var fechaT = fechaTransact.split('/').join('-');
            var fechaP = fechaPago.split('/').join('-');
            
            var fechaTf = moment(fechaT, 'MM-DD-YYYY').format("YYYY-MM-DD");
            var fechaPf = moment(fechaP, 'DD-MM-YYYY').format("YYYY-MM-DD");
            
            var fechaTr = moment(fechaTf, "YYYY-MM-DD");
            var fechaPa = moment(fechaPf, "YYYY-MM-DD");
            
            
            var fechaPagoIn = $("#fech-pago").val();
            var fechaPagoInp = fechaPagoIn.split('/').join('-');
            var fechaPagoInpu = moment(fechaPagoInp, 'DD-MM-YYYY').format("YYYY-MM-DD");
            var fechaPagoInput = moment(fechaPagoInpu, "YYYY-MM-DD");

            if (idTipoVenta == 1 && (fechaPa >= fechaTr) && (fechaPagoInput <= fechaPa)) {

                if (mpagosValue == 1) {

                    if (valorVuelto === false || ImportPago.val() === '') {
                        $("#divEfectivo").append("<p id='msjVUelto'>");
                        $("#msjVUelto").html("El monto a pagar no debe ser menor al importe a pagar")
                            .css('background-color', '#e61717')
                            .css('border-radius', '5px')
                            .css('color', 'white')
                            .css('padding', '5px')
                            .css('margin-top', '10px');
                    } else {
                        $("#msjVUelto").remove();   
                        codPrestamo = 0;
                        busquedaVentaCuentaPorCobrar(ntraVenta, 1, function (array) {

                            var codven = array[1];
                            var mediopago = parseInt(mpagosValue);
                            var tCambio = tipoCambio.tipoCambio;
                            var tMoneda = tipoMoneda;
                            var valorIgv = igv;
                            var itpv = importePagoValue;
                            var vueltov = parseFloat(Vuelto.val()).toFixed(2);
                            var nroTransf = $("#nroTrans").val();
                            var nroCuenta = $("#nroCuenta").val();
                            var banco = $("#descBanco").val();

                            var fechP = moment(array[3]).format('YYYY-MM-DD');
                            var fechaPag = moment(fechaPa).format('YYYY-MM-DD');

                            if (array[1] === ntraVenta && importeTotalValue === array[2].toFixed(2)
                                && estadoV === array[4] && fechaPag == fechP) {
                               InsertarTransaccionPago(1, 0, 0, codven, mediopago, tCambio, tMoneda, valorIgv,
                                    estadoPago, itpv, vueltov, nroTransf, nroCuenta, banco, fechaPagoInput)
                            }

                        });

                    }


                } else if  (mpagosValue == 2) {

                    if (valorVuelto === false || ImportPagoTrans.val() === '') {
                        $("#divImportTrans").append("<p id='msjVUelto'>");
                        $("#msjVUelto").html("El monto a pagar debe ser igual al importe a pagar")
                            .css('background-color', '#e61717')
                            .css('border-radius', '5px')
                            .css('color', 'white')
                            .css('padding', '5px')
                            .css('margin-top', '10px');
                    } else {

                        $("#msjVUelto").remove();
                        codPrestamo = 0;
                        busquedaVentaCuentaPorCobrar(ntraVenta, 1, function (array) {


                            var codven = array[1];
                            var mediopago = parseInt(mpagosValue);
                            var tCambio = tipoCambio.tipoCambio;
                            var tMoneda = tipoMoneda;
                            var valorIgv = igv;
                            var itpv = importePagoValue;
                            var nroTransf = $("#nroTrans").val();
                            var nroCuenta = $("#nroCuenta").val();
                            var banco = $("#descBanco").val();
                            // var vueltov = parseFloat(Vuelto.val()).toFixed(2);

                            var fechP = moment(array[3]).format('YYYY-MM-DD');
                            var fechaPag = moment(fechaPa).format('YYYY-MM-DD');

                            if (array[1] === ntraVenta && importeTotalValue === array[2].toFixed(2)
                                && estadoV === array[4] && fechaPag == fechP) {

                                InsertarTransaccionPago(1, 0, 0, codven, mediopago, tCambio,
                                    tMoneda, valorIgv, estadoPago, itpv, null, nroTransf, nroCuenta, banco, fechaPagoInput)

                            }

                        });
                    }
                    
                        

                    


                } else {

                    $("#divMPagos").append("<p id='msjMediPago'>");
                    $("#msjMediPago").html("Seleccione un medio de pago")
                        .css('background-color', '#e61717')
                        .css('border-radius', '5px')
                        .css('color', 'white')
                        .css('padding', '5px')
                        .css('margin-top', '10px');
                }
            } else if (idTipoVenta == 2 && (fechaPa >= fechaTr) && (fechaPagoInput <= fechaPa)) {
                
                
                if (mpagosValue == 1) {
                    
                    if (valorVuelto === false || ImportPago.val() === '') {
                        $("#divEfectivo").append("<p id='msjVUelto'>");
                        $("#msjVUelto").html("El monto a pagar no debe ser menor al importe a pagar")
                            .css('background-color', '#e61717')
                            .css('border-radius', '5px')
                            .css('color', 'white')
                            .css('padding', '5px')
                            .css('margin-top', '10px');
                    } else {
                        $("#msjVUelto").remove();

                            var codven = ntraVenta;
                            var mediopago = parseInt(mpagosValue);
                            var tCambio = tipoCambio.tipoCambio;
                            var tMoneda = tipoMoneda;
                            var valorIgv = igv;
                            var itpv = importePagoValue;
                            var vueltov = parseFloat(Vuelto.val()).toFixed(2);
                            var nroTransf = $("#nroTrans").val();
                            var nroCuenta = $("#nroCuenta").val();
                            var banco = $("#descBanco").val();
                            var codPrestamo = numPrestamo;
                            var nrocuota = parseInt($("#ncuota").val());                  
                                                   
                        InsertarTransaccionPago(2, codPrestamo, nrocuota, codven, mediopago, tCambio, tMoneda, valorIgv,
                            estadoPago, itpv, vueltov, nroTransf, nroCuenta, banco, fechaPagoInput);                          

                    }


                } else if (mpagosValue == 2) {

                    if (valorVuelto === false || ImportPagoTrans.val() === '') {
                        $("#divImportTrans").append("<p id='msjVUelto'>");
                        $("#msjVUelto").html("El monto a pagar debe ser igual al importe a pagar")
                            .css('background-color', '#e61717')
                            .css('border-radius', '5px')
                            .css('color', 'white')
                            .css('padding', '5px')
                            .css('margin-top', '10px');
                    } else {

                        $("#msjVUelto").remove();                       

                            var codven = ntraVenta;
                            var mediopago = parseInt(mpagosValue);
                            var tCambio = tipoCambio.tipoCambio;
                            var tMoneda = tipoMoneda;
                            var valorIgv = igv;
                            var itpv = importePagoValue;
                            var nroTransf = $("#nroTrans").val();
                            var nroCuenta = $("#nroCuenta").val();
                            var banco = $("#descBanco").val();
                        var codPrestamo = numPrestamo;
                        var nrocuota = parseInt($("#ncuota").val());

                        InsertarTransaccionPago(2, codPrestamo, nrocuota, codven, mediopago, tCambio,
                            tMoneda, valorIgv, estadoPago, itpv, null, nroTransf, nroCuenta, banco, fechaPagoInput);                     
                        
                    }

                } else {

                    $("#divMPagos").append("<p id='msjMediPago'>");
                    $("#msjMediPago").html("Seleccione un medio de pago")
                        .css('background-color', '#e61717')
                        .css('border-radius', '5px')
                        .css('color', 'white')
                        .css('padding', '5px')
                        .css('margin-top', '10px');
                }

            }else {
                $("#divFechaPago").append("<p id='msjFechaPago'>");
                $("#msjFechaPago").html("la fecha de pago no es correcta")
                    .css('background-color', '#e61717')
                    .css('border-radius', '5px')
                    .css('color', 'white')
                    .css('padding', '5px')
                    .css('margin-top', '10px')

                }

        });


    }
   
    function busquedaVentaCuentaPorCobrar(codVenta, flag, callbackFunction) {
        
        json = JSON.stringify({ codVenta: codVenta, flag: flag });
        var arrData = new Array();
        var functArrData
        $.ajax({
            type: "POST",
            url: "frmMantDetalleFactura.aspx/BuscarCuentaPorCobrar",
            data: json,
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) { 
                
                arrData.push(data.d.ntra, data.d.codOperacion,
                    data.d.importe, data.d.fechaCobro, data.d.estado, data.d.tipoCambiov);
                //console.log(arrData)
                callbackFunction(arrData);
            }
             
        });    
    }

    ObtenerTipoCambio(1, 1);

    function ObtenerTipoCambio(flag, codSucursal) {
        var json = JSON.stringify({ flag: flag, codSucursal: codSucursal })
        $.ajax({
            type: "POST",
            url: "frmMantDetalleFactura.aspx/ListarParametros",
            data: json,
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                
                btnGuardarDatos(data.d);
            }
        })
    }

    function limpiarCampos() {
        $("#nroTrans").val("");
        $("#nroCuenta").val("");
        $("#descBanco").val("");
        $("#ImportPagoTrans ").val("");
        $("#ImportPago").val("");
        $("#Vuelto").val("");
        $("#fech-pago").val("");
    }

    function InsertarTransaccionPago(flag, codPrestamo, nroCuota, codVenta, ntraMedioPago, tipoCambio,
        tipoMoneda, igv, estado, importe, vuelto,nroTransf,nroCuenta,banco,fechaTrans) {

        var json = JSON.stringify(
            {
                flag: flag,
                codPrestamo: codPrestamo,
                nroCuota: nroCuota,
                codVenta: codVenta,
                ntraMedioPago: ntraMedioPago,
                tipoCambio: tipoCambio,
                tipoMoneda: tipoMoneda,
                igv: igv,
                estado: estado,
                importe: importe,
                vuelto: vuelto,
                nroTransf: nroTransf,
                nroCuenta: nroCuenta,
                banco: banco,
                fechaTrans: fechaTrans
            });

        $.ajax({
            type: "POST",
            url: "frmMantDetalleFactura.aspx/InsertarTransaccionPago",
            data: json,
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (response) {
                
                if (response.d === 2)   {

                    $("#divFechaPago").css("display", "none");
                    $("#divMPagos").css("display", "none");
                    $('#divEfectivo').css("display", "none");
                    $('#divTransferencia').css("display", "none");
                    Mpmensaje.html("El pago se realizo correctamente");
                    Mpmensaje.css("color", "#ffffff");
                    Mmensaje.css("background-color", "#337ab7")
                        .css("border-color", "#2e6da4");
                    Mmensaje.css("display", "block");

                    btnGuardar.css("display", "none");
                    table.clear().draw();
                    ListarDocumentosVenta(1, MesActual, 0, 0, 0, "", "", 0,0,'',0)

                    if (codPrestamo != "" || codPrestamo != 0) {
                        ListarCronograma(1, codVenta, function (data) {
                            $("#divCronograma").css('display', 'block');
                            $("#tblCronograma").css('display', 'block');
                            for (var i = 0; i < data.length; i++) {

                                tablaCronograma.fnAddData([
                                    data[i].codPrestamo,
                                    data[i].fechaPago,
                                    data[i].nroCuota,
                                    data[i].importe.toFixed(2),
                                    data[i].estado,
                                    data[i].descestado
                                ]);
                            }

                            var bodyTr = $("#tbl_body_cronograma_prestamo tr");
                            var arrCuota = new Array();
                            for (var i = 0; i < bodyTr.length; i++) {

                                if (tableCronograma.row(i).data()[4] == 1) {
                                    arrCuota.push(tableCronograma.row(i).data()[2]);
                                }

                            }
                            var nroCuotamin = Math.min.apply(null, arrCuota);

                            for (var i = 0; i < bodyTr.length; i++) {

                                if (tableCronograma.row(i).data()[2] == nroCuotamin) {
                                    ImportePagar = tableCronograma.row(i).data()[3];
                                    ImporteNC = ImporteTotal - ImportePagar;
                                    nCuota = tableCronograma.row(i).data()[2];
                                    fechaCuota = tableCronograma.row(i).data()[1];
                                    codPrestamo = tableCronograma.row(i).data()[0];
                                }

                            }

                            pImporteCP.val(ImportePagar);
                            pImporteNC.val(ImporteNC);
                            $('#ncuota').val(nCuota);
                            var fCuota = moment(fechaCuota).format('DD/MM/YYYY');
                            $('#fpago').val(fCuota);
                            arrCuota = [];
                            $("#ncuota").css('display', 'block');
                            $("#lblcodnCuota").css('display', 'block');
                            $("#codpr").val(codPrestamo);


                        });

                    }

                }
                if (response.d === 1) {
                    Mpmensaje.html("El pago se realizo correctamente");
                    Mpmensaje.css("color", "#ffffff");
                    Mmensaje.css("background-color", "#337ab7")
                        .css("border-color", "#2e6da4");
                    Mmensaje.css("display", "block");
                    tableCronograma.clear().draw();
                    
                    ListarCronograma(1, codVenta, function (data) {
                        $("#divCronograma").css('display', 'block');
                        $("#tblCronograma").css('display', 'block');
                        for (var i = 0; i < data.length; i++) {

                            tablaCronograma.fnAddData([
                                data[i].codPrestamo,
                                data[i].fechaPago,
                                data[i].nroCuota,
                                data[i].importe.toFixed(2),
                                data[i].estado,
                                data[i].descestado
                            ]);
                        }

                        var bodyTr = $("#tbl_body_cronograma_prestamo tr");
                        var arrCuota = new Array();
                        for (var i = 0; i < bodyTr.length; i++) {

                            if (tableCronograma.row(i).data()[4] == 1) {
                                arrCuota.push(tableCronograma.row(i).data()[2]);
                            }

                        }
                        var nroCuotamin = Math.min.apply(null, arrCuota);

                        for (var i = 0; i < bodyTr.length; i++) {

                            if (tableCronograma.row(i).data()[2] == nroCuotamin) {
                                ImportePagar = tableCronograma.row(i).data()[3];
                                ImporteNC = ImporteTotal - ImportePagar;
                                nCuota = tableCronograma.row(i).data()[2];
                                fechaCuota = tableCronograma.row(i).data()[1];
                                codPrestamo = tableCronograma.row(i).data()[0];
                            }

                        }

                        pImporteCP.val(ImportePagar);
                        pImporteNC.val(ImporteNC);
                        $('#ncuota').val(nCuota);
                        var fCuota = moment(fechaCuota).format('DD/MM/YYYY');
                        $('#fpago').val(fCuota);
                        arrCuota = [];
                        $("#ncuota").css('display', 'block');
                        $("#lblcodnCuota").css('display', 'block');
                        $("#codpr").val(codPrestamo);


                    });

                    ListarDocumentosVenta(1, MesActual, 0, 0, 0, "", "", 0,0,'',0)
                }
                limpiarCampos();
                
            }
        });
    }

    //PAGO CREDITO///////////////////////
    function ListarCronograma(flag, codVenta, cronagramaPrestamo) {
        var json = JSON.stringify({ codVenta: codVenta, flag: flag });
        $.ajax({
            type:"POST",
            url:"frmMantDetalleFactura.aspx/ListarCronograma",
            data:json,
            contentType:"application/json; charset=utf-8",
            error:function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                tableCronograma.clear().draw();
                cronagramaPrestamo(data.d);

            }

        })

    }

    
    


    //VER detalle de venta
    var verCodVenta = $("#MVventa");
    var verVendedor = $("#MVvendedor");
    var verCliente = $("#MVcliente");
    var verRuta = $("#MVruta");
    var verPuntoEntrega = $("#MVentrega");
    var verfechaPago = $("#MVfechaPago");
    var vertventa = $("#MVtventa");
    var verMoneda = $("#MVMoneda");
    var verSerie = $("#MVSerie");
    var verNumVenta = $("#MVNroVenta");
    var verTipDoc = $("#MVtdoc");
    var verEstado = $("#MVEstado");
    var verRecargo = $("#MVrecargo");
    var verIgv = $("#MVigv");
    var verSubtotal = $("#MVsubtotal");
    var verTotal = $("#MVtotal");
    var listaPromo = $("#id_promo_detalle");
    var listaDesc = $("#id_desc_detalle");
    var hisFechaCreacion = $("#id_fecha_creacion");
    var hisFechaPago = $("#id_fecha_pago");
    var hisFechaNC = $("#id_fecha_NC");
    var hisFechaAnulacion = $("#id_fecha_anulacion");

    function LlenarDataVenta(data) {
        verVendedor.val(data.vendedor);
        verCliente.val(data.cliente);
        verRuta.val(data.ruta);
        verPuntoEntrega.val(data.direccion);
        verfechaPago.val(data.fechaPago);
        vertventa.val(data.tVenta);
        verMoneda.val(data.moneda);
        verSerie.val(data.serie);
        verNumVenta.val(data.nroDocumentoCadena);
        verTipDoc.val(data.tDoc);
        verEstado.val(data.estPre);
        verRecargo.val(data.importeRecargo.toFixed(2));
        verIgv.val(data.IGV.toFixed(2));
        verSubtotal.val((data.importeTotal - data.IGV).toFixed(2));
        verTotal.val(data.importeTotal.toFixed(2));

        var listaProductos = data.listaDetalle;
        var listaPromocionesData = data.listaPromociones;
        var listaDescuentosData = data.listaDescuentos;
        tableDetalle.clear().draw();
        for (var i = 0; i < listaProductos.length; i++) {
            tablaDetalle.fnAddData([
                listaProductos[i].codProducto,
                listaProductos[i].descProducto,
                listaProductos[i].cantidadPresentacion,
                listaProductos[i].descUnidadBase,
                listaProductos[i].precioVenta.toFixed(2),
                listaProductos[i].descAlmacen,
                listaProductos[i].descTipoProducto,
                listaProductos[i].descuento.toFixed(2),
                (listaProductos[i].cantidadUnidadBase * listaProductos[i].precioVenta - listaProductos[i].descuento).toFixed(2)
            ]);
        }
        listaPromo.html("");
        listaDesc.html("");
        hisFechaNC.html("");
        hisFechaPago.html("");
        hisFechaCreacion.html("");
        hisFechaAnulacion.html("");


        if (data.anulacionVenta.fechaTransaccion.trim().length > 0) {
            hisFechaAnulacion.append("<p>" + data.anulacionVenta.fechaTransaccion + "</p>");
        } else {
            hisFechaAnulacion.append("<p> SIN REGISTRO </p>");
        }

        if (data.listaNCFechas.length > 0) {
            for (var i = 0; i < data.listaNCFechas.length; i++) {
                hisFechaNC.append("<p>Codigo: " + data.listaNCFechas[i].codigo + " Fecha" + data.listaNCFechas[i].fechaTransaccion + " Realizada por: " + data.listaNCFechas[i].vendedor + "</p>");
            }

        } else {
            hisFechaNC.append("<p> SIN REGISTROS </p>");
        }

        if (data.listaPagosFechas.length > 0) {
            for (var i = 0; i < data.listaPagosFechas.length; i++) {
                hisFechaPago.append("<p>" + data.listaPagosFechas[i].fechaTransaccion + "</p>");
            }

        } else {
            hisFechaPago.append("<p> SIN REGISTROS </p>");
        }

        hisFechaCreacion.append("<p>" + data.fechaTransaccion + "</p>"); 

        if (listaPromocionesData.length > 0) {
            for (var i = 0; i < listaPromocionesData.length; i++) {
                listaPromo.append("<p>" + listaPromocionesData[i].descripcion + "</p>");
            }

        } else {
            listaPromo.append("<p> SIN PROMOCIONES </p>");
        }


        if (listaDescuentosData.length > 0) {
            for (var i = 0; i < listaDescuentosData.length; i++) {
                listaDesc.append("<p>" + listaDescuentosData[i].descripcion + "</p>");
            }

        } else {
            listaDesc.append("<p> SIN DESCUENTOS </p>");
        }

    }

    $("body").on('click', '.btnEye', function () {
        //limpiarModalVer();
        var tr = $(this).parent().parent();
        //var npre = tableModal.row(tr).data()[0];
        verCodVenta.val(table.row(tr).data()[9]);
        MostrarDetalleVenta(verCodVenta.val());
    });
    $("body").on('click', '.btndescargar', function () {
        //limpiarModalVer();
        var tr = $(this).parent().parent();
        //var npre = tableModal.row(tr).data()[0];
        verCodVenta.val(table.row(tr).data()[9]);
        descargarPdfVenta(verCodVenta.val());
    });

    function MostrarDetalleVenta(codigo) {
        //DESCRIPCION : Funcion que me trae la lista del detalle de la preventa por codigo de preventa
        $.ajax({
            type: "POST",
            url: "frmMantDetalleFactura.aspx/ListarDetalleVenta",
            data: "{'codigo': '" + codigo + "'}",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                //console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                tableDetalle.clear().draw();
                LlenarDataVenta(data.d);
                //console.log(data.d);
                //descargarPdfVenta(codigo);
            }
        });
    }
    function descargarPdfVenta(codigo) {
        //DESCRIPCION : Funcion que me trae la lista de rutas.
        var nomPdf = "Venta_" + codigo + ".pdf";
        $.ajax({
            type: "POST",
            url: "frmMantDetalleFactura.aspx/generarVentaPdf",
            data: "{'codigo': '" + codigo + "'}",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                var bytes = new Uint8Array(data.d);
                enviarpdf(nomPdf, bytes);
            }
        });
    }

    function enviarpdf(nomPdf, datos) {
        var blob = new Blob([datos]);
        var link = document.createElement("a");
        link.href = window.URL.createObjectURL(blob);
        var fileName = nomPdf;
        link.download = fileName;
        link.click();
    }

    btnRennvSunat.click(function () {

        ReenviarComprobanteFallido();

    });

    function ReenviarComprobanteFallido() {
        //DESCRIPCION : Funcion que me trae la lista de rutas.
        $.ajax({
            type: "POST",
            url: "frmMantDetalleFactura.aspx/EnviarComproanteFallidos",
            //data: "{'codigo': '" + codigo + "'}",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOtions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                console.log(data.d);
            }
        });
    }

    

            
})
