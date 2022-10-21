using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoServizi.Business.Enums
{
    /// <summary>
    /// Tipologie di eventi
    /// </summary>
    public enum TipoEventoEnum
    {
        /// <summary>
        /// Censimento utente
        /// </summary>
        CensimentoUtente = 1,
        /// <summary>
        /// Modifica utente
        /// </summary>
        ModificaUtente = 2,
        /// <summary>
        /// Cancellazione utente
        /// </summary>
        CancellazioneUtente = 3
    }
}
