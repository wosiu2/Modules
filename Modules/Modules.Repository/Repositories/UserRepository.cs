using Modules.Base.Model;

using System.Linq;


namespace Modules.Repository
{
    public class UserRepository : BaseRepository<User, ModulesDbContext>
    {
        public override User Get(int id)
        {
            return GetAll().Where(n => n.Id == id).SingleOrDefault();
        }
    }
}
