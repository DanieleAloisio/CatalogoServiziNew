using CatalogoServizi.Business.Data;
using CatalogoServizi.Business.Dto.Utente;
using CatalogoServizi.Business.Exceptions;
using CatalogoServizi.Common.Data;
using CatalogoServizi.Common.Models;
using CatalogoServizi.Common.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoServizi.Business.Storage.Manager
{
    internal static class UtenteManagerrExt
    {
        public static IQueryable<UtenteOutput> ToSearchOutput(this IQueryable<Utente> source)
        {
            return source
                .Select(u => new UtenteOutput()
                {
                    Username = u.Email,
                    DataCreazione = u.DataCreazione,
                    Nome = u.Nome,
                    Cognome = u.Cognome,
                    Email = u.Email,
                    Ruoli = u.Ruoli.Select(x => new KeyValue<int, string>() { Key = x.Id, Value = x.Titolo }).ToList(),
                });
        }
    }

    /// <summary>
    /// Utente manager
    /// </summary>
    public class UtenteManager : BaseRepository<AppDbContext, Utente, int>
    {
        /// <summary>
        /// costruttore
        /// </summary>
        /// <param name="context"></param>
        public UtenteManager(AppDbContext context) : base(context) { }

        /// <summary>
        /// Get All testo libero
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<DataSource<UtenteOutput>> GetAll(UtenteInput input)
        {
            var res = Context.Utente.Include(x => x.Ruoli).AsQueryable();

            if (!string.IsNullOrEmpty(input.TestoLibero))

                res = res.Where(x => x.Nome.Contains(input.TestoLibero) ||
                      x.Cognome.Contains(input.TestoLibero) ||
                      x.AccountRete.Contains(input.TestoLibero) ||
                      x.Email.Contains(input.TestoLibero));

            if (input.IdRuolo != null)
                res = res.Where(p => p.Ruoli.Any(x => x.Id == input.IdRuolo));

            if (input.DataCreazione != null)
                res = res.BetweenDate(l => l.DataCreazione, input.DataCreazione, true);

            if (string.IsNullOrEmpty(input.SortBy))
                input.SortBy = "DataCreazione";

            return await res.ToSearchOutput().FilterAsync(input);

        }

        /// <summary>
        /// Modifica utente
        /// </summary>
        /// <param name="idUtente"></param>
        /// <param name="idRuolo"></param>
        /// <returns></returns>
        /// <exception cref="ItemNotFoundException"></exception>
        public async Task<int> Edit(int idUtente, int idRuolo)
        {
            var utente = await Context.Utente.Include(x => x.Ruoli).FirstOrDefaultAsync(x => x.Id == idUtente);
            var ruolo = await Context.Ruolo.FirstOrDefaultAsync(x => x.Id == idRuolo);

            if (utente != null && ruolo != null)
            {
                utente.Ruoli.Clear();
                utente.Ruoli.Add(ruolo);
            }
            else
            {
                throw new ItemNotFoundException();
            }

            return await Context.SaveChangesAsync();
        }

        /// <summary>
        /// Cancella utente
        /// </summary>
        /// <param name="idUtente"></param>
        /// <returns></returns>
        public async Task<int> Delete(int idUtente)
        {
            var utente = await Context.Utente.Include(x => x.Ruoli).FirstOrDefaultAsync(x => x.Id == idUtente);

            if (utente == null)
                throw new ItemNotFoundException();

            Context.Utente.Attach(utente);
            Context.Utente.Remove(utente);

            return await Context.SaveChangesAsync();
        }
    }
}
