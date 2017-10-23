using System.Threading.Tasks;
namespace KYHBPA.Data.Repository
{
    public interface IRepository<TEntity, in TKey> where TEntity : class
    {
        void Create(TEntity entity);
        void Delete(TEntity entity);
        Task<TEntity> FindByIdAsync(TKey id);
        TEntity FindById(TKey id);
        void Update(TEntity entity);
    }
}