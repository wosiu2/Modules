using Modules.Base.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Repository.Repositories
{
    public class SieveMeshRepository : BaseRepository<SieveMesh, ModulesDbContext>
    {
        public override SieveMesh Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
