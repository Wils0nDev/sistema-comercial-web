using CEN;
using CLN;
using CAD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Collections;
using System.Data.OleDb;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using ExcelDataReader;
using System.Globalization;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;

namespace VirgenCarmenMantenedor
{
    public partial class frmMantStock1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //DESCRIPCION: Pagina de Carga
            //IsPostBack: Primera ves no es PostBack
            //A partir de la segunda vez, cuando se produce algun evento SI es postback

            //VALIDAR SI SE PRESIONO EL BOTON REFRESCAR DEL NAVEGADOR - INICIO
            HiddenField campoOcultoCargaMasiva = (HiddenField)(Page.Form.FindControl("campoOcultoCargaMasiva"));
            String valorGeneradoFileUpload = campoOcultoCargaMasiva.Value;
            String valorSesionCargaArchivo = "";

            System.Web.HttpContext _httpContext = System.Web.HttpContext.Current;
            //VALIDAR SI SE PRESIONO EL BOTON REFRESCAR DEL NAVEGADOR - FIN

            if (!IsPostBack)
            {
                llenarcategorias();
                llenarListaProveedor();
                llenarListaFabricante();
                llenarGriedView();
                lblMensaje.Visible = false;
                txtmensaje.Visible = false;
            }
            //VALIDAR SI SE PRESIONO EL BOTON REFRESCAR DEL NAVEGADOR - INICIO
            valorSesionCargaArchivo = (String)Session["valorSesionCargaArchivo"];

            if (!String.IsNullOrEmpty(valorSesionCargaArchivo))
            {
                if (valorSesionCargaArchivo.Equals(valorGeneradoFileUpload))
                { //Se hizo clic en el boton Refrescar del Navegador
                    _httpContext.Items.Add("RefrescarPagina", true);
                    // llenarGriedViewfiltro1();
                }
                else
                {
                    //Sino se está refrescando la página se debe almacenar el nuevo valor
                    //por si luego se refresca la página y se tenga que saber si es el mismo valor o no
                    valorSesionCargaArchivo = valorGeneradoFileUpload;
                    Session["valorSesionCargaArchivo"] = valorSesionCargaArchivo;
                    _httpContext.Items.Add("RefrescarPagina", false);
                }

            }
            else
            {
                if (!(valorGeneradoFileUpload.Equals(null) || valorGeneradoFileUpload.Equals("")))
                { //Se hizo clic en el boton Procesar Archivo (Carga Masiva)
                    valorSesionCargaArchivo = valorGeneradoFileUpload;
                    Session["valorSesionCargaArchivo"] = valorSesionCargaArchivo;
                    _httpContext.Items.Add("RefrescarPagina", false);

                }

            }
        }


        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            CLNDetalleAlmacen clndetalle = new CLNDetalleAlmacen();
            CENDatosDetalleAlmacen cendatosalmacen = new CENDatosDetalleAlmacen();
            List<CENDetalleAlmacen> lista = new List<CENDetalleAlmacen>();
            CLNProducto clnproducto = new CLNProducto();
            if (e.CommandName.Equals("ver"))
            {
                String[] Datos = e.CommandArgument.ToString().Split('-');
                codProducto.Text = Datos[0];
                DescProducto.Text = Datos[1];
                cendatosalmacen = clndetalle.Listadatosdetallealmacen(codProducto.Text.Trim());
                lista = cendatosalmacen.DatosDetalleAlmacen;
                GridVie.DataSource = lista;
                GridVie.DataBind();
                txttotalStock.Text = clnproducto.ObtenerMontoTotalAlmacen(codProducto.Text.Trim()).ToString();
                mdeVerDetalle.Show();
            }
            else if (e.CommandName.Equals("modificar"))
            {
                String[] Datoss = e.CommandArgument.ToString().Split('-');
                codigoproducto.Text = Datoss[CENConstante.g_const_0];
                descripcionproducto.Text = Datoss[CENConstante.g_const_1];
                cendatosalmacen = clndetalle.Listadatosdetallealmacen(codigoproducto.Text.Trim());
                lista = cendatosalmacen.DatosDetalleAlmacen;
                GridViewmd.DataSource = lista;
                GridViewmd.DataBind();
                txtTotalStockactualizado.Text = clnproducto.ObtenerMontoTotalAlmacen(codigoproducto.Text.Trim()).ToString();
                mdemodificardetalle.Show();

            }

        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            GridView1.PageIndex = e.NewPageIndex;
            llenarGriedViewfiltro1();
        }
        private void llenarGriedView()
        {
            //llenar Griew Vied
            int codCategoria = CENConstante.g_const_0;
            int subcategoria = CENConstante.g_const_0;
            int codProveedor = CENConstante.g_const_0;
            int codFabricante = CENConstante.g_const_0;
            string descProducto = CENConstante.g_const_vacio;
            CLNProducto producto = new CLNProducto();
            CENDatosProducto producto1 = new CENDatosProducto();
            List<CENProducto> lista = new List<CENProducto>();
            producto1 = producto.ListaDatosProducto(codCategoria, subcategoria, codProveedor, codFabricante, descProducto);
            lista = producto1.DatosProducto;
            GridView1.DataSource = lista;
            GridView1.DataBind();
        }
        private void llenarGriedViewfiltro()
        {
            // llenar griedview con resultado de filtros
            int codCategoria = CENConstante.g_const_0;
            int subcategoria = CENConstante.g_const_0;
            int codProveedor = CENConstante.g_const_0;
            int codFabricante = CENConstante.g_const_0;
            string descProducto = CENConstante.g_const_vacio;
            CLNProducto producto = new CLNProducto();
            CENDatosProducto producto1 = new CENDatosProducto();
            List<CENProducto> lista = new List<CENProducto>();
            CENProducto listadetalle = new CENProducto();
            try
            {
                if (DropDownList1.SelectedValue != "0") codCategoria = Convert.ToInt32(DropDownList1.SelectedValue);
                if (DropDownList2.SelectedValue != "0") subcategoria = Convert.ToInt32(DropDownList2.SelectedValue);
                if (DropDownList3.SelectedValue != "0") codFabricante = Convert.ToInt32(DropDownList3.SelectedValue);
                if (DropDownList4.SelectedValue != "0") codProveedor = Convert.ToInt32(DropDownList4.SelectedValue);
                if (txtdescripcion.Text != "") descProducto = txtdescripcion.Text;
                producto1 = producto.ListaDatosProducto(codCategoria, subcategoria, codProveedor, codFabricante, descProducto);
                lista = producto1.DatosProducto;

                if (lista != null && lista.Count > CENConstante.g_const_0)
                {
                    GridView1.DataSource = lista;
                    GridView1.DataBind();
                    lblMensaje.Visible = false;
                }
                else
                {

                    datagridvacia();
                    lblMensaje.Visible = true;

                }



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void llenarGriedViewfiltro1()
        {
            // llenar griedview con resultado de filtros
            int codCategoria = CENConstante.g_const_0;
            int subcategoria = CENConstante.g_const_0;
            int codProveedor = CENConstante.g_const_0;
            int codFabricante = CENConstante.g_const_0;
            string descProducto = CENConstante.g_const_vacio;
            CLNProducto producto = new CLNProducto();
            CENDatosProducto producto1 = new CENDatosProducto();
            List<CENProducto> lista = new List<CENProducto>();
            CENProducto listadetalle = new CENProducto();
            try
            {
                codCategoria = Convert.ToInt32(DropDownList1.SelectedValue);
                subcategoria = Convert.ToInt32(DropDownList2.SelectedValue);
                codFabricante = Convert.ToInt32(DropDownList3.SelectedValue);
                codProveedor = Convert.ToInt32(DropDownList4.SelectedValue);
                descProducto = txtdescripcion.Text.Trim();
                producto1 = producto.ListaDatosProducto(codCategoria, subcategoria, codProveedor, codFabricante, descProducto);
                lista = producto1.DatosProducto;
                if (lista != null && lista.Count > CENConstante.g_const_0)
                {
                    GridView1.DataSource = lista;
                    GridView1.DataBind();
                    lblMensaje.Visible = false;
                }
                else
                {
                    datagridvacia();
                    lblMensaje.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void llenarcategorias()
        {

            CLNCategoria clncategoria = new CLNCategoria();
            CENDatoscategoria cencategoria = new CENDatoscategoria();
            List<CENCategoria> lista = new List<CENCategoria>();
            try
            {
                cencategoria = clncategoria.Listadatoscategoria();
                if (cencategoria.ErrorWebSer.TipoErr == CENConstante.g_const_0)
                {
                    lista = cencategoria.DatosCategoria;
                    DropDownList1.DataSource = lista;
                    DropDownList1.DataValueField = "codigoCategoria";
                    DropDownList1.DataTextField = "descCategoria";
                    DropDownList1.DataBind();
                    DropDownList1.Items.Insert(CENConstante.g_const_0, new ListItem("--Seleccionar--", "0"));
                    DropDownList2.Items.Insert(CENConstante.g_const_0, new ListItem("--Seleccionar--", "0"));
                }
                else
                {
                    Page page = HttpContext.Current.Handler as Page;
                    ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + cencategoria.ErrorWebSer.DescripcionErr + "');", true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void llenarListaSubCategorias()
        {
            int categoria = Convert.ToInt32(DropDownList1.SelectedValue);
            CLNSubCategoria clnsubcategoria = new CLNSubCategoria();
            CENDatoSubscategoria cencsubategoria = new CENDatoSubscategoria();
            List<CENSubCategoria> lista = new List<CENSubCategoria>();
            try
            {
                cencsubategoria = clnsubcategoria.Listadatossubcategorias(categoria);
                if (cencsubategoria.ErrorWebSer.TipoErr == CENConstante.g_const_0)
                {
                    lista = cencsubategoria.DatosSubCategoria;
                    DropDownList2.DataSource = lista;
                    DropDownList2.DataValueField = "codigoSubCategoria";
                    DropDownList2.DataTextField = "descSubCategoria";
                    DropDownList2.DataBind();
                    DropDownList2.Items.Insert(CENConstante.g_const_0, new ListItem("--Seleccionar--", "0"));
                }
                else
                {
                    Page page = HttpContext.Current.Handler as Page;
                    ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + cencsubategoria.ErrorWebSer.DescripcionErr + "');", true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void llenarListaFabricante()
        {
            CLNFabricante clnfabricante = new CLNFabricante();
            CENDatosFabricante cenfabricante = new CENDatosFabricante();
            List<CENFabricante> lista = new List<CENFabricante>();
            try
            {
                cenfabricante = clnfabricante.Listadatosfabricante();
                if (cenfabricante.ErrorWebSer.TipoErr == CENConstante.g_const_0)
                {
                    lista = cenfabricante.DatosFabricante;
                    DropDownList3.DataSource = lista;
                    DropDownList3.DataValueField = "codigoFabricante";
                    DropDownList3.DataTextField = "descFabricante";
                    DropDownList3.DataBind();
                    DropDownList3.Items.Insert(CENConstante.g_const_0, new ListItem("--Seleccionar--", "0"));
                }
                else
                {
                    Page page = HttpContext.Current.Handler as Page;
                    ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + cenfabricante.ErrorWebSer.DescripcionErr + "');", true);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void llenarListaProveedor()
        {
            CLNProveedor clnproveedor = new CLNProveedor();
            CENDatosProveedor cenproveedor = new CENDatosProveedor();
            List<CENProveedor> lista = new List<CENProveedor>();
            try
            {
                cenproveedor = clnproveedor.Listadatosproveedor();
                if (cenproveedor.ErrorWebSer.TipoErr == CENConstante.g_const_0)
                {
                    lista = cenproveedor.DatosProveedor;
                    DropDownList4.DataSource = lista;
                    DropDownList4.DataValueField = "codigoProveedor";
                    DropDownList4.DataTextField = "descproveedor";
                    DropDownList4.DataBind();
                    DropDownList4.Items.Insert(CENConstante.g_const_0, new ListItem("--Seleccionar--", "0"));
                }
                else
                {
                    Page page = HttpContext.Current.Handler as Page;
                    ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + cenproveedor.ErrorWebSer.DescripcionErr + "');", true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void datagridvacia()
        {
            //Procedimiento que carga la grid vacia
            List<CENProducto> datagridproductos = new List<CENProducto>();
            datagridproductos.Add(new CENProducto());
            GridView1.DataSource = datagridproductos;
            GridView1.DataBind();
            GridView1.Rows[CENConstante.g_const_0].Visible = false;

        }
        public bool validarDocumento(FileUpload fuDocumento)
        {
            // Funcion que valida el documento adjuntado
            bool vretorno = true; //Variable flag
            string msje = CENConstante.g_const_vacio;    //variable de mensaje
            CADCliente consulta = new CADCliente();


            if (fuDocumento.FileContent.Length == CENConstante.g_const_0)
            {
                msje = consulta.SeleccionarConcepto(CENConstante.g_const_1, CENConstante.g_const_10, CENConstante.g_const_1);
                MostrarMensaje(CENConstante.g_const_2, msje);
                return false;
            }

            return vretorno;
        }
        private bool validartipoDocumento(FileUpload fuDocumento)
        {
            // Funcion que valida el documento adjuntado sea excel
            bool vretorno = true; //Variable flag
            string msje = CENConstante.g_const_vacio;    //variable de mensaje
            CADCliente consulta = new CADCliente();
            string[] cExtension = null;  //Variable de extension de archivo
            cExtension = fuDocumento.FileName.Split('.');
            if (cExtension[cExtension.Length - CENConstante.g_const_1].ToLower() != CENConstante.g_extension_xls &
                   cExtension[cExtension.Length - CENConstante.g_const_1].ToLower() != CENConstante.g_extension_xlsx)
            {
                msje = consulta.SeleccionarConcepto(CENConstante.g_const_1, CENConstante.g_const_10, CENConstante.g_const_2);
                MostrarMensaje(CENConstante.g_const_2, msje);
                return false;
            }
            return vretorno;
        }
        private bool DocumentoCarga(DataTable dt)
        {
            //DESCRIPCION: Permite validar data correcta de la carga masiva
            bool val = true;
            string msje = string.Empty;
            CLNConcepto concepto = new CLNConcepto();
            CADCliente consulta = new CADCliente();
            List<CENConcepto> lista = new List<CENConcepto>();
            CLNProducto producto = new CLNProducto();
            int i = CENConstante.g_const_0;
            int fila = CENConstante.g_const_0; //Fila
            bool flag = true;
            try
            {
                lista = concepto.ListarConceptos(10);
                if (dt.Columns.Count != lista.Count())
                {
                    msje = consulta.SeleccionarConcepto(CENConstante.g_const_1, CENConstante.g_const_10, CENConstante.g_const_4);
                    MostrarMensaje(CENConstante.g_const_1, msje);
                    val = false;
                    return val;
                }
                else
                {
                    val = true;
                }

                foreach (DataColumn Col in dt.Columns)
                {
                    if (val)
                    {
                        string col = dt.Columns[i].ColumnName;
                        if (Col.Caption.ToUpper().Trim() != lista[i].descripcion.ToUpper().Trim())
                        {

                            msje = consulta.SeleccionarConcepto(CENConstante.g_const_1, CENConstante.g_const_10, CENConstante.g_const_5);
                            MostrarMensaje(CENConstante.g_const_1, msje);
                            val = false;
                            return val;
                        }
                    }
                    else
                    {
                        break;
                    }
                    i++;
                }

                if (dt.Rows.Count == CENConstante.g_const_0)
                {
                    msje = consulta.SeleccionarConcepto(CENConstante.g_const_1, CENConstante.g_const_10, CENConstante.g_const_6);
                    MostrarMensaje(CENConstante.g_const_1, msje);
                    val = false;
                    return val;
                }

                for (var r = CENConstante.g_const_0; r < dt.Rows.Count; r++)
                {
                    int xcant = producto.ObtenerCantidad(dt.Rows[r][CENConstante.g_const_0].ToString());
                    if (xcant == CENConstante.g_const_0)
                    {
                        fila = r + CENConstante.g_const_2;
                        msje = consulta.SeleccionarConcepto(CENConstante.g_const_1, CENConstante.g_const_10, CENConstante.g_const_8);
                        msje = msje + dt.Rows[r][CENConstante.g_const_0].ToString();
                        MostrarMensaje(CENConstante.g_const_1, msje);
                        val = false;
                        return val;
                    }
                }
                for (var m = CENConstante.g_const_0; m < dt.Rows.Count; m++)
                {
                    for (var j = CENConstante.g_const_0; j < dt.Columns.Count; j++)
                    {
                        if (j == CENConstante.g_const_0)
                        {
                            string data = dt.Rows[m][j].ToString();

                            if (data is null || data.Trim() == CENConstante.g_const_vacio || data.Length == CENConstante.g_const_0)
                            {

                                fila = m + CENConstante.g_const_2;
                                msje = consulta.SeleccionarConcepto(CENConstante.g_const_1, CENConstante.g_const_10, CENConstante.g_const_7);
                                msje = msje + fila;
                                MostrarMensaje(CENConstante.g_const_1, msje);
                                val = false;
                                return val;
                            }
                            else
                            {
                                if (m >= CENConstante.g_const_1)
                                {
                                    for (var k = CENConstante.g_const_0; k < dt.Rows.Count; k++)
                                    {
                                        if (data.Equals(dt.Rows[k][CENConstante.g_const_0].ToString().Trim()) && k != m)
                                        {

                                            fila = m + CENConstante.g_const_2;
                                            msje = consulta.SeleccionarConcepto(CENConstante.g_const_1, CENConstante.g_const_10, CENConstante.g_const_7);
                                            msje = msje + fila;
                                            MostrarMensaje(CENConstante.g_const_1, msje);
                                            val = false;
                                            flag = false;
                                            break;
                                        }
                                    }
                                }
                                if (!flag)
                                {
                                    break;
                                }

                            }
                        }
                        else if (j > CENConstante.g_const_1)
                        {

                            string datafila = dt.Rows[m][j].ToString();

                            if (datafila is null || datafila.Trim() == CENConstante.g_const_vacio)
                            {

                                fila = m + CENConstante.g_const_2;
                                msje = consulta.SeleccionarConcepto(CENConstante.g_const_1, CENConstante.g_const_10, CENConstante.g_const_7);
                                msje = msje + fila;
                                MostrarMensaje(CENConstante.g_const_1, msje);
                                val = false;
                                return val;
                            }
                            else
                            {
                                int numero = CENConstante.g_const_0;
                                if (!int.TryParse(dt.Rows[m][j].ToString(), out numero))
                                {

                                    fila = m + CENConstante.g_const_2;

                                    msje = consulta.SeleccionarConcepto(CENConstante.g_const_1, CENConstante.g_const_10, CENConstante.g_const_9);
                                    msje = msje + fila;
                                    MostrarMensaje(CENConstante.g_const_1, msje);
                                    val = false;
                                    return val;
                                }

                                int datat = Convert.ToInt32(dt.Rows[m][j].ToString());
                                if (datat < CENConstante.g_const_0)
                                {

                                    fila = m + CENConstante.g_const_2;
                                    msje = consulta.SeleccionarConcepto(CENConstante.g_const_1, CENConstante.g_const_10, CENConstante.g_const_7);
                                    msje = msje + fila;
                                    MostrarMensaje(CENConstante.g_const_1, msje);
                                    val = false;
                                    return val;
                                }
                            }


                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return val;
        }
        private void MostrarMensaje(int tipo, string msje)
        {
            string mensaje = string.Empty; //Mensaje por defecto
            if (tipo == CENConstante.g_const_1)
            {
                CADCliente consulta = new CADCliente();
                mensaje = consulta.SeleccionarConcepto(CENConstante.g_const_1, CENConstante.g_const_10, CENConstante.g_const_3);
                Response.Write("<script>alert('" + mensaje + CENConstante.g_const_espacio + msje + "')</script>");
            }
            else
            {
                Response.Write("<script>alert('" + msje + "')</script>");
            }

        }

        private bool CargarDocumentoExcel(DataTable dt)
        {
            //cargando excel
            CLNAlmacen almacen = new CLNAlmacen();
            CENDatosCodigoAlmacen datosalmacen = new CENDatosCodigoAlmacen();
            string columna = string.Empty;
            int codAlmacen = CENConstante.g_const_0;
            bool resul = true;

            CLNRegistroStock clnregistrostock = new CLNRegistroStock();
            CENDatosRegistrostock cendatosregistrostock = new CENDatosRegistrostock();

            for (var m = CENConstante.g_const_0; m < dt.Rows.Count; m++)
            {
                for (var j = CENConstante.g_const_0; j < dt.Columns.Count; j++)
                {

                    if (j > CENConstante.g_const_1)
                    {
                        columna = dt.Columns[j].ColumnName; //nombre de columna de almacenes
                        datosalmacen = almacen.CodigoAlmacen(columna);
                        codAlmacen = datosalmacen.CodAlmacen; //codigo de almacen
                        cendatosregistrostock = clnregistrostock.DatosRegistroStock(Convert.ToInt32(dt.Rows[m][j].ToString()), dt.Rows[m][0].ToString(), codAlmacen);
                        if (cendatosregistrostock.ErrorWebSer.TipoErr == CENConstante.g_const_1)
                        {
                            resul = false;
                            break;
                        }
                    }
                }
                columna = CENConstante.g_const_espacio;
                codAlmacen = CENConstante.g_const_0;
            }
            return resul;
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            llenarListaSubCategorias();
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void btnbuscar_Click(object sender, EventArgs e)
        {
            llenarGriedViewfiltro1();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string msje = string.Empty;    //variable de mensaje
            string tempPath = string.Empty; //Directorio de archivo temporal
            string excel = string.Empty;    //Ruta fisica de archivo
            string diagonal = string.Empty; //diagonal
            CLNConcepto concepto = new CLNConcepto();
            CADCliente consulta = new CADCliente();
            CLNProducto producto = new CLNProducto();
            try
            {
                if ((bool)HttpContext.Current.Items["RefrescarPagina"].Equals(false))
                {
                    if (validarDocumento(fuDocumentoAjuste))
                    {
                        if (validartipoDocumento(fuDocumentoAjuste))
                        {

                            if (fuDocumentoAjuste.HasFile)
                            {
                                IExcelDataReader excelReader = null;
                                DataSet DataSet = new DataSet();
                                String fileName = fuDocumentoAjuste.FileName;
                                String strFileType = System.IO.Path.GetExtension(fileName).ToLower();
                                excel = "Excel";
                                diagonal = CENConstante.g_const_diag;
                                tempPath = Server.MapPath(ConfigurationManager.AppSettings["TargetPath"] + excel + diagonal + fileName);
                                fuDocumentoAjuste.SaveAs(tempPath);
                                FileStream stream = File.Open(tempPath, FileMode.Open, FileAccess.Read);

                                if (Path.GetExtension(tempPath) == CENConstante.g_extension_vxls)
                                {
                                    excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
                                }
                                if (Path.GetExtension(tempPath).Equals(CENConstante.g_extension_vxlsx))
                                {
                                    excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                                }
                                var conf = new ExcelDataSetConfiguration()
                                {
                                    ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                                    {
                                        UseHeaderRow = true
                                    }
                                };
                                DataSet = excelReader.AsDataSet(conf);
                                DataTable dt = DataSet.Tables[CENConstante.g_const_0];

                                if (DataSet.Tables.Count > CENConstante.g_const_0)
                                {

                                    if (!DocumentoCarga(dt))
                                    {
                                        excelReader.Dispose();
                                        System.IO.File.Delete(tempPath); //Eliminar archivo de servidor
                                    }
                                    else
                                    {
                                        if (!CargarDocumentoExcel(dt))
                                        {
                                            excelReader.Dispose();
                                            System.IO.File.Delete(tempPath); //Eliminar archivo de servidor                                        
                                            msje = consulta.SeleccionarConcepto(CENConstante.g_const_1, CENConstante.g_const_10, CENConstante.g_const_10);
                                            MostrarMensaje(CENConstante.g_const_1, msje);
                                        }
                                        else
                                        {
                                            excelReader.Dispose();
                                            System.IO.File.Delete(tempPath); //Eliminar archivo de servidor
                                            msje = consulta.SeleccionarConcepto(CENConstante.g_const_1, CENConstante.g_const_10, CENConstante.g_const_11);
                                            MostrarMensaje(CENConstante.g_const_2, msje);
                                            llenarGriedViewfiltro1();
                                        }
                                    }

                                }
                            }
                        }

                    }
                }
                else
                {
                    llenarGriedViewfiltro1();
                }
            }
            catch (Exception ex)
            {
                msje = ex.Message;
                MostrarMensaje(CENConstante.g_const_1, msje);
            }

        }
        protected void grdNotes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewmd.EditIndex = e.NewEditIndex;
            CLNDetalleAlmacen clndetalle = new CLNDetalleAlmacen();
            CENDatosDetalleAlmacen cendatosalmacen = new CENDatosDetalleAlmacen();
            List<CENDetalleAlmacen> lista = new List<CENDetalleAlmacen>();

            cendatosalmacen = clndetalle.Listadatosdetallealmacen(codigoproducto.Text.Trim());
            lista = cendatosalmacen.DatosDetalleAlmacen;
            GridViewmd.DataSource = lista;
            GridViewmd.DataBind();
        }

        protected void grdNotes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

            GridViewmd.EditIndex = -CENConstante.g_const_1;
            CLNDetalleAlmacen clndetalle = new CLNDetalleAlmacen();
            CENDatosDetalleAlmacen cendatosalmacen = new CENDatosDetalleAlmacen();
            List<CENDetalleAlmacen> lista = new List<CENDetalleAlmacen>();
            txtmensaje.Visible = false;
            cendatosalmacen = clndetalle.Listadatosdetallealmacen(codigoproducto.Text.Trim());
            lista = cendatosalmacen.DatosDetalleAlmacen;
            GridViewmd.DataSource = lista;
            GridViewmd.DataBind();


        }

        protected void grdNotes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // IDictionaryEnumerator enumerator = e.NewValues.GetEnumerator();
            // enumerator.Reset();
            Label codAlmacen = GridViewmd.Rows[e.RowIndex].FindControl("lbl_codAlmacen") as Label;
            Label codProducto = GridViewmd.Rows[e.RowIndex].FindControl("lbl_codProducto") as Label;
            TextBox cantstock = GridViewmd.Rows[e.RowIndex].FindControl("Textstock") as TextBox;

            Regex rg = new Regex(@"^(\d+)((\.\d+))$");
            Regex rg2 = new Regex(@"^(\d+)$");

            if (rg.IsMatch(Convert.ToInt32(cantstock.Text).ToString()) || rg2.IsMatch(Convert.ToInt32(cantstock.Text).ToString()))
            {

                CLNRegistroStock clnregistrostock = new CLNRegistroStock();
                CENDatosRegistrostock cendatosregistrostock = new CENDatosRegistrostock();
                cendatosregistrostock = clnregistrostock.DatosRegistroStock(Convert.ToInt32(cantstock.Text), codigoproducto.Text.Trim(), Convert.ToInt32(codAlmacen.Text));
                GridViewmd.EditIndex = -CENConstante.g_const_1;


                CLNDetalleAlmacen clndetalle = new CLNDetalleAlmacen();
                CLNProducto clnproducto = new CLNProducto();
                CENDatosDetalleAlmacen cendatosalmacen = new CENDatosDetalleAlmacen();
                List<CENDetalleAlmacen> lista = new List<CENDetalleAlmacen>();

                cendatosalmacen = clndetalle.Listadatosdetallealmacen(codigoproducto.Text.Trim());
                lista = cendatosalmacen.DatosDetalleAlmacen;
                GridViewmd.DataSource = lista;
                GridViewmd.DataBind();
                txtTotalStockactualizado.Text = clnproducto.ObtenerMontoTotalAlmacen(codigoproducto.Text.Trim()).ToString();
                llenarGriedViewfiltro1();
                txtmensaje.Visible = false;
            }
            else
            {
                txtmensaje.Visible = true;
            }

        }


        protected void btnreporte_Click(object sender, EventArgs e)
        {
            List<CENHAlmacen> listaCabecera = new List<CENHAlmacen>();
            CLNAlmacen almacen = new CLNAlmacen();
            CLNProducto producto = new CLNProducto();

            try
            {
                foreach (GridViewRow row in GridView1.Rows)
                {
                    CENHAlmacen cabecera = new CENHAlmacen();
                    cabecera.CodProducto = Server.HtmlDecode(row.Cells[CENConstante.g_const_0].Text.Trim());
                    cabecera.Categoria = Server.HtmlDecode(row.Cells[CENConstante.g_const_2].Text.Trim());
                    cabecera.SubCategoria = Server.HtmlDecode(row.Cells[CENConstante.g_const_4].Text);
                    cabecera.Fabricante = Server.HtmlDecode(row.Cells[CENConstante.g_const_8].Text);
                    cabecera.DescProducto = Server.HtmlDecode(row.Cells[CENConstante.g_const_9].Text);
                    cabecera.fechavencimiento = Server.HtmlDecode(row.Cells[CENConstante.g_const_10].Text);

                    listaCabecera.Add(cabecera);
                }
                listaCabecera = almacen.ObtenerDetalleAlmacen(listaCabecera);
                DataTable dt = producto.ObtenerDataTableReporte(listaCabecera);
                if (dt.Rows.Count > CENConstante.g_const_0)
                {
                    GenerarReporte(dt);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void GenerarReporte(DataTable dt)
        {
            //GENERAR REPORTE
            if (dt.Rows.Count > CENConstante.g_const_0)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                StringWriter sw = new StringWriter(sb);

                GridView dg = new GridView();
                dg.EnableViewState = false;
                dg.DataSource = dt;
                dg.DataBind();
                Page pagina = new Page();
                HtmlForm form = new HtmlForm();
                HtmlTextWriter htw = new HtmlTextWriter(sw);
                dg.Caption = "REPORTE DE ALMACENES DE ARTICULOS";
                pagina.EnableEventValidation = false;
                pagina.DesignerInitialize();
                pagina.Controls.Add(form);
                form.Controls.Add(dg);
                pagina.RenderControl(htw);
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/vnd.ms-excel";
                Response.AddHeader("Content-Disposition", "attachment;filename=ReporteAlmacen.xls");
                Response.Charset = "UTF-8";
                Response.ContentEncoding = System.Text.Encoding.Default;
                Response.Write(sb.ToString());
                Response.Flush();
                Response.Close();
                Response.End();
            }


        }
    }
}