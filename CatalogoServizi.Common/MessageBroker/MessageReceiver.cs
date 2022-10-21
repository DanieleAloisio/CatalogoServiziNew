using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using IModel = RabbitMQ.Client.IModel;

namespace CatalogoServizi.Common.MessageBroker
{
    /// <summary>
    /// Message Receiver
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class MessageReceiver<T> : IHostedService
    {
        private readonly MessageBrokerConfig _config;
        private readonly ILogger<MessageReceiver<T>> _logger;
        private readonly string _routingKey = null!;
        private ConnectionFactory _factory = null!;
        private IConnection _connection = null!;
        private IModel _channel = null!;
        EventingBasicConsumer _consumer = null!;

        /// <summary>
        /// Logger
        /// </summary>
        protected ILogger<MessageReceiver<T>> Logger { get { return _logger; } }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="config">Config</param>
        /// <param name="logger">Logger</param>
        /// <param name="routingKey">Routing key</param>
        public MessageReceiver(IOptions<MessageBrokerConfig> config, ILogger<MessageReceiver<T>> logger, string routingKey = "")
        {
            _config = config.Value;
            _logger = logger;
            _routingKey = routingKey;
        }

        /// <summary>
        /// Receive Message
        /// </summary>
        /// <param name="item">Item</param>
        public abstract void Receive(T? item);

        /// <summary>
        /// Start Async
        /// </summary>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns>Task</returns>
        public Task StartAsync(CancellationToken cancellationToken)
        {

            try
            {
                _factory = new ConnectionFactory()
                {
                    HostName = _config.HostName,
                    UserName = _config.UserName,
                    Password = _config.Password
                };
                _connection = _factory.CreateConnection();
                _channel = _connection.CreateModel();
                _consumer = new EventingBasicConsumer(_channel);

                _consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    var item = JsonSerializer.Deserialize<T>(message, new JsonSerializerOptions()
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    Receive(item);
                };


                string exchangename = typeof(T).GetIdentifier();
                string queuename = $"{AppDomain.CurrentDomain.FriendlyName}_{exchangename}";

                _channel.ExchangeDeclare(exchange: exchangename, durable: true, autoDelete: false, type: ExchangeType.Fanout);
                _channel.QueueDeclare(queuename, true, false, false);
                _channel.QueueBind(queue: queuename, exchange: exchangename, routingKey: _routingKey);
                _channel.BasicConsume(queue: queuename, autoAck: true, consumer: _consumer);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }


            return Task.CompletedTask;

        }

        /// <summary>
        /// Stop
        /// </summary>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns>Task</returns>
        public Task StopAsync(CancellationToken cancellationToken)
        {
            _connection.Dispose();
            return Task.CompletedTask;
        }
    }
}
