using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.DataAccess.EntityFramework
{
    // Repository pattern implementation for EntityFramework with Linq

    /// <summary>This method implements repository pattern for
    /// EntityFramework.</summary>
    /// <param name="TEntity">table</param>
    /// <param name="Tcontext">database name</param>
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
            where TEntity : class, IEntity, new()
            where TContext : DbContext, new()
    {
        /// <summary>This method returns all elements of
        /// a table.</summary>
        /// <param name="filter">filter parameter</param>
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return
                    filter == null
                        ? context.Set<TEntity>().ToList()
                        : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        /// <summary>This method returns a specific element from a table.</summary>
        /// <param name="filter">filter parameter</param>
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        /// <summary>This method adds a new record to a table</summary>
        /// <param name="entity">table</param>
        public void Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        /// <summary>This method updates the specific record from a table</summary>
        /// <param name="entity">table</param>
        public void Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        /// <summary>This method removes a specific record from a table</summary>
        /// <param name="entity">table</param>
        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
