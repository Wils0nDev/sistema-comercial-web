using CAD;
using CEN;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CLN
{
    public class CLNVentaPdf
    {
        public byte[] VentaPdf(int codventa)
        {
            CLNVentaPdf clnPDF = new CLNVentaPdf();
            CLN_Venta clnVenta = new CLN_Venta();
            CENVentaFiltroPA dataVenta = new CENVentaFiltroPA();


            CLNFormatos objCLNFormatos = new CLNFormatos();
            CENConstante cons = new CENConstante ();
            CADPreventa objCADPreventa = new CADPreventa();
            List<CENDetallePreventa> listaDetalle = null;
            CENCamposPreventa ubigeo = null;
            MemoryStream ms = null;
            string descUbigeo=CENConstante.g_const_vacio;
            byte[] l_pdfbytes = null;

            try
            {
                dataVenta = clnVenta.listarVentaCodigo(codventa);
                
                //listaDetalle = objCADPreventa.ListarDetalle(codventa);


                ms = new MemoryStream();
                
                if (!String.IsNullOrEmpty(dataVenta.codUbigeo.Trim()))
                {
                    ubigeo = objCADPreventa.obtenerUbigeo(dataVenta.codUbigeo.Trim());
                    descUbigeo = ubigeo.descripcion;
                }
                

                Document doc = new Document(PageSize.A4, CENConstante.g_const_30, CENConstante.g_const_30, CENConstante.g_const_30, CENConstante.g_const_30);
                PdfWriter pw = PdfWriter.GetInstance(doc, ms);
                doc.Open();

                //Color de fuentes
                var CPrincipal = new BaseColor(CENConstante.g_const_1, CENConstante.g_const_108, CENConstante.g_const_179);//color tema principal tonalidad azul
                var CSecundario = new BaseColor(CENConstante.g_const_128, CENConstante.g_const_128, CENConstante.g_const_128);//color gris
                var CGenerico = new BaseColor(CENConstante.g_const_0, CENConstante.g_const_0, CENConstante.g_const_0);//color negro
                var CBlanco = new BaseColor(CENConstante.g_const_255, CENConstante.g_const_255, CENConstante.g_const_255);//color blanco
                //fuentes
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
                //ImagenPDF.ScaleToFit(125f, 60F);
                ImagenPDF.SetAbsolutePosition(50, 710);
                doc.Add(ImagenPDF);

                //DATOS DE LA DISTRIBUIDORA
                PdfPTable tabla1 = new PdfPTable(CENConstante.g_const_4);
                tabla1.WidthPercentage = CENConstante.g_cons100f;
                //tabla1.TotalWidth = 600f;
                float[] widths_cabecera = new float[] { CENConstante.g_cons25f, CENConstante.g_cons25f, CENConstante.g_cons20f, CENConstante.g_cons30f };
                tabla1.SetWidths(widths_cabecera);
                tabla1.DefaultCell.Border = Rectangle.NO_BORDER;
                tabla1.SpacingBefore = CENConstante.g_cons20f;
                tabla1.SpacingAfter = CENConstante.g_cons20f;

                PdfPCell clFila10 = new PdfPCell(new Phrase(CENConstante.g_const_vacio, ftitulo2));
                clFila10.Border = CENConstante.g_const_0;
                PdfPCell clFila11 = new PdfPCell(new Phrase(CENConstante.g_campo_avenida, ftitulo2));
                //clFila11.BorderWidth = 0.75f;
                //clFila11.FixedHeight = 10f;
                clFila11.Border = CENConstante.g_const_0;
                clFila11.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                //PdfPCell clFila12 = new PdfPCell(new Phrase(CENConstante.g_campo_sucursal, ftitulo2));
                PdfPCell clFila12 = new PdfPCell(new Phrase("", ftitulo2));
                //clFila12.BorderWidth = 0.75f;
                //clFila12.FixedHeight = 0f;
                clFila12.Border = CENConstante.g_const_0;
                clFila12.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                //PdfPCell clFila13 = new PdfPCell(new Phrase(datosPre.sucursal, ftitulo2));
                PdfPCell clFila13 = new PdfPCell(new Phrase("", ftitulo2));
                //clFila13.BorderWidth = 0.75f;
                //clFila13.FixedHeight = 0f;
                clFila13.Border = CENConstante.g_const_0;
                clFila13.HorizontalAlignment = PdfPCell.ALIGN_LEFT;

                PdfPCell clFila20 = new PdfPCell(new Phrase(CENConstante.g_const_vacio, ftitulo2));
                clFila20.Border = CENConstante.g_const_0;
                PdfPCell clFila21 = new PdfPCell(new Phrase(CENConstante.g_campo_urbanizacion, ftitulo2));
                clFila21.Border = CENConstante.g_const_0;
                clFila21.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                //PdfPCell clFila22 = new PdfPCell(new Phrase(CENConstante.g_campo_ruc, ftitulo2));
                PdfPCell clFila22 = new PdfPCell(new Phrase("", ftitulo2));
                clFila22.Border = CENConstante.g_const_0;
                clFila22.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                PdfPCell clFila23 = new PdfPCell(new Phrase("10773880579", ftitulo2));
                clFila23.Border = CENConstante.g_const_0;
                clFila23.HorizontalAlignment = PdfPCell.ALIGN_LEFT;

                PdfPCell clFila30 = new PdfPCell(new Phrase(CENConstante.g_const_vacio, ftitulo2));
                clFila30.Border = CENConstante.g_const_0;
                PdfPCell clFila31 = new PdfPCell(new Phrase(CENConstante.g_campo_chiclayo, ftitulo2));
                clFila31.Border = CENConstante.g_const_0;
                clFila31.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                //PdfPCell clFila32 = new PdfPCell(new Phrase(CENConstante.g_campo_telefono, ftitulo2));
                PdfPCell clFila32 = new PdfPCell(new Phrase("", ftitulo2));
                //dataVenta.tDoc
                clFila32.Border = CENConstante.g_const_0;
                clFila32.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                PdfPCell clFila33 = new PdfPCell(new Phrase(dataVenta.tDoc, ftitulo2));
                clFila33.Border = CENConstante.g_const_0;
                clFila33.HorizontalAlignment = PdfPCell.ALIGN_LEFT;

                PdfPCell clFila40 = new PdfPCell(new Phrase(CENConstante.g_const_vacio, ftitulo2));
                clFila40.Border = CENConstante.g_const_0;
                PdfPCell clFila41 = new PdfPCell(new Phrase("", ftitulo2));
                clFila41.Border = CENConstante.g_const_0;
                clFila41.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                //PdfPCell clFila42 = new PdfPCell(new Phrase(CENConstante.g_campo_correo, ftitulo2));
                PdfPCell clFila42 = new PdfPCell(new Phrase("", ftitulo2));
                clFila42.Border = CENConstante.g_const_0;
                clFila42.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                PdfPCell clFila43 = new PdfPCell(new Phrase(dataVenta.serie + " - " + dataVenta.nroDocumentoCadena, ftitulo2));
                clFila43.Border = CENConstante.g_const_0;
                clFila43.HorizontalAlignment = PdfPCell.ALIGN_LEFT;

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



                //Datos generales
                double subtotalPre = (dataVenta.importeTotal - dataVenta.IGV);// - dataVenta.importeRecargo;
                Paragraph titulo2 = new Paragraph(CENConstante.g_campo_datosGen, ftitulo2);
                PdfPTable tabla2 = new PdfPTable(CENConstante.g_const_2);
                tabla2.WidthPercentage = CENConstante.g_cons100f;
                float[] widths_dato1 = new float[] { CENConstante.g_cons25f, CENConstante.g_cons75f };
                tabla2.SetWidths(widths_dato1);
                tabla2.DefaultCell.Border = Rectangle.NO_BORDER;
                tabla2.SpacingBefore = CENConstante.g_cons10f;
                PdfPCell cl2Fila11 = new PdfPCell(new Phrase(CENConstante.g_campo_vendedor, fsec10n));
                cl2Fila11.Border = CENConstante.g_const_0;
                cl2Fila11.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                PdfPCell cl2Fila12 = new PdfPCell(new Phrase(dataVenta.vendedor, fsec10));
                cl2Fila12.Border = CENConstante.g_const_0;
                cl2Fila12.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                PdfPCell cl2Fila21 = new PdfPCell(new Phrase(CENConstante.g_campo_cliente, fsec10n));
                cl2Fila21.Border = CENConstante.g_const_0;
                cl2Fila21.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                PdfPCell cl2Fila22 = new PdfPCell(new Phrase(dataVenta.cliente, fsec10));
                cl2Fila22.Border = CENConstante.g_const_0;
                cl2Fila22.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                string ruc_dni = (dataVenta.tipoPersona == 1) ? CENConstante.g_campo_dni : CENConstante.g_campo_ruc;
                PdfPCell cl2Fila31 = new PdfPCell(new Phrase(ruc_dni, fsec10n));
                cl2Fila31.Border = CENConstante.g_const_0;
                cl2Fila31.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                PdfPCell cl2Fila32 = new PdfPCell(new Phrase(dataVenta.identificacion, fsec10));
                cl2Fila32.Border = CENConstante.g_const_0;
                cl2Fila32.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                PdfPCell cl2Fila41 = new PdfPCell(new Phrase(CENConstante.g_campo_ubigeo, fsec10n));
                cl2Fila41.Border = CENConstante.g_const_0;
                cl2Fila41.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                PdfPCell cl2Fila42 = new PdfPCell(new Phrase(descUbigeo, fsec10));
                cl2Fila42.Border = CENConstante.g_const_0;
                cl2Fila42.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                PdfPCell cl2Fila51 = new PdfPCell(new Phrase(CENConstante.g_campo_ruta, fsec10n));
                cl2Fila51.Border = CENConstante.g_const_0;
                cl2Fila51.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                PdfPCell cl2Fila52 = new PdfPCell(new Phrase(dataVenta.ruta, fsec10));
                cl2Fila52.Border = CENConstante.g_const_0;
                cl2Fila52.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                PdfPCell cl2Fila61 = new PdfPCell(new Phrase(CENConstante.g_campo_puntoEnt, fsec10n));
                cl2Fila61.Border = CENConstante.g_const_0;
                cl2Fila61.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                PdfPCell cl2Fila62 = new PdfPCell(new Phrase(dataVenta.direccion, fsec10));
                cl2Fila62.Border = CENConstante.g_const_0;
                cl2Fila62.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                tabla2.AddCell(cl2Fila11);
                tabla2.AddCell(cl2Fila12);
                tabla2.AddCell(cl2Fila21);
                tabla2.AddCell(cl2Fila22);
                tabla2.AddCell(cl2Fila31);
                tabla2.AddCell(cl2Fila32);
                tabla2.AddCell(cl2Fila41);
                tabla2.AddCell(cl2Fila42);
                tabla2.AddCell(cl2Fila51);
                tabla2.AddCell(cl2Fila52);
                tabla2.AddCell(cl2Fila61);
                tabla2.AddCell(cl2Fila62);
                doc.Add(titulo2);
                doc.Add(tabla2);



                
                //Detalle de la preventa
                Paragraph titulo3 = new Paragraph("DETALLE DE LA VENTA", ftitulo2);
                PdfPTable tabla3 = new PdfPTable(CENConstante.g_const_4);
                tabla3.WidthPercentage = CENConstante.g_cons100f;
                float[] widths_dato2 = new float[] { CENConstante.g_cons25f, CENConstante.g_cons25f, CENConstante.g_cons25f, CENConstante.g_cons25f };
                tabla3.SetWidths(widths_dato2);
                tabla3.DefaultCell.Border = Rectangle.NO_BORDER;
                tabla3.SpacingBefore = CENConstante.g_cons10f;
                tabla3.SpacingAfter = CENConstante.g_cons10f;
                PdfPCell cl3Fila11 = new PdfPCell(new Phrase("VENTA", fsec10n));
                cl3Fila11.Border = CENConstante.g_const_0;
                cl3Fila11.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                PdfPCell cl3Fila12 = new PdfPCell(new Phrase(codventa.ToString(), fsec10));
                cl3Fila12.Border = CENConstante.g_const_0;
                cl3Fila12.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                PdfPCell cl3Fila13 = new PdfPCell(new Phrase("FECHA DE PAGO", fsec10n));
                cl3Fila13.Border = CENConstante.g_const_0;
                cl3Fila13.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                PdfPCell cl3Fila14 = new PdfPCell(new Phrase(dataVenta.fechaPago, fsec10));
                cl3Fila14.Border = CENConstante.g_const_0;
                cl3Fila14.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                PdfPCell cl3Fila21 = new PdfPCell(new Phrase(CENConstante.g_campo_tipoVenta, fsec10n));
                cl3Fila21.Border = CENConstante.g_const_0;
                cl3Fila21.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                PdfPCell cl3Fila22 = new PdfPCell(new Phrase(dataVenta.tVenta, fsec10));
                cl3Fila22.Border = CENConstante.g_const_0;
                cl3Fila22.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                PdfPCell cl3Fila23 = new PdfPCell(new Phrase(CENConstante.g_campo_moneda, fsec10n));
                cl3Fila23.Border = CENConstante.g_const_0;
                cl3Fila23.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                PdfPCell cl3Fila24 = new PdfPCell(new Phrase(dataVenta.moneda, fsec10));
                cl3Fila24.Border = CENConstante.g_const_0;
                cl3Fila24.HorizontalAlignment = PdfPCell.ALIGN_LEFT;

                PdfPCell cl3Fila31 = new PdfPCell(new Phrase(CENConstante.g_campo_documento, fsec10n));
                cl3Fila31.Border = CENConstante.g_const_0;
                cl3Fila31.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                PdfPCell cl3Fila32 = new PdfPCell(new Phrase(dataVenta.tDoc, fsec10));
                cl3Fila32.Border = CENConstante.g_const_0;
                cl3Fila32.HorizontalAlignment = PdfPCell.ALIGN_LEFT;


                PdfPCell cl3Fila33 = new PdfPCell(new Phrase(CENConstante.g_campo_estado, fsec10n));
                cl3Fila33.Border = CENConstante.g_const_0;
                cl3Fila33.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                PdfPCell cl3Fila34 = new PdfPCell(new Phrase(dataVenta.estPre, fsec10));
                cl3Fila34.Border = CENConstante.g_const_0;
                cl3Fila34.HorizontalAlignment = PdfPCell.ALIGN_LEFT;


                /*
                PdfPCell cl3Fila41 = new PdfPCell(new Phrase(CENConstante.g_campo_estado, fsec10n));
                cl3Fila41.Border = CENConstante.g_const_0;
                cl3Fila41.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                PdfPCell cl3Fila42 = new PdfPCell(new Phrase(datosPre.estado, fsec10));
                cl3Fila42.Border = CENConstante.g_const_0;
                cl3Fila42.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                PdfPCell cl3Fila43 = new PdfPCell(new Phrase(CENConstante.g_campo_medio, fsec10n));
                cl3Fila43.Border = CENConstante.g_const_0;
                cl3Fila43.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                PdfPCell cl3Fila44 = new PdfPCell(new Phrase(datosPre.Oven, fsec10));
                cl3Fila44.Border = CENConstante.g_const_0;
                cl3Fila44.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                */
                tabla3.AddCell(cl3Fila11);
                tabla3.AddCell(cl3Fila12);
                tabla3.AddCell(cl3Fila13);
                tabla3.AddCell(cl3Fila14);
                tabla3.AddCell(cl3Fila21);
                tabla3.AddCell(cl3Fila22);
                tabla3.AddCell(cl3Fila23);
                tabla3.AddCell(cl3Fila24);
                tabla3.AddCell(cl3Fila31);
                tabla3.AddCell(cl3Fila32);
                tabla3.AddCell(cl3Fila33);
                tabla3.AddCell(cl3Fila34);
                /*
                tabla3.AddCell(cl3Fila41);
                tabla3.AddCell(cl3Fila42);
                tabla3.AddCell(cl3Fila43);
                tabla3.AddCell(cl3Fila44);
                */
                doc.Add(titulo3);
                doc.Add(tabla3);
                
                //DEtalle de productos de la preventa
                Paragraph titulo4 = new Paragraph(CENConstante.g_campo_detaProd, ftitulo2);
                PdfPTable tabla4 = new PdfPTable(CENConstante.g_const_9);
                tabla4.HeaderRows = CENConstante.g_const_1;
                tabla4.WidthPercentage = CENConstante.g_cons100f;
                float[] widths_productos = new float[] { CENConstante.g_cons5f, CENConstante.g_cons10f, CENConstante.g_cons15f, CENConstante.g_cons10f, CENConstante.g_cons10f, CENConstante.g_cons10f, CENConstante.g_cons10f, CENConstante.g_cons10f, CENConstante.g_cons10f };
                tabla4.SetWidths(widths_productos);
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
                //for de los productos, promociones y descuentos
                double descTotal = CENConstante.g_const_0;
                int cont_desc = 0;
                int cont_promo = 0;
                int posicion = CENConstante.g_const_0;
                foreach (CENNotaCreditoDatosDetalleVenta data in dataVenta.listaDetalle)
                {
                    posicion = posicion + CENConstante.g_const_1;
                    descTotal = descTotal + data.descuento;
                    double subtotal = (data.precioVenta * data.cantidadUnidadBase - data.descuento);
                    cl4Fila11 = objCLNFormatos.FormatearCeldaTexto(data.itemVenta.ToString(), CENConstante.consARIAL, CENConstante.g_const_8, CENConstante.g_const_1, CENConstante.g_cons075f, CENConstante.g_cons20f, CBlanco, CSecundario, CBlanco, CBlanco, CBlanco, CBlanco, CENConstante.g_const_1);
                    cl4Fila12 = objCLNFormatos.FormatearCeldaTexto(data.codProducto, CENConstante.consARIAL, CENConstante.g_const_8, CENConstante.g_const_1, CENConstante.g_cons075f, CENConstante.g_cons20f, CBlanco, CSecundario, CBlanco, CBlanco, CBlanco, CBlanco, CENConstante.g_const_1);
                    cl4Fila13 = objCLNFormatos.FormatearCeldaTexto(data.descProducto, CENConstante.consARIAL, CENConstante.g_const_8, CENConstante.g_const_1, CENConstante.g_cons075f, CENConstante.g_cons20f, CBlanco, CSecundario, CBlanco, CBlanco, CBlanco, CBlanco, CENConstante.g_const_3);
                    cl4Fila14 = objCLNFormatos.FormatearCeldaTexto(data.cantidadPresentacion.ToString(), CENConstante.consARIAL, CENConstante.g_const_8, CENConstante.g_const_1, CENConstante.g_cons075f, CENConstante.g_cons20f, CBlanco, CSecundario, CBlanco, CBlanco, CBlanco, CBlanco, CENConstante.g_const_1);
                    cl4Fila15 = objCLNFormatos.FormatearCeldaTexto(data.descUnidadBase, CENConstante.consARIAL, CENConstante.g_const_8, CENConstante.g_const_1, CENConstante.g_cons075f, CENConstante.g_cons20f, CBlanco, CSecundario, CBlanco, CBlanco, CBlanco, CBlanco, CENConstante.g_const_1);
                    cl4Fila16 = objCLNFormatos.FormatearCeldaTexto(FormatoDecimal(data.precioVenta), CENConstante.consARIAL, CENConstante.g_const_8, CENConstante.g_const_1, CENConstante.g_cons075f, CENConstante.g_cons20f, CBlanco, CSecundario, CBlanco, CBlanco, CBlanco, CBlanco, CENConstante.g_const_2);
                    cl4Fila17 = objCLNFormatos.FormatearCeldaTexto(FormatoDecimal(data.descuento), CENConstante.consARIAL, CENConstante.g_const_8, CENConstante.g_const_1, CENConstante.g_cons075f, CENConstante.g_cons20f, CBlanco, CSecundario, CBlanco, CBlanco, CBlanco, CBlanco, CENConstante.g_const_2);
                    cl4Fila18 = objCLNFormatos.FormatearCeldaTexto(data.descTipoProducto, CENConstante.consARIAL, CENConstante.g_const_8, CENConstante.g_const_1, CENConstante.g_cons075f, CENConstante.g_cons20f, CBlanco, CSecundario, CBlanco, CBlanco, CBlanco, CBlanco, CENConstante.g_const_3);
                    cl4Fila19 = objCLNFormatos.FormatearCeldaTexto(FormatoDecimal(subtotal), CENConstante.consARIAL, CENConstante.g_const_8, CENConstante.g_const_1, CENConstante.g_cons075f, CENConstante.g_cons20f, CBlanco, CSecundario, CBlanco, CBlanco, CBlanco, CBlanco, CENConstante.g_const_2);
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
                doc.Add(titulo4);
                doc.Add(tabla4);
                
                //Tabla de los totales
                PdfPTable tabla5 = new PdfPTable(CENConstante.g_const_2);
                tabla5.WidthPercentage = CENConstante.g_cons100f;
                float[] widths_montos = new float[] { CENConstante.g_cons90f, CENConstante.g_cons10f};
                tabla5.SetWidths(widths_montos);
                tabla5.DefaultCell.Border = Rectangle.NO_BORDER;
                tabla5.SpacingAfter = CENConstante.g_cons10f;

                PdfPCell cl5Fila41 = new PdfPCell(new Phrase(CENConstante.g_campo_subtotal, fsec10n));
                cl5Fila41.Border = CENConstante.g_const_0;
                cl5Fila41.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                PdfPCell cl5Fila42 = new PdfPCell(new Phrase(FormatoDecimal(subtotalPre), fsec10));
                cl5Fila42.Border = CENConstante.g_const_0;
                cl5Fila42.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                PdfPCell cl5Fila11 = new PdfPCell(new Phrase(CENConstante.g_campo_descTotal, fsec10n));
                cl5Fila11.Border = CENConstante.g_const_0;
                cl5Fila11.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                PdfPCell cl5Fila12 = new PdfPCell(new Phrase(FormatoDecimal(descTotal), fsec10));
                cl5Fila12.Border = CENConstante.g_const_0;
                cl5Fila12.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                PdfPCell cl5Fila21 = new PdfPCell(new Phrase(CENConstante.g_campo_recargo, fsec10n));
                cl5Fila21.Border = CENConstante.g_const_0;
                cl5Fila21.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                PdfPCell cl5Fila22 = new PdfPCell(new Phrase(FormatoDecimal(dataVenta.importeRecargo), fsec10));
                cl5Fila22.Border = CENConstante.g_const_0;
                cl5Fila22.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                PdfPCell cl5Fila31 = new PdfPCell(new Phrase(CENConstante.g_campo_igv, fsec10n));
                cl5Fila31.Border = CENConstante.g_const_0;
                cl5Fila31.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                PdfPCell cl5Fila32 = new PdfPCell(new Phrase(FormatoDecimal(dataVenta.IGV), fsec10));
                cl5Fila32.Border = CENConstante.g_const_0;
                cl5Fila32.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                PdfPCell cl5Fila51 = new PdfPCell(new Phrase(CENConstante.g_campo_total, fsec10n));
                cl5Fila51.Border = CENConstante.g_const_0;
                cl5Fila51.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                PdfPCell cl5Fila52 = new PdfPCell(new Phrase(FormatoDecimal(dataVenta.importeTotal), fsec10));
                cl5Fila52.Border = CENConstante.g_const_0;
                cl5Fila52.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                tabla5.AddCell(cl5Fila41);
                tabla5.AddCell(cl5Fila42);
                tabla5.AddCell(cl5Fila11);
                tabla5.AddCell(cl5Fila12);
                tabla5.AddCell(cl5Fila21);
                tabla5.AddCell(cl5Fila22);
                tabla5.AddCell(cl5Fila31);
                tabla5.AddCell(cl5Fila32);
                tabla5.AddCell(cl5Fila51);
                tabla5.AddCell(cl5Fila52);
                doc.Add(tabla5);
                
                //PROMOCIONES Y DESCUENTOS
                Paragraph tpromo = new Paragraph(CENConstante.g_campo_promociones, ftitulo2);
                Paragraph promociones = new Paragraph();
                Paragraph tdesc = new Paragraph(CENConstante.g_campo_descuentos, ftitulo2);
                Paragraph descuentos = new Paragraph();


                if(dataVenta.listaPromociones.Count > CENConstante.g_const_0)
                {
                    cont_promo = dataVenta.listaPromociones.Count;
                    for (int i = CENConstante.g_const_0; i<dataVenta.listaPromociones.Count; i++)
                    {
                        promociones.Add(new Phrase(dataVenta.listaPromociones[i].descripcion + CENConstante.consSaltoLinea, fsec10));
                    }
                }

                if (dataVenta.listaDescuentos.Count > CENConstante.g_const_0)
                {
                    cont_desc = dataVenta.listaDescuentos.Count;
                    for (int i = CENConstante.g_const_0; i < dataVenta.listaDescuentos.Count; i++)
                    {
                        descuentos.Add(new Phrase(dataVenta.listaDescuentos[i].descripcion + CENConstante.consSaltoLinea, fsec10));
                    }
                }
                if (cont_promo == CENConstante.g_const_0) { promociones.Add(new Phrase("Sin promociones", fsec10)); }
                if (cont_desc == CENConstante.g_const_0) { descuentos.Add(new Phrase("Sin descuentos", fsec10)); }
                doc.Add(tpromo);
                doc.Add(promociones);
                doc.Add(nuevaLinea);
                doc.Add(tdesc);
                doc.Add(descuentos);

                

                doc.Close();

                l_pdfbytes = ms.ToArray();
                ms.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return l_pdfbytes;
        }


        public string FormatoDecimal(double monto)
        {
            return string.Format(CENConstante.g_const_formredini + Math.Abs(CENConstante.g_const_2) + CENConstante.g_const_formredfin, monto);

        }

    }
    
}
