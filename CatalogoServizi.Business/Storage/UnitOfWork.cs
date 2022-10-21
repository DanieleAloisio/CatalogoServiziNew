using CatalogoServizi.Business.Data;
using CatalogoServizi.Business.Storage.Manager;
using CatalogoServizi.Common.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CatalogoServizi.Business.Storage
{
    /// <summary>
    /// Unit of work
    /// </summary>
    public class UnitOfWork : BaseUnitOfWork<AppDbContext>
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// Manager dei servizi
        /// </summary>
        public ServizioManager ServizioManager
        {
            get
            {
                return new ServizioManager(_context);
            }
        }

        /// <summary>
        /// Manager dei parametri
        /// </summary>
        public ConfigurazioneParametroManager ConfigurazioneParametroManager
        {
            get
            {
                return new ConfigurazioneParametroManager(_context);
            }
        }

        /// <summary>
        /// Manager dei log
        /// </summary>
        public LogManager LogManager
        {
            get
            {
                return new LogManager(_context);
            }
        }

        /// <summary>
        /// Email manager
        /// </summary>
        public ConfigurazioneEmailManager EmailManager
        {
            get
            {
                return new ConfigurazioneEmailManager(_context);
            }
        }

        /// <summary>
        /// Manager storico email
        /// </summary>
        public StoricoEmailManager StoricoEmailManager
        {
            get
            {
                return new StoricoEmailManager(_context);
            }
        }

        /// <summary>
        /// Manager utenti
        /// </summary>
        public UtenteManager UtenteManager
        {
            get
            {
                return new UtenteManager(_context);
            }
        }


        /// <summary>
        /// Tracciatura log
        /// </summary>
        /// <typeparam name="Request">Tipo Richiesta</typeparam>
        /// <param name="request">Richiesta</param>
        /// <param name="ex"></param>
        /// <returns></returns>
        public async Task LogException<Request>(Request request, Exception ex)
        {

            await _context.Log.AddAsync(new Log()
            {
                DataEvento = DateTime.Now,
                InputData = JsonSerializer.Serialize(request),
                Messaggio = ex.Message,
                IsError = true,
                StackTrace = String.IsNullOrEmpty(ex.StackTrace) ? "" : ex.StackTrace
            });
        }

        /// <summary>
        /// Log di una richiesta
        /// </summary>
        /// <typeparam name="Request">Tipo Richiesta</typeparam>
        /// <param name="request">Richiesta</param>
        /// <returns>Task</returns>
        public async Task LogRequest<Request>(Request request)
        {
            await _context.Log.AddAsync(new Log()
            {
                DataEvento = DateTime.Now,
                Messaggio = $"Evento {typeof(Request).Name}",
                InputData = JsonSerializer.Serialize(request)
            });
        }

    }
}
