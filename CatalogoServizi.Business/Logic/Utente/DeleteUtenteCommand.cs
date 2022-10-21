using CatalogoServizi.Business.Storage;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoServizi.Business.Logic.Utente
{
    /// <summary>
    /// Request
    /// </summary>
    public class DeleteUtenteRequest : IRequest<int>
    {
        /// <summary>
        /// Id utente
        /// </summary>
        public int IdUtente { get; set; }
    }

    /// <summary>
    /// Hanndler
    /// </summary>
    public class DeleteUtenteHandler : IRequestHandler<DeleteUtenteRequest, int>
    {
        private readonly UnitOfWork _uof;

        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="uof"></param>
        public DeleteUtenteHandler(UnitOfWork uof)
        {
            _uof = uof;
        }

        /// <summary>
        /// Handle
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<int> Handle(DeleteUtenteRequest request, CancellationToken cancellationToken)
        {
            return await _uof.UtenteManager.Delete(request.IdUtente);
        }
    }
}
