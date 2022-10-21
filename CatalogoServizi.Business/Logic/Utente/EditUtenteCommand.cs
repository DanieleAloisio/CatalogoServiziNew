using CatalogoServizi.Business.Dto.Utente;
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
    public class EditUtenteRequest : IRequest<int>
    {
        /// <summary>
        /// IdUtente
        /// </summary>
        public int IdUtente { get; set; }

        /// <summary>
        /// IdRuolo
        /// </summary>
        public int IdRuolo { get; set; }
    }

    /// <summary>
    /// Handler
    /// </summary>
    public class EditUtenteHandler : IRequestHandler<EditUtenteRequest, int>
    {
        private readonly UnitOfWork _uof;

        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="uof"></param>
        public EditUtenteHandler(UnitOfWork uof)
        {
            _uof = uof;
        }

        /// <summary>
        /// Handle
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<int> Handle(EditUtenteRequest request, CancellationToken cancellationToken)
        {
            return await _uof.UtenteManager.Edit(request.IdUtente, request.IdRuolo);
        }
    }
}
