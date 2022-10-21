using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogoServizi.Common.Models;

namespace CatalogoServizi.Business.Dto.LogDto
{
    /// <summary>
    /// Log Search Information
    /// </summary>
    public class LogSearchInput : DataFilter
    {
        /// <summary>
        /// Testo del messaggio
        /// </summary>
        public string Messaggio { get; set; } = string.Empty;

        /// <summary>
        /// Data Evento
        /// </summary>
        public DateRange DataEvento { get; set; } = new DateRange();

        /// <summary>
        /// Tipo Evento
        /// </summary>
        public int? IdTipoEvento { get; set; }
        
        /// <summary>
        /// Identificativo utente
        /// </summary>
        public int? IdUtente { get;  set; }
    }
}
