<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Loyout.Master" AutoEventWireup="true" CodeBehind="frmRutasBitacora.aspx.cs" Inherits="VirgenCarmenMantenedor.frmRutasBitacora1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="Scripts/DataTable/datatables.min.css" />
    <link rel="stylesheet" href="Scripts/DataTable/Buttons-1.6.1/css/buttons.dataTables.min.css" />
    <link rel="stylesheet" href="icon/style.css" />
    <link rel="stylesheet" href="Scripts/jqueryui/jquery-ui.min.css" />
    <link rel="stylesheet" href="Scripts/jqueryui/jquery-ui.structure.min.css" />
    <link rel="stylesheet" href="Scripts/jqueryui/jquery-ui.theme.min.css" />
    
    <script src="JavaScript/jquery.js"></script>
     <script src="JavaScript/bootstrap.js"></script>
    <script src="JavaScript/bootstrap.min.js"></script>
    <script src="Scripts/GoogleMaps.js"></script>
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
    <script src="//maps.googleapis.com/maps/api/js?key=AIzaSyCA85ouhMdbAp5PZZSzHHu7a5_CUT5daD8&callback&sensor=false" type="text/javascript"></script>

    <script src="Scripts/DataTable/datatables.min.js"></script>
    <script src="Scripts/DataTable/Buttons-1.6.1/js/dataTables.buttons.min.js"></script>
    <script src="Scripts/DataTable/Buttons-1.6.1/js/buttons.flash.min.js"></script>
    <script src="Scripts/DataTable/Buttons-1.6.1/js/jszip.min.js"></script>
    <script src="Scripts/DataTable/Buttons-1.6.1/js/pdfmake.min.js"></script>
    <script src="Scripts/DataTable/Buttons-1.6.1/js/vfs_fonts.js"></script>
    <script src="Scripts/DataTable/Buttons-1.6.1/js/buttons.html5.min.js"></script>
    <script src="Scripts/DataTable/Buttons-1.6.1/js/buttons.print.min.js"></script>
    <script type="text/javascript" src="Scripts/jqueryui/jquery-ui.min.js"></script>
    <script src="Scripts/sweetalert.min.js"></script>
    <script src="Scripts/moment.min.js"></script>
    <link rel="stylesheet" href="CSS/DataTable.css" />
    <script src="Scripts/peticiones_bitacora.js"></script>
    <script src="Scripts/eventos.js"></script> 

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-xs-12">
                <div class="box box-primary">
                    <div class="box-header">
                        <h3 class="box-title" id="titleRutas">Bitacora de rutas</h3>
                    </div>
                    <div class="form-group">
                        <label for="vendedores">
                            <h4 id="titleSelect">Seleccione al vendedor</h4>
                        </label>
                        <select class="form-control" id="vendedores">
                            <option value="0">SELECCIONE A UN VENDEDOR</option>
                        </select>
                    </div>
                    <div class="form-group" id="MmensajeOrdenFecha">
                        <p id="MpmensajeOrden">La fecha inicial  debe ser menor a la fecha final</p>
                    </div>

                    <div class="form-group" id="rangoFecha" style="display: none">
                        <div class='col-sm-6'>
                            <input type="text" name="date_begin" id="min-date" class="form-control date-range-filter"
                                placeholder="De: dd-mm-yyyy" />
                        </div>
                        <div class='col-sm-6'>
                            <input type="text" id="max-date" class="form-control date-range-filter"
                                placeholder="Hasta: dd-mm-yyyy" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="box-body">

                            <table id="tb_rutasBitacora" class="table table-bordered table-hover">

                                <thead>
                                    <tr>
                                        <th scope="col">VENDEDOR</th>
                                        <th scope="col">RUTA</th>
                                        <th scope="col">CLIENTE</th>
                                        <th scope="col">VISITA</th>
                                        <th scope="col">MOTIVO</th>                                        
                                        <th scope="col">FECHA</th>
                                        <th scope="col">LATITUD</th>
                                        <th scope="col">LONGITUD</th>

                                    </tr>
                                </thead>

                                <tbody id="tbl_body_table_bitacora">
                                </tbody>
                                <!-- aqui traeremos la data por medio de ajax -->
                                <tfoot>
                                    <tr>
                                        <th scope="col">VENDEDOR</th>
                                        <th scope="col">RUTA</th>
                                        <th scope="col">CLIENTE</th>
                                        <th scope="col">VISITA</th>
                                        <th scope="col">MOTIVO</th>
                                        <th scope="col">FECHA</th>
                                        <th scope="col">LATITUD</th>
                                        <th scope="col">LONGITUD</th>
                                        

                                    </tr>
                                </tfoot>
                            </table>

                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Button trigger modal -->
        <div class="row">
            <div class="col-xs-12">
                <button type="button" class="btn btn-primary" id="buttonModalMapa" data-toggle="modal" >
                    Abrir modal
                </button>
            </div>
        </div>
    </div>
        <!-- Modal -->
    <!-- Modal -->
    <div class="modal fade" id="ModalMapa" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
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
                    <div class="row">
                        <div class="col-md-12 modal_body_content">
                            <p>Some contents...</p>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12 modal_body_map">
                            <div class="location-map" id="location-map">
                                <div style="width: 600px; height: 400px;" id="map_canvas"></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
