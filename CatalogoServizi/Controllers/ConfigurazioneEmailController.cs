using CatalogoServizi.Business.Dto;
using CatalogoServizi.Business.Dto.Common;
using CatalogoServizi.Business.Dto.ConfigurazioneEmail;
using CatalogoServizi.Business.Logic.Email;
using CatalogoServizi.Business.Logic.Logging;
using CatalogoServizi.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoServizi.Controllers
{
    /// <summary>
    /// Controller
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ConfigurazioneEmailController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Controller
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="logger"></param>
        public ConfigurazioneEmailController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get All
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DataSource<ConfigurazioneEmailOutput>))]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetAllConfigurazioneEmailRequest());
            return Ok(response);
        }

        /// <summary>
        /// Get Email by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ConfigurazioneEmailOutput))]
        public async Task<IActionResult> GetEmailById([FromRoute] int id)
        {
            var response = await _mediator.Send(new GetEmailByIdRequest { Id = id });
            return Ok(response);
        }

        /// <summary>
        /// Edit stato email
        /// </summary>
        /// <param name="id"></param>
        /// <param name="stato"></param>
        /// <returns></returns>
        [HttpPut("{id}/{stato}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        public async Task<IActionResult> EditStatoEmail([FromRoute] int id, [FromRoute] int stato)
        {
            var response = await _mediator.Send(new EditStatoConfigurazioneEmailRequest() { Id = id, IdStato = stato });
            return Ok(response);
        }

    }
}
