using CatalogoServizi.Common.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoServizi.Common.Pipeline
{
    /// <summary>
    /// Transaction Pipeline
    /// </summary>
    /// <typeparam name="Request">Request</typeparam>
    /// <typeparam name="Response">Response</typeparam>
    public class TransactionPipeline< Request, Response> : IPipelineBehavior<Request, Response> where Request : IRequest<Response>
    {
        private readonly IBaseUnitOfWork _uow;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="uow">Repository</param>
        public TransactionPipeline(IBaseUnitOfWork uow)
        {
            _uow = uow;
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
            using var tx = await _uow.BeginTransactionAsync();

            try
            {
                var res = await next();

                tx.Commit();

                return res;
            }
            catch 
            {
                tx.Rollback();
                throw;
            }
        }
    }
}
