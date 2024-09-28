using DAL.EF.TableModels;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class RecommendationRepo : Repo, IRepo<Recommendation, int, Recommendation>
    {
        public Recommendation Create(Recommendation obj)
        {
            db.Recommendations.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);
            db.Recommendations.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public List<Recommendation> Get()
        {
            return db.Recommendations.ToList();
        }

        public Recommendation Get(int id)
        {
            return db.Recommendations.Find(id);
        }

        public Recommendation Update(Recommendation obj)
        {
            var exobj = Get(obj.RecommendationId);
            obj.RecommendationDate = exobj.RecommendationDate;
            obj.UpdatedDate = DateTime.Now;
            db.Entry(exobj).CurrentValues.SetValues(obj);
            db.SaveChanges();
            return obj;
        }
    }
}
