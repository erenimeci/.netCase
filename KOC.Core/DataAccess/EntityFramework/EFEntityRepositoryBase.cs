using KOC.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KOC.Core.DataAccess.EntityFramework
{
    public class EFEntityRepositoryBase<TContext, TEntity> : IEntityRepository<TEntity>
        where TContext : DbContext, new()
        where TEntity : class, IEntity, new()
    {
        TContext context = EFDBContextSingleton<TContext>.Instance;

        public void Add(TEntity entity)
        {

            var addEntity = context.Entry(entity);
            addEntity.State = EntityState.Added;
            context.SaveChanges();

        }

        public void Delete(TEntity entity)
        {
            var deleteEntity = context.Entry(entity);
            deleteEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {

            return context.Set<TEntity>().Where(filter).FirstOrDefault();

        }

        public ICollection<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {

            return filter == null ?
                context.Set<TEntity>().ToList() :
               context.Set<TEntity>().Where(filter).ToList();

        }

        public void Update(TEntity entity)
        {

            var updateEntity = context.Entry(entity);
            updateEntity.State = EntityState.Modified;
            context.SaveChanges();

        }
    }
}
