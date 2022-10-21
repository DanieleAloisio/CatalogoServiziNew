using CatalogoServizi.Business.Dto;
using CatalogoServizi.Business.Dto.LogDto;
using CatalogoServizi.Business.Storage;
using CatalogoServizi.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoServizi.Business.Logic.Logging
{
    /// <summary>
    /// Request
    /// </summary>
    public class LogSearchRequest : LogSearchInput, IRequest<DataSource<LogSearchOutput>>
    {

    }

    /// <summary>
    /// Handler
    /// </summary>
    public class LogSearchHandler : IRequestHandler<LogSearchRequest, DataSource<LogSearchOutput>>
    {
        private readonly UnitOfWork _uof;

        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="uof"></param>
        public LogSearchHandler(UnitOfWork uof)
        {
            _uof = uof;
        }

        /// <summary>
        /// Handle
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<DataSource<LogSearchOutput>> Handle(LogSearchRequest request, CancellationToken cancellationToken)
        {
            return await _uof.LogManager.Search(request);
        }
    }

}
