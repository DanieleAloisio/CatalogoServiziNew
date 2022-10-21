using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CatalogoServizi.Common.MessageBroker
{
    /// <summary>
    /// Message Sender Service
    /// </summary>
    public class MessageSender : IMessageSender
    {
        private readonly ConnectionFactory _factory = null!;
        private readonly MessageBrokerConfig _config = null!;
        private readonly IConnection _connection = null!;
        private readonly IModel _model = null!;
        private readonly bool ready = false;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="config">Broker configuration</param>
        public MessageSender(IOptions<MessageBrokerConfig> config)
        {
            try
            {
                _config = config.Value;
                _factory = new ConnectionFactory()
                {
                    UserName = _config.UserName,
                    HostName = _config.HostName,
                    Password = _config.Password
                };

                _connection = _factory.CreateConnection();
                _model = _connection.CreateModel();
                ready = true;
            }
            catch
            {
                //Offline
            }
        }

        /// <summary>
        /// Send message to an exchange. If exchange name is omitted it will be used type fullname
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="item">Item</param>
        /// <param name="exchangeName">Exchange name.</param>
        /// <param name="routingKey">Routing key</param>
        public void SendMessage<T>(T item, string exchangeName = "", string routingKey = "") where T : class, new()
        {
            if (ready)
            {
                if (string.IsNullOrEmpty(exchangeName))
                    exchangeName = item.GetType().GetIdentifier();

                _model.ExchangeDeclare(exchange: exchangeName, durable: true, autoDelete: false, type: ExchangeType.Fanout);
                var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(item));
                _model.BasicPublish(exchange: exchangeName, routingKey: routingKey, basicProperties: null, body: body);
            }
        }

    }
}
