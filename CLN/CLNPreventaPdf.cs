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
    public class CLNPreventaPdf
    {
        public byte[] preventaPdf(CENPreventaLista datosPre)
        {
            CLNFormatos objCLNFormatos = new CLNFormatos();
            CENConstante cons = new CENConstante ();
            CADPreventa objCADPreventa = null;
            List<CENDetallePreventa> listaDetalle = null;
            CENCamposPreventa ubigeo = null;
            MemoryStream ms = null;
            int npreventa = datosPre.ntraPreventa;
            string descUbigeo="";
            byte[] l_pdfbytes = null;

            try
            {
                objCADPreventa = new CADPreventa();
                listaDetalle = objCADPreventa.ListarDetalle(npreventa);
                ms = new MemoryStream();

                if (!String.IsNullOrEmpty(datosPre.codUbigeo.Trim()))
                {
                    ubigeo = objCADPreventa.obtenerUbigeo(datosPre.codUbigeo);
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
                PdfPCell clFila12 = new PdfPCell(new Phrase(CENConstante.g_campo_sucursal, ftitulo2));
                //clFila12.BorderWidth = 0.75f;
                //clFila12.FixedHeight = 0f;
                clFila12.Border = CENConstante.g_const_0;
                clFila12.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                PdfPCell clFila13 = new PdfPCell(new Phrase(datosPre.sucursal, ftitulo2));
                //clFila13.BorderWidth = 0.75f;
                //clFila13.FixedHeight = 0f;
                clFila13.Border = CENConstante.g_const_0;
                clFila13.HorizontalAlignment = PdfPCell.ALIGN_LEFT;

                PdfPCell clFila20 = new PdfPCell(new Phrase(CENConstante.g_const_vacio, ftitulo2));
                clFila20.Border = CENConstante.g_const_0;
                PdfPCell clFila21 = new PdfPCell(new Phrase(CENConstante.g_campo_urbanizacion, ftitulo2));
                clFila21.Border = CENConstante.g_const_0;
                clFila21.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                PdfPCell clFila22 = new PdfPCell(new Phrase(CENConstante.g_campo_ruc, ftitulo2));
                clFila22.Border = CENConstante.g_const_0;
                clFila22.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                PdfPCell clFila23 = new PdfPCell(new Phrase(CENConstante.g_const_vacio, ftitulo2));
                clFila23.Border = CENConstante.g_const_0;
                clFila23.HorizontalAlignment = PdfPCell.ALIGN_LEFT;

                PdfPCell clFila30 = new PdfPCell(new Phrase(CENConstante.g_const_vacio, ftitulo2));
                clFila30.Border = CENConstante.g_const_0;
                PdfPCell clFila31 = new PdfPCell(new Phrase(CENConstante.g_campo_chiclayo, ftitulo2));
                clFila31.Border = CENConstante.g_const_0;
                clFila31.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                PdfPCell clFila32 = new PdfPCell(new Phrase(CENConstante.g_campo_telefono, ftitulo2));
                clFila32.Border = CENConstante.g_const_0;
                clFila32.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                PdfPCell clFila33 = new PdfPCell(new Phrase("-----", ftitulo2));
                clFila33.Border = CENConstante.g_const_0;
                clFila33.HorizontalAlignment = PdfPCell.ALIGN_LEFT;

                PdfPCell clFila40 = new PdfPCell(new Phrase(CENConstante.g_const_vacio, ftitulo2));
                clFila40.Border = CENConstante.g_const_0;
                PdfPCell clFila41 = new PdfPCell(new Phrase("----", ftitulo2));
                clFila41.Border = CENConstante.g_const_0;
                clFila41.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                PdfPCell clFila42 = new PdfPCell(new Phrase(CENConstante.g_campo_correo, ftitulo2));
                clFila42.Border = CENConstante.g_const_0;
                clFila42.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                PdfPCell clFila43 = new PdfPCell(new Phrase("----", ftitulo2));
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
                PdfPCell cl2Fila12 = new PdfPCell(new Phrase(datosPre.vendedor, fsec10));
                cl2Fila12.Border = CENConstante.g_const_0;
                cl2Fila12.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                PdfPCell cl2Fila21 = new PdfPCell(new Phrase(CENConstante.g_campo_cliente, fsec10n));
                cl2Fila21.Border = CENConstante.g_const_0;
                cl2Fila21.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                PdfPCell cl2Fila22 = new PdfPCell(new Phrase(datosPre.cliente, fsec10));
                cl2Fila22.Border = CENConstante.g_const_0;
                cl2Fila22.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                string ruc_dni = (datosPre.tipoPersona == 1) ? CENConstante.g_campo_dni : CENConstante.g_campo_ruc;
                PdfPCell cl2Fila31 = new PdfPCell(new Phrase(ruc_dni, fsec10n));
                cl2Fila31.Border = CENConstante.g_const_0;
                cl2Fila31.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                PdfPCell cl2Fila32 = new PdfPCell(new Phrase(datosPre.identificacion, fsec10));
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
                PdfPCell cl2Fila52 = new PdfPCell(new Phrase(datosPre.ruta, fsec10));
                cl2Fila52.Border = CENConstante.g_const_0;
                cl2Fila52.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                PdfPCell cl2Fila61 = new PdfPCell(new Phrase(CENConstante.g_campo_puntoEnt, fsec10n));
                cl2Fila61.Border = CENConstante.g_const_0;
                cl2Fila61.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                PdfPCell cl2Fila62 = new PdfPCell(new Phrase(datosPre.PuntoEntrega, fsec10));
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
                Paragraph titulo3 = new Paragraph(CENConstante.g_campo_detaPrev, ftitulo2);
                PdfPTable tabla3 = new PdfPTable(CENConstante.g_const_4);
                tabla3.WidthPercentage = CENConstante.g_cons100f;
                float[] widths_dato2 = new float[] { CENConstante.g_cons25f, CENConstante.g_cons25f, CENConstante.g_cons25f, CENConstante.g_cons25f };
                tabla3.SetWidths(widths_dato2);
                tabla3.DefaultCell.Border = Rectangle.NO_BORDER;
                tabla3.SpacingBefore = CENConstante.g_cons10f;
                tabla3.SpacingAfter = CENConstante.g_cons10f;
                PdfPCell cl3Fila11 = new PdfPCell(new Phrase(CENConstante.g_campo_preventa, fsec10n));
                cl3Fila11.Border = CENConstante.g_const_0;
                cl3Fila11.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                PdfPCell cl3Fila12 = new PdfPCell(new Phrase(datosPre.ntraPreventa.ToString(), fsec10));
                cl3Fila12.Border = CENConstante.g_const_0;
                cl3Fila12.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                PdfPCell cl3Fila13 = new PdfPCell(new Phrase(CENConstante.g_campo_fechaR, fsec10n));
                cl3Fila13.Border = CENConstante.g_const_0;
                cl3Fila13.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                PdfPCell cl3Fila14 = new PdfPCell(new Phrase(datosPre.FechaR, fsec10));
                cl3Fila14.Border = CENConstante.g_const_0;
                cl3Fila14.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                PdfPCell cl3Fila21 = new PdfPCell(new Phrase(CENConstante.g_campo_tipoVenta, fsec10n));
                cl3Fila21.Border = CENConstante.g_const_0;
                cl3Fila21.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                PdfPCell cl3Fila22 = new PdfPCell(new Phrase(datosPre.Tventa, fsec10));
                cl3Fila22.Border = CENConstante.g_const_0;
                cl3Fila22.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                PdfPCell cl3Fila23 = new PdfPCell(new Phrase(CENConstante.g_campo_fechaE, fsec10n));
                cl3Fila23.Border = CENConstante.g_const_0;
                cl3Fila23.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                PdfPCell cl3Fila24 = new PdfPCell(new Phrase(datosPre.FechaE, fsec10));
                cl3Fila24.Border = CENConstante.g_const_0;
                cl3Fila24.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                PdfPCell cl3Fila31 = new PdfPCell(new Phrase(CENConstante.g_campo_documento, fsec10n));
                cl3Fila31.Border = CENConstante.g_const_0;
                cl3Fila31.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                PdfPCell cl3Fila32 = new PdfPCell(new Phrase(datosPre.Tdoc, fsec10));
                cl3Fila32.Border = CENConstante.g_const_0;
                cl3Fila32.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                PdfPCell cl3Fila33 = new PdfPCell(new Phrase(CENConstante.g_campo_moneda, fsec10n));
                cl3Fila33.Border = CENConstante.g_const_0;
                cl3Fila33.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                PdfPCell cl3Fila34 = new PdfPCell(new Phrase(datosPre.moneda, fsec10));
                cl3Fila34.Border = CENConstante.g_const_0;
                cl3Fila34.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
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
                tabla3.AddCell(cl3Fila41);
                tabla3.AddCell(cl3Fila42);
                tabla3.AddCell(cl3Fila43);
                tabla3.AddCell(cl3Fila44);
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
                //for del detalle de la preventa
                decimal descTotal = CENConstante.g_const_0;
                int cont_desc = 0;
                int cont_promo = 0;
                foreach (var data in listaDetalle)
                {
                    descTotal = descTotal + data.descuento;
                    decimal subtotal = (data.precio * data.cantidadUnidadBase - data.descuento);
                    cl4Fila11 = objCLNFormatos.FormatearCeldaTexto(data.item.ToString(), CENConstante.consARIAL, CENConstante.g_const_8, CENConstante.g_const_1, CENConstante.g_cons075f, CENConstante.g_cons20f, CBlanco, CSecundario, CBlanco, CBlanco, CBlanco, CBlanco, CENConstante.g_const_1);
                    cl4Fila12 = objCLNFormatos.FormatearCeldaTexto(data.codProducto, CENConstante.consARIAL, CENConstante.g_const_8, CENConstante.g_const_1, CENConstante.g_cons075f, CENConstante.g_cons20f, CBlanco, CSecundario, CBlanco, CBlanco, CBlanco, CBlanco, CENConstante.g_const_1);
                    cl4Fila13 = objCLNFormatos.FormatearCeldaTexto(data.descripcion, CENConstante.consARIAL, CENConstante.g_const_8, CENConstante.g_const_1, CENConstante.g_cons075f, CENConstante.g_cons20f, CBlanco, CSecundario, CBlanco, CBlanco, CBlanco, CBlanco, CENConstante.g_const_3);
                    cl4Fila14 = objCLNFormatos.FormatearCeldaTexto(data.cantidad.ToString(), CENConstante.consARIAL, CENConstante.g_const_8, CENConstante.g_const_1, CENConstante.g_cons075f, CENConstante.g_cons20f, CBlanco, CSecundario, CBlanco, CBlanco, CBlanco, CBlanco, CENConstante.g_const_1);
                    cl4Fila15 = objCLNFormatos.FormatearCeldaTexto(data.um, CENConstante.consARIAL, CENConstante.g_const_8, CENConstante.g_const_1, CENConstante.g_cons075f, CENConstante.g_cons20f, CBlanco, CSecundario, CBlanco, CBlanco, CBlanco, CBlanco, CENConstante.g_const_1);
                    cl4Fila16 = objCLNFormatos.FormatearCeldaTexto(data.precio.ToString(), CENConstante.consARIAL, CENConstante.g_const_8, CENConstante.g_const_1, CENConstante.g_cons075f, CENConstante.g_cons20f, CBlanco, CSecundario, CBlanco, CBlanco, CBlanco, CBlanco, CENConstante.g_const_2);
                    cl4Fila17 = objCLNFormatos.FormatearCeldaTexto(data.descuento.ToString(), CENConstante.consARIAL, CENConstante.g_const_8, CENConstante.g_const_1, CENConstante.g_cons075f, CENConstante.g_cons20f, CBlanco, CSecundario, CBlanco, CBlanco, CBlanco, CBlanco, CENConstante.g_const_2);
                    cl4Fila18 = objCLNFormatos.FormatearCeldaTexto(data.tipo, CENConstante.consARIAL, CENConstante.g_const_8, CENConstante.g_const_1, CENConstante.g_cons075f, CENConstante.g_cons20f, CBlanco, CSecundario, CBlanco, CBlanco, CBlanco, CBlanco, CENConstante.g_const_3);
                    cl4Fila19 = objCLNFormatos.FormatearCeldaTexto(subtotal.ToString(), CENConstante.consARIAL, CENConstante.g_const_8, CENConstante.g_const_1, CENConstante.g_cons075f, CENConstante.g_cons20f, CBlanco, CSecundario, CBlanco, CBlanco, CBlanco, CBlanco, CENConstante.g_const_2);
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
                decimal subtotalPre = datosPre.total - datosPre.igv;

                PdfPTable tabla5 = new PdfPTable(CENConstante.g_const_2);
                tabla5.WidthPercentage = CENConstante.g_cons100f;
                float[] widths_montos = new float[] { CENConstante.g_cons90f, CENConstante.g_cons10f};
                tabla5.SetWidths(widths_montos);
                tabla5.DefaultCell.Border = Rectangle.NO_BORDER;
                tabla5.SpacingAfter = CENConstante.g_cons10f;

                PdfPCell cl5Fila41 = new PdfPCell(new Phrase(CENConstante.g_campo_subtotal, fsec10n));
                cl5Fila41.Border = CENConstante.g_const_0;
                cl5Fila41.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                PdfPCell cl5Fila42 = new PdfPCell(new Phrase(subtotalPre.ToString(), fsec10));
                cl5Fila42.Border = CENConstante.g_const_0;
                cl5Fila42.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                PdfPCell cl5Fila11 = new PdfPCell(new Phrase(CENConstante.g_campo_descTotal, fsec10n));
                cl5Fila11.Border = CENConstante.g_const_0;
                cl5Fila11.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                PdfPCell cl5Fila12 = new PdfPCell(new Phrase(descTotal.ToString(), fsec10));
                cl5Fila12.Border = CENConstante.g_const_0;
                cl5Fila12.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                PdfPCell cl5Fila21 = new PdfPCell(new Phrase(CENConstante.g_campo_recargo, fsec10n));
                cl5Fila21.Border = CENConstante.g_const_0;
                cl5Fila21.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                PdfPCell cl5Fila22 = new PdfPCell(new Phrase(datosPre.recargo.ToString(), fsec10));
                cl5Fila22.Border = CENConstante.g_const_0;
                cl5Fila22.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                PdfPCell cl5Fila31 = new PdfPCell(new Phrase(CENConstante.g_campo_igv, fsec10n));
                cl5Fila31.Border = CENConstante.g_const_0;
                cl5Fila31.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                PdfPCell cl5Fila32 = new PdfPCell(new Phrase(datosPre.igv.ToString(), fsec10));
                cl5Fila32.Border = CENConstante.g_const_0;
                cl5Fila32.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                PdfPCell cl5Fila51 = new PdfPCell(new Phrase(CENConstante.g_campo_total, fsec10n));
                cl5Fila51.Border = CENConstante.g_const_0;
                cl5Fila51.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                PdfPCell cl5Fila52 = new PdfPCell(new Phrase(datosPre.total.ToString(), fsec10));
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

                int cont2 = 0;
                List<int> milista = new List<int>();
                milista.Add(0);
                //for de las promociones y descuentos
                foreach (var data2 in listaDetalle)
                {
                    if (data2.codPro != CENConstante.g_const_0)
                    {
                        foreach (var num in milista)
                        {
                            if (num == data2.codPro)
                            {
                                cont2++;
                            }
                        }
                        if (cont2==0)
                        {
                            milista.Add(data2.codPro);
                            promociones.Add(new Phrase(data2.descrPro + CENConstante.consSaltoLinea, fsec10));
                        }
                        cont2 = 0;
                        cont_promo = 1;
                    }
                    if (data2.codDec != CENConstante.g_const_0)
                    {
                        descuentos.Add(new Phrase(data2.descrDesc + CENConstante.consSaltoLinea, fsec10));
                        cont_desc = 1;
                    }
                }
                if (cont_promo == 0) { promociones.Add(new Phrase(CENConstante.g_mens_not_promo, fsec10)); }
                if (cont_desc == 0) { descuentos.Add(new Phrase(CENConstante.g_mens_not_desc, fsec10)); }
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
    }

    public class CLNFormatos
    {
        public PdfPCell FormatearCeldaTexto(string TextoCelda, string FuenteTexto, int TamanioTexto, int Borde, float BordeInf, float TamanioCelda, BaseColor ColorFondo, BaseColor ColorLetra, BaseColor ColorTop, BaseColor ColorBottom, BaseColor ColorLeft, BaseColor ColorRight, int Alieneacion)
        {
            //DESCRIPCION: LOGICA PARA CREAR UNA CELDA CON FORMATO DE TEXTO
            Chunk chunTexto = chunTexto = new Chunk(CENConstante.consSaltoLinea + TextoCelda, FontFactory.GetFont(FuenteTexto, TamanioTexto, iTextSharp.text.Font.BOLD, ColorLetra));

            PdfPCell celda = new PdfPCell(new Phrase(chunTexto));
            celda.BorderWidth = Borde;
            celda.BorderWidthBottom = BordeInf;
            celda.BorderColorTop = ColorTop;
            celda.BorderColorBottom = ColorBottom;
            celda.BorderColorLeft = ColorLeft;
            celda.BorderColorRight = ColorRight;
            //celda.FixedHeight = TamanioCelda;
            celda.BackgroundColor = ColorFondo;
            celda.VerticalAlignment = Element.ALIGN_CENTER;
            celda.FixedHeight = CENConstante.g_cons28f;
            celda.MinimumHeight = TamanioCelda;

            if (Alieneacion == CENConstante.g_const_1) celda.HorizontalAlignment = Element.ALIGN_CENTER;
            if (Alieneacion == CENConstante.g_const_2) celda.HorizontalAlignment = Element.ALIGN_RIGHT;
            if (Alieneacion == CENConstante.g_const_3) celda.HorizontalAlignment = Element.ALIGN_LEFT;

            return celda;
        }
    }
}
