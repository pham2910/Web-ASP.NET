using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class ReviewDAO
    {
        private ReviewDbContext db = null;
        public ReviewDAO()
        {
            db = new ReviewDbContext();
        }
        public List<Review> ListAll(int id)
        {
            return db.Reviews.Where(x=> x.ComId == id).ToList();
        }

        public void insert(Review ent_review)
        {
            db.Reviews.Add(ent_review);
            db.SaveChanges();
        }
    }
}
