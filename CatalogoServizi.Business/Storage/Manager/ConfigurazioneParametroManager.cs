using CatalogoServizi.Business.Data;
using CatalogoServizi.Common.Repository;

namespace CatalogoServizi.Business.Storage.Manager
{
    /// <summary>
    /// Manager
    /// </summary>
    public class ConfigurazioneParametroManager : BaseRepository<AppDbContext,ConfigurazioneParametro, int>
    {
        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="context"></param>
        public ConfigurazioneParametroManager(AppDbContext context) : base(context)
        {
        }

        //Qui dichiari metodi specifici del Parametro Manager
    }
}
