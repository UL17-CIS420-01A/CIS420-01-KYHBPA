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
        private readonly Entities _context;

        protected BaseRepository(Entities context)
        {
            if (context == null) { throw new ArgumentNullException(nameof(context)); }
            this._context = context;
        }

        protected Entities Context => _context;

        public void Create(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            Context.Set<TEntity>().Add(entity);
        }

        public async Task<TEntity> FindByIdAsync(TKey id)
        {
            return await Task.FromResult(FindById(id));
        }

        public TEntity FindById(TKey id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public ICollection<TEntity> FindEntities()
        {
            return _context.Set<TEntity>().ToList();
        }

        public void Delete(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            Context.Set<TEntity>().Attach(entity);
            Context.Set<TEntity>().Remove(entity);
        }
        public void Update(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            Context.Set<TEntity>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }
    }
}
