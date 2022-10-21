using CatalogoServizi.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoServizi.Business.Dto.StoricoEmail
{
    /// <summary>
    /// Output ricerca storico email
    /// </summary>
    public class StoricoEmailOutput
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// IdConfigurazione
        /// </summary>
        public int IdConfigurazione { get; set; }

        /// <summary>
        /// Oggetto
        /// </summary>
        public string Oggetto { get; set; } = string.Empty;

        /// <summary>
        /// Testo
        /// </summary>
        public string Testo { get; set; }

        /// <summary>
        /// Data Invio
        /// </summary>
        public DateTime DataInvio { get; set; }

        /// <summary>
        /// Invio Corretto
        /// </summary>
        public bool InvioCorretto { get; set; }

        /// <summary>
        /// Messaggio Errore
        /// </summary>
        public string MessaggioErrore { get; set; }
    }
}
