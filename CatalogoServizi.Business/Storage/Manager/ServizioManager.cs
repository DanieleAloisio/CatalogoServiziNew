using CatalogoServizi.Business.Data;
using CatalogoServizi.Common.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoServizi.Business.Storage.Manager
{
    /// <summary>
    /// Servizio Manager
    /// </summary>
    public class ServizioManager : BaseRepository<AppDbContext, Servizio, int>
    {
        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="context"></param>
        public ServizioManager(AppDbContext context) : base(context)
        {
        }

    }
}
