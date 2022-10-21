using CatalogoServizi.Common.MessageBroker;
using CatalogoServizi.Common.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoServizi.MessageHub.Business.Consumer
{
    /// <summary>
    /// Consumer dei log
    /// </summary>
    public class LogConsumer : MessageReceiver<LogMessage>
    {
        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="config">configurazoine</param>
        /// <param name="logger">Logger</param>
        /// <param name="routingKey">Chiave routing</param>
        public LogConsumer(IOptions<MessageBrokerConfig> config, ILogger<MessageReceiver<LogMessage>> logger, string routingKey = "") : base(config, logger, routingKey)
        {
        }

        /// <summary>
        /// Evento del receiver
        /// </summary>
        /// <param name="item">Oggetto</param>
        public override void Receive(LogMessage? item)
        {
            
        }
    }
}
