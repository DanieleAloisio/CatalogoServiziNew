using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoServizi.Business.Dto.Servizio
{
    /// <summary>
    /// Servizio
    /// </summary>
    public class ServizioInput
    {

        /// <summary>
        /// Id Utente
        /// </summary>
        public int IdUtente { get; set; }

        /// <summary>
        /// Nome
        /// </summary>
        public string Nome { get; set; } = string.Empty;

        /// <summary>
        /// Url
        /// </summary>
        public string Url { get; set; } = string.Empty;

        /// <summary>
        /// Inizio Pubblicazione
        /// </summary>
        public DateTime InizioPubblicazione { get; set; }

        /// <summary>
        /// Data Fine Pubblicazione
        /// </summary>
        public DateTime? DataFinePubblicazione { get; set; }

        /// <summary>
        /// Canc
        /// </summary>
        public bool Canc { get; set; }
    }
}
