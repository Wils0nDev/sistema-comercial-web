<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Loyout.Master" AutoEventWireup="true" CodeBehind="frmMantProm.aspx.cs" Inherits="VirgenCarmenMantenedor.frmMantProm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
<%--    <link rel="stylesheet" href="Scripts/DataTable/datatables.min.css" />
    <link rel="stylesheet" href="Scripts/DataTable/Buttons-1.6.1/css/buttons.dataTables.min.css" />
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
    <script type="text/javascript" src="Scripts/jqueryui/jquery-ui.min.js"></script>

    <script src="https://momentjs.com/downloads/moment.min.js"></script>
    <link rel="stylesheet" href="CSS/DataTable.css" />--%>

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

     <script src="Scripts/RegistProm.js"></script>

    <link rel="stylesheet" href="css/web_general.css" type="text/css" media="screen, projection" />

    <title>Mantenedor de Promociones</title>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container-fluid">
         <!-- Formulario Horizontal-->
        <div class="row">
            <!-- ESTE SERA EL TITULO GENERAL DEL MANTENEDOR -->
            <div class="col-xs-12">
                <div class="box-header">
                    <h3 class="box-title" id="tituloID" style="font-size: 30px;font-weight: 600;color: #1b1818; text-transform: none;">Mantenedor de Promociones</h3>
                </div>
                <div class="form-group sub-titulo">
                    <h4 class="box-filtros" style ="font-weight: 600; color: #9e9e9e;">Filtros de Búsqueda</h4>
                </div>
                    <div class="form-group col-xs-12">
                        <div class="form-group col-xs-6">
                            <label for="idSelect2" class="col-sm-2 label label-default horizontal">Producto</label>
                                <select class="form-control producto horizontal" id="producto_principal">
                                    <option value="">-SELECCIONAR-</option>                                   
                                </select>
                        </div>
                        <div class="form-group col-xs-6">
                            <label for="idSelect2" class="col-sm-2 label label-default horizontal">Cliente</label>
                            <select class="form-control horizontal cliente" id="">
                                <option value="0">-SELECCIONAR-</option>                                   
                            </select>
                        </div>
                    </div>

                    <div class="form-group col-xs-12">
                        <div class="form-group col-xs-6">
                            <label for="idSelect2" class="col-sm-2 label label-default horizontal">Vendedor</label>
                            <select class="form-control horizontal" id="vendedor">
                                <option value="0">-SELECCIONAR-</option>               
                            </select>
                        </div>
                        <div class="form-group col-xs-6">
                            <label for="idSelect2" class="col-sm-2 label label-default horizontal">Estado</label>
                            <select class="form-control sucursales horizontal" id="estado">
                                <option value="0">-SELECCIONAR-</option>
                            </select>
                        </div>
                    </div>

                    <div class="form-group col-xs-12">
                        <div class="form-group col-xs-6">
                            <label class="col-xs-2 label label-default horizontal" for="id_proveedor">Proveedor</label>
                            <select class="form-control horizontal" id="id_proveedor">
                                <option value = "0">-SELECCIONAR-</option>
                            </select>
                        </div>
                        <div class="form-group col-xs-6">
                            <label for="idSelect2" class="col-sm-2 label label-default horizontal">Tipo Venta</label>
                            <select class="form-control sucursales horizontal" id="tipoVenta">
                                <option value="0">-SELECCIONAR-</option>                        
                            </select>
                        </div>
                    </div>
                    <div class="form-group col-xs-12">
                        <div class="form-group col-xs-6">

                           <label class="col-sm-2 label label-default horizontal"  for="idSelect">Periodo </label>
                               <div class="form-group" id="rangoFecha" style="display:inline">
                                   <div class='col-sm-4'>
                                       <input type="date" id="min_date" class="form-control date-range-filter"/>
                                   </div>
                                   <label class="col-sm-1 label label-default horizontal" for="idSelect" style="font-weight: 900;text-align: center;color: black;margin-right: 0px !important;background: border-box !important;position: relative;display: block;">--</label>

                                   <div class='col-sm-4'>
                                       <input type="date" id="max_date" class="form-control date-range-filter"/>
                                   </div>
                               </div>
                        </div>

                        <div class="form-group col-xs-6" style="text-align:center";>
                            <button type="button" class="btn btn-primary" id="id_btnBuscar" >
                                    BUSCAR
                            </button>
                        </div>
                    </div>
            </div>
        </div>

        <div class="form-group">
            <div class="box-body">
                <table id="tb_rutas" class="table table-bordered table-hover">
                    <thead>
                        <tr>
                            <th scope="col">CODIGO</th>
                            <th scope="col">CODIGO PRODUCTO</th>
                            <th scope="col">PRODUCTO</th>
                            <th scope="col">FECHA INICIO</th>
                            <th scope="col">FECHA FIN</th>
                            <th scope="col">CODIGO PROVEEDOR</th>
                            <th scope="col">PROVEEDOR</th>                       
                            <th scope="col">ACCION</th>

                            <th scope="col">promocion</th>
                            <th scope="col">codhoraI</th>
                            <th scope="col">codhoraF</th>
                            <th scope="col">codEstado</th>
                            <th scope="col">estado</th>
                            <th scope="col">cantidadProd</th>                           
                            <th scope="col">codUnidadBase</th>
                            <th scope="col">desUnidadBase</th>

                           <%-- <th scope="col">codProdProm</th>
                            <th scope="col">desProdProm</th>
                            <th scope="col">cantidadProdPromo</th>
                            <th scope="col">codUnidadBaseProdProm</th>
                            <th scope="col">desUnidadBaseProdProm</th>
                            <th scope="col">costoProdProm</th>--%>

                            <th scope="col">tipoProm</th>
                            <th scope="col">detTipoProm</th>
                            <th scope="col">codVendAplica</th>
                            <th scope="col">desVendAplica</th>
                            <th scope="col">codClienteAplica</th>
                            <th scope="col">desClienetAplica</th>
                            <th scope="col">vecesUsarProm</th>
                            <th scope="col">vecesUsarPromXvend</th>
                            <th scope="col">vecesUsarPromXcliente</th>

                        </tr>
                    </thead>
                
                    <tbody id="tbl_body_table">
                    
                    </tbody>
                    <!-- aqui traeremos la data por medio de ajax -->

                    <tfoot>
                        <tr>
                            <th scope="col">CODIGO</th>
                            <th scope="col">CODIGO PRODUCTO</th>
                            <th scope="col">PRODUCTO</th>
                            <th scope="col">FECHA INICIO</th>
                            <th scope="col">FECHA FIN</th>
                            <th scope="col">CODIGO PROVEEDOR</th>
                            <th scope="col">PROVEEDOR</th>                       
                            <th scope="col">ACCION</th>

                            <th scope="col">promocion</th>
                            <th scope="col">codhoraI</th>
                            <th scope="col">codhoraF</th>
                            <th scope="col">codEstado</th>
                            <th scope="col">estado</th>
                            <th scope="col">cantidadProd</th>
                            <th scope="col">codUnidadBase</th>
                            <th scope="col">desUnidadBase</th>

<%--                            <th scope="col">codProdProm</th>
                            <th scope="col">desProdProm</th>
                            <th scope="col">cantidadProdPromo</th>
                            <th scope="col">codUnidadBaseProdProm</th>
                            <th scope="col">desUnidadBaseProdProm</th>
                            <th scope="col">costoProdProm</th>--%>

                            <th scope="col">tipoProm</th>
                            <th scope="col">detTipoProm</th>

                            <th scope="col">codVendAplica</th>
                            <th scope="col">desVendAplica</th>
                            <th scope="col">codClienteAplica</th>
                            <th scope="col">desClienetAplica</th>
                            <th scope="col">vecesUsarProm</th>
                            <th scope="col">vecesUsarPromXvend</th>
                            <th scope="col">vecesUsarPromXcliente</th>
                        </tr>
                    </tfoot>
                </table>
            </div>
        </div>

               <!-- Button trigger modal -->
        <div class="row">
            <div class="col-xs-12" style="margin-bottom: 3%">
                <button type="button" class="btn btn-primary" id="buttonModal" data-toggle="modal" data-target="#exampleModal2"  >
                        AGREGAR
                </button>
            </div>
        </div>
    </div>


            <!-- Modal Detalle de Promocion -->
    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Detalle de Promoción</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <form role="form" onsubmit="return false;">
                        <div class="form-group col-xs-12">
                            <div class="form-group col-xs-12">
                                <label for="inputName">Producto</label>
                                <input type="text" readonly="readonly" class="form-control" id="ProductoVer"  />
                            </div>
                        </div>
                        <div class="form-group col-xs-12">
                            <div class="form-group col-xs-6">
                                <label for="inputName">Inicio</label>
                                <input type="text" readonly="readonly" class="form-control" id="InicioVer" />
                            </div>
                            <div class="form-group col-xs-6">
                                <label for="inputName">Fin</label>
                                <input type="text" readonly="readonly" class="form-control" id="FinVer" />
                            </div>
                        </div>
                        <div class="form-group col-xs-12">
                            <div class="form-group col-xs-6">
                                <label for="inputName">Cant. Minima</label>
                                <input type="text" readonly="readonly" class="form-control" id="CantM" />
                            </div>
                            <div class="form-group col-xs-6">
                                <label for="inputName">Unidad Base/Importe</label>
                                <input type="text" readonly="readonly" class="form-control" id="Ubase" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="inputName">Productos Promocionados</label>

                            <div class="form-group">
                                <div class="box-body">
                                    <table id="tb_detalle" class="table table-bordered table-hover">
                                        <thead>
                                            <tr>
                                                <th scope="col">codigoPromo</th>
                                                <th scope="col">PRODUCTO</th>
                                                <th scope="col">CANTIDAD</th>
                                                <th scope="col">PRESENTACION</th>                       
                                                <th scope="col">PRECIO (S./)</th>
                                            </tr>
                                        </thead>
                                    
                                        <tbody id="">
                                        
                                        </tbody>
                                        <!-- aqui traeremos la data por medio de ajax -->

                                        <tfoot>
                                            <tr>
                                                <th scope="col">codigoPromo</th>
                                                <th scope="col">PRODUCTO</th>
                                                <th scope="col">CANTIDAD</th>
                                                <th scope="col">PRESENTACION</th>                       
                                                <th scope="col">PRECIO (S./)</th>
                                            </tr>
                                        </tfoot>
                                    </table>
                                </div>
                            </div>
                        </div>


                        <div class="form-group col-xs-12">
                                <div class="form-group col-xs-10">
                                    <label for="inputName" class="col-sm-3 horizontal" style="margin-left:-5%;" >Cant. Max. Promoción</label>
                                    <input type="text" readonly="readonly" class="form-control horizontal" id="MaxP"  />
                                </div>
                        </div>


                        <div class="form-group col-xs-12">
                                <div class="form-group col-xs-10">
                                    <label for="inputName" class="col-sm-3 horizontal" style="margin-left:-5%;">Cant. Max. Vendedor</label>
                                    <input type="text" readonly="readonly" class="form-control horizontal" id="VendedorMax"  />
                                </div>
                        </div>

                        <div class="form-group col-xs-12">
                                <div class="form-group col-xs-10">
                                    <label for="inputName" class="col-sm-3 horizontal" style="margin-left:-5%;">Cant. Max. Cliente</label>
                                    <input type="text" readonly="readonly" class="form-control horizontal" id="ClienteMax"  />
                                </div>
                        </div>

                        <div class="form-group" style="text-align: right">
                            <button type="button" class="btn btn-default" data-dismiss="modal" id="btnCancelar">Regresar</button>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>


            <!-- Modal Registrar Promocion -->
    <div class="modal fade" id="exampleModal2" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="regProm">Registrar Promoción</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>

                </div>
                <div class="modal-body">
                    <form role="form" onsubmit="return false;">
                        <div class="row form-group col-xs-12">
                            <div class="form-group col-xs-12">
                                <label for="inputName">Nombre</label>
                                <input type="text" class="form-control" id="Nombre"  />
                            </div>
                        </div>

                        <div class="row form-group col-xs-12">
                            <div class="form-group col-xs-6">
                                <label for="inputName" class="form-group col-xs-12">Fecha Inicio</label>
                                <div class="form-group col-xs-12">
                                    <input type="date" id="fecha-inicio" class="form-control date-range-filter"/>
                                </div>
                            </div>
                            <div class="form-group col-xs-6">
                                <label for="inputName" class="form-group col-xs-12">Fecha Final</label>
                                <div class="form-group col-xs-12">
                                    <input type="date" id="fecha-final" class="form-control date-range-filter"/>
                                </div>
                            </div>
                        </div>

                        <div class="row form-group col-xs-12">
                            <div class="form-group col-xs-6">
                                <label for="inputName" class="form-group col-xs-12">Hora Inicio</label>
                                <div  class="form-group col-xs-12">
                                    <input type="time" id="hora-inicio" class="form-control date-range-filter"/>
                                </div>
                            </div>
                            <div class="form-group col-xs-6">
                                <label for="inputName" class="form-group col-xs-12">Hora Fin</label>
                                <div  class="form-group col-xs-12">
                                     <input type="time" id="hora-fin" class="form-control date-range-filter"/>
                                </div>      
                            </div>
                        </div>

                        <div class="row form-group col-xs-12">
                            <div class="form-group col-xs-5">
                                <label for="inputName" class="form-group col-xs-12">Activar Promoción</label>
                            </div>
                            <div class="form-group col-xs-7">
                                <div  class="form-group col-xs-12">
                                    <div class="form-group col-xs-3">
                                        <label class="radio-inline">
                                            <input type="radio" name="inlineRadioOptions" id="inlineRadio1" value="1" class="horizontal" checked />SI
                                        </label>                            
                                    </div>
                                    <div class="form-group col-xs-3 ">
                                        <label class="radio-inline">
                                            <input type="radio" name="inlineRadioOptions" id="inlineRadio2" value="2" class="horizontal" />NO
                                        </label>
                                    </div>
                                </div>      
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="row form-group col-xs-12">
                                <label for="inputName">Producto con Promocion</label>
                            </div>
                                <div class="row form-group col-xs-12">

                                    <div class="form-group  col-xs-12">
                                        <div class="form-group col-xs-5">
                                            <p><b>Por la compra de:</b></p>
                                        </div>
                                        <div class="form-group col-xs-6">
                                            <input type="text" class="form-control" id="id_Producto_reg" placeholder="Ingrese un producto"/>
                                            <input type="hidden" class="form-control horizontal" id="id_codProducto_reg"/>
                                        </div>
                                    </div>

                                </div>       
                     
                                <div class="row form-group col-xs-12">
                                    <div class="form-group col-xs-3" style="padding-right: 0% !important;">
                                        <label for="inputName" class="form-group col-xs-12">por un total de</label>
                                    </div>
                                    <div  class="form-group col-xs-3" style="padding-right: 0% !important;">
                                        <input type="text" id="txt-cant" class="form-control date-range-filter"/>
                                    </div>

                                    <div class="form-group col-xs-4" style="padding-right: 0% !important;">
                                        <select class="form-control horizontal" id="id_unidadBase">
                                            <option value = "0"> SOLES </option>
                                        </select>
                                    </div>

                                    <div class="form-group col-xs-2" style="padding-right: 0% !important;padding-left: 0%;">
                                        <label for="inputName" class="form-group col-xs-12">o más</label>
                                    </div>
                                </div> 
                        </div>

                        <div class="form-group">
                            <div class="row form-group col-xs-12">
                                <label for="inputName">Productos Promocionados</label>
                            </div>



                                <div class="row form-group  col-xs-12">
                                    <label for="inputName" class="form-group col-xs-12">Recibirá</label>
                                </div>
                                <div class="form-group col-xs-12">
                                    <div class="form-group col-xs-3">
                                        <input type="text" class="form-control" id="id_Producto_promo" placeholder="Ingrese Producto"/>
                                        <input type="hidden" class="form-control horizontal" id="id_codProducto_promo"/>
                                    </div>

                                    <div  class="form-group col-xs-1" style="padding-right: 0% !important;padding-left: 0% !important;">
                                        <input type="text" id="txt-cantidad" class="form-control date-range-filter"/>
                                    </div>



                                    <div class="form-group col-xs-3" style="padding-right: 0% !important;">
                                        <select class="form-control horizontal" id="id_unidadBase_promo" style="width: 100% !important;">
                                            <option value = "0"> SOLES </option>
                                        </select>
                                    </div>

                                    <div class="form-group col-xs-1" style="padding-right: 0% !important;padding-left: 0% !important;">
                                        <label for="inputName" class="form-group col-xs-12">a S./</label>
                                    </div>
                                    <div  class="form-group col-xs-2" style="padding-right: 0% !important;padding-left: 0% !important;">
                                        <input type="number" min="0.1" step="0.1" id="txt-dinero" class="form-control date-range-filter"/>
                                    </div>
                                    <div class="form-group col-xs-2" style="text-align:center";>
                                        <button type="button" class="btn btn-primary" id="btnAgregar" >
                                                Agregar
                                        </button>
                                    </div>


                            <div class="form-group">
                                <div class="box-body">
                                    <table id="tb_agregar" class="table table-bordered table-hover">
                                        <thead>
                                            <tr>
                                                <th scope="col">codigoProducto</th>
                                                <th scope="col">PRODUCTO</th>
                                                <th scope="col">CANTIDAD</th>
                                                <th scope="col">cod.Pres</th>
                                                <th scope="col">U.BASE</th>                       
                                                <th scope="col">S./</th>
                                                <th scope="col">ACCION</th>
                                            </tr>
                                        </thead>
                                    
                                        <tbody id="">
                                        
                                        </tbody>
                                        <!-- aqui traeremos la data por medio de ajax -->

                                    </table>
                                </div>
                            </div>



                                </div>       
                        </div>

                        <div class="form-group">
                            <label for="inputName">Promoción aplica para</label>
                                <div class="row form-group col-xs-12">
<%--                                    <div class="form-group">
                                        <label>
                                            <input type="checkbox" />
                                            Contado
                                        </label>
                                    </div>
                                    <div class="form-group">
                                        <label>
                                            <input type="checkbox" />
                                            Credito
                                        </label>
                                    </div>--%>

                                    <div class="form-group">
                                        <label class="radio-inline">
                                            <input type="radio" name="promocionAplica" id="aplicaPara1" value="1" class="horizontal" />CONTADO
                                        </label>                            
                                    </div>
                                    <div class="form-group">
                                        <label class="radio-inline">
                                            <input type="radio" name="promocionAplica" id="aplicaPara2" value="2" class="horizontal" />CREDITO
                                        </label>
                                    </div>


                                </div>      
                        </div>


                            <div class="form-group col-xs-12">
                                <div class="row form-group col-xs-6">
                                    <label for="inputName" class="col-sm-2 horizontal">vendedor</label>
                                    <select class="form-control importe horizontal vendedores">
                                        <option value="0">-SELECCIONAR-</option>                                   
                                    </select>
                                </div>
                            </div>

                            <div class="form-group col-xs-12">
                                <div class="row form-group col-xs-6">
                                    <label for="inputName" class="col-sm-2 horizontal ">Cliente</label>
                                    <select class="form-control importe horizontal clientesM">
                                        <option value="0">-SELECCIONAR-</option>                                   
                                    </select>

                                </div>
                            </div> 

                            <div class="form-group col-xs-12">
                                <div class="row form-group col-xs-6">
                                    <label for="inputName" class="col-sm-9 horizontal">Veces que puede usarse la Promocion</label>
                                    <input type="text" id="txt-cantM" class="form-control date-range-filter horizontal" style="width: 17% !important;"/>
                                </div>
                            </div> 
                            <div class="form-group col-xs-12">
                                <div class="row form-group col-xs-6">
                                    <label for="inputName" class="col-sm-9 horizontal">Veces que el vendedor puede usar la promocion</label>
                                    <input type="text" id="txt-cantV" class="form-control date-range-filter horizontal" style="width: 17% !important;"/>
                                </div>
                            </div> 

                            <div class="form-group col-xs-12">
                                <div class="row form-group col-xs-6">
                                    <label for="inputName" class="col-sm-9 horizontal">Veces que el cliente puede usar la promocion</label>
                                    <input type="text" id="txt-cantC" class="form-control date-range-filter horizontal" style="width: 17% !important;"/>
                                </div>
                            </div> 


                    </form>
                        <div class="form-group" style="text-align: right">
                            <button type="button" class="btn btn-default" data-dismiss="modal" id="btnCancelaq">Cancelar</button>
                            <button type="submit" class="btn btn-primary" id="btnGuardar">Guardar</button>
                        </div>
                </div>
            </div>
        </div>
    </div>



        <!-- Modal Editar Promocion -->
    <div class="modal fade" id="exampleModal3" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="editProm">Editar Promoción</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>

                </div>
                <div class="modal-body">
                    <form role="form" onsubmit="return false;">
                        <div class="row form-group col-xs-12">
                            <div class="form-group col-xs-12">
                                <label for="inputName">Nombre</label>
                                <input type="text" class="form-control" id="NombreEditar"  />
                            </div>
                        </div>

                        <div class="row form-group col-xs-12">
                            <div class="form-group col-xs-6">
                                <label for="inputName" class="form-group col-xs-12">Fecha Inicio</label>
                                <div class="form-group col-xs-12">
                                    <input type="date" id="fecha-inicio-Editar" class="form-control date-range-filter"/>
                                </div>
                            </div>
                            <div class="form-group col-xs-6">
                                <label for="inputName" class="form-group col-xs-12">Fecha Final</label>
                                <div class="form-group col-xs-12">
                                    <input type="date" id="fecha-final-Editar" class="form-control date-range-filter"/>
                                </div>
                            </div>
                        </div>

                        <div class="row form-group col-xs-12">
                            <div class="form-group col-xs-6">
                                <label for="inputName" class="form-group col-xs-12">Hora Inicio</label>
                                <div  class="form-group col-xs-12">
                                    <input type="time" id="hora-inicio-Editar" class="form-control date-range-filter"/>
                                </div>
                            </div>
                            <div class="form-group col-xs-6">
                                <label for="inputName" class="form-group col-xs-12">Hora Fin</label>
                                <div  class="form-group col-xs-12">
                                     <input type="time" id="hora-fin-editar" class="form-control date-range-filter"/>
                                </div>      
                            </div>
                        </div>

                        <div class="row form-group col-xs-12">
                            <div class="form-group col-xs-5">
                                <label for="inputName" class="form-group col-xs-12">Estado de Promoción</label>
                            </div>
                            <div class="form-group col-xs-7">
                                <div  class="form-group col-xs-12">
                                    <div class="form-group col-xs-3">
                                        <label class="radio-inline">
                                            <input type="radio" name="inlineRadioOptions" id="inlineRadio1-E" value="option1" class="horizontal" />SI
                                        </label>                            
                                    </div>
                                    <div class="form-group col-xs-3 ">
                                        <label class="radio-inline">
                                            <input type="radio" name="inlineRadioOptions" id="inlineRadio2-E" value="option2" class="horizontal" />NO
                                        </label>
                                    </div>
                                </div>      
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="row form-group col-xs-12">
                                <label for="inputName">Producto con Promocion</label>
                            </div>
                                <div class="row form-group col-xs-12">

                                    <div class="form-group  col-xs-12">
                                        <div class="form-group col-xs-5">
                                            <p><b>Por la compra de:</b></p>
                                        </div>
                                        <div class="form-group col-xs-6">
                                            <input type="text" class="form-control" id="id_Producto_edit" placeholder="Ingrese un producto"/>
                                            <input type="hidden" class="form-control horizontal" id="id_codProducto_edit"/>
                                        </div>
                                    </div>

                                </div>       
                     
                                <div class="row form-group col-xs-12">
                                    <div class="form-group col-xs-3" style="padding-right: 0% !important;">
                                        <label for="inputName" class="form-group col-xs-12">por un total de</label>
                                    </div>
                                    <div  class="form-group col-xs-3" style="padding-right: 0% !important;">
                                        <input type="text" id="txt-cant-edit" class="form-control date-range-filter"/>
                                    </div>

                                    <div class="form-group col-xs-4" style="padding-right: 0% !important;">
                                        <select class="form-control horizontal" id="id_unidadBase_edit">
                                            <option value = "0"> SOLES </option>
                                        </select>
                                    </div>

                                    <div class="form-group col-xs-2" style="padding-right: 0% !important;padding-left: 0%;">
                                        <label for="inputName" class="form-group col-xs-12">o más</label>
                                    </div>
                                </div> 
                        </div>

                        <div class="form-group">
                            <div class="row form-group col-xs-12">
                                <label for="inputName">Productos Promocionados</label>
                            </div>



                                <div class="row form-group  col-xs-12">
                                    <label for="inputName" class="form-group col-xs-12">Recibirá</label>
                                </div>
                                <div class="form-group col-xs-12">
                                    <div class="form-group col-xs-3">
                                        <input type="text" class="form-control" id="id_Producto_promo_edit" placeholder="Ingrese Producto"/>
                                        <input type="hidden" class="form-control horizontal" id="id_codProducto_promo_edit"/>
                                    </div>

                                    <div  class="form-group col-xs-1" style="padding-right: 0% !important;padding-left: 0% !important;">
                                        <input type="text" id="txt-cantidad_edit" class="form-control date-range-filter"/>
                                    </div>



                                    <div class="form-group col-xs-3" style="padding-right: 0% !important;">
                                        <select class="form-control horizontal" id="id_unidadBase_promo_edit" style="width: 100% !important;">
                                            <option value = "0"> SOLES </option>
                                        </select>
                                    </div>

                                    <div class="form-group col-xs-1" style="padding-right: 0% !important;padding-left: 0% !important;">
                                        <label for="inputName" class="form-group col-xs-12">a S./</label>
                                    </div>
                                    <div  class="form-group col-xs-2" style="padding-right: 0% !important;padding-left: 0% !important;">
                                        <input type="number" min="0.1" step="0.1" id="txt-dinero_edit" class="form-control date-range-filter"/>
                                    </div>
                                    <div class="form-group col-xs-2" style="text-align:center";>
                                        <button type="button" class="btn btn-primary" id="id_Agregar_edit" >
                                                Agregar
                                        </button>
                                    </div>


                            <div class="form-group">
                            <label for="inputName">Productos Promocionados</label>

                            <div class="form-group">
                                <div class="box-body">
                                    <table id="tb_detalle_edit" class="table table-bordered table-hover">
                                        <thead>
                                            <tr>
                                                <th scope="col">codigoPromo</th>
                                                <th scope="col">PRODUCTO</th>
                                                <th scope="col">CANTIDAD</th>                     
                                                <th scope="col">PRECIO (S./)</th>
                                                <th scope="col">ACCIÓN</th>
                                            </tr>
                                        </thead>
                                    
                                        <tbody id="">
                                        
                                        </tbody>
                                        <!-- aqui traeremos la data por medio de ajax -->

                                        <tfoot>
                                            <tr>
                                                <th scope="col">codigoPromo</th>
                                                <th scope="col">PRODUCTO</th>
                                                <th scope="col">CANTIDAD</th>                    
                                                <th scope="col">PRECIO (S./)</th>
                                                <th scope="col">ACCIÓN</th>
                                            </tr>
                                        </tfoot>
                                    </table>
                                </div>
                            </div>
                        </div>



                                </div>       
                        </div>

                        <div class="form-group">
                            <label for="inputName">Promoción aplica para</label>
                                <div class="row form-group col-xs-12">
                                    <div class="form-group">
                                        <label>
                                            <input type="checkbox" id="checkbox-1" />
                                            Contado
                                        </label>
                                    </div>
                                    <div class="form-group">
                                        <label>
                                            <input type="checkbox"   id="checkbox-2"/>
                                            Credito
                                        </label>
                                    </div>
                                </div>      
                        </div>


                            <div class="form-group col-xs-12">
                                <div class="row form-group col-xs-6">
                                    <label for="inputName" class="col-sm-2 horizontal">vendedor</label>
                                    <select class="form-control importe horizontal vendedores">
                                        <option value="0">-SELECCIONAR-</option>                                   
                                    </select>
                                </div>
                            </div>

                            <div class="form-group col-xs-12">
                                <div class="row form-group col-xs-6">
                                    <label for="inputName" class="col-sm-2 horizontal ">Cliente</label>
                                    <select class="form-control importe horizontal clientesM">
                                        <option value="0">-SELECCIONAR-</option>                                   
                                    </select>

                                </div>
                            </div> 

                            <div class="form-group col-xs-12">
                                <div class="row form-group col-xs-6">
                                    <label for="inputName" class="col-sm-9 horizontal">Veces que puede usarse la Promocion</label>
                                    <input type="text" id="txt-cantM_edit" class="form-control date-range-filter horizontal" style="width: 17% !important;"/>
                                </div>
                            </div> 
                            <div class="form-group col-xs-12">
                                <div class="row form-group col-xs-6">
                                    <label for="inputName" class="col-sm-9 horizontal">Veces que el vendedor puede usar la promocion</label>
                                    <input type="text" id="txt-cantV_edit" class="form-control date-range-filter horizontal" style="width: 17% !important;"/>
                                </div>
                            </div> 

                            <div class="form-group col-xs-12">
                                <div class="row form-group col-xs-6">
                                    <label for="inputName" class="col-sm-9 horizontal">Veces que el cliente puede usar la promocion</label>
                                    <input type="text" id="txt-cantC_edit" class="form-control date-range-filter horizontal" style="width: 17% !important;"/>
                                </div>
                            </div> 


                    </form>
                        <div class="form-group" style="text-align: right">
                            <button type="button" class="btn btn-default" data-dismiss="modal" id="btnCancelaq_edit">Cancelar</button>
                            <button type="submit" class="btn btn-primary" id="btnModifica_edi">Guardar</button>
                        </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
