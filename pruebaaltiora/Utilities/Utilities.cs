using System;
using pruebaaltiora.Models;
using System.Data;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;

namespace pruebaaltiora.Utilities
{
    public static partial class Utilities
    {

        /// <summary>
        /// Conviente en Mayusclas las columans de la Primera Tabla
        /// </summary>
        /// <param name="ad_dataSet"></param>
        /// <param name="as_mayusculas"></param>
        public static void ColumnasCambioNombre(DataSet ad_dataSet, bool as_mayusculas)
        {
            if (!(ad_dataSet != null && ad_dataSet.Tables != null && ad_dataSet.Tables.Count > 0))
                return;


            foreach (DataColumn item in ad_dataSet.Tables[0].Columns)
            {
                if (as_mayusculas)
                    item.ColumnName = item.ColumnName.ToUpper();
                else
                    item.ColumnName = item.ColumnName.ToLower();
            }
        }

        /// <summary>
        /// Conviente en Mayusclas las columans de la Primera Tabla
        /// </summary>
        /// <param name="ad_dataSet"></param>
        /// <param name="as_mayusculas"></param>
        public static void ColumnasCambioNombreCapital(DataSet ad_dataSet)
        {
            if (!(ad_dataSet != null && ad_dataSet.Tables != null && ad_dataSet.Tables.Count > 0))
                return;


            foreach (DataColumn item in ad_dataSet.Tables[0].Columns)
            {
                item.ColumnName = PrimeraLetraMayuscula(item.ColumnName);
            }
        }

        public static string PrimeraLetraMayuscula(this string input) =>
        input switch
        {
            null => throw new ArgumentNullException(nameof(input)),
            "" => throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)),
            _ => string.Concat(input[0].ToString().ToUpper(), input.AsSpan(1))
        };

        /// <summary>
        /// Valida si la Primara Tabla del Dataset Posee Registros
        /// </summary>
        /// <param name="ad_dataaset"></param>
        /// <returns></returns>
        public static bool DataSetConDatos(DataSet ad_dataaset)
        {

            return (ad_dataaset != null && ad_dataaset.Tables != null && ad_dataaset.Tables.Count > 0 && ad_dataaset.Tables[0].Rows.Count > 0);

        }
    }
}