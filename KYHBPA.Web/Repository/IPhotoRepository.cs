using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace KYHBPA.Data.Repository
{
    public interface IPhotoRepository : IRepository<Photo, Guid>
    {
        Task<Photo> FindPhotoByKeyAsync(string key);
        Photo FindPhotoByKey(string key);

        Task<PhotoCollection> FindPhotosByKeyAsync(string key);
        PhotoCollection FindPhotosByKey(string key);

        ICollection<Guid> FindPhotoIds();
    }
}