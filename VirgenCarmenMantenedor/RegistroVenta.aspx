<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Loyout.Master" AutoEventWireup="true" CodeBehind="RegistroVenta.aspx.cs" Inherits="VirgenCarmenMantenedor.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" href="Scripts/DataTable/datatables.min.css" />
    <link rel="stylesheet" href="css/web_general.css" type="text/css" media="screen, projection" />
    <link rel="stylesheet" href="icon/style.css" />
    <link rel="stylesheet" href="Scripts/jqueryui/jquery-ui.min.css" />
    <link rel="stylesheet" href="Scripts/jqueryui/jquery-ui.structure.min.css" />
    <link rel="stylesheet" href="Scripts/jqueryui/jquery-ui.theme.min.css" />
    

    <script src="Scripts/DataTable/datatables.min.js"></script>
    <script type="text/javascript" src="Scripts/jqueryui/jquery-ui.min.js"></script>
    <script src="Scripts/sweetalert.min.js"></script>
    
    <title>Registro de Facturación</title>
    <style>
    .form-group.sub-titulo{
        margin-bottom: 35px;
    }
    .box-header{
        margin-bottom: 50px;
    }

     .ui-autocomplete-loading {
        background: white url("Imagenes/cargar.gif") right center no-repeat;
      }
.ui-menu .ui-menu-item a {
  font-size: 12px;
}
.ui-autocomplete {
    z-index: 215000000 !important;
/*
      position: fixed;
  top: 100%;
  left: 0;
  z-index: 1051 !important;
  float: left;
  display: none;
  min-width: 160px;
  width: 160px;
  padding: 4px 0;
  margin: 2px 0 0 0;
  list-style: none;
  background-color: #ffffff;
  border-color: #ccc;
  border-color: rgba(0, 0, 0, 0.2);
  border-style: solid;
  border-width: 1px;
  -webkit-border-radius: 2px;
  -moz-border-radius: 2px;
  border-radius: 2px;
  -webkit-box-shadow: 0 5px 10px rgba(0, 0, 0, 0.2);
  -moz-box-shadow: 0 5px 10px rgba(0, 0, 0, 0.2);
  box-shadow: 0 5px 10px rgba(0, 0, 0, 0.2);
  -webkit-background-clip: padding-box;
  -moz-background-clip: padding;
  background-clip: padding-box;
  *border-right-width: 2px;
  *border-bottom-width: 2px;
*/
}
      </style>
    <script src='http://cdnjs.cloudflare.com/ajax/libs/bootstrap-validator/0.4.5/js/bootstrapvalidator.min.js'></script>
    <script src="Scripts/Facturacion.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="container-fluid">
        <div class="row">
            <form role="form" id="frmRegistroVenta" onsubmit="return false;">
            <div class="col-xs-12">
                <!-- ESTE SERA EL TITULO GENERAL DEL MANTENEDOR -->
                <div class="box-header">
                    <h3 class="box-title">Registro de venta</h3>
                </div>

                <!-- ESTE SERA EL SUB TITULO GENERAL DE LO QUE SE QUIERE HACER -->
                <div class="form-group sub-titulo">
                    <h4 class="box-filtros">Datos Generales</h4>
                </div>

            </div>

            <div class="form-group col-xs-12">
                     <div class="form-group col-xs-6">
                            <label class="col-sm-2 label label-default horizontal" for="idInput2">Preventa</label>
                            <input type="text" class="form-control horizontal" id="codPreventa" placeholder="Preventa" readonly />
                         <input type="hidden" class="form-control horizontal" id="codSucursal" />
                         <input type="hidden" class="form-control horizontal" id="codPuntoEntrega" />
                        </div>
                    <div class="form-group col-xs-6">
                        <label class="col-sm-2 label label-default horizontal" for="idInput2">F. de entrega</label>
                        <input type="text" class="form-control horizontal" id="fechaEntrega" placeholder="Fecha de entrega" readonly />
                    </div>
                </div>

            <div class="form-group col-xs-12">
                     <div class="form-group col-xs-6">
                            <label class="col-sm-2 label label-default horizontal" for="idInput2">Moneda</label>
                            <input type="text" class="form-control horizontal" id="descMoneda" placeholder="Moneda" readonly />  
                          <input type="hidden" class="form-control horizontal" id="tipMoneda" />  
                        </div>
                    <div class="form-group col-xs-6">
                        <label class="col-sm-2 label label-default horizontal" for="idInput2">Tipo de venta</label>
                        <input type="text" class="form-control horizontal" id="tipVenta" placeholder="Tipo de venta" readonly />
                        <input type="hidden" class="form-control horizontal" id="codTipVenta"  />
                    </div>
                </div>

            <div class="form-group col-xs-12">
                     <div class="form-group col-xs-6">
                            <label class="col-sm-2 label label-default horizontal" for="idInput2">Doc. Venta</label>
                            <input type="text" class="form-control horizontal" id="docVenta" placeholder="Tipo de documento de venta" readonly />                          
                            <input type="hidden" class="form-control horizontal" id="codDocVenta"  />     
                     </div>
                </div>

            <div class="form-group col-xs-12">
                     <div class="form-group col-xs-12">
                            <label class="col-sm-2 label label-default horizontal" for="idInput2">Cliente</label>
                            <input type="text" class="form-control horizontal" id="nomCliente" placeholder="Cliente"  readonly/>    
                            <input type="hidden" class="form-control horizontal" id="codCliente"  />    
                        </div>
                </div>

            <div class="form-group col-xs-12">
                     <div class="form-group col-xs-12">
                            <label class="col-sm-2 label label-default horizontal" for="idInput2">Vendedor</label>
                            <input type="text" class="form-control horizontal" id="nomVendedor" placeholder="Vendedor" readonly />  
                            <input type="hidden" class="form-control horizontal" id="codVendedor"  />
                        </div>
                </div>


            <div class="col-xs-12">
                <!-- ESTE SERA EL TITULO GENERAL DEL MANTENEDOR -->

                <!-- ESTE SERA EL SUB TITULO GENERAL DE LO QUE SE QUIERE HACER -->
                <div class="form-group sub-titulo">
                    <h4 class="box-filtros">Pago</h4>
                </div>

            </div>

            <div class="form-group col-xs-12" id="groupFechaPago">
                     <div class="form-group col-xs-6">
                            <label class="col-sm-4 label label-default horizontal" for="idInput2">Fecha de pago</label>
                             <div class="col-xs-7">
                                 <input type="text" id="fecCompromiso" class="form-control" placeholder="dd/mm/yyyy" />
                                 <div class="invalid-feedback ocultar" id="valFecha" >
                                  Ingrese fecha de pago.
                                </div>
                             </div>
                        </div>
                </div>

           

            <div class="form-group col-xs-12">
                     <div class="form-group col-xs-12">
                            <button type="submit" class="btn btn-primary pull-right" id="btnGuardarVenta">Registrar Venta</button>                        
                        </div>
                </div>

           </form>

            <div class="box-body table-responsive col-xs-12">
                <table id="idDateTablProducto" class="table table-bordered table-hover">

                    <thead>
                        <tr>
                            <th scope="col">CÓDIGO</th>
                            <th scope="col">DESCRIPCIÓN</th>
                            <th scope="col">CANTIDAD</th>
                            <th scope="col">UNIDAD</th>                         
                            <th scope="col">TIPO</th>
                            <th scope="col">DESCUENTO</th>
                            <th scope="col">PRECIO</th>
                            <th scope="col">IMPORTE</th>
                        </tr>
                    </thead>
                    <tbody id="tbl_body_table_2" class="ui-sortable">
                        <!--
                        <tr role="row" class="odd ui-sortable-handle">
                            <td>1</td>
                            <td>LA VICTORIA</td>
                            <td>Wilson Vasquez Coronado</td>
                            <td>LA VICTORIA</td>
                            <td>LA VICTORIA</td>
                            <td>LA VICTORIA</td>
                            <td>LA VICTORIA</td>
                            
                        </tr>
                        <tr role="row" class="even ui-sortable-handle">
                            <td>2</td>
                            <td>MON-MOT</td>
                            <td>Wilson Vasquez Coronado</td>
                            <td>MONSEFU - MOTUPE</td>
                            <td>LA VICTORIA</td>
                            <td>LA VICTORIA</td>
                            <td>LA VICTORIA</td>
                            
                        </tr>
                        -->
                    </tbody>
                    <!-- aqui traeremos la data por medio de ajax -->
                    <tfoot>
                        <tr>
                            <th scope="col">CÓDIGO</th>
                            <th scope="col">DESCRIPCIÓN</th>
                            <th scope="col">CANTIDAD</th>
                            <th scope="col">UNIDAD</th>                       
                            <th scope="col">TIPO</th>
                            <th scope="col">DESCUENTO</th>
                            <th scope="col">PRECIO</th>
                            <th scope="col">IMPORTE</th>

                        </tr>
                    </tfoot>
                </table>

            </div>


            <!-- MOSTRAR TOTAL -->
            <div class="form-group col-xs-12">
                <div class="form-group col-xs-9"></div>
                <div class="form-group col-xs-3">
                    <label class="col-xs-4 label label-default horizontal" for="idInput2">Subtotal</label>   
                    <div class="form-group col-xs-7">
                                <input type="text" class="form-control horizontal" id="montoSubtotal" placeholder="Subtotal" readonly />                          
                            </div>
                </div>
            </div>

            <div class="form-group col-xs-12">
                <div class="form-group col-xs-9"></div>
                <div class="form-group col-xs-3">
                    <label class="col-xs-4 label label-default horizontal" for="idInput2">Descuento</label>   
                    <div class="form-group col-xs-7">
                                <input type="text" class="form-control horizontal" id="montoDescuento" placeholder="Descuento" readonly />                          
                            </div>
                </div>
            </div>

            <div class="form-group col-xs-12">
                <div class="form-group col-xs-9"></div>
                <div class="form-group col-xs-3">
                    <label class="col-xs-4 label label-default horizontal" for="idInput2">Recargo</label>   
                    <div class="form-group col-xs-7">
                                <input type="text" class="form-control horizontal" id="montoRecargo" placeholder="Recargo" readonly />                          
                            </div>
                </div>
            </div>

            <div class="form-group col-xs-12">
                <div class="form-group col-xs-9"></div>
                <div class="form-group col-xs-3">
                    <label class="col-xs-4 label label-default horizontal" for="idInput2">IGV</label>   
                    <div class="form-group col-xs-7">
                                <input type="text" class="form-control horizontal" id="montoIGV" placeholder="IGV" readonly />                          
                            </div>
                </div>
            </div>

            <div class="form-group col-xs-12">
                <div class="form-group col-xs-9"></div>
                <div class="form-group col-xs-3">
                    <label class="col-xs-4 label label-default horizontal" for="idInput2">Total</label>   
                    <div class="form-group col-xs-7">
                                <input type="text" class="form-control horizontal" id="montoTotal" placeholder="Total" readonly />                          
                            </div>
                </div>
            </div>


        </div>
    </div>

    










    <!-- Modal -->
    <div class="modal fade" id="modalFiltroFactura" data-backdrop="static" data-keyboard="false" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Buscar Preventa</h5>
                    <!--
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    -->
                    <div class="form-group" id="Mmensaje">
                        <p id="Mpmensaje"></p>
                    </div>
                </div>
                <div class="modal-body">
                    <form role="form" class="frmBuscarPreventa" onsubmit="return false;">
                        <div class="form-group">
                            <label for="inputName">Código</label>
                            <!--
                            <input type="hidden" class="form-control" id="McodOrden" disabled="disabled" />
                            <input type="hidden" class="form-control" id="McodVendedor" disabled="disabled" />
                            <input type="hidden" class="form-control" id="MRutaAnterior" disabled="disabled" />
                            -->
                            <input type="text" class="form-control" id="mdCodigo" />
                        </div>
                        <div class="form-group">
                            <label for="mdVendedor">Vendedor</label>
                            <select class="form-control" id="mdVendedor">
                                <option value="">Selecciona una opcion</option>

                            </select>
                        </div>
                        <div class="form-group">
                            <label for="mdCliente">Cliente</label>
                              <input type="hidden" id="mdcodCliente" name="mdcodCliente" value="0" />
                            <input type="text" class="form-control" id="mdCliente"  />

                        </div>

                        <div class="form-group ">
                            <label for="mdmin-date">Rango de fecha</label>
                            </div>

                        <div class="form-group  row">
                            <div class="col-xs-6">
                                <input type="text" id="mdmin-date" class="form-control" placeholder="Desde: dd-mm-yyyy" />
                            </div>
                            <div class="col-xs-6">
                                <input type="text" id="mdmax-date" class="form-control" placeholder="Hasta: dd-mm-yyyy" />
                            </div>
                            
                        </div>
                        <br>
                        <div class="form-group row">
                            <button type="submit" class="btn btn-primary pull-right" id="btnBuscarPreventa">Buscar</button>
                            </div>
                        <br>

                        

                        
                    </form>


                    <div class="row">
            <div class="box-body table-responsive">
                <table id="idDateTablPreventasModal" class="table table-bordered table-hover">

                    <thead>
                        <tr>
                            <th scope="col">CÓDIGO</th>
                            <th scope="col">CLIENTE</th>
                            <th scope="col">VENDEDOR</th>
                            <th scope="col">IMPORTE</th>                         
                            <th scope="col">ACCION</th>
                            <th scope="col">TIPO DE MONEDA</th> 
                            <th scope="col">MONEDA</th> 
                            <th scope="col">CODIGO DE VENDEDOR</th> 
                            <th scope="col">VENDEDOR</th> 
                            <th scope="col">CODIGO DE CLIENTE</th> 
                            <th scope="col">CLIENTE</th> 
                            <th scope="col">TIPO DE VENTA</th> 
                            <th scope="col">DOCUMENTO DE VENTA DE VENTA</th> 
                            <th scope="col">FECHA DE ENTREGA</th> 
                            <th scope="col">RECARGO</th> 
                            <th scope="col">IGV</th> 
                            <th scope="col">TOTAL</th> 
                            <th scope="col">TIPO DE VENTA</th> 
                            <th scope="col">CODIGO DE SUCURSAL</th>
                            <th scope="col">CODIGO TIPO DE DOCUMENTO</th>
                            <th scope="col">CODIGO PUNTO DE ENTREGA</th>
                        </tr>
                    </thead>
                    <tbody id="tbl_body_table" class="ui-sortable">
                       
                    </tbody>
                    <!-- aqui traeremos la data por medio de ajax -->
                    <tfoot>
                        <tr>
                            <th scope="col">CÓDIGO</th>
                            <th scope="col">CLIENTE</th>
                            <th scope="col">VENDEDOR</th>
                            <th scope="col">IMPORTE</th>                       
                            <th scope="col">ACCION</th>
                            <th scope="col">TIPO DE MONEDA</th> 
                            <th scope="col">MONEDA</th> 
                            <th scope="col">CODIGO DE VENDEDOR</th> 
                            <th scope="col">VENDEDOR</th> 
                            <th scope="col">CODIGO DE CLIENTE</th> 
                            <th scope="col">CLIENTE</th> 
                            <th scope="col">TIPO DE VENTA</th> 
                            <th scope="col">DOCUMENTO DE VENTA DE VENTA</th> 
                            <th scope="col">FECHA DE ENTREGA</th> 
                            <th scope="col">RECARGO</th> 
                            <th scope="col">IGV</th> 
                            <th scope="col">TOTAL</th> 
                            <th scope="col">TIPO DE VENTA</th> 
                            <th scope="col">CODIGO DE SUCURSAL</th>
                            <th scope="col">CODIGO TIPO DE DOCUMENTO</th>
                            <th scope="col">CODIGO PUNTO DE ENTREGA</th>
                        </tr>
                    </tfoot>
                </table>

            </div>
        </div>

                    <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal" id="btnCancelar">Cancelar</button>
                        </div>

                </div>

            </div>
        </div>
    </div>
</asp:Content>
