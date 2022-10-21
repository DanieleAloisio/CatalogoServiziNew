using CatalogoServizi.Business.Dto;
using CatalogoServizi.Business.Dto.Utente;
using CatalogoServizi.Business.Logic.Utente;
using CatalogoServizi.Common.Mapping;
using CatalogoServizi.Business.Utility;
using CatalogoServizi.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoServizi.Controllers
{
    /// <summary>
    /// Controller gestione utenti
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class UtenteController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="mediator">Mediator</param>
        public UtenteController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Get all
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DataSource<UtenteOutput>))]
        public async Task<IActionResult> Search([FromQuery] UtenteInput input)
        {
            var response = await _mediator.Send(Mapping<UtenteInput, GetSearchUtenteRequest>.Map(input));
            return Ok(response);
        }

        /// <summary>
        /// Aggiorna utente
        /// </summary>
        /// <param name="idUtente"></param>
        /// <param name="idRuolo"></param>
        /// <returns></returns>
        [HttpPut("{idUtente}/{idRuolo}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UtenteOutput))]
        public async Task<IActionResult> EditUtente([FromRoute] int idUtente, [FromRoute] int idRuolo)
        {
            var response = await _mediator.Send(new EditUtenteRequest() { IdUtente = idUtente, IdRuolo = idRuolo });
            return Ok(response);
        }

        /// <summary>
        /// Elimina utente
        /// </summary>
        /// <param name="idUtente"></param>
        /// <returns></returns>
        [HttpDelete("{idUtente}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UtenteOutput))]
        public async Task<IActionResult> DeleteUtente([FromRoute] int idUtente)
        {
            var response = await _mediator.Send(new DeleteUtenteRequest() { IdUtente = idUtente });
            return Ok(response);
        }
    }
}
