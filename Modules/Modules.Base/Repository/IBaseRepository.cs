
using System.Collections.Generic;


namespace Modules.Base.Repository
{
    public interface IBaseRepository<TEntity>
    {
        TEntity GetByIndex(int id);
        IEnumerable<TEntity> GetAll();
        int Update(TEntity entity);
        int UpdateAll(IEnumerable<TEntity> entity);
        int Delete(TEntity entity);
        int DeleteAll(IEnumerable<TEntity> entity);
    }
}
