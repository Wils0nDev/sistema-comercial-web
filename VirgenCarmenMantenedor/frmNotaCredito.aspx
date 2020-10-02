<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Loyout.Master" AutoEventWireup="true" CodeBehind="frmNotaCredito.aspx.cs" Inherits="VirgenCarmenMantenedor.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" href="Scripts/DataTable/datatables.min.css" />
    <link rel="stylesheet" href="css/web_general.css" type="text/css" media="screen, projection" />
    <link rel="stylesheet" href="css/notacredito.css" type="text/css" media="screen, projection" />
    <link rel="stylesheet" href="icon/style.css" />
    <link rel="stylesheet" href="Scripts/jqueryui/jquery-ui.min.css" />

    <script src="Scripts/DataTable/datatables.min.js"></script>
    <script src="Scripts/sweetalert.min.js"></script>
    <script src="Scripts/Plantilla.js"></script>

    <script src="Scripts/jqueryui/jquery-ui.min.js"></script>
    <script src="Scripts/notacredito_ajax.js"></script>
    <style>
      .ui-autocomplete-loading {
        background: white url("Imagenes/cargar.gif") right center no-repeat;
      }
      </style>
    <title>NOTA DE CREDITO</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-xs-12">
                <div class="box-header">
                    <h3 class="box-title">NOTA DE CREDITO</h3>
                </div>
                <div class="form-group">
                    <h4 class="box-filtros">DATOS DE VENTA</h4>
                </div>

                <form class="form-horizontal" id="formNC" name="formNC">
                    <div class="form-group col-xs-12">
                        
                        <div class="form-group col-xs-3">
                            <label class="label col-sm-3 label-default horizontal " id="l_codventa" for="id_codventa">Codigo</label>
                            <input type="text" class="form-control horizontal" id="id_codventa" disabled />
                        </div>
                        <div class="form-group col-xs-3">
                            <label class="label col-sm-3 label-default horizontal " id="l_tipocambio" for="id_tipocambio">T.Cambio</label>
                            <input type="text" class="form-control horizontal" id="id_tipocambio" disabled />
                        </div>
                        <div class="form-group col-xs-3">
                            <label class="label col-sm-3 label-default horizontal " id="l_serie" for="id_serie">Serie</label>
                            <input type="text" class="form-control horizontal" id="id_serie" disabled />
                        </div>
                        <div class="form-group col-xs-3">
                            <label class="label col-sm-3 label-default horizontal " id="l_numero" for="id_numero">Numero</label>
                            <input type="text" class="form-control horizontal" id="id_numero" disabled />
                        </div>
                        
                    </div>

                    <div class="form-group col-xs-12">

                        <div class="form-group col-xs-6">
                            <label class="label col-sm-2 label-default horizontal " id="l_cliente" for="id_cliente">Cliente</label>
                            <input type="text" class="form-control horizontal" id="id_cliente" disabled />
                        </div>
                        <div class="form-group col-xs-6">
                            <label class="label col-sm-2 label-default horizontal " id="l_vendedor" for="id_vendedor">Vendedor</label>
                            <input type="text" class="form-control horizontal" id="id_vendedor" disabled />
                        </div>
                        

                    </div>

                    <div class="form-group col-xs-12">
                        <h4 class="box-filtros">DATOS NOTA CREDITO</h4>
                    </div>

                    <div class="form-group col-xs-12">

                        <div class="form-group col-xs-6">
                            <label class="label col-sm-2 label-default horizontal " id="l_motivo" for="id_motivo">Motivo</label>
                            <select class="form-control horizontal" id="id_motivo">
                                <option value="0">Selecionar motivo</option>
                            </select>
                        </div>
                        <div class="form-group col-xs-3">
                            <label class="label col-sm-3 label-default horizontal " id="l_importe" for="id_importe">Importe</label>
                            <input type="text" class="form-control horizontal" id="id_importe" disabled value="0.00"/>
                        </div>

                    </div>

                    <h4 class="box-filtros">PRODUCTOS</h4>
                    <div class="form-group col-xs-12">
                        <label class="label col-sm-4 label-default horizontal " id="l_l" for="">Leyenda: </label>
                        <label class="label col-sm-4 label-default horizontal " id="l_1" for="">No disponible</label>
                        <label class="label col-sm-4 label-default horizontal " id="l_2" for="">Eliminado</label>
                        <label class="label col-sm-4 label-default horizontal " id="l_3" for="">Modificado</label>
                        <label class="label col-sm-4 label-default horizontal " id="l_4" for="">Sin cambios</label>
                    </div>
                    <div class="form-group col-xs-12">
                        <div class="box-body table-responsive">
                            <table id="id_carrito_venta" class="table table-bordered table-hover">
                                <thead>
                                    <tr>
                                        <th scope="col">ITEM</th>
                                        
                                        <th scope="col">CODIGO</th>
                                        <th scope="col">DESCRIPCION</th>

                                        <th scope="col">CANT FINAL</th>
                                        
                                        <th scope="col">CANT DIS. ORI</th>
                                        <th scope="col">CANT ORIGINAL</th>
                                        <th scope="col">CANT UB.</th>

                                        <th scope="col">PRECIO</th>
                                        <th scope="col">DSCTO</th>
                                        
                                        <th scope="col">ALMACEN</th>    
                                        
                                        <th scope="col">UNIDAD</th>
                                        
                                        <th scope="col">SUBTOTAL</th>
                                        
                                        <th scope="col">TIPO</th>

                                        <th scope="col">CANT DEVUELTOS</th>

                                        <th scope="col">ACCION</th>
                                        <th scope="col">FLAG</th>
                                    </tr>
                                </thead>
                                <tbody id="tbl_body_table" class="ui-sortable">
                                </tbody>
                            </table>
                        </div>
                    </div>
                    

                    <div class="form-group col-xs-12">
                        <div class="form-group col-xs-2">
                            <label class="label col-sm-4 label-default horizontal " id="l_subtotal" for="id_subtotal">SubTotal</label>
                            <input type="text" class="form-control horizontal" id="id_subtotal" disabled />
                        </div>
                        <div class="form-group col-xs-2">
                            <label class="label col-sm-4 label-default horizontal " id="l_recargo" for="id_recargo">Recargo</label>
                            <input type="text" class="form-control horizontal" id="id_recargo" disabled />
                        </div>
                        <div class="form-group col-xs-2">
                            <label class="label col-sm-3 label-default horizontal " id="l_descuento" for="id_descuento">Descto</label>
                            <input type="text" class="form-control horizontal" id="id_descuento" disabled />
                        </div>
                        <div class="form-group col-xs-2">
                            <label class="label col-sm-3 label-default horizontal " id="l_igv" for="id_igv">IGV</label>
                            <input type="text" class="form-control horizontal" id="id_igv" disabled />
                        </div>
                        <div class="form-group col-xs-2">
                            <label class="label col-sm-3 label-default horizontal " id="l_total" for="id_total">Total</label>
                            <input type="text" class="form-control horizontal" id="id_total" disabled />
                        </div>
                    </div>
                    
                    <div class="row text-right">
                         <button type="button" class="btn btn-default" data-dismiss="modal" id="btnCancelar">CANCELAR</button>
                         <button type="button" class="btn btn-primary" id="btnGuardar">GUARDAR</button>
                         <br>
                        <br>
                    </div>

                </form>

            </div>
        </div>
    </div> 

    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <form role="form" onsubmit="return false;">
                    
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Buscar Venta</h5>
                    </div>
                    <div class="modal-body ">
                        <div class="form-group ">
                            <label class="label col-sm-2 label-default horizontal " id="l_codigoventa_m" for="id_codigoventa_m">Codigo Venta</label>
                            <input type="text" class="form-control horizontal" id="id_codigoventa_m" />
                        </div>
                        
                        <div class="form-group row">
                            <label class="label col-sm-2 label-default horizontal " id="l_serie_m" for="id_serie_m">Documento</label>
                            
                            <div class="col-xs-4">
                                <input type="text" class="form-control horizontal" id="id_serie_m" placeholder="Serie"/>
                            </div>
                            <div class="col-xs-4">
                                <input type="text" class="form-control horizontal" id="id_numero_m" placeholder ="Numero"/>
                                <br>
                            </div>
                        </div>

                        <div class="form-group row">
                            <label class="label col-sm-2 label-default horizontal " id="l_fechas_m" for="id_fechainicio_m">Fechas</label>
                            
                            <div class="col-xs-4">
                                <input type="text" class="form-control horizontal" id="id_fechainicio_m" placeholder="Fecha Inicio"/>
                            </div>
                            <div class="col-xs-4">
                                <input type="text" class="form-control horizontal" id="id_fechafin_m" placeholder="Fecha Fin" />
                                <br>
                            </div>
                        </div>
                        
                        <div class="form-group ">
                            <label class="label col-sm-2 label-default horizontal " id="l_cliente_m" for="id_cliente_m">Cliente</label>
                            <input type="text" class="form-control horizontal" id="id_cliente_m" placeholder="Numero Documento / Nombre" />
                            <input type="hidden" class="form-control horizontal" id="id_codcliente_m" />
                        </div>
                        
                        <div class="form-group ">
                            <label class="label col-sm-2 label-default horizontal " id="l_vendedor_m" for="id_vendedor_m">Vendedor</label>
                            <select class="form-control horizontal" id="id_vendedor_m">
                                <option value="0">Selecionar vendedor</option>
                            </select>
                        </div>

                        <div class="form-group text-right">
                            <button type="button" class="btn btn-primary" id="btnbuscar_m">Buscar</button>
                        </div>

                        <div class="box-body table-responsive">
                            <table id="id_venta_m" class="table table-bordered table-hover">
                                <thead>
                                    <tr>
                                        <th scope="col">CODIGO</th>

                                        <th scope="col">CLIENTE</th>

                                        <th scope="col">ACCION</th>
                                    </tr>
                                </thead>
                                <tbody id="tbl_body_table_modal" class="ui-sortable">
                                </tbody>
                            </table>
                        </div>

                        <div class="form-group text-right">
                            <button type="button" class="btn btn-default" id="btncancelar_m">Cancelar</button>
                        </div>
                        
                        
                    </div>
                </form>
            </div>
        </div>
    </div>

    <!--modal editar producto-->
    <div class="modal fade" id="ModalEditProduct" tabindex="-1" role="dialog" aria-labelledby="exampleModalEditProduct" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <form role="form" onsubmit="return false;">
                    
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalEditProduct">Editar Cantidad Producto</h5>
                    </div>
                    <div class="modal-body ">
                        <div class="form-group row">
                            <label class="label col-sm-2 label-default horizontal " id="l_original_m_p" for="id_original_m_p">Cant.Dispo.</label>
                            <div class="col-xs-3">
                                <input type="text" class="form-control horizontal" id="id_original_m_p" disabled/>
                            </div>
                            <label class="label col-sm-2 label-default horizontal " id="l_cantidad_m_p" for="id_cantidad_m_p">Cant.Final</label>
                            <div class="col-xs-3">
                                <input type="number" class="form-control horizontal" id="id_cantidad_m_p" />
                                <input type="hidden" class="form-control horizontal" id="id_producto_m_p" />
                                <br>
                            </div>
                        </div>
                        
                        <div class="form-group text-right">
                            <button type="button" class="btn btn-default" data-dismiss="modal" id="id_btncancelar_m_p">CANCELAR</button>
                            <button type="button" class="btn btn-primary" id="id_btnguardar_m_p">GUARDAR</button>
                        </div>
                                                
                    </div>
                </form>
            </div>
        </div>
    </div>


</asp:Content>
