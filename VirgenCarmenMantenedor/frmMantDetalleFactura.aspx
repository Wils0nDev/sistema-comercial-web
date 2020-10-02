<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmMantDetalleFactura.aspx.cs" Inherits="VirgenCarmenMantenedor.frmMantDetalleFactura" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
      <link rel="stylesheet" href="Scripts/DataTable/datatables.min.css" />    
    <link rel="stylesheet" href="Scripts/jqueryui/jquery-ui.min.css" />
    <link rel="stylesheet" href="Scripts/jqueryui/jquery-ui.structure.min.css" />
    <link rel="stylesheet" href="Scripts/jqueryui/jquery-ui.theme.min.css" />
    <link rel="stylesheet" href="CSS/modal_style.css" />
    <link rel="stylesheet" href="CSS/DataTable.css" />
    <link rel="stylesheet" href="css/web_general.css" type="text/css" media="screen, projection" />
    <link rel="stylesheet" href="css/mant_det_factura.css" type="text/css" media="screen, projection" />
   
    <link rel="stylesheet" href="icon/style.css" />
    <script src="Scripts/DataTable/datatables.min.js"></script>
    <script src="Scripts/sweetalert.min.js"></script>
    <script src="Scripts/moment.min.js"></script>
    <script type="text/javascript" src="Scripts/jqueryui/jquery-ui.min.js"></script>
    <script src="Scripts/mant_detalle_factura.js"></script>
    <title>Detalle de facturación</title>

</head>
<body>
    <div class="container-fluid">
        <div class="row">
            <div class="col-xs-12">
                <div class="box-header">
                    <h3 class="box-title" id="tituloID">Mantenedor de detalle de ventas     </h3>
                </div>

                <!-- ESTE SERA EL SUB TITULO GENERAL DE LO QUE SE QUIERE HACER -->
                <div class="form-group sub-titulo">
                    <h4 class="box-filtros">Filtros</h4>
                </div>
                <form id="formFiltros" onsubmit="return false;">
                    <div class="form-group col-xs-12">
                        <div class="form-group col-xs-3">
                            <label class="col-sm-4 label label-default horizontal" id="lblcodFactura" for="codFactura">Código de venta</label>
                            <input type="text" class="form-control col-sm-2 horizontal" id="codFactura" placeholder="Código de venta" />
                        </div>
                        <div class="form-group col-xs-2">
                            <label for="" class="col-sm-4 label label-default horizontal">Serie</label>
                            <input type="text" class="form-control col-sm-2 horizontal" id="codSerie" placeholder="Serie" />

                        </div>
                        <div class="form-group col-xs-2">
                            <label for="" class="col-sm-4 label label-default horizontal">N° Doc.</label>
                            <input type="text" class="form-control col-sm-2 horizontal" id="codNumDoc" placeholder="Numero" />
                        </div>
                        <div class="form-group col-xs-3">
                            <label for="" class="col-sm-4 label label-default horizontal">Documento</label>
                            <select id="codDocumento" class="form-control horizontal">
                                <option value="0">DOCUMENTO</option>

                            </select>
                        </div>
                        <div class="form-group col-xs-2">
                            <label for="" class="col-sm-4 label label-default horizontal">Estado</label>
                            <select id="codEstado" class="form-control horizontal">
                                <option value="0">ESTADO</option>

                            </select>
                        </div>
                    </div>
                    <div class="form-group col-xs-12">
                        <div class="form-group col-xs-6">
                            <label class="col-sm-2 label label-default horizontal" id="lblcodCliente" for="codCliente">Cliente</label>
                            <input type="text" class="form-control horizontal" id="codCliente" placeholder="Nombre del cliente o razon social" />
                        </div>
                        <div class="form-group col-xs-6">
                            <label class="col-sm-2 label label-default horizontal" id="lblNumDoc" for="codCliente">N° Documento</label>
                            <input type="text" class="form-control horizontal" id="id_documento" placeholder="RUC/DNI" disabled />
                        </div>
                    </div>
                    <div class="form-group col-xs-12">
                        <div class="form-group col-xs-12">
                            <label class="col-sm-2 label label-default horizontal" id="lblcodVendedor" for="codVendedor">Vendedor</label>
                            <select class="form-control" id="vendedores">
                                <option value="0">SELECCIONE A UN VENDEDOR</option>
                            </select>
                        </div>
                    </div>

                    <div class="form-group col-xs-12">
                        <div class="form-group col-xs-12">
                            <label for="" id="fecharegistro" class="col-sm-1 label label-default horizontal">Fecha de registro</label>
                            <div class='col-sm-4'>
                                <input type="text" name="date_begin" id="min-date" class="form-control date-range-filter"
                                    placeholder="De: dd-mm-yyyy" />
                            </div>
                            <div class='col-sm-4'>
                                <input type="text" id="max-date" class="form-control date-range-filter"
                                    placeholder="Hasta: dd-mm-yyyy" />
                            </div>
                            <div class="form-group col-xs-2">
                                <button type="submit" id="btnBuscar" class="btn btn-primary">Buscar</button>
                            </div>
                        </div>
                    </div>
                    <div class="form-group col-xs-12" id="MmensajeOrdenFecha">
                        <p id="MpmensajeOrden">La fecha inicial  debe ser menor o igual a la fecha final</p>
                    </div>
                </form>
            </div>
        </div>

        <div class="row">
            <div class="form-group col-xs-2">
                            <button type="submit" id="btnReenviarSunat" class="btn btn-primary">ENVIAR SUNAT</button>
                        </div>
        </div>

        <div class="row">
            <div class="box-body table-responsive">
                <table id="tb_documento_venta" class="table table-bordered table-hover">

                    <thead>
                        <tr>
                            <th scope="col">CODIGO</th>
                            <th scope="col">DOCUMENTO</th>
                            <th scope="col">CLIENTE</th>
                            <th scope="col">RAZON SOCIAL</th>
                            <th scope="col">VENDEDOR</th>
                            <th scope="col">EMISION</th>
                            <th scope="col">PAGO</th>
                            <th scope="col">TOTAL</th>
                            <th scope="col">ESTADO</th>
                            <th scope="col">CODVENTA</th>
                            <th scope="col">CODTIPOVENTA</th>
                            <th scope="col">VENTA</th>
                            <th scope="col">ESTADOV</th> 
                            <th scope="col">IGV</th>
                            <th scope="col">TIPOMONEDA</th>
                            <th scope="col">ESTADOC</th>
                            <th scope="col">IMPORTECC</th>
                            <th scope="col">IMPORTEP</th>
                            <th scope="col">ESTADOP</th>
                            <th scope="col">MONEDA</th>
                            <th scope="col">ACCION</th>

                        </tr>
                    </thead>
                    <tbody id="tbl_body_table_documento_venta" class="ui-sortable">
                    </tbody>
                    <!-- aqui traeremos la data por medio de ajax -->
                    <tfoot>
                        <tr>
                            <th scope="col">CODIGO</th>
                            <th scope="col">DOCUMENTO</th>
                            <th scope="col">CLIENTE</th>
                            <th scope="col">RAZON SOCIAL</th>
                            <th scope="col">VENDEDOR</th>
                            <th scope="col">EMISION</th>
                            <th scope="col">PAGO</th>
                            <th scope="col">TOTAL</th>
                            <th scope="col">ESTADO</th>
                            <th scope="col">CODVENTA</th>
                            <th scope="col">CODTIPOVENTA</th>
                            <th scope="col">VENTA</th> 
                            <th scope="col">ESTADOV</th> 
                            <th scope="col">IGV</th>
                            <th scope="col">TIPOMONEDA</th>
                            <th scope="col">ESTADOC</th>
                            <th scope="col">IMPORTECC</th>
                            <th scope="col">IMPORTEP</th>
                            <th scope="col">ESTADOP</th>
                            <th scope="col">MONEDA</th>
                            <th scope="col">ACCION</th>

                        </tr>
                    </tfoot>
                </table>

            </div>
        </div>

    </div>

    <!-- Modal -->
    <div class="modal fade" id="modalPago" tabindex="-1" role="dialog" aria-labelledby="modalPagoLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Pagar venta</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    <div class="form-group" id="Mmensaje">
                        <p id="Mpmensaje"></p>
                    </div>
                </div>
                <div class="modal-body">
                    <form role="form" onsubmit="return false;">
                        <div class="form-group col-xs-12">
                          
                            <label  class="label label-default col-xs-4" for="inputName">Tipo de documento:</label>
                            <!--p id="pDoc"></-p--> 
                            <div class="col-xs-8">
                                    <input type="text" class="form-control" id="pDoc" readonly=""/>
                            </div>
                        </div>
                        <div class="form-group col-xs-12">
                            <label class="label label-default col-xs-4" id="lblDoc" for="inputName">Factura:</label>
                            
                            <div class="col-xs-8">
                                    <input type="text" class="form-control" id="pFactura" readonly=""/>
                            </div>                            
                            <!--p id="pFactura"></p--> 
                        </div>
                        <div class="form-group col-xs-12">
                            <label class="label label-default col-xs-4" id="lblCliente" for="inputName">Cliente:</label>
                            <div class="col-xs-8">
                                    <input type="text" class="form-control" id="pCLiente" readonly=""/>
                            </div> 
                            <!--p id="pCLiente"></p--> 

                        </div>
                        <div class="form-group col-xs-12">
                            <label class="label label-default col-xs-4" id="lblRazonS" for="pRazonS">Razon Social:</label>
                             <div class="col-xs-8">
                                    <input type="text" class="form-control" id="pRazonS" readonly=""/>
                            </div> 
                            
                            <!--p id="pRazonS"></p--> 

                        </div>
                        <div class="form-group col-xs-12">
                            <label class="label label-default col-xs-4" id="lblVendedor" for="inputName">Vendedor:</label>
                            <div class="col-xs-8">
                                    <input type="text" class="form-control" id="pVendedor" readonly=""/>
                            </div>
                            

                        </div>
                        <div class="form-group col-xs-12">
                            <label class="label label-default col-xs-3" id="lblImporte" for="inputName">Importe:</label>
                            <div class="col-xs-3">
                                    <input type="text" class="form-control" id="pImporte" readonly=""/>
                            </div>
                            <label class="label label-default col-xs-3" id="lblpImporteNC" for="inputName">Descuento de NC:</label>
                            <div class="col-xs-3">
                                    <input type="text" class="form-control" id="pImporteNC" readonly=""/>
                            </div>
                        </div>

                        <div class="form-group col-xs-12">
                            <label class="label label-default col-xs-4"  for="codTipoVenta">Importe a pagar :</label>
                            <div class="col-xs-3">
                                    <input type="text" class="form-control" id="pImporteCP" readonly=""/>
                            </div>
                            <label class="label label-default col-xs-2" id="lbligv" for="inputName">Igv:</label>
                            <div class="col-xs-3">
                                    <input type="text" class="form-control" id="pigv" readonly=""/>
                            </div>
                        </div>

                        <div class="form-group col-xs-12">
                            <label class="label label-default col-xs-3"  for="codTipoVenta">Tipo de venta :</label>
                            <div class="col-xs-3">
                                    <input type="text" class="form-control" id="codTipoVenta" readonly=""/>
                            </div>
                            <label class="label label-default col-xs-3"  for="codTipoMoneda">Moneda :</label>
                            <div class="col-xs-3">
                                    <input type="text" class="form-control" id="codTipoMoneda" readonly=""/>
                            </div>
                        </div>

                        <div class="form-group col-xs-12">                            
                            <label class="label label-default col-xs-3"  for="codTipoMoneda">Fecha de pago:</label>
                            <div class="col-xs-4">
                                    <input type="text" class="form-control" id="fpago" readonly=""/>
                            </div>
                            <label class="label label-default col-xs-3" id="lblcodnCuota" for="codnCuota">Número de cuota:</label>
                            <div class="col-xs-2">
                                    <input type="text" class="form-control" id="ncuota" readonly=""/>
                                    <input type="text" class="form-control" id="codpr" disabled="disabled" style="display:none" />   
                            </div>
                        </div>

                        <div class="form-group col-xs-12" id="divCronograma">
                            <h5 class="modal-title" id="hCronograma">Cronograma</h5>
                        </div>
                        
                        <div class="form-group col-xs-12" id="tblCronograma">
                            <div class="box-body table-responsive">
                                <table id="tb_cronograma_prestamo" class="table table-bordered table-hover">

                                    <thead>
                                        <tr>
                                            <th scope="col" class="titletb">CODIGO</th>
                                            <th scope="col"  class="titletb">FECHA DE PAGO</th>
                                            <th scope="col"  class="titletb">N° DE CUOTA</th>
                                            <th scope="col"  class="titletb">IMPORTE</th>
                                            <th scope="col"  class="titletb">CODESTADO</th>
                                            <th scope="col"  class="titletb">ESTADO</th>
                                        </tr>
                                    </thead>
                                    <tbody id="tbl_body_cronograma_prestamo" class="ui-sortable">
                                    </tbody>
                                    <!-- aqui traeremos la data por medio de ajax -->
                                    <tfoot>
                                        <tr>
                                            <th scope="col"  class="titletb">CODIGO</th>
                                            <th scope="col"  class="titletb">FECHA DE PAGO</th>
                                            <th scope="col"  class="titletb">N° DE CUOTA</th>                                            
                                            <th scope="col"  class="titletb">IMPORTE</th>
                                            <th scope="col" class="titletb" >CODESTADO</th>
                                            <th scope="col" class="titletb">ESTADO</th>

                                        </tr>
                                    </tfoot>
                                </table>
                            </div>
                        </div>
                      
                        <div class="form-group col-xs-12" id="divFechaPago">
                            <label for="mpagos">Fecha de pago</label>
                            <input type="text" id="fech-pago" class="form-control date-range-filter"
                                placeholder="Hasta: dd-mm-yyyy" />
                            
                        </div>
                        <div class="form-group col-xs-12" id="divMPagos">
                            <label for="mpagos">Medios de pago</label>
                            <select class="form-control" id="mpagos">
                                <option value="0">SELECCIONE UN MEDIO DE PAGO</option>
                            </select>
                        </div>
                        <div class="form-group col-xs-12" id="divEfectivo">
                            <div class="form-group import-pago">
                                <label id="" for="ImportPago">Importe a pagar</label>
                                <input type="text" class="form-control" id="ImportPago" maxlength="10" />                            
                            </div>
                            <div id="divvuelto" class="form-group import-pago">
                                <label id="" for="Vuelto">Vuelto</label>
                                <input type="text" class="form-control" id="Vuelto" disabled="disabled" />                            
                            </div>
                        </div>
                        <div class="form-group" id="divTransferencia">
                            <div id="divTrans" class="form-group col-xs-6 import-pago-trans">
                                <label id="" for="ImportPago">N° de Transferencia</label>
                                <input type="text" class="form-control" id="nroTrans" />
                            </div>
                            <div id="divCuenta" class="form-group col-xs-6 import-pago-trans">
                                <label id="" for="Vuelto">N° de Cuenta</label>
                                <input type="text" class="form-control" id="nroCuenta" />
                            </div>
                            <div id="divBanco" class="form-group col-xs-6 import-pago-trans">
                                <label id="" for="Vuelto">Banco</label>
                                <input type="text" class="form-control" id="descBanco" />
                            </div>
                            <div id="divImportTrans" class="form-group col-xs-6 import-pago-trans">
                                <label id="" for="ImportPago">Importe a pagar</label>
                                <input type="text" class="form-control" id="ImportPagoTrans" />
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal" id="btnCancelar">Cerrar</button>
                            <button type="submit" class="btn btn-primary" id="btnGuardar">Pagar</button>
                        </div>
                    </form>
                </div>

            </div>
        </div>
    </div>


    <!-- VENTANA MODAL PARA VER DETALLE DE LA VENTA-->
    <div class="modal fade" id="modalVer" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel2" aria-hidden="true">
        <div class="modal-dialog" id="anchover">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel2">VENTA</h5>
                </div>
                <div class="modal-body">
                    <div class="container-fluid">
                            <div class="form-group">
                                <h4 class="box-filtros">Datos Generales</h4>
                            </div>
                            <!-- Datos Generales -->
                            <div class="row form-group">
                                <label class="label label-default col-xs-2" for="MVvendedor">Vendedor</label>
                                <div class="col-xs-10">
                                    <input type="text" class="form-control " id="MVvendedor" readonly=""/>
                                </div>
                            </div>
                            <div class="row form-group">
                                <label class="label label-default col-xs-2" for="MVcliente">Cliente</label>
                                <div class="col-xs-10">
                                    <input type="text" class="form-control " id="MVcliente" readonly=""/>
                                </div>
                            </div>
                            <div class="row form-group">
                                <label class="label label-default col-xs-2" for="MVruta">Ruta</label>
                                <div class="col-xs-10">
                                    <input type="text" class="form-control " id="MVruta" readonly=""/>
                                </div>
                            </div>
                            <div class="row form-group">
                                <label class="label label-default col-xs-2" for="MVentrega">P. Entrega</label>
                                <div class="col-xs-10">
                                    <input type="text" class="form-control " id="MVentrega" readonly=""/>
                                </div>
                            </div>
                            <!-- Datos de la preventa -->
                            <div class="form-group">
                                <h4 class="box-filtros">Datos de la Venta</h4>
                            </div>
                            <div class="row form-group">
                                <label class="label label-default  col-xs-2" for="MVSerie">Serie</label>
                                <div class="col-xs-4">
                                    <input type="text" class="form-control " id="MVSerie" readonly=""/>
                                </div>
                                <label class="label label-default  col-xs-2" for="MVNroVenta">Nro Doc.</label>
                                <div class="col-xs-4">
                                    <input type="text" class="form-control " id="MVNroVenta" readonly=""/>
                                </div>
                            </div>
                            <div class="row form-group">
                                <label class="label label-default  col-xs-2" for="MVventa">Venta</label>
                                <div class="col-xs-4">
                                    <input type="text" class="form-control " id="MVventa" readonly=""/>
                                </div>
                                <label class="label label-default  col-xs-2" for="MVfechaPago">F. Pago</label>
                                <div class="col-xs-4">
                                    <input type="text" class="form-control " id="MVfechaPago" readonly=""/>
                                </div>
                            </div>
                                <div class=" row form-group">
                                <label class="label label-default  col-xs-2" for="MVtventa">Tipo Venta</label>
                                <div class="col-xs-4">
                                    <input type="text" class="form-control " id="MVtventa" readonly=""/>
                                </div>
                                <label class="label label-default  col-xs-2" for="MVMoneda">Moneda</label>
                                <div class="col-xs-4">
                                    <input type="text" class="form-control " id="MVMoneda" readonly=""/>
                                </div>
                            </div>
                            <div class="row form-group">
                                <label class="label label-default  col-xs-2" for="MVtdoc">Tipo Doc</label>
                                <div class="col-xs-4">
                                    <input type="text" class="form-control " id="MVtdoc" readonly=""/>
                                </div>
                                <label class="label label-default  col-xs-2" for="MVEstado">Estado</label>
                                <div class="col-xs-4">
                                    <input type="text" class="form-control " id="MVEstado" readonly=""/>
                                </div>
                            </div>

                            <div class="row form-group">
                                <label class="label label-default  col-xs-2" for="MVrecargo">Recargo</label>
                                <div class="col-xs-4">
                                    <input type="text" class="form-control " id="MVrecargo" readonly=""/>
                                </div>
                                <label class="label label-default  col-xs-2" for="MVigv">IGV</label>
                                <div class="col-xs-4">
                                    <input type="text" class="form-control " id="MVigv" readonly=""/>
                                </div>
                            </div>
                            <div class="row form-group">
                                <label class="label label-default  col-xs-2" for="MVsubtotal">Subtotal</label>
                                <div class="col-xs-4">
                                    <input type="text" class="form-control " id="MVsubtotal" readonly=""/>
                                </div>
                                <label class="label label-default  col-xs-2" for="MVtotal">Total</label>
                                <div class="col-xs-4">
                                    <input type="text" class="form-control " id="MVtotal" readonly=""/>
                                </div>
                            </div>
                            <!-- Mostrar al carrito -->
                            <div class="form-group">
                                <h4 class="box-filtros">Detalle Venta</h4>
                            </div>
                            <div class="form-group">
                                <div class="box-body table-responsive">
                                    <table id="id_table_detalle" class="table table-bordered table-hover">
                                        <thead>
                                            <tr>
                                                <th>SKU</th>
                                                <th>DESCRIPCION</th>
                                                <th>CANT.</th>
                                                <th>UNIDAD</th>
                                                <th>PRECIO</th>
                                                <th>ALMACEN</th>
                                                <th>TIPO</th>
                                                <th>DESCUENTO</th>
                                                <th>SUBT.</th>
                                            </tr>
                                        </thead>
                                        <tbody id="tbl_body_table_modal_ver" class="ui-sortable">
                                            
                                        </tbody>
                                        <tfoot>
                                            <tr>
                                                <th>SKU</th>
                                                <th>DESCRIPCION</th>
                                                <th>CANT.</th>
                                                <th>UNIDAD</th>
                                                <th>PRECIO</th>
                                                <th>ALMACEN</th>
                                                <th>TIPO</th>
                                                <th>DESCUENTO</th>
                                                <th>SUBT.</th>  
                                            </tr>
                                        </tfoot>
                                    </table>
                                </div>
                            </div>
                            <!-- Mostrar promociones y descuentos -->
                            <div class="form-group col-xs-12">
                                <h5 class="box-filtros">Promociones</h5>
                            </div>
                            <div class="form-group col-xs-12" id="id_promo_detalle">

                            </div>
                            <div class="form-group col-xs-12">
                                <h5 class="box-filtros">Descuentos</h5>
                            </div>
                            <div class="form-group col-xs-12" id="id_desc_detalle">

                            </div>

                            <!-- Mostrar historial -->
                            <div class="form-group col-xs-12">
                                <h3 class="box-filtros">HISTORIAL</h3>
                            </div>

                            <div class="form-group col-xs-12">
                                <h5 class="box-filtros">Fecha de creación</h5>
                            </div>
                            <div class="form-group col-xs-12" id="id_fecha_creacion">
                            </div>

                            <div class="form-group col-xs-12">
                                <h5 class="box-filtros">Fecha de pago</h5>
                            </div>
                            <div class="form-group col-xs-12" id="id_fecha_pago">
                            </div>

                            <div class="form-group col-xs-12">
                                <h5 class="box-filtros">Nota de crédito</h5>
                            </div>
                            <div class="form-group col-xs-12" id="id_fecha_NC">
                            </div>

                            <div class="form-group col-xs-12">
                                <h5 class="box-filtros">Fecha de anulacion</h5>
                            </div>
                            <div class="form-group col-xs-12" id="id_fecha_anulacion">
                            </div>
                            <div class="form-group col-xs-12 " id="ancho2">
                                <button type="button" class="btn btn-primary pull-right" data-dismiss="modal" id="btnCancelar">SALIR</button>
                            </div>
                    </div> <!-- Fin container -->
                    
                </div> <!-- Fin Modal Body -->
            </div><!-- Fin Modal content -->
        </div>
    </div>

</body>
</html>
