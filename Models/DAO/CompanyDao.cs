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
            foreach (Company item in db.Companies)
            {
                item.Rating = Math.Round(this.CalRating(item.Id), 1);
            }
            db.SaveChanges();
        }
        public List<Company> ListAll()
        {
            return db.Companies.Where(x=> x.Confirm== true).ToList();
        }

        public List<Company> ListTop()
        {
            return db.Companies.Where(x => x.Confirm == true).OrderByDescending(x => x.Rating).Take(4).ToList();
        }

        public List<Company> ListWhere( string name)
        {
            if (!string.IsNullOrEmpty(name))
                return db.Companies.Where(x=>x.Name.Contains(name)).ToList();
            return db.Companies.ToList();
        }

        public Company Choose (int id)
        {
            return db.Companies.SingleOrDefault(x => x.Id.Equals(id));
        }

        public int CountRating (int id)
        {
            return db.Reviews.Count(x => x.ComId == id);
        }

        public float SumRating(int id)
        {
            if (CountRating(id) == 0)
            {
                return 0;
            }
            return (float)db.Reviews.Where(x=> x.ComId == id).Sum(x => x.Rating);
        }

        public float CalRating (int id)
        {
            if (CountRating(id) == 0)
            {
                return 0;
            }
            return (float)(SumRating(id) / CountRating(id));
        }

        public void insert(Company ent_company)
        {
            db.Companies.Add(ent_company);
            db.SaveChanges();
        }
    }
}
