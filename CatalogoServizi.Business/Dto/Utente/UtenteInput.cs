using CatalogoServizi.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoServizi.Business.Dto.Utente
{
    /// <summary>
    /// Utente Input
    /// </summary>
    public class UtenteInput: DataFilter
    {
        /// <summary>
        /// Testo Libero
        /// </summary>
        public string TestoLibero { get; set; }

        /// <summary>
        /// IdRuolo
        /// </summary>
        public int? IdRuolo { get; set; }

        /// <summary>
        /// DataCreazione
        /// </summary>
        public DateRange DataCreazione { get; set; }
    }
}
