using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class IndustryDAO
    {
        private ReviewDbContext db;

        public IndustryDAO ()
        {
            db = new ReviewDbContext();
        }

        public List<Field> ListIndustry()
        {
            return db.Fields.ToList();
        }

        

        public int findIndustryByName(string industry)
        {
            var result = db.Fields.SingleOrDefault(x => x.FieldName.Equals(industry));
            if (result != null)
                return result.ID;
            return 0;
        }

    }
}
