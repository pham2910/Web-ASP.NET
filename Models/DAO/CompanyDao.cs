using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class CompanyDao
    {
        private ReviewDbContext db = null;
        public CompanyDao()
        {
            db = new ReviewDbContext();
        }
        public List<Company> ListAll()
        {
            return db.Companies.ToList();
        }
    }
}
