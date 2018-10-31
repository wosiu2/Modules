using Modules.Base.Model;
using Modules.Base.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Repository
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : BaseModel
    {
        public int Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public int DeleteAll(IEnumerable<TEntity> entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public TEntity GetByIndex(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public int UpdateAll(IEnumerable<TEntity> entity)
        {
            throw new NotImplementedException();
        }
    }
}
