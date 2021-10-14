using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class AdminDao
    {
        private ReviewDbContext db;

        public AdminDao ()
        {
            db = new ReviewDbContext();
        }

        public int login (string name, string password)
        {
            var res = db.Admins.SingleOrDefault(x => x.AdminName.Contains(name) && x.Pwd.Contains(password));

            if (res == null)
            {
                return 0;
            }
            return 1;
        }
    }
}
