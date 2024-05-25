using Examen.Models;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;


namespace Examen.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class StoredProcedure
    {
        private SqlConnection con;
        private SqlCommand com;
        private string nameStoredProcedure;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nameSP"></param>
        public StoredProcedure(string nameSP) {

            conectarDB();
            nameStoredProcedure = nameSP;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="valor"></param>
        public void AgregarParametro(string name, object valor)
        {   
           com.Parameters.Add(new SqlParameter(name, Convertidor(valor)));
        }

        private void conectarDB()
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings.ToString());
                con.Open();

            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Cierra la conexion
        /// </summary>
        public void cerrarConexion()
        {
            con.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        public async Task<SqlDataReader> ExecuteReader()
        {
            com = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = nameStoredProcedure;

            var reader = await com.ExecuteReaderAsync();

            return reader;
        }

        private SqlDbType Convertidor(object Valor)
        {

            switch(Valor.GetType().Name) {

                case "Int32":
                    return SqlDbType.Int;
                case "Int64":
                    return SqlDbType.BigInt;
                case "Int16":
                    return SqlDbType.SmallInt;
                case "byte":
                    return SqlDbType.TinyInt;
                case "decimal":
                    return SqlDbType.Decimal;
                case "float":
                    return SqlDbType.Float;
                case "double":
                    return SqlDbType.Real;
                case "bool":
                    return SqlDbType.Bit;
                case "string":
                    return SqlDbType.NVarChar;
                case "DateTime":
                    return SqlDbType.DateTime;

            }

            return SqlDbType.Int;
        }
    }

}