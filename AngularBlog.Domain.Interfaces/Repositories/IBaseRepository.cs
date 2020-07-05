using System.Collections.Generic;

namespace AngularBlog.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<in TKey, TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(TKey id);

        bool Create(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(TKey id);
        bool Save();
    }
}