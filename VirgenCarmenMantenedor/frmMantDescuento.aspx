<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Loyout.Master" AutoEventWireup="true" CodeBehind="frmMantDescuento.aspx.cs" Inherits="VirgenCarmenMantenedor.frmMantDetalleDescuento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="Scripts/DataTable/datatables.min.css" />
    <link rel="stylesheet" href="css/web_general.css" type="text/css" media="screen, projection" />
    <link rel="stylesheet" href="icon/style.css" />
    <link rel="stylesheet" href="Scripts/jqueryui/jquery-ui.min.css" />

    <script src="Scripts/DataTable/datatables.min.js"></script>
    <script src="Scripts/sweetalert.min.js"></script>
    <script src="Scripts/jqueryui/jquery-ui.min.js"></script>
    <script src="Scripts/descuento_ajax.js"></script>

    <title>DESCUENTO</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
        <!-- ESTE SERA EL TITULO GENERAL DEL MANTENEDOR -->
            <div class="box-header">
                <h3 class="box-title">MANTENEDOR DE DESCUENTO</h3>
            </div>
            <div class="form-group sub-titulo">
                <h4 class="box-filtros">FILTROS DE BUSQUEDA</h4>
            </div>
            <!-- Zona de filtros -->
            <div class="form-group col-xs-6">
                <label class="col-xs-2 label label-default horizontal" for="id_producto">Producto</label>
                <input type="text" class="form-control horizontal" id="id_producto" placeholder="Ingesar sku / nombre producto" />
                <input type="hidden" class="form-control horizontal" id="id_codProducto"/>
            </div>
            <div class="form-group col-xs-6">
                <label class="col-xs-2 label label-default horizontal" for="id_cliente">Cliente</label>
                <input type="text" id="id_cliente" class="form-control horizontal" placeholder="Ingesar Nombre / Numero Documento" />
                <input type="hidden" class="form-control horizontal" id="id_codCliente" value="0" />
            </div>
            <div class="form-group col-xs-6">
                <label class="col-sm-2 label label-default horizontal" for="id_vendedor">Vendedor</label>
                <select class="form-control horizontal id_vendedor" id="id_vendedor">
                    <option value = "0"> -Selecinar- </option>
                </select>
            </div>
            <div class="form-group col-xs-6">
                <label class="col-sm-2 label label-default horizontal" for="id_estado">Estado</label>
                <select class="form-control horizontal" id="id_estado">
                    <option value = "0"> -Selecinar- </option>
                </select>
            </div>
            <!-- div para mostrar mensaje de validacion de fecha de vigencia-->
            <div class="row form-group col-xs-12" >
                <div class="col-xs-5 form-group" id="msjFecha" hidden="">

                </div>
            </div>
            <div class="form-group col-xs-6">
                <label class="col-sm-2 label label-default horizontal" for="">Fecha Vigencia</label>
                <div class="form-group">
                    <div class="col-xs-4">
                        <input type="text" class="form-control fvalidar" id="id_fechaI" placeholder="Del: dd-mm-yyyy" autocomplete="off"/>
                    </div>
                    <div class="col-sm-1">
                        <label class=" label label-info"  for="">-</label>
                    </div>
                    <div class="col-xs-4">
                        <input type="text" class="form-control fvalidar" id="id_fechaF" placeholder="Al: dd-mm-yyyy" autocomplete="off"/>
                    </div>
                </div>
            </div>
            <div class="form-group col-xs-6">
                <button type="button" class="btn btn-primary btn-lg pull-right" id="btnBuscar">BUSCAR</button>
            </div>
        </div>
        <!-- TABLA DE RESULTADOS DE LOS FILTROS -->
        <div class="row">
            <div class="form-group">
                <h4 class="box-filtros" id="titelpreventa">LISTADO DE DESCUENTOS</h4>
            </div>
        </div>
        <div class="row">
            <div class="box-body table-responsive">
                <table id="id_tblDescuento" class="table table-bordered table-hover">
                    <thead>
                        <tr>
                            <th>SKU</th>    <!-- 0 -->
                            <th>PRODUCTO</th>
                            <th>DESCRIPCION</th>
                            <th>FECHA INI</th>
                            <th>FECHA FIN</th> 
                            <th>ESTADO</th>  <!-- 5 -->
                            <th>ACCION</th>
                            <th>NTR DESC</th>
                            <th>HORAI</th>
                            <th>HORAF</th>  
                            <th>COD ESTADO</th>  <!-- 10 -->
                            <th>COD UNIDAD</th>
                            <th>DESC UNIDAD</th>
                            <th>CANTIDAD</th>
                            <th>TIPO CANT</th>
                            <th>DESCUENTO</th>   <!-- 15 -->
                            <th>TIPO DESC</th> 
                            <th>COD VEND</th>
                            <th>VENDEDOR</th>
                            <th>COD CLI</th>
                            <th>CLIENTE</th>
                            <th>VECES DESC</th> <!-- 20 -->
                            <th>VECES VEN</th>
                            <th>VECES CLI</th>
                        </tr>
                    </thead>
                    <tbody id="tbl_body_table" class="ui-sortable">
                        
                    </tbody>
                    <tfoot>
                        <tr>
                            <th>SKU</th>    <!-- 0 -->
                            <th>PRODUCTO</th>
                            <th>DESCRIPCION</th>
                            <th>FECHA INI</th>
                            <th>FECHA FIN</th> 
                            <th>ESTADO</th>  <!-- 5 -->
                            <th>ACCION</th>
                            <th>NTR DESC</th>
                            <th>HORAI</th>
                            <th>HORAF</th>  
                            <th>COD ESTADO</th>  <!-- 10 -->
                            <th>COD UNIDAD</th>
                            <th>DESC UNIDAD</th>
                            <th>CANTIDAD</th>
                            <th>TIPO CANT</th>
                            <th>DESCUENTO</th>   <!-- 15 -->
                            <th>TIPO DESC</th> 
                            <th>COD VEND</th>
                            <th>VENDEDOR</th>
                            <th>COD CLI</th>
                            <th>CLIENTE</th>
                            <th>VECES DESC</th> <!-- 20 -->
                            <th>VECES VEN</th>
                            <th>VECES CLI</th>
                        </tr>
                    </tfoot>
                </table>
            </div>
        </div>
        <div class="row">
            <div class="form-group col-xs-12">
                <button type="button" class="btn btn-primary" id="btnAgregar" data-toggle="modal" data-target="#modalDescuento">AGREGAR</button>
            </div>
        </div>
    </div>

        <!-- Ventana modal para Registrar descuento -->
    <div class="modal fade" id="modalDescuento" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="id_tituloDesc">Registrar Descuento</h5>
                </div>
                <div class="modal-body">
                    <form role="form" onsubmit="return false;">
                        <!-- -------------------------- -->
                        <div class="row form-group">
                            <!-- div para mostrar mensaje de validacion de fecha de vigencia-->
                            <div class="row form-group col-xs-12" >
                                <div class="col-xs-8 form-group" id="msjFechaEdit" hidden="">

                                </div>
                            </div>
                            <label class="col-xs-2 label label-default " for="">Fecha Vig.</label>
                            <div class="col-xs-4">
                                <input type="text" class="form-control fvalidarEdit" id="id_fecha_vigI" placeholder="Del: dd-mm-yyyy" autocomplete="off"/>
                            </div>
                            <div class="col-sm-1">
                                <label class="label label-info" for="">-</label>
                            </div>
                            <div class="col-xs-4">
                                <input type="text" class="form-control fvalidarEdit" id="id_fecha_vigF" placeholder="Al: dd-mm-yyyy" autocomplete="off"/>
                            </div>
                        </div>
                        <div class="row form-group">
                            <!-- div para mostrar mensaje de validacion de hora de vigencia-->
                            <div class="row form-group col-xs-12" >
                                <div class="col-xs-8 form-group" id="msjHoraEdit" hidden="">

                                </div>
                            </div>
                            <label class="col-xs-2 label label-default " for="">Hora</label>
                            <div class="col-xs-4">
                                <input type="time" class="form-control hvalidarEdit" id="id_horaI"/>
                            </div>
                            <div class="col-sm-1">
                                <label class="label label-info" for="">-</label>
                            </div>
                            <div class="col-xs-4">
                                <input type="time" class="form-control hvalidarEdit" id="id_horaF"/>
                            </div>
                        </div>
                        <div class="row form-group">
                            <label class="col-xs-2 label label-default horizontal" for="">Activar</label>
                            <label class="radio-inline col-xs-1">
                                <input type="radio" name="activacion" id="id_activado" value="1" />Si
                            </label>                            
                            <label class="radio-inline col-xs-2">
                                <input type="radio" name="activacion" id="id_desactivado" value="2" />No
                            </label>
                        </div>

                        <!-- ------Descuento----- -->
                        <div class="form-group">
                            <h4 class="box-filtros">Descuento por producto</h4>
                        </div>
                        <div class="row form-group">
                            <div class="col-xs-3">
                                <p>Por la compra de:</p>
                            </div>
                            <div class="col-xs-8">
                                <input type="text" class="form-control" id="id_Producto_reg" placeholder="Ingrese un producto"/>
                                <input type="hidden" class="form-control horizontal" id="id_codProducto_reg"/>
                            </div>
                        </div>
                        <p></p>
                        <div class="row form-group">
                            <div class="col-xs-3">
                                <p>Por un total de:</p>
                            </div>
                            <div class="col-xs-4">
                                <input type="number" class="form-control " id="id_cantidad" placeholder="Ingrese cantidad"/>
                            </div>
                            <div class="col-xs-5">
                                <select class="form-control horizontal" id="id_unidadBase">
                                    <option value = "0"> SOLES </option>
                                </select>
                            </div>
                        </div>
                        <p></p>
                        <div class="row form-group">
                            <div class="col-xs-3">
                                <p>a mas, se dara un descuento de:</p>
                            </div>
                            <div class="col-xs-4">
                                <input type="number" class="form-control " id="id_monto" placeholder="Ingrese monto"/>
                            </div>
                            <div class="col-xs-5">
                                <select class="form-control horizontal" id="id_tipoMonto">
                                    <option value = "0"> -Selecinar- </option>
                                    <option value = "1"> SOLES (S/.) </option>
                                    <option value = "2"> POR CIENTO(%)</option> 
                                </select>
                            </div>
                        </div>

                        <!-- ------Datos adicionales----- -->
                        <div class="row form-group">
                            <h4 class="box-filtros">Restricciones</h4>
                        </div>
                        <div class="row form-group">
                            <label class="col-xs-3"><input type="checkbox" id="id_ck_vendedor"/> Vendedor</label>
                            <div class="col-xs-9">
                                <select class="form-control horizontal id_vendedor" id="id_vendedorReg"  style="width: 348px;" disabled="">
                                    <option value = "0"> -Selecinar- </option>
                                </select>
                            </div>
                        </div>
                        <div class="row form-group">
                            <label class="col-xs-3"><input type="checkbox" id="id_ck_cliente"/> Cliente</label>
                            <div class="col-xs-8">
                                <input type="text" class="form-control " id="id_cliente_reg" placeholder="Seleccione un cliente" disabled=""/>
                                <input type="hidden" class="form-control horizontal" id="id_codCliente_reg"/>
                            </div>
                        </div>
                        <div class="row form-group">
                            <label class="col-xs-9"><input type="checkbox" id="id_ck_veces_desc"/> Veces que se puede utilizar el descuento.</label>
                            <div class="col-xs-2">
                                <input type="number" class="form-control " id="id_veces_dec" disabled=""/>
                            </div>
                        </div>
                        <div class="row form-group">
                            <label class="col-xs-9"><input type="checkbox" id="id_ck_veces_vend" disabled=""/> Veces que un vendedor puede utilizar el descuento.</label>
                            <div class="col-xs-2">
                                <input type="number" class="form-control " id="id_veces_vend" disabled=""/>
                            </div>
                        </div>
                        <div class="row sform-group">
                            <label class="col-xs-9"><input type="checkbox" id="id_ck_veces_clie" disabled=""/> Veces que un cliente puede utilizar el descuento.</label>
                            <div class="col-xs-2">
                                <input type="number" class="form-control " id="id_veces_clie" disabled=""/>
                            </div>
                        </div>
                        <p></p>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal" id="id_btncancelar">CANCELAR</button>
                            <button type="submit" class="btn btn-primary" id="id_btnregistrar">REGISTRAR</button>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>

            <!-- Ventana modal para Ver descuento -->
    <div class="modal fade" id="modalVer" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog"">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Ver Descuento</h5>
                </div>
                <div class="modal-body">
                    <div class="container-fluid">
                        <!-- ------Datos Generales------ -->
                        <div class="form-group">
                            <h4 class="box-filtros">Datos del Descuento</h4>
                        </div>
                        <div class="row form-group">
                            <label class="label label-default  col-xs-2" for="MNtra_descuento">Cod. Descuento</label>
                            <div class="col-xs-4">
                                <input type="text" class="form-control " id="MNtra_descuento" readonly=""/>
                            </div>
                            <label class="label label-default  col-xs-2" for="MEstado">Estado</label>
                            <div class="col-xs-4">
                                <input type="text" class="form-control " id="MEstado" readonly="""/>
                            </div>
                        </div>
                        <div class="row form-group">
                            <label class="label label-default  col-xs-2" for="MFecha_Inicial">F. Inicio</label>
                            <div class="col-xs-4">
                                <input type="text" class="form-control " id="MFecha_Inicial" readonly=""/>
                            </div>
                            <label class="label label-default  col-xs-2" for="MFecha_Fin">F. Final</label>
                            <div class="col-xs-4">
                                <input type="text" class="form-control " id="MFecha_Fin" readonly=""/>
                            </div>
                        </div>
                        <div class="row form-group">
                            <label class="label label-default  col-xs-2" for="MHora_Inicio">H. Inicio</label>
                            <div class="col-xs-4">
                                <input type="text" class="form-control " id="MHora_Inicio" readonly=""/>
                            </div>
                            <label class="label label-default  col-xs-2" for="MHora_Fin">H. Final</label>
                            <div class="col-xs-4">
                                <input type="text" class="form-control " id="MHora_Fin" readonly=""/>
                            </div>
                        </div>
                        <div class="row form-group">
                            <label class="label label-default  col-xs-2" for="MProducto">Producto</label>
                            <div class="col-xs-10">
                                <input type="text" class="form-control " id="MProducto" readonly=""/>
                            </div>
                        </div>
                        <div class="row form-group">
                            <label class="label label-default  col-xs-2" for="MCodPro">SKU</label>
                            <div class="col-xs-4">
                                <input type="text" class="form-control " id="MCodPro" readonly=""/>
                            </div>
                            <label class="label label-default  col-xs-2" for="Munidad">UM</label>
                            <div class="col-xs-4">
                                <input type="text" class="form-control " id="Munidad" readonly=""/>
                            </div>
                        </div>

                        <!-- ------Detalle del descuento----- -->
                        <div class="form-group">
                            <h4 class="box-filtros">Detalle del Descuento</h4>
                        </div>
                        <div class="form-group" id="MDesDescuento">

                        </div>

                        <!-- ------Datos adicionales----- -->
                        <div class="form-group">
                            <h4 class="box-filtros">Datos Adicionales</h4>
                        </div>
                        <div class="form-group" id="MDetalleDescuento">

                        </div>
                        <div class="form-group" id="MDetalleVenedor">

                        </div>
                        <div class="form-group" id="MDetalleCliente">

                        </div>
                    </div>
                     <!-- Pie de pagina Botones -->
                    <div class="modal-footer">
                        <button type="button" class="btn btn-primary" data-dismiss="modal" id="">SALIR</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
