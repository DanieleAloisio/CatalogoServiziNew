using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoServizi.Common.MessageBroker
{
    /// <summary>
    /// Message Sender Interface
    /// </summary>
    public interface IMessageSender
    {
        /// <summary>
        /// Send Message
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="item">Item</param>
        /// <param name="exchangeName">exchange name</param>
        /// <param name="routingKey">routing key</param>
        void SendMessage<T>(T item, string exchangeName = "", string routingKey = "") where T : class, new();
    }
}
