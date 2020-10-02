<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Loyout.Master" AutoEventWireup="true" CodeBehind="registrarpreventa.aspx.cs" Inherits="VirgenCarmenMantenedor.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <link rel="stylesheet" href="Scripts/DataTable/datatables.min.css" />
    <link rel="stylesheet" href="css/web_general.css" type="text/css" media="screen, projection" />
    <link rel="stylesheet" href="css/preventa.css" type="text/css" media="screen, projection" />
    <link rel="stylesheet" href="icon/style.css" />
    <link rel="stylesheet" href="Scripts/jqueryui/jquery-ui.min.css" />

    <script src="Scripts/DataTable/datatables.min.js"></script>
    <script src="Scripts/sweetalert.min.js"></script>
    <script src="Scripts/Plantilla.js"></script>

    <script src="Scripts/jqueryui/jquery-ui.min.js"></script>
    <script src="Scripts/preventa_ajax.js"></script>
    <style>
      .ui-autocomplete-loading {
        background: white url("Imagenes/cargar.gif") right center no-repeat;
      }
      </style>
    <title>REGISTRAR PREVENTA</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-xs-12">
                <div class="box-header">
                    <h3 class="box-title" id="tituloMant">REGISTRAR PREVENTA</h3>
                </div>
                <div class="form-group">
                    <h4 class="box-filtros">Datos del vendedor</h4>
                </div>

                <!-- Formulario para registrar -->
                <form class="form-horizontal" id="formulario" name="formulario">
                    <!-- Datos del vendedor -->
                    <div class="form-group col-xs-12">
                        <div class="form-group col-xs-6">
                            <label class="label col-sm-2 label-default horizontal " id="label_vendedor" for="id_vendedor">Vendedor</label>
                            <select class="form-control horizontal" id="id_vendedor">
                                <option value="0">Selecionar vendedor</option>
                            </select>
                        </div>

                        <div class="form-group col-xs-3">
                            <label class="label col-sm-2 label-default horizontal" id="label_ruta" for="">Ruta</label>
                            <input type="text" class="form-control horizontal" id="" disabled="" value="Oficina Chiclayo"/>
                        </div>
                    </div>

                    <div class="form-group col-xs-12">
                        <h4 class="box-filtros">Datos de Venta</h4>
                    </div>
                    <div class="form-group col-xs-12">
                        <div class="form-group col-xs-3">
                            <label class="label label-default horizontal col-sm-3" id="label_tipoventa" for="">T. Venta</label>
                            <label class="radio-inline">
                                <input type="radio" name="radio_tipo_venta" id="id_contado" value="1" checked />
                                Contado
                            </label>
                            <label class="radio-inline">
                                <input type="radio" name="radio_tipo_venta" id="id_credito" value="2" />
                                Credito
                            </label>
                        </div>
                        <div class="form-group col-xs-3">
                            <label class="col-sm-4 label label-default horizontal" id="label_documento" for="">Documento</label>
                            <label class="radio-inline">
                                <input type="radio" name="radio_doc" id="id_boleta" value="1" checked/>
                                Boleta
                            </label>
                            <label class="radio-inline">
                                <input type="radio" name="radio_doc" id="id_factura" value="2" />
                                Factura
                            </label>
                        </div>
                        <div class="form-group col-xs-3">
                            <label class="col-sm-4 label label-default horizontal" id="labelfecha" for="">F. Entrega</label>
                            <div class='input-group date' id=''>
                                <input type='text' class="form-control" id='id_fecha'/>
                            </div>
                        </div>
                        <div class="form-group col-xs-2">
                            <label class="col-sm-6 label label-default horizontal" id="labelhora" for="">H. Entrega</label>
                            <input type="number" class="form-control " id="id_hora" value="06" />
                        </div>
                        <div class="form-group col-xs-1">
                            <input type="number" class="form-control " id="id_minu" value="00"/>
                        </div>
                    </div>

                    <!-- Datos del cliente -->
                    <div class="form-group col-xs-12">
                        <h4 class="box-filtros">Datos del Cliente</h4>
                    </div>
                    
                    <div class="form-group col-xs-12">
                        
                        <div class="form-group col-xs-3 ">
                            <label class="label col-sm-3 label-default horizontal " for="id_nomCliente">Cliente</label>
                            <input type="text" class="form-control horizontal" id="id_documento" placeholder="Numero Documento" disabled/>
                        </div>
                        <div class="form-group col-xs-7 ">
                            <input type="text" class="form-control horizontal " id="id_nomCliente" placeholder="Nombre / Numero Documento"/>
                            <input type="hidden" class="form-control horizontal" id="id_codCliente" />
                            <input type="hidden" class="form-control horizontal" id="id_tipoListaPrecio" />
                        </div>
                    </div>

                    <div class="form-group col-xs-12">
                        <div class="form-group col-xs-5">
                            <label  class="col-sm-4 label label-default horizontal" for="id_puntoEntrega">Direccion Entrega</label>
                            <select class="form-control horizontal " id="id_puntoEntrega">
                                <option value="0">Seleccionar Ruta</option>
                            </select>
                        </div>
                    </div>

                    
                    <!-- Datos del producto -->
                    <div class="form-group col-xs-12">
                        <h4 class="box-filtros">Datos del Producto</h4>
                    </div>
                    <div class="form-group col-xs-12">
                        
                        <div class="form-group col-xs-3">
                            <label  class="col-sm-4 label label-default horizontal" for="id_desProducto">Producto</label>
                            <input type="text" class="form-control horizontal" id="id_codProducto" placeholder="Codigo" disabled/>
                        </div>
                        <div class="form-group col-xs-4">
                            <input type="text" class="form-control horizontal" id="id_desProducto" placeholder="Descripcion / Codigo" disabled/>
                            <input type="hidden" class="form-control horizontal" id="id_tipoProducto" />
                        </div>
                    </div>
                    
                    <div class="form-group col-xs-12">
                        <div class="form-group col-xs-2">
                            <label  class="col-sm-5 label label-default horizontal" id="lavelStock" for="">Stock:</label>
                            <input type="text" class="form-control horizontal" disabled="" id="id_stock" placeholder="0"/>
                        </div>
                        <div class="form-group col-xs-2">
                            <label  class="col-sm-5 label label-default horizontal" id="labelPrecio" for="">Precio:</label>
                            <input type="text" class="form-control horizontal" disabled="" id="id_precio" placeholder="0.0"/>
                        </div>
                        <div class="form-group col-xs-3">
                            <label  class="col-sm-4 label label-default horizontal" id="labelAlmacen" for="id_almacen">Almacen:</label>
                            <select class="form-control horizontal" id="id_almacen">
                                <option value="0">Seleccionar</option>
                            </select>
                        </div>
                        <div class="form-group col-xs-3">
                            <label  class="col-sm-4 label label-default horizontal" id="labelUnidad" for="">Unidad:</label>
                            <select class="form-control horizontal" id="id_unidad">
                                <option value="0">Seleccionar</option>
                            </select>
                        </div>
                        <div class="form-group col-xs-2">
                            <label  class="col-sm-6 label label-default horizontal" id="labelCantidad" for="">Cantidad:</label>
                            <input type="number" class="form-control" id="id_cantidad" value ="1"/>
                        </div>
                    </div>

                    <!-- Promociones y descuentos -->
                    <div class="form-group col-xs-12">
                        <h4 class="box-filtros">Promociones</h4>
                        <div class="form-group col-xs-12" id="promos" >
                        </div>

                        <br>
                        <h4 class="box-filtros">Descuentos</h4>
                        <div class="form-group col-xs-12" id="dsctos" >
                        </div>
                    </div>
                    <!--
                    <div class="form-group col-xs-12">
                        <h5 class="box-filtros">Promociones</h5>
                    </div>
                    <div class="form-group col-xs-12">
 
                        <div class=" col-xs-12">
                            <label class="radio">
                                <input type="radio" name="radio_tipo_promo"  id="inlineRadio6" value="option1"/>
                                Por la compra de 24 unidades o mas, recibira 3 galletas mas.
                            </label>
                            <label class="radio">
                                <input type="radio" name="radio_tipo_promo" id="inlineRadio7" value="option2" />
                                Por la compra de 120 unidades o mas, recibira 20 galletas mas.
                            </label>
                        </div>
                    </div>
                    <div class="form-group col-xs-12">
                        <h5 class="box-filtros">Descuentos</h5>
                    </div>
                    <div class=" col-xs-12">
                        <label class="radio">
                            <input type="radio" name="radio_tipo_desc"  id="inlineRadio8" value="option1"/>
                            Por la compra de 24 unidades o mas, recibira 5%. de descuento.
                        </label>
                        <label class="radio">
                            <input type="radio" name="radio_tipo_desc" id="inlineRadio9" value="option2" />
                            Por la compra de 120 unidades o mas, recibira 15%. de descuento.
                        </label>
                    </div>
                    -->
                    <!-- Agregar al carrito -->
                    <div class="form-group col-xs-12">
                        <button type="button" id="id_btnAgregar" class="btn btn-primary">AGREGAR PRODUCTO</button>
                    </div>

                    <div class="form-group col-xs-12">
                        <div class="box-body table-responsive">
                            <table id="id_carrito" class="table table-bordered table-hover">
                                <thead>
                                    <tr>
                                        <th scope="col">ITEM</th>
                                        
                                        <th scope="col">CODIGO</th>
                                        <th scope="col">DESCRIPCION</th>

                                        <th scope="col">CANTIDAD</th>
                                        <th scope="col">CANTIDADUNIDADBASE</th>

                                        <th scope="col">PRECIO</th>
                                        
                                        <th scope="col">ALMACEN</th>    
                                        <th scope="col">CODALMACEN</th>    
                                        
                                        <th scope="col">UNIDAD</th>
                                        <th scope="col">CODPRESENTACION</th>
                                        
                                        <th scope="col">SUBTOTAL</th>
                                        
                                        <th scope="col">TIPO</th>
                                        <th scope="col">CODIGOTIPOPRODUCTO</th>

                                        <th scope="col">ACCION</th>
                                    </tr>
                                </thead>
                                <tbody id="tbl_body_table" class="ui-sortable">
                                </tbody>
                            </table>
                        </div>
                    </div>

                <!-- Descuento por Preventa -->
                    <div class="form-group col-xs-12">
                        
                        <div class="form-group col-xs-2">
                                
                            </div>
                            <div class="form-group col-xs-2">
                                <label  class="col-sm-4 label label-default horizontal " id="labelsubtotal" for="">SubTotal:</label>
                                <input type="text" class="form-control horizontal col-sm-1 grupo" id="id_subtotal" disabled="" placeholder="0.00" />
                            </div>
                            <div class="form-group col-xs-2">
                                 <label  class="col-sm-4 label label-default horizontal " id="labelrecargo" for="">Recargo:</label>
                                <input type="text" class="form-control horizontal col-sm-2" id="id_recargo" disabled="" placeholder="0.00"/>
                            </div>
                            <div class="form-group col-xs-2">
                                <label  class="col-sm-3 label label-default horizontal " id="labeldesc" for="">Desc:</label>              
                                <input type="text" class="form-control horizontal col-sm-2" id="id_descuento" disabled="" placeholder="0.00"/>
                            </div>
                            <div class="form-group col-xs-2">
                                <label  class="col-sm-3 label label-default horizontal " id="labeligv" for="">IGV:</label>                                
                                <input type="text" class="form-control horizontal col-sm-2" id="id_igv" disabled="" placeholder="0.00"/>
                            </div>
                            <div class="form-group col-xs-2">
                                <label  class="col-sm-3 label label-default horizontal " id="labeltotal" for="">TOTAL:</label> 
                                <input type="text" class="form-control horizontal col-sm-2" id="id_total" disabled="" placeholder="0.00"/>
                            </div>
                            
                        
                    </div>
                    <div class="form-group col-xs-12">
                        <input type="checkbox" class="horizontal col-sm-1 " id="id_flag_recargo" disabled=""/> Aplicar recargo por venta al credito
                    </div>

                    <div class="row text-right">
                         <button type="button" class="btn btn-default" data-dismiss="modal" id="btnCancelar">CANCELAR</button>
                         <button type="button" class="btn btn-primary" id="btnGuardar">GUARDAR</button>
                    </div>

                </form>

            </div>
        </div>
    </div> <!-- Fin container -->

    <!-- Modal -->
    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Editar Producto</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    <div class="form-group" id="Mmensaje">
                        <p id="Mpmensaje"></p>
                    </div>
                </div>
                <div class="modal-body">
                    <form role="form" onsubmit="return false;">
                        <div class="form-group">
                            <label for="inputName">Producto</label>
                            <input type="text" class="form-control" id="id_codProM" disabled="disabled" />
                            <input type="text" class="form-control" id="id_desProM" disabled="disabled" />
                        </div>
                        <div class="form-group">
                            <label for="inputName">Precio</label>
                            <input type="text" class="form-control" id="id_preProM" disabled="disabled" />
                        </div>
                        <div class="form-group">
                            <label for="inputName">Stock</label>
                            <input type="text" class="form-control" id="id_stoProM" disabled="disabled" />
                        </div>
                        <div class="form-group">
                            <label for="inputName">Almacen</label>
                            <select class="form-control" id="id_almProM">
                                <option value="">Seleccionar</option>
                            </select>
                        </div>
                        <div class="form-group">
                            <label for="inputName">Unidad</label>
                            <select class="form-control" id="id_uniProM">
                                <option value="">Seleccionar</option>
                            </select>
                        </div>
                        <div class="form-group">
                            <label for="inputName">Cantidad</label>
                            <input type="number" class="form-control" id="id_canProM"/>
                        </div>
                        
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal" id="btnCancelarM">Cancelar</button>
                            <button type="button" class="btn btn-primary" data-dismiss="modal" id="btnGuardarM">Guardar</button>
                        </div>
                    </form>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
