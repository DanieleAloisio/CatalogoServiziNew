using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CatalogoServizi.Common.Repository
{
    /// <summary>
    /// Unit of work base
    /// </summary>
    /// <typeparam name="Context">Context</typeparam>
    public abstract class BaseUnitOfWork<Context> : IBaseUnitOfWork where Context : DbContext
    {
        private readonly Context _context;

        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="context">DB Context</param>
        public BaseUnitOfWork(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Salva su DB Context
        /// </summary>
        /// <returns>Numero record modificati</returns>
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        /// <summary>
        /// Salva su DB Context in modalità asincrona
        /// </summary>
        /// <returns>Numero record modificati</returns>
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }


        /// <summary>
        /// Crea una transazione per la durata della request
        /// </summary>
        /// <returns>Transazione</returns>
        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }

        /// <summary>
        /// Restituisce il numero di entry in attesa di essere inviate al DB
        /// </summary>
        /// <returns>Numero di entry</returns>
        public int HasChanges()
        {
            return _context.ChangeTracker.Entries()
                            .Count(e => e.State == Microsoft.EntityFrameworkCore.EntityState.Added ||
                            e.State == Microsoft.EntityFrameworkCore.EntityState.Modified ||
                            e.State == Microsoft.EntityFrameworkCore.EntityState.Deleted);
        }
    }
}
