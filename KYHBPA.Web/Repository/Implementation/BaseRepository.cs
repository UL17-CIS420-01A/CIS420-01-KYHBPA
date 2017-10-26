using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace KYHBPA.Repository.Implementation
{
    public class BaseRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
    {
        private readonly EntityDbContext _context;

        internal BaseRepository(EntityDbContext context)
        {
            if (context.IsNull()) { throw new ArgumentNullException(nameof(context)); }
            this._context = context;
        }

        protected EntityDbContext Context => _context;

        public virtual void Create(TEntity photo)
        {
            if (photo.IsNull()) throw new ArgumentNullException(nameof(photo));
            Context.Set<TEntity>().Add(photo);
            Context.SaveChanges();
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
            if (entity.IsNull()) throw new ArgumentNullException(nameof(entity));
            Context.Set<TEntity>().Attach(entity);
            Context.Set<TEntity>().Remove(entity);
            Context.SaveChanges();
        }
        public virtual int Update(TEntity entity)
        {
            if (entity.IsNull()) throw new ArgumentNullException(nameof(entity));
            Context.Set<TEntity>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
            return Context.SaveChanges();
        }
        public virtual async Task<int> UpdateAsync(TEntity entity)
        {
            if (entity.IsNull()) throw new ArgumentNullException(nameof(entity));
            Context.Set<TEntity>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
            return await Context.SaveChangesAsync();
        }
    }
}
