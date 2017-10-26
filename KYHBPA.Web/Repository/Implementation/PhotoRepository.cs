using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace KYHBPA.Repository.Implementation
{
    public class PhotoRepository : BaseRepository<Photo, Guid>, IPhotoRepository
    {
        public PhotoRepository(EntityDbContext context) : base(context)
        {
        }

        public override void Create(Photo photo)
        {
            if (photo.IsNull()) throw new ArgumentNullException(nameof(photo));
            Context.Set<Photo>().Add(photo);
            Context.SaveChanges();
        }

        public override Photo FindById(Guid id)
        {
            return Context.Set<Photo>().Where(o => !o.IsDeleted).FirstOrDefault(o => o.Id == id);
        }
        public override async Task<Photo> FindByIdAsync(Guid id)
        {
            return await Task.FromResult(FindById(id));
        }

        public virtual ICollection<Photo> FindPhotos()
        {
            return Context.Set<Photo>().Where(o => !o.IsDeleted).ToList();
        }
        public async Task<ICollection<Photo>> FindPhotosAsync()
        {
            return await Task.FromResult(FindPhotos());
        }

        public override void Delete(Photo entity)
        {
            if (entity.IsNull()) throw new ArgumentNullException(nameof(entity));
            entity.IsDeleted = true;
            entity.Deleted = DateTime.UtcNow;
            Context.Set<Photo>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public override int Update(Photo entity)
        {
            if (entity.IsNull()) throw new ArgumentNullException(nameof(entity));
            entity.LastModified = DateTime.UtcNow;
            return base.Update(entity);
        }

        public override async Task<int> UpdateAsync(Photo entity)
        {
            if (entity.IsNull()) throw new ArgumentNullException(nameof(entity));
            entity.LastModified = DateTime.UtcNow;
            return await base.UpdateAsync(entity);
        }

        public virtual ICollection<Guid> FindPhotoIds()
        {
            return Context.Set<Photo>().Where(o => !o.IsDeleted).Select(o => o.Id).ToList();
        }
        public async Task<ICollection<Guid>> FindPhotoIdsAsync()
        {
            return await Task.FromResult(FindPhotoIds());
        }

        public ICollection<Guid> FindPhotoGalleryIds()
        {
            return Context.Set<Photo>().Where(o => !o.IsDeleted && o.IsInGallery).Select(o => o.Id).ToList();
        }
        public async Task<ICollection<Guid>> FindPhotoGalleryIdsAsync()
        {
            return await Task.FromResult(FindPhotoGalleryIds());
        }

        public ICollection<Guid> FindDeletedPhotoIds()
        {
            return Context.Set<Photo>().Where(o => o.IsDeleted).Select(o => o.Id).ToList();
        }
        public async Task<ICollection<Guid>> FindDeletedPhotoIdsAsync()
        {
            return await Task.FromResult(FindDeletedPhotoIds());
        }

        public ICollection<Photo> FindDeletedPhotos()
        {
            return Context.Set<Photo>().Where(o => o.IsDeleted).ToList();
        }
        public async Task<ICollection<Photo>> FindDeletedPhotosAsync()
        {
            return await Task.FromResult(FindDeletedPhotos());
        }

        public ICollection<string> FindCollectionKeys()
        {
            return Context.Set<PhotoCollection>().Select(o => o.Key).Distinct().ToList();
        }
        public async Task<ICollection<string>> FindCollectionKeysAsync()
        {
            return await Task.FromResult(FindCollectionKeys());
        }

        public ICollection<string> FindAvailableCollectionKeys()
        {
            return Context.Set<PhotoCollection>().Where(o => o.CollectionSize < o.MaximumCollectionSize).Select(o => o.Key).Distinct().ToList();
        }
        public async Task<ICollection<string>> FindAvailableCollectionKeysAsync()
        {
            return await Task.FromResult(FindAvailableCollectionKeys());
        }

        public Photo FindPhotoByKey(string key)
        {
            return Context.Set<Photo>()
                .SingleOrDefault(o => !o.IsDeleted &&
               o.PhotoCollectionKey.Equals(key, StringComparison.InvariantCultureIgnoreCase));
        }
        public async Task<Photo> FindPhotoByKeyAsync(string key)
        {
            return await Task.FromResult(FindPhotoByKey(key));
        }

        public Guid FindPhotoIdByKey(string key)
        {
            var photoId = Context
                .Set<PhotoCollection>()
                .Include(o=>o.Collection)
                .SingleOrDefault(c => c.Key.Equals(key, StringComparison.InvariantCultureIgnoreCase))
                .Collection.SingleOrDefault().Id;
            return photoId;
        }

        public async Task<Guid> FindPhotoIdByKeyAsync(string key)
        {
            return await Task.FromResult(FindPhotoIdByKey(key));
        }

        public PhotoCollection FindPhotosByKey(string key)
        {
            var photos = Context
                .Set<PhotoCollection>()
                .SingleOrDefault(c => c.Key.Equals(key, StringComparison.InvariantCultureIgnoreCase));
            return photos;
        }
        public async Task<PhotoCollection> FindPhotosByKeyAsync(string key)
        {
            return await Task.FromResult(FindPhotosByKey(key));
        }

        public ICollection<Guid> FindPhotoIdsByKey(string key)
        {
            var photos = Context
                .Set<PhotoCollection>()
                .Where(c => c.Key.Equals(key, StringComparison.InvariantCultureIgnoreCase))
                .SelectMany(o => o.Collection.Select(c => c.Id)).ToList();
            return photos;
        }
        public async Task<ICollection<Guid>> FindPhotoIdsByKeyAsync(string key)
        {
            return await Task.FromResult(FindPhotoIdsByKey(key));
        }
    }
}
