using Modules.Base.Model;
using System;
using System.Linq;


namespace Modules.Repository
{
    public class UserRepository : BaseRepository<User, ModulesDbContext>
    {
        public override User Get(int id)
        {
            return GetAll().Where(n => n.Id == id).SingleOrDefault();
        }

        public User GetByCredentials(string login,string passwd)
        {
            return GetAll().Where(n => n.Login.Equals(login)&& n.Passwd.Equals(passwd)).SingleOrDefault();
        }

        public User GetByCookie(string cookie)
        {
            if (cookie==null) return null;
            return GetAll().Where(n => n.Cookie.ToString().Equals(cookie)).SingleOrDefault();
        }
    }
}
