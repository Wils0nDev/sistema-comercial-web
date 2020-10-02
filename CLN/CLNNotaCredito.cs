using CAD;
using CEN;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CLN
{
    public class CLNNotaCredito
    {
        public List<CENPreventaCliente> buscarCliente(string cadena)
        {
            CADPreventa cadPreventa = new CADPreventa();
            List<CENPreventaCliente> lista = null;
            try
            {
                lista = cadPreventa.buscarCliente(cadena);
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return lista;
        }

        public List<CENNotaCreditoVenta> buscarVentas(CENNotaCreditoParametroBuscarVenta parametros)
        {
            CADNotaCredito cadNotaCredito = new CADNotaCredito();
            List<CENNotaCreditoVenta> lista = null;
            try
            {
                lista = cadNotaCredito.buscarVentas(parametros);
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return lista;
        }

        public CENNotaCreditoDatosVenta obtenerVenta(int codigo)
        {
            CADNotaCredito cadNotaCredito = new CADNotaCredito();
            CENNotaCreditoDatosVenta obj = null;
            try
            {
                obj = cadNotaCredito.obtenerVenta(codigo);
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return obj;
        }

        public List<CENNotaCreditoDatosDetalleVenta> obtenerDetalleVenta(int codigo)
        {
            CADNotaCredito cadNotaCredito = new CADNotaCredito();
            List<CENNotaCreditoDatosDetalleVenta> lista = null;
            try
            {
                lista = cadNotaCredito.obtenerDetalleVenta(codigo);
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return lista;
        }

        public List<CENNotaCreditoMotivoNC> obtenerMotivosNC()
        {
            CADNotaCredito cadNotaCredito = new CADNotaCredito();
            List<CENNotaCreditoMotivoNC> lista = null;
            try
            {
                lista = cadNotaCredito.obtenerMotivosNC();
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return lista;
        }

        public List<CENNotaCreditoVentaPromocion> obtenerVentaPromocion(int codigo)
        {
            CADNotaCredito cadNotaCredito = new CADNotaCredito();
            List<CENNotaCreditoVentaPromocion> lista = null;
            try
            {
                lista = cadNotaCredito.obtenerVentaPromocion(codigo);
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return lista;
        }

        public List<CENNotaCreditoVentaDescuento> obtenerVentaDescuento(int codigo)
        {
            CADNotaCredito cadNotaCredito = new CADNotaCredito();
            List<CENNotaCreditoVentaDescuento> lista = null;
            try
            {
                lista = cadNotaCredito.obtenerVentaDescuento(codigo);
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return lista;
        }

        public CENNotaCreditoDatosPromocion obtenerValoresPromocion(int codigo)
        {
            CADNotaCredito cadNotaCredito = new CADNotaCredito();
            CENNotaCreditoDatosPromocion obj = null;
            try
            {
                obj = cadNotaCredito.obtenerValoresPromocion(codigo);
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return obj;
        }

        public CENNotaCreditoDatosDescuento obtenerValoresDescuento(int codigo)
        {
            CADNotaCredito cadNotaCredito = new CADNotaCredito();
            CENNotaCreditoDatosDescuento obj = null;
            try
            {
                obj = cadNotaCredito.obtenerValoresDescuento(codigo);
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return obj;
        }

        public CENNotaCreditoRptaRegistroNC registrarNC(CENNotaCredito nc)
        {
            CADNotaCredito cadNotaCredito = new CADNotaCredito();
            CENNotaCreditoRptaRegistroNC obj = null;
            int ntraVN = 0;
            try
            {
                ntraVN = cadNotaCredito.registrarVentaN(nc);

                obj = cadNotaCredito.registrarNotaCredito(nc, ntraVN);
                enviarNCSunat(nc.codVenta, obj.ntraNC, ntraVN, nc.tipo, nc.usuario, nc.ip, nc.mac);
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return obj;
        }

        public byte[] generarNotaCreditoPDF(int codNotaCredito)
        {
            CADNotaCredito cadNotaCredito = new CADNotaCredito();
            CLNFormatos objCLNFormatos = new CLNFormatos();
            CENNotaCreditoCabeceraImpresion obj;
            byte[] pdfbytes = null;
            MemoryStream ms = null;

            try
            {
                //obtener data a mostrar
                obj = cadNotaCredito.obtenerDatosCabeceraNC(codNotaCredito);
                obj.listaDetalle = cadNotaCredito.obtenerDatosDetalleNC(codNotaCredito);

                if (obj != null)
                {
                    ms = new MemoryStream();
                    //Color de fuentes
                    var CPrincipal = new BaseColor(CENConstante.g_const_1, CENConstante.g_const_108, CENConstante.g_const_179);//color tema principal tonalidad azul
                    var CSecundario = new BaseColor(CENConstante.g_const_128, CENConstante.g_const_128, CENConstante.g_const_128);//color gris
                    var CGenerico = new BaseColor(CENConstante.g_const_0, CENConstante.g_const_0, CENConstante.g_const_0);//color negro
                    var CBlanco = new BaseColor(CENConstante.g_const_255, CENConstante.g_const_255, CENConstante.g_const_255);//color blanco

                    Document doc = new Document(PageSize.A4, CENConstante.g_const_30, CENConstante.g_const_30, CENConstante.g_const_30, CENConstante.g_const_30);
                    PdfWriter pw = PdfWriter.GetInstance(doc, ms);
                    doc.Open();

                    Font ftitulo1 = new Font(Font.FontFamily.HELVETICA, CENConstante.g_const_14, Font.BOLD, CPrincipal);
                    Font ftitulo2 = new Font(Font.FontFamily.HELVETICA, CENConstante.g_const_11, Font.BOLD, CPrincipal);
                    Font flabel = new Font(Font.FontFamily.HELVETICA, CENConstante.g_const_11, Font.BOLD, CSecundario);
                    Font flabe2 = new Font(Font.FontFamily.HELVETICA, CENConstante.g_const_11, Font.BOLD, CGenerico);
                    Font flabe3 = new Font(Font.FontFamily.HELVETICA, CENConstante.g_const_11, Font.NORMAL, CPrincipal);
                    Font fsec10n = new Font(Font.FontFamily.HELVETICA, CENConstante.g_const_10, Font.BOLD, CSecundario);
                    Font fsec10 = new Font(Font.FontFamily.HELVETICA, CENConstante.g_const_10, Font.NORMAL, CSecundario);
                    Font fcampo1 = new Font(Font.FontFamily.HELVETICA, CENConstante.g_const_11, Font.NORMAL, CSecundario);
                    Font fcampo2 = new Font(Font.FontFamily.HELVETICA, CENConstante.g_const_11, Font.NORMAL, CGenerico);

                    Paragraph nuevaLinea = new Paragraph(Chunk.NEWLINE);

                    //TITULO
                    Paragraph titulo = new Paragraph();
                    titulo.Add(new Phrase(CENConstante.g_campo_nombEmpresa, ftitulo1));
                    titulo.Alignment = Element.ALIGN_CENTER;
                    doc.Add(titulo);

                    string RutaBase = HttpContext.Current.Server.MapPath(CENConstante.g_const_tilde) + CENConstante.g_const_pathImg + CENConstante.g_const_pathLogo;
                    Image ImagenPDF = Image.GetInstance(RutaBase);
                    ImagenPDF.ScalePercent(20f);
                    ImagenPDF.SetAbsolutePosition(50, 710);
                    doc.Add(ImagenPDF);

                    //DATOS DE LA DISTRIBUIDORA
                    PdfPTable tabla1 = new PdfPTable(CENConstante.g_const_4);
                    tabla1.WidthPercentage = CENConstante.g_cons100f;
                    float[] widths_cabecera = new float[] { CENConstante.g_cons25f, CENConstante.g_cons25f, CENConstante.g_cons20f, CENConstante.g_cons30f };
                    tabla1.SetWidths(widths_cabecera);
                    tabla1.DefaultCell.Border = Rectangle.NO_BORDER;
                    tabla1.SpacingBefore = CENConstante.g_cons20f;
                    tabla1.SpacingAfter = CENConstante.g_cons20f;

                    PdfPCell clFila10 = new PdfPCell(new Phrase(CENConstante.g_const_vacio, ftitulo2));
                    clFila10.Border = CENConstante.g_const_0;
                    PdfPCell clFila11 = new PdfPCell(new Phrase(CENConstante.g_campo_avenida, ftitulo2));
                    clFila11.Border = CENConstante.g_const_0;
                    clFila11.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    PdfPCell clFila12 = new PdfPCell(new Phrase("", ftitulo2));
                    clFila12.Border = CENConstante.g_const_0;
                    clFila12.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                    PdfPCell clFila13 = new PdfPCell(new Phrase("NOTA DE CREDITO", ftitulo2));
                    clFila13.Border = CENConstante.g_const_0;
                    clFila13.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;

                    PdfPCell clFila20 = new PdfPCell(new Phrase(CENConstante.g_const_vacio, ftitulo2));
                    clFila20.Border = CENConstante.g_const_0;
                    PdfPCell clFila21 = new PdfPCell(new Phrase(CENConstante.g_campo_urbanizacion, ftitulo2));
                    clFila21.Border = CENConstante.g_const_0;
                    clFila21.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    PdfPCell clFila22 = new PdfPCell(new Phrase("", ftitulo2));
                    clFila22.Border = CENConstante.g_const_0;
                    clFila22.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                    PdfPCell clFila23 = new PdfPCell(new Phrase(obj.serieNC + " - " + obj.numeroNC, ftitulo2));
                    clFila23.Border = CENConstante.g_const_0;
                    clFila23.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;

                    PdfPCell clFila30 = new PdfPCell(new Phrase(CENConstante.g_const_vacio, ftitulo2));
                    clFila30.Border = CENConstante.g_const_0;
                    PdfPCell clFila31 = new PdfPCell(new Phrase(CENConstante.g_campo_chiclayo, ftitulo2));
                    clFila31.Border = CENConstante.g_const_0;
                    clFila31.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    PdfPCell clFila32 = new PdfPCell(new Phrase("", ftitulo2));
                    clFila32.Border = CENConstante.g_const_0;
                    clFila32.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                    PdfPCell clFila33 = new PdfPCell(new Phrase("", ftitulo2));
                    clFila33.Border = CENConstante.g_const_0;
                    clFila33.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;

                    PdfPCell clFila40 = new PdfPCell(new Phrase(CENConstante.g_const_vacio, ftitulo2));
                    clFila40.Border = CENConstante.g_const_0;
                    PdfPCell clFila41 = new PdfPCell(new Phrase("", ftitulo2));
                    clFila41.Border = CENConstante.g_const_0;
                    clFila41.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    PdfPCell clFila42 = new PdfPCell(new Phrase("", ftitulo2));
                    clFila42.Border = CENConstante.g_const_0;
                    clFila42.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                    PdfPCell clFila43 = new PdfPCell(new Phrase(obj.fechaNC, ftitulo2));
                    clFila43.Border = CENConstante.g_const_0;
                    clFila43.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;

                    tabla1.AddCell(clFila10);
                    tabla1.AddCell(clFila11);
                    tabla1.AddCell(clFila12);
                    tabla1.AddCell(clFila13);
                    tabla1.AddCell(clFila20);
                    tabla1.AddCell(clFila21);
                    tabla1.AddCell(clFila22);
                    tabla1.AddCell(clFila23);
                    tabla1.AddCell(clFila30);
                    tabla1.AddCell(clFila31);
                    tabla1.AddCell(clFila32);
                    tabla1.AddCell(clFila33);
                    tabla1.AddCell(clFila40);
                    tabla1.AddCell(clFila41);
                    tabla1.AddCell(clFila42);
                    tabla1.AddCell(clFila43);
                    doc.Add(tabla1);

                    //DATOS NC
                    titulo = null;
                    titulo = new Paragraph(CENConstante.g_campo_datosGen, ftitulo2);
                    doc.Add(titulo);

                    PdfPTable tabla2 = new PdfPTable(CENConstante.g_const_4);
                    tabla2.WidthPercentage = CENConstante.g_cons100f;
                    widths_cabecera = null;
                    widths_cabecera = new float[] { CENConstante.g_cons17f, CENConstante.g_cons43f, CENConstante.g_cons10f, CENConstante.g_cons30f };
                    tabla2.SetWidths(widths_cabecera);
                    tabla2.DefaultCell.Border = Rectangle.NO_BORDER;
                    tabla2.SpacingBefore = CENConstante.g_cons10f;

                    PdfPCell cl2Fila11 = new PdfPCell(new Phrase("CLIENTE:", fsec10n));
                    cl2Fila11.Border = CENConstante.g_const_0;
                    cl2Fila11.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    PdfPCell cl2Fila12 = new PdfPCell(new Phrase(obj.nombreC, fsec10));
                    cl2Fila12.Border = CENConstante.g_const_0;
                    cl2Fila12.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    PdfPCell cl2Fila13 = new PdfPCell(new Phrase("", fsec10n));
                    cl2Fila13.Border = CENConstante.g_const_0;
                    cl2Fila13.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    PdfPCell cl2Fila14 = new PdfPCell(new Phrase("", fsec10));
                    cl2Fila14.Border = CENConstante.g_const_0;
                    cl2Fila14.HorizontalAlignment = PdfPCell.ALIGN_LEFT;

                    PdfPCell cl2Fila21 = new PdfPCell(new Phrase("N°DOCUMENTO:", fsec10n));
                    cl2Fila21.Border = CENConstante.g_const_0;
                    cl2Fila21.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    PdfPCell cl2Fila22 = new PdfPCell(new Phrase(obj.nroDocumentoC, fsec10));
                    cl2Fila22.Border = CENConstante.g_const_0;
                    cl2Fila22.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    PdfPCell cl2Fila23 = new PdfPCell(new Phrase("APLICA:", fsec10n));
                    cl2Fila23.Border = CENConstante.g_const_0;
                    cl2Fila23.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    PdfPCell cl2Fila24 = new PdfPCell(new Phrase(obj.serieV + " - " + obj.numeroV, fsec10));
                    cl2Fila24.Border = CENConstante.g_const_0;
                    cl2Fila24.HorizontalAlignment = PdfPCell.ALIGN_LEFT;

                    PdfPCell cl2Fila31 = new PdfPCell(new Phrase("TIPO:", fsec10n));
                    cl2Fila31.Border = CENConstante.g_const_0;
                    cl2Fila31.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    PdfPCell cl2Fila32 = new PdfPCell(new Phrase(obj.tipoNC, fsec10));
                    cl2Fila32.Border = CENConstante.g_const_0;
                    cl2Fila32.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    PdfPCell cl2Fila33 = new PdfPCell(new Phrase("MOTIVO:", fsec10n));
                    cl2Fila33.Border = CENConstante.g_const_0;
                    cl2Fila33.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    PdfPCell cl2Fila34 = new PdfPCell(new Phrase(obj.motivoNC, fsec10));
                    cl2Fila34.Border = CENConstante.g_const_0;
                    cl2Fila34.HorizontalAlignment = PdfPCell.ALIGN_LEFT;

                    tabla2.AddCell(cl2Fila11);
                    tabla2.AddCell(cl2Fila12);
                    tabla2.AddCell(cl2Fila13);
                    tabla2.AddCell(cl2Fila14);
                    tabla2.AddCell(cl2Fila21);
                    tabla2.AddCell(cl2Fila22);
                    tabla2.AddCell(cl2Fila23);
                    tabla2.AddCell(cl2Fila24);
                    tabla2.AddCell(cl2Fila31);
                    tabla2.AddCell(cl2Fila32);
                    tabla2.AddCell(cl2Fila33);
                    tabla2.AddCell(cl2Fila34);
                    doc.Add(tabla2);

                    doc.Add(nuevaLinea);
                    //DETALLE PRODUCTOS
                    titulo = null;
                    titulo = new Paragraph(CENConstante.g_campo_detaProd, ftitulo2);
                    doc.Add(titulo);

                    //CABECERA TITULOS
                    PdfPTable tabla4 = new PdfPTable(CENConstante.g_const_9);
                    tabla4.HeaderRows = CENConstante.g_const_1;
                    tabla4.WidthPercentage = CENConstante.g_cons100f;
                    widths_cabecera = null;
                    widths_cabecera = new float[] { CENConstante.g_cons5f, CENConstante.g_cons10f, CENConstante.g_cons15f, CENConstante.g_cons10f, CENConstante.g_cons10f, CENConstante.g_cons10f, CENConstante.g_cons10f, CENConstante.g_cons10f, CENConstante.g_cons10f };
                    tabla4.SetWidths(widths_cabecera);
                    tabla4.DefaultCell.Border = Rectangle.NO_BORDER;
                    tabla4.SpacingBefore = CENConstante.g_cons10f;
                    tabla4.SpacingAfter = CENConstante.g_cons20f;
                    PdfPCell cl4Fila11 = new PdfPCell();
                    cl4Fila11 = objCLNFormatos.FormatearCeldaTexto(CENConstante.g_campo_tblnumeral, CENConstante.consARIAL, CENConstante.g_const_8, CENConstante.g_const_1, CENConstante.g_cons075f, CENConstante.g_cons35f, CPrincipal, CBlanco, CPrincipal, CPrincipal, CPrincipal, CBlanco, CENConstante.g_const_1);
                    PdfPCell cl4Fila12 = new PdfPCell();
                    cl4Fila12 = objCLNFormatos.FormatearCeldaTexto(CENConstante.g_campo_tblsku, CENConstante.consARIAL, CENConstante.g_const_8, CENConstante.g_const_1, CENConstante.g_cons075f, CENConstante.g_cons35f, CPrincipal, CBlanco, CPrincipal, CPrincipal, CPrincipal, CBlanco, CENConstante.g_const_1);
                    PdfPCell cl4Fila13 = new PdfPCell();
                    cl4Fila13 = objCLNFormatos.FormatearCeldaTexto(CENConstante.g_campo_tbldescrip, CENConstante.consARIAL, CENConstante.g_const_8, CENConstante.g_const_1, CENConstante.g_cons075f, CENConstante.g_cons35f, CPrincipal, CBlanco, CPrincipal, CPrincipal, CPrincipal, CBlanco, CENConstante.g_const_1);
                    PdfPCell cl4Fila14 = new PdfPCell();
                    cl4Fila14 = objCLNFormatos.FormatearCeldaTexto(CENConstante.g_campo_tblcant, CENConstante.consARIAL, CENConstante.g_const_8, CENConstante.g_const_1, CENConstante.g_cons075f, CENConstante.g_cons35f, CPrincipal, CBlanco, CPrincipal, CPrincipal, CPrincipal, CBlanco, CENConstante.g_const_1);
                    PdfPCell cl4Fila15 = new PdfPCell();
                    cl4Fila15 = objCLNFormatos.FormatearCeldaTexto(CENConstante.g_campo_tblUm, CENConstante.consARIAL, CENConstante.g_const_8, CENConstante.g_const_1, CENConstante.g_cons075f, CENConstante.g_cons35f, CPrincipal, CBlanco, CPrincipal, CPrincipal, CPrincipal, CBlanco, CENConstante.g_const_1);
                    PdfPCell cl4Fila16 = new PdfPCell();
                    cl4Fila16 = objCLNFormatos.FormatearCeldaTexto(CENConstante.g_campo_tblprecio, CENConstante.consARIAL, CENConstante.g_const_8, CENConstante.g_const_1, CENConstante.g_cons075f, CENConstante.g_cons35f, CPrincipal, CBlanco, CPrincipal, CPrincipal, CPrincipal, CBlanco, CENConstante.g_const_1);
                    PdfPCell cl4Fila17 = new PdfPCell();
                    cl4Fila17 = objCLNFormatos.FormatearCeldaTexto(CENConstante.g_campo_tbldesc, CENConstante.consARIAL, CENConstante.g_const_8, CENConstante.g_const_1, CENConstante.g_cons075f, CENConstante.g_cons35f, CPrincipal, CBlanco, CPrincipal, CPrincipal, CPrincipal, CBlanco, CENConstante.g_const_1);
                    PdfPCell cl4Fila18 = new PdfPCell();
                    cl4Fila18 = objCLNFormatos.FormatearCeldaTexto(CENConstante.g_campo_tbltipo, CENConstante.consARIAL, CENConstante.g_const_8, CENConstante.g_const_1, CENConstante.g_cons075f, CENConstante.g_cons35f, CPrincipal, CBlanco, CPrincipal, CPrincipal, CPrincipal, CBlanco, CENConstante.g_const_1);
                    PdfPCell cl4Fila19 = new PdfPCell();
                    cl4Fila19 = objCLNFormatos.FormatearCeldaTexto(CENConstante.g_campo_tblimporte, CENConstante.consARIAL, CENConstante.g_const_8, CENConstante.g_const_1, CENConstante.g_cons075f, CENConstante.g_cons35f, CPrincipal, CBlanco, CPrincipal, CPrincipal, CPrincipal, CBlanco, CENConstante.g_const_1);
                    tabla4.AddCell(cl4Fila11);
                    tabla4.AddCell(cl4Fila12);
                    tabla4.AddCell(cl4Fila13);
                    tabla4.AddCell(cl4Fila14);
                    tabla4.AddCell(cl4Fila15);
                    tabla4.AddCell(cl4Fila16);
                    tabla4.AddCell(cl4Fila17);
                    tabla4.AddCell(cl4Fila18);
                    tabla4.AddCell(cl4Fila19);

                    //PRODUCTOS
                    int posicion = CENConstante.g_const_0;
                    foreach (CENNotaCreditoDetalleImpresion data in obj.listaDetalle)
                    {
                        posicion = posicion + CENConstante.g_const_1;
                        cl4Fila11 = new PdfPCell();
                        cl4Fila12 = new PdfPCell();
                        cl4Fila13 = new PdfPCell();
                        cl4Fila14 = new PdfPCell();
                        cl4Fila15 = new PdfPCell();
                        cl4Fila16 = new PdfPCell();
                        cl4Fila17 = new PdfPCell();
                        cl4Fila18 = new PdfPCell();
                        cl4Fila19 = new PdfPCell();

                        cl4Fila11 = objCLNFormatos.FormatearCeldaTexto(posicion.ToString(), CENConstante.consARIAL, CENConstante.g_const_8, CENConstante.g_const_1, CENConstante.g_cons075f, CENConstante.g_cons20f, CBlanco, CSecundario, CBlanco, CBlanco, CBlanco, CBlanco, CENConstante.g_const_1);
                        cl4Fila12 = objCLNFormatos.FormatearCeldaTexto(data.codProducto, CENConstante.consARIAL, CENConstante.g_const_8, CENConstante.g_const_1, CENConstante.g_cons075f, CENConstante.g_cons20f, CBlanco, CSecundario, CBlanco, CBlanco, CBlanco, CBlanco, CENConstante.g_const_1);
                        cl4Fila13 = objCLNFormatos.FormatearCeldaTexto(data.descProducto, CENConstante.consARIAL, CENConstante.g_const_8, CENConstante.g_const_1, CENConstante.g_cons075f, CENConstante.g_cons20f, CBlanco, CSecundario, CBlanco, CBlanco, CBlanco, CBlanco, CENConstante.g_const_3);
                        cl4Fila14 = objCLNFormatos.FormatearCeldaTexto(data.cantidad.ToString(), CENConstante.consARIAL, CENConstante.g_const_8, CENConstante.g_const_1, CENConstante.g_cons075f, CENConstante.g_cons20f, CBlanco, CSecundario, CBlanco, CBlanco, CBlanco, CBlanco, CENConstante.g_const_1);
                        cl4Fila15 = objCLNFormatos.FormatearCeldaTexto(data.descUnidad, CENConstante.consARIAL, CENConstante.g_const_8, CENConstante.g_const_1, CENConstante.g_cons075f, CENConstante.g_cons20f, CBlanco, CSecundario, CBlanco, CBlanco, CBlanco, CBlanco, CENConstante.g_const_1);
                        cl4Fila16 = objCLNFormatos.FormatearCeldaTexto(FormatoDecimal(data.precioVenta), CENConstante.consARIAL, CENConstante.g_const_8, CENConstante.g_const_1, CENConstante.g_cons075f, CENConstante.g_cons20f, CBlanco, CSecundario, CBlanco, CBlanco, CBlanco, CBlanco, CENConstante.g_const_2);
                        cl4Fila17 = objCLNFormatos.FormatearCeldaTexto(FormatoDecimal(0), CENConstante.consARIAL, CENConstante.g_const_8, CENConstante.g_const_1, CENConstante.g_cons075f, CENConstante.g_cons20f, CBlanco, CSecundario, CBlanco, CBlanco, CBlanco, CBlanco, CENConstante.g_const_2);
                        cl4Fila18 = objCLNFormatos.FormatearCeldaTexto(data.descTipoProducto, CENConstante.consARIAL, CENConstante.g_const_8, CENConstante.g_const_1, CENConstante.g_cons075f, CENConstante.g_cons20f, CBlanco, CSecundario, CBlanco, CBlanco, CBlanco, CBlanco, CENConstante.g_const_3);
                        cl4Fila19 = objCLNFormatos.FormatearCeldaTexto(FormatoDecimal(data.subTotal), CENConstante.consARIAL, CENConstante.g_const_8, CENConstante.g_const_1, CENConstante.g_cons075f, CENConstante.g_cons20f, CBlanco, CSecundario, CBlanco, CBlanco, CBlanco, CBlanco, CENConstante.g_const_2);
                        tabla4.AddCell(cl4Fila11);
                        tabla4.AddCell(cl4Fila12);
                        tabla4.AddCell(cl4Fila13);
                        tabla4.AddCell(cl4Fila14);
                        tabla4.AddCell(cl4Fila15);
                        tabla4.AddCell(cl4Fila16);
                        tabla4.AddCell(cl4Fila17);
                        tabla4.AddCell(cl4Fila18);
                        tabla4.AddCell(cl4Fila19);
                    }
                    doc.Add(tabla4);
                    doc.Add(nuevaLinea);

                    //TOTALES
                    //Tabla de los totales
                    PdfPTable tabla5 = new PdfPTable(CENConstante.g_const_2);
                    tabla5.WidthPercentage = CENConstante.g_cons100f;
                    widths_cabecera = null;
                    widths_cabecera = new float[] { CENConstante.g_cons90f, CENConstante.g_cons10f };
                    tabla5.SetWidths(widths_cabecera);
                    tabla5.DefaultCell.Border = Rectangle.NO_BORDER;
                    tabla5.SpacingAfter = CENConstante.g_cons10f;

                    PdfPCell cl5Fila11 = new PdfPCell(new Phrase(CENConstante.g_campo_subtotal, fsec10n));
                    cl5Fila11.Border = CENConstante.g_const_0;
                    cl5Fila11.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                    PdfPCell cl5Fila12 = new PdfPCell(new Phrase(FormatoDecimal(obj.importeSubTotalV), fsec10));
                    cl5Fila12.Border = CENConstante.g_const_0;
                    cl5Fila12.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                    PdfPCell cl5Fila21 = new PdfPCell(new Phrase(CENConstante.g_campo_descTotal, fsec10n));
                    cl5Fila21.Border = CENConstante.g_const_0;
                    cl5Fila21.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                    PdfPCell cl5Fila22 = new PdfPCell(new Phrase(FormatoDecimal(0), fsec10));
                    cl5Fila22.Border = CENConstante.g_const_0;
                    cl5Fila22.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                    /*PdfPCell cl5Fila21 = new PdfPCell(new Phrase(CENConstante.g_campo_recargo, fsec10n));
                    cl5Fila21.Border = CENConstante.g_const_0;
                    cl5Fila21.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                    PdfPCell cl5Fila22 = new PdfPCell(new Phrase(FormatoDecimal(dataVenta.importeRecargo), fsec10));
                    cl5Fila22.Border = CENConstante.g_const_0;
                    cl5Fila22.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;*/
                    PdfPCell cl5Fila41 = new PdfPCell(new Phrase(CENConstante.g_campo_igv, fsec10n));
                    cl5Fila41.Border = CENConstante.g_const_0;
                    cl5Fila41.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                    PdfPCell cl5Fila42 = new PdfPCell(new Phrase(FormatoDecimal(obj.importeIgvV), fsec10));
                    cl5Fila42.Border = CENConstante.g_const_0;
                    cl5Fila42.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                    PdfPCell cl5Fila51 = new PdfPCell(new Phrase(CENConstante.g_campo_total, fsec10n));
                    cl5Fila51.Border = CENConstante.g_const_0;
                    cl5Fila51.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                    PdfPCell cl5Fila52 = new PdfPCell(new Phrase(FormatoDecimal(obj.importeTotalV), fsec10));
                    cl5Fila52.Border = CENConstante.g_const_0;
                    cl5Fila52.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                    tabla5.AddCell(cl5Fila11);
                    tabla5.AddCell(cl5Fila12);
                    tabla5.AddCell(cl5Fila21);
                    tabla5.AddCell(cl5Fila22);
                    //tabla5.AddCell(cl5Fila21);
                    //tabla5.AddCell(cl5Fila22);
                    tabla5.AddCell(cl5Fila41);
                    tabla5.AddCell(cl5Fila42);
                    tabla5.AddCell(cl5Fila51);
                    tabla5.AddCell(cl5Fila52);
                    doc.Add(tabla5);

                    doc.Close();
                    pdfbytes = ms.ToArray();
                    ms.Dispose();
                }

                ms = new MemoryStream();
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return pdfbytes;
        }

        public string FormatoDecimal(double monto)
        {
            return string.Format(CENConstante.g_const_formredini + Math.Abs(CENConstante.g_const_2) + CENConstante.g_const_formredfin, monto);

        }

        public CENNotaCreditoRptaValidacion validarVenta(int codigo)
        {
            CADNotaCredito cadNotaCredito = new CADNotaCredito();
            CENNotaCreditoRptaValidacion obj = null;
            try
            {
                obj = cadNotaCredito.validarVenta(codigo);
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return obj;
        }

        public CENNotaCreditoParametrosRpta obtenerParametros(CENNotaCreditoParametros p)
        {
            CADNotaCredito cadNotaCredito = new CADNotaCredito();
            CENNotaCreditoParametrosRpta obj = null;
            try
            {
                obj = cadNotaCredito.obtenerParametros(p);
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return obj;
        }

        public void enviarNCSunat(int codVenta, int codNC, int codVentaN, int tipoNC, string usuario, string ip, string mac)
        {
            CENApiNC obj = null;
            CENLegends legends = null;
            CLNProcesosGenerales pg = new CLNProcesosGenerales();
            CADNotaCredito cadNotaCredito = new CADNotaCredito();
            CADcomprobSunat cadComprob = new CADcomprobSunat();
            CENComprobSunat cenComprob = null;
            ResponseApi responseApi = new ResponseApi();
            int codComprobSunat;
            string DataJSON;
            string DataJSONSalida;
            int flag = CENConstante.g_const_2;
            try
            {
                obj = cadNotaCredito.obtenerDatosSunat(codVenta, codNC, codVentaN);
                legends = new CENLegends();
                legends.code = "1000";
                legends.value = pg.convertirALetras(obj.mtoImpVenta.ToString());
                obj.legends.Add(legends);

                DataJSON = JsonConvert.SerializeObject(obj);

                cenComprob = new CENComprobSunat();
                cenComprob.codTransaccion = codNC;
                cenComprob.codModulo = CENConstante.g_const_1;
                cenComprob.tipDocSunat = CENConstante.g_const_2;
                cenComprob.tipDocVenta = tipoNC;
                cenComprob.tramEntrada = DataJSON;
                cenComprob.tramSalida = CENConstante.g_const_vacio;
                cenComprob.estado = CENConstante.g_const_1;
                cenComprob.usuario = usuario;
                cenComprob.ip = ip;
                cenComprob.mac = mac;

                codComprobSunat = cadComprob.RegistrarComprobSunat(cenComprob);

                responseApi = enviarTramaNCSunat(DataJSON);
                DataJSONSalida = JsonConvert.SerializeObject(responseApi);

                if (responseApi.sunatResponse.success)
                    flag = CENConstante.g_const_1;

                cadComprob.ActualizarComprobSunat(codComprobSunat, DataJSONSalida, flag);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ResponseApi enviarTramaNCSunat(string DataJSON)
        {
            //DESCRIPCIÓN: 
            ResponseApi resp = null;
            try
            {
                string URLWebAPI = "https://facturacion.apisperu.com";

                // Crear un objeto HttpClient para acceder a la Web API
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(URLWebAPI);

                client.DefaultRequestHeaders.Add("Authorization", "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.eyJpYXQiOjE1ODY4MDk5NTEsInVzZXJuYW1lIjoiV2lsbWVyU2FuY2hleiIsImNvbXBhbnkiOiIyMjE2NjU4NTEzOSIsImV4cCI6NDc0MDQwOTk1MX0.iHYvheClIGSY9qkF10b0cTyKlRoPpyHSiVgGGkESIkNr8ryanjX9rYFTPXMfj7rmWb6jnTDXBLEdTphKhMEekW4jc2_XHf3llUiGDeCfpRMIOXa4B83uCuPFnsfAJt-44ifSl3oBZZdS9wvRZ5Lrv6XUrFXlzc667le8wS8DH-nUWMBuYd3ih5yWluMEnvouq_vej9JbJ6I94IVxvB_A88XmYTk2cEO3ifZqS4KgWl0HRy19q-D1n0OvxcO1iR0jjzd4400i7PDY_KyspAqd6tRhdXZKFVSo_xn8fjZ3pIhwAw3ee1_HGLwl7DRbPX0wCrc-iMNPgfa57586oRe8InMRrtKqeSqukDcc3d5FhVeXUKwTxqOHc_vM3E4qOXOp_vqf2m8afY0eXAr0SqVjxYM5csFz_h1CZ4TSnHlEhfOcGk3K6VM2WZKNsOdvnDWUIRf7SgWkdnjC49Cv6pfYFM5_bkUqt-cnyDjBlVP8OozC1vhAA-j6FQFPqWwGmfAlXOfcF2czoaDJZW-bspDeFnuBxAfXKNYnv9E-xAvKsrmBmGor8suc7lgpKGMBzGAzstkApDuzrzJfVZCX7eNzhjZ5xHsNslFrHMC0NWE_TXIemcBlGTfFLRUFpWY2nIPmnFi00zHW9g6nVIbdjAYH6_DD5aLGg68SYYOa3kFXfeU");

                // Especificar que estamos aceptando datos JSON
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.
                    MediaTypeWithQualityHeaderValue(CENConstante.g_const_apliJSON));

                // Obtener un tipo HttpContent para pasarlo en la petición 
                StringContent Content = new StringContent(DataJSON,
                    System.Text.Encoding.UTF8, CENConstante.g_const_apliJSON);

                // Realizar la llamada al recurso Web API y obtener la respuesta
                HttpResponseMessage response = client.PostAsync(
                "/api/v1/note/send", Content).Result;

                //convertimos a clase el objeto json de salida
                resp = JsonConvert.DeserializeObject<ResponseApi>(
                           response.Content.ReadAsStringAsync().Result);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resp;
        }
    }
}
