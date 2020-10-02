using CEN;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CLN
{
    public class CLNConsultas
    {
        public string ConvertFechaDateToString(DateTime fecha)
        {
            try
            {
                CultureInfo MyCultureInfo = new CultureInfo(CENConstante.g_const_es_PE);
                return fecha.ToString(CENConstante.g_const_formfech, MyCultureInfo);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DateTime ConvertFechaStringToDate(string fecha)
        {
            try
            {
                CultureInfo MyCultureInfo = new CultureInfo(CENConstante.g_const_es_PE);
                DateTime myDate = DateTime.ParseExact(fecha, CENConstante.g_const_formfech, MyCultureInfo);
                return myDate;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public bool ValidarNumero(string numero)
        {
            //DESCRIPCIÓN: VALIDAR NUMERO
            Regex reg = new Regex(CENConstante.g_const_rango_num);

            try
            {
                if (string.IsNullOrWhiteSpace(numero))
                    return false;
                for (int i = CENConstante.g_const_0; i < numero.Length; i++)
                {
                    if (!(reg.IsMatch(numero.Substring(i, CENConstante.g_const_1))))
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }

        public double RedondeoMontoFavorCliente(double monto)
        {
            try
            {
                string cadenaMonto = monto.ToString("N2");

                cadenaMonto = cadenaMonto.Substring(CENConstante.g_const_0, (cadenaMonto.Length - CENConstante.g_const_1));
                monto = Math.Round(double.Parse(cadenaMonto), CENConstante.g_const_2);
                return monto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ConvertirNroDocumento(int nroDocumento)
        {
            int longTotal = CENConstante.g_const_SizeTotalVenta;
            int longNumDoc = CENConstante.g_const_0;
            int longAddCero = CENConstante.g_const_0;
            string codigoTrans = CENConstante.g_const_vacio;
            try
            {
                if (nroDocumento > CENConstante.g_const_0)
                {
                    longNumDoc = nroDocumento.ToString().Length;
                    longAddCero = longTotal - longNumDoc;

                    for (int i = CENConstante.g_const_0; i < longAddCero; i++)
                    {
                        codigoTrans = codigoTrans + CENConstante.g_const_0;
                    }
                    codigoTrans = codigoTrans + nroDocumento;
                }
                return codigoTrans;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
