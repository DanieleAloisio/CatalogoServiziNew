using CatalogoServizi.Business.Dto;
using CatalogoServizi.Business.Dto.Utente;
using CatalogoServizi.Business.Storage;
using CatalogoServizi.Business.Utility;
using CatalogoServizi.Common.Models;
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
    public class GetSearchUtenteRequest : UtenteInput, IRequest<DataSource<UtenteOutput>>
    {
    }

    /// <summary>
    /// Handler
    /// </summary>
    public class GetAllUtenteHandler : IRequestHandler<GetSearchUtenteRequest, DataSource<UtenteOutput>>
    {

        private readonly UnitOfWork _uof;

        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="uof"></param>
        public GetAllUtenteHandler(UnitOfWork uof)
        {
            _uof = uof;
        }

        /// <summary>
        /// Handle
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<DataSource<UtenteOutput>> Handle(GetSearchUtenteRequest request, CancellationToken cancellationToken)
        {
            return await _uof.UtenteManager.GetAll(request);
        }
    }
}
