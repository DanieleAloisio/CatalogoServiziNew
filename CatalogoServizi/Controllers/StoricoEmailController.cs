using CatalogoServizi.Business.Dto;
using CatalogoServizi.Business.Dto.Common;
using CatalogoServizi.Business.Dto.StoricoEmail;
using CatalogoServizi.Business.Logic.StoricoEmail;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoServizi.Controllers
{
    /// <summary>
    /// Storico Email Controller
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class StoricoEmailController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="mediator"></param>
        public StoricoEmailController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(StoricoEmailOutput))]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetAllEmailStoricoInviateRequest());

            return Ok(response);
        }

        /// <summary>
        /// Get email storico by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(StoricoEmailOutput))]
        public async Task<IActionResult> GetEmailStoricoById([FromRoute] int id)
        {
            var response = await _mediator.Send(new GetEmailStoricoByIdRequest() { Id = id });

            return Ok(response);


        }
    }
}
