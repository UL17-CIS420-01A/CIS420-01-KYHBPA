using System.Collections.Generic;
using System.Threading.Tasks;

namespace KYHBPA.Repository
{
    public interface IRepository<TEntity, in TKey> where TEntity : class
    {
        void Create(TEntity photo);
        void Delete(TEntity entity);
        Task<TEntity> FindByIdAsync(TKey id);
        TEntity FindById(TKey id);
        ICollection<TEntity> FindEntities();
        int Update(TEntity entity);
        Task<int> UpdateAsync(TEntity entity);

    }
}