<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Loyout.Master" AutoEventWireup="true" CodeBehind="frmRutasAsignadas.aspx.cs" Inherits="VirgenCarmenMantenedor.frmRutasAsignadas1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link rel="stylesheet" href="Scripts/DataTable/datatables.min.css" />
<link rel="stylesheet" href="Scripts/DataTable/Buttons-1.6.1/css/buttons.dataTables.min.css"/>
<link rel="stylesheet" href="icon/style.css" />
 <link rel="stylesheet" href="icon/pdf/style.css" />
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
<script src="Scripts/peticiones_ajax.js"></script> 
<script src="Scripts/eventos.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row">

    <div class="col-xs-12">  
        
            <div class="box box-success">
                <div class="box-header">
                    <h3 class="box-title" id="titleRutas">Lista de rutas asignadas</h3>
                </div>
                <div class="form-group">
                  <label for="vendedores"><h4 id="titleSelect">Seleccione al vendedor</h4></label>
                    <select class="form-control" id="vendedores">
                        <option value="0">SELECCIONE A UN VENDEDOR</option>
                  </select> 
                </div>
                <div class="form-group" id="MmensajeOrden">
                    <p id="MpmensajeOrden">El orden se actualizo correctamente</p>
                </div>
                <div class="box-body table-responsive">
                    <table id="tb_rutasAsignadas" class="table table-bordered table-hover">
                        
                        <thead>
                        <tr>
                            <th scope="col">ORDEN</th>
                            <th scope="col">ABREVIATURA</th>
                            <th scope="col">VENDEDOR</th>
                            <th scope="col">RUTA</th>
                            <th scope="col">DIA</th>
                            <th scope="col">CODRUTA</th>
                            <th scope="col">CODUSUARIO</th>
                            <th scope="col">CODDIA</th>
                            <th scope="col">ACCION</th>
                            
                        </tr>
                        </thead>

                        <tbody id="tbl_body_table">

                        </tbody>
                        <!-- aqui traeremos la data por medio de ajax -->
                        <tfoot>
                        <tr>
                            <th scope="col">ORDEN</th>
                            <th scope="col">ABREVIATURA</th>
                            <th scope="col">VENDEDOR</th>
                            <th scope="col">RUTA</th>
                            <th scope="col">DIA</th>
                            <th scope="col">CODRUTA</th>
                            <th scope="col">CODUSUARIO</th>
                            <th scope="col">CODDIA</th>
                            <th scope="col">ACCION</th>
                            
                        </tr>
                        </tfoot>
                    </table>

                </div>

            </div>

        </div>

    </div>
      <!-- Button trigger modal -->
    <button type="button" class="btn btn-primary" id="buttonModal" data-toggle="modal" data-target="#exampleModal" disabled="disabled" >
      Asignar Ruta
    </button>
    <!-- Modal -->
<div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Asignación de Rutas</h5>
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
                        <label for="inputName">Vendedor</label>
                        <input type="hidden" class="form-control" id="McodOrden" disabled="disabled" />
                        <input type="hidden" class="form-control" id="McodVendedor" disabled="disabled" />
                        <input type="hidden" class="form-control" id="MRutaAnterior" disabled="disabled" />
  
                        <input type="text" class="form-control" id="Mvendedor" disabled="disabled"/>
                    </div>
                    <div class="form-group">
                        <label for="inputEmail">Rutas</label>
                        <select  class="form-control" id="rutas" >
                            <option value="">Seleccione una Ruta</option>
                
                        </select> 
                    </div>
                    <div class="form-group">
                        <label for="inputName">Abreviatura</label>
                        <input type="text" class="form-control" id="Mabreviatura" disabled="disabled" />
                        
                    </div>
                  <div class="form-group">
                            <label for="inputEmail">Dias</label>
                            <select class="form-control" id="dias">
                                <option value="">Seleccione una día</option>

                            </select> 
                   </div>
                    <div class="modal-footer">
        
                <button type="button" class="btn btn-default" data-dismiss="modal" id="btnCancelar">Cancelar</button>
                <button type="submit" class="btn btn-primary" id="btnGuardar">Guardar</button>
                <button type="submit" class="btn btn-primary" id="btnActualizar">Actualizar</button>
      </div>
                </form>
      </div>
      
    </div>
  </div>
</div>

</asp:Content>
