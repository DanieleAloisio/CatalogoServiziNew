using CatalogoServizi.Business.Data;
using CatalogoServizi.Business.Dto;
using CatalogoServizi.Business.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore.Query;
using CatalogoServizi.Business.Dto.LogDto;
using CatalogoServizi.Business.Exceptions;
using CatalogoServizi.Common.Repository;
using CatalogoServizi.Common.Models;
using CatalogoServizi.Common.Data;

namespace CatalogoServizi.Business.Storage.Manager
{
    internal static class LogManagerExt
    {
        public static IQueryable<Log> Valid(this IQueryable<Log> source)
        {
            return source.Where(l => l.Id > 0);
        }

        public static IQueryable<LogSearchOutput> ToSearchOutput(this IQueryable<Log> source)
        {
            return source
                .Include(l => l.Tipo)
                .Include(l => l.Utente)
                .Select(l => new LogSearchOutput()
                {
                    Id = l.Id,
                    DataEvento = l.DataEvento,
                    Messaggio = l.Messaggio,
                    IdTipo = l.IdTipo.Value,
                    Tipo = l.Tipo.Titolo,
                    Utente = l.Utente.Nome + " " + l.Utente.Cognome
                });
        }
    }

    /// <summary>
    /// Manager
    /// </summary>
    public class LogManager : BaseRepository<AppDbContext, Log, int>
    {
        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="context"></param>
        public LogManager(AppDbContext context) : base(context) { }

        /// <summary>
        /// Search
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="InvalidDataException"></exception>
        public async Task<DataSource<LogSearchOutput>> Search(LogSearchInput input)
        {

            if (input == null)
            {
                throw new InvalidDataException();
            }

            var res = Context.Log.AsQueryable();

            if (!string.IsNullOrEmpty(input.Messaggio))
                res = res.Where(l => l.Messaggio.Contains(input.Messaggio));

            if (input.IdUtente.HasValue)
                res = res.Where(l => l.IdUtente == input.IdUtente);

            if (input.IdTipoEvento.HasValue && input.IdTipoEvento != 0)
                res = res.Where(l => l.IdTipo == input.IdTipoEvento.Value);

            if (input.DataEvento != null)
                res = res.BetweenDate(l => l.DataEvento, input.DataEvento, true);

            if (string.IsNullOrEmpty(input.SortBy))
                input.SortBy = "DataEvento";

            return await res.ToSearchOutput().FilterAsync(input);
        }

        /// <summary>
        /// Get Log by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ItemNotFoundException"></exception>
        public async Task<LogSearchOutput> GetLogById(int id)
        {
            var res = await Context
                .Log
                .Where(l => l.Id == id).ToSearchOutput().FirstOrDefaultAsync();

            if (res == null)
                throw new ItemNotFoundException();

            return res;
        }
    }
}
