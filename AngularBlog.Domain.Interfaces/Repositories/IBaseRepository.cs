using System.Collections.Generic;
using System.Threading.Tasks;

namespace AngularBlog.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<in TKey, TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(TKey id);

        Task<bool> CreateAsync(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(TKey id);
    }
}