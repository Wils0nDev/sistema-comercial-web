<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Loyout.Master" AutoEventWireup="true" CodeBehind="frmMantCliente.aspx.cs" Inherits="VirgenCarmenMantenedor.MantenimientoCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <title></title>
    <link rel="stylesheet" href="css/bootstrap.min.css"" type="text/css" media="screen, projection" />
    <link rel="stylesheet" href="css/web_general.css" type="text/css" media="screen, projection" />
    <link rel="stylesheet" href="css/mant_cliente.css" type="text/css" media="screen, projection" />
    <link rel="stylesheet" href="icon/style.css" />
    <link rel="stylesheet" href="./CSS/alertify.min.css" />
    <link rel="stylesheet" href="./CSS/default.min.css" />
    <script src="Scripts/DataTable/datatables.min.js"></script>
    <script src="Scripts/sweetalert.min.js"></script>
    <script type="text/javascript" src="./Scripts/alertify.min.js"></script>
    <script type="text/javascript" src="./Scripts/JavaScriptMantCliente.js"></script>
    <script src="Scripts/sweetalert.min.js"></script>
     <script src="Scripts/GoogleMapsClient.js"></script>
    <script src="Scripts/mant_cliente.js"></script>
    <script src="//maps.googleapis.com/maps/api/js?key=AIzaSyCA85ouhMdbAp5PZZSzHHu7a5_CUT5daD8&callback&sensor=false" type="text/javascript"></script>

    <style>
        .swal-overlay{
            z-index: 215000000 !important;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <form id="form1" runat="server">

    <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>  <!-- Para usar Ayax -->
    <div class="form-group col-xs-12">
    <div class="box-header" id="B2" runat="server" style="cursor: pointer">
        <h3 class="box-title">Mantenedor de clientes</h3>
    </div>
    <div class="form-group  col-xs-12"">
         <h4 class="box-filtros">Ingrese opción de busqueda</h4>
    </div>
    
        <asp:Panel ID="pnlOpcionDeBusqueda" runat="server" GroupingText="">

            <div class="form-group  col-xs-12">
                <div class="form-group  col-xs-6">
                    <div class="form-group col-xs-3">
                        <label for="rbNumDocumento">
                            <asp:RadioButton ID="rbNumDocumento" runat="server" onclick="desactiva1()" />
                            Nº Documento
                        </label>
                    </div>
                    <div class="form-group col-xs-3">
                        <label for="rbNombres" >
                            <asp:RadioButton ID="rbNombres" runat="server" onclick="desactiva2()" />
                            Nombres
                        </label>
                    </div>
                </div>
                <div class="form-group  col-xs-6">
                    <label for="lblNumDocRuc" class="col-sm-2 label label-default">Nº Doc. / Ruc</label>
                    <asp:TextBox CssClass="form-control" ID="txtNumDoc_Ruc" runat="server" MaxLength="15" Enabled="False"></asp:TextBox>
                </div>
               
            </div>
            <div class="form-group  col-xs-12">
                  <div class="form-group  col-xs-6">
                    <asp:DropDownList CssClass="form-control" ID="cbTipoDocumento" runat="server" Enabled="False">
                    </asp:DropDownList>
                </div>

                <div class="form-group  col-xs-6">
                    <label for="lbNombres" class="col-sm-2 label label-default">Nombres</label>
                    <asp:TextBox CssClass="form-control" ID="txtNombres" runat="server" Enabled="False" MaxLength="70"></asp:TextBox>
                </div>
            </div>
             <div class="form-group  col-xs-12">
                    <asp:Button ID="btnBuscarCliente" CssClass="btn-primary btn-lg" runat="server" Text="Buscar"  OnClick="btnBuscarCliente_Click" />
                    <asp:CustomValidator ID="cvNumDoc_Ruc" runat="server" ControlToValidate="txtNumDoc_Ruc" ErrorMessage="CustomValidator" ClientValidationFunction="valida_NumDoc_Ruc" ForeColor="Red"></asp:CustomValidator>

             </div>
        </asp:Panel>

    <asp:Panel ID="pnCabecera" runat="server">
         <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="form-group  col-xs-12"">
                    <asp:Button CssClass="btn btn-primary" ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" CommandName="agregar"/>
                </div>
           </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>

     <div class="form-group  col-xs-12"">
         <h4 class="box-filtros">Lista de Clientes</h4>
    </div>
        <asp:Panel ID="pnlListaCliente" runat="server" GroupingText="">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div class="form-group col-xs-12">
                    <div>
                        <asp:GridView ID="gvClientes" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" ShowHeaderWhenEmpty="True" PageSize="5" AllowPaging="True" OnPageIndexChanging="gvClientes_PageIndexChanging" OnRowCommand="gvClientes_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="ITEM">
                                    <ItemTemplate>
                                        <asp:Label ID="lbgvItem" runat="server" Text='<%#Container.DataItemIndex + 1%>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CODIGO PERSONA">
                                    <ItemTemplate>
                                        <asp:Label ID="lbgvCodigoPersona" runat="server" Text='<%# Eval("codPersona") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="TIPO PERSONA">
                                    <ItemTemplate>
                                        <asp:Label ID="lbgvTipoPersona" runat="server" Text='<%# Eval("descTipoPersona") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="TIPO DOCUMENTO">
                                    <ItemTemplate>
                                        <asp:Label ID="lbgvTipoDocumento" runat="server" Text='<%# Eval("descTipoDocumento") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="NUM. DOCUMENTO">
                                    <ItemTemplate>
                                        <asp:Label ID="lbgvNumeroDocumento" runat="server" Text='<%# Eval("numeroDocumento") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="RUC">
                                    <ItemTemplate>
                                        <asp:Label ID="lbgvRuc" runat="server" Text='<%# Eval("ruc") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="RAZON SOCIAL">
                                    <ItemTemplate>
                                        <asp:Label ID="lbgvRazonSocial" runat="server" Text='<%# Eval("razonSocial") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="NOMBRES">
                                    <ItemTemplate>
                                        <asp:Label ID="lbgvNombres" runat="server" Text='<%# Eval("nombres") + " " +  Eval("apellidoPaterno") + " " + Eval("apellidoMaterno")%>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="DIRECCION">
                                    <ItemTemplate>
                                        <asp:Label ID="lbgvDireccion" runat="server" Text='<%# Eval("direccion") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CORREO">
                                    <ItemTemplate>
                                        <asp:Label ID="lbgvCorreo" runat="server" Text='<%# Eval("correo") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="TELEFONO">
                                    <ItemTemplate>
                                        <asp:Label ID="lbgvTelefono" runat="server" Text='<%# Eval("telefono") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CELULAR">
                                    <ItemTemplate>
                                        <asp:Label ID="lbgvCelular" runat="server" Text='<%# Eval("celular") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="OPERACIONES">
                                    <ItemTemplate>
                                        <asp:LinkButton CssClass="btn btn-default icon-ver btnVer" ID="lkbVer" runat="server" CommandName="Ver" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"></asp:LinkButton>
                                        <asp:LinkButton CssClass="btn btn-default icon-pencil btnEditar" ID="lkbEditar" runat="server" CommandName="Editar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"></asp:LinkButton>
                                        <asp:LinkButton CssClass="btn btn-default icon-bin btnDelete" ID="lkbEliminar" OnClientClick="return alertaConfirmar2()" runat="server" CommandName="Eliminar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                No se encontraron Clientes....!!! 
                            </EmptyDataTemplate>
                            <HeaderStyle CssClass="headertable" />
                            <FooterStyle CssClass="headertable" />
                            <PagerStyle HorizontalAlign="Right"></PagerStyle>
                           
                        </asp:GridView>
                    </div>
                    <div>
                    </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
    <div class="form-group  col-xs-12">
    <asp:Panel ID="pnlReporte" runat="server">
        <asp:Button CssClass="btn-primary btn-lg" ID="btnReporte" runat="server" Text="Reporte" />
    </asp:Panel>
    </div>


    <!-- INICIO Mostrar MODAL DETALLE DE CLIENTE-->

    <asp:HiddenField ID="campoOculto" runat="server"/>
    <ajaxtoolkit:modalpopupextender runat="server" ID="mdeVerDetalle"
                      TargetControlID="campoOculto"
                      PopupControlID="pnl"  
                      BackgroundCssClass="modalBackground"
                      CancelControlID="btnCancelar"
                      DropShadow="true"
                      >
    </ajaxtoolkit:modalpopupextender>
    
        <asp:Panel runat="server" ID="pnl" CssClass="modalPopup " ScrollBars="Both" Style="display: none">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <div class="form-group col-xs-12">
                        <asp:Label ID="Label2" runat="server"></asp:Label>

                        <div class="modal-header">
                            <h5 class="modal-title">Detalle del Cliente</h5>
                        </div>
                        <div class="form-group">
                            <label for="txtMdTipoPersona" runat="server">Tipo Persona</label>
                            <asp:TextBox CssClass="form-control select-cliente" ID="txtMdTipoPersona" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="txtMdTipoDocumento" runat="server">Tipo Documento</label>
                            <asp:TextBox CssClass="form-control select-cliente" ID="txtMdTipoDocumento" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="txtMdPerfilCliente" runat="server">Perfil Cliente</label>
                            <asp:TextBox CssClass="form-control select-cliente" ID="txtMdPerfilCliente" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="txtMdClasificacion" runat="server">Clasificacion</label>
                            <asp:TextBox CssClass="form-control select-cliente" ID="txtMdClasificacion" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="txtMdFrecuencia" runat="server">Frecuencia</label>
                            <asp:TextBox CssClass="form-control select-cliente" ID="txtMdFrecuencia" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="txtMdListaPrecio" runat="server">Lista Precio</label>
                            <asp:TextBox CssClass="form-control select-cliente" ID="txtMdListaPrecio" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="txtMdRuta" runat="server">Ruta</label>
                            <asp:TextBox CssClass="form-control select-cliente" ID="txtMdRuta" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="txtMdOrdenAtencion" runat="server">Orden Atencion</label>
                            <asp:TextBox CssClass="form-control select-cliente" ID="txtMdOrdenAtencion" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="txtMdNumDocumento" id="labelMrmNumDocumentoVer" runat="server">Numero Documento</label>
                            <asp:TextBox CssClass="form-control select-cliente" ID="txtMdNumDocumento" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="txtMdRuc" runat="server">RUC</label>
                            <asp:TextBox CssClass="form-control select-cliente" ID="txtMdRuc" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="txtMdRazonSocial" runat="server">Razon Social</label>
                            <asp:TextBox CssClass="form-control select-cliente" ID="txtMdRazonSocial" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="txtMdNombres" runat="server">Nombres</label>
                            <asp:TextBox CssClass="form-control select-cliente" ID="txtMdNombres" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="txtMdApellPaterno" runat="server">Apellido Paterno</label>
                            <asp:TextBox CssClass="form-control select-cliente" ID="txtMdApellPaterno" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="txtMdApellMaterno" runat="server">Apellido Materno</label>
                            <asp:TextBox CssClass="form-control select-cliente" ID="txtMdApellMaterno" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="txtMdDireccion" runat="server">Direccion</label>
                            <asp:TextBox CssClass="form-control select-cliente" ID="txtMdDireccion" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="txtMdCorreo" runat="server">Correo</label>
                            <asp:TextBox CssClass="form-control select-cliente" ID="txtMdCorreo" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="txtMdTelefono" runat="server">Telefono</label>
                            <asp:TextBox CssClass="form-control select-cliente" ID="txtMdTelefono" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="txtMdCelular" runat="server">Celular</label>
                            <asp:TextBox CssClass="form-control select-cliente" ID="txtMdCelular" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <asp:Panel ID="Panel5" runat="server" CssClass="form-group col-xs-12" GroupingText="Domicilio Fiscal">
                        <div class="form-group">
                            <label for="txtMdDepartamento" runat="server">Departamento</label>
                            <asp:TextBox CssClass="form-control select-cliente" ID="txtMdDepartamento" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="txtMdProvincia" runat="server">Provincia</label>                            
                            <asp:TextBox CssClass="form-control select-cliente" ID="txtMdProvincia" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="txtMdDistrito" runat="server">Distrito</label>
                            <asp:TextBox CssClass="form-control select-cliente" ID="txtMdDistrito" runat="server"></asp:TextBox>
                        </div>
                    </asp:Panel>
                    <asp:Panel  CssClass="form-group col-xs-12" ID="pnListaPuntosEntrega" runat="server" GroupingText="Puntos de Entrega">
                        <!-- Los puntos de entrega!!-->
                        <asp:GridView ID="gvPuntosEntrega" runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" AllowPaging="true" PageSize="3" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" GridLines="Vertical" Font-Size="10pt" ForeColor="Black" OnPageIndexChanging="gvPuntosEntrega_PageIndexChanging">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:TemplateField HeaderText="O. ENTREGA">
                                    <ItemTemplate>
                                        <asp:Label ID="Label12" runat="server" Text='<%# Eval("ordenEntrega") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="DEPARTAMENTO">
                                    <ItemTemplate>
                                        <asp:Label ID="Label13" runat="server" Text='<%# Eval("descDepartamento") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PROVINCIA">
                                    <ItemTemplate>
                                        <asp:Label ID="Label14" runat="server" Text='<%# Eval("descProvincia") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="DISTRITO">
                                    <ItemTemplate>
                                        <asp:Label ID="Label15" runat="server" Text='<%# Eval("descDistrito") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="DIRECCION">
                                    <ItemTemplate>
                                        <asp:Label ID="Label16" runat="server" Text='<%# Eval("direccion") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="REFERENCIA">
                                    <ItemTemplate>
                                        <asp:Label ID="Label17" runat="server" Text='<%# Eval("referencia") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                No se encontraron Puntos de Entrega....!!!  
                            </EmptyDataTemplate>
                            <FooterStyle BackColor="#CCCC99" />
                            <HeaderStyle CssClass="headertable" />
                            <PagerStyle HorizontalAlign="Right"></PagerStyle>
                            <RowStyle BackColor="#F7F7DE" />
                            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#FBFBF2" />
                            <SortedAscendingHeaderStyle BackColor="#848384" />
                            <SortedDescendingCellStyle BackColor="#EAEAD3" />
                            <SortedDescendingHeaderStyle BackColor="#575357" />
                        </asp:GridView>
                    </asp:Panel>
                    <br />
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="modal-footer">
            <asp:Button CssClass="btn btn-primary" runat="server" ID="btnCancelar" Text="REGRESAR" OnClientClick="btnCancelarDetalle(this);" />
            </div>

        </asp:Panel>
    <!-- FIN Mostrar MODAL DETALLE CLIENTE-->


    <!-- INICIO Mostrar MODAL EDITAR CLIENTE-->

    <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
        <ContentTemplate>

            <asp:HiddenField ID="campoOcultoEditar" runat="server" />
            <ajaxToolkit:ModalPopupExtender runat="server" ID="mdeRegMod"
                TargetControlID="campoOcultoEditar"
                PopupControlID="pnlRegMod"
                BackgroundCssClass="modalBackground"
                DropShadow="true">
            </ajaxToolkit:ModalPopupExtender>

            <asp:Panel ID="pnlRegMod" runat="server" CssClass="modalPopup" ScrollBars="Auto" Style="display: none">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lbTituloMdRegMod" runat="server"></asp:Label>
                        <div class="form-group col-xs-12">
                            <div class="modal-header">
                                <h5 class="modal-title" id="verstock">Registrar Cliente</h5>
                            </div>
                            <div class="form-group">
                                <label for="cbMrmTipoPersona" runat="server">Tipo Persona</label>
                                <asp:DropDownList CssClass="form-control select-cliente" ID="cbMrmTipoPersona" runat="server" onchange="select_TipPersona();"></asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="cbMrmTipoDocumento" runat="server">Tipo Documento</label>
                                <asp:DropDownList CssClass="form-control select-cliente" ID="cbMrmTipoDocumento" runat="server" onchange="desactivaNumDoc_Ruc();"></asp:DropDownList>
                            </div>

                            <div class="form-group">
                                <label for="cbMrmPerfilCliente" runat="server">Perfil Cliente</label>
                                <asp:DropDownList CssClass="form-control select-cliente" ID="cbMrmPerfilCliente" runat="server"></asp:DropDownList>
                            </div>

                            <div class="form-group">
                                <label for="cbMrmClasificacion" runat="server">Clasificacion</label>
                                <asp:DropDownList CssClass="form-control select-cliente" ID="cbMrmClasificacion" runat="server"></asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="cbMrmFrecuencia" runat="server">Frecuencia</label>
                                <asp:DropDownList CssClass="form-control select-cliente" ID="cbMrmFrecuencia" runat="server"></asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="cbMrmTipoListaPrecio" runat="server">Lista Precio</label>
                                <asp:DropDownList CssClass="form-control select-cliente" ID="cbMrmTipoListaPrecio" runat="server"></asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="cbMrmRuta" runat="server">Ruta</label>
                                <asp:DropDownList CssClass="form-control select-cliente" ID="cbMrmRuta" runat="server"></asp:DropDownList>
                            </div>

                            <div class="form-group">
                                <label for="txtMrmOrdenAtencion" runat="server">Orden Atencion</label>
                                <asp:TextBox CssClass="form-control select-cliente" ID="txtMrmOrdenAtencion" runat="server"  onKeyPress="return validarOrdenAtencion(event)"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:CustomValidator CssClass="mensaje-validacion" ID="cvMrnOrdenAtencion" runat="server" ErrorMessage="CustomValidator" ClientValidationFunction="valida_txtMrmOrdenAtencion" ControlToValidate="txtMrmOrdenAtencion"></asp:CustomValidator>
                                <asp:Label ID="lbMrmCodPersona" runat="server" Text="CodPersona" Visible="False"></asp:Label>
                            </div>
                            <div class="form-group num-doc">

                                <label for="txtMrmNumDocumento" id="labelMrmNumDocumento" runat="server">Número de doc.</label>
                                <asp:TextBox CssClass="form-control select-cliente" ID="txtMrmNumDocumento" onkeyup="keyClienteReniec();" runat="server" MaxLength="15"></asp:TextBox>
                                <div id="mensaje_consulta_reniec" style="background-color:green; color:white;" ></div>
                            </div>
                            <div class="form-group">
                                <asp:CustomValidator CssClass="mensaje-validacion" ID="cvMrmNumDocumento" runat="server" ErrorMessage="CustomValidator" ClientValidationFunction="valida_txtMrmNumDocumento" ControlToValidate="txtMrmNumDocumento"></asp:CustomValidator>
                            </div>

                            <div class="form-group">
                                <label for="txtMrmRUC" runat="server">RUC</label>
                                <asp:TextBox CssClass="form-control select-cliente" ID="txtMrmRUC" onkeyup="keyClienteSunat();" runat="server" MaxLength="11"></asp:TextBox>
                                <div style="background-color:white; color:white;" >Consultando</div>
                                <div id="mensaje_consulta_sunat" style="background-color:green; color:white;" ></div>
                            </div>
                            <div class="form-group">
                                <asp:CustomValidator CssClass="mensaje-validacion" ID="cvMrmRUC" runat="server" ErrorMessage="CustomValidator" ClientValidationFunction="valida_txtMrmRUC" ControlToValidate="txtMrmRUC"></asp:CustomValidator>
                            </div>

                            <div class="form-group">
                                <label for="txtMrmRazonSocial" runat="server">Razon Social</label>
                                <asp:TextBox CssClass="form-control select-cliente" ID="txtMrmRazonSocial" runat="server" MaxLength="50"></asp:TextBox>
                                <asp:CustomValidator ID="cvMrmRazonSocial" runat="server" ErrorMessage="CustomValidator" ClientValidationFunction="valida_txtMrmRazonSocial" ForeColor="Red" ControlToValidate="txtMrmRazonSocial" ValidateEmptyText="true"></asp:CustomValidator>
                            </div>

                            <div class="form-group">
                                <label for="txtMrmNombres" runat="server">Nombres</label>
                                <asp:TextBox CssClass="form-control select-cliente" ID="txtMrmNombres" runat="server" MaxLength="30"></asp:TextBox>
                                <asp:CustomValidator ID="cvMrmNombres" runat="server" ErrorMessage="CustomValidator" ClientValidationFunction="valida_txtMrmNombres" ForeColor="Red" ControlToValidate="txtMrmNombres" ValidateEmptyText="true"></asp:CustomValidator>

                            </div>

                            <div class="form-group">
                                <label for="txtMrmApellPaterno" runat="server">Apellido Paterno</label>
                                <asp:TextBox CssClass="form-control select-cliente" ID="txtMrmApellPaterno" runat="server" MaxLength="20"></asp:TextBox>
                                <asp:CustomValidator ID="cvMrmApellPaterno" runat="server" ErrorMessage="CustomValidator" ClientValidationFunction="valida_txtMrmApellPaterno" ForeColor="Red" ControlToValidate="txtMrmApellPaterno" ValidateEmptyText="true"></asp:CustomValidator>

                            </div>

                            <div class="form-group">
                                <label for="txtMrmApellMaterno" runat="server">Apellido Materno</label>
                                <asp:TextBox CssClass="form-control select-cliente" ID="txtMrmApellMaterno" runat="server" MaxLength="20"></asp:TextBox>
                                <asp:CustomValidator ID="cvMrmApellMaterno" runat="server" ErrorMessage="CustomValidator" ClientValidationFunction="valida_txtMrmApellMaterno" ForeColor="Red" ControlToValidate="txtMrmApellMaterno" ValidateEmptyText="true"></asp:CustomValidator>

                            </div>

                            <div class="form-group">
                                <label for="txtMrmDireccion" runat="server">Direccion</label>
                                <button type="button" class="btn btn-primary" id="buttonModals" data-toggle="modal" data-target="#modalMapClient" onclick="display();">
                                    Mapa
                                </button>
                                <asp:TextBox CssClass="form-control select-cliente" ID="txtMrmDireccion" runat="server" MaxLength="100"></asp:TextBox>


                            </div>

                            <div class="form-group">
                                <label for="txtLatitud" runat="server">Latitud</label>
                                <asp:TextBox CssClass="form-control select-cliente" ID="txtLatitud" runat="server" MaxLength="100" Style="display: none"></asp:TextBox>
                                <asp:TextBox CssClass="form-control select-cliente" ID="txtLatitudXa" runat="server" MaxLength="100" Enabled="False"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <label for="txtLongitud" runat="server">Longitud</label>
                                <asp:TextBox CssClass="form-control select-cliente" ID="txtLongitud" runat="server" MaxLength="100" Style="display: none"></asp:TextBox>
                                <asp:TextBox CssClass="form-control select-cliente" ID="txtLongitudYa" runat="server" MaxLength="100" Enabled="False"></asp:TextBox>
                            </div>



                            <div class="form-group">
                                <label for="txtMrmCorreo" runat="server">Correo</label>
                                <asp:TextBox CssClass="form-control select-cliente" ID="txtMrmCorreo" runat="server" TextMode="Email" MaxLength="60"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="txtMrmTelefono" runat="server">Telefono</label>
                                <asp:TextBox CssClass="form-control select-cliente" ID="txtMrmTelefono" runat="server" TextMode="Phone" MaxLength="15" onKeyPress="return soloNumeros(event)"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="txtMrmCelular" runat="server">Celular</label>
                                <asp:TextBox CssClass="form-control select-cliente" ID="txtMrmCelular" runat="server" MaxLength="9" onKeyPress="return soloNumeros(event)"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:CustomValidator CssClass="mensaje-validacion" ID="cvMrmCelular" runat="server" ErrorMessage="CustomValidator" ClientValidationFunction="valida_txtMrmCelular" ControlToValidate="txtMrmCelular"></asp:CustomValidator>
                            </div>
                        </div>
                        <asp:Panel CssClass="form-group col-xs-12" ID="pnlMrmDomicilioFiscal" runat="server" GroupingText="Domicilio Fiscal">

                            <div class="form-group">
                                <label for="cbMrmDepartamento" runat="server">Departamento</label>
                                <asp:DropDownList CssClass="form-control select-cliente" ID="cbMrmDepartamento" AutoPostBack="True"  OnSelectedIndexChanged = "OnSelectedDepartamento" runat="server" ></asp:DropDownList>
                            </div>

                            <div class="form-group">
                                <label for="cbMrmProvincia" runat="server">Provincia</label>
                                <asp:DropDownList CssClass="form-control select-cliente" ID="cbMrmProvincia" AutoPostBack="True"  OnSelectedIndexChanged = "OnSelectedProvincia" runat="server" ></asp:DropDownList>
                            </div>

                            <div class="form-group">
                                <label for="cbMrmDistrito" runat="server">Distrito</label>
                                <asp:DropDownList CssClass="form-control select-cliente" ID="cbMrmDistrito" runat="server"></asp:DropDownList>
                            </div>
                        </asp:Panel>

                        <asp:Panel CssClass="form-group col-xs-12" ID="pnlPuntoEntregaRegMod" runat="server" GroupingText="Puntos de Entrega">
                            <!-- Los puntos de entrega!!-->
                          
                            <asp:GridView ID="gvMrmPuntosEntrega" runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" AllowPaging="True" PageSize="3" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" GridLines="Vertical" Font-Size="10pt" ForeColor="Black" OnPageIndexChanging="gvMrmPuntosEntrega_PageIndexChanging" ShowFooter="True" OnRowCommand="gvMrmPuntosEntrega_RowCommand">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>

                                    <asp:TemplateField HeaderText="O. ENTREGA">
                                        <FooterTemplate>
                                            <asp:TextBox CssClass="form-control" ID="txtgvMrmOrdenEntrega" runat="server" TextMode="Number" MaxLength="4"></asp:TextBox>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbgvMrmOrdenEntrega" runat="server" Text='<%# Eval("ordenEntrega") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DEPARTAMENTO">
                                        <FooterTemplate>
                                            <asp:DropDownList CssClass="form-control" ID="cbgvMrmDepartamento" AutoPostBack="True"  OnSelectedIndexChanged = "OnSelectedDepartamentoPE" runat="server" Width="140" >
                                            </asp:DropDownList>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbgvMrmDescDepartamento" runat="server" Text='<%# Eval("descDepartamento") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PROVINCIA">
                                        <FooterTemplate>
                                            <asp:DropDownList CssClass="form-control" ID="cbgvMrmProvincia" AutoPostBack="True"  OnSelectedIndexChanged = "OnSelectedProvinciaPE" runat="server" EnableViewState="True" EnableTheming="True" >
                                            </asp:DropDownList>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbgvMrmDescProvincia" runat="server" Text='<%# Eval("descProvincia") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DISTRITO">
                                        <FooterTemplate>
                                            <asp:DropDownList CssClass="form-control" ID="cbgvMrmDistrito" runat="server" onchange="actualizarUbigeoPe(this);">
                                            </asp:DropDownList>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbgvMrmDescDistrito" runat="server" Text='<%# Eval("descDistrito") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DIRECCION">
                                        <FooterTemplate>
                                            <asp:TextBox CssClass="form-control" ID="txtgvMrmDireccion" runat="server" Width="200px" MaxLength="200" TextMode="SingleLine"></asp:TextBox>
                                            <asp:TextBox CssClass="form-control" ID="txtLatitudPE" runat="server" Width="200px" MaxLength="200" TextMode="SingleLine" Style="display: none"></asp:TextBox>
                                            <asp:TextBox CssClass="form-control" ID="txtLongitudPE" runat="server" Width="200px" MaxLength="200" TextMode="SingleLine" Style="display: none"></asp:TextBox>
                                            <button type="button" class="btn btn-primary moda-pentrega" id="buttonModalsPentrega" data-toggle="modal" data-target="#modalMapClient" onclick="displaytwo();">Mapa</button>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbgvMrmDireccion" runat="server" Text='<%# Eval("direccion") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="REFERENCIA">
                                        <FooterTemplate>
                                            <asp:TextBox CssClass="form-control" ID="txtgvMrmReferencia" runat="server" Width="200px" TextMode="SingleLine" MaxLength="200"></asp:TextBox>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbgvMrmReferencia" runat="server" Text='<%# Eval("referencia") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="OPERACIONES">
                                        <FooterTemplate>
                                            <asp:LinkButton CssClass="btn btn-primary" ID="lkbMrmAgregarPe" runat="server" OnClick="lkbMrmAgregarPe_Click">Agregar</asp:LinkButton>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lkbMrmEliminarPe" runat="server" CommandName="EliminarPuntoEntrega" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">Eliminar</asp:LinkButton>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    No se encontraron Puntos de Entrega....!!!  
                                </EmptyDataTemplate>
                                <FooterStyle BackColor="#CCCC99" />
                                <HeaderStyle CssClass="headertable" />
                                <PagerStyle HorizontalAlign="Right"></PagerStyle>
                                <RowStyle BackColor="#F7F7DE" />
                                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                                <SortedAscendingHeaderStyle BackColor="#848384" />
                                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                                <SortedDescendingHeaderStyle BackColor="#575357" />
                            </asp:GridView>
                            
                        </asp:Panel>
                        <br />

                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="modal-footer perso-nalizado">
                    <asp:Button CssClass="btn btn-default" ID="btnCancelarMdRegMod" runat="server" Text="REGRESAR" OnClick="btnCancelarMdRegMod_Click" OnClientClick="btnCancelarMdRegMod_Click(this);" />
                    <asp:Button CssClass="btn btn-primary" ID="btnAceptarMdRegMod" runat="server" Text="ACEPTAR" OnClientClick="return jsValidarCliente()" OnClick="btnAceptarMdRegMod_Click" />
                </div>

            </asp:Panel>
        </ContentTemplate>
        </asp:UpdatePanel>
    <!-- FIN Mostrar MODAL EDITAR CLIENTE-->
        </div>
    </form>

     <!-- Modal -->
    <div class="modal fade" id="modalMapClient" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Asignación de direcció</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    <div class="form-group" id="Mmensaje">
                        <p id="Mpmensaje"></p>
                    </div>
                </div>
                <div class="modal-body map-modal">
                    <div class="row" style="padding-right:20px">
                        <div class="form-group">
                            <label for="inputName" id="labelDir">Dirección</label>
                            <input type="text" class="form-control" id="txtDireccion" />
                            <button type="button" class="btn btn-primary" id="btnDireccion">Buscar</button>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12 modal_body_map">
                            <div class="location-map" id="location-map">
                                <div style="width: 100%; height: 400px;" id="map_canvas"></div>
                            </div>
                        </div>
                    </div>

                    <div class="modal-footer map-modal">
                        <button type="button" class="btn btn-default" data-dismiss="modal" id="btnCancelarModal">Cancelar</button>
                        <button type="submit" class="btn btn-primary" data-dismiss="modal" id="btnGuardarMap">Guardar</button>
                        <button type="submit" class="btn btn-primary" data-dismiss="modal" id="btnGuardarMapPE">Guardar</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    
</asp:Content>

