using CatalogoServizi.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoServizi.Business.Dto.Utente
{
    /// <summary>
    /// Utente Output
    /// </summary>
    public class UtenteOutput
    {
        /// <summary>
        /// Username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Nome
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Cognome
        /// </summary>
        public string Cognome { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Data Creazione
        /// </summary>
        public DateTime DataCreazione { get; set; }

        /// <summary>
        /// Ruoli
        /// </summary>
        public List<KeyValue<int, string>> Ruoli { get; set; } = new List<KeyValue<int, string>>();
    }
}
