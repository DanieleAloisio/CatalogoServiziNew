using Microsoft.EntityFrameworkCore;

namespace CatalogoServizi.Common.Repository
{

    /// <summary>
    /// Base repository
    /// </summary>
    /// <typeparam name="TContext">Tipo di context da utilizzare</typeparam>
    /// <typeparam name="TEntity">Entity Type</typeparam>
    /// <typeparam name="TKey">Key Type</typeparam>
    public class BaseRepository<TContext, TEntity, TKey> : IBaseRepository<TEntity, TKey>
        where TContext : DbContext
        where TEntity : class
        where TKey : struct
    {
        /// <summary>
        /// Contesto DB
        /// </summary>
        protected TContext Context { get; private set; }


        /// <summary>
        /// DB set
        /// </summary>
        protected DbSet<TEntity> _dbSet;

        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="context">Context</param>
        public BaseRepository(TContext context)
        {
            Context = context;
            _dbSet = Context.Set<TEntity>();
        }

        /// <summary>
        /// Creazione entit�
        /// </summary>
        /// <param name="entity">Entit�</param>
        public void Create(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        /// <summary>
        /// Elimina un'entit�
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        /// <summary>
        /// Restituisce l'entit� per chiave primaria
        /// </summary>
        /// <param name="primaryKey">Chiave primaria</param>
        /// <returns>Entit�</returns>
        public async Task<TEntity?> GetByPrimaryKey(TKey primaryKey)
        {
            return await _dbSet.FindAsync(primaryKey);
        }

        /// <summary>
        /// Genera una lista
        /// </summary>
        /// <returns>Lista di entit�</returns>
        public List<TEntity> ToList()
        {
            return _dbSet.ToList();
        }

        /// <summary>
        /// Genera una lista di entit� in modalit� asincrona
        /// </summary>
        /// <returns>Lista di entit� </returns>
        public async Task<List<TEntity>> ToListAsync()
        {
            return await _dbSet.ToListAsync();
        }

        /// <summary>
        /// Genera una lista includendo entit� relazionate
        /// </summary>
        /// <param name="include">entit� da includere</param>
        /// <returns>Lista </returns>
        public List<TEntity> ToListAndInclude(params string[] include)
        {
            return Include(include)
                .ToList();
        }

        /// <summary>
        /// Genera una lista includendo entit� relazionate in modo asincrono
        /// </summary>
        /// <param name="include">entit� da includere</param>
        /// <returns>Lista </returns>
        public async Task<List<TEntity>> ToListAndIncludeAsync(params string[] include)
        {
            return await Include(include)
                .ToListAsync();
        }

        private IQueryable<TEntity> Include(params string[] includeProperies)
        {
            return includeProperies
                .Aggregate(_dbSet.AsQueryable(), (current, inc) => current.Include(inc));
        }

    }
}