using CatalogoServizi.Business.Dto.ConfigurazioneParametro;
using CatalogoServizi.Business.Logic.ConfigurazioneParametro;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoServizi.Controllers;

/// <summary>
/// Gestione configurazione parametri
/// </summary>
[ApiController]
[Route("[controller]")]
public class ConfigurazioneParametroController : ControllerBase
{

    private readonly IMediator _mediator;

    /// <summary>
    /// Costruttore
    /// </summary>
    /// <param name="mediator">Mediator</param>
    public ConfigurazioneParametroController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Restituisce una configurazione per ID
    /// </summary>
    /// <param name="id">ID</param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ConfigurazioneParametroOutput))]
    public async Task<IActionResult> GetConfigurazioneParametro([FromRoute] int id)
    {
        var response = await _mediator.Send(new GetConfigurazioneParametroRequest() { Id = id });
        return Ok(response);
    }

    /// <summary>
    /// Restituisce tutte le configurazioni
    /// </summary>
    /// <returns></returns>
    [HttpGet("all")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ConfigurazioneParametroOutput))]
    public async Task<IActionResult> GetAllConfigurazioneParametro()
    {
        var response = await _mediator.Send(new GetAllConfigurazioneParametroRequest());
        return Ok(response);
    }

    /// <summary>
    /// Aggiorna un parametro
    /// </summary>
    /// <param name="id">Id</param>
    /// <param name="input">Configurazione</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ConfigurazioneParametroOutput))]
    public async Task<IActionResult> EditConfigurazioneParametro([FromRoute] int id, [FromBody] ConfigurazioneParametroInput input)
    {
        var response = await _mediator.Send(new EditConfigurazioneParametroRequest() { Id = id, confParamDto = input });
        return Ok(response);
    }
}
