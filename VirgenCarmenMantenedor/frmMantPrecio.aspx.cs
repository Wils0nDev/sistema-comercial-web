using System;
using System.Collections.Generic;
using CLN;
using CEN;
using System.Web.UI.WebControls;
using System.Configuration;
using ExcelDataReader;
using System.IO;
using System.Web.UI;
using System.Collections;
using System.Web.Services;
using Newtonsoft.Json;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Text;
using System.Web;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;

namespace VirgenCarmenMantenedor
{
    public partial class frmMantPrecio : System.Web.UI.Page
    {

        int POSICION = 0;       //Posicion
        int INDICE_PRIMERA_FILA_NULA; //Indice Primera Fila Nula
        string CODIGO = "";     //Codigo
        GridView gvAux;         //GridView Auxiliar
        Boolean EXISTE_FILA_NULA; //Existe fila nula
        int CANTIDAD_COLUMNAS_SINVACIOS; //Cantidad Columnas sin VACIOS NI NULOS
        int SOSPECHA_COLUMNAS_VACIAS; //Sospecha de Columnas VACÍAS

        protected void Page_Load(object sender, EventArgs e)
        {
            HiddenField campoOcultoCargaMasiva = (HiddenField)(Page.Form.FindControl("campoOcultoCargaMasiva"));
            String valorGeneradoFileUpload = campoOcultoCargaMasiva.Value;
            String valorSesionCargaArchivo = "";

            System.Web.HttpContext _httpContext = System.Web.HttpContext.Current;
            //VALIDAR SI SE PRESIONO EL BOTON REFRESCAR DEL NAVEGADOR - FIN

            if (!IsPostBack)
            {
                gvAux = new GridView();
                obtenerDatos();
                llenarCombos();
            }

            //VALIDAR SI SE PRESIONO EL BOTON REFRESCAR DEL NAVEGADOR - INICIO
            valorSesionCargaArchivo = (String)Session["valorSesionCargaArchivo"];

            if (!String.IsNullOrEmpty(valorSesionCargaArchivo))
            {
                if (valorSesionCargaArchivo.Equals(valorGeneradoFileUpload))
                { //Se hizo clic en el boton Refrescar del Navegador
                    _httpContext.Items.Add("RefrescarPagina", true);
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

            //VALIDAR SI SE PRESIONO EL BOTON REFRESCAR DEL NAVEGADOR - FI
        }
        public void obtenerDatos()
        {
            //DESCRIPCION: Obtener Datos Completos para mostrar en GridView Principal
            CLNPrecio clnPrecio = new CLNPrecio();
            ArrayList lParametros = new ArrayList();
            try
            {
                if (clnPrecio.obtenerPrecios().Count.Equals(0))
                {
                    lblMensaje.Visible = true;
                }
                else
                {
                    lblMensaje.Visible = false;
                }

                grdViewPrincipal.DataSource = clnPrecio.obtenerPrecios();
                grdViewPrincipal.DataBind();

                //GUARDAR PARAMETROS PARA POSTERIOR REPORTE, ACTUALIZACION DE MODAL y/o PAGINACION
                lParametros.Add(0); //Proveedor
                lParametros.Add(0); //Fabricante
                lParametros.Add(0); //Categoria
                lParametros.Add(0); //Subcategoria
                lParametros.Add(""); //Producto

                Session["lParametros"] = lParametros;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            //DESCRIPCION: Subir y procesar archivo Excel
            string tempPath;
            string excel;
            string diagonal;
            string mensaje;
            int FLAG = 0;
            CLNPrecio CLNPrecio = new CLNPrecio();

            try
            {
                if ((bool)HttpContext.Current.Items["RefrescarPagina"].Equals(false))
                { //VALIDAR BOTÓN REFRESCAR PÁGINA - INICIO
                    if (fuSubirArchivoServidor.HasFile)
                    {
                        System.Data.DataSet dsExcelData = new System.Data.DataSet();
                        String fileName = fuSubirArchivoServidor.FileName;
                        String strFileType = System.IO.Path.GetExtension(fileName).ToLower();
                        fileName = "cargaPrecios.xlsx";
                        excel = "Excel";
                        diagonal = "\\";
                        tempPath = Server.MapPath(ConfigurationManager.AppSettings["TargetPath"] + excel + diagonal + fileName);
                        ViewState["tempPath"] = tempPath;
                        fuSubirArchivoServidor.SaveAs(tempPath);

                        if (strFileType.Trim() == ".xls" || strFileType.Trim() == ".xlsx")
                        {
                            FLAG = GetExcelData(tempPath); //EVALUA DATA DEL EXCEL (MUY IMPORTANTE)     
                            fuSubirArchivoServidor.Dispose();

                            //Obtengo el Mensaje de la Tabla Concepto (tblConcepto) de acuerdo al FLAG obtenido de la funcion: GetExcelData
                            mensaje = obtenerMensajeParametrizado(FLAG);

                            ScriptManager.RegisterStartupScript(this, this.GetType(),
                            "MSJInformativo", "mensajeInformativo('" + FLAG + "','" + POSICION + "','" + CODIGO + "','" + mensaje + "');", true);


                            System.IO.File.Delete(tempPath); //Eliminar archivo de servidor 
                        }
                        else
                        {
                            mensaje = CLNPrecio.obtenerDescripcionConcepto(CENConstante.g_const_1, CENConstante.g_const_10, CENConstante.g_const_2);
                            FLAG = 1;
                            ScriptManager.RegisterStartupScript(this, this.GetType(),
                            "MSJInformativo", "mensajeInformativo('" + FLAG + "','','','" + mensaje + "');", true);
                            fuSubirArchivoServidor.Dispose();

                        }
                    }
                    else
                    {
                        mensaje = CLNPrecio.obtenerDescripcionConcepto(CENConstante.g_const_1, CENConstante.g_const_10, CENConstante.g_const_1);
                        FLAG = 7;
                        ScriptManager.RegisterStartupScript(this, this.GetType(),
                         "MSJInformativo", "mensajeInformativo('" + FLAG + "','','','" + mensaje + "');", true);
                        fuSubirArchivoServidor.Dispose();
                    }
                } //VALIDAR BOTÓN REFRESCAR PÁGINA - FIN

                obtenerDatos();
                limpiarFiltrosBusqueda(); //LIMPIAR FILTROS DE BÚSQUEDA


            }
            catch (Exception ex)
            {

                //MENSAJES GENERICO NO CONTROLADO (Procesar - btnProcesar_Click)                
                FLAG = -999;

                ScriptManager.RegisterStartupScript(this, this.GetType(),
                   "MSJInformativo", "mensajeInformativo('" + FLAG + "','','','');", true);

                obtenerDatos();
                limpiarFiltrosBusqueda(); //LIMPIAR FILTROS DE BÚSQUEDA

            }


        }

        public void limpiarFiltrosBusqueda()
        {
            //DESCRIPCION: Limpiar Filtros de Búsqueda
            try
            {
                ddlCategoria.SelectedIndex = 0;
                ddlSubcategoria.SelectedIndex = 0;
                ddlFabricante.SelectedIndex = 0;
                ddlProveedor.SelectedIndex = 0;
                txtProducto.Text = "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string obtenerMensajeParametrizado(int FLAG)
        {
            //DESCRIPCION: Obtener mensaje parametrizado
            String mensaje = "";
            CLNPrecio CLNPrecio = new CLNPrecio();

            try
            {
                switch (FLAG)
                {
                    case 1:
                        mensaje = CLNPrecio.obtenerDescripcionConcepto(CENConstante.g_const_1, CENConstante.g_const_10, CENConstante.g_const_6);
                        break;

                    case 2:
                        mensaje = CLNPrecio.obtenerDescripcionConcepto(CENConstante.g_const_1, CENConstante.g_const_10, CENConstante.g_const_4);
                        break;

                    case 3:
                        mensaje = CLNPrecio.obtenerDescripcionConcepto(CENConstante.g_const_1, CENConstante.g_const_10, CENConstante.g_const_11);
                        break;

                    case 4:
                        mensaje = CLNPrecio.obtenerDescripcionConcepto(CENConstante.g_const_1, CENConstante.g_const_10, CENConstante.g_const_13);
                        mensaje = mensaje + CLNPrecio.obtenerDescripcionConcepto(CENConstante.g_const_1, CENConstante.g_const_10, CENConstante.g_const_7);
                        break;

                    case 5:
                        mensaje = CLNPrecio.obtenerDescripcionConcepto(CENConstante.g_const_1, CENConstante.g_const_10, CENConstante.g_const_5);
                        break;

                    case 6:
                        mensaje = CLNPrecio.obtenerDescripcionConcepto(CENConstante.g_const_1, CENConstante.g_const_10, CENConstante.g_const_8);
                        break;

                    case 8:
                        mensaje = CLNPrecio.obtenerDescripcionConcepto(CENConstante.g_const_1, CENConstante.g_const_10, CENConstante.g_const_12);
                        mensaje = mensaje + CLNPrecio.obtenerDescripcionConcepto(CENConstante.g_const_1, CENConstante.g_const_10, CENConstante.g_const_7);
                        break;

                    case 9:
                        mensaje = CLNPrecio.obtenerDescripcionConcepto(CENConstante.g_const_1, CENConstante.g_const_10, CENConstante.g_const_14);
                        break;

                    case 10:
                        mensaje = CLNPrecio.obtenerDescripcionConcepto(CENConstante.g_const_1, CENConstante.g_const_10, CENConstante.g_const_15);
                        mensaje = mensaje + CLNPrecio.obtenerDescripcionConcepto(CENConstante.g_const_1, CENConstante.g_const_10, CENConstante.g_const_7);
                        break;

                    case 11:
                        mensaje = CLNPrecio.obtenerDescripcionConcepto(CENConstante.g_const_1, CENConstante.g_const_10, CENConstante.g_const_4);
                        mensaje = mensaje + " " + CLNPrecio.obtenerDescripcionConcepto(CENConstante.g_const_1, CENConstante.g_const_10, CENConstante.g_const_7);
                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return mensaje;
        }

        public int GetExcelData(string fileFullPath)
        {
            //DESCRIPCION: Obtener data de excel en listas

            int cont = 0; //obtener los precios de archivo excel
            int cantidadColumnasCargaMasiva = 0;
            List<List<String>> lcadena = new List<List<String>>();
            List<String> laux;
            List<String> nombreColumnas;
            IExcelDataReader excelReader = null;
            List<CENCPrecio> lcabecera = new List<CENCPrecio>(); //Lista de Cabecera que contiene su detalle
            List<CENConcepto> lConceptoPrecio = new List<CENConcepto>(); //Listar concepto precio

            CLNPrecio clnPrecio = new CLNPrecio();
            Boolean rpta = false;
            int FLAG = 0; //NO SE ENCONTRO ERRORES
            int totalColumnas = 0; //TOTAL DE COLUMNAS
            Boolean filaNula = false; //Fila nula
            Boolean ultimaFila = false; //Ultima fila
            Boolean validarArchivoVacio = false;

            try
            {

                FileStream stream = File.Open(fileFullPath, FileMode.Open, FileAccess.Read);

                if (Path.GetExtension(fileFullPath) == ".xls")
                {
                    excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
                }
                if (Path.GetExtension(fileFullPath) == ".xlsx")
                {
                    excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                }

                //CANTIDAD DE COLUMNAS QUE DEBERAN TENER DATA
                cantidadColumnasCargaMasiva = cantidadColumnasCorrectasCargaMasiva();


                //*********************************************************************
                //PASAR A EXCEL DATA READER A DATA TABLE - INICIO (SE VALIDARÁ ÚLTIMA FILA Y FILA CON VALORES NULOS O VACÍOS)
                DataSet result = excelReader.AsDataSet();
                DataTable table = result.Tables[0];

                //VALIDAR ARCHIVO VACIO - INICIO

                if (table.Rows.Count == 0) //EXCEL SE ENCUENTRA VACÍO
                {
                    //MUESTRO MENSAJE DE ARCHIVO VACÍO
                    FLAG = 1;
                    excelReader.Dispose(); //Liberar recurso para luego poder eliminarlo
                    return FLAG;
                }
                else
                { //SE REALIZA BÚSQUEDA EN TODAS LAS FILAS EN CASO EXISTAN FILAS CON ESPACIO QUE ESTEN SIENDO CONSIDERADAS COMO FILAS VÁLIDAS
                    for (int a = 0; a < table.Rows.Count; a++)
                    {
                        DataRow fila = table.Rows[a]; //Obtengo fila a fila

                        for (int b = 0; b < table.Columns.Count; b++) //NOTA: El comando: Columns.Count, obtiene la mayor cantidad de columnas de todo el excel
                        {
                            if (!String.IsNullOrEmpty(fila[b].ToString().Trim()))
                            {
                                validarArchivoVacio = true;
                                break;
                            }
                        }

                        if (validarArchivoVacio)
                        {
                            break;
                        }

                    }

                    if (validarArchivoVacio.Equals(false))
                    {
                        //MUESTRO MENSAJE DE ARCHIVO VACÍO
                        FLAG = 1;
                        excelReader.Dispose(); //Liberar recurso para luego poder eliminarlo
                        return FLAG;
                    }

                }

                //VALIDAR ARCHIVO VACIO - FIN

                for (int j = 0; j < table.Rows.Count; j++)
                { //VALIDACIÓN EN BÚSQUEDA DE LA ÚLTIMA FILA (CASO: ESPACIOS EN BLANCO EN FORMATO EXCEL)

                    DataRow row = table.Rows[j]; //Obtengo fila a fila
                    String sinespacios = row[j].ToString().Trim();

                    //VALIDAR NUMERO DE COLUMNAS POR CADA FILA (ESPECIFICO) - INICIO                    
                    if (!validarNumeroColumnasEspecifico(row, cantidadColumnasCargaMasiva))
                    { //NUMERO DE COLUMNAS INCORRECTO
                        if (SOSPECHA_COLUMNAS_VACIAS.Equals(row.Table.Columns.Count))
                        {
                            if (validarUltimaFila(table, cantidadColumnasCargaMasiva, j)) //IMPORTANTE: VALIDAR ÚLTIMA FILA CON ESPACIOS EN BLANCO
                            {//SE ENCONTRÓ LA ÚLTIMA FILA QUE TENIA ESPACIOS EN BLANCO
                                ultimaFila = true;
                                break;
                            }
                            else
                            {
                                FLAG = 11;
                                POSICION = j + 1;
                                excelReader.Dispose(); //Liberar recurso para luego poder eliminarlo
                                return FLAG;
                            }

                        }
                        else
                        {
                            FLAG = 11;
                            POSICION = j + 1;
                            excelReader.Dispose(); //Liberar recurso para luego poder eliminarlo
                            return FLAG;
                        }

                    }
                    //VALIDAR NUMERO DE COLUMNAS POR CADA FILA (ESPECIFICO) - FIN

                    //SI SE ENCONTRÓ UNA FILA CON TODAS LAS CELDAS NULAS, SE ANALIZARÁ DESDE ESTA FILA HASTA EL TOTAL DE FILAS
                    //CON LA FINALIDAD DE SABER SI ES LA ULTIMA FILA.                      

                    if (validarUltimaFila(table, cantidadColumnasCargaMasiva, j)) //IMPORTANTE: VALIDAR ÚLTIMA FILA
                    {//SE ENCONTRÓ LA ÚLTIMA FILA
                        ultimaFila = true;
                        break;
                    }


                    if (String.IsNullOrEmpty(sinespacios)) //NULO o VACIO "{}"
                    {
                        //Se encontró un valor NULO o VACIO lo cual no es correcto en base al formato especificado
                        FLAG = 10;
                        POSICION = j + 1;
                        excelReader.Dispose(); //Liberar recurso para luego poder eliminarlo

                        return FLAG;

                    }

                    if (ultimaFila.Equals(true))
                    {//SE ENCONTRÓ ÚLTIMA FILA
                        ultimaFila = false;
                        break;
                    }
                }

                //PASAR A EXCEL DATA READER A DATA TABLE - FIN (SE VALIDARÁ ÚLTIMA FILA Y FILA CON VALORES NULOS O VACÍOS)
                //*********************************************************************

                int columnas = excelReader.FieldCount; //OBTENER NÚMERO DE COLUMNA DEL EXCEL          

                //LIMPIAR COLUMNAS QUE TENGAN VALORES NULOS O VACIOS - INICIO
                if (obtenerCantidadColumnasSinContarNulosNiVacios(table, cantidadColumnasCargaMasiva)) //CANTIDAD DE COLUMNAS CORRECTAS (SE ANALIZA TODAS LAS FILAS)
                {
                    columnas = CANTIDAD_COLUMNAS_SINVACIOS;
                }
                else
                {
                    FLAG = 11;
                    return FLAG;
                }

                //LIMPIAR COLUMNAS QUE TENGAN VALORES NULOS O VACIOS - FIN

                //OBTENER NOMBRE DE COLUMNAS DE BASE DE DATOS
                lConceptoPrecio = clnPrecio.ListarConceptoPrecio(13);

                do
                {
                    while (excelReader.Read())
                    { //INICIO DE WHILE DE LECTURA DEL "EXCEL DATA READER"
                        cont++;

                        if (EXISTE_FILA_NULA.Equals(true)) //VALIDACION CUANDO SE ENCONTRÓ LA PRIMERA FILA CON ESPACIO - INICIO (IF)
                        {
                            if (cont - 1 < INDICE_PRIMERA_FILA_NULA)
                            {

                                //Crear objeto Cabecera
                                int dep = excelReader.Depth;
                                laux = new List<String>();
                                nombreColumnas = new List<String>();

                                laux.Add(excelReader.GetString(0));

                                if (cont >= 2) //LISTA DE PRECIOS (VARIABLE)
                                {

                                    //Validar si la fila tiene todas las columnas nulas (ahi deberá finalizar) - INICIO
                                    if (String.IsNullOrEmpty(excelReader.GetString(0)))
                                    {
                                        for (int h = 1; h < totalColumnas; h++)
                                        {

                                            if (String.IsNullOrEmpty(excelReader.GetString(h)))
                                            {
                                                filaNula = true;
                                            }
                                            else
                                            {
                                                filaNula = false;
                                            }
                                        }

                                        if (filaNula.Equals(true))
                                        {
                                            break; //finalizo el recorrido de filas del excel (finalizo el WHILE excelReader.Read())
                                        }

                                    }
                                    //Validar si la fila tiene todas las columnas nulas (ahi deberá finalizar) - FIN


                                    //Obtener los datos de las columnas de Precios (N° Columnas Variables)
                                    for (int j = 2; j < columnas; j++)
                                    {
                                        Type tipoDato = excelReader.GetFieldType(j);

                                        if (tipoDato.Name.Equals("String"))
                                        {
                                            excelReader.Dispose(); //Liberar recurso para luego poder eliminarlo
                                            POSICION = cont;
                                            FLAG = 8;

                                            return FLAG;
                                        }

                                        if (tipoDato.Name.Equals("Double"))
                                        {
                                            if (excelReader.GetDouble(j) < 0) //Validando si precio es menor o igual a cero (0)
                                            {
                                                excelReader.Dispose(); //Liberar recurso para luego poder eliminarlo
                                                FLAG = 4;
                                                POSICION = cont;
                                                return FLAG;
                                            }
                                            laux.Add(excelReader.GetDouble(j).ToString());
                                        }


                                    }
                                }
                                else //VALIDACION DE COLUMNAS
                                {
                                    //Obtener los datos de los nombres de las columnas (Precios)
                                    int x = 0; //contador de columnas no incluye las nulas para validar cantidad de columnas
                                    for (int j = 2; j < columnas; j++)
                                    {
                                        if (!excelReader.IsDBNull(j))
                                        {
                                            laux.Add(excelReader.GetString(j).ToString());
                                            x = x + 1;
                                        }

                                    }

                                    x = x + 2;
                                    // VALIDAR CANTIDAD DE COLUMNAS
                                    if (validarArchivoExcel(x).Equals(false)) //NO CONTIENE LA CANTIDAD DE COLUMNAS CORRECTAS
                                    {
                                        excelReader.Dispose(); //Liberar recurso para luego poder eliminarlo
                                        FLAG = 2;
                                        return FLAG;

                                    }

                                    //OTENER NOMBRE DE TODAS LAS COLUMNAS DEL EXCEL EN LA LISTA (Nombre Columnas)
                                    totalColumnas = columnas;

                                    for (int k = 0; k < columnas; k++)
                                    {
                                        if (!excelReader.IsDBNull(k))
                                        {
                                            nombreColumnas.Add(excelReader.GetString(k).ToString());

                                        }

                                    }

                                    //VALIDAR NOMBRE DE COLUMNAS (PRECIO)
                                    for (int z = 0; z < lConceptoPrecio.Count; z++)
                                    {
                                        if (lConceptoPrecio[z].descripcion.Equals(nombreColumnas[z]))
                                        {
                                            continue;
                                        }
                                        else
                                        {

                                            FLAG = 5;
                                            excelReader.Dispose(); //Liberar recurso para luego poder eliminarlo
                                            return FLAG;
                                        }
                                    }

                                }

                                lcadena.Add(laux);  //Lista de todas las filas del Excel

                            }
                        } //VALIDACION CUANDO SE ENCONTRO ULTIMA FILA CON ESPACIO - FIN (IF)

                        else  //VALIDACIÓN SI NÓ SE ENCONTRÓ FILA CON ESPACIO HASTA EL FINAL DE LAS FILAS. - INICIO (ELSE)
                        {
                            //Crear objeto Cabecera
                            int dep = excelReader.Depth;
                            laux = new List<String>();
                            nombreColumnas = new List<String>();

                            laux.Add(excelReader.GetString(0));

                            if (cont >= 2) //LISTA DE PRECIOS (VARIABLE)
                            {

                                //Validar si la fila tiene todas las columnas nulas (ahi deberá finalizar) - INICIO
                                if (String.IsNullOrEmpty(excelReader.GetString(0)))
                                {
                                    for (int h = 1; h < totalColumnas; h++)
                                    {

                                        if (String.IsNullOrEmpty(excelReader.GetString(h)))
                                        {
                                            filaNula = true;
                                        }
                                        else
                                        {
                                            filaNula = false;
                                        }
                                    }

                                    if (filaNula.Equals(true))
                                    {
                                        break; //finalizo el recorrido de filas del excel (finalizo el WHILE excelReader.Read())
                                    }

                                }
                                //Validar si la fila tiene todas las columnas nulas (ahi deberá finalizar) - FIN


                                //Obtener los datos de las columnas de Precios (N° Columnas Variables)
                                for (int j = 2; j < columnas; j++)
                                {
                                    Type tipoDato = excelReader.GetFieldType(j);

                                    if (tipoDato.Name.Equals("String"))
                                    {
                                        excelReader.Dispose(); //Liberar recurso para luego poder eliminarlo
                                        POSICION = cont;
                                        FLAG = 8;

                                        return FLAG;
                                    }

                                    if (tipoDato.Name.Equals("Double"))
                                    {
                                        if (excelReader.GetDouble(j) < 0) //Validando si precio es menor o igual a cero (0)
                                        {
                                            excelReader.Dispose(); //Liberar recurso para luego poder eliminarlo
                                            FLAG = 4;
                                            POSICION = cont;
                                            return FLAG;
                                        }
                                        laux.Add(excelReader.GetDouble(j).ToString());
                                    }


                                }
                            }
                            else //VALIDACION DE COLUMNAS
                            {
                                //Obtener los datos de los nombres de las columnas (Precios)
                                int x = 0; //contador de columnas no incluye las nulas para validar cantidad de columnas
                                for (int j = 2; j < columnas; j++)
                                {
                                    if (!excelReader.IsDBNull(j))
                                    {
                                        laux.Add(excelReader.GetString(j).ToString());
                                        x = x + 1;
                                    }

                                }

                                x = x + 2;
                                // VALIDAR CANTIDAD DE COLUMNAS
                                if (validarArchivoExcel(x).Equals(false)) //NO CONTIENE LA CANTIDAD DE COLUMNAS CORRECTAS
                                {
                                    excelReader.Dispose(); //Liberar recurso para luego poder eliminarlo
                                    FLAG = 2;
                                    return FLAG;

                                }

                                //OTENER NOMBRE DE TODAS LAS COLUMNAS DEL EXCEL EN LA LISTA (Nombre Columnas)
                                totalColumnas = columnas;

                                for (int k = 0; k < columnas; k++)
                                {
                                    if (!excelReader.IsDBNull(k))
                                    {
                                        nombreColumnas.Add(excelReader.GetString(k).ToString());

                                    }

                                }

                                //VALIDAR NOMBRE DE COLUMNAS (PRECIO)
                                for (int z = 0; z < lConceptoPrecio.Count; z++)
                                {
                                    if (lConceptoPrecio[z].descripcion.Equals(nombreColumnas[z]))
                                    {
                                        continue;
                                    }
                                    else
                                    {

                                        FLAG = 5;
                                        excelReader.Dispose(); //Liberar recurso para luego poder eliminarlo
                                        return FLAG;
                                    }
                                }

                            }

                            lcadena.Add(laux);  //Lista de todas las filas del Excel

                        } //VALIDACIÓN SI NÓ SE ENCONTRÓ FILA CON ESPACIO HASTA EL FINAL DE LAS FILAS. - FIN (ELSE)


                    } //FIN DE WHILE DE LECTURA DEL "EXCEL DATA READER"


                } while (excelReader.NextResult());

                if (cont == 0) //VALIDAR CUANDO SE SUBE UN EXCEL VACIO (SIN NADA)
                {
                    FLAG = 1;
                    excelReader.Dispose(); //Liberar recurso para luego poder eliminarlo
                    return FLAG;
                }

                //VALIDAR CODIGO DE PRODUCTO REPETIDO - INICIO
                for (int m = 1; m < lcadena.Count; m++) //se inicio a partir del indice (1) porque el indice cero (0) deberia contener el nombre de las columnas
                {
                    String cadena1 = lcadena[m][0].ToUpper();
                    for (int n = 2; n < lcadena.Count; n++)
                    {
                        String cadena2 = lcadena[n][0].ToUpper();
                        if (m < n) //Esta condicion es necesaria para que no se analice la misma fila y no se confunda con un codigo repetido.
                        {
                            if (cadena1.Equals(cadena2))
                            {
                                //Codigo de Producto REPETIDO, Se mostrara mensaje de Validacion (NO SE CONTINUARA CON EL PROCESO)
                                CODIGO = cadena1;
                                FLAG = 9;
                                excelReader.Dispose(); //Liberar recurso para luego poder eliminarlo
                                return FLAG;
                            }
                        }
                    }

                }
                //VALIDAR CODIGO DE PRODUCTO REPETIDO - FIN


                //VALIDAR EXISTENCIA DE CODIGO DE PRODUCTO EN LA BASE DE DATOS
                for (int g = 1; g < lcadena.Count; g++)
                {
                    string codigoProducto = lcadena[g][0];

                    int cantidad = clnPrecio.validarCodigoProducto(codigoProducto);
                    if (cantidad == 0)
                    {
                        FLAG = 6;
                        CODIGO = codigoProducto;
                        excelReader.Dispose(); //Liberar recurso para luego poder eliminarlo
                        return FLAG;
                    }
                }


                //#####INICIO: PROCESAR EXCEL######
                rpta = clnPrecio.procesarExcel(lcadena);
                if (rpta)
                {
                    obtenerDatos(); //Obtengo los datos de la BD y Actualizo el GRIDVIEW
                    FLAG = 3; //TODO CORRECTO
                }
                //#####FIN: PROCESAR EXCEL######

                //#########################
                excelReader.Dispose(); //Liberar recurso para luego poder eliminarlo

            }
            catch (Exception ex)
            {
                excelReader.Dispose();
                throw ex;
            }

            return FLAG;
        }

        public Boolean validarNumeroColumnasEspecifico(DataRow dataRow, int numeroColumnasCorrectasBD)
        {
            //DESCRIPCION: Validar número de columnas especifico por cada fila
            Boolean respuesta = false;
            int cantidadColumnasSinVacios = 0;

            try
            {
                for (int i = 0; i < dataRow.Table.Columns.Count; i++)
                {

                    if (!String.IsNullOrEmpty(dataRow[i].ToString().Trim()))
                    {
                        cantidadColumnasSinVacios = cantidadColumnasSinVacios + 1;
                    }
                    else
                    {
                        if (String.IsNullOrEmpty(dataRow[i].ToString().Trim()))
                        {
                            SOSPECHA_COLUMNAS_VACIAS = SOSPECHA_COLUMNAS_VACIAS + 1;
                        }
                    }

                }


                if (cantidadColumnasSinVacios.Equals(numeroColumnasCorrectasBD))
                {
                    respuesta = true;
                    return respuesta;
                }
                else
                {

                    respuesta = false;
                    return respuesta;


                }

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public Boolean obtenerCantidadColumnasSinContarNulosNiVacios(DataTable dataTable, int cantidadColumnasCorrectas)
        {
            //DESCRIPCION: Obtener cantidad de columnas sin contar NULOS NI VACIOS
            int cantidadColumnasExcel = 0;
            int ultimaFilaValida = 0;
            Boolean respuesta = false;
            Boolean respuestaFila = false;

            try
            {
                //VALIDAR LA EXISTENCIA DE FILA NULA - INICIO
                if (EXISTE_FILA_NULA)
                {
                    ultimaFilaValida = INDICE_PRIMERA_FILA_NULA;
                }
                else
                {
                    ultimaFilaValida = dataTable.Rows.Count;
                }
                //VALIDAR LA EXISTENCIA DE FILA NULA - FIN


                for (int i = 0; i < ultimaFilaValida; i++)
                {
                    DataRow row = dataTable.Rows[i];
                    cantidadColumnasExcel = 0;

                    for (int j = 0; j < row.Table.Columns.Count; j++)
                    {
                        if (!row[j].ToString().Trim().Equals(""))
                        {
                            cantidadColumnasExcel = cantidadColumnasExcel + 1;
                        }
                    }

                    if (cantidadColumnasCorrectas.Equals(cantidadColumnasExcel))
                    {
                        respuestaFila = true;

                        continue;

                    }
                    else
                    {
                        POSICION = i + 1;
                        respuesta = false;

                        return respuesta;
                    }

                }

                if (respuestaFila)
                {
                    CANTIDAD_COLUMNAS_SINVACIOS = cantidadColumnasExcel;
                    respuesta = true;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return respuesta;

        }

        public Boolean validarUltimaFila(DataTable table, int cantidadColumnasCargaMasiva, int fila)
        {
            //DESCRIPCION: Validacion de Ultima Fila NULA (NOTA: TODO ESTE PROCESO ES NECESARIO, PARA VALIDAR UN CASO DONDE SE COLOQUE ESPACIO EN BLANCO EN LA ULTIMA FILA DEL EXCEL.
            String cadenaSinEspacio = "";
            Boolean rpta = false;
            int cantNulosColumnas = 0;
            int cantNulosFilas = 0;

            try
            {
                for (int i = fila; i < table.Rows.Count; i++) //Obtengo fila a fila
                {
                    DataRow row = table.Rows[i];
                    for (int j = 0; j < cantidadColumnasCargaMasiva; j++) //Obtengo valores de cada fila
                    {
                        cadenaSinEspacio = row[j].ToString().Trim();

                        if (String.IsNullOrEmpty(cadenaSinEspacio))
                        {
                            cantNulosColumnas++;
                        }
                    }

                    if (cantNulosColumnas.Equals(cantidadColumnasCargaMasiva)) //Fila contiene todos los valores Nulos
                    {
                        rpta = true; //Fila 

                    }
                    else
                    {
                        rpta = false; //Fila NO contiene todos los valores Nulos
                        break; //Se rompe el for principal y se continúa validando la siguiente fila desde la function que llama a esta.
                    }

                    //*****************************************************************************
                    //A PARTIR DE AQUI EN ADELANTE SE ANALIZARÁ SI LA FILA ENCONTRADA ES LA ÚLTIMA
                    //*****************************************************************************

                    if (rpta.Equals(true)) //Se analizará hasta el final de las finales para verificar si es la ULTIMA FILA
                    {                      //Se evaluará dentro del for principal, pues si no es la Ultima fila se deberá continuar con el proceso de verificar filas nulas.

                        cadenaSinEspacio = "";
                        cantNulosColumnas = 0; //Se inicializa ademas por cada fila.
                        cantNulosFilas = 0;    //Solo es necesario inicializar a este nivel.

                        for (int k = fila + 1; k < table.Rows.Count; k++)
                        //se le suma "1" a la variable "k", para continuar evaluando la siguiente fila en (INICIO)
                        //busca de que todos sus valores seas nulos para encontrar asi la ultima fila.    (INICIO)
                        {
                            DataRow rowAux = table.Rows[k];
                            cantNulosColumnas = 0;

                            for (int h = 0; h < cantidadColumnasCargaMasiva; h++) //Obtengo valores de cada fila
                            {
                                cadenaSinEspacio = rowAux[h].ToString().Trim();

                                if (String.IsNullOrEmpty(cadenaSinEspacio))
                                {
                                    cantNulosColumnas++;
                                }
                            }


                            if (cantNulosColumnas.Equals(cantidadColumnasCargaMasiva))
                            {
                                cantNulosFilas++; //Cuenta cada fila donde se obtuvo todos los valores en NULO y/o VACIO.
                                continue;
                            }
                            else
                            {
                                return false; //Si la siguiente fila no contiene todos los valores nulos se continua validando la fila siguiente desde la funcion que llama a esta.
                            }
                        } //se le suma "1" a la variable "k", para continuar evaluando la siguiente fila en (FIN)
                          //busca de que todos sus valores seas nulos para encontrar asi la ultima fila.    (FIN)

                        //CONDICIONES PARA OBTENER EL INDICE DE LA PRIMERA FILA NULA (PUEDE HABER MÁS FILAS NULAS HASTA ALCANZAR EL TOTAL DE FILAS)
                        if (cantNulosFilas.Equals(table.Rows.Count - fila)) //Cantidad de Filas Nulas desde la primera fila que se encontró todos sus valores nulos hasta la última fila (Cuando desde que se encontro la primera fila con espacios en blanco hasta la ultima fila hay más de una fila con espacios en blanco) 
                        {
                            //ESTA ES LA PRIMERA FILA CON TODOS LOS VALORES NULOS - INICIO
                            INDICE_PRIMERA_FILA_NULA = fila;
                            EXISTE_FILA_NULA = true; //Existe fila nula (puede haber mas de 1 fila con espacio en blanco)
                            rpta = true;
                            return rpta;
                            //ESTA ES LA PRIMERA FILA CON TODOS LOS VALORES NULOS - FIN

                        }

                        if (cantNulosFilas.Equals(table.Rows.Count - (fila + 1))) //Cantidad de Filas Nulas desde la primera fila que se encontró todos sus valores nulos hasta la última fila (Cuando la ultima fila es la que contiene espacios en blanco) 
                        {
                            //ESTA ES LA PRIMERA FILA CON TODOS LOS VALORES NULOS - INICIO
                            INDICE_PRIMERA_FILA_NULA = fila;
                            EXISTE_FILA_NULA = true;
                            rpta = true;
                            return rpta;
                            //ESTA ES LA PRIMERA FILA CON TODOS LOS VALORES NULOS - FIN

                        }
                    }


                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rpta;

        }

        public Boolean validarArchivoExcel(int columnasExcel)
        {
            //DESCRIPCION: Validar cantidad de columnas
            Boolean respuesta = false;

            try
            {
                int cantidadColumnasExcel = columnasExcel; //Columnas del Excel
                int cantidadColumnasBD = 0;
                List<CENConcepto> lConcepto;
                CLNConcepto CLNConcepto = new CLNConcepto();
                lConcepto = CLNConcepto.obtenerCorrelativos();
                cantidadColumnasBD = lConcepto.Count;

                cantidadColumnasBD = cantidadColumnasBD + 3; // A la cantidad de Tipos de Precios de la BD se le suma la Columna Codigo de Producto, Descripcion y Precio Costo.

                if (cantidadColumnasExcel == cantidadColumnasBD)
                {
                    respuesta = true;
                }
                else
                {
                    respuesta = false;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return respuesta;

        }

        public int cantidadColumnasCorrectasCargaMasiva()
        {
            //DESCRIPCION: Cantidad de Columnas Correctas Carga Masiva
            int cantidadColumnasBD = 0;

            try
            {

                List<CENConcepto> lConcepto;
                CLNConcepto CLNConcepto = new CLNConcepto();
                lConcepto = CLNConcepto.obtenerCorrelativos();
                cantidadColumnasBD = lConcepto.Count;

                cantidadColumnasBD = cantidadColumnasBD + 3; // A la cantidad de Tipos de Precios de la BD se le suma la Columna Codigo de Producto, Descripcion y Precio Costo.


            }
            catch (Exception ex)
            {
                throw ex;
            }

            return cantidadColumnasBD;

        }


        public void llenarCombos()
        {
            //DESCRIPCION: Llenar combos
            List<CENProveedor> lProveedor;
            List<CENFabricante> lFabricante;
            List<CENCategoria> lCategoria;

            CLNPrecio CLNPrecio = new CLNPrecio();
            try
            {
                //Listas
                lProveedor = CLNPrecio.LlenarComboProveedor();
                lFabricante = CLNPrecio.LlenarComboFabricante();
                lCategoria = CLNPrecio.LlenarComboCategoria();

                //Proveedor
                ddlProveedor.DataSource = lProveedor;
                ddlProveedor.DataTextField = "descproveedor";                            // FieldName of Table in DataBase
                ddlProveedor.DataValueField = "codigoProveedor";
                ddlProveedor.DataBind();
                //Fabricante
                ddlFabricante.DataSource = lFabricante;
                ddlFabricante.DataTextField = "descFabricante";                            // FieldName of Table in DataBase
                ddlFabricante.DataValueField = "codigoFabricante";
                ddlFabricante.DataBind();
                //Categoria
                ddlCategoria.DataSource = lCategoria;
                ddlCategoria.DataTextField = "descCategoria";                            // FieldName of Table in DataBase
                ddlCategoria.DataValueField = "codigoCategoria";
                ddlCategoria.DataBind();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            //DESCRIPCION: buscar por Codigo de Producto y Descripcion
            int FLAG;
            ArrayList lParametros = new ArrayList();
            try
            {
                List<CENVPrecio> lVPrecio;
                CLNPrecio CLNPrecio = new CLNPrecio();
                //Obtener item seleccionadode combos
                int codProveedor = Int32.Parse(ddlProveedor.SelectedValue.ToString());
                int codFabricante = Int32.Parse(ddlFabricante.SelectedValue.ToString());
                int codCategoria = Int32.Parse(ddlCategoria.SelectedValue.ToString());
                int codSubcategoria = Int32.Parse(ddlSubcategoria.SelectedValue.ToString());
                string producto = txtProducto.Text;

                lVPrecio = CLNPrecio.buscarProducto(codProveedor, codFabricante, codCategoria, codSubcategoria, producto);

                if (lVPrecio.Count.Equals(0)) //MOSTRAR MENSAJE OCULTO CUANDO NO SE ENCONTRÓ DATA PARA EL FORMULARIO PRINCIPAL
                {
                    lblMensaje.Visible = true;
                }
                else
                {
                    lblMensaje.Visible = false;
                }

                grdViewPrincipal.DataSource = lVPrecio;
                grdViewPrincipal.DataBind();


                //GUARDAR PARAMETROS PARA POSTERIOR REPORTE y/o PAGINACION
                lParametros.Add(codProveedor); //Proveedor
                lParametros.Add(codFabricante); //Fabricante
                lParametros.Add(codCategoria); //Categoria
                lParametros.Add(codSubcategoria); //Subcategoria
                lParametros.Add(producto); //Producto

                Session["lParametros"] = lParametros;

                gvAux = new GridView(); //VARIABLE UTILIZADA PARA REPORTE


            }
            catch (Exception ex)
            {
                //MENSAJES GENERICO NO CONTROLADO (Buscar - btnBuscar_Click)                
                FLAG = -999;
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                   "MSJInformativo", "mensajeInformativo('" + FLAG + "','','','');", true);

            }

        }

        protected void grvActualizarPrecios_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //DESCRIPCION: Boton Editar de Grid View Modal (Command Field)
            int FLAG;

            try
            {
                grvActualizarPrecios.EditIndex = e.NewEditIndex;

                CLNPrecio clnPrecio = new CLNPrecio();

                grvActualizarPrecios.DataSource = clnPrecio.ObtenerDetallePrecio(codProductoActualizar.Text);
                grvActualizarPrecios.DataBind();

            }
            catch (Exception ex)
            {
                //MENSAJES GENERICO NO CONTROLADO (Editar / Modal - grvActualizarPrecios_RowEditing)  
                FLAG = -999;
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                "MSJInformativo", "mensajeInformativo('" + FLAG + "','','','');", true);
            }


        }

        protected void grvActualizarPrecios_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //DESCRIPCION: Boton Cancelar de Grid View Modal (Command Field)
            int FLAG;

            try
            {
                grvActualizarPrecios.EditIndex = -1;

                CLNPrecio clnPrecio = new CLNPrecio();
                grvActualizarPrecios.DataSource = clnPrecio.ObtenerDetallePrecio(codProductoActualizar.Text);
                grvActualizarPrecios.DataBind();

            }
            catch (Exception ex)
            {
                //MENSAJES GENERICO NO CONTROLADO (Cancelar / Modal - grvActualizarPrecios_RowCancelingEdit)  
                FLAG = -999;
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                "MSJInformativo", "mensajeInformativo('" + FLAG + "','','','');", true);
            }

        }

        protected void grvActualizarPrecios_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //DESCRIPCION: Boton Actualizar de Grid View modal (Command Field)
            CLNPrecio clnPrecio = new CLNPrecio();
            Boolean respuesta = false;
            string sprecio = "";
            string mensaje = "";
            int FLAG;

            List<CENVPrecio> lVPrecio;
            ArrayList lParametros = new ArrayList();
            CLNPrecio CLNPrecio = new CLNPrecio();

            try
            {
                GridViewRow row = grvActualizarPrecios.Rows[e.RowIndex];
                int tipoListaPrecio = Convert.ToInt32((row.FindControl("lblcorrelativo") as Label).Text);
                sprecio = (row.FindControl("txtPrecioVenta") as TextBox).Text;
                //decimal dprecio = Convert.ToDecimal(sprecio);
                //sprecio = Convert.ToString(dprecio); 
                //PATRON SE VALIDACION EN EL LADO DEL SERVIDOR ES DISTINTO AL PATRON DE VALIDACION EN EL LADO DEL CLIENTE
                //ESTO SE DEBE A QUE LA VALIDACION EN EL LADO DEL SERVIDOR ES ESPECIFICA AL FORMARTO: (Numero.Decimal) SIN INCLUIR COMAS
                Regex rg = new Regex(@"^(\d+)((\.\d+))$");
                Regex rg2 = new Regex(@"^(\d+)$");

                if (!sprecio.Trim().Equals("")) //SÓLO SE CONTINÚA CON EL PROCESO SI SE HA INGRESADO PRECIO.
                {
                    if (rg.IsMatch(sprecio) || rg2.IsMatch(sprecio))
                    {
                        decimal precio = Convert.ToDecimal((row.FindControl("txtPrecioVenta") as TextBox).Text);

                        //Comparar con la lista de precio de la base de datos si ha variado el precio
                        respuesta = clnPrecio.compararPrecio(codProductoActualizar.Text, tipoListaPrecio, precio); //METODO ACTUALIZAR Y/O REGISTRAR
                                                                                                                   //Actualizar Datos GRID VIEW (Modal Actualizar)

                        if (respuesta) //Solo vuelve actualizar el Modal con la data real de la Base de Datos si hubo cambios en la misma.
                        {

                            grvActualizarPrecios.EditIndex = -1; //VOLVER BOTONES ACTUALIZAR A POSICION NORMAL (1 SOLO BOTON)

                            grvActualizarPrecios.DataSource = clnPrecio.ObtenerDetallePrecio(codProductoActualizar.Text);
                            grvActualizarPrecios.DataBind();

                            //ACTUALIZAR GRID VIEW PRINCIPAL LUEGO DE ACTUALIZAR EN EL MODAL
                            //SE ACTUALIZARÁ CON LA DATA FILTRADA Ó CON LA DATA CARGADA INICIALMENTE (TODA LA DATA)
                            lParametros = (ArrayList)Session["lParametros"];
                            lVPrecio = CLNPrecio.buscarProducto(Convert.ToInt32(lParametros[0]), Convert.ToInt32(lParametros[1]), Convert.ToInt32(lParametros[2]), Convert.ToInt32(lParametros[3]), Convert.ToString(lParametros[4]));

                            grdViewPrincipal.DataSource = lVPrecio;
                            grdViewPrincipal.DataBind();

                        }

                    }
                    else
                    {
                        mensaje = CLNPrecio.obtenerDescripcionConcepto(CENConstante.g_const_1, CENConstante.g_const_10, CENConstante.g_const_12);

                        ScriptManager.RegisterStartupScript(this, this.GetType(),
                    "MSJInformativo", "validarFormatoDecimalServidor('" + mensaje + "');", true);
                    }
                }
                else
                { //MENSAJE CUANDO NO SE HA INGRESADO PRECIO
                    mensaje = CLNPrecio.obtenerDescripcionConcepto(CENConstante.g_const_1, CENConstante.g_const_10, CENConstante.g_const_16);

                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                "MSJInformativo", "validarFormatoDecimalServidor('Debe ingresar un número');", true);
                }
            }
            catch (Exception ex)
            {
                //MENSAJES GENERICO NO CONTROLADO (Actualizar / Modal - grvActualizarPrecios_RowUpdating)  
                FLAG = -999;
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                "MSJInformativo", "mensajeInformativo('" + FLAG + "','','','');", true);
            }

        }

        protected void grdViewPrincipal_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //DESCRIPCION: Evento de la Grilla Principal
            List<CENDetallePrecio> ldetPrecio;
            int FLAG;

            try
            {
                if (e.CommandName.Equals("ver")) //Ver Detalle de Precios
                {
                    int index = Convert.ToInt32(e.CommandArgument);

                    GridViewRow gvrow = grdViewPrincipal.Rows[index];

                    codProducto.Text = Server.HtmlDecode(gvrow.Cells[8].Text).ToString();
                    descProducto.Text = Server.HtmlDecode(gvrow.Cells[9].Text).ToString();

                    CLNPrecio clnPrecio = new CLNPrecio();
                    //Obtener Detalle de Precios Completo
                    ldetPrecio = clnPrecio.ObtenerDetallePrecio(codProducto.Text);

                    grvVerDetallePrecios.DataSource = ldetPrecio;
                    grvVerDetallePrecios.DataBind();
                    mdeVerDetalle.Show(); //mostrando la ventana modal con ModalPopExtender

                }

                if (e.CommandName.Equals("editar")) //Ver Detalle de Precios
                {
                    int index = Convert.ToInt32(e.CommandArgument);

                    GridViewRow gvrow = grdViewPrincipal.Rows[index];

                    codProductoActualizar.Text = Server.HtmlDecode(gvrow.Cells[0].Text).ToString();
                    descProductoActualizar.Text = Server.HtmlDecode(gvrow.Cells[9].Text).ToString();

                    CLNPrecio clnPrecio = new CLNPrecio();
                    //Obtener Detalle de Precios Completo
                    ldetPrecio = clnPrecio.ObtenerDetallePrecio(codProductoActualizar.Text);

                    //Cargar Data en GridView Modal (EDITAR)
                    grvActualizarPrecios.DataSource = ldetPrecio;
                    grvActualizarPrecios.DataBind();
                    mdeActualizarPrecios.Show(); //mostrando la ventana modal con ModalPopExtender

                }

            }
            catch (Exception ex)
            {
                //MENSAJES GENERICO NO CONTROLADO (Ver / Actualizar - grdViewPrincipal_RowCommand)    
                FLAG = -999;
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                "MSJInformativo", "mensajeInformativo('" + FLAG + "','','','');", true);
            }
        }

        protected void btnReporte_Click(object sender, EventArgs e)
        {
            //DESCRIPCION: Reporte de Data GRID VIEW (DENTRO DEL FOR DEL GRID VIEW)
            ArrayList lParametros = new ArrayList();
            int FLAG;

            try
            {
                List<string> lfila;
                List<List<string>> lGriedView = new List<List<string>>();

                List<CENCPrecio> listaCabecera;
                List<CENVPrecio> lVPrecio;

                CLNPrecio CLNPrecio = new CLNPrecio();
                gvAux = new GridView(); //VARIABLE UTILIZADA PARA REPORTE

                /////////////////////////////////////////
                //PASOS PARA GENERAR EL REPORTE (INICIO)
                /////////////////////////////////////////

                //PASO 01 => OBTENER DATOS DE GRID VIEW (Codigo de Producto y Descripcion de Producto)
                //OBTENER DATOS FILTRADOS
                lParametros = (ArrayList)Session["lParametros"];
                lVPrecio = CLNPrecio.buscarProducto(Convert.ToInt32(lParametros[0]), Convert.ToInt32(lParametros[1]), Convert.ToInt32(lParametros[2]), Convert.ToInt32(lParametros[3]), Convert.ToString(lParametros[4]));

                gvAux.DataSource = lVPrecio;
                gvAux.DataBind();

                foreach (GridViewRow row in gvAux.Rows)
                {
                    lfila = new List<string>();

                    lfila.Add(row.Cells[8].Text); //Codigo de Producto
                    lfila.Add(row.Cells[5].Text); //Descripcion de Categoria
                    lfila.Add(row.Cells[7].Text); //Descripcion de Subcategoria
                    lfila.Add(row.Cells[3].Text); //Descripcion de Fabricante
                    lfila.Add(row.Cells[9].Text); //Descripcion de Producto

                    lGriedView.Add(lfila);
                }


                //PASO 02 => OBTENER PRODUCTO CON SU DETALLE DE PRECIOS
                listaCabecera = CLNPrecio.ObtenerDetalleXProductoReporte(lGriedView);

                //PASO 03 => OBTENER DATA TABLE
                DataTable dataTable = CLNPrecio.ObtenerDataTableReporte(listaCabecera);

                DataRow filaNueva;
                //Validar cuando el dataTable NO tiene data
                if (dataTable.Rows.Count == 0)
                {
                    filaNueva = dataTable.NewRow();
                    filaNueva[0] = "";

                    dataTable.Rows.Add(filaNueva);
                }

                //PASO 04 => GENERAR REPORTE                
                GenerarReporte(dataTable);

                //////////////////////////////////
                //PASOS PARA GENERAR EL REPORTE (FIN)
                //////////////////////////////////          

            }
            catch (Exception ex)
            {
                //MENSAJES GENERICO NO CONTROLADO (REPORTE: btnReporte_Click)    
                FLAG = -999;
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                "MSJInformativo", "mensajeInformativo('" + FLAG + "','','','');", true);

            }

        }

        public void GenerarReporte(DataTable dt)
        {
            //DESCRIPCION: Genera Archivo Excel

            try
            {
                //GENERAR REPORTE
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                StringWriter sw = new StringWriter(sb);

                GridView dg = new GridView();
                dg.Caption = "REPORTE DE PRECIOS DE ARTICULOS";
                dg.EnableViewState = false;
                dg.DataSource = dt;
                dg.DataBind();
                Page pagina = new Page();
                HtmlForm form = new HtmlForm();
                HtmlTextWriter htw = new HtmlTextWriter(sw);

                pagina.EnableEventValidation = false;
                pagina.DesignerInitialize();
                pagina.Controls.Add(form);
                form.Controls.Add(dg);
                pagina.RenderControl(htw);
                Response.Clear();
                Response.Buffer = false;
                Response.ContentType = "application/vnd.ms-excel";
                Response.AddHeader("Content-Disposition", "attachment;filename=ReportePrecios.xls");
                Response.Charset = "UTF-8";
                Response.ContentEncoding = System.Text.Encoding.Default;
                Response.Write(sb.ToString());
                Response.Flush();
                Response.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DESCRIPCION: Cargar SubCategoria
            int FLAG;
            try
            {

                while (ddlSubcategoria.Items.Count > 1)
                {
                    ddlSubcategoria.Items.RemoveAt(1);
                }

                List<CENSubcategoria> lSubcategoria;
                CLNPrecio CLNPrecio = new CLNPrecio();
                lSubcategoria = CLNPrecio.LlenarComboSubcategoria(ddlCategoria.SelectedIndex);
                ddlSubcategoria.DataSource = lSubcategoria;
                ddlSubcategoria.DataValueField = "ntraSubcategoria";
                ddlSubcategoria.DataTextField = "descSubcategoria";                            // FieldName of Table in DataBase

                ddlSubcategoria.DataBind();


            }
            catch (Exception ex)
            {
                //MENSAJES GENERICO NO CONTROLADO (DROP DOWN LIST CATEGORIA - ddlCategoria_SelectedIndexChanged)                
                FLAG = -999;
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                "MSJInformativo", "mensajeInformativo('" + FLAG + "','','','');", true);
            }

        }

        protected void grdViewPrincipal_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //DESCRIPCION: Paginación
            int FLAG;
            CLNPrecio CLNPrecio = new CLNPrecio();
            List<CENVPrecio> lVPrecio;
            ArrayList lParametros = new ArrayList();

            try
            {
                grdViewPrincipal.PageIndex = e.NewPageIndex;

                lParametros = (ArrayList)Session["lParametros"];
                lVPrecio = CLNPrecio.buscarProducto(Convert.ToInt32(lParametros[0]), Convert.ToInt32(lParametros[1]), Convert.ToInt32(lParametros[2]), Convert.ToInt32(lParametros[3]), Convert.ToString(lParametros[4]));

                grdViewPrincipal.DataSource = lVPrecio;
                grdViewPrincipal.DataBind();

            }
            catch
            {
                //MENSAJES GENERICO NO CONTROLADO (PAGINACION GRID VIEW PRINCIPAL - grdViewPrincipal_PageIndexChanging)                  
                FLAG = -999;
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                "MSJInformativo", "mensajeInformativo('" + FLAG + "','','','');", true);

            }

        }

        protected void btnFactDistribucion_Click(object sender, EventArgs e)
        {
            //Descripcion: Se eligio el modo de distribucion automatica de precios
            try
            {
                CLNPrecio clnPrecio = new CLNPrecio();
                List<CENFactDistribPrecio> lTipoPrecioParametrizado = new List<CENFactDistribPrecio>();

                lTipoPrecioParametrizado = clnPrecio.listar_tipo_precio_parametrizado();

                //Cargar Data en GridView Modal (FACTOR DISTRIBUCION)
                grvDistribucionAutomaticaPrecios.DataSource = lTipoPrecioParametrizado;
                grvDistribucionAutomaticaPrecios.DataBind();
                mdeDistribucionAutomaticaPrecios.Show(); //mostrando la ventana modal con ModalPopExtender

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnProcesarDistribucionPrecios_Click(object sender, EventArgs e)
        {
            //Descripcion: Procesar (registrar y/o actualizar) factor de precio en la BD
            try
            {
                DataTable dt = new DataTable("TblPrecio");
                DataColumn dtColumn;
                DataRow myDataRow;

                dtColumn = new DataColumn();
                dtColumn.DataType = typeof(Int32);
                dtColumn.ColumnName = "correlativo";

                dt.Columns.Add(dtColumn);

                dtColumn = new DataColumn();
                dtColumn.DataType = typeof(String);
                dtColumn.ColumnName = "descripcion";

                dt.Columns.Add(dtColumn);

                dtColumn = new DataColumn();
                dtColumn.DataType = typeof(Decimal);
                dtColumn.ColumnName = "precioVenta";

                dt.Columns.Add(dtColumn);

                myDataRow = dt.NewRow();
                myDataRow["correlativo"] = 1;
                myDataRow["descripcion"] = "Precio Cobertura";
                myDataRow["precioVenta"] = 1.23;
                dt.Rows.Add(myDataRow);

                myDataRow = dt.NewRow();
                myDataRow["correlativo"] = 2;
                myDataRow["descripcion"] = "Precio Mayorista";
                myDataRow["precioVenta"] = 2.34;
                dt.Rows.Add(myDataRow);

                mdeDistribucionAutomaticaPrecios.Hide();

                //Cargar Data en GridView Modal (EDITAR)
                grvActualizarPrecios.DataSource = dt;
                grvActualizarPrecios.DataBind();
                mdeActualizarPrecios.Show(); //mostrando la ventana modal con ModalPopExtender

            }
            catch (Exception)
            {

                throw;
            }
               
            }

        protected void btnCancelarDistribucionAutomaticaPrecios_Click(object sender, EventArgs e)
        {
            //Descripcion: Cierra el modal de Distribucion automatica de precios
            try
            {
                mdeDistribucionAutomaticaPrecios.Hide();

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void grvDistribucionAutomaticaPrecios_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Descripcion: Habilitar input para actualizar Factor de Distribucion
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void grvDistribucionAutomaticaPrecios_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //Descripcion: Actualizar Factor de Distribucion en la BD
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }


        protected void grvDistribucionAutomaticaPrecios_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //Descripcion: Cancelar Actualizacion de Factor de Distribucion
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}