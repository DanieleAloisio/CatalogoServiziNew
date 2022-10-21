using CatalogoServizi.Business.Dto;
using CatalogoServizi.Business.Dto.Common;
using CatalogoServizi.Business.Dto.Servizio;
using CatalogoServizi.Business.Logic.Servizio;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoServizi.Controllers;
/// <summary>
/// Servizio Controller
/// </summary>
[ApiController]
[Route("[controller]")]
public class ServizioController : ControllerBase
{

    private readonly IMediator _mediator;
    /// <summary>
    /// Costruttore
    /// </summary>
    /// <param name="mediator"></param>
    public ServizioController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Crea Servizio
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost("create")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
    public async Task<IActionResult> CreateServizio([FromBody] ServizioInput input)
    {
        var response = await _mediator.Send(new CreaServizioRequest() { Input = input });
        return Ok(response);

    }
}
