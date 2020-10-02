using CEN;
using CAD;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using ExcelDataReader;
using System.Data;

namespace CLN
{
    public class CLNPrecio
    {

        public List<CENVPrecio> obtenerPrecios()
        {
            List<CENVPrecio> obtenerPrecios;
            CADPrecio CADPrecio = new CADPrecio();

            obtenerPrecios = CADPrecio.Obtener_VPrecios();

            return obtenerPrecios;
        }

        public List<CENDetallePrecio> ObtenerDetallePrecio(String codigoArticulo)
        {
            List<CENDetallePrecio> detallePrecio;
            CADPrecio CADPrecio = new CADPrecio();

            detallePrecio = CADPrecio.ObtenerDetallePrecios(codigoArticulo);

            return detallePrecio;
        }

        public void RegistrarActualizarxCargaMasiva(String codProducto, int tipoListaPrecio, double valor, int flag)
        {
            //DESCRIPCION: Registra Actualiza por Carga Masiva
            CADPrecio CADPrecio = new CADPrecio();

            try
            {
                CADPrecio.RegistrarActualizarxCargaMasiva(codProducto, tipoListaPrecio, valor, flag);

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public List<CENCPrecio> asignarDataExcelEnObjetos(List<List<string>> excel)
        {
            //Asignar la data del Excel en Objetos
            //DESCRIPCION: OrdenarDatos de Archivo Excel
            CENCPrecio cencPrecio;
            CENDPrecio cendPrecio;
            List<CENDPrecio> ldPrecio;
            List<CENCPrecio> lcPrecio = new List<CENCPrecio>();

            try
            {
                int arrayPrincipal = excel.Count; //Cantidad Filas
                int arraySecundario = excel[0].Count; //Cantidad Columnas

                for (int i = CENConstante.g_const_1; i < arrayPrincipal; i++)
                {
                    cencPrecio = new CENCPrecio(); //Cabecera por cada Producto que contiene un detalle de Precios

                    cencPrecio.CodProducto = excel[i][CENConstante.g_const_0];
                    cencPrecio.PrecioCosto = excel[i][CENConstante.g_const_1];

                    ldPrecio = new List<CENDPrecio>(); //Creamos una Lista Detalle Precio por Cada Cabecer de Precio
                    for (int j = CENConstante.g_const_2; j < arraySecundario; j++)
                    {
                        cendPrecio = new CENDPrecio(); //Creamos un Objetio Detalle Precio por Cada Producto

                        cendPrecio.PrecioVenta = excel[i][j];

                        ldPrecio.Add(cendPrecio);
                    }

                    cencPrecio.Ldprecios = ldPrecio;

                    lcPrecio.Add(cencPrecio); //Agrego las cabeceras a la Lista de Precios
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lcPrecio;

        }

        public List<CENCPrecio> completarDataExcel(List<CENCPrecio> dataExcel)
        {
            //Completar data del Excel con Código de Tipos de Precios
            CLNConcepto CLNConcepto = new CLNConcepto();
            List<CENConcepto> correlativos = CLNConcepto.obtenerCorrelativos();
            List<CENCPrecio> excelCompleto = new List<CENCPrecio>();

            CADPrecio cadPrecio = new CADPrecio();
            for (int i = 0; i < dataExcel.Count; i++) //Filas
            {
                //asignar Tipo de Precio Costo (Por defecto es Cero)
                //dataExcel[i].Ldprecios[0].TipoListaPrecio = 0;

                for (int j = 0; j < correlativos.Count; j++) //Detalle de Precios (Incluye Precio de Costo)
                {
                    //Asigno el codigo de Tipo de Precio a la lista del Excel                       
                    dataExcel[i].Ldprecios[j].TipoListaPrecio = correlativos[j].correlativo;
                }

            }

            excelCompleto = dataExcel;

            return excelCompleto;

        }

        public Boolean procesarExcel(List<List<string>> dataExcel)
        {
            List<CENCPrecio> lcabecera = new List<CENCPrecio>(); //Lista de Cabecera que contiene su detalle
            List<CENCPrecio> excelCompleto;
            List<CENCPrecio> dataTablasCompleto;
            Boolean rpta = false;
            try
            {
                lcabecera = asignarDataExcelEnObjetos(dataExcel);                        //PASO 01
                excelCompleto = completarDataExcel(lcabecera);                           //PASO 02
                dataTablasCompleto = obtenerDataBDProductoDetallePrecio();               //PASO 03
                rpta = compararDataExcelvsDataTablas(excelCompleto, dataTablasCompleto); //PASO 04

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rpta;

        }

        public List<CENCPrecio> obtenerDataBDProductoDetallePrecio()
        {
            List<CENCPrecio> datosBDCompleto;
            CADPrecio cadPrecio = new CADPrecio();
            try
            {
                datosBDCompleto = cadPrecio.obtenerDataBDProductoDetallePrecio();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return datosBDCompleto;
        }
        public Boolean compararDataExcelvsDataTablas(List<CENCPrecio> dataExcel, List<CENCPrecio> dataTablas)
        {
            //DESCRIPCION: Compara Data Excel versus Data de las Tablas
            String valorExcel = "";
            String valorTabla = "";
            String codProductoExcel = "";
            String codProductoBD = "";
            Double dvalorExcel;
            Double dvalorTabla;
            Boolean flag = false;
            CLNPrecio clnPrecio = new CLNPrecio();


            //DESCRIPCION: Comparar data de Excel vs Tabla           
            try
            {
                for (int i = 0; i < dataExcel.Count; i++) //Data de Excel
                {
                    for (int j = 0; j < dataTablas.Count; j++) //Data de Tablas
                    {
                        codProductoExcel = dataExcel[i].CodProducto.ToUpper(); //SE PASA A MAYUSCULAS PUES C# "SI" ES SENSIBLE A MAYUSCULAS Y/O MINUSCULAS SIN EMBARGO SQL "NO"
                        codProductoBD = dataTablas[j].CodProducto.ToUpper();   //SE PASA A MAYUSCULAS PUES C# "SI" ES SENSIBLE A MAYUSCULAS Y/O MINUSCULAS SIN EMBARGO SQL "NO"                    

                        if (codProductoExcel.Equals(codProductoBD)) //Buando codigo de producto de Excel en la Data de Tablas
                        {
                            //INICIO: DE LA COMPARACION DEL PRECIO COSTO DEL EXCEL VERSUS LA DATA DE LAS TABLAS
                            valorExcel = dataExcel[i].PrecioCosto;
                            valorTabla = dataTablas[j].PrecioCosto;
                            dvalorExcel = Convert.ToDouble(valorExcel); //Convertimos los precios a Double para eliminar los ceros a la derecha en casos los haya
                            dvalorTabla = Convert.ToDouble(valorTabla); //Convertimos los precios a Double para eliminar los ceros a la derecha en casos los haya
                            //FIN: DE LA COMPARACION DEL PRECIO COSTO DEL EXCEL VERSUS LA DATA DE LAS TABLAS
                            if (!dvalorExcel.Equals(dvalorTabla))
                            {

                                //ACTUALIZO (DE LO CONTRARIO NO REALIZO NINGUNA ACCION)
                                clnPrecio.RegistrarActualizarxCargaMasiva(dataExcel[i].CodProducto, 0, dvalorExcel, 1);

                            }

                            //INICIO: DE LA COMPARACION DEL DETALLE DE PRECIOS POR CADA PRODUCTO (Data del Excel versus Tablas de la Base de Datos)
                            valorExcel = "";
                            valorTabla = "";
                            for (int k = 0; k < dataExcel[i].Ldprecios.Count; k++)
                            {
                                flag = false; //Inicializo para volver a comparar el Detalle de Precios del Excel con el Detalle de Precio de las Tablas
                                for (int m = 0; m < dataTablas[j].Ldprecios.Count; m++)
                                {

                                    if (dataExcel[i].Ldprecios[k].TipoListaPrecio == dataTablas[j].Ldprecios[m].TipoListaPrecio) //Comparar por cada Tipo de Precio del Excel con el Tipo de Precio registrado en la Base de Datos
                                    {
                                        flag = true;
                                        //Si encuentro el mismo tipo de precio del Excel con la Base de Datos de cada Producto => Obtengo el Precio Venta para verificar si el valor es diferente para actualizar
                                        valorExcel = dataExcel[i].Ldprecios[k].PrecioVenta;
                                        valorTabla = dataTablas[j].Ldprecios[m].PrecioVenta;
                                        dvalorExcel = Convert.ToDouble(valorExcel); //Convertimos los precios a Double para eliminar los ceros a la derecha en casos los haya
                                        dvalorTabla = Convert.ToDouble(valorTabla); //Convertimos los precios a Double para eliminar los ceros a la derecha en casos los haya

                                        if (!dvalorExcel.Equals(dvalorTabla)) //si el valor del precio del Excel es distinto al Precio de la Tabla (ACTUALIZO)
                                        {
                                            //ACTUALIZO (DE LO CONTRARIO NO REALIZO NINGUNA ACCION)                                        
                                            clnPrecio.RegistrarActualizarxCargaMasiva(dataExcel[i].CodProducto, dataExcel[i].Ldprecios[k].TipoListaPrecio, dvalorExcel, 2);

                                        }

                                    }

                                }
                                //Si "NO" encontré el Tipo de Precio de la data del Excel en la Data de las Tablas recien inserto
                                if (flag == false)
                                {
                                    //INSERTO EN LA BASE DE DATOS (tblPrecio)
                                    clnPrecio.RegistrarActualizarxCargaMasiva(dataExcel[i].CodProducto, dataExcel[i].Ldprecios[k].TipoListaPrecio, Convert.ToDouble(dataExcel[i].Ldprecios[k].PrecioVenta), 3);

                                }

                            } //FIN: DE LA COMPARACION DEL DETALLE DE PRECIOS POR CADA PRODUCTO (Data del Excel versus Tablas de la Base de Datos)

                        } //SINO ENCUENTRO EL PRODUCTO NO HAGO NADA (PUES SOLO ACTUALIZO O AGREGO UN TIPO DE PRECIO SI EL PRODUCTO YA EXISTE PUES ESTE MANTENEDOR SOLO ES DE PRECIOS) 


                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;

            }

            return true;
        }

        public List<CENProveedor> LlenarComboProveedor()
        {
            //DESCRIPCION: Obtiene codigo y descripcion de Proveedor

            List<CENProveedor> lProveedor = new List<CENProveedor>();
            CADPrecio CADPrecio = new CADPrecio();
            try
            {
                lProveedor = CADPrecio.listarProveedor();
            }
            catch (Exception ex)
            {
                ex.StackTrace.ToString();
            }

            return lProveedor;


        }
        public List<CENFabricante> LlenarComboFabricante()
        {
            //DESCRIPCION: Obtiene codigo y descripcion de Fabricante
            List<CENFabricante> lFabricante = new List<CENFabricante>();
            CADPrecio CADPrecio = new CADPrecio();
            try
            {
                lFabricante = CADPrecio.listarFabricante();
            }
            catch (Exception ex)
            {
                ex.StackTrace.ToString();
            }

            return lFabricante;

        }

        public List<CENCategoria> LlenarComboCategoria()
        {
            //DESCRIPCION: Obtiene codigo y descripcion de Categoria
            List<CENCategoria> lCategoria = new List<CENCategoria>();
            CADPrecio CADPrecio = new CADPrecio();
            try
            {
                lCategoria = CADPrecio.listarCategoria();
            }
            catch (Exception ex)
            {
                ex.StackTrace.ToString();
            }

            return lCategoria;

        }

        public List<CENSubcategoria> LlenarComboSubcategoria(int ntraCategoria)
        {
            //DESCRIPCION: Obtiene codigo y descripcion de Subcategoria
            List<CENSubcategoria> lSubcategoria = new List<CENSubcategoria>();
            CADPrecio CADPrecio = new CADPrecio();
            try
            {
                lSubcategoria = CADPrecio.listarSubcategoria(ntraCategoria);
            }
            catch (Exception ex)
            {
                ex.StackTrace.ToString();
            }

            return lSubcategoria;

        }

        public List<CENVPrecio> buscarProducto(int codProveedor, int codFabricante, int codCategoria, int codSubcategoria, string producto)
        {
            //DESCRIPCION: buscar por codigo de producot y descripcion del producto
            List<CENVPrecio> lVPrecio = new List<CENVPrecio>();
            CADPrecio CADPrecio = new CADPrecio();
            try
            {
                lVPrecio = CADPrecio.BuscarProducto(codProveedor, codFabricante, codCategoria, codSubcategoria, producto);
            }
            catch (Exception ex)
            {
                ex.StackTrace.ToString();
            }

            return lVPrecio;

        }

        public Boolean compararPrecio(string codProducto, int tipoListaPrecio, decimal precio)
        {
            //DESCRIPCION: Compara si el precio ha variado o no (VENTANA MODAL - ACTUALIZAR)
            Boolean respuesta = false;
            Decimal precioBD = 0; //no tiene precio
            CLNPrecio clnPrecio = new CLNPrecio();
            CADPrecio CADPrecio = new CADPrecio();
            //NOTA: ES POSIBLE ACTUALIZAR UN VALOR DE PRECIO DE (0) A OTRO PRECIO MAYOR A CERO (0) ó
            //DE UN VALOR DE PRECIO DIFERENTE DE CERO A CERO (0)
            try
            {
                //Obtener lista de precios por Producto
                precioBD = CADPrecio.ObtenerPrecioXProducto(codProducto, tipoListaPrecio);  //cuando no encuentra precio en la TblPrecio el valor automatico asignado es cero (0), desde el store.           


                if (!tipoListaPrecio.Equals(0)) //Tipo de Precio es DISTINTO del PRECIO COSTO.
                {
                    if (precioBD.Equals(-1)) //NO SE ENCONTRÓ TIPO DE PRECIO EN LA TABLA: TBLPRECIO 
                    {                        //POR DEFECTO CUANDO NO SE ENCUENTRE EL TIPO DE PRECIO EN LA TABLA: TBLPRECIO, SE RETORNA (-1) DEL STORE.

                        //INSERTAR PRECIO VENTA EN LA BASE DE DATOS EN LA TABLA: TblPrecio
                        CADPrecio.ActualizarInsertarPrecioModal(codProducto, tipoListaPrecio, precio, 3); //INSERTAR PRECIO EN LA TABLA: TblPrecio (3)
                        respuesta = true;
                    }
                    else //SI SE ENCONTRÓ EL TIPO DE PRECIO EN LA TABLA: TBLPRECIO
                    {
                        if (!precioBD.Equals(precio))
                        {
                            //ACTUALIZAR PRECIO COSTO EN LA BASE DE DATOS EN LA TABLA: TblProducto
                            CADPrecio.ActualizarInsertarPrecioModal(codProducto, tipoListaPrecio, precio, 2); //ACTUALIAZR PRECIO EN LA TABLA: TblProducto (1)
                            respuesta = true;
                        }
                    }


                }
                else //Tipo de Precio es IGUAL a PRECIO COSTO
                {
                    if (!precioBD.Equals(precio)) //SI EL PRECIO DE LA BD ES DISTINTO AL PRECIO INGRESADO POR FORMULARIO SE ACTUALIZARÁ
                    {
                        //ACTUALIZAR PRECIO EN LA BASE DE DATOS EN LA TABLA: TblPrecio
                        CADPrecio.ActualizarInsertarPrecioModal(codProducto, tipoListaPrecio, precio, 1); //ACTUALIZAR PRECIO EN LA TABLA: TblProducto (1)
                        respuesta = true;
                    }
                }

            }
            catch (Exception ex)
            {
                ex.StackTrace.ToString();
            }

            return respuesta;

        }

        public List<CENCPrecio> ObtenerDetalleXProductoReporte(List<List<string>> gridView)
        {
            //DESCRIPCION: Generar Reporte Excel
            List<CENCPrecio> listaCabecera = new List<CENCPrecio>();
            List<CENDPrecio> listaDetalle = new List<CENDPrecio>();
            CADPrecio CADPrecio = new CADPrecio();

            List<CENDPrecio> lPrecioVenta; //Lista Contiene Sólo Precio de Venta X Producto

            try
            {
                for (int i = 0; i < gridView.Count; i++)
                {
                    CENCPrecio cabecera = new CENCPrecio();
                    cabecera.CodProducto = gridView[i][0];
                    cabecera.DescCategoria = gridView[i][1];
                    cabecera.DescSubcategoria = gridView[i][2];
                    cabecera.DescFabricante = gridView[i][3];
                    cabecera.Descripcion = gridView[i][4];
                    //Se obtiene tambien el valor del "Precio Costo" desde el método: "ObtenerSoloPrecioVentaXProducto" 
                    lPrecioVenta = CADPrecio.ObtenerSoloPrecioVentaXProducto(cabecera.CodProducto);
                    cabecera.Ldprecios = lPrecioVenta;

                    listaCabecera.Add(cabecera);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listaCabecera;
        }

        public List<CENConcepto> descripcionConceptoPrecio()
        {
            //DESCRIPCION: Obtener todas las descripcion del Prefijo = 7 (Tipos de Precios)
            List<CENConcepto> lDesConcepto;

            CADConcepto CADConcepto = new CADConcepto();
            lDesConcepto = CADConcepto.ListarConceptosDescripcionPrecio();

            return lDesConcepto;

        }

        public List<CENConcepto> ListarConceptoPrecio(int prefijo)
        {
            //DESCRIPCION: Listar concepto precio por prefijo
            List<CENConcepto> lConceptoPrecio;

            CADPrecio CADPrecio = new CADPrecio();
            lConceptoPrecio = CADPrecio.ListarConceptoPrecio(prefijo);

            return lConceptoPrecio;

        }

        public DataTable ObtenerDataTableReporte(List<CENCPrecio> listaCabecera)
        {
            //DESCRIPCION: OBTENER DATA TABLE
            List<CENConcepto> listaConcepto;

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            StringWriter sw = new StringWriter(sb);

            //LLENAR CABECERAS ESTATICAS (DESCRIPCION)
            System.Data.DataTable dt = new System.Data.DataTable();

            dt.Columns.Add("Codigo Producto");
            dt.Columns.Add("Categoria");
            dt.Columns.Add("Subcategoria");
            dt.Columns.Add("Fabricante");
            dt.Columns.Add("Descripcion");
            dt.Columns.Add("Precio Costo");

            //LLENAR CABECERAS DINAMICAS (DESCRIPCION) - SE OBTIENE SÓLO LOS VALORES DEL PRECIO VENTA "NO DEL PRECIO COSTO"
            listaConcepto = descripcionConceptoPrecio();
            for (int i = 0; i < listaConcepto.Count; i++)
            {
                dt.Columns.Add(listaConcepto[i].descripcion);
            }

            //CARGAR DATA EN DATA TABLE
            foreach (CENCPrecio c in listaCabecera)
            {
                // CREAR NUEVA FILA
                System.Data.DataRow dr = dt.NewRow();
                dr["CODIGO PRODUCTO"] = c.CodProducto;
                dr["CATEGORIA"] = c.DescCategoria;
                dr["SUBCATEGORIA"] = c.DescSubcategoria;
                dr["FABRICANTE"] = c.DescFabricante;
                dr["DESCRIPCION"] = c.Descripcion;

                int i = 5; //Indice a partir de donde se van Obtener las Columnas Dinamicas

                // find the friends and mark them
                foreach (CENDPrecio d in c.Ldprecios)
                {
                    string columna = dt.Columns[i].ToString();
                    dr[columna] = d.PrecioVenta;
                    i++;
                }

                dt.Rows.Add(dr);
            }

            return dt;

        }

        public int validarCodigoProducto(string codigoProducto)
        {
            //DESCRIPCION: Validar exitencia de codigo de producto
            int cantidad;
            try
            {
                CADPrecio CADPrecio = new CADPrecio();
                cantidad = CADPrecio.validarCodigoProducto(codigoProducto);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return cantidad;

        }

        public string obtenerDescripcionConcepto(int flag, int prefijo, int correlativo)
        {
            //DESCRIPCION:Obtener descripcion concepto por correlativo
            String mensaje;
            CADCliente CADCliente = new CADCliente();

            try
            {
                mensaje = CADCliente.SeleccionarConcepto(flag, prefijo, correlativo);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return mensaje;
        }

        public List<CENFactDistribPrecio> listar_tipo_precio_parametrizado()
        {
            try
            {
                CADPrecio cadPrecio = new CADPrecio();
                List<CENFactDistribPrecio> lTipoPrecioParametrizados;

                lTipoPrecioParametrizados = cadPrecio.listar_tipo_precio_parametrizado();

                return lTipoPrecioParametrizados;
            }
            catch (Exception)
            {

                throw;
            }

        }




    }
}

