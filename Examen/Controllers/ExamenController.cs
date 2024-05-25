using Examen.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using static Examen.Data.traExamen;

namespace Examen.Controllers
{ 
    /// <summary>
    /// Administra las funciones basicas del examen CRUD
    /// </summary>
    public class ExamenController : ApiController
    {
        /// <summary>
        /// Contiene una lista de examen
        /// </summary>
        /// <param name="FilNombre"></param>
        /// <returns></returns>
        [Route("api/Examen")]
        [ResponseType(typeof(IEnumerable<cExamen>))]
        public async Task<HttpResponseMessage> GetDataList(string FilNombre = null)
        {
            {
                var list = await Select(FilNombre);

                if (list == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NoContent, "No se encontraron resultados");
                }

                // Serialize data to JSON
                string jsonData = JsonConvert.SerializeObject(list);

                // Return JSON response
                var response = Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                return response;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="examen"></param>
        /// <returns></returns>
        [Route("api/Examen")]
        [ResponseType(typeof(cResultado))]
        public async Task<HttpResponseMessage> Post([FromBody] cExamen examen)
        {
            var oResult = await Insert(examen, Request.Headers.AcceptLanguage.ToString());

            if (oResult.Success)
            {
                // Serialize data to JSON
                string jsonData = JsonConvert.SerializeObject(oResult);

                // Return JSON response
                var response = Request.CreateResponse(HttpStatusCode.OK);

                response.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NoContent, oResult.Message);

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="examen"></param>
        /// <returns></returns>
        [Route("api/Examen")]
        [ResponseType(typeof(cResultado))]
        public async Task<HttpResponseMessage> Put([FromBody] cExamen examen)
        {
            var oResult = await Update(examen, Request.Headers.AcceptLanguage.ToString());

            if (oResult.Success)
            {
                // Serialize data to JSON
                string jsonData = JsonConvert.SerializeObject(oResult);

                // Return JSON response
                var response = Request.CreateResponse(HttpStatusCode.OK);

                response.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NoContent, oResult.Message);

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdExamen"></param>
        /// <returns></returns>
        [Route("api/Examen")]
        [ResponseType(typeof(cResultado))]
        public async Task<HttpResponseMessage> Delete(int IdExamen)
        {
            var oResult = await _Delete(IdExamen, Request.Headers.AcceptLanguage.ToString());

            if (oResult.Success)
            {
                // Serialize data to JSON
                string jsonData = JsonConvert.SerializeObject(oResult);

                // Return JSON response
                var response = Request.CreateResponse(HttpStatusCode.OK);

                response.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NoContent, oResult.Message);

            }
        }

    }
}