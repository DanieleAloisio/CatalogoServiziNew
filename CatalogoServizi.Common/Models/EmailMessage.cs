using CatalogoServizi.Common.MessageBroker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoServizi.Common.Models
{
    /// <summary>
    /// Messaggi
    /// </summary>
    [MessageBus("EmailMessage")]
    public class EmailMessage
    {
        /// <summary>
        /// Oggetto
        /// </summary>
        public string Oggetto { get; set; } = string.Empty;

        /// <summary>
        /// Testo
        /// </summary>
        public string Testo { get; set; } = string.Empty;

        /// <summary>
        /// Destinatari To
        /// </summary>
        public List<string> DestinatariTo { get; set; } = new List<string>();

        /// <summary>
        /// Destinatari in cc
        /// </summary>
        public List<string> DestinatariCc { get; set; } = new List<string>();
    }
}
