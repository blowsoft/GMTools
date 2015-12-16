using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GMTools.Dependencies.DataSet
{
    /// <summary>
    /// Interface for a single repository for a single entity in the data-set. It provides the base CRUD functions.
    /// </summary>
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Gets all the entities in the repository.
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Gets all the entities in the repository asynchronously.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAllAsync(); 

        /// <summary>
        /// Gets the entity with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        TEntity Get(int id);

        /// <summary>
        /// Gets the entity with the specified identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<TEntity> GetAsync(int id);

        /// <summary>
        /// Finds the entity which matches the specified expression.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns></returns>
        TEntity Find(Expression<Func<TEntity, bool>> match);

        /// <summary>
        /// Finds the entity which matches the specified expression asynchronously.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns></returns>
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> match);

        /// <summary>
        /// Finds all the entities which match the specified expression.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns></returns>
        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> match);

        /// <summary>
        /// Finds all the entities which match the specified expression asynchronously.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> match);

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Add(TEntity entity);

        /// <summary>
        /// Adds the specified entity asynchronously.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        Task AddAsync(TEntity entity);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="updated">The updated entity.</param>
        /// <returns></returns>
        TEntity Update(TEntity updated);

        /// <summary>
        /// Updates the specified entity asynchronously.
        /// </summary>
        /// <param name="updated">The updated entity.</param>
        /// <returns></returns>
        Task<TEntity> UpdateAsync(TEntity updated);

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="deleted">The deleted entity.</param>
        void Delete(TEntity deleted);

        /// <summary>
        /// Deletes the specified entity asynchronously.
        /// </summary>
        /// <param name="deleted">The deleted entity.</param>
        /// <returns></returns>
        Task DeleteAsync(TEntity deleted);
    }
}
