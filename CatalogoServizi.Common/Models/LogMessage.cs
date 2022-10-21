using CatalogoServizi.Common.MessageBroker;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoServizi.Common.Models
{
    /// <summary>
    /// Log Channel
    /// </summary>
    [MessageBus("LogChannel")]
    public class LogMessage
    {
        /// <summary>
        /// Input data
        /// </summary>
        public string Input { get;  set; } = string.Empty;

        /// <summary>
        /// Output data
        /// </summary>
        public string Output { get; set; } = string.Empty;

        /// <summary>
        /// Utenza
        /// </summary>
        public string User { get; set; } = string.Empty;

        /// <summary>
        /// Event type
        /// </summary>
        public string EventType { get; set; } = string.Empty;
    }
}
