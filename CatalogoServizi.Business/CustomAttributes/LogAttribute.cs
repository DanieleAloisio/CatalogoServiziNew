using CatalogoServizi.Business.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoServizi.Business.CustomAttributes
{
    /// <summary>
    /// Attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class LogAttribute : Attribute
    {
        /// <summary>
        /// Messaggio
        /// </summary>
        public string Messaggio { get; private set; }

        /// <summary>
        /// Tipo Evento
        /// </summary>
        public TipoEventoEnum TipoEvento { get; private set; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="messaggio"></param>
        /// <param name="tipoEvento"></param>
        public LogAttribute(string messaggio,TipoEventoEnum tipoEvento)
        {
            Messaggio = messaggio;
            TipoEvento = tipoEvento;
        }

        
    }


}
