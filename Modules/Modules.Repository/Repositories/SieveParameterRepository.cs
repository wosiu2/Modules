using Modules.Base.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Repository.Repositories
{
    public class SieveParameterRepository : BaseRepository<SieveParameter, ModulesDbContext>
    {
        public override SieveParameter Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
