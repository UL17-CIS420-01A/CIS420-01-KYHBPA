using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KYHBPA.Repository
{
    public interface IPhotoRepository : IRepository<Photo, Guid>
    {

        ICollection<Photo> FindPhotos();
        Task<ICollection<Photo>> FindPhotosAsync();

        ICollection<Guid> FindPhotoIds();
        Task<ICollection<Guid>> FindPhotoIdsAsync();

        ICollection<Guid> FindPhotoGalleryIds();
        Task<ICollection<Guid>> FindPhotoGalleryIdsAsync();

        ICollection<Guid> FindDeletedPhotoIds();
        Task<ICollection<Guid>> FindDeletedPhotoIdsAsync();

        ICollection<Photo> FindDeletedPhotos();
        Task<ICollection<Photo>> FindDeletedPhotosAsync();


        Photo FindPhotoByKey(string key);
        Task<Photo> FindPhotoByKeyAsync(string key);

        Guid FindPhotoIdByKey(string key);
        Task<Guid> FindPhotoIdByKeyAsync(string key);

        PhotoCollection FindPhotosByKey(string key);
        Task<PhotoCollection> FindPhotosByKeyAsync(string key);

        ICollection<Guid> FindPhotoIdsByKey(string key);
        Task<ICollection<Guid>> FindPhotoIdsByKeyAsync(string key);

        ICollection<string> FindCollectionKeys();
        Task<ICollection<string>> FindCollectionKeysAsync();

        ICollection<string> FindAvailableCollectionKeys();
        Task<ICollection<string>> FindAvailableCollectionKeysAsync();

    }
}