using CatalogoServizi.Common.MessageBroker;
using CatalogoServizi.Common.Models;
using CatalogoServizi.Common.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CatalogoServizi.Common.Pipeline
{
    /// <summary>
    /// Log Pipeline
    /// </summary>
    /// <typeparam name="Request">Request Type</typeparam>
    /// <typeparam name="Response">Response Type</typeparam>
    public class LogPipeline<Request, Response> : IPipelineBehavior<Request, Response> where Request : IRequest<Response>
    {
        private readonly IMessageSender _sender;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="sender">Sender</param>
        public LogPipeline(IMessageSender sender)
        {
            _sender = sender;
        }

        /// <summary>
        /// Handle
        /// </summary>
        /// <param name="request">request</param>
        /// <param name="next">Next delegate</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns>Response</returns>
        public async Task<Response> Handle(Request request, RequestHandlerDelegate<Response> next, CancellationToken cancellationToken)
        {
            try
            {
                var res = await next();
                //log
                _sender.SendMessage(new LogMessage()
                {
                    Input = JsonSerializer.Serialize(request),
                    Output = JsonSerializer.Serialize(res),
                    EventType = "test",
                    User = "roby"
                }); 
                //await _uow.LogRequest(request);
                //await _uow.SaveChangesAsync();
                return res;
            }
            catch (Exception ex)
            {
                //await _uow.LogException(request, ex);
                //await _uow.SaveChangesAsync();
                throw;
            }



        }
    }
}
