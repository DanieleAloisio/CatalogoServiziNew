using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoServizi.Business.Dto.Common
{
    /// <summary>
    /// Messaggio di risposta generica
    /// </summary>
    public class MessageDto
    {
        /// <summary>
        /// Testo
        /// </summary>
        public string TextMessage { get; set; } = string.Empty;

        /// <summary>
        /// Codice errore
        /// </summary>
        public int ErrorCode { get; set; }

        /// <summary>
        /// Costruttore
        /// </summary>
        public MessageDto()
        {

        }

        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="textMessage">testo</param>
        /// <param name="errorCode">Codice errore</param>
        public MessageDto(string textMessage, int errorCode)
        {
            TextMessage = textMessage;
            ErrorCode = errorCode;
        }
    }
}
