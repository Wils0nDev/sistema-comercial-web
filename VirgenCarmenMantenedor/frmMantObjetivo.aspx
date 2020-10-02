<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Loyout.Master" AutoEventWireup="true" CodeBehind="frmMantObjetivo.aspx.cs" Inherits="VirgenCarmenMantenedor.frmMantObjetivo1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="Scripts/DataTable/datatables.min.css" />
     <link rel="stylesheet" href="css/web_general.css" type="text/css" media="screen, projection" />
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
    <link rel="stylesheet" href="CSS/modal_style.css" />
    <link rel="stylesheet" href="CSS/DataTable.css" />
    <script src="Scripts/moment.min.js"></script>
    <script src="Scripts/sweetalert.min.js"></script>
    <script src="Scripts/Plantilla.js"></script>
    <script src="Scripts/mantObjetivo.js"></script>
    <script type="text/javascript">
        function filterFloat(evt,input){
            // Backspace = 8, Enter = 13, ‘0′ = 48, ‘9′ = 57, ‘.’ = 46, ‘-’ = 43
            var key = window.Event ? evt.which : evt.keyCode;    
            var chark = String.fromCharCode(key);
            var tempValue = input.value+chark;
            if(key >= 48 && key <= 57){
                if(filter(tempValue)=== false){
                    return false;
                }else{       
                    return true;
                }
            }else{
                  if(key == 8 || key == 13 || key == 0) {     
                      return true;              
                  }else if(key == 46){
                        if(filter(tempValue)=== false){
                            return false;
                        }else{       
                            return true;
                        }
                  }else{
                      return false;
                  }
            }
        }
        function filter(__val__){
            var preg = /^([0-9]+\.?[0-9]{0,2})$/; 
            if(preg.test(__val__) === true){
                return true;
            }else{
               return false;
            }
    
        }
    </script>
    <title>Mantenedor Objetivos</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-xs-12">
                <div class="box-header">
                    <h3 class="box-title" id="tituloID">Mantenedor de Objetivos</h3>
                </div>
                <!-- ESTE SERA EL SUB TITULO GENERAL DE LO QUE SE QUIERE HACER -->
                <div class="form-group sub-titulo">
                    <h4 class="box-filtros">Ingrese opción de Búsqueda</h4>
                </div>
                <div class="form-group col-xs-12" >
                    <div class="form-group col-xs-4">
                        <label for="" class="form-group col-xs-5 label label-default horizontal" style="text-align:center">T. Indicador</label>                                                    
                        <select id="tindicador" class="form-control horizontal">
                            <option value="0">--Seleccione--</option>
                        </select>                       
                    </div>
                    <div class="form-group col-xs-4">
                        <label for="" class="form-group col-xs-5 label label-default horizontal" style="text-align:center">Perfil</label>                                          
                        <select id="perfil" class="form-control horizontal">
                            <option value="0">--Seleccione--</option>
                        </select>                      
                    </div>
                    <div class="form-group col-xs-4">
                        <label for="" class="form-group col-xs-5 label label-default horizontal" style="text-align:center">Trabajador</label>                                            
                        <select id="trabajador" class="form-control horizontal">
                            <option value="0">--Seleccione--</option>
                        </select>                       
                    </div>
                </div>
                <div class="form-group col-xs-12">
                    <div class="form-group col-xs-5">
                        <label for="" id="fechainicio" class="col-xs-4 label label-default horizontal" style="text-align:center">Fecha Inicio</label>
                        <div class='col-xs-7'>
                            <input type="text" name="date_begin" id="min-date" class="form-control date-range-filter"
                                placeholder="De: dd-mm-yyyy" />
                        </div>  
                    </div>
                    <div class="form-group col-xs-5">
                        <label for="" id="fechafin" class="col-xs-4 label label-default horizontal" style="text-align:center">Fecha de Fin</label>
                        <div class='col-xs-7'>
                            <input type="text" id="max-date" class="form-control date-range-filter"
                                placeholder="Hasta: dd-mm-yyyy" />
                        </div>
                    </div>
                    <div class="form-group col-xs-2">
                        <button type="submit" id="btnBuscar" class="btn btn-primary">Buscar</button>
                    </div>
                        
                </div>
                <div class="form-group col-xs-6">
                    <button type="button" class="btn btn-primary" id="buttonModal" data-toggle="modal" data-target="#objetivoModal">
                            Agregar
                    </button>
                </div> 
            </div>
        </div>
    </div>
  <%--      TABLA DE DATOS DE OBJETIVOS CON ACCIONES--%>
    <div class="row">
        <div class="box-body table-responsive">
             <table id="id_tblObjetivos" class="table table-bordered table-hover">
                <thead>
                    <tr>
                        <th>CÓDIGO</th>                            
                        <th>DESCRIPCIÓN</th>
                        <th>TIPO DE INDICADOR</th>
                        <th>INDICADOR</th>
                        <th>VALOR INDICADOR</th>
                        <th>PERFIL</th>
                        <th>TRABAJADOR</th>
                        <th>FECHA REGISTRO</th>
                        <th>ACCIÓN</th>
                    </tr>
                </thead>
                <tbody id="tbl_body_table" class="ui-sortable"></tbody>
                <tfoot>
                    <tr>
                    <th>CÓDIGO</th>                            
                    <th>DESCRIPCIÓN</th>
                    <th>TIPO DE INDICADOR</th>
                    <th>INDICADOR</th>
                    <th>VALOR INDICADOR</th>
                    <th>PERFIL</th>
                    <th>TRABAJADOR</th>
                    <th>FECHA REGISTRO</th>
                    <th>ACCIÓN</th>               
                    </tr>
                </tfoot>                   
            </table>
        </div>
    </div>  
    
    <div class="modal fade" id="objetivoModal" tabindex="-1" role="dialog" aria-labelledby="objetivoModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <%--<h5 class="modal-title" id="productoModalLabel">Producto</h5>--%>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    <div class="form-group" style="text-align:center">
                        <h4>Registrar Objetivo</h4>
                    </div>                   
                </div>
                <div class="modal-body">
                    <form role="form" onsubmit="return false;">
                        
                        <div class="row">
                            <label class="col-sm-2 label label-default horizontal"  for="inputEmail">Descripción</label>
                            <div class='col-xs-8'>
                                <input type="text" class="form-control horizontal" id="Mdescripcion" maxlength="50"/>
                            </div>
                        </div>
                        <div class="row" >
                            <label class="col-sm-2 label label-default horizontal" for="inputName">T. Indicador</label>
                            <div class="col-sm-3">
                                <select class="form-control" id="tindicadorM" >
                                <option value="0">-Seleccionar-</option>
                            </select>
                            </div>                            
                            <label class="col-sm-2 label label-default" for="categoria">Indicador</label>
                            <div class="col-sm-4">
                              <select class="form-control" id="indicadorM">
                                <option value="0">-Seleccionar-</option>
                             </select>
                            </div>
                        </div>
                        <div class="row">
                            <label class="col-sm-2 label label-default horizontal"  for="inputEmail">Val. Indicador</label>
                            <div class='col-xs-4'> 
                                <input type="text" class="form-control horizontal" id="vindicador" onkeypress="return filterFloat(event,this);"/>
                            </div>
                        </div>                  
                        <div class="row" >
                            <label class="col-sm-2 label label-default horizontal" for="inputName">Perfil</label>
                            <div class="col-sm-3">
                                <select class="form-control presentacion" id="perfilM" >
                                <option value="0">-Seleccionar-</option>
                            </select>
                            </div>                            
                            <label class="col-sm-2 label label-default" for="categoria">Trabajador</label>
                            <div class="col-sm-4">
                              <select class="form-control" id="trabajadorM">
                                <option value="0">-Seleccionar-</option>
                             </select>
                            </div>
                        </div>                
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal" id="btnCancelar">Cancelar</button>
                            <button type="submit" class="btn btn-primary" id="btnGuardar">Guardar</button>
                            <button type="submit" class="btn btn-primary" id="btnActualizar" style="display:none">Actualizar</button>
                        </div>
                    </form>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
