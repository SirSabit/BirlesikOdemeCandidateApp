using Boca.Core.BaseEntities;
using Boca.Core.BaseRepositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boca.Core.BaseRepositories.Concrete
{
    public class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity>
        where TEntity : BaseEntity
        where TContext : DbContext
    {
        private readonly TContext context;

        public BaseRepository(TContext context)
        {
            this.context = context;
        }

        public int Insert(TEntity entity)
        {
            try
            {
                context.Entry(entity).State = EntityState.Added;
                return context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int Update(TEntity entity)
        {
            try
            {
                context.Entry(entity).State = EntityState.Modified;
                return context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public TEntity GetEntityByExpression(Func<TEntity, bool> expression)
        {
            try
            {
                return context.Set<TEntity>().Where(expression).SingleOrDefault();                                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int Delete(int id)
        {
            try
            {
                var entity = GetEntityByExpression(x => x.Id == id);
                entity.IsDeleted = true;
                context.Entry(entity).State = EntityState.Modified;
                return context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<TEntity> GetEntities()
        {
            try
            {
                return context.Set<TEntity>().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<TEntity> GetEntities(Func<TEntity, bool> expression)
        {
            try
            {
                return context.Set<TEntity>().Where(expression).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
