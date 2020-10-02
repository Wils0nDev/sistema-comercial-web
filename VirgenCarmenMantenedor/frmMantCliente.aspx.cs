using CEN;
using CLN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VirgenCarmenMantenedor
{
    public partial class MantenimientoCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) //ingresa solo la primera vez que se carga el formulario
            {

                //Inicio la variable que deseo mantener en caso refresco la pagina
                CENDepartamento objListaDep = new CENDepartamento();
                ViewState["objListaDep"] = objListaDep;
                CENDistrito objListaDist = new CENDistrito();
                ViewState["objListaDist"] = objListaDist;
                CENProvincia objListaProv = new CENProvincia();
                ViewState["objListaProv"] = objListaProv;

                CENPuntoEntrega objListaPuntosEntrega = new CENPuntoEntrega();
                ViewState["objListaPuntosEntrega"] = objListaPuntosEntrega;
                CENPuntoEntrega objLpeEliminados = new CENPuntoEntrega();
                ViewState["objLpeEliminados"] = objLpeEliminados;
                CENPuntoEntrega objLpeAgregados = new CENPuntoEntrega();
                ViewState["objLpeAgregados"] = objLpeAgregados;

                CENConcepto objListaConcepto = new CENConcepto();
                ViewState["objListaConcepto"] = objListaConcepto;

                CENCliente objListaCliente = new CENCliente();
                ViewState["objListaCliente"] = objListaCliente;

                CENGlobales objGlobal = new CENGlobales();
                ViewState["objGlobal"] = objGlobal;

                //LLenar Ubligeo
                llenarListaDepProvDist();

                //Llenar ComboBox
                llenarListaConceptos();

                //Llenar gried view Clientes
                llenarGriedViewClientes();

            }
        }


        public void llenarListaConceptos()
        {

            try
            {
                //llenar combo
                CLNConcepto concepto = new CLNConcepto();
                CENConcepto objListaConcepto = (CENConcepto)ViewState["objListaConcepto"];

                objListaConcepto.lcon = concepto.ListarConceptos(2);

                foreach (CENConcepto auxConcepto in objListaConcepto.lcon)
                {
                    cbTipoDocumento.Items.Add(auxConcepto.descripcion);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void llenarListaDepProvDist()
        {
            try
            {
                CLNDepartamento departamento = new CLNDepartamento();
                CENDepartamento objListaDep = (CENDepartamento)ViewState["objListaDep"];

                CLNProvincia provincia = new CLNProvincia();
                CENProvincia objListaProv = (CENProvincia)ViewState["objListaProv"];

                CLNDistrito distrito = new CLNDistrito();
                CENDistrito objListaDist = (CENDistrito)ViewState["objListaDist"];

                objListaDep.ldep = departamento.ListarDepartamentos(7);
                objListaProv.lprov = provincia.ListarProvincias(8);
                objListaDist.ldist = distrito.ListarDistritos(9);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void llenarGriedViewClientesVacio()
        {
            //GRIED VIEW CLIENTES
            List<CENCliente> lc = new List<CENCliente>();
            CENCliente c = new CENCliente();

            lc.Add(c);
            gvClientes.DataSource = lc;
            gvClientes.DataBind();
            gvClientes.Rows[0].Cells.Clear();
            gvClientes.Rows[0].Cells.Add(new TableCell());
            gvClientes.Rows[0].Cells[0].ColumnSpan = 13;
            gvClientes.Rows[0].Cells[0].Text = "No se encontraron Clientes....!!!";
            gvClientes.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
        }

        public void llenarGriedViewClientes()
        {
            try
            {
                //llenar Gried View
                CLNCliente cliente = new CLNCliente();
                CENCliente objListaCliente = (CENCliente)ViewState["objListaCliente"];

                objListaCliente.lcli = cliente.ListarClientes(0, "", "");


                if (objListaCliente.lcli.Count > 0)
                {
                    gvClientes.DataSource = objListaCliente.lcli;
                    gvClientes.DataBind();
                }
                else
                {
                    llenarGriedViewClientesVacio();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void llenarGriedViewClientes2()
        {
            CENCliente objListaCliente = (CENCliente)ViewState["objListaCliente"];

            if (objListaCliente.lcli.Count > 0)
            {
                gvClientes.DataSource = objListaCliente.lcli;
                gvClientes.DataBind();
            }
            else
            {
                llenarGriedViewClientesVacio();
            }

        }

        protected void gvClientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //Paginacion del gried view
            gvClientes.PageIndex = e.NewPageIndex;
            llenarGriedViewClientes2();
        }

        public void limpiarOpcionesBusquedad()
        {
            rbNumDocumento.Checked = false;
            rbNombres.Checked = false;
            cbTipoDocumento.SelectedIndex = 0;
            txtNumDoc_Ruc.Text = "";
            txtNombres.Text = "";
        }

        public void bloquearModalVer()
        {
            txtMdTipoPersona.Enabled = false;
            txtMdTipoDocumento.Enabled = false;
            txtMdPerfilCliente.Enabled = false;
            txtMdClasificacion.Enabled = false;
            txtMdFrecuencia.Enabled = false;
            txtMdListaPrecio.Enabled = false;
            txtMdRuta.Enabled = false;
            txtMdOrdenAtencion.Enabled = false;
            txtMdNumDocumento.Enabled = false;
            txtMdRuc.Enabled = false;
            txtMdRazonSocial.Enabled = false;
            txtMdNombres.Enabled = false;
            txtMdApellPaterno.Enabled = false;
            txtMdApellMaterno.Enabled = false;
            txtMdDireccion.Enabled = false;
            txtMdCorreo.Enabled = false;
            txtMdTelefono.Enabled = false;
            txtMdCelular.Enabled = false;
            txtMdDepartamento.Enabled = false;
            txtMdProvincia.Enabled = false;
            txtMdDistrito.Enabled = false;
        }

        public void limpiarModal()
        {
            lbMrmCodPersona.Text = "";
            txtMrmOrdenAtencion.Text = "";
            txtMrmNumDocumento.Text = "";
            txtMrmRUC.Text = "";
            txtMrmRazonSocial.Text = "";
            txtMrmNombres.Text = "";
            txtMrmApellPaterno.Text = "";
            txtMrmApellMaterno.Text = "";
            txtMrmDireccion.Text = "";
            txtMrmCorreo.Text = "";
            txtMrmTelefono.Text = "";
            txtMrmCelular.Text = "";
            txtLatitud.Text = "";
            txtLongitud.Text = "";
            txtLatitudXa.Text = "";
            txtLongitudYa.Text = "";
            List<CENPuntoEntrega> lpe = new List<CENPuntoEntrega>();

            gvMrmPuntosEntrega.DataSource = lpe;
            gvMrmPuntosEntrega.DataBind();
        }

        protected void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                CENCliente objListaCliente = (CENCliente)ViewState["objListaCliente"];
                CENConcepto objListaConcepto = (CENConcepto)ViewState["objListaConcepto"];
                int auxtipoDocumento = 0;

                if (rbNumDocumento.Checked == true)
                {
                    foreach (CENConcepto auxConcepto in objListaConcepto.lcon)
                    {
                        if (cbTipoDocumento.SelectedValue == auxConcepto.descripcion)
                        {
                            auxtipoDocumento = auxConcepto.correlativo;
                            break;
                        }
                    }
                }

                //llenar Griew Vied
                CLNCliente cliente = new CLNCliente();

                if (txtNumDoc_Ruc.Text != "")
                {
                    gvClientes.DataSource = cliente.ListarClientes(auxtipoDocumento, Convert.ToString(txtNumDoc_Ruc.Text.Trim()), "");
                    gvClientes.DataBind();

                }

                if (txtNombres.Text.Trim() != "")
                {
                    gvClientes.DataSource = cliente.ListarClientes(auxtipoDocumento, "", Convert.ToString(txtNombres.Text));
                    gvClientes.DataBind();

                }

                if (rbNumDocumento.Checked == false && rbNombres.Checked == false)
                {
                    txtNumDoc_Ruc.Text = "";
                    txtNombres.Text = "";
                    llenarGriedViewClientes2();
                }

                if (gvClientes.Rows.Count == 0)
                {
                    llenarGriedViewClientesVacio();
                }

                limpiarOpcionesBusquedad();

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        protected void gvClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                Int32 auxCodPersona = 0;
                int index = -1;

                if (e.CommandName.Equals("Ver"))  //Debe ser igual al nombre que se coloco en la propiedad del boton: "CommandName" 
                {
                    //Obtener fila seleccionada
                    index = Convert.ToInt32(e.CommandArgument);
                    auxCodPersona = Convert.ToInt32(((Label)gvClientes.Rows[index].FindControl("lbgvCodigoPersona")).Text);

                    verDetalleCliente(auxCodPersona);
                }

                if (e.CommandName.Equals("Eliminar"))
                {
                    //Obtener fila seleccionada
                    index = Convert.ToInt32(e.CommandArgument);
                    auxCodPersona = Convert.ToInt32(((Label)gvClientes.Rows[index].FindControl("lbgvCodigoPersona")).Text);

                    CLNCliente cliente = new CLNCliente();
                    cliente.eliminarCliente(auxCodPersona);
                    eliminarClienteLista(auxCodPersona);
                    llenarGriedViewClientes2();
                }

                if (e.CommandName.Equals("Editar"))
                {
                    //Obtener fila seleccionada
                    index = Convert.ToInt32(e.CommandArgument);
                    auxCodPersona = Convert.ToInt32(((Label)gvClientes.Rows[index].FindControl("lbgvCodigoPersona")).Text);
                    editarCliente(auxCodPersona);

                    CENGlobales objGlobal = (CENGlobales)ViewState["objGlobal"];
                    objGlobal.tipoModal = "Editar";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void verDetalleCliente(Int32 auxCodPersona)
        {
            CENCliente objListaCliente = (CENCliente)ViewState["objListaCliente"];

            foreach (CENCliente auxCliente in objListaCliente.lcli)
            {
                if (auxCliente.codPersona == auxCodPersona)
                {
                    txtMdTipoPersona.Text = auxCliente.descTipoPersona;
                    txtMdTipoDocumento.Text = auxCliente.descTipoDocumento;
                    txtMdPerfilCliente.Text = auxCliente.descPerfilCliente;
                    txtMdClasificacion.Text = auxCliente.descClasificacion;
                    txtMdFrecuencia.Text = auxCliente.descFrecuencia;
                    txtMdListaPrecio.Text = auxCliente.descTipoListaPrecio;
                    txtMdRuta.Text = auxCliente.descCodRuta;
                    if (auxCliente.ordenAtencion != 0)
                        txtMdOrdenAtencion.Text = Convert.ToString(auxCliente.ordenAtencion);
                    txtMdNumDocumento.Text = auxCliente.numeroDocumento;
                    txtMdRazonSocial.Text = auxCliente.razonSocial;
                    txtMdRuc.Text = auxCliente.ruc;
                    txtMdNombres.Text = auxCliente.nombres;
                    txtMdApellPaterno.Text = auxCliente.apellidoPaterno;
                    txtMdApellMaterno.Text = auxCliente.apellidoMaterno;
                    txtMdDireccion.Text = auxCliente.direccion;
                    txtMdCorreo.Text = auxCliente.correo;
                    txtMdTelefono.Text = auxCliente.telefono;
                    txtMdCelular.Text = auxCliente.celular;


                    /*UBIGEO Domicilio Fiscal*/
                    if (auxCliente.codUbigeo.Trim() != "")
                    {
                        Dictionary<string, string> depProvDist = new Dictionary<string, string>();
                        depProvDist = ubigeo(auxCliente.codUbigeo);

                        txtMdDepartamento.Text = depProvDist["departamento"];
                        txtMdProvincia.Text = depProvDist["provincia"];
                        txtMdDistrito.Text = depProvDist["distrito"];
                    }

                    /*Lista de Puntos de Entrega*/
                    llenarGriedViewPuntosEntrega(1, auxCliente.codPersona);

                    break;
                }

            }

            bloquearModalVer();
            mdeVerDetalle.Show(); //mostrando la ventana modal con ModalPopExtender
        }

        public void editarCliente(Int32 auxCodPersona)
        {
            CENCliente objListaCliente = (CENCliente)ViewState["objListaCliente"];

            foreach (CENCliente auxCliente in objListaCliente.lcli)
            {
                if (auxCliente.codPersona == auxCodPersona)
                {

                    llenarCombosModal(auxCliente.tipoPersona, auxCliente.tipoDocumento, auxCliente.clasificacionCliente, auxCliente.perfilCliente, auxCliente.frecuenciaCliente, auxCliente.tipoListaPrecio, auxCliente.codRuta, auxCliente.codUbigeo.Trim(), CENConstante.g_const_2);

                    txtMrmNumDocumento.Enabled = true;
                    txtMrmRUC.Enabled = true;
                    txtMrmRazonSocial.Enabled = true;
                    cbMrmTipoPersona.Enabled = false;
                    cbMrmTipoDocumento.Enabled = false;
                    if (cbMrmTipoDocumento.SelectedValue == "1")
                    {
                        txtMrmRUC.Enabled = false;
                    }
                    else if (cbMrmTipoDocumento.SelectedValue == "2")
                    {
                        txtMrmRUC.Enabled = false;
                        txtMrmRazonSocial.Enabled = false;
                    }
                    else
                    {
                        txtMrmNumDocumento.Enabled = false;
                    }

                    lbMrmCodPersona.Text = Convert.ToString(auxCliente.codPersona);
                    if (auxCliente.ordenAtencion != 0)
                    {
                        txtMrmOrdenAtencion.Text = Convert.ToString(auxCliente.ordenAtencion);
                    }
                    txtMrmNumDocumento.Text = auxCliente.numeroDocumento;
                    txtMrmRazonSocial.Text = auxCliente.razonSocial;
                    txtMrmRUC.Text = auxCliente.ruc;
                    txtMrmNombres.Text = auxCliente.nombres;
                    txtMrmApellPaterno.Text = auxCliente.apellidoPaterno;
                    txtMrmApellMaterno.Text = auxCliente.apellidoMaterno;
                    txtMrmDireccion.Text = auxCliente.direccion;
                    txtMrmCorreo.Text = auxCliente.correo;
                    txtMrmTelefono.Text = auxCliente.telefono;
                    txtMrmCelular.Text = auxCliente.celular;
                    txtLatitud.Text = auxCliente.coordenadaX;
                    txtLongitud.Text = auxCliente.coordenadaY;
                    txtLatitudXa.Text = auxCliente.coordenadaX;
                    txtLongitudYa.Text = auxCliente.coordenadaY;

                    /*Lista de Puntos de Entrega*/
                    llenarGriedViewPuntosEntrega(2, auxCliente.codPersona);

                    break;

                }
            }

            //lbTituloMdRegMod.Text = "MODIFICAR CLIENTE";
            mdeRegMod.Show();

        }

        public void llenarCombosModal(int tipoPersona, int tipoDocumento, int clasificacion, int perfilCliente, int frecuenciaCliente, int tipoListaPrecio, int codRuta, string auxUbigeo, int tipoMant)
        {

            CLNConcepto concepto = new CLNConcepto();
            List<CENConcepto> listaCombo = new List<CENConcepto>();
            CENDistrito objListaDist = (CENDistrito)ViewState["objListaDist"];
            CENProvincia objListaProv = (CENProvincia)ViewState["objListaProv"];
            CENDepartamento objListaDep = (CENDepartamento)ViewState["objListaDep"];

            cbMrmTipoPersona.DataValueField = "correlativo";
            cbMrmTipoPersona.DataTextField = "descripcion";
            listaCombo = concepto.ListarConceptos(11);
            cbMrmTipoPersona.DataSource = listaCombo;
            cbMrmTipoPersona.DataBind();

            cbMrmTipoDocumento.DataValueField = "correlativo";
            cbMrmTipoDocumento.DataTextField = "descripcion";
            listaCombo = concepto.ListarConceptos(2);
            cbMrmTipoDocumento.DataSource = listaCombo;
            cbMrmTipoDocumento.DataBind();

            cbMrmPerfilCliente.DataValueField = "correlativo";
            cbMrmPerfilCliente.DataTextField = "descripcion";
            listaCombo = concepto.ListarConceptos(12);
            cbMrmPerfilCliente.DataSource = listaCombo;
            cbMrmPerfilCliente.DataBind();

            cbMrmClasificacion.DataValueField = "correlativo";
            cbMrmClasificacion.DataTextField = "descripcion";
            listaCombo = concepto.ListarConceptos(13);
            cbMrmClasificacion.DataSource = listaCombo;
            cbMrmClasificacion.DataBind();

            cbMrmFrecuencia.DataValueField = "correlativo";
            cbMrmFrecuencia.DataTextField = "descripcion";
            listaCombo = concepto.ListarConceptos(14);
            cbMrmFrecuencia.DataSource = listaCombo;
            cbMrmFrecuencia.DataBind();

            cbMrmTipoListaPrecio.DataValueField = "correlativo";
            cbMrmTipoListaPrecio.DataTextField = "descripcion";
            listaCombo = concepto.ListarConceptos(15);
            cbMrmTipoListaPrecio.DataSource = listaCombo;
            cbMrmTipoListaPrecio.DataBind();

            cbMrmRuta.DataValueField = "correlativo";
            cbMrmRuta.DataTextField = "descripcion";
            listaCombo = concepto.ListarConceptos(16);
            cbMrmRuta.DataSource = listaCombo;
            cbMrmRuta.DataBind();

            //Llenar combo Distrito - cbMeDistrito;
            listaCombo = new List<CENConcepto>();

            List<CENConceptoUbigeo> listaComboDist = new List<CENConceptoUbigeo>();
            CENConceptoUbigeo nuevoConceptoVacioDist = new CENConceptoUbigeo();
            nuevoConceptoVacioDist.correlativo = "000000";
            nuevoConceptoVacioDist.descripcion = "SELECCIONAR";
            listaComboDist.Add(nuevoConceptoVacioDist);
            /*
            foreach (CENDistrito auxDistrito in objListaDist.ldist)
            {
                string codComboDist = "";
                codComboDist = auxDistrito.codDepartamento + auxDistrito.codProvincia + auxDistrito.codDistrito;
                CENConcepto nuevoConcepto = new CENConcepto();
                nuevoConcepto.correlativo = Convert.ToInt32(codComboDist);
                nuevoConcepto.descripcion = auxDistrito.nombre;
                listaCombo.Add(nuevoConcepto);
            }
            */

            cbMrmDistrito.DataValueField = "correlativo";
            cbMrmDistrito.DataTextField = "descripcion";
            cbMrmDistrito.DataSource = listaComboDist;
            cbMrmDistrito.DataBind();

            //Llenar combo Provincia - cbMeProvincia;
            listaCombo = new List<CENConcepto>();
            List<CENConceptoUbigeo> listaComboProv = new List<CENConceptoUbigeo>();
            CENConceptoUbigeo nuevoConceptoVacio = new CENConceptoUbigeo();
            nuevoConceptoVacio.correlativo = "0000";
            nuevoConceptoVacio.descripcion = "SELECCIONAR";
            listaComboProv.Add(nuevoConceptoVacio);
            /*
            foreach (CENProvincia auxProvincia in objListaProv.lprov)
            {
                string codComboProv = "";
                codComboProv = auxProvincia.codDepartamento + auxProvincia.codProvincia;
                CENConcepto nuevoConcepto = new CENConcepto();
                nuevoConcepto.correlativo = Convert.ToInt32(codComboProv);
                nuevoConcepto.descripcion = auxProvincia.nombre;
                listaCombo.Add(nuevoConcepto);
            }
            */

            cbMrmProvincia.DataValueField = "correlativo";
            cbMrmProvincia.DataTextField = "descripcion";
            cbMrmProvincia.DataSource = listaComboProv;
            cbMrmProvincia.DataBind();

            //Llenar combo Departamento - cbMeDepartamento
            cbMrmDepartamento.DataValueField = "codDepartamento";
            cbMrmDepartamento.DataTextField = "nombre";
            cbMrmDepartamento.DataSource = objListaDep.ldep;
            cbMrmDepartamento.DataBind();


            //SELECCIONAMOS LOS COMBOS
            cbMrmTipoPersona.SelectedValue = tipoPersona.ToString();
            cbMrmTipoDocumento.SelectedValue = tipoDocumento.ToString();

            if (perfilCliente == 0)
            {
                cbMrmPerfilCliente.SelectedIndex = 0;
            }
            else
            {
                cbMrmPerfilCliente.SelectedValue = perfilCliente.ToString();
            }

            if (clasificacion == 0)
            {
                cbMrmClasificacion.SelectedIndex = 0;
            }
            else
            {
                cbMrmClasificacion.SelectedValue = clasificacion.ToString();
            }

            cbMrmFrecuencia.SelectedValue = frecuenciaCliente.ToString();
            cbMrmTipoListaPrecio.SelectedValue = tipoListaPrecio.ToString();
            cbMrmRuta.SelectedValue = codRuta.ToString();

            if (auxUbigeo != "")
            {
                if (tipoMant == CENConstante.g_const_2)
                {
                    cbMrmDepartamento.SelectedValue = auxUbigeo.Substring(0, 2);

                    List<CENConceptoUbigeo> listaComboProvincia = new List<CENConceptoUbigeo>();
                    CLNProvincia provincia = new CLNProvincia();
                    objListaProv.lprov = provincia.ListarProvinciasRegistro(auxUbigeo.Substring(0, 2), "00");
                    CENConceptoUbigeo nuevoConceptoVacio1 = new CENConceptoUbigeo();
                    nuevoConceptoVacio1.correlativo = "0000";
                    nuevoConceptoVacio1.descripcion = "SELECCIONAR";
                    listaComboProvincia.Add(nuevoConceptoVacio1);
                    foreach (CENProvincia auxProvincia in objListaProv.lprov)
                    {
                        string codComboProv = "";
                        codComboProv = auxProvincia.codDepartamento + auxProvincia.codProvincia;
                        CENConceptoUbigeo nuevoConcepto = new CENConceptoUbigeo();
                        nuevoConcepto.correlativo = codComboProv;
                        nuevoConcepto.descripcion = auxProvincia.nombre;
                        listaComboProvincia.Add(nuevoConcepto);
                    }
                    cbMrmProvincia.DataSource = listaComboProvincia;
                    cbMrmProvincia.DataBind();

                    cbMrmProvincia.SelectedValue = auxUbigeo.Substring(0, 4);

                    //Distrito
                    string codDep = "";
                    string codPro = "";
                    string codDist = "00";
                    List<CENConceptoUbigeo> listaComboDistrito = new List<CENConceptoUbigeo>();

                    CLNDistrito distrito = new CLNDistrito();
                    //CENDistrito objListaDist = (CENDistrito)ViewState["objListaDist"];

                    codDep = auxUbigeo.Substring(CENConstante.g_const_0, CENConstante.g_const_2);
                    codPro = auxUbigeo.Substring(CENConstante.g_const_2, CENConstante.g_const_2);
                    objListaDist.ldist = distrito.ListarDistritosRegistro(codDep, codPro, codDist);

                    CENConceptoUbigeo nuevoConceptoVacioDistrito = new CENConceptoUbigeo();
                    nuevoConceptoVacioDistrito.correlativo = "000000";
                    nuevoConceptoVacioDistrito.descripcion = "SELECCIONAR";
                    listaComboDistrito.Add(nuevoConceptoVacioDistrito);
                    foreach (CENDistrito auxDistrito in objListaDist.ldist)
                    {
                        string codComboDist = "";
                        codComboDist = auxDistrito.codDepartamento + auxDistrito.codProvincia + auxDistrito.codDistrito;
                        CENConceptoUbigeo nuevoConcepto = new CENConceptoUbigeo();
                        nuevoConcepto.correlativo = codComboDist;
                        nuevoConcepto.descripcion = auxDistrito.nombre;
                        listaComboDistrito.Add(nuevoConcepto);
                    }
                    cbMrmDistrito.DataSource = listaComboDistrito;
                    cbMrmDistrito.DataBind();
                    cbMrmDistrito.SelectedValue = auxUbigeo;
                }
                else if (tipoMant == CENConstante.g_const_1)
                {
                    cbMrmDepartamento.SelectedValue = auxUbigeo.Substring(0, 2);
                    cbMrmProvincia.SelectedValue = auxUbigeo.Substring(0, 4);
                    cbMrmDistrito.SelectedValue = auxUbigeo;
                }

            }
            else
            {
                cbMrmDepartamento.SelectedIndex = 0;
                cbMrmProvincia.SelectedIndex = 0;
                cbMrmDistrito.SelectedIndex = 0;
            }

        }

        public void llenarCombosGVPuntosEntrega()
        {
            List<CENConcepto> listaCombo = new List<CENConcepto>();
            CENDistrito objListaDist = (CENDistrito)ViewState["objListaDist"];
            CENProvincia objListaProv = (CENProvincia)ViewState["objListaProv"];
            CENDepartamento objListaDep = (CENDepartamento)ViewState["objListaDep"];

            DropDownList cbDepa = gvMrmPuntosEntrega.FooterRow.FindControl("cbgvMrmDepartamento") as DropDownList;
            DropDownList cbProv = gvMrmPuntosEntrega.FooterRow.FindControl("cbgvMrmProvincia") as DropDownList;
            DropDownList cbDist = gvMrmPuntosEntrega.FooterRow.FindControl("cbgvMrmDistrito") as DropDownList;
            /*
            //Llenar combo Distrito - cbMeDistrito;
            foreach (CENDistrito auxDistrito in objListaDist.ldist)
            {
                string codComboDist = "";
                codComboDist = auxDistrito.codDepartamento + auxDistrito.codProvincia + auxDistrito.codDistrito;
                CENConcepto nuevoConcepto = new CENConcepto();
                nuevoConcepto.correlativo = Convert.ToInt32(codComboDist);
                nuevoConcepto.descripcion = auxDistrito.nombre;
                listaCombo.Add(nuevoConcepto);
            }
            cbDist.DataValueField = "correlativo";
            cbDist.DataTextField = "descripcion";
            cbDist.DataSource = listaCombo;
            cbDist.DataBind();

            //Llenar combo Provincia - cbMeProvincia;
            listaCombo = new List<CENConcepto>();
            foreach (CENProvincia auxProvincia in objListaProv.lprov)
            {
                string codComboProv = "";
                codComboProv = auxProvincia.codDepartamento + auxProvincia.codProvincia;
                CENConcepto nuevoConcepto = new CENConcepto();
                nuevoConcepto.correlativo = Convert.ToInt32(codComboProv);
                nuevoConcepto.descripcion = auxProvincia.nombre;
                listaCombo.Add(nuevoConcepto);
            }
            cbProv.DataValueField = "correlativo";
            cbProv.DataTextField = "descripcion";
            cbProv.DataSource = listaCombo;
            cbProv.DataBind();
            */

            //Llenar combo Departamento - cbMeDepartamento;
            cbDepa.DataValueField = "codDepartamento";
            cbDepa.DataTextField = "nombre";
            cbDepa.DataSource = objListaDep.ldep;
            cbDepa.DataBind();

        }

        public void eliminarClienteLista(Int32 auxCodPersona)
        {
            CENCliente objListaCliente = (CENCliente)ViewState["objListaCliente"];

            foreach (CENCliente auxCliente in objListaCliente.lcli)
            {
                if (auxCliente.codPersona == auxCodPersona)
                {
                    objListaCliente.lcli.Remove(auxCliente);
                    break;
                }
            }
        }

        public void editarClienteLista(CENCliente data)
        {
            CENCliente objListaCliente = (CENCliente)ViewState["objListaCliente"];

            foreach (CENCliente auxCliente in objListaCliente.lcli)
            {
                if (auxCliente.codPersona == data.codPersona)
                {
                    int pos = retornarPosicionCliente(auxCliente.codPersona);
                    objListaCliente.lcli.Remove(auxCliente);
                    objListaCliente.lcli.Insert(pos, data);
                    break;
                }
            }
        }

        public int retornarPosicionCliente(int auxCodPersona)
        {
            CENCliente objListaCliente = (CENCliente)ViewState["objListaCliente"];
            Int32 posicion = 0;

            for (int i = 0; i < objListaCliente.lcli.Count(); i++)
            {
                if (objListaCliente.lcli[i].codPersona == auxCodPersona)
                {
                    posicion = i;
                    break;
                }
            }

            return posicion;
        }

        public void llenarGriedViewPuntosEntregaVacio()
        {
            //GRIED VIEW PUNTOS DE ENTREGA
            List<CENPuntoEntrega> lpe = new List<CENPuntoEntrega>();
            CENPuntoEntrega p = new CENPuntoEntrega();

            lpe.Add(p);
            gvPuntosEntrega.DataSource = lpe;
            gvPuntosEntrega.DataBind();
            gvPuntosEntrega.Rows[0].Cells.Clear();
            gvPuntosEntrega.Rows[0].Cells.Add(new TableCell());
            gvPuntosEntrega.Rows[0].Cells[0].ColumnSpan = 7;
            gvPuntosEntrega.Rows[0].Cells[0].Text = "No se encontraron Puntos de Entrega....!!!";
            gvPuntosEntrega.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
        }

        public void llenarGriedViewMrnPuntosEntregaVacio()
        {
            //GRIED VIEW PUNTOS DE ENTREGA
            List<CENPuntoEntrega> lpe = new List<CENPuntoEntrega>();
            CENPuntoEntrega p = new CENPuntoEntrega();

            lpe.Add(p);
            gvMrmPuntosEntrega.DataSource = lpe;
            gvMrmPuntosEntrega.DataBind();
            gvMrmPuntosEntrega.Rows[0].Cells.Clear();
            gvMrmPuntosEntrega.Rows[0].Cells.Add(new TableCell());
            gvMrmPuntosEntrega.Rows[0].Cells[0].ColumnSpan = 7;
            gvMrmPuntosEntrega.Rows[0].Cells[0].Text = "No se encontraron Puntos de Entrega....!!!";
            gvMrmPuntosEntrega.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
        }

        public void llenarGriedViewPuntosEntrega(int modal, Int32 auxCodPersona)
        {
            CLNPuntoEntrega puntoEntrega = new CLNPuntoEntrega();
            CENPuntoEntrega objListaPuntosEntrega = (CENPuntoEntrega)ViewState["objListaPuntosEntrega"];

            //llenamos la lista de puntos de entrega con sus respectivos ubigeos
            objListaPuntosEntrega.lpent = puntoEntrega.ListarPuntosEntrega(auxCodPersona);

            for (Int32 i = objListaPuntosEntrega.lpent.Count(); i > 0; i--)
            {
                if (objListaPuntosEntrega.lpent[i - 1].codUbigeo.Trim() != "")
                {
                    Dictionary<string, string> depProvDist = new Dictionary<string, string>();
                    depProvDist = ubigeo(objListaPuntosEntrega.lpent[i - 1].codUbigeo.Trim());

                    objListaPuntosEntrega.lpent[i - 1].descDistrito = depProvDist["distrito"];
                    objListaPuntosEntrega.lpent[i - 1].descProvincia = depProvDist["provincia"];
                    objListaPuntosEntrega.lpent[i - 1].descDepartamento = depProvDist["departamento"];
                }
            }

            if (modal == 1)
            {

                if (objListaPuntosEntrega.lpent.Count > 0)
                {
                    gvPuntosEntrega.DataSource = objListaPuntosEntrega.lpent;
                    gvPuntosEntrega.DataBind();
                }
                else
                {
                    llenarGriedViewPuntosEntregaVacio();
                }
            }
            if (modal == 2)
            {
                if (objListaPuntosEntrega.lpent.Count() > 0)
                {
                    gvMrmPuntosEntrega.DataSource = objListaPuntosEntrega.lpent;
                    gvMrmPuntosEntrega.DataBind();
                }
                else
                {
                    llenarGriedViewMrnPuntosEntregaVacio();
                }

                llenarCombosGVPuntosEntrega();
            }

        }

        public Dictionary<string, string> ubigeo(string auxUbigeo)
        {
            Dictionary<string, string> depProvDist = new Dictionary<string, string>();
            CENDepartamento objListaDep = (CENDepartamento)ViewState["objListaDep"];
            CENProvincia objListaProv = (CENProvincia)ViewState["objListaProv"];
            CENDistrito objListaDist = (CENDistrito)ViewState["objListaDist"];
            //Primero separamos las variables
            string codDep = CENConstante.g_const_vacio;
            string codPro = CENConstante.g_const_vacio;
            string codDist = CENConstante.g_const_vacio;
            List<CENConceptoUbigeo> listaCombo = new List<CENConceptoUbigeo>();

            CLNDistrito distrito = new CLNDistrito();
            CLNProvincia provincia = new CLNProvincia();
            CLNDepartamento departamento = new CLNDepartamento();

            codDep = auxUbigeo.Substring(CENConstante.g_const_0, CENConstante.g_const_2);
            codPro = auxUbigeo.Substring(CENConstante.g_const_2, CENConstante.g_const_2);
            codDist = auxUbigeo.Substring(CENConstante.g_const_4, CENConstante.g_const_2);

            objListaProv.lprov = provincia.ListarProvinciasRegistro(codDep, codPro);
            objListaDist.ldist = distrito.ListarDistritosRegistro(codDep, codPro, codDist);

            foreach (CENDistrito auxDistrito in objListaDist.ldist)
            {
                string ubigeo = auxDistrito.codDepartamento + auxDistrito.codProvincia + auxDistrito.codDistrito;

                if (ubigeo == auxUbigeo)
                {
                    depProvDist.Add("distrito", auxDistrito.nombre);

                    foreach (CENDepartamento auxDepartamento in objListaDep.ldep)
                    {
                        if (auxDepartamento.codDepartamento == auxDistrito.codDepartamento)
                        {
                            depProvDist.Add("departamento", auxDepartamento.nombre);

                            foreach (CENProvincia auxProvincia in objListaProv.lprov)
                            {
                                if (auxProvincia.codDepartamento == auxDepartamento.codDepartamento && auxProvincia.codProvincia == auxDistrito.codProvincia)
                                {
                                    depProvDist.Add("provincia", auxProvincia.nombre);
                                    break;
                                }
                            }
                            break;
                        }
                    }
                    break;
                }
            }

            return depProvDist;
        }

        public Dictionary<string, string> ubigeo_2(string auxUbigeo)
        {
            Dictionary<string, string> depProvDist = new Dictionary<string, string>();

            CENDepartamento objListaDep = (CENDepartamento)ViewState["objListaDep"];
            CENProvincia objListaProv = (CENProvincia)ViewState["objListaProv"];
            CENDistrito objListaDist = (CENDistrito)ViewState["objListaDist"];

            foreach (CENDistrito auxDistrito in objListaDist.ldist)
            {
                string ubigeo = auxDistrito.codDepartamento + auxDistrito.codProvincia + auxDistrito.codDistrito;

                if (ubigeo == auxUbigeo)
                {
                    depProvDist.Add("distrito", auxDistrito.nombre);

                    foreach (CENDepartamento auxDepartamento in objListaDep.ldep)
                    {
                        if (auxDepartamento.codDepartamento == auxDistrito.codDepartamento)
                        {
                            depProvDist.Add("departamento", auxDepartamento.nombre);

                            foreach (CENProvincia auxProvincia in objListaProv.lprov)
                            {
                                if (auxProvincia.codDepartamento == auxDepartamento.codDepartamento && auxProvincia.codProvincia == auxDistrito.codProvincia)
                                {
                                    depProvDist.Add("provincia", auxProvincia.nombre);
                                    break;
                                }
                            }
                            break;
                        }
                    }
                    break;
                }
            }

            return depProvDist;
        }

        protected void gvPuntosEntrega_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            CENPuntoEntrega objListaPuntosEntrega = (CENPuntoEntrega)ViewState["objListaPuntosEntrega"];

            gvPuntosEntrega.PageIndex = e.NewPageIndex;
            gvPuntosEntrega.DataSource = objListaPuntosEntrega.lpent;
            gvPuntosEntrega.DataBind();
        }

        protected void gvMrmPuntosEntrega_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            CENPuntoEntrega objListaPuntosEntrega = (CENPuntoEntrega)ViewState["objListaPuntosEntrega"];

            gvMrmPuntosEntrega.PageIndex = e.NewPageIndex;
            gvMrmPuntosEntrega.DataSource = objListaPuntosEntrega.lpent;
            gvMrmPuntosEntrega.DataBind();

            llenarCombosGVPuntosEntrega();
        }

        public bool ValidarRegistroVacioNumDocumento_ruc()
        {

            if (txtMrmNumDocumento.Text.Trim() == "" && txtMrmRUC.Text.Trim() == "")
            {
                return false;
            }
            else
            {
                return true;
            }

        }


        protected void btnCancelarMdRegMod_Click(object sender, EventArgs e)
        {
            CENCliente objListaCliente = (CENCliente)ViewState["objListaCliente"];

            CENPuntoEntrega objListaPuntosEntrega = (CENPuntoEntrega)ViewState["objListaPuntosEntrega"];
            CENPuntoEntrega objLpeEliminados = (CENPuntoEntrega)ViewState["objLpeEliminados"];
            CENPuntoEntrega objLpeAgregados = (CENPuntoEntrega)ViewState["objLpeAgregados"];

            objListaPuntosEntrega.lpent.Clear();
            objLpeEliminados.lpent.Clear();
            objLpeAgregados.lpent.Clear();

            //Comrobar si se llena fila vacia;
            Label item = (Label)gvClientes.Rows[0].FindControl("lbgvItem") as Label;
            string num = item.Text;

            if (objListaCliente.lcli.Count == 0 || num == "")
            {
                llenarGriedViewClientesVacio();
            }

            mdeRegMod.Hide();
        }

        protected void btnAceptarMdRegMod_Click(object sender, EventArgs e)
        {
            try
            {
                CENPuntoEntrega objListaPuntosEntrega = (CENPuntoEntrega)ViewState["objListaPuntosEntrega"];
                CENPuntoEntrega objLpeEliminados = (CENPuntoEntrega)ViewState["objLpeEliminados"];
                CENPuntoEntrega objLpeAgregados = (CENPuntoEntrega)ViewState["objLpeAgregados"];

                CENCliente data = new CENCliente();
                CLNCliente cliente = new CLNCliente();


                data.tipoPersona = Convert.ToByte(cbMrmTipoPersona.SelectedValue);
                data.descTipoPersona = cbMrmTipoPersona.SelectedItem.ToString();
                data.tipoDocumento = Convert.ToByte(cbMrmTipoDocumento.SelectedValue);
                data.descTipoDocumento = cbMrmTipoDocumento.SelectedItem.ToString();
                data.perfilCliente = Convert.ToByte(cbMrmPerfilCliente.SelectedValue);
                data.descPerfilCliente = cbMrmPerfilCliente.SelectedItem.ToString();
                data.clasificacionCliente = Convert.ToByte(cbMrmClasificacion.SelectedValue);
                data.descClasificacion = cbMrmClasificacion.SelectedItem.ToString();
                data.frecuenciaCliente = Convert.ToByte(cbMrmFrecuencia.SelectedValue);
                data.descFrecuencia = cbMrmFrecuencia.SelectedItem.ToString();
                data.tipoListaPrecio = Convert.ToByte(cbMrmTipoListaPrecio.SelectedValue);
                data.descTipoListaPrecio = cbMrmTipoListaPrecio.SelectedItem.ToString();
                data.codRuta = Convert.ToInt32(cbMrmRuta.SelectedValue);
                data.descCodRuta = cbMrmRuta.SelectedItem.ToString();

                if (txtMrmOrdenAtencion.Text.Trim() != "")
                {
                    data.ordenAtencion = Convert.ToInt16(txtMrmOrdenAtencion.Text.Trim());
                }
                else
                {
                    data.ordenAtencion = 0;
                }
                data.numeroDocumento = txtMrmNumDocumento.Text.Trim();
                data.ruc = txtMrmRUC.Text.Trim();
                data.razonSocial = txtMrmRazonSocial.Text.ToUpper();
                data.nombres = txtMrmNombres.Text.ToUpper();
                data.apellidoPaterno = txtMrmApellPaterno.Text.ToUpper();
                data.apellidoMaterno = txtMrmApellMaterno.Text.ToUpper();
                data.direccion = txtMrmDireccion.Text.ToUpper();
                data.correo = txtMrmCorreo.Text.Trim();
                data.telefono = txtMrmTelefono.Text;
                data.celular = txtMrmCelular.Text;
                data.codUbigeo = cbMrmDistrito.SelectedValue;
                data.coordenadaX = txtLatitud.Text;
                data.coordenadaY = txtLongitud.Text;

                CENGlobales objGlobal = (CENGlobales)ViewState["objGlobal"];

                if (objGlobal.tipoModal == "Editar")
                {
                    data.codPersona = Convert.ToInt32(lbMrmCodPersona.Text);
                    cliente.modificarCliente(data);
                    editarClienteLista(data);
                    //REGISTRAR PUNTOS DE ENTREGA DEL CLIENTE
                    registrar_EliminarPuntosEntrega(data.codPersona);
                    llenarGriedViewClientes2();

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "mensajeConfirmacion", "mensajeConfirmacion();", true);
                }

                if (objGlobal.tipoModal == "Agregar")
                {

                    if (ValidarRegistroVacioNumDocumento_ruc())
                    {
                        //Verificar si Dni existe
                        Byte sw = 0;

                        if (txtMrmNumDocumento.Text.Trim() != "" && cbMrmTipoDocumento.SelectedValue == "1")
                        {
                            data.codPersona = Convert.ToInt32(txtMrmNumDocumento.Text.Trim());
                            sw = cliente.buscarDniCliente(data.codPersona);
                        }

                        if (sw == 0) //Dni disponible
                        {
                            CENCliente objListaCliente = (CENCliente)ViewState["objListaCliente"];

                            data.codPersona = cliente.registrarCliente(data);
                            objListaCliente.lcli.Insert(0, data);
                            //REGISTRAR PUNTOS DE ENTREGA DEL CLIENTE
                            registrar_EliminarPuntosEntrega(data.codPersona);
                            llenarGriedViewClientes2();

                            ScriptManager.RegisterStartupScript(this, this.GetType(), "mensajeConfirmacionRegistrar", "mensajeConfirmacionRegistrar();", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "mensajeExisteCliente", "mensajeExisteCliente();", true);
                        }
                    }

                }

                objListaPuntosEntrega.lpent.Clear();
                objLpeEliminados.lpent.Clear();
                objLpeAgregados.lpent.Clear();
                mdeRegMod.Hide();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvMrmPuntosEntrega_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int index = -1;

                if (e.CommandName.Equals("EliminarPuntoEntrega"))
                {
                    //Obtener fila seleccionada
                    index = Convert.ToInt32(e.CommandArgument);

                    eliminarPuntoEntregaLista(index);

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void eliminarPuntoEntregaLista(Int32 pos)
        {
            CENPuntoEntrega objListaPuntosEntrega = (CENPuntoEntrega)ViewState["objListaPuntosEntrega"];
            CENPuntoEntrega objLpeEliminados = (CENPuntoEntrega)ViewState["objLpeEliminados"];

            if (objListaPuntosEntrega.lpent.Count < 3)
            {
                objLpeEliminados.lpent.Add(objListaPuntosEntrega.lpent[pos]);
                objListaPuntosEntrega.lpent.RemoveAt(pos);
            }
            else
            {
                int pagina = gvMrmPuntosEntrega.PageIndex;
                pos = pos + (pagina * 3);

                objLpeEliminados.lpent.Add(objListaPuntosEntrega.lpent[pos]);
                objListaPuntosEntrega.lpent.RemoveAt(pos);
            }

            if (objListaPuntosEntrega.lpent.Count == 0)
            {
                llenarGriedViewMrnPuntosEntregaVacio();
            }
            else
            {
                gvMrmPuntosEntrega.DataSource = objListaPuntosEntrega.lpent;
                gvMrmPuntosEntrega.DataBind();
            }
            llenarCombosGVPuntosEntrega();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                llenarCombosModal(1, 1, 1, 1, 1, 1, 1, "", CENConstante.g_const_1);
                limpiarModal();

                // lbTituloMdRegMod.Text = "REGISTRAR CLIENTE";

                cbMrmTipoPersona.Enabled = true;
                cbMrmTipoDocumento.Enabled = true;
                txtMrmNumDocumento.Enabled = true;
                txtMrmRUC.Enabled = true;
                txtMrmRazonSocial.Enabled = true;

                //GRIED VIEW PUNTOS DE ENTREGA
                List<CENPuntoEntrega> lpe = new List<CENPuntoEntrega>();
                CENPuntoEntrega p = new CENPuntoEntrega();

                lpe.Add(p);
                gvMrmPuntosEntrega.DataSource = lpe;
                gvMrmPuntosEntrega.DataBind();
                gvMrmPuntosEntrega.Rows[0].Cells.Clear();
                gvMrmPuntosEntrega.Rows[0].Cells.Add(new TableCell());
                gvMrmPuntosEntrega.Rows[0].Cells[0].ColumnSpan = 7;
                gvMrmPuntosEntrega.Rows[0].Cells[0].Text = "No se encontraron Puntos de Entrega....!!!";
                gvMrmPuntosEntrega.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;

                //Llenar los combos del griedView Punto de Entrega
                llenarCombosGVPuntosEntrega();

                //Mostrar Modal
                mdeRegMod.Show();

                CENGlobales objGlobal = (CENGlobales)ViewState["objGlobal"];
                objGlobal.tipoModal = "Agregar";
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool buscarPuntoEntrega(string auxUbigeo, string auxDireccion)
        {
            CENPuntoEntrega objListaPuntosEntrega = (CENPuntoEntrega)ViewState["objListaPuntosEntrega"];
            CENPuntoEntrega objLpeAgregados = (CENPuntoEntrega)ViewState["objLpeAgregados"];

            int sw = 0;

            foreach (CENPuntoEntrega auxPunto in objListaPuntosEntrega.lpent)
            {
                if (auxPunto.codUbigeo == auxUbigeo && auxPunto.direccion == auxDireccion)
                {
                    sw = 1;
                    break;
                }

            }

            foreach (CENPuntoEntrega auxPunto in objLpeAgregados.lpent)
            {
                if (auxPunto.codUbigeo == auxUbigeo && auxPunto.direccion == auxDireccion)
                {
                    sw = 1;
                    break;
                }

            }

            if (sw == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void lkbMrmAgregarPe_Click(object sender, EventArgs e)
        {
            CENPuntoEntrega objListaPuntosEntrega = (CENPuntoEntrega)ViewState["objListaPuntosEntrega"];
            CENPuntoEntrega objLpeAgregados = (CENPuntoEntrega)ViewState["objLpeAgregados"];
            CENPuntoEntrega auxPunto = new CENPuntoEntrega();

            TextBox ordenEntrega = (TextBox)gvMrmPuntosEntrega.FooterRow.FindControl("txtgvMrmOrdenEntrega") as TextBox;
            DropDownList cbDepa = gvMrmPuntosEntrega.FooterRow.FindControl("cbgvMrmDepartamento") as DropDownList;
            DropDownList cbProv = gvMrmPuntosEntrega.FooterRow.FindControl("cbgvMrmProvincia") as DropDownList;
            DropDownList cbDist = gvMrmPuntosEntrega.FooterRow.FindControl("cbgvMrmDistrito") as DropDownList;
            TextBox direccion = gvMrmPuntosEntrega.FooterRow.FindControl("txtgvMrmDireccion") as TextBox;
            TextBox latitudX = gvMrmPuntosEntrega.FooterRow.FindControl("txtLatitudPE") as TextBox;
            TextBox longitudY = gvMrmPuntosEntrega.FooterRow.FindControl("txtLongitudPE") as TextBox;
            TextBox referencia = gvMrmPuntosEntrega.FooterRow.FindControl("txtgvMrmReferencia") as TextBox;

            bool sw = buscarPuntoEntrega(cbDist.SelectedValue, Convert.ToString(direccion.Text));

            if (sw == false)   //Punto de Entrega disponible
            {
                if (ordenEntrega.Text != "" && direccion.Text != "")
                {
                    if (ordenEntrega.Text != "")
                    {
                        auxPunto.ordenEntrega = Convert.ToInt16(((TextBox)gvMrmPuntosEntrega.FooterRow.FindControl("txtgvMrmOrdenEntrega")).Text);
                    }
                    auxPunto.descDepartamento = Convert.ToString(cbDepa.SelectedItem);
                    auxPunto.descProvincia = Convert.ToString(cbProv.SelectedItem);
                    auxPunto.descDistrito = Convert.ToString(cbDist.SelectedItem);
                    auxPunto.direccion = Convert.ToString(direccion.Text);
                    auxPunto.referencia = Convert.ToString(referencia.Text);
                    auxPunto.codUbigeo = cbDist.SelectedValue;
                    auxPunto.coordenadaX = Convert.ToString(latitudX.Text);
                    auxPunto.coordenadaY = Convert.ToString(longitudY.Text);

                    objLpeAgregados.lpent.Add(auxPunto);
                    objListaPuntosEntrega.lpent.Add(auxPunto);
                    gvMrmPuntosEntrega.DataSource = objListaPuntosEntrega.lpent;
                    gvMrmPuntosEntrega.DataBind();
                    llenarCombosGVPuntosEntrega();

                }
                else
                {
                    if (objListaPuntosEntrega.lpent.Count == 0)
                    {
                        llenarGriedViewMrnPuntosEntregaVacio();
                        llenarCombosGVPuntosEntrega();
                    }

                    String mensaje = "; alert('¡Por lo menos llene el orden con la direccion del punto de entrega!');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "mensajeValidacion", mensaje, true);
                }
            }
            else
            {
                String mensaje = "; alert('¡PUNTO DE ENTREGA YA EXISTE!!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensajeValidacion", mensaje, true);
            }
        }

        public bool buscarPuntoEntregaLpeEliminados(string auxUbigeo, string auxDireccion)
        {
            CENPuntoEntrega objLpeEliminados = (CENPuntoEntrega)ViewState["objLpeEliminados"];

            int sw = 0;

            foreach (CENPuntoEntrega auxPunto in objLpeEliminados.lpent)
            {
                if (auxPunto.codUbigeo == auxUbigeo && auxPunto.direccion == auxDireccion)
                {
                    sw = 1;
                    break;
                }

            }

            if (sw == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool buscarPuntoEntregaLpeAgregados(string auxUbigeo, string auxDireccion)
        {
            CENPuntoEntrega objLpeAgregados = (CENPuntoEntrega)ViewState["objLpeAgregados"];

            int sw = 0;

            foreach (CENPuntoEntrega auxPunto in objLpeAgregados.lpent)
            {
                if (auxPunto.codUbigeo == auxUbigeo && auxPunto.direccion == auxDireccion)
                {
                    sw = 1;
                    break;
                }

            }

            if (sw == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public void registrar_EliminarPuntosEntrega(int codPersona)
        {
            CENPuntoEntrega objLpeAgregados = (CENPuntoEntrega)ViewState["objLpeAgregados"];
            CENPuntoEntrega objLpeEliminados = (CENPuntoEntrega)ViewState["objLpeEliminados"];
            CLNPuntoEntrega puntoEntrega = new CLNPuntoEntrega();


            foreach (CENPuntoEntrega auxPunto in objLpeAgregados.lpent)
            {
                auxPunto.codPersona = codPersona;
                bool sw = buscarPuntoEntregaLpeEliminados(auxPunto.codUbigeo, auxPunto.direccion);

                if (sw == false)   //Punto de Entrega No encontrado
                {
                    puntoEntrega.registrarEliminarPuntoEntrega(1, auxPunto);
                }

            }

            foreach (CENPuntoEntrega auxPunto in objLpeEliminados.lpent)
            {
                auxPunto.codPersona = codPersona;
                bool sw = buscarPuntoEntregaLpeAgregados(auxPunto.codUbigeo, auxPunto.direccion);

                if (sw == false)   //Punto de Entrega No encontrado
                {
                    puntoEntrega.registrarEliminarPuntoEntrega(2, auxPunto);
                }

            }

        }


        [WebMethod]
        public static CEN_RespuestaWSReniec BuscarClienteReniec(string numDocumento)
        {
            CEN_RespuestaWSReniec respuesta = new CEN_RespuestaWSReniec();
            CEN_RequestReniec request = new CEN_RequestReniec();
            CLNConexionServicio cLNConexion = new CLNConexionServicio();
            try
            {
                request.numDocumento = numDocumento;
                respuesta = cLNConexion.ConsultaClienteReniec(request);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return respuesta;
        }

        [WebMethod]
        public static CEN_RespuestaWSSunat BuscarClienteSunat(string numDocumento)
        {
            CEN_RespuestaWSSunat respuesta = new CEN_RespuestaWSSunat();
            CEN_RequestSunat request = new CEN_RequestSunat();
            CLNConexionServicio cLNConexion = new CLNConexionServicio();
            try
            {
                request.numDocumento = numDocumento;
                respuesta = cLNConexion.ConsultaClienteSunat(request);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return respuesta;
        }

        protected void OnSelectedDepartamento(object sender, EventArgs e)
        {
            string message = cbMrmDepartamento.SelectedItem.Text + " - " + cbMrmDepartamento.SelectedItem.Value;

            List<CENConceptoUbigeo> listaCombo = new List<CENConceptoUbigeo>();
            CLNProvincia provincia = new CLNProvincia();
            CENProvincia objListaProv = (CENProvincia)ViewState["objListaProv"];


            objListaProv.lprov = provincia.ListarProvinciasRegistro(cbMrmDepartamento.SelectedItem.Value, "00");
            CENConceptoUbigeo nuevoConceptoVacio = new CENConceptoUbigeo();
            nuevoConceptoVacio.correlativo = "0000";
            nuevoConceptoVacio.descripcion = "SELECCIONAR";
            listaCombo.Add(nuevoConceptoVacio);
            foreach (CENProvincia auxProvincia in objListaProv.lprov)
            {
                string codComboProv = "";
                codComboProv = auxProvincia.codDepartamento + auxProvincia.codProvincia;
                CENConceptoUbigeo nuevoConcepto = new CENConceptoUbigeo();
                nuevoConcepto.correlativo = codComboProv;
                nuevoConcepto.descripcion = auxProvincia.nombre;
                listaCombo.Add(nuevoConcepto);
            }

            cbMrmProvincia.DataValueField = "correlativo";
            cbMrmProvincia.DataTextField = "descripcion";
            cbMrmProvincia.DataSource = listaCombo;
            cbMrmProvincia.DataBind();
            //objListaDist.ldist = distrito.ListarDistritos(9);


            List<CENConceptoUbigeo> listaComboDist = new List<CENConceptoUbigeo>();

            CLNDistrito distrito = new CLNDistrito();
            CENDistrito objListaDist = (CENDistrito)ViewState["objListaDist"];


            CENConceptoUbigeo nuevoConceptoDistVacio = new CENConceptoUbigeo();
            nuevoConceptoDistVacio.correlativo = "000000";
            nuevoConceptoDistVacio.descripcion = "SELECCIONAR";
            listaComboDist.Add(nuevoConceptoDistVacio);
            cbMrmDistrito.DataValueField = "correlativo";
            cbMrmDistrito.DataTextField = "descripcion";
            cbMrmDistrito.DataSource = listaComboDist;
            cbMrmDistrito.DataBind();


        }

        protected void OnSelectedProvincia(object sender, EventArgs e)
        {
            string message = cbMrmProvincia.SelectedItem.Text + " - " + cbMrmProvincia.SelectedItem.Value;

            string codDep = CENConstante.g_const_vacio;
            string codPro = CENConstante.g_const_vacio;
            string codDist = "00";
            List<CENConceptoUbigeo> listaCombo = new List<CENConceptoUbigeo>();

            CLNDistrito distrito = new CLNDistrito();
            CENDistrito objListaDist = (CENDistrito)ViewState["objListaDist"];

            codDep = cbMrmProvincia.SelectedItem.Value.Substring(CENConstante.g_const_0, CENConstante.g_const_2);
            codPro = cbMrmProvincia.SelectedItem.Value.Substring(CENConstante.g_const_2, CENConstante.g_const_2);
            objListaDist.ldist = distrito.ListarDistritosRegistro(codDep, codPro, "00");

            CENConceptoUbigeo nuevoConceptoVacio = new CENConceptoUbigeo();
            nuevoConceptoVacio.correlativo = "000000";
            nuevoConceptoVacio.descripcion = "SELECCIONAR";
            listaCombo.Add(nuevoConceptoVacio);
            foreach (CENDistrito auxDistrito in objListaDist.ldist)
            {
                string codComboDist = "";
                codComboDist = auxDistrito.codDepartamento + auxDistrito.codProvincia + auxDistrito.codDistrito;
                CENConceptoUbigeo nuevoConcepto = new CENConceptoUbigeo();
                nuevoConcepto.correlativo = codComboDist;
                nuevoConcepto.descripcion = auxDistrito.nombre;
                listaCombo.Add(nuevoConcepto);
            }

            cbMrmDistrito.DataValueField = "correlativo";
            cbMrmDistrito.DataTextField = "descripcion";
            cbMrmDistrito.DataSource = listaCombo;
            cbMrmDistrito.DataBind();
            //objListaDist.ldist = distrito.ListarDistritos(9);
        }








        //Ubigeo de punto de entrega
        protected void OnSelectedDepartamentoPE(object sender, EventArgs e)
        {

            DropDownList cbDep = gvMrmPuntosEntrega.FooterRow.FindControl("cbgvMrmDepartamento") as DropDownList;
            DropDownList cbProv = gvMrmPuntosEntrega.FooterRow.FindControl("cbgvMrmProvincia") as DropDownList;
            DropDownList cdDist = gvMrmPuntosEntrega.FooterRow.FindControl("cbgvMrmDistrito") as DropDownList;
            string message = cbDep.SelectedItem.Text + " - " + cbDep.SelectedItem.Value;

            List<CENConceptoUbigeo> listaCombo = new List<CENConceptoUbigeo>();
            CLNProvincia provincia = new CLNProvincia();
            CENProvincia objListaProv = (CENProvincia)ViewState["objListaProv"];


            objListaProv.lprov = provincia.ListarProvinciasRegistro(cbDep.SelectedItem.Value, "00");
            CENConceptoUbigeo nuevoConceptoVacio = new CENConceptoUbigeo();
            nuevoConceptoVacio.correlativo = "0000";
            nuevoConceptoVacio.descripcion = "SELECCIONAR";
            listaCombo.Add(nuevoConceptoVacio);
            foreach (CENProvincia auxProvincia in objListaProv.lprov)
            {
                string codComboProv = "";
                codComboProv = auxProvincia.codDepartamento + auxProvincia.codProvincia;
                CENConceptoUbigeo nuevoConcepto = new CENConceptoUbigeo();
                nuevoConcepto.correlativo = codComboProv;
                nuevoConcepto.descripcion = auxProvincia.nombre;
                listaCombo.Add(nuevoConcepto);
            }

            cbProv.DataValueField = "correlativo";
            cbProv.DataTextField = "descripcion";
            cbProv.DataSource = listaCombo;
            cbProv.DataBind();
            //objListaDist.ldist = distrito.ListarDistritos(9);


            List<CENConceptoUbigeo> listaComboDist = new List<CENConceptoUbigeo>();

            CLNDistrito distrito = new CLNDistrito();
            CENDistrito objListaDist = (CENDistrito)ViewState["objListaDist"];


            CENConceptoUbigeo nuevoConceptoDistVacio = new CENConceptoUbigeo();
            nuevoConceptoDistVacio.correlativo = "000000";
            nuevoConceptoDistVacio.descripcion = "SELECCIONAR";
            listaComboDist.Add(nuevoConceptoDistVacio);
            cdDist.DataValueField = "correlativo";
            cdDist.DataTextField = "descripcion";
            cdDist.DataSource = listaComboDist;
            cdDist.DataBind();



        }


        protected void OnSelectedProvinciaPE(object sender, EventArgs e)
        {

            DropDownList cbProv = gvMrmPuntosEntrega.FooterRow.FindControl("cbgvMrmProvincia") as DropDownList;
            DropDownList cdDist = gvMrmPuntosEntrega.FooterRow.FindControl("cbgvMrmDistrito") as DropDownList;

            string message = cbProv.SelectedItem.Text + " - " + cbProv.SelectedItem.Value;

            string codDep = CENConstante.g_const_vacio;
            string codPro = CENConstante.g_const_vacio;
            string codDist = "00";
            List<CENConceptoUbigeo> listaCombo = new List<CENConceptoUbigeo>();

            CLNDistrito distrito = new CLNDistrito();
            CENDistrito objListaDist = (CENDistrito)ViewState["objListaDist"];

            codDep = cbProv.SelectedItem.Value.Substring(CENConstante.g_const_0, CENConstante.g_const_2);
            codPro = cbProv.SelectedItem.Value.Substring(CENConstante.g_const_2, CENConstante.g_const_2);
            objListaDist.ldist = distrito.ListarDistritosRegistro(codDep, codPro, codDist);

            CENConceptoUbigeo nuevoConceptoVacio = new CENConceptoUbigeo();
            nuevoConceptoVacio.correlativo = "000000";
            nuevoConceptoVacio.descripcion = "SELECCIONAR";
            listaCombo.Add(nuevoConceptoVacio);
            foreach (CENDistrito auxDistrito in objListaDist.ldist)
            {
                string codComboDist = "";
                codComboDist = auxDistrito.codDepartamento + auxDistrito.codProvincia + auxDistrito.codDistrito;
                CENConceptoUbigeo nuevoConcepto = new CENConceptoUbigeo();
                nuevoConcepto.correlativo = codComboDist;
                nuevoConcepto.descripcion = auxDistrito.nombre;
                listaCombo.Add(nuevoConcepto);
            }

            cdDist.DataValueField = "correlativo";
            cdDist.DataTextField = "descripcion";
            cdDist.DataSource = listaCombo;
            cdDist.DataBind();

        }

        [WebMethod]
        public static bool ValidarExisteCliente(string numDocumento, int tipoDoc, int tipoPer)
        {
            CLNCliente cliente = new CLNCliente();
            bool estadoClient = true;
            int estadoruc = CENConstante.g_const_0;
            try
            {
                Byte sw = 0;
                if (tipoDoc == CENConstante.g_const_1 && tipoPer == CENConstante.g_const_1 && numDocumento.Length == 8)
                {
                    sw = cliente.buscarDniCliente(Int32.Parse(numDocumento));
                    if (sw == 0)
                        estadoClient = true;
                    else
                        estadoClient = false;
                }

                if (tipoDoc == CENConstante.g_const_3 || tipoPer == CENConstante.g_const_2 || numDocumento.Length == 11)
                {
                    estadoruc = cliente.buscarRUCCliente(numDocumento);
                    if (estadoruc == 0)
                        estadoClient = true;
                    else
                        estadoClient = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return estadoClient;
        }


    }
}