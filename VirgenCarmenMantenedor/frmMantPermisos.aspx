<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Loyout.Master" AutoEventWireup="true" CodeBehind="frmMantPermisos.aspx.cs" Inherits="VirgenCarmenMantenedor.frmMantPermisos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/alertify.min.js"></script>
    <link href="css/alertify.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="css/web_general.css" type="text/css" media="screen, projection" />
    <link rel="stylesheet" href="icon/style.css" />
    <link rel="stylesheet" href="Scripts/jqueryui/jquery-ui.min.css" />
    <link rel="stylesheet" href="Scripts/DataTable/datatables.min.css" />
    <script src="Scripts/DataTable/datatables.min.js"></script>
    <script src="Scripts/sweetalert.min.js"></script>
    <script src="Scripts/permisos.js"></script>
    <style>
        .header-permisos {
            height:150px;
        }
        .paneles {
            padding:20px !important;
        }


    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       
<div class="container">
     <!-- Formulario Horizontal-->
        <div class="row">
            <!-- ESTE SERA EL TITULO GENERAL DEL MANTENEDOR -->
            <div class="col-xs-12">
                <div class="box-header">
                    <h3 class="box-title" id="tituloID">Registro de permisos</h3>
                </div>
                              
                <div class="header-permisos col-xs-12">
                    <ul class="nav nav-tabs">
                        <li role="presentation" class="active"><a href="#guardarPanel" id="tab_guardar" data-toggle="tab">Guardar</a></li>
                        <li role="presentation"><a id="tab_editar" href="#editarPanel" data-toggle="tab">Editar</a></li>
                    </ul>
                   
                    <div  class="tab-content paneles">
                         <div id="guardarPanel" class="tab-pane active">
                        <div class="form-group col-xs-6">
                            <label for="selectPerfil" class="col-sm-2 label label-default horizontal" style="font-size:15px">Perfil</label>
                            <select id="selectPerfil" class="form-control horizontal">
                              <option value="0">-Seleccione perfil-</option>
                            </select>
                        </div>

                        <div class="form-group col-xs-6">
                           <button type="submit" class="btn btn-primary" id="btnGuardar">Guardar</button>
                        </div>
                    </div>
                    <div id="editarPanel" class="tab-pane">
                        <div class="form-group col-xs-6">
                            <label for="selectPerfilEditar" class="col-sm-2 label label-default horizontal" style="font-size:15px">Perfil</label>
                            <select id="selectPerfilEditar" class="form-control horizontal">
                              <option value="0">-Seleccione perfil-</option>
                            </select>
                        </div>

                        <div class="form-group col-xs-6">
                           <button type="submit" class="btn btn-primary" id="btnEditar">Guardar Cambios</button>
                        </div>
                    </div>
                    </div>
                   
                </div>
            </div>
        </div>
        <div class="row">
            <div class="box-body table-responsive">
                <table id="tblPermisos" class="table table-bordered table-hover">

                    <thead>
                        <tr>
                            <th scope="col">N°</th>
                            <th scope="col">ORDEN</th>
                            <th scope="col">ORDEN FORMULARIO</th>
                            <th scope="col">FORMULARIO</th>
                            <th scope="col">MODULO</th>   
                            <th scope="col">COD PERMISO</th> 
                            <th scope="col">ACCION</th> 
                            

                        </tr>
                    </thead>
                    <tbody id="tbl_body_table" class="ui-sortable">

                    </tbody>
                    <!-- aqui traeremos la data por medio de ajax -->
                    <tfoot>
                        <tr>
                           <th scope="col">N°</th>
                            <th scope="col">ORDEN</th>
                            <th scope="col">ORDEN FORMULARIO</th>
                            <th scope="col">FORMULARIO</th>
                            <th scope="col">MODULO</th>   
                            <th scope="col">COD PERMISO</th> 
                            <th scope="col">ACCION</th>
                        </tr>
                    </tfoot>
                </table>

            </div>
        </div>
</div>

</asp:Content>
