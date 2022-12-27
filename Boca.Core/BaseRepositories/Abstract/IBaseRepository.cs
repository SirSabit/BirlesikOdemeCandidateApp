using Boca.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boca.Core.BaseRepositories.Abstract
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// Insert Entity
        /// </summary>
        /// <param name="entity">Generic Object</param>
        /// <returns>int</returns>
        int Insert(TEntity entity);
        /// <summary>
        /// Update Entity
        /// </summary>
        /// <param name="entity">Generic Object</param>
        /// <returns>int</returns>
        int Update(TEntity entity);
        /// <summary>
        /// Returns specified object
        /// </summary>
        /// <param name="expression">expression to filter the entity</param>
        /// <returns>TEntity</returns>
        TEntity GetEntityByExpression(Func<TEntity, bool> expression);
        /// <summary>
        /// Soft deletion of the data based on id
        /// </summary>
        /// <param name="id">id for the data to be deleted</param>
        /// <returns>int</returns>
        int Delete(int id);
        /// <summary>
        /// List of the entity without any parameters
        /// </summary>
        /// <returns>List of the TEntity</returns>
        List<TEntity> GetEntities();
        /// <summary>
        /// List of the entity with expression filter
        /// </summary>
        /// <param name="expression">expression parameter to filter the list</param>
        /// <returns></returns>
        List<TEntity> GetEntities(Func<TEntity, bool> expression);
    }
}
