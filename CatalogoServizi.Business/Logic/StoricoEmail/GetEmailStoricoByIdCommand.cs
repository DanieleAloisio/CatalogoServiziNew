using CatalogoServizi.Business.Dto;
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
    public class GetEmailStoricoByIdRequest : IRequest<StoricoEmailOutput>
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
    }

    /// <summary>
    /// Handler
    /// </summary>
    public class GetEmailStoricoHandler : IRequestHandler<GetEmailStoricoByIdRequest, StoricoEmailOutput>
    {
        private readonly UnitOfWork _uof;

        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="uof"></param>
        public GetEmailStoricoHandler(UnitOfWork uof)
        {
            _uof = uof;
        }

        /// <summary>
        /// Handle
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<StoricoEmailOutput> Handle(GetEmailStoricoByIdRequest request, CancellationToken cancellationToken)
        {
            return await _uof.StoricoEmailManager.GetEmailStoricoById(request.Id);
        }
    }
}
