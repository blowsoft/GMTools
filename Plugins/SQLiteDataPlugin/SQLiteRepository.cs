using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GMTools.Dependencies.DataSet;
using GMTools.Utilities.MEF;
using SQLite;

namespace SineRequieDataPlugin
{
    /// <summary>
    /// Class implementing access to an SQLite database using sqlite-net from praeclarum.
    /// </summary>
    public class SQLiteRepository<TEntity> : IRepository<TEntity> 
        where TEntity : IndexedEntity, new()
    {
        #region Private Properties

        private static readonly string DatabasePath = MefConfigurator.GamesBasePluginDirectory + "SineRequie\\Data\\data.sqlite";
        
        private static readonly SQLiteAsyncConnection SqliteConnection = new SQLiteAsyncConnection(DatabasePath);

        #endregion

        /// <summary>
        /// Generates the table asynchronously.
        /// </summary>
        /// <returns></returns>
        public async Task GenerateTableAsync()
        {
            await SqliteConnection.CreateTableAsync<TEntity>();
        }

        /// <summary>
        /// Gets all the entities in the repository asynchronously.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await SqliteConnection.Table<TEntity>().ToListAsync();
        }

        /// <summary>
        /// Gets the entity with the specified identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<TEntity> GetAsync(int id)
        {
            return await SqliteConnection.Table<TEntity>().Where(entity => entity.Id == id).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Finds the entity which matches the specified expression asynchronously.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns></returns>
        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> match)
        {
            return await SqliteConnection.Table<TEntity>().Where(match).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Finds all the entities which match the specified expression asynchronously.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> match)
        {
            return await SqliteConnection.Table<TEntity>().Where(match).ToListAsync();
        }

        /// <summary>
        /// Adds the specified entity asynchronously.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public async Task AddAsync(TEntity entity)
        {
            await SqliteConnection.InsertAsync(entity);
        }

        /// <summary>
        /// Updates the specified entity asynchronously.
        /// </summary>
        /// <param name="updated">The updated entity.</param>
        /// <returns></returns>
        public async Task<TEntity> UpdateAsync(TEntity updated)
        {
            await SqliteConnection.UpdateAsync(updated);

            return updated;
        }

        /// <summary>
        /// Deletes the specified entity asynchronously.
        /// </summary>
        /// <param name="deleted">The deleted entity.</param>
        /// <returns></returns>
        public async Task DeleteAsync(TEntity deleted)
        {
            await SqliteConnection.DeleteAsync(deleted);
        }
    }
}
