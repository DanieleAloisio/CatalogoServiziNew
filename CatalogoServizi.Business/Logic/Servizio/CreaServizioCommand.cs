using CatalogoServizi.Business.Data;
using MediatR;
using CatalogoServizi.Business.Storage;
using CatalogoServizi.Business.Dto;
using CatalogoServizi.Business.Utility;
using CatalogoServizi.Business.Logic.Servizio;
using CatalogoServizi.Business.Dto.Servizio;

namespace CatalogoServizi.Business.Logic.Servizio;

/// <summary>
/// Command
/// </summary>
public class CreaServizioRequest : IRequest<int>
{
    /// <summary>
    /// Input
    /// </summary>
    public ServizioInput Input { get; set; }
}


/// <summary>
/// Handler
/// </summary>
public class CreaServizioHandler : IRequestHandler<CreaServizioRequest, int>
{
    private readonly UnitOfWork _uof;

    /// <summary>
    /// Handler
    /// </summary>
    /// <param name="uof"></param>
    public CreaServizioHandler(UnitOfWork uof)
    {
        _uof = uof;
    }

    /// <summary>
    /// Handle
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<int> Handle(CreaServizioRequest request, CancellationToken cancellationToken)
    {
#warning Si recuperare l'utente che fa la richiesta

        var utente = await _uof.UtenteManager.GetByPrimaryKey(request.Input.IdUtente);

        if (utente != null)
        {
            Data.Servizio servizio = new Data.Servizio()
            {
                Nome = request.Input.Nome,
                Url = request.Input.Url,
                InizioPubblicazione = request.Input.InizioPubblicazione,
                DataFinePubblicazione = null,
                Canc = request.Input.Canc,
                IdAutoreCensimento = request.Input.IdUtente,
                Utente = utente
            };

            _uof.ServizioManager.Create(servizio);
            return await _uof.SaveChangesAsync();
        }
        return 0;
    }
}