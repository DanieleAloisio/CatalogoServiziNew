using CatalogoServizi.Business.Dto;
using CatalogoServizi.Business.Dto.ConfigurazioneEmail;
using CatalogoServizi.Business.Storage;
using CatalogoServizi.Business.Utility;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoServizi.Business.Logic.Email
{
    /// <summary>
    /// Get email by id request
    /// </summary>
    public class GetEmailByIdRequest : ConfigurazioneEmailInput, IRequest<ConfigurazioneEmailOutput>
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
    }

    /// <summary>
    /// Handler
    /// </summary>
    public class GetConfigurazioneEmailHandler : IRequestHandler<GetEmailByIdRequest, ConfigurazioneEmailOutput>
    {
        private readonly UnitOfWork _uof;

        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="uof"></param>
        public GetConfigurazioneEmailHandler(UnitOfWork uof)
        {
            _uof = uof;
        }

        /// <summary>
        /// Handle
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ConfigurazioneEmailOutput> Handle(GetEmailByIdRequest request, CancellationToken cancellationToken)
        {
            return await _uof.EmailManager.GetById(request.Id);
        }
    }
}
