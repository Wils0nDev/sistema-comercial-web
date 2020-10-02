<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Loyout.Master" AutoEventWireup="true" CodeBehind="frmMantPreventa.aspx.cs" Inherits="VirgenCarmenMantenedor.frmMantPreventa1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="Scripts/DataTable/datatables.min.css" />
    <link rel="stylesheet" href="css/web_general.css" type="text/css" media="screen, projection" />
    <link rel="stylesheet" href="icon/style.css" />
    <link rel="stylesheet" href="Scripts/jqueryui/jquery-ui.min.css" />

    <script src="Scripts/DataTable/datatables.min.js"></script>
    <script src="Scripts/sweetalert.min.js"></script>
    <script src="Scripts/jqueryui/jquery-ui.min.js"></script>
    <script src="Scripts/preventaMant_ajax.js"></script>

    <title>PREVENTA</title>

    <style>
        #anchover{
          width: 65% !important;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container-fluid">
        <!-- CAMPOS PARA LOS FILTROS -->
        <div class="row">
            <div class="box-header">
                <h3 class="box-title">MANTENEDOR DE PREVENTA</h3>
            </div>
            <div class="form-group sub-titulo">
                <h4 class="box-filtros">FILTROS DE BUSQUEDA</h4>
            </div>
            <!-- Zona de filtros -->
            <div class="form-group col-xs-6">
                <label class="col-xs-2 label label-default horizontal" for="id_preventa">Cod. Preventa</label>
                <input type="text" id="id_preventa" class="form-control horizontal" placeholder="Ingesar numero de preventa" />
            </div>
        
            <div class="form-group col-xs-6">
                <label class="col-sm-2 label label-default horizontal " for="id_ruta">Ruta</label>                
                <select class="form-control horizontal" id="id_ruta">
                    <option value = "0"> -Selecinar- </option>
                </select>
            </div>
            <div class="form-group col-xs-6">
                <label class="col-xs-2 label label-default horizontal" for="id_producto">Producto</label>
                <input type="text" id="id_producto" class="form-control horizontal" placeholder="Ingesar sku / nombre producto" />
                <input type="hidden" class="form-control horizontal" id="id_codProducto"/>
            </div>
            <div class="form-group col-xs-6">
                <label class="col-xs-2 label label-default horizontal" for="id_cliente">Cliente</label>
                <input type="text" id="id_cliente" class="form-control horizontal" placeholder="Ingesar Nombre / Numero Documento" />
                <input type="hidden" class="form-control horizontal" id="id_codCliente" value="0" />
            </div>
            <div class="form-group col-xs-6 horizontal">
                <label class="col-sm-2 label label-default horizontal" for="id_vendedor">Vendedor</label>
                <select class="form-control horizontal" id="id_vendedor">
                    <option value = "0"> -Selecinar- </option>
                </select>
            </div>
            <div class="form-group col-xs-6">
                <label class="col-sm-2 label label-default horizontal" for="id_estado">Estado</label>
                <select class="form-control horizontal" id="id_estado">
                    <option value = "0"> -Selecinar- </option>
                </select>
            </div>
            <div class="form-group col-xs-6">
                <label class="col-xs-2 label label-default horizontal" for="id_proveedor">Proveedor</label>
                <select class="form-control horizontal" id="id_proveedor">
                    <option value = "0"> -Selecinar- </option>
                </select>
            </div> 
            <div class="form-group col-xs-6">
                <label class="col-sm-2 label label-default horizontal" for="id_tipo_doc">Tipo Doc.</label>
                <select class="form-control horizontal" id="id_tipo_doc">
                    <option value = "0"> -Selecinar- </option>
                </select>
            </div>
            <!-- div para mostrar mensaje de validacion de fecha de entrega-->
            <div class="row form-group col-xs-12" >
                <div class="col-xs-5 form-group" id="msjFechaE" hidden="">

                </div>
            </div>

            <div class="form-group col-xs-6">
                <label class="col-xs-2 label label-default horizontal"  for="">Fecha Entrega</label>
                <div class='col-xs-4'>
                    <input type="text" class="form-control fEvalidar" id="id_fechaEntregaI" placeholder="Del: dd-mm-yyyy" autocomplete="off"/>
                </div>
                <div class="col-sm-1">
                    <label class=" label label-info"  for="">-</label>
                </div>
                <div class='col-xs-4'>
                    <input type="text" class="form-control fEvalidar" id="id_fechaEntregaF" placeholder="Del: dd-mm-yyyy" autocomplete="off"/>
                </div>
            </div>
            <div class="form-group col-xs-6">
                <label class="col-xs-2 label label-default horizontal" for="id_origen_venta">Origen Venta</label>
                <select class="form-control horizontal" id="id_origen_venta">
                    <option value = "0"> -Selecinar- </option>
                </select>
            </div>
            <!-- div para mostrar mensaje de validacion de fecha de registro-->
            <div class="row form-group col-xs-12" >
                <div class="col-xs-5 form-group" id="msjFechaR" hidden="">

                </div>
            </div>

            <div class="form-group col-xs-6">
                <label class="col-xs-2 label label-default horizontal" for="">Fecha Registro</label>
                <div class="col-xs-4">
                    <input type="text" class="form-control fRvalidar" id="id_fechaRegistroI" placeholder="Del: dd-mm-yyyy" autocomplete="off"/>
                </div>
                <div class="col-sm-1">
                    <label class=" label label-info"  for="">-</label>
                </div>
                <div class=" col-xs-4">
                    <input type="text" class="form-control fRvalidar" id="id_fechaRegistroF" placeholder="Del: dd-mm-yyyy" autocomplete="off"/>
                </div>
            </div>
            <div class="form-group col-xs-6 horizontal">
                <label class="col-sm-2 label label-default horizontal " for="id_tipo_venta">Tipo Venta</label>                
                <select class="form-control horizontal" id="id_tipo_venta">
                    <option value = "0"> -Selecinar- </option>
                </select>
            </div>     
            <div class="form-group">
                <div class="form-group col-xs-6">
                    <h4 class="box-filtros" id="titelpreventa">LISTADO DE PREVENTAS</h4>
                </div>
                <div class="form-group col-xs-6">
                    <button type="button" class="btn btn-primary btn-lg pull-right" id="id_btnBuscar">BUSCAR</button>
                </div>
            </div>
        </div>
        <!-- TABLA DE RESULTADOS DE LOS FILTROS -->
        <div class="row">
            <div class="box-body table-responsive">
                <table id="id_tblPreventa" class="table table-bordered table-hover">
                    <thead>
                        <tr>
                            <th>CODIGO</th> <!-- 0 -->
                            <th>F. REG</th> <!-- 1 -->
                            <th>CLIENTE</th> <!-- 2 -->
                            <th>VENDEDOR</th> <!-- 3 -->
                            <th>TOTAL</th> <!-- 4 -->
                            <th>ESTADO</th> <!-- 5 -->
                            <th>RUTA</th> <!-- 6 -->
                            <th>DIRECCION</th> <!-- 7 -->
                            <th>TVENTA</th> <!-- 8 -->
                            <th>TDOC</th> <!-- 9 -->
                            <th>OVENTA</th> <!-- 10 -->
                            <th>F. ENTR</th> <!-- 11 -->
                            <th>RECARGO</th>  <!-- 12 -->
                            <th>IGV</th> <!-- 13 -->
                            <th>MONEDA</th> <!-- 14 -->
                            <th>ACCION</th> <!-- 15 -->
                            <th>SUCURSAL</th> <!-- 16 -->
                            <th>TIPO PER</th> <!-- 17 -->
                            <th>IDENTIFICACION</th> <!-- 18 -->
                            <th>UBIGEO</th> <!-- 19 -->
                            <th>CODVENDEDOR</th> <!-- 20 -->
                            <th>CODCLIENTE</th> <!-- 21 -->
                            <th>CODPUNTO</th> <!-- 22 -->
                        </tr>
                    </thead>
                    <tbody id="tbl_body_table" class="ui-sortable">
                        
                    </tbody>

                    <tfoot>
                        <tr>
                            <th>CODIGO</th> <!-- 0 -->
                            <th>F. REG</th> <!-- 1 -->
                            <th>CLIENTE</th> <!-- 2 -->
                            <th>VENDEDOR</th> <!-- 3 -->
                            <th>TOTAL</th> <!-- 4 -->
                            <th>ESTADO</th> <!-- 5 -->
                            <th>RUTA</th> <!-- 6 -->
                            <th>DIRECCION</th> <!-- 7 -->
                            <th>TVENTA</th> <!-- 8 -->
                            <th>TDOC</th> <!-- 9 -->
                            <th>OVENTA</th> <!-- 10 -->
                            <th>F. ENTR</th> <!-- 11 -->
                            <th>RECARGO</th>  <!-- 12 -->
                            <th>IGV</th> <!-- 13 -->
                            <th>MONEDA</th> <!-- 14 -->
                            <th>ACCION</th> <!-- 15 -->
                            <th>SUCURSAL</th> <!-- 16 -->
                            <th>TIPO PER</th> <!-- 17 -->
                            <th>IDENTIFICACION</th> <!-- 18 -->
                            <th>UBIGEO</th> <!-- 19 -->
                            <th>CODVENDEDOR</th> <!-- 20 -->
                            <th>CODCLIENTE</th> <!-- 21 -->
                            <th>CODPUNTO</th> <!-- 22 -->
                        </tr>
                    </tfoot>
                </table>
            </div>
        </div>
    </div> <!-- fin container-->

    <!-- VENTANA MODAL PARA VER DETALLE DE LA PREVENTA-->
    <div class="modal fade" id="modalVer" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" id="anchover">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">VER PREVENTA</h5>
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
                                <h4 class="box-filtros">Datos de la Preventa</h4>
                            </div>
                            <div class="row form-group">
                                <label class="label label-default  col-xs-2" for="MVpreventa">Preventa</label>
                                <div class="col-xs-4">
                                    <input type="text" class="form-control " id="MVpreventa" readonly=""/>
                                </div>
                                <label class="label label-default  col-xs-2" for="MVfechar">F. Registro</label>
                                <div class="col-xs-4">
                                    <input type="text" class="form-control " id="MVfechar" readonly=""/>
                                </div>
                            </div>
                                <div class=" row form-group">
                                <label class="label label-default  col-xs-2" for="MVtventa">Tipo Venta</label>
                                <div class="col-xs-4">
                                    <input type="text" class="form-control " id="MVtventa" readonly=""/>
                                </div>
                                <label class="label label-default  col-xs-2" for="MVfechae">F. Entrega</label>
                                <div class="col-xs-4">
                                    <input type="text" class="form-control " id="MVfechae" readonly=""/>
                                </div>
                            </div>
                            <div class="row form-group">
                                <label class="label label-default  col-xs-2" for="MVtdoc">Tipo Doc</label>
                                <div class="col-xs-4">
                                    <input type="text" class="form-control " id="MVtdoc" readonly=""/>
                                </div>
                                <label class="label label-default  col-xs-2" for="MVdescuento">Descuento</label>
                                <div class="col-xs-4">
                                    <input type="text" class="form-control " id="MVdescuento" readonly=""/>
                                </div>
                            </div>
                            <div class="row form-group">
                                <label class="label label-default  col-xs-2" for="MVoventa">Medio</label>
                                <div class="col-xs-4">
                                    <input type="text" class="form-control " id="MVoventa" readonly=""/>
                                </div>
                                <label class="label label-default  col-xs-2" for="MVrecargo">Recargo</label>
                                <div class="col-xs-4">
                                    <input type="text" class="form-control " id="MVrecargo" readonly=""/>
                                </div>
                            </div>
                            <div class="row form-group">
                                <label class="label label-default  col-xs-2" for="MVestado">Estado</label>
                                <div class="col-xs-4">
                                    <input type="text" class="form-control " id="MVestado" readonly=""/>
                                </div>
                                <label class="label label-default  col-xs-2" for="MVigv">IGV</label>
                                <div class="col-xs-4">
                                    <input type="text" class="form-control " id="MVigv" readonly=""/>
                                </div>
                            </div>
                            <div class="row form-group">
                                <label class="label label-default  col-xs-2" for="MVmoneda">Moneda</label>
                                <div class="col-xs-4">
                                    <input type="text" class="form-control " id="MVmoneda" readonly=""/>
                                </div>
                                <label class="label label-default  col-xs-2" for="MVsubtotal">Subtotal</label>
                                <div class="col-xs-4">
                                    <input type="text" class="form-control " id="MVsubtotal" readonly=""/>
                                </div>
                            </div>
                            <div class="row form-group">
                                <label class="label label-default  col-xs-2" >-</label>
                                <div class="col-xs-4">
                                    <input type="text" class="form-control " readonly=""/>
                                </div>
                                <label class="label label-default  col-xs-2" for="MVtotal">Total</label>
                                <div class="col-xs-4">
                                    <input type="text" class="form-control " id="MVtotal" readonly=""/>
                                </div>
                            </div>
                            <!-- Mostrar al carrito -->
                            <div class="form-group">
                                <h4 class="box-filtros">Detalle Preventa</h4>
                            </div>
                            <div class="form-group">
                                <div class="box-body table-responsive">
                                    <table id="id_table_detalle" class="table table-bordered table-hover">
                                        <thead>
                                            <tr>
                                                <th>#</th>
                                                <th>SKU</th>
                                                <th>DESCRIPCION</th>
                                                <th>CANT.</th>
                                                <th>UM</th>
                                                <th>PRECIO</th>
                                                <th>DESC.</th>
                                                <th>TIPO</th>
                                                <th>SUBT.</th>
                                            </tr>
                                        </thead>
                                        <tbody id="tbl_body_table_modal_ver" class="ui-sortable">
                                            
                                        </tbody>
                                        <tfoot>
                                            <tr>
                                                <th>#</th>
                                                <th>SKU</th>
                                                <th>DESCRIPCION</th>
                                                <th>CANT.</th>
                                                <th>UM</th>
                                                <th>PRECIO</th>
                                                <th>DESC.</th>
                                                <th>TIPO</th>
                                                <th>SUBT.</th>  
                                            </tr>
                                        </tfoot>
                                    </table>
                                </div>
                            </div>
                            <!-- Mostrar promociones y descuentos -->
                            <div class="form-group">
                                <h4 class="box-filtros">Datos Adicionales</h4>
                            </div>
                            <div class="form-group col-xs-12">
                                <h5 class="box-filtros">Promociones</h5>
                            </div>
                            <div class="form-group col-xs-12" id="id_promo_detalle">

                            </div>
                            <div class="form-group col-xs-12">
                                <h5 class="box-filtros">Descuento</h5>
                            </div>
                            <div class="form-group col-xs-12" id="id_desc_detalle">

                            </div>
                            <div class="form-group col-xs-12 " id="ancho2">
                                <button type="button" class="btn btn-primary pull-right" data-dismiss="modal" id="btnCancelar">SALIR</button>
                            </div>
                    </div> <!-- Fin container -->
                    
                </div> <!-- Fin Modal Body -->
            </div><!-- Fin Modal content -->
        </div>
    </div>
</asp:Content>
