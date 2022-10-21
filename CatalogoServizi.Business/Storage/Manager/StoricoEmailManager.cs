using CatalogoServizi.Business.Data;
using CatalogoServizi.Business.Dto;
using CatalogoServizi.Business.Dto.StoricoEmail;
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
    internal static class StoricoEmailManagerExt
    {
        public static IQueryable<StoricoEmailOutput> GetAllOutput(this IQueryable<StoricoEmail> source)
        {
            var res = source.Include(x => x.ConfigurazioneEmail)
                   .ThenInclude(x => x.TipoEvento)
                   .Include(x => x.StoricoDestinatario)
                   .Select(x => new StoricoEmailOutput()
                   {
                       Id = x.Id,
                       IdConfigurazione = x.IdConfigurazione,
                       Oggetto = x.Oggetto,
                       Testo = x.Testo,
                       DataInvio = x.DataInvio,
                       InvioCorretto = x.InvioCorretto,
                       MessaggioErrore = x.MessaggioErrore
                   });

            return res;
        }

        public static StoricoEmailOutput GetEmailById(this StoricoEmail source)
        {
            return new StoricoEmailOutput()
            {
                Id = source.Id,
                IdConfigurazione = source.IdConfigurazione,
                Oggetto = source.Oggetto,
                Testo = source.Testo,
                DataInvio = source.DataInvio,
                InvioCorretto = source.InvioCorretto,
                MessaggioErrore = source.MessaggioErrore
            };
        }
    }
    /// <summary>
    /// Email Manager
    /// </summary>
    public class StoricoEmailManager : BaseRepository<AppDbContext, StoricoEmail, int>
    {
        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="context"></param>
        public StoricoEmailManager(AppDbContext context) : base(context)
        {
        }
        /// <summary>
        /// Get all
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<DataSource<StoricoEmailOutput>> GetAll(StoricoEmailInput input)
        {
            if (string.IsNullOrEmpty(input.SortBy))
                input.SortBy = "DataInvio";

            return await Context.StoricoEmail.GetAllOutput().FilterAsync(input);
        }

        /// <summary>
        /// Get Email Storico By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<StoricoEmailOutput> GetEmailStoricoById(int id)
        {
            var entity = await Context.StoricoEmail.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                throw new ItemNotFoundException();

            return entity.GetEmailById();
        }
    }
}
