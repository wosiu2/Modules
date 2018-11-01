
using System.Collections.Generic;


namespace Modules.Base.Repository
{
    public interface IBaseRepository<TEntity>
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();     
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);
        void DeleteAll();

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Complete();
    }
}
