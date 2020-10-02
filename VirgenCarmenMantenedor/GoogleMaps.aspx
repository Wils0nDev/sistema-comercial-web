<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Loyout.Master" AutoEventWireup="true" CodeBehind="GoogleMaps.aspx.cs" Inherits="VirgenCarmenMantenedor.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" href="css/bootstrap.min.css"" type="text/css" media="screen, projection" />
    <script src="JavaScript/jquery.js"></script>
    <script src="JavaScript/bootstrap.min.js"></script>
    <script src="Scripts/GoogleMaps.js"></script>
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
    <script src="//maps.googleapis.com/maps/api/js?key=AIzaSyCA85ouhMdbAp5PZZSzHHu7a5_CUT5daD8&callback"></script>
    <script src="Scripts/DataTable/datatables.min.js"></script>
    <title></title>
 <style>
      /* Always set the map height explicitly to define the size of the div
       * element that contains the map. */
      #map {
        height: 100%;
      }
      /* Optional: Makes the sample page fill the window. */
      html, body {
        height: 100%;
        margin: 0;
        padding: 0;
      }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row">
            <div class="col-xs-12">
                <button type="button" class="btn btn-primary" id="buttonModalMapa" data-toggle="modal" data-target="#ModalMapa" >
                Abrir modal
                </button>
            </div>

        </div>

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
