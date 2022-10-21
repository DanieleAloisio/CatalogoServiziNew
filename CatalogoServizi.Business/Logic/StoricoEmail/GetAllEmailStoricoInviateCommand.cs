using CatalogoServizi.Common.Models;
using CatalogoServizi.Business.Dto.StoricoEmail;
using CatalogoServizi.Business.Storage;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoServizi.Business.Logic.StoricoEmail
{
    /// <summary>
    /// Request
    /// </summary>
    public class GetAllEmailStoricoInviateRequest : StoricoEmailInput, IRequest<DataSource<StoricoEmailOutput>>
    {

    }

    /// <summary>
    /// Handler
    /// </summary>
    public class GetAllEmailStoricoInviateHandler : IRequestHandler<GetAllEmailStoricoInviateRequest, DataSource<StoricoEmailOutput>>
    {
        private readonly UnitOfWork _uof;

        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="uof"></param>
        public GetAllEmailStoricoInviateHandler(UnitOfWork uof)
        {
            _uof = uof;
        }

        /// <summary>
        /// Handle
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<DataSource<StoricoEmailOutput>> Handle(GetAllEmailStoricoInviateRequest request, CancellationToken cancellationToken)
        {
            return await _uof.StoricoEmailManager.GetAll(request);
        }
    }
}
