using CatalogoServizi.Business.Storage;
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
    public class EditStatoConfigurazioneEmailRequest : IRequest<int>
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// IdStato
        /// </summary>
        public int IdStato { get; set; }
    }

    /// <summary>
    /// Handler
    /// </summary>
    public class EditStatoConfigurazioneEmailHandler : IRequestHandler<EditStatoConfigurazioneEmailRequest, int>
    {
        private readonly UnitOfWork _uof;

        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="uof"></param>
        public EditStatoConfigurazioneEmailHandler(UnitOfWork uof)
        {
            _uof = uof;
        }
        
        /// <summary>
        /// Handle
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<int> Handle(EditStatoConfigurazioneEmailRequest request, CancellationToken cancellationToken)
        { 
            var modelDb = await _uof.EmailManager.GetByPrimaryKey(request.Id);

            if (modelDb == null) return -1;

            modelDb.IsAttivo = Convert.ToBoolean(request.IdStato);

            return await _uof.SaveChangesAsync();
        }
    }

}
