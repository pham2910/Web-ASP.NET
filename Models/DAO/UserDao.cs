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

        public int login (string name, string password)
        {
            var result = db.Admins.SingleOrDefault(x => x.AdminName.Contains(name) && x.Pwd.Contains(password));

            if (result == null)
            {
                return 0;
            }
            else return 1;
        }
    }

    
}
