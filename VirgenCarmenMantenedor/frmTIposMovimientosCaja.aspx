<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Loyout.Master" AutoEventWireup="true" CodeBehind="frmTIposMovimientosCaja.aspx.cs" Inherits="VirgenCarmenMantenedor.frmTIposMovimientosCaja1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="Scripts/DataTable/datatables.min.css" />    
    <link rel="stylesheet" href="Scripts/jqueryui/jquery-ui.min.css" />
    <link rel="stylesheet" href="Scripts/jqueryui/jquery-ui.structure.min.css" />
    <link rel="stylesheet" href="Scripts/jqueryui/jquery-ui.theme.min.css" />
    <link rel="stylesheet" href="CSS/modal_style.css" />
    <link rel="stylesheet" href="CSS/DataTable.css" />
    <link rel="stylesheet" href="css/web_general.css" type="text/css" media="screen, projection" />
    <link rel="stylesheet" href="css/tipos_mov_caja.css" type="text/css" media="screen, projection" />

    <link rel="stylesheet" href="icon/style.css" />
    <script src="Scripts/DataTable/datatables.min.js"></script>
    <script src="Scripts/sweetalert.min.js"></script>
    <script src="Scripts/moment.min.js"></script>
    <script type="text/javascript" src="Scripts/jqueryui/jquery-ui.min.js"></script>
    <script src="Scripts/tipos_mov_caja.js"></script>
    <title>Tipos de Movimientos en Caja</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-xs-12">
                <div class="box-header">
                    <h3 class="box-title" id="tituloID">Tipos de Movimientos en Caja</h3>
                </div>

                <div class="form-group col-xs-12">
                    <h4 class="box-filtros">Registar Tipo de Movimiento en Caja</h4>
                    <button type="button" class="btn btn-primary" id="buttonModal" data-toggle="modal" data-target="#modalAccion"  >
                        Registrar Tipo de Movimiento
                </button>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="box-body table-responsive">
                <table id="tb_tipo_movimiento_caja" class="table table-bordered table-hover">

                    <thead>
                        <tr>
                            <th scope="col">CODIGO</th>
                            <th scope="col">DESCRIPCI&Oacute;N</th>
                            <th scope="col">COD. TIPO REGISTRO</th>
                            <th scope="col">TIPO REGISTRO</th>
                            <th scope="col">ACCION</th>

                        </tr>
                    </thead>
                    <tbody id="tbl_body_table_tipo_movimiento_caja" class="ui-sortable">
                    </tbody>
                    <!-- aqui traeremos la data por medio de ajax -->
                    <tfoot>
                        <tr>
                            <th scope="col">CODIGO</th>
                            <th scope="col">DESCRIPCI&Oacute;N</th>
                            <th scope="col">COD. TIPO REGISTRO</th>
                            <th scope="col">TIPO REGISTRO</th>
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

                        <div class="form-group col-xs-12" id="divCodTMovimiento">
                            <input type="hidden" class="form-control" id="pCodTipoMovimiento" readonly="true"/>
                        </div>

                        <div class="form-group col-xs-12" id="divTRegistro">
                            <label for="tregistro">Tipo de Registro</label>
                            <select class="form-control" id="tregistro">
                                <option value="0">SELECCIONE UN TIPO DE REGISTRO</option>
                            </select>
                        </div>

                        <div class="form-group col-xs-12" id="divPDescripcion">
                          
                            <label  class="label label-default col-xs-4" for="inputName">Descripci&oacute;n:</label>
                            <div class="col-xs-8">
                                    <input type="text" class="form-control" id="pDescripcion" />
                            </div>
                        </div>
                        
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal" id="btnCancelar">Cerrar</button>
                            <button type="submit" class="btn btn-primary" id="btnRegistrar">Registrar</button>
                            <button type="submit" class="btn btn-primary" id="btnGuardar">Guardar</button>
                        </div>
                    </form>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
