using CatalogoServizi.Business.Dto;
using CatalogoServizi.Business.Dto.ConfigurazioneParametro;
using CatalogoServizi.Business.Storage;
using CatalogoServizi.Business.Utility;
using CatalogoServizi.Common.Models;
using MediatR;

namespace CatalogoServizi.Business.Logic.ConfigurazioneParametro
{
    /// <summary>
    /// Command
    /// </summary>
    public class GetAllConfigurazioneParametroRequest : IRequest<DataSource<ConfigurazioneParametroOutput>> { }

    /// <summary>
    /// Handler
    /// </summary>
    public class GetAllConfigurazioneParametroHandler : IRequestHandler<GetAllConfigurazioneParametroRequest, DataSource<ConfigurazioneParametroOutput>>
    {
        private readonly UnitOfWork _uof;

        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="uof"></param>
        public GetAllConfigurazioneParametroHandler(UnitOfWork uof)
        {
            _uof = uof;
        }

        /// <summary>
        /// Handle
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<DataSource<ConfigurazioneParametroOutput>> Handle(GetAllConfigurazioneParametroRequest request, CancellationToken cancellationToken)
        {
            var result = await _uof.ConfigurazioneParametroManager.ToListAsync();

            if (result != null)
            {
                var configurazioneParametroDto = new DataSource<ConfigurazioneParametroOutput>();

                foreach (var item in result)
                {
                    configurazioneParametroDto.Data.Add(Mapping<Data.ConfigurazioneParametro, ConfigurazioneParametroOutput>.Map(item));
                }
                return configurazioneParametroDto;
            }

            return new DataSource<ConfigurazioneParametroOutput>();
        }
    }
}
