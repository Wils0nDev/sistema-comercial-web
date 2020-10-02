<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Loyout.Master" AutoEventWireup="true" CodeBehind="frmMantProducto.aspx.cs" Inherits="VirgenCarmenMantenedor.frmMantProducto1" %>
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
    <script src="Scripts/sweetalert.min.js"></script>
    <script src="Scripts/Plantilla.js"></script>
    <script src="Scripts/producto.js"></script>
    <title>Mantenedor Producto</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container-fluid">
        <div class="row">
            <div class="col-xs-12">
                <!-- ESTE SERA EL TITULO GENERAL DEL MANTENEDOR -->
                <div class="box-header sub-titulo">
                    <h3 class="box-title ">Mantenedor Producto</h3>
                </div>
                <!-- ESTE SERA EL SUB TITULO GENERAL DE LO QUE SE QUIERE HACER -->
                <div class="form-group">
                    <h4 class="box-filtros">Ingrese opción de Búsqueda</h4>
                </div>

                <div class="form-group col-xs-12">
                    <div class="form-group col-xs-6">
                        <label for="categoria" class="col-sm-4 label label-default">Categoria</label>
                        <select id="categoria" class="form-control categoria">
                             <option value="0">--Seleccionar--</option>                       
                        </select>
                    </div>

                    <div class="form-group col-xs-6">
                        <label for="ddlSubCategoria" class="col-sm-4 label label-default">SubCategoria</label>
                        <select id="subcategoria" class="form-control subcategoria">
                            <option value="0">--Seleccionar--</option>                            
                        </select>
                    </div>

                     <div class="form-group col-xs-6">
                        <label for="ddlFabricante" class="col-sm-4 label label-default">Fabricante</label>
                        <select id="fabricante" class="form-control fabricante">
                             <option value="0">--Seleccionar--</option>                            
                        </select>
                    </div>

                    <div class="form-group col-xs-6">
                        <label for="ddlProveedor" class="col-sm-4 label label-default">Proveedor</label>
                        <select id="proveedor" class="form-control proveedor">
                             <option value="0">--Seleccionar--</option>                            
                        </select>
                    </div>

                    <div class="form-group col-xs-6">
                           <label for="txtProducto" class="col-sm-4 label label-default">Producto</label>
                           <input type="text" class="form-control" id="txtProducto" />
                    </div>     
                    <div class="form-group col-xs-12" style="text-align:right">
                            <button type="submit" class="btn btn-primary" id="btnBuscar">Buscar</button>
                    </div>

                    <!--agregar nuevo producto --->
                     <div class="form-group col-xs-6">
                        <button type="button" class="btn btn-primary" id="buttonModal" data-toggle="modal" data-target="#productoModal">
                       Agregar
                        </button>

                    </div>                                           
                    
                </div>                                  

            </div>
        </div>
        <div class="row">
        <div class="box-body table-responsive">
             <table id="id_tblProducto" class="table table-bordered table-hover">
                   <thead>
                        <tr>
                            <th>CÓDIGO</th>
                            <th>COD. CATEGORIA</th>
                            <th>CATEGORIA</th>
                            <th>COD. SUBCATEGORIA</th>
                            <th>SUBCATEGORIA</th>
                            <th>COD. PROVEEDOR</th>
                            <th>PROVEEDOR</th>
                            <th>COD. FABRICANTE</th>
                            <th>FABRICANTE</th>
                            <th>DESCRIPCION</th>
                            <th>UNIDAD BASE</th> 
                            <th>COD. TIPO PRODUCT.</th> 
                            <th>TIPO PRODUCTO</th>  
                            <th>FLAG VENTA</th> 
                            <th>ACCION</th>

                        </tr>
                    </thead>
                    <tbody id="tbl_body_table" class="ui-sortable">

                     </tbody>

                     <tfoot>
                         <tr>
                             <th>CÓDIGO</th>
                            <th>COD. CATEGORIA</th>
                            <th>CATEGORIA</th>
                            <th>COD. SUBCATEGORIA</th>
                            <th>SUBCATEGORIA</th>
                            <th>COD. PROVEEDOR</th>
                            <th>PROVEEDOR</th>
                            <th>COD. FABRICANTE</th>
                            <th>FABRICANTE</th>
                            <th>DESCRIPCION</th>
                            <th>UNIDAD BASE</th> 
                            <th>COD. TIPO PRODUCT.</th> 
                            <th>TIPO PRODUCTO</th>  
                            <th>FLAG VENTA</th> 
                            <th>ACCION</th>
                         </tr>
                     </tfoot>
                   
                </table>

        </div>
    </div>   

    </div>
   <!-- Ventana modal REGISTRAR producto -->
    <div class="modal fade" id="productoModal" tabindex="-1" role="dialog" aria-labelledby="productoModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <%--<h5 class="modal-title" id="productoModalLabel">Producto</h5>--%>
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
                          <!--<label class="col-sm-2 label label-default" for="inputEmail">SKU Producto</label>-->
                           <input type="hidden" class="form-control" id="McodProveedor" disabled="disabled" /> 
                           <input type="hidden" class="form-control" id="McodFabricante" disabled="disabled" />
                           <input type="hidden" class="form-control" id="McodCategoria" disabled="disabled" />
                           <input type="hidden" class="form-control" id="McodsubCategoria" disabled="disabled" />
                            <input type="hidden" class="form-control" id="Msku" disabled="disabled"/>                         
                           
                        </div>
                        <div class="form-group ">
                            <label class="col-sm-2 label label-default"  for="inputEmail">Descripción</label>
                             <input type="text" class="form-control" id="Mdescripcion" />
                        </div>
                        <div class="row" >
                            <label class="col-sm-3 label label-default" for="inputName">Unidad de venta</label>
                            <div class="col-sm-3">
                                <select class="form-control presentacion" id="unidadbase" >
                                <option value="0">-Seleccionar-</option>
                            </select>
                            </div>
                            
                            <label class="col-sm-2 label label-default" for="categoria">Categoria</label>
                            <div class="col-sm-4">
                              <select class="form-control" id="dllcategoria">
                                <option value="0">-Seleccionar-</option>
                             </select>
                            </div>
                        </div>
                          <div class="row">
                              <label class="col-sm-3 label label-default" for="inputEmail">Tipo Producto</label>
                              <div class="col-sm-3">
                                   <select class="form-control" id="tipoProducto">
                                     <option value="0">-Seleccionar-</option>
                                 </select>
                                </div>

                            <label class="col-sm-2 label label-default" for="inputEmail">SubCategoria</label>
                            <div class="col-sm-4">
                                <select class="form-control" id="dllsubcategoria">
                                    <option value="0">-Selecciona-</option>
                                 </select>
                             </div>
                            </div>
                  
                         <div class="row">
                            <label class="col-sm-3 label label-default" for="inputEmail">Fabricante</label>
                             <div class="col-sm-9">
                                  <select class="form-control fabricante" id="dllfabricante">
                                      <option value="0">-Selecciona-</option>
                                 </select>
                            </div>
                        </div>
                         <div class="row">
                            <label class="col-sm-3 label label-default" for="inputEmail">Proveedor</label>
                             <div class="col-sm-9">
                                  <select class="form-control proveedor" id="dllproveedor">
                                      <option value="0">Selecciona una opcion</option>
                                 </select>
                            </div>                        
                        </div>                   
                        <div class="row">
                            <label class="col-sm-3 label label-default" >Tipo Venta</label>
                             <div class="col-sm-9">
                                  <select class="form-control" id="flagVenta">
                                      <option value="">Selecciona una opcion</option>                                   
                                 </select>
                            </div>
                        </div>
                        <div class="row">
                            <label class="col-sm-4 label label-default" for="inputEmail">Presentacion Producto</label>
                             <div class="col-sm-8">
                                  <select class="form-control" id="presentacion">
                                      <option value="0">Selecciona</option>
                                 </select>
                            </div>
                        </div>
                        <div class="row">
                             <label class="col-sm-3 label label-default" for="inputName">Cant. U. Base</label>
                                       
                            <div class="col-lg-3">
                                  <input type="text" class="form-control" id="Mcant" onkeypress='return event.charCode >= 48 && event.charCode <= 57' />
                            </div>    
                            
                            <div class="col-lg-6">
                                  <button type="submit" class="btn btn-primary" id="btnAgregar">Agregar</button>
                            </div>                             
                        </div>                 
                  
                       <div class="row">
                          <div class="box-body table-responsive">
                            <table id="idDateTablePresentacion" class="table table-bordered table-hover">
                               <thead>
                                    <tr>
                                        <th scope="col">CODIGO</th>    <!--Codigo del combo-->
                                        <th scope="col">DESCRIPCIÓN</th>    <!--Valor del combo-->
                                        <th scope="col">CANTIDAD</th>       <!--Cantidad del combo-->
                                        <th scope="col">ACCION</th>
                            
                                    </tr>
                                </thead>
                                <tbody id="idDateTableP" class="ui-sortable">                       
                        </tbody>        
                                <tfoot>
                                    <tr>
                                        <th scope="col">CODIGO</th>    <!--Codigo del combo-->
                                        <th scope="col">DESCRIPCIÓN</th>    <!--Valor del combo-->
                                        <th scope="col">CANTIDAD</th>       <!--Cantidad del combo-->
                                        <th scope="col">ACCION</th>
                            
                                    </tr>
                                </tfoot>
                      </table>
                    </div>
                  </div>
                
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal" id="btnCancelar">Cancelar</button>
                            <button type="submit" class="btn btn-primary" id="btnGuardar">Guardar</button>
                          <%--  <button type="submit" class="btn btn-primary" id="btnActualizar" style="display:none">Actualizar</button>--%>
                        </div>
                    </form>
                </div>

            </div>
        </div>
    </div>

    <!-- Ventana modal EDITAR producto -->
     <div class="modal fade" id="productoEditarModal" tabindex="-1" role="dialog" aria-labelledby="productoModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <%--<h5 class="modal-title" id="productoModalLabel">Producto</h5>--%>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    <div class="form-group" id="MmensajeE">
                        <p id="MpmensajeE"></p>
                    </div>
                    
                </div>
                <div class="modal-body">
                    <form role="form" onsubmit="return false;">
                        <div class="form-group">
                          <!--<label class="col-sm-2 label label-default" for="inputEmail">SKU Producto</label>-->                         
                            <input type="hidden" class="form-control" id="MskuE"/>                         
                           
                        </div>
                        <div class="form-group ">
                            <label class="col-sm-2 label label-default"  for="inputEmail">Descripción</label>
                             <input type="text" class="form-control" id="MdescripcionE" />
                        </div>
                        <div class="row" >
                            <label class="col-sm-3 label label-default" for="inputName">Unidad de venta</label>
                            <div class="col-sm-3">
                                <select class="form-control" id="unidadbaseE" >
                                <option value="0">-Seleccionar-</option>
                            </select>
                            </div>
                            
                            <label class="col-sm-2 label label-default" for="categoria">Categoria</label>
                            <div class="col-sm-4">
                              <select class="form-control" id="dllcategoriaE">
                                <option value="0">-Seleccionar-</option>
                             </select>
                            </div>
                        </div>
                          <div class="row">
                              <label class="col-sm-3 label label-default" for="inputEmail">Tipo Producto</label>
                              <div class="col-sm-3">
                                   <select class="form-control" id="tipoProductoE">
                                     <option value="0">-Seleccionar-</option>
                                 </select>
                                </div>

                            <label class="col-sm-2 label label-default" for="inputEmail">SubCategoria</label>
                            <div class="col-sm-4">
                                <select class="form-control" id="dllsubcategoriaE">
                                    <option value="0">-Selecciona-</option>
                                 </select>
                             </div>
                            </div>
                  
                         <div class="row">
                            <label class="col-sm-3 label label-default" for="inputEmail">Fabricante</label>
                             <div class="col-sm-9">
                                  <select class="form-control fabricante" id="dllfabricanteE">
                                      <option value="0">-Selecciona-</option>
                                 </select>
                            </div>
                        </div>
                         <div class="row">
                            <label class="col-sm-3 label label-default" for="inputEmail">Proveedor</label>
                             <div class="col-sm-9">
                                  <select class="form-control proveedor" id="dllproveedorE">
                                      <option value="0">Selecciona una opcion</option>
                                 </select>
                            </div>                        
                        </div>                   
                        <div class="row">
                            <label class="col-sm-3 label label-default" >Tipo Venta</label>
                             <div class="col-sm-9">
                                  <select class="form-control" id="flagVentaE">
                                      <option value="">Selecciona una opcion</option>                                   
                                 </select>
                            </div>
                        </div>
                        <div class="row">
                            <label class="col-sm-4 label label-default" for="inputEmail">Presentacion Producto</label>
                             <div class="col-sm-8">
                                  <select class="form-control" id="presentacionE">
                                      <option value="0">Selecciona</option>
                                 </select>
                            </div>
                        </div>
                        <div class="row">
                             <label class="col-sm-3 label label-default" for="inputName">Cant. U. Base</label>
                                       
                            <div class="col-lg-3">
                                  <input type="text" class="form-control" id="McantE" onkeypress='return event.charCode >= 48 && event.charCode <= 57' />
                            </div>    
                            
                            <div class="col-lg-6">
                                  <button type="submit" class="btn btn-primary" id="btnAgregarE">Agregar</button>
                            </div>                             
                        </div>                
                  
                        <!--DESDE AQUIiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii-->
                         <!-- Tabla para editar traeremos la data por medio de ajax -->
                        <div class="row">
                          <div class="box-body table-responsive">
                            <table id="idDatePresentacionEdit" class="table table-bordered table-hover">
                               <thead>
                                    <tr>
                                        <th scope="col">CODIGO</th>    <!--Codigo del combo-->
                                        <th scope="col">CODIGO2</th>    <!--Codigo del combo-->
                                        <th scope="col">DESCRIPCIÓN</th>    <!--Valor del combo-->
                                        <th scope="col">CANTIDAD</th>       <!--Cantidad del combo-->
                                        <th scope="col">ACCION</th>
                            
                                    </tr>
                                </thead>
                                <tbody id="idDateTablePE" class="ui-sortable">                                        
                                </tbody> 
                                 <!-- aqui traeremos la data por medio de ajax -->
                                <tfoot>
                                    <tr>
                                        <th scope="col">CODIGO</th>    <!--Codigo del combo-->
                                        <th scope="col">CODIGO2</th>    <!--Codigo del combo-->
                                        <th scope="col">DESCRIPCIÓN</th>    <!--Valor del combo-->
                                        <th scope="col">CANTIDAD</th>       <!--Cantidad del combo-->
                                        <th scope="col">ACCION</th>
                            
                                    </tr>
                                </tfoot>
                                        
                      </table>
                    </div>
                  </div>
        <!--HAST AQUIiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii-->
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal" id="btnCancelarE">Cancelar</button>                            
                            <button type="submit" class="btn btn-primary" id="btnActualizar">Actualizar</button>
                        </div>
                    </form>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
