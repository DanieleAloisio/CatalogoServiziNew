using Microsoft.EntityFrameworkCore.Storage;

namespace CatalogoServizi.Common.Repository
{
    /// <summary>
    /// Unit of work base
    /// </summary>
    public interface IBaseUnitOfWork
    {
        /// <summary>
        /// Crea una transazione per la durata della request
        /// </summary>
        /// <returns>Transazione</returns>
        Task<IDbContextTransaction> BeginTransactionAsync();

        /// <summary>
        /// Restituisce il numero di entry in attesa di essere inviate al DB
        /// </summary>
        /// <returns>Numero di entry</returns>
        int HasChanges();

        /// <summary>
        /// Salva su DB Context
        /// </summary>
        /// <returns>Numero record modificati</returns>
        int SaveChanges();

        /// <summary>
        /// Salva su DB Context in modalità asincrona
        /// </summary>
        /// <returns>Numero record modificati</returns>
        Task<int> SaveChangesAsync();
    }
}