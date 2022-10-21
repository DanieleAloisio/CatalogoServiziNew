using AutoMapper;
using CatalogoServizi.Business.Dto;
using CatalogoServizi.Business.Dto.ConfigurazioneParametro;
using CatalogoServizi.Business.Storage;
using CatalogoServizi.Business.Utility;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoServizi.Business.Logic.ConfigurazioneParametro
{
    /// <summary>
    /// Command
    /// </summary>
    public class EditConfigurazioneParametroRequest : IRequest<int>
    {
        public int Id { get; set; }
        public ConfigurazioneParametroInput confParamDto { get; set; }
    }

    /// <summary>
    /// Handler
    /// </summary>
    public class EditConfigurazioneParametroHandler : IRequestHandler<EditConfigurazioneParametroRequest, int>
    {
        private readonly UnitOfWork _uof;

        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="uof"></param>
        public EditConfigurazioneParametroHandler(UnitOfWork uof)
        {
            _uof = uof;
        }

        /// <summary>
        /// Handle
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<int> Handle(EditConfigurazioneParametroRequest request, CancellationToken cancellationToken)
        {
            var modelDb =  await _uof.ConfigurazioneParametroManager.GetByPrimaryKey(request.Id);

            if (modelDb == null) return -1;

            modelDb.Id = request.Id;
            modelDb.Nome = request.confParamDto.Nome;
            modelDb.Valore = request.confParamDto.Valore;
            modelDb.DataUltimaModifica = DateTime.Now;

            return await _uof.SaveChangesAsync();
        }
    }
}
