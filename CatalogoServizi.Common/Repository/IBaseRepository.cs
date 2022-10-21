using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoServizi.Common.Repository
{
    /// <summary>
    /// Base repository
    /// </summary>
    /// <typeparam name="TEntity">Entity Type</typeparam>
    /// <typeparam name="TKey">Key Type</typeparam>
    public interface IBaseRepository<TEntity, TKey> where TEntity : class where TKey : struct
    {
        /// <summary>
        /// Creazione entità
        /// </summary>
        /// <param name="entity">Entità</param>
        void Create(TEntity entity);

        /// <summary>
        /// Elimina un'entità
        /// </summary>
        /// <param name="entity"></param>
        void Delete(TEntity entity);

        /// <summary>
        /// Restituisce l'entità per chiave primaria
        /// </summary>
        /// <param name="primaryKey">Chiave primaria</param>
        /// <returns>Entità</returns>
        Task<TEntity?> GetByPrimaryKey(TKey primaryKey);

        /// <summary>
        /// Genera una lista
        /// </summary>
        /// <returns>Lista di entità</returns>
        List<TEntity> ToList();

        /// <summary>
        /// Genera una lista includendo entità relazionate
        /// </summary>
        /// <param name="include">entità da includere</param>
        /// <returns>Lista </returns>
        List<TEntity> ToListAndInclude(params string[] include);

        /// <summary>
        /// Genera una lista di entità in modalità asincrona
        /// </summary>
        /// <returns>Lista di entità </returns>
        Task<List<TEntity>> ToListAsync();

        /// <summary>
        /// Genera una lista includendo entità relazionate in modo asincrono
        /// </summary>
        /// <param name="include">entità da includere</param>
        /// <returns>Lista </returns>
        Task<List<TEntity>> ToListAndIncludeAsync(params string[] include);
    }
}
