<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Loyout.Master" AutoEventWireup="true" CodeBehind="frmMantStock.aspx.cs" Inherits="VirgenCarmenMantenedor.frmMantStock1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <title></title>

   <link rel="stylesheet" href="css/bootstrap.min.css"" type="text/css" media="screen, projection" />
   <link rel="stylesheet" href="css/GridView.css" type="text/css" media="screen, projection" />
   <link rel="stylesheet" href="css/Styles.css" type="text/css" media="screen, projection" />
   <link rel="stylesheet" href="css/web_general.css" type="text/css" media="screen, projection" />
    <link rel="stylesheet" href="icon/style.css" type="text/css" media="screen, projection" />
   <script src="JavaScript/jquery.js"></script>
   <script src="JavaScript/bootstrap.min.js"></script>
   <style type="text/css">
       
   </style>
    <script type="text/javascript">


        function HideMPEPopup() {
            $find("mdemodificardetalle").document;

        }
        function ValidateAndHideMPEPopup() {
            //  hide the Popup 
            if (Page_ClientValidate('AddNewFile')) {
                HideMPEPopup();
            }
        }

            function validarRefrescarPagina()
            {
                var cadenaAleatoria = generadorSecuenciaAleatoria();
                var campoOcultoCargaMasiva = document.getElementById("campoOcultoCargaMasiva"); 
                campoOcultoCargaMasiva.value = cadenaAleatoria;
            }   

            function generadorSecuenciaAleatoria() 
            { 
                var g = ""; 
                for(var i = 0; i < 32; i++) 
                g += Math.floor(Math.random() * 0xF).toString(0xF) 

                return g; 
            }

     </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

    <form id="form1" runat="server" class="form-inline">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true" EnablePageMethods="true">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="upGeneral" class="row" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="form-group col-xs-12">
                        <div class="box-header" id="B2" runat="server" style="cursor: pointer">
                            <h3 class="box-title">STOCK</h3>
                        </div>
                        <div class="form-group">
                            <h4 class="box-filtros">Ingrese opción de busqueda</h4>
                        </div>
                        <div class="form-group col-xs-12" id="B2_reg" runat="server">

                            <div class="form-group col-xs-12">
                                <div class="form-group col-xs-6">
                                    <label for="DropDownList1" class="col-sm-2 label label-default">Categoria</label>
                                    <asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </div>
                                <div class="form-group col-xs-6">
                                    <label for="DropDownList2" class="col-sm-2 label label-default">Sub Categoría</label>
                                    <asp:DropDownList CssClass="form-control" ID="DropDownList2" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group col-xs-12">
                                <div class="form-group col-xs-6">
                                    <label for="DropDownList3" class="col-sm-2 label label-default">Fabricante</label>
                                    <asp:DropDownList CssClass="form-control" ID="DropDownList3" runat="server" AutoPostBack="true">
                                    </asp:DropDownList>
                                </div>

                                <div class="form-group col-xs-6">
                                    <label for="DropDownList4" class="col-sm-2 label label-default">Proveedor</label>
                                    <asp:DropDownList CssClass="form-control" ID="DropDownList4" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group col-xs-12">
                                <div class="form-group col-xs-6">
                                    <label for="txtdescripcion" class="col-sm-2 label label-default">Descripción</label>
                                    <asp:TextBox ID="txtdescripcion" runat="server" CssClass="form-control" MaxLength="100">
                                    </asp:TextBox>
                                </div>

                                <div class="form-group col-xs-6">
                                    <asp:Button ID="btnbuscar" CssClass="ButtonSecundarioCampo100 btn-primary btn-lg" Text="Buscar" runat="server" OnClick="btnbuscar_Click" />
                                </div>
                            </div>
                            <div class="form-group col-xs-12">
                                <h4 class="box-filtros" id="titleSelect">Listado de Articulos</h4>
                            </div>

                            <div class="FilaRegistro">
                                <div id="divGrilla1" runat="server" style="height: 300px; overflow: scroll">
                                    <asp:Panel ID="pnlDatos1" Height="20px" runat="server" ScrollBars="None">
                                        <asp:GridView ID="GridView1" runat="server" Caption="" AutoGenerateColumns="False"
                                            AlternatingRowStyle-CssClass="altrow" PagerStyle-CssClass="pagerstyle" OnRowCommand="GridView1_RowCommand"
                                            OnPageIndexChanging="GridView1_PageIndexChanging">
                                            <Columns>
                                                <asp:BoundField HeaderText="Codigo" DataField="codProducto">
                                                    <FooterStyle HorizontalAlign="Center" Width="20px" Wrap="False" />
                                                    <HeaderStyle HorizontalAlign="Center" Width="20px" Wrap="False" />
                                                    <ItemStyle HorizontalAlign="Center" Width="50px" Wrap="False" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="codCategoria" Visible="false" ItemStyle-HorizontalAlign="Center" />

                                                <asp:BoundField HeaderText="Categoria" DataField="descCategoria" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />

                                                <asp:BoundField DataField="codSubCategoria" Visible="false" ItemStyle-HorizontalAlign="Center" />

                                                <asp:BoundField HeaderText="SubCategoria" DataField="descSubCategoria" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />

                                                <asp:BoundField DataField="codProveedor" Visible="false" />

                                                <asp:BoundField HeaderText="Proveedor" DataField="descProveedor" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />

                                                <asp:BoundField DataField="codFabricante" Visible="false" />

                                                <asp:BoundField HeaderText="Fabricante" DataField="descFabricante" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />

                                                <asp:BoundField HeaderText="Descripcion" DataField="descProducto" ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />

                                                <asp:BoundField HeaderText="Fecha Vencimiento" DataField="fechavencimiento" ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />


                                                <asp:TemplateField HeaderText="Almacen Principal">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbgvAlmPrincipal" runat="server" Text='<%# Eval("cantAlmPrincipal") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Cod_Unidad" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbgvCodUndBase" runat="server" Text='<%# Eval("undBase") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Unidad">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbgvDescUnidadBase" runat="server" Text='<%# Eval("descUndBase") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="10%" HeaderText="Consultar" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <div style="text-align: center;">

                                                            <asp:Button class="icon-ver btnVer" title="Ver" runat="server" ID="btnVerDetalle" CommandName="ver" CommandArgument='<%#Eval("codProducto")+"-"+Eval("descProducto")%>' />
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderStyle-Width="10%" HeaderText="Modificar" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <div style="text-align: center;">
                                                            <asp:Button class="icon-pencil btnEditar" title="Editar" runat="server" ID="btnmodificar" CommandName="modificar" CommandArgument='<%#Eval("codProducto")+"-"+Eval("descProducto")%>' />
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EditRowStyle BackColor="#2461BF" />
                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle CssClass="headertable" />
                                        </asp:GridView>
                                        <br />
                                        <div style="text-align: center">
                                            <asp:Label ID="lblMensaje" runat="server" Text="NO SE ENCONTRARON REGISTROS." Style="color: red; text-align: center;"></asp:Label>
                                        </div>
                                    </asp:Panel>
                                </div>
                            </div>
                        </div>

                        <div class="form-group col-xs-12" id="Div2" runat="server" style="cursor: pointer">
                            <h4 class="box-filtros">Carga Masiva</h4>

                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            
            <div class="form-group col-xs-12">
                <div class="form-group col-xs-6">
                    <label class="col-sm-2 label label-default" style="margin-right:5px">Adjuntar</label>
                    <asp:FileUpload ID="fuDocumentoAjuste" runat="server" ></asp:FileUpload>
                </div>
                <div class="form-group col-xs-6">
                    <asp:Button CssClass="btn btn-primary" ID="Button2" Text="Procesar archivo" runat="server" OnClick="Button2_Click" OnClientClick="validarRefrescarPagina();" />
                </div>
            </div>
            <hr class="new1" />
            <div class="form-group col-xs-12">
                <div class="form-group col-xs-6">
                    <h4 class="box-filtros" >Reporte</h4>                    
                </div>
                <div class="form-group col-xs-6">
                    <asp:Button CssClass="btn btn-primary" ID="btnreporte" Text="Reporte" runat="server" OnClick="btnreporte_Click" />
                </div>
            </div>
            <asp:HiddenField runat="server" ID="campoOcultoCargaMasiva"/>
            <!-- INICIO MODAL VER ALMACEN-->
            <asp:Panel runat="server" ID="pnl" CssClass="modalPopup" Width="50%" ScrollBars="Both" Style="display: none">
                
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="modal-header">
                            <h5 class="modal-title" id="verstock">Ver Stock</h5>
                        </div>
                        <div class="form-group">
                            <label for="codProducto" runat="server">Producto</label>
                            <asp:TextBox CssClass="form-control" runat="server" ID="codProducto" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="codProducto" runat="server">Descripcion</label>
                            <asp:TextBox CssClass="form-control" runat="server" ID="DescProducto" Enabled="false"></asp:TextBox>
                        </div>

                        <asp:GridView ID="GridVie" runat="server" AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField DataField="transaccion" Visible="false" />
                                <asp:BoundField HeaderText="Almacen" DataField="descAlmacen" />
                                <asp:BoundField DataField="codProducto" Visible="false" />
                                <asp:BoundField HeaderText="Stock" DataField="stock" />
                            </Columns>
                            <HeaderStyle CssClass="headertable"  />
                        </asp:GridView>
                        <br />
                        <label for="txttotalStock" runat="server">Total Stock</label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="txttotalStock" Enabled="false"></asp:TextBox>

                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="modal-footer ver-stock">
                    <asp:Button class="btn btn-primary" runat="server" ID="btnCancelar" Text="Regresar" />
                </div>
            </asp:Panel>
            <asp:HiddenField ID="campoOculto" runat="server" />

            <ajaxToolkit:ModalPopupExtender runat="server" ID="mdeVerDetalle"
                TargetControlID="campoOculto"
                PopupControlID="pnl"
                BackgroundCssClass="modalBackground"
                CancelControlID="btnCancelar">
            </ajaxToolkit:ModalPopupExtender>
            <!-- FIN MODAL VER ALMACEN-->

            <!-- INICIO MODAL MODIFICAR ALMACEN-->
            <asp:Panel runat="server" ID="pn2" CssClass="modalPopup" Width="50%" ScrollBars="Both" Style="display: none">
                <asp:UpdatePanel runat="server">
                   
                    <ContentTemplate>
                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLabel">Editar stock</h5>
                           
                            <div class="form-group" id="Mmensaje" style="display: none;">
                                <p id="Mpmensaje"></p>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="descripcionproducto" runat="server">Producto</label>
                            <asp:TextBox CssClass="form-control" runat="server" ID="codigoproducto" Enabled="false"></asp:TextBox>
                        </div>
                        
                        <div class="form-group">
                            <label  for="descripcionproducto" runat="server">Descripcion</label>
                            <asp:TextBox CssClass="form-control" runat="server" ID="descripcionproducto" Enabled="false"></asp:TextBox>
                        </div>

                        <asp:GridView ID="GridViewmd" runat="server" AutoGenerateColumns="false" OnRowEditing="grdNotes_RowEditing"
                            OnRowCancelingEdit="grdNotes_RowCancelingEdit" OnRowUpdating="grdNotes_RowUpdating">
                            <Columns>

                                <asp:TemplateField HeaderText="CodAlmacen" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_codAlmacen" runat="server" Text='<%#Eval("transaccion") %>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:BoundField HeaderText="Almacen" DataField="descAlmacen" />


                                <asp:TemplateField HeaderText="CodigoProducto" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_codProducto" runat="server" Text='<%#Eval("codProducto") %>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Stock" SortExpression="stock">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("stock") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="Textstock" runat="server" Text='<%# Bind("stock") %>' ValidationGroup="AddNewFile" TextMode="Number"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvNombreDocumento" runat="server"
                                            ErrorMessage="Ingrese Nombre" ControlToValidate="Textstock"
                                            ForeColor="Red" ValidationGroup="AddNewFile">*</asp:RequiredFieldValidator>

                                    </EditItemTemplate>

                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button  class="icon-pencil btnEditar" ID="btn_Edit" runat="server"  CommandName="Edit" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Button class="btn btn-primary btn-actualizar" ID="btn_Update" runat="server" Text="Actualizar" CommandName="Update" OnClientClick="ValidateAndHideMPEPopup()" CausesValidation="false" />
                                        <asp:Button class="btn btn-primary btn-cancel" ID="btn_Cancel" runat="server" Text="Cancelar" CommandName="Cancel" CausesValidation="False" />
                                    </EditItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle CssClass="headertable"  />
                        </asp:GridView>
                        <asp:Label ID="txtmensaje" runat="server" Text="No se permiten valores negativos" Style="color: red; text-align:center;"></asp:Label>
                         <br />
                        <label for="txtTotalStockactualizado">Total Stock</label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtTotalStockactualizado" Enabled="false"></asp:TextBox>
                        
                    </ContentTemplate>
                </asp:UpdatePanel>
        
                <div class="modal-footer">                  
                    <asp:Button class="btn btn-primary" runat="server" ID="Button1" Text="Regresar" />
                </div>
                
            </asp:Panel>
           
            <asp:HiddenField ID="HiddenField1" runat="server" />

            <ajaxToolkit:ModalPopupExtender runat="server" ID="mdemodificardetalle"
                TargetControlID="HiddenField1"
                PopupControlID="pn2"
                BackgroundCssClass="modalBackground"
                CancelControlID="btnCancelar">
            </ajaxToolkit:ModalPopupExtender>
            <!-- FIN MODAL MODIFICAR ALMACEN-->
        </div>
    </form>
</asp:Content>
