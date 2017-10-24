using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using KYHBPA.Data.Infrastructure;

namespace KYHBPA.Data.Repository
{
    public class PhotoRepository : BaseRepository<Photo, Guid>, IPhotoRepository
    {
        public PhotoRepository(EntityDbContext context) : base(context)
        {
        }

        public virtual void Create(Photo photo)
        {
            if (photo.IsNull()) throw new ArgumentNullException(nameof(photo));
            Context.Set<Photo>().Add(photo);
            Context.SaveChanges();
        }

        public virtual async Task<Photo> FindByIdAsync(Guid id)
        {
            return await Task.FromResult(FindById(id));
        }

        public virtual Photo FindById(Guid id)
        {
            return Context.Set<Photo>().Where(o => !o.IsDeleted).FirstOrDefault(o => o.Id == id);
        }

        public virtual ICollection<Photo> FindEntities()
        {
            return Context.Set<Photo>().Where(o => !o.IsDeleted).ToList();
        }

        public virtual void Delete(Photo entity)
        {
            if (entity.IsNull()) throw new ArgumentNullException(nameof(entity));
            entity.IsDeleted = true;
            entity.Deleted = DateTime.UtcNow;
            Context.Set<Photo>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }
        public virtual void Update(Photo entity)
        {
            if (entity.IsNull()) throw new ArgumentNullException(nameof(entity));
            entity.LastModified = DateTime.UtcNow;
            Context.Set<Photo>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual ICollection<Guid> FindPhotoIds()
        {
            return Context.Set<Photo>().Where(o => !o.IsDeleted).Select(o => o.Id).ToList();
        }

        public async Task<Photo> FindPhotoByKeyAsync(string key)
        {
            return await Task.FromResult(FindPhotoByKey(key));
        }

        public Photo FindPhotoByKey(string key)
        {
            return Context.Set<Photo>()
                .FirstOrDefault(o => !o.IsDeleted &&
               o.PhotoCollection.Any(c => c.Key.Equals(key, StringComparison.InvariantCultureIgnoreCase)));
        }

        public async Task<PhotoCollection> FindPhotosByKeyAsync(string key)
        {
            return await Task.FromResult(FindPhotosByKey(key));
        }

        public PhotoCollection FindPhotosByKey(string key)
        {
            var photos = Context
                .Set<PhotoCollection>()
                .SingleOrDefault(c => c.Key.Equals(key, StringComparison.InvariantCultureIgnoreCase));
            return photos;
        }
    }
}
