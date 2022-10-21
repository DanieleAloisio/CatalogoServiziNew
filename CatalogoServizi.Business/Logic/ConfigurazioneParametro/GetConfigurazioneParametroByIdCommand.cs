using AutoMapper;
using CatalogoServizi.Business.Dto;
using CatalogoServizi.Business.Dto.ConfigurazioneParametro;
using CatalogoServizi.Business.Storage;
using CatalogoServizi.Business.Utility;
using MediatR;

namespace CatalogoServizi.Business.Logic.ConfigurazioneParametro
{
    /// <summary>
    /// Command
    /// </summary>
    public class GetConfigurazioneParametroRequest : IRequest<ConfigurazioneParametroOutput>
    {
        public int Id { get; set; }
    }

    /// <summary>
    /// Handler
    /// </summary>
    public class GetConfigurazioneParametroHandler : IRequestHandler<GetConfigurazioneParametroRequest, ConfigurazioneParametroOutput>
    {
        private readonly UnitOfWork _uof;

        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="uof"></param>
        public GetConfigurazioneParametroHandler(UnitOfWork uof)
        {
            _uof = uof;
        }

        /// <summary>
        /// Handle
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ConfigurazioneParametroOutput> Handle(GetConfigurazioneParametroRequest request, CancellationToken cancellationToken)
        {
            ConfigurazioneParametroOutput configurazioneParametroDto = null;
            var result = await _uof.ConfigurazioneParametroManager.GetByPrimaryKey(request.Id);

            if (result != null)
            {
                configurazioneParametroDto = Mapping<Data.ConfigurazioneParametro, ConfigurazioneParametroOutput>.Map(result);
            }

            return configurazioneParametroDto;
        }

    }
}
