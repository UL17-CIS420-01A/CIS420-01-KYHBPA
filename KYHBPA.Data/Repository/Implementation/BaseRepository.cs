using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using KYHBPA.Data.Infrastructure;

namespace KYHBPA.Data.Repository
{
    public class BaseRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
    {
        private readonly EntityDbContext _context;

        internal BaseRepository(EntityDbContext context)
        {
            if (context == null) { throw new ArgumentNullException(nameof(context)); }
            this._context = context;
        }

        protected EntityDbContext Context => _context;

        public virtual void Create(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            Context.Set<TEntity>().Add(entity);
        }

        public virtual async Task<TEntity> FindByIdAsync(TKey id)
        {
            return await Task.FromResult(FindById(id));
        }

        public virtual TEntity FindById(TKey id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public virtual ICollection<TEntity> FindEntities()
        {
            return _context.Set<TEntity>().ToList();
        }

        public virtual void Delete(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            Context.Set<TEntity>().Attach(entity);
            Context.Set<TEntity>().Remove(entity);
        }
        public virtual void Update(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            Context.Set<TEntity>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }
    }
}
