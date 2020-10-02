using CEN;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAD
{
    public class CAD_Consulta
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
            catch(Exception ex)
            {
                throw ex;
            }
            

        }
        
    }
}
