using CatalogoServizi.Common.Models;
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
    /// Request
    /// </summary>
    public class GetAllConfigurazioneEmailRequest : ConfigurazioneEmailInput, IRequest<DataSource<ConfigurazioneEmailOutput>>
    {

    }

    /// <summary>
    /// Handler
    /// </summary>
    public class GetAllConfigurazioneEmailHandler : IRequestHandler<GetAllConfigurazioneEmailRequest, DataSource<ConfigurazioneEmailOutput>>
    {
        private readonly UnitOfWork _uof;

        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="uof"></param>
        public GetAllConfigurazioneEmailHandler(UnitOfWork uof)
        {
            _uof = uof;
        }

        /// <summary>
        /// Handle
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<DataSource<ConfigurazioneEmailOutput>> Handle(GetAllConfigurazioneEmailRequest request, CancellationToken cancellationToken)
        {
            return await _uof.EmailManager.GetAll(request);
        }
    }

}
