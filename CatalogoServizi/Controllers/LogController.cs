using CatalogoServizi.Business;
using CatalogoServizi.Business.Dto;
using CatalogoServizi.Business.Dto.Common;
using CatalogoServizi.Business.Dto.LogDto;
using CatalogoServizi.Business.Logic.Logging;
using CatalogoServizi.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoServizi.Controllers
{
    /// <summary>
    /// Gestione del Log
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="mediator"></param>
        public LogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Restituisce un log by id 
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>risultato</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LogSearchOutput))]
        public async Task<IActionResult> GetLogById([FromRoute] int id)
        {
            var response = await _mediator.Send( new GetLogByIdRequest() { Id = id });
            return Ok(response);
        }

        /// <summary>
        /// Ricerca
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("search")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DataSource<LogSearchOutput>))]
        public async Task<IActionResult> Search([FromRoute]LogSearchRequest input)
        {
            var response = await _mediator.Send( input);
            return Ok(response);
        }
    }
}
