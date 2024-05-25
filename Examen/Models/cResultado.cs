using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen.Models
{
    public class cResultado
    {

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public cResultado(bool bSuccess, string sMessage, object oDato)
        {
            Success = bSuccess;
            Message = sMessage;
            Dato = oDato;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public object Dato { get; set; }
    }
}