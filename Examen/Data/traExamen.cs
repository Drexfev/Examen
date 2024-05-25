using Examen.Models;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examen.Data
{
    /// <summary>
    /// Asministra las funciones basicas de los examenes
    /// </summary>
    public class traExamen
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlDataReader"></param>
        /// <returns></returns>
        private static cExamen DatoExamen(SqlDataReader sqlDataReader)
        {
            var oExamen = new cExamen();

            var cantidadColumnas = sqlDataReader.FieldCount;

            for (int i = 0; i < cantidadColumnas; i++) {

                switch (sqlDataReader.GetName(i))
                {
                    case nameof(oExamen.IdExamen): oExamen.IdExamen = sqlDataReader.GetInt32(i); break;
                    case nameof(oExamen.Nombre): oExamen.Nombre = sqlDataReader.GetString(i); break;
                    case nameof(oExamen.Descripcion): oExamen.Descripcion = sqlDataReader.GetString(i); break;
                } 
            }

            return oExamen;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlDataReader"></param>
        /// <returns></returns>
        private static List<cExamen> ListaExamen(SqlDataReader sqlDataReader) { 
            
            var listExamen = new List<cExamen>();

            while (sqlDataReader.Read())
            {
                listExamen.Add(DatoExamen(sqlDataReader));
            }

            return listExamen;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="FilNombre"></param>
        /// <returns></returns>
        public static async Task<List<cExamen>> Select(string FilNombre)
        {
            var oStoredProcedured = new StoredProcedure("dbo.spConsultar");

            oStoredProcedured.AgregarParametro("@FilNombre", FilNombre);

            var sqlDataReader = await oStoredProcedured.ExecuteReader();

            var listExamen = new List<cExamen>();

            listExamen = ListaExamen(sqlDataReader);

            oStoredProcedured.cerrarConexion();

            return listExamen;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oExamen"></param>
        /// <param name="sIdioma"></param>
        /// <returns></returns>
        public static async Task<cResultado> Insert(cExamen oExamen, string sIdioma)
        {
            var oStoredProcedured = new StoredProcedure("dbo.spAgregar");

            oStoredProcedured.AgregarParametro("@Nombre", oExamen.Nombre);
            oStoredProcedured.AgregarParametro("@Idioma", oExamen.Descripcion);
            oStoredProcedured.AgregarParametro("@Idioma", sIdioma);

            var sqlDataReader = await oStoredProcedured.ExecuteReader();

            sqlDataReader.Read();

            var result = new cResultado(sqlDataReader.GetBoolean(1), sqlDataReader.GetString(2), sqlDataReader.GetString(3));

            oStoredProcedured.cerrarConexion();

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oExamen"></param>
        /// <param name="sIdioma"></param>
        /// <returns></returns>
        public static async Task<cResultado> Update(cExamen oExamen, string sIdioma)
        {
            var oStoredProcedured = new StoredProcedure("dbo.spActualizar");

            oStoredProcedured.AgregarParametro("@Nombre", oExamen.Nombre);
            oStoredProcedured.AgregarParametro("@Descripcion", oExamen.Descripcion);
            oStoredProcedured.AgregarParametro("@Idioma", sIdioma);

            var sqlDataReader = await oStoredProcedured.ExecuteReader();

            sqlDataReader.Read();

            var result = new cResultado(sqlDataReader.GetBoolean(1), sqlDataReader.GetString(2), sqlDataReader.GetString(3));

            oStoredProcedured.cerrarConexion();

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idExamen"></param>
        /// <param name="sIdioma"></param>
        /// <returns></returns>
        public static async Task<cResultado> _Delete(int idExamen, string sIdioma)
        {
            var oStoredProcedured = new StoredProcedure("dbo.spEliminar");

            oStoredProcedured.AgregarParametro("@IdExamen", idExamen);
            oStoredProcedured.AgregarParametro("@Idioma", sIdioma);

            var sqlDataReader = await oStoredProcedured.ExecuteReader();

            sqlDataReader.Read();

            var result = new cResultado(sqlDataReader.GetBoolean(1), sqlDataReader.GetString(2), sqlDataReader.GetString(3));

            oStoredProcedured.cerrarConexion();

            return result;
        }

    }
}