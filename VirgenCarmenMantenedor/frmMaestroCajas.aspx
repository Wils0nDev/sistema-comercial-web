<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Loyout.Master" AutoEventWireup="true" CodeBehind="frmMaestroCajas.aspx.cs" Inherits="VirgenCarmenMantenedor.frmMaestroCajas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="Scripts/DataTable/datatables.min.css" />    
    <link rel="stylesheet" href="Scripts/jqueryui/jquery-ui.min.css" />
    <link rel="stylesheet" href="Scripts/jqueryui/jquery-ui.structure.min.css" />
    <link rel="stylesheet" href="Scripts/jqueryui/jquery-ui.theme.min.css" />
    <link rel="stylesheet" href="CSS/modal_style.css" />
    <link rel="stylesheet" href="CSS/DataTable.css" />
    <link rel="stylesheet" href="css/web_general.css" type="text/css" media="screen, projection" />
    <link rel="stylesheet" href="css/maestro_cajas.css" type="text/css" media="screen, projection" />

    <link rel="stylesheet" href="icon/style.css" />
    <script src="Scripts/DataTable/datatables.min.js"></script>
    <script src="Scripts/sweetalert.min.js"></script>
    <script src="Scripts/moment.min.js"></script>
    <script type="text/javascript" src="Scripts/jqueryui/jquery-ui.min.js"></script>
    <script src="Scripts/maestro_cajas.js"></script>
    <title>Maestro de Cajas</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-xs-12">
                <div class="box-header">
                    <h3 class="box-title" id="tituloID">Maestro de Cajas</h3>
                </div>

                <!-- ESTE SERA EL SUB TITULO GENERAL DE LO QUE SE QUIERE HACER -->
                <div class="form-group sub-titulo">
                    <h4 class="box-filtros">Filtros de B&uacute;squeda</h4>
                </div>

                <div class="form-group col-xs-12">
                    <div class="form-group col-xs-6">
                        <label for="" class="col-sm-2 label label-default horizontal">Estado</label>
                        <select id="selectEstadoCaja" class="form-control horizontal">
                            <option value="0">SELECCIONE UN ESTADO DE CAJA</option>

                        </select>
                    </div>     
                    
                    <div class="form-group col-xs-6">
                        <label for="" class="col-sm-2 label label-default horizontal">Encargado</label>
                        <select id="selectEncargado" class="form-control horizontal">
                            <option value="0">SELECCIONE UN ENCARGADO</option>

                        </select>
                    </div>  
                </div>

                <div class="form-group col-xs-12">
                    <div class="form-group col-xs-6">
                        <label for="" class="col-sm-2 label label-default horizontal">Caja</label>
                        <select id="selectCaja" class="form-control horizontal">
                            <option value="0">SELECCIONE UNA CAJA</option>

                        </select>
                    </div>  
                </div>

                <div class="form-group col-xs-12">
                    <div class="form-group col-xs-12">
                        <label for="" id="fecharegistro" class="col-sm-1 label label-default horizontal">Fecha de Creación</label>
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
                    <p id="MpmensajeOrden">La fecha inicial  debe ser menor a la fecha final</p>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="form-group col-xs-12">
                    <h4 class="box-filtros">Crear Caja</h4>
                    <button type="button" class="btn btn-primary" id="btnCrearCaja" data-toggle="modal" data-target="#modalAccion">
                        Crear Caja
                    </button>
                </div>
        </div>
        <div class="row">
            <div class="box-body table-responsive">
                <table id="tb_caja" class="table table-bordered table-hover">

                    <thead>
                        <tr>
                            <th scope="col">N° CAJA</th>
                            <th scope="col">FECHA CREACI&Oacute;N</th>
                            <th scope="col">DESCRIPCION</th>
                            <th scope="col">SUCURSAL</th>
                            <th scope="col">COD. ESTADO</th>
                            <th scope="col">ESTADO</th>
                            <th scope="col">COD. ENCARGADO</th>
                            <th scope="col">ENCARGADO</th>
                            <th scope="col">USUARIO ENCARGADO</th>
                            <th scope="col">ACCION</th>

                        </tr>
                    </thead>
                    <tbody id="tbl_body_table_caja" class="ui-sortable">
                    </tbody>
                    <!-- aqui traeremos la data por medio de ajax -->
                    <tfoot>
                        <tr>
                            <th scope="col">N° CAJA</th>
                            <th scope="col">FECHA CREACI&Oacute;N</th>
                            <th scope="col">DESCRIPCION</th>
                            <th scope="col">SUCURSAL</th>
                            <th scope="col">COD. ESTADO</th>
                            <th scope="col">ESTADO</th>
                            <th scope="col">COD. ENCARGADO</th>
                            <th scope="col">ENCARGADO</th>
                            <th scope="col">USUARIO ENCARGADO</th>
                            <th scope="col">ACCION</th>

                        </tr>
                    </tfoot>
                </table>

            </div>
        </div>

        <div class="row">
            <div class="form-group col-xs-12">
                    <h4 class="box-filtros">Aperturar Caja</h4>
                    <button type="button" class="btn btn-primary" id="btnAperturarCaja" data-toggle="modal" data-target="#modalAccion">
                        Aperturar Caja
                    </button>
                </div>
        </div>
        <div class="row">
            <div class="box-body table-responsive">
                <table id="tb_cajas_aperturadas" class="table table-bordered table-hover">

                    <thead>
                        <tr>
                            <th scope="col">N° APERTURA CAJA</th>
                            <th scope="col">FECHA APERTURA</th>
                            <th scope="col">CAJA</th>
                            <th scope="col">MONTO INICIAL (S/.)</th>
                            <th scope="col">MONTO INICIAL ($)</th>
                            <th scope="col">ACCION</th>

                        </tr>
                    </thead>
                    <tbody id="tbl_body_table_cajas_aperturadas" class="ui-sortable">
                    </tbody>
                    <!-- aqui traeremos la data por medio de ajax -->
                    <tfoot>
                        <tr>
                            <th scope="col">N° APERTURA CAJA</th>
                            <th scope="col">FECHA APERTURA</th>
                            <th scope="col">CAJA</th>
                            <th scope="col">MONTO INICIAL (S/.)</th>
                            <th scope="col">MONTO INICIAL ($)</th>
                            <th scope="col">ACCION</th>

                        </tr>
                    </tfoot>
                </table>

            </div>
        </div>

    </div>

    <!-- Modal -->
    <div class="modal fade" id="modalAccion" tabindex="-1" role="dialog" aria-labelledby="modalAccionLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="lblTitle"></h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    <div class="form-group" id="Mmensaje">
                        <p id="Mpmensaje"></p>
                    </div>
                </div>
                <div class="modal-body">
                    <form role="form" onsubmit="return false;">
                        <div class="form-group" id="divRegEditCaja">

                            <div class="form-group col-xs-12">
                                <input type="hidden" class="form-control" id="txtNtraCaja" readonly=""/>
                            </div>

                            <div class="form-group col-xs-12">
                          
                                <label  class="label label-default col-xs-4" for="inputName">Descripci&oacute;n:</label>
                                <div class="col-xs-8">
                                        <input type="text" class="form-control" id="txtDesc"/>
                                </div>
                            </div>

                            <div class="form-group col-xs-12">
                                <label for="lblEncargado">Encargado</label>
                                <select class="form-control" id="selectEncargado_Modal">
                                    <option value="0">SELECCIONE UN ENCARGADO</option>
                                </select>
                            </div>

                            <div class="form-group col-xs-12">
                                <div class="box-body table-responsive">
                                    <label for="lblTiposMov">Tipos de Movimientos de Caja</label>
                                    <table id="id_table_tipos_mov_caja" class="table table-bordered table-hover">
                                        <thead>
                                            <tr>
                                                <th>N°</th>
                                                <th>TIPO DE MOVIMIENTO</th>
                                                <th>TIPO DE REGISTRO</th>
                                                <th>ACCIÓN</th>
                                            </tr>
                                        </thead>
                                        <tbody id="tbl_body_table_tipos_mov_caja" class="ui-sortable">
                                            
                                        </tbody>
                                        <tfoot>
                                            <tr>
                                                <th>N°</th>
                                                <th>TIPO DE MOVIMIENTO</th>
                                                <th>TIPO DE REGISTRO</th>
                                                <th>ACCIÓN</th>
                                            </tr>
                                        </tfoot>
                                    </table>
                                </div>
                            </div>
                        </div>

                        <div class="form-group" id="divAperturaCaja">

                            <div class="form-group col-xs-12">
                                <input type="hidden" class="form-control" id="txtNtraAperturaCaja" readonly=""/>
                            </div>

                            <div class="form-group col-xs-12" id="divCajaAp">
                                <label for="lblCaja">Selecciona Caja</label>
                                <select class="form-control" id="selectCajaMA">
                                    <option value="0">SELECCIONE UNA CAJA</option>
                                </select>
                            </div>

                            <div class="form-group col-xs-12">
                                <label  class="label label-default col-xs-4" for="inputName">Importe Inicial (S/.)</label>
                                <div class="col-xs-8">
                                        <input type="text" class="form-control decimales" id="txtImpSoles" value="0.0"/>
                                </div>
                            </div>

                            <div class="form-group col-xs-12">
                                <label  class="label label-default col-xs-4" for="inputName">Importe Inicial ($)</label>
                                <div class="col-xs-8">
                                        <input type="text" class="form-control decimales" id="txtImpDolares" value="0.0"/>
                                </div>
                            </div>
                        </div>

                        <div class="form-group" id="divVerCaja">

                            <div class="form-group col-xs-12">
                                <label  class="label label-default col-xs-4" for="inputName">Descripci&oacute;n:</label>
                                <div class="col-xs-8">
                                        <input type="text" class="form-control" id="txtDescCaja" readonly=""/>
                                </div>
                            </div>

                            <div class="form-group col-xs-12">
                                <label  class="label label-default col-xs-4" for="inputName">Encargado:</label>
                                <div class="col-xs-8">
                                        <input type="text" class="form-control" id="txtEncCaja" readonly=""/>
                                </div>
                            </div>

                            <div class="form-group col-xs-12">
                                <div class="box-body table-responsive">
                                    <h4 class="box-filtros">Tipos de Movimientos de Caja</h4>
                                    <table id="id_table_ver_tipos_mov_caja" class="table table-bordered table-hover">
                                        <thead>
                                            <tr>
                                                <th>TIPO DE MOVIMIENTO</th>
                                                <th>TIPO DE REGISTRO</th>
                                            </tr>
                                        </thead>
                                        <tbody id="tbl_body_table_ver_tipos_mov_caja" class="ui-sortable">
                                            
                                        </tbody>
                                        <tfoot>
                                            <tr>
                                                <th>TIPO DE MOVIMIENTO</th>
                                                <th>TIPO DE REGISTRO</th>
                                            </tr>
                                        </tfoot>
                                    </table>
                                </div>
                            </div>

                            <div class="form-group col-xs-12" id="divDetApCaja">
                                <div class="form-group col-xs-12">
                                    <label  class="label label-default horizontal col-xs-2" for="inputName">Fecha:</label>
                                    <div class="col-xs-4">
                                            <input type="text" class="form-control" id="txtFecApCaja" readonly=""/>
                                    </div>
                                </div>

                                <div class="form-group col-xs-12">
                                    <label  class="label label-default col-xs-3" for="inputName">Monto Inicial (S/.):</label>
                                    <div class="col-xs-3">
                                            <input type="text" class="form-control" id="txtSaldoSCaja" readonly=""/>
                                    </div>

                                    <label  class="label label-default col-xs-3" for="inputName">Monto Inicial ($):</label>
                                    <div class="col-xs-3">
                                            <input type="text" class="form-control" id="txtSaldoDCaja" readonly=""/>
                                    </div>
                                </div>
                            </div>

                            <div class="form-group col-xs-12">
                                <div class="box-body table-responsive">
                                    <h4 class="box-filtros">Aperturas de Caja</h4>
                                    <table id="id_table_ver_ap_caja" class="table table-bordered table-hover">
                                        <thead>
                                            <tr>
                                                <th>FECHA</th>
                                                <th>MONTO INICIAL (S/.)</th>
                                                <th>MONTO INICIAL ($)</th>
                                            </tr>
                                        </thead>
                                        <tbody id="tbl_body_table_ver_ap_caja" class="ui-sortable">
                                            
                                        </tbody>
                                        <tfoot>
                                            <tr>
                                                <th>FECHA</th>
                                                <th>MONTO INICIAL (S/.)</th>
                                                <th>MONTO INICIAL ($)</th>
                                            </tr>
                                        </tfoot>
                                    </table>
                                </div>
                            </div>

                            <div class="form-group col-xs-12">
                                <div class="box-body table-responsive">
                                    <h4 class="box-filtros">Cierres de Caja</h4>
                                    <table id="id_table_ver_ci_caja" class="table table-bordered table-hover">
                                        <thead>
                                            <tr>
                                                <th>FECHA</th>
                                                <th>MONTO TOTAL (S/.) - REGISTRADO</th>
                                                <th>MONTO TOTAL (S/.) - SISTEMA</th>
                                                <th>DIFERENCIA (S/.)</th>
                                                <th>MONTO TOTAL ($) - REGISTRADO</th>
                                                <th>MONTO TOTAL ($) - SISTEMA</th>
                                                <th>DIFERENCIA ($)</th>
                                            </tr>
                                        </thead>
                                        <tbody id="tbl_body_table_ver_ci_caja" class="ui-sortable">
                                            
                                        </tbody>
                                        <tfoot>
                                            <tr>
                                                <th>FECHA</th>
                                                <th>MONTO TOTAL (S/.) - REGISTRADO</th>
                                                <th>MONTO TOTAL (S/.) - SISTEMA</th>
                                                <th>DIFERENCIA (S/.)</th>
                                                <th>MONTO TOTAL ($) - REGISTRADO</th>
                                                <th>MONTO TOTAL ($) - SISTEMA</th>
                                                <th>DIFERENCIA ($)</th>
                                            </tr>
                                        </tfoot>
                                    </table>
                                </div>
                            </div>

                            <div class="form-group col-xs-12">
                                <div class="box-body table-responsive">
                                    <h4 class="box-filtros">Movimientos Registrados en Caja</h4>
                                    <table id="id_table_ver_movs_caja" class="table table-bordered table-hover">
                                        <thead>
                                            <tr>
                                                <th>FECHA</th>
                                                <th>TIPO DE REGISTRO</th>
                                                <th>TIPO DE MOVIMIENTO</th>                                               
                                                <th>IMPORTE</th>
                                                <th>TIPO DE MONEDA</th>
                                                <th>MODO DE PAGO</th>
                                                <th>TIPO DE TRANSACCI&Oacute;N</th>
                                                <th>ESTADO</th>
                                            </tr>
                                        </thead>
                                        <tbody id="tbl_body_table_ver_movs_caja" class="ui-sortable">
                                            
                                        </tbody>
                                        <tfoot>
                                            <tr>
                                                <th>FECHA</th>
                                                <th>TIPO DE REGISTRO</th>
                                                <th>TIPO DE MOVIMIENTO</th>                                               
                                                <th>IMPORTE</th>
                                                <th>TIPO DE MONEDA</th>
                                                <th>MODO DE PAGO</th>
                                                <th>TIPO DE TRANSACCI&Oacute;N</th>
                                                <th>ESTADO</th>
                                            </tr>
                                        </tfoot>
                                    </table>
                                </div>
                            </div>

                        </div>
                        
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal" id="btnCancelar">Cerrar</button>
                            <button type="submit" class="btn btn-primary" id="btnGuardar">Guardar</button>
                            <button type="submit" class="btn btn-primary" id="btnRegistrar">Registrar</button>
                            <button type="submit" class="btn btn-primary" id="btnAperturar">Aperturar</button>
                            <button type="submit" class="btn btn-primary" id="btnGuardarA">Guardar</button>
                        </div>
                    </form>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
