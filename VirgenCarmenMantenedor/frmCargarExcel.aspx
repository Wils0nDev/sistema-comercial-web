<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmCargarExcel.aspx.cs" Inherits="VirgenCarmenMantenedor.frmCargarExcel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="Scripts/DataTable/datatables.min.css" />
    <link rel="stylesheet" href="css/web_general.css" type="text/css" media="screen, projection" />
    <script src="Scripts/DataTable/datatables.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/xlsx/0.8.0/jszip.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/xlsx/0.8.0/xlsx.js"></script>
    <script src="Scripts/cargar_excel.js"></script>
    <title></title>
</head>
<body>
    <div class="container-fluid">
        <div class="row">
            <div class="col-xs-12">
                <!-- ESTE SERA EL TITULO GENERAL DEL MANTENEDOR -->
                <div class="box-header">
                    <h3 class="box-title">Titulo de Mantenedor</h3>
                </div>

                <!-- ESTE SERA EL SUB TITULO GENERAL DE LO QUE SE QUIERE HACER -->
                <div class="form-group">
                    <h4 class="box-filtros">Subtitulo de la accion: Registrar ...</h4>
                </div>

                <div class="form-group">
                        <label class="col-sm-2 label label-default" id="label1" >File input</label>
                        <input id="upload" type="file" id="exampleInputFile" name="files[]" />
                        <p class="help-block">Example block-level help text here.</p>
                 </div> 
                <div class="row">
            <div class="box-body table-responsive">
                <table id="idDateTable" class="table table-bordered table-hover">

                    <thead>
                        <tr>
                            <th scope="col">ORDEN</th>
                            <th scope="col">NOMBRE</th>
                            <th scope="col">APELLIDOS</th>
                            <th scope="col">DNI</th>
                            <th scope="col">DIRECCION</th>
                            

                        </tr>
                    </thead>
                    <tbody id="tbl_body_table" class="ui-sortable">

                       
                    </tbody>
                    <!-- aqui traeremos la data por medio de ajax -->
                    <tfoot>
                        <tr>
                            <th scope="col">ORDEN</th>
                            <th scope="col">NOMBRE</th>
                            <th scope="col">APELLIDOS</th>
                            <th scope="col">DNI</th>
                            <th scope="col">DIRECCION</th>

                        </tr>
                    </tfoot>
                </table>

            </div>
        </div>
            </div>
        </div>
    </div>

</body>
</html>
