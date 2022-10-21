using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoServizi.Business.Dto.LogDto
{
    /// <summary>
    /// Output di ricerca log
    /// </summary>
    public class LogSearchOutput
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id Tipo
        /// </summary>
        public int IdTipo { get; set; }

        /// <summary>
        /// Tipo (descrizione)
        /// </summary>
        public string Tipo { get; set; } = string.Empty;

        /// <summary>
        /// Nominativo
        /// </summary>
        public string Utente { get; set; } = string.Empty;

        /// <summary>
        /// Data evento
        /// </summary>
        public DateTime DataEvento { get; set; }

        public string Messaggio { get; set; } = string.Empty;

    }
}
