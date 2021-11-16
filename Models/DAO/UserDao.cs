using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class UserDao
    {
        private ReviewDbContext db;

        public UserDao()
        {
            db = new ReviewDbContext();
        }

        public User login(string user, string password)
        {
            var result = db.Users.SingleOrDefault(x => (x.UserName.Contains(user) || x.Email.Contains(user)) && x.Pwd.Contains(password));

            return result;
        }

        public string insert(User ent_user)
        {
            db.Users.Add(ent_user);
            db.SaveChanges();
            return ent_user.UserName;
        }

        public bool findAccount(string name, string email)
        {
            var result = db.Users.SingleOrDefault(x => x.UserName.Contains(name) || x.Email.Contains(email));
            if (result != null)
                return true;
            return false;
        }

        public int findUserByName(string name)
        {
            var result = db.Users.SingleOrDefault(x => x.UserName.Contains(name));
            if (result != null)
                return result.ID;
            return 0;
        }
    }
}
