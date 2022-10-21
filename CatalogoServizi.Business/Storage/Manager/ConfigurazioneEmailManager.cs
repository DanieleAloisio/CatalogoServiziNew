using CatalogoServizi.Business.Data;
using CatalogoServizi.Business.Dto.ConfigurazioneEmail;
using CatalogoServizi.Business.Exceptions;
using CatalogoServizi.Common.Data;
using CatalogoServizi.Common.Models;
using CatalogoServizi.Common.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoServizi.Business.Storage.Manager
{
    internal static class ConfigurazioneEmailManagerExt
    {
        public static IQueryable<ConfigurazioneEmailOutput> GetAllOutput(this IQueryable<ConfigurazioneEmail> source)
        {


            source.Include(x => x.StoricoEmail);

            return source.Select(x => new ConfigurazioneEmailOutput()
            {
                TipoEvento = x.TipoEvento.Titolo,
                IdAutoreUltimaModifica = x.IdAutoreModifica,
                DataUltimaModifica = x.DataUltimaModifica,
                IsAttivo = x.IsAttivo,
                CountMessage = source.GroupBy(x => x.Id).Count(),


            });
        }

        public static ConfigurazioneEmailOutput GetByIdOutput(this ConfigurazioneEmail source)
        {

            ConfigurazioneEmailOutput c = new ConfigurazioneEmailOutput()
            {
                IdAutoreUltimaModifica = source.IdAutoreModifica,
                TipoEvento = source.TipoEvento.Titolo,
                Oggetto = source.Oggetto,
                Testo = source.Testo,
                IsAttivo = source.IsAttivo
            };

            return c;
        }
    }

    /// <summary>
    /// Manager
    /// </summary>
    public class ConfigurazioneEmailManager : BaseRepository<AppDbContext, ConfigurazioneEmail, int>
    {
        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="context"></param>
        public ConfigurazioneEmailManager(AppDbContext context) : base(context) { }

        /// <summary>
        /// Get All
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="InvalidDataException"></exception>
        public async Task<DataSource<ConfigurazioneEmailOutput>> GetAll(ConfigurazioneEmailInput input)
        {
            if (input == null)
            {
                throw new InvalidDataException();
            }

            if (string.IsNullOrEmpty(input.SortBy))
                input.SortBy = "DataUltimaModifica";

            var res = await Context.ConfigurazioneEmail
                            .Include(c => c.TipoEvento)
                            .Include(x => x.StoricoEmail)
                            .ToListAsync();

            List<ConfigurazioneEmailOutput> output = new List<ConfigurazioneEmailOutput>();

            foreach (var item in res)
            {
                output.Add(new ConfigurazioneEmailOutput
                {
                    IdAutoreUltimaModifica = item.Id,
                    IsAttivo = item.IsAttivo,
                    Oggetto = item.Oggetto,
                    Testo = item.Testo,
                    CountMessage = item.StoricoEmail?.Count(),
                    TipoEvento = item.TipoEvento.Titolo,
                    DataUltimaModifica = item.DataUltimaModifica
                });
            }

            return output.AsQueryable().Filter(input);
        }

        /// <summary>
        /// Get by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ItemNotFoundException"></exception>
        public async Task<ConfigurazioneEmailOutput> GetById(int id)
        {
            var res = await Context
                .ConfigurazioneEmail
                .Include(x => x.TipoEvento)
                .Include(x => x.Destinatario)
                .Include(x => x.Tag)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (res == null)
                throw new ItemNotFoundException();

            return res.GetByIdOutput();
        }
    }
}