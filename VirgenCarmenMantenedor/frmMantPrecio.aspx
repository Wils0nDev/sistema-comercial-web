<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Loyout.Master" AutoEventWireup="true" CodeBehind="frmMantPrecio.aspx.cs" Inherits="VirgenCarmenMantenedor.frmMantPrecio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        
 <style type="text/css">
   .modalBackground
    {
        background-color: Black;
        filter: alpha(opacity=40);
        opacity: 0.4;
    }

     .modalPopup {
         background-color: #FFFFFF;
         width: 400px;
         height: 400px;
         border: 3px solid #0DA9D0;
     }

</style>
    <link rel="stylesheet" href="css/bootstrap.min.css"" type="text/css" media="screen, projection" />
   <link rel="stylesheet" href="css/web_general.css" type="text/css" media="screen, projection" />
    <link rel="stylesheet" href="css/mant_precios.css" type="text/css" media="screen, projection" />
    <link rel="stylesheet" href="icon/style.css" type="text/css" media="screen, projection" />
     <link rel="stylesheet" href="css/alertify.min.css" />
     <link rel="stylesheet" href="css/default.min.css" />
     
     <script type="text/javascript" src="Scripts/jquery-3.3.1.min.js"></script>
     <script type="text/javascript" src="Scripts/alertify.min.js"></script> 
     <script type="text/javascript" src="Scripts/JSPrecio.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <form id="form1" runat="server">
        <asp:ScriptManager ID="scMFrmPrecio" runat="server" EnablePartialRendering="true" ScriptMode="Release" EnablePageMethods="true">
        </asp:ScriptManager>
        <asp:Panel runat="server" ID="pnlCombos">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="form-group col-xs-12">
                        <div class="box-header" id="B2" runat="server" style="cursor: pointer">
                            <h3 class="box-title">Precios</h3>
                        </div>
                        <div class="form-group">
                            <h4 class="box-filtros">Ingrese opción de busqueda</h4>
                        </div>
                        <div class="form-group col-xs-12">
                            <div class="form-group col-xs-12">
                                <div class="form-group col-xs-6">
                                    <label for="ddlCategoria" class="col-sm-2 label label-default">Categoria</label>
                                    <asp:DropDownList CssClass="form-control" ID="ddlCategoria" runat="server"
                                        AppendDataBoundItems="true" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem Text="Seleccionar" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group col-xs-6">
                                    <label for="Subcategoria" class="col-sm-2 label label-default">Subcategoria</label>
                                    <asp:DropDownList CssClass="form-control" ID="ddlSubcategoria" runat="server"
                                        AppendDataBoundItems="true">
                                        <asp:ListItem Text="Seleccionar" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group col-xs-12">
                                <div class="form-group col-xs-6">
                                    <label for="ddlFabricante" class="col-sm-2 label label-default">Fabricante</label>
                                    <asp:DropDownList CssClass="form-control" runat="server" ID="ddlFabricante" AppendDataBoundItems="true">
                                        <asp:ListItem Text="Seleccionar" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group col-xs-6">
                                    <label for="ddlProveedor" class="col-sm-2 label label-default">Proveedor</label>
                                    <asp:DropDownList CssClass="form-control" runat="server" ID="ddlProveedor" AppendDataBoundItems="true">
                                        <asp:ListItem Text="Seleccionar" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group col-xs-12">
                                <div class="form-group col-xs-6">
                                    <label for="txtProducto" class="col-sm-2 label label-default">Producto</label>                                    
                                    <asp:TextBox CssClass="form-control" runat="server" ID="txtProducto"></asp:TextBox>
                                </div>
                                <div class="form-group col-xs-6">
                                    <asp:Button CssClass="ButtonSecundarioCampo100 btn-primary btn-lg" runat="server" Text="Buscar" ID="btnBuscar" OnClick="btnBuscar_Click" />
                                </div>                            
                            </div>
                             <asp:Button CssClass="ButtonSecundarioCampo100 btn-primary btn-lg" runat="server" Text="Fact. Distribucion" ID="btnFactDistribucion" OnClick="btnFactDistribucion_Click"  />                              
                              
                        </div>                      
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>

        <!-- GRID VIEW PRINCIPAL INICIO-->
        <div class="form-group col-xs-12">
                    <h4 class="box-filtros" id="titleSelect">Listado de Precios</h4>
        </div>
        <div class="form-group col-xs-12">
        <asp:UpdatePanel ID="upCrudGrid1" runat="server">
            <ContentTemplate>                
                <asp:GridView

                    ID="grdViewPrincipal" runat="server" 
                    AutoGenerateColumns="False" EmptyDataText="No hay Registros"
                    DataKeyNames="codProducto"
                    AllowPaging="True" OnRowCommand="grdViewPrincipal_RowCommand" CellPadding="4"  GridLines="None"
                    OnPageIndexChanging="grdViewPrincipal_PageIndexChanging" PageSize="5" >
                    <AlternatingRowStyle BackColor="White" />

                    <Columns>
                        <asp:BoundField DataField="codProveedor" Visible="false" />
                        <asp:BoundField HeaderText="Proveedor" DataField="descProveedor" />

                        <asp:BoundField DataField="codFabricante" Visible="false" />
                        <asp:BoundField HeaderText="Fabricante" DataField="descFabricante" />

                        <asp:BoundField DataField="codCategoria" Visible="false" />
                        <asp:BoundField HeaderText="Categoria" DataField="descCategoria" />

                        <asp:BoundField DataField="codSubcategoria" Visible="false" />
                        <asp:BoundField HeaderText="SubCategoria" DataField="descSubcategoria" />

                        <asp:BoundField HeaderText="Codigo" DataField="codProducto" />

                        <asp:BoundField HeaderText="Descripcion" DataField="descProducto" />

                        <asp:BoundField HeaderText="Precio Costo" DataField="precioCosto" DataFormatString="{0:0.00}" />

                        <asp:TemplateField HeaderText="Tipos de Precios">
                            <ItemTemplate>
                                <asp:Button CssClass="icon-ver btnVer" runat="server" ID="btnVerDetalle" CommandName="ver" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button CssClass="icon-pencil btnEditar" runat="server" ID="btnEditar"  CommandName="editar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle CssClass="headertable" />
                     <PagerStyle HorizontalAlign="Right"></PagerStyle>
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True"  />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
                <div style="text-align:center">
              <asp:Label ID="lblMensaje" runat="server" Text="NO SE ENCONTRARON REGISTROS." Style="color: red; text-align:center;"></asp:Label>
            </div>
            </ContentTemplate>

        </asp:UpdatePanel>
        </div>
        <!-- GRID VIEW PRINCIPAL FIN -->

        <!-- PANEL VER DETALLE INICIO -->
        <!-- Ventana modal (gridview) /VER DETALLE PRECIOS - NOTA: Update Panel anula el evento Click por tanto no se debe usar-->
        <asp:Panel runat="server" ID="pnlVerDetallePrecios" CssClass="modalPopup" Width="30%" ScrollBars="Both" Style="display: none">

            <!-- gridview modal (Campos de la Base de datos) -->
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="modal-header">
                            <h5 class="modal-title" >Detalle Precio</h5>
                     </div>
                     <div class="form-group col-xs-12">
                    <div class="form-group">  
                            <label for="codProducto" runat="server">Producto</label>     
                            <asp:TextBox CssClass="form-control" runat="server" ID="codProducto" Enabled="false" ></asp:TextBox>
                      </div>
                     <div class="form-group">
                            <label for="descProducto" runat="server">Descripcion</label>     
                            <asp:TextBox CssClass="form-control" runat="server" ID="descProducto" Enabled="false" Style="margin-left: 15px" Width="210px"></asp:TextBox>
                        </div>
                </div>
                    <div class="form-group col-xs-12">

                        <asp:GridView ID="grvVerDetallePrecios" runat="server" AutoGenerateColumns="false" Width="320px">
                            <Columns>
                                <asp:BoundField DataField="correlativo" Visible="false" />

                                <asp:BoundField HeaderText="Tipo de Precio" DataField="descripcion" />
                                <asp:BoundField HeaderText="Precio Venta" DataField="precioVenta" DataFormatString="{0:0.00}" />
                            </Columns>
                             <HeaderStyle CssClass="headertable"  />
                        </asp:GridView>
                    </div>
                </ContentTemplate>

            </asp:UpdatePanel>
            <div class="modal-footer mant-precio">
                    <asp:Button CssClass="btn btn-primary" runat="server" ID="btnCancelar" Text="Regresar" />
             </div>
        </asp:Panel>
        <!-- PANEL VER DETALLE FIN -->

        <!-- PANEL ACTUALIZAR INICIO -->
        <!-- Ventana modal (gridview) /ACTUALIZAR DETALLE PRECIOS - NOTA: Update Panel anula el evento Click por tanto no se debe usar-->
        <asp:Panel runat="server" ID="pnlActualizarPrecios" CssClass="modalPopup"  ScrollBars="Both" Style="display: none">

            <!-- gridview modal (Campos de la Base de datos) -->
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                      <div class="modal-header">
                            <h5 class="modal-title" >Modificar Precio</h5>
                        </div>
                    <div class="form-group col-xs-12">
                        <div class="form-group">
                            <label for="codProductoActualizar" runat="server">Producto</label>
                            <asp:TextBox CssClass="form-control" runat="server" ID="codProductoActualizar" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="descProductoActualizar" runat="server">Descripcion</label>
                            <asp:TextBox CssClass="form-control" runat="server" ID="descProductoActualizar" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group col-xs-12">
                        <asp:GridView ID="grvActualizarPrecios"
                            AutoGenerateColumns="false" AutoGenerateEditButton="false"
                            AutoGenerateDeleteButton="false" runat="server"
                            OnRowEditing="grvActualizarPrecios_RowEditing"
                            OnRowCancelingEdit="grvActualizarPrecios_RowCancelingEdit"
                            OnRowUpdating="grvActualizarPrecios_RowUpdating"
                            Width="470px">
                            <Columns>
                                <asp:TemplateField HeaderText="Tipo de Precio">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcorrelativo" Text='<%#Eval("correlativo")%>' Visible="false" runat="server"></asp:Label>
                                        <asp:Label ID="lbldescripcion" Text='<%#Eval("descripcion")%>' runat="server"></asp:Label>

                                    </ItemTemplate>

                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Precio">
                                    <ItemTemplate>
                                        <asp:Label ID="lblprecioVenta" Text='<%#Eval("precioVenta","{0:0.00}")%>' runat="server"></asp:Label>
                                    </ItemTemplate>

                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtPrecioVenta" Text='<%#Eval("precioVenta","{0:0.00}")%>' runat="server" DataFormatString="{0:0.00}" onblur="validarPrecioVenta(this) ;" />

                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField   runat="server" ButtonType="Button" ShowEditButton="true" ShowDeleteButton="false" ItemStyle-Width="150" EditText="Editar" CancelText="Cancelar" UpdateText="Agregar" >
                                 <ControlStyle CssClass="btn btn-primary " />
                                </asp:CommandField>
                                 
                                </Columns>
                            <HeaderStyle CssClass="headertable"  />

                        </asp:GridView> 
                      </div>
                      
                </ContentTemplate>              

            </asp:UpdatePanel>     
            <div  class="modal-footer mant-precio">
                <asp:Button class="btn btn-primary mant-precio"  runat="server" ID="btnCancelarActualizarPrecios" Text="Cancelar" />
            </div>      

        </asp:Panel>
        <!-- PANEL ACTUALIZAR FIN -->

         <!-- PANEL DISTRIBUCION AUTOMATICA DE PRECIOS INICIO -->
        <!-- Ventana modal (gridview) /INGRESAR FACTOR PARA DISTRIBUCION AUTOMATICA DE PRECIOS - NOTA: Update Panel anula el evento Click por tanto no se debe usar-->
        <asp:Panel runat="server" ID="pnlDistribucionAutomaticaPrecios" CssClass="modalPopup"  ScrollBars="Both" Style="display: none">

            <!-- gridview modal (Campos de la Base de datos) -->
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="modal-header">
                            <h5 class="modal-title" >Distribución Automática</h5>
                        </div>              
                    <div class="form-group col-xs-12">
                        <asp:GridView ID="grvDistribucionAutomaticaPrecios"
                            AutoGenerateColumns="false" AutoGenerateEditButton="false"
                            AutoGenerateDeleteButton="false" runat="server"
                            OnRowEditing="grvDistribucionAutomaticaPrecios_RowEditing"
                            OnRowCancelingEdit="grvDistribucionAutomaticaPrecios_RowCancelingEdit"
                            OnRowUpdating="grvDistribucionAutomaticaPrecios_RowUpdating"
                            Width="470px">
                            <Columns>
                                <asp:TemplateField HeaderText="TipoPrecio">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcorrelativo" Text='<%#Eval("tipoPrecio")%>' Visible="false" runat="server"></asp:Label>
                                        <asp:Label ID="lbldescripcion" Text='<%#Eval("descTipoPrecio")%>' runat="server"></asp:Label>

                                    </ItemTemplate>

                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Factor(%)">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFactor" Text='<%#Eval("factor","{00}")%>' runat="server"></asp:Label>
                                    </ItemTemplate>

                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtFactor" Text='<%#Eval("factor","{00}")%>' runat="server" DataFormatString="{00}" onblur="validarFactorDistribucioPrecio(this) ;" />

                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField   runat="server" ButtonType="Button" ShowEditButton="true" ShowDeleteButton="false" ItemStyle-Width="150" EditText="Editar" CancelText="Cancelar" UpdateText="Agregar" >
                                 <ControlStyle CssClass="btn btn-primary " />
                                </asp:CommandField>
                                 
                                </Columns>
                            <HeaderStyle CssClass="headertable"  />

                        </asp:GridView> 
                      </div>
                      
                </ContentTemplate>              

            </asp:UpdatePanel>     
            <div  class="modal-footer mant-precio">
                <asp:Button class="btn btn-primary mant-precio"  runat="server" ID="btnProcesarDistribucionPrecios" Text="Procesar" OnClick="btnProcesarDistribucionPrecios_Click" />
                <asp:Button class="btn btn-primary mant-precio"  runat="server" ID="btnCancelarDistribucionAutomaticaPrecios" Text="Cancelar" OnClick="btnCancelarDistribucionAutomaticaPrecios_Click" />
          
            </div>      

        </asp:Panel>
        <!-- PANEL DISTRIBUCION AUTOMATICA DE PRECIOS FIN -->

        <!-- modalpopextender(VER DETALLLE PRECIOS) -->
        <asp:HiddenField ID="campoOcultoVerDetallePrecios" runat="server" />

        <ajaxToolkit:ModalPopupExtender runat="server" ID="mdeVerDetalle"
            TargetControlID="campoOcultoVerDetallePrecios"
            PopupControlID="pnlVerDetallePrecios"
            BackgroundCssClass="modalBackground"
            CancelControlID="btnCancelar">
        </ajaxToolkit:ModalPopupExtender>

        <!-- modalpopextender(ACTUALIZAR PRECIOS) -->
        <asp:HiddenField ID="campoOcultoActualizarPrecios" runat="server" />

        <ajaxToolkit:ModalPopupExtender runat="server" ID="mdeActualizarPrecios"
            TargetControlID="campoOcultoActualizarPrecios"
            PopupControlID="pnlActualizarPrecios"
            BackgroundCssClass="modalBackground"
            CancelControlID="btnCancelarActualizarPrecios">
        </ajaxToolkit:ModalPopupExtender>

        <!-- modalpopextender(DISTRIBUCION AUTOMATICA DE PRECIOS) -->
        <asp:HiddenField ID="campoOcultoDistribucionAutomaticaPrecios" runat="server" />

        <ajaxToolkit:ModalPopupExtender runat="server" ID="mdeDistribucionAutomaticaPrecios"
            TargetControlID="campoOcultoDistribucionAutomaticaPrecios"
            PopupControlID="pnlDistribucionAutomaticaPrecios"
            BackgroundCssClass="modalBackground"
        
            >
          
        </ajaxToolkit:ModalPopupExtender>
        
        <asp:Panel runat="server" Font-Size="Small"  class="form-group col-xs-12">
            <h4 class="box-filtros">Carga Masiva</h4>
            <div class="form-group col-xs-6">
                <asp:FileUpload runat="server" ID="fuSubirArchivoServidor" />
            </div>
            <div class="form-group col-xs-6">
                <asp:Button class="btn btn-primary" runat="server" ID="btnProcesar" Text="Procesar" OnClick="btnProcesar_Click" />
            </div>
        </asp:Panel>
        <hr class="new1" />
        <asp:Panel runat="server" Font-Size="Small"  class="form-group col-xs-12">
            <div class="form-group col-xs-6">
                <h4 class="box-filtros">Reporte</h4>
            </div>
            <div class="form-group col-xs-6 report">
                <asp:Button class="btn btn-primary" ID="btnReporte" runat="server" Text="Reporte" OnClick="btnReporte_Click" />
            </div>
        </asp:Panel>
        <asp:HiddenField runat="server" ID="campoOcultoCargaMasiva"/>
    </form>
    
   <script type="text/javascript" src="Scripts/jquery-3.3.1.min.js"></script>
   <script type="text/javascript" src="Scripts/bootstrap.min.js"></script>
</asp:Content>
