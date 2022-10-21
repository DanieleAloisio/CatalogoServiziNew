using CatalogoServizi.Business.Dto;
using CatalogoServizi.Business.Dto.LogDto;
using CatalogoServizi.Business.Exceptions;
using CatalogoServizi.Business.Storage;
using CatalogoServizi.Business.Utility;
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
    public class GetLogByIdRequest : IRequest<LogSearchOutput>
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
    }

    /// <summary>
    /// Handler
    /// </summary>
    public class GetLogByIdHandler : IRequestHandler<GetLogByIdRequest, LogSearchOutput>
    {
        private readonly UnitOfWork _uof;

        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="uof"></param>
        public GetLogByIdHandler(UnitOfWork uof)
        {
            _uof = uof;
        }

        /// <summary>
        /// Handle
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ItemNotFoundException"></exception>
        public async Task<LogSearchOutput> Handle(GetLogByIdRequest request, CancellationToken cancellationToken)
        {
            var result = await _uof.LogManager.GetLogById(request.Id);
            if (result == null)
                throw new ItemNotFoundException();

            return result;
        }
    }

}
