<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Plantilla.aspx.cs" Inherits="VirgenCarmenMantenedor.Plantilla" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="Scripts/DataTable/datatables.min.css" />
    <link rel="stylesheet" href="css/web_general.css" type="text/css" media="screen, projection" />
    <link rel="stylesheet" href="icon/style.css" />
    <script src="Scripts/DataTable/datatables.min.js"></script>
    <script src="Scripts/sweetalert.min.js"></script>
    <script src="Scripts/Plantilla.js"></script>
    <title>Titulo del mantenedor</title>
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
                <!-- -----         --->

                <!-- Formulario Vertical-->
                <form >
                    <div class="form-group">
                        <label class="col-sm-2 label label-default"  for="exampleInputEmail1">Email address</label>
                        <input type="email" class="form-control" id="exampleInputEmail1" placeholder="Email" />
                    </div>
                    <div class="form-group">
                        <label class="col-sm-2 label label-default"  for="exampleInputPassword1">Password</label>
                        <input type="password" class="form-control" id="exampleInputPassword1" placeholder="Password" />
                    </div>
                    <div class="form-group">
                        <label class="col-sm-2 label label-default" id="label1" >File input</label>
                        <input type="file" id="exampleInputFile" />
                        <p class="help-block">Example block-level help text here.</p>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-2 label label-default"  for="idSelect">Seleccione una opcion</label>
                        <select id="idSelect" class="form-control">
                            <option>1</option>
                            <option>2</option>
                            <option>3</option>
                            <option>4</option>
                            <option>5</option>
                        </select>
                    </div>
                    <div class="form-group">
                        <label>
                            <input type="checkbox" />
                            Check me out
                        </label>
                    </div>
                     <div class="form-group">
                         <label class="col-sm-2 label label-default"  for="txtArea">Area de Texto</label>
                         <textarea class="form-control" id="txtArea" rows="3"></textarea>
                     </div>
                    <!-- Botones -->
                    <button type="button" class="btn btn-default">Cancelar</button>
                    <button type="button" class="btn btn-primary">Guardar</button>
                    <!-- -----         --->
                </form>
                <!-- ----- -->
                <!-- Botton Abrir Mofal-->
                
                <!-- -->
            </div>
        </div>
         <!-- Formulario Horizontal-->
        <div class="row">
            <!-- ESTE SERA EL TITULO GENERAL DEL MANTENEDOR -->
            <div class="col-xs-12">
                <div class="box-header">
                    <h3 class="box-title" id="tituloID">Titulo de Mantenedor</h3>
                </div>

                <!-- ESTE SERA EL SUB TITULO GENERAL DE LO QUE SE QUIERE HACER -->
                <div class="form-group">
                    <h4 class="box-filtros">Subtitulo de la accion: Registrar ...</h4>
                </div>

                <div class="form-group col-xs-12">
                     <div class="form-group col-xs-3">
                            <label class="radio-inline">
                                <input type="radio" name="inlineRadioOptions" id="inlineRadio1" value="option1" />
                                Radio 1
                            </label>                            
                        </div>
                        <div class="form-group col-xs-3 ">
                            <label class="radio-inline">
                                <input type="radio" name="inlineRadioOptions" id="inlineRadio2" value="option2" />
                                Radio 2
                            </label>
                        </div>
                    <div class="form-group col-xs-6">
                        <label class="col-sm-2 label label-default horizontal" for="idInput2">Password</label>
                        <input type="password" class="form-control horizontal" id="idInput2" placeholder="Password" />
                    </div>
                </div>

                <div class="form-group col-xs-12">
                    <div class="form-group col-xs-6">
                        <label for="idSelect2" class="col-sm-2 label label-default horizontal">Fabricante</label>
                        <select id="idSelect2" class="form-control horizontal">
                            <option>1</option>
                            <option>2</option>
                            <option>3</option>
                            <option>4</option>
                            <option>5</option>
                        </select>
                    </div>

                    <div class="form-group col-xs-6">
                       <button type="submit" class="btn btn-primary">Guardar</button>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="box-body table-responsive">
                <table id="idDateTable" class="table table-bordered table-hover">

                    <thead>
                        <tr>
                            <th scope="col">ORDEN</th>
                            <th scope="col">ABREVIATURA</th>
                            <th scope="col">VENDEDOR</th>
                            <th scope="col">RUTA</th>
                            <th scope="col">DIA</th>                            
                            <th scope="col">ACCION</th>

                        </tr>
                    </thead>
                    <tbody id="tbl_body_table" class="ui-sortable">

                        <tr role="row" class="odd ui-sortable-handle">
                            <td>1</td>
                            <td>LA VICTORIA</td>
                            <td>Wilson Vasquez Coronado</td>
                            <td>LA VICTORIA</td>
                            <td>LUNES</td>
                            <td>
                                <button type="button" title="Editar" class="icon-pencil btnEditar" data-toggle="modal" data-target="#exampleModal"></button>
                                <button type="button" id="" class="icon-bin btnDelete" data-toggle="tooltip" title="Eliminar"></button>
                            </td>
                        </tr>
                        <tr role="row" class="even ui-sortable-handle">
                            <td>2</td>
                            <td>MON-MOT</td>
                            <td>Wilson Vasquez Coronado</td>
                            <td>MONSEFU - MOTUPE</td>
                            <td>MARTES</td>
                            <td>
                                <button type="button" title="Editar" class="icon-pencil btnEditar" data-toggle="modal" data-target="#exampleModal"></button>
                                <button type="button" id="" class="icon-bin btnDelete" data-toggle="tooltip" title="Eliminar"></button>
                            </td>
                        </tr>
                        <tr role="row" class="odd ui-sortable-handle">
                            <td>3</td>
                            <td>PI-PR-GA-PO-SA-AV</td>
                            <td>Wilson Vasquez Coronado</td>
                            <td>CARRETERA PIMENTEL - PROVIVIENDA - LA GARITA - LOS PORTALES - LOS SAUCES - AVIENTEL</td>
                            <td>JUEVES</td>
                            <td>
                                <button type="button" title="Editar" class="icon-pencil btnEditar" data-toggle="modal" data-target="#exampleModal"></button>
                                <button type="button" id="" class="icon-bin btnDelete" data-toggle="tooltip" title="Eliminar"></button>
                            </td>
                        </tr>
                        <tr role="row" class="even ui-sortable-handle">
                            <td>4</td>
                            <td>CH</td>
                            <td>Wilson Vasquez Coronado</td>
                            <td>CHONGOYAPE</td>
                            <td>LUNES</td>
                            <td>
                                <button type="button" title="Editar" class="icon-pencil btnEditar" data-toggle="modal" data-target="#exampleModal"></button>
                                <button type="button" id="" class="icon-bin btnDelete" data-toggle="tooltip" title="Eliminar"></button>
                            </td>
                        </tr>
                    </tbody>
                    <!-- aqui traeremos la data por medio de ajax -->
                    <tfoot>
                        <tr>
                            <th scope="col">ORDEN</th>
                            <th scope="col">ABREVIATURA</th>
                            <th scope="col">VENDEDOR</th>
                            <th scope="col">RUTA</th>
                            <th scope="col">DIA</th>                            
                            <th scope="col">ACCION</th>

                        </tr>
                    </tfoot>
                </table>

            </div>
        </div>
        <!-- Button trigger modal -->
        <div class="row">
            <div class="col-xs-12">
                <button type="button" class="btn btn-primary" id="buttonModal" data-toggle="modal" data-target="#exampleModal">
                Abrir modal
                </button>
            </div>

        </div>
    </div>
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

                            <input type="text" class="form-control" id="Mvendedor" disabled="disabled" />
                        </div>
                        <div class="form-group">
                            <label for="inputEmail">Rutas</label>
                            <select class="form-control" id="rutas">
                                <option value="">Selecciona una opcion</option>

                            </select>
                        </div>
                        <div class="form-group">
                            <label for="inputName">Abreviatura</label>
                            <input type="text" class="form-control" id="Mabreviatura"  />

                        </div>
                        <div class="form-group">
                            <label for="inputEmail">Dias</label>
                            <select class="form-control" id="dias">
                                <option value="">Selecciona una opcion</option>

                            </select>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal" id="btnCancelar">Cancelar</button>
                            <button type="submit" class="btn btn-primary" id="btnGuardar">Guardar</button>
                        </div>
                    </form>
                </div>

            </div>
        </div>
    </div>
</body>
</html>
