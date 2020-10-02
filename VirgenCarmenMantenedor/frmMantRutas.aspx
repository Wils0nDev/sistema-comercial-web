<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Loyout.Master" AutoEventWireup="true" CodeBehind="frmMantRutas.aspx.cs" Inherits="VirgenCarmenMantenedor.frmMantRutas1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" href="Scripts/DataTable/datatables.min.css" />
    <link rel="stylesheet" href="Scripts/DataTable/Buttons-1.6.1/css/buttons.dataTables.min.css"/>
    <link rel="stylesheet" href="icon/style.css" />
    <link rel="stylesheet" href="Scripts/jqueryui/jquery-ui.min.css" />
    <link rel="stylesheet" href="Scripts/jqueryui/jquery-ui.structure.min.css" />
    <link rel="stylesheet" href="Scripts/jqueryui/jquery-ui.theme.min.css" />
    <script src="Scripts/DataTable/datatables.min.js"></script>
    <script src="Scripts/DataTable/Buttons-1.6.1/js/dataTables.buttons.min.js"></script>
    <script src="Scripts/DataTable/Buttons-1.6.1/js/buttons.flash.min.js"></script>
    <script src="Scripts/DataTable/Buttons-1.6.1/js/jszip.min.js"></script>
    <script src="Scripts/DataTable/Buttons-1.6.1/js/pdfmake.min.js"></script>
    <script src="Scripts/DataTable/Buttons-1.6.1/js/vfs_fonts.js"></script>
    <script src="Scripts/DataTable/Buttons-1.6.1/js/buttons.html5.min.js"></script> 
    <script src="Scripts/DataTable/Buttons-1.6.1/js/buttons.print.min.js"></script>
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
    <script type="text/javascript" src="Scripts/jqueryui/jquery-ui.min.js"></script>

    <link rel="stylesheet" href="CSS/modal_style.css" />
    <link rel="stylesheet" href="CSS/DataTable.css" />

    <script src="Scripts/MantRutas.js"></script>

    <title>Mantenedor de Rutas</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container-fluid">
         <!-- Formulario Horizontal-->
        <div class="row">
            <!-- ESTE SERA EL TITULO GENERAL DEL MANTENEDOR -->
            <div class="col-xs-12">
                <div class="box-header">
                    <h3 class="box-title" id="tituloID" style="font-size: 30px;font-weight: 600;color: #1b1818; text-transform: none;">Mantenedor de Rutas</h3>
                </div>
            </div>
        </div>

        <div class="form-group">
            <div class="box-body">
                <table id="tb_rutas" class="table table-bordered table-hover">
                    <thead>
                        <tr>
                            <th scope="col">CODIGO</th>
                            <th scope="col">RUTA</th>
                            <!--<th scope="col">VENDEDOR</th>-->
                            <th scope="col">ABREVIATURA</th>
                            <!--<th scope="col">DIA</th>-->                         
                            <th scope="col">ACCION</th>
                        </tr>
                    </thead>
                
                    <tbody id="tbl_body_table">
                    
                    </tbody>
                    <!-- aqui traeremos la data por medio de ajax -->

                    <tfoot>
                        <tr>
                            <th scope="col">CODIGO</th>
                            <th scope="col">RUTA</th>
                            <!--<th scope="col">VENDEDOR</th>-->
                            <th scope="col">ABREVIATURA</th>
                            <!--<th scope="col">DIA</th>-->                         
                            <th scope="col">ACCION</th>
                        </tr>
                    </tfoot>
                </table>
            </div>
        </div>

               <!-- Button trigger modal -->
        <div class="row">
            <div class="col-xs-12" style="margin-bottom: 3%">
                <button type="button" class="btn btn-primary" id="buttonModal" data-toggle="modal" data-target="#exampleModal"  >
                        Registrar Ruta
                </button>
            </div>

        </div>

    </div>

            <!-- Modal1 -->
    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Registrar Rutas</h5>
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
                            <label for="inputName">Ruta</label>
                            <input type="text" class="form-control" id="Ruta"  />
                        </div>
                        <div class="form-group">
                            <label for="inputName">Abreviatura</label>
                            <input type="text" class="form-control" id="Abreviatura"  />
                        </div>
                    <%--<div class="form-group">
                            <label for="inputEmail">Sucursal</label>
                        <select class="form-control sucursales" id="sucursales">
                            <option value="0">SELECCIONE UNA SUCURSAL</option>
                        </select> 
                        </div>--%>
                        <div class="form-group" style="text-align: right">
                            <button type="button" class="btn btn-default" data-dismiss="modal" id="btnCancelar">Cancelar</button>
                            <button type="submit" class="btn btn-primary" id="btnGuardarM">Guardar</button>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>

          <!-- Modal2 -->
    <div class="modal fade" id="exampleModal2" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel2" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel2">Modificar Rutas</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    <div class="form-group" id="Mmensaje2">
                        <p id="Mpmensaje2" style="color: rgb(255, 255, 255);margin: 0 0 10px;background-color: transparent;width: 100%;border-radius: 5px;padding: 8px;
                            font-size: 15px;font-weight: 600;padding-left: 20px;margin-top: 10px;"></p>
                    </div>
                </div>
                <div class="modal-body">
                    <form role="form" onsubmit="return false;">

                        <div class="form-group">
                            <label for="inputName">Codigo</label>
                            <input type="text" readonly="readonly" class="form-control" id="Mcodigo"  />
                        </div>

                        <div class="form-group">
                            <label for="inputName">Ruta</label>
                            <input type="text" class="form-control" id="Mruta"  />
                        </div>
                        <div class="form-group">
                            <label for="inputName">Abreviatura</label>
                            <input type="text" class="form-control" id="Mabreviatura"  />
                        </div>
                        <%--<div class="form-group">
                            <label for="inputEmail">Sucursal</label>
                            <select class="form-control sucursales" id="">
                                <option value="">SELECCIONE UNA SUCURSAL</option>

                            </select>
                        </div>--%>
                        <div class="form-group" style="text-align: right">
                            <button type="button" class="btn btn-default" data-dismiss="modal" id="btnCancelar2">Cancelar</button>
                            <button type="submit" class="btn btn-primary" id="btnModifica">Actualizar</button>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
