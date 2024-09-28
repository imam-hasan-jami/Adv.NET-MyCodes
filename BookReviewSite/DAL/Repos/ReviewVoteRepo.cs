using DAL.EF.TableModels;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ReviewVoteRepo : Repo, IRepo<ReviewVote, int, ReviewVote>
    {
        public ReviewVote Create(ReviewVote obj)
        {
            db.ReviewVotes.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);
            db.ReviewVotes.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public List<ReviewVote> Get()
        {
            return db.ReviewVotes.ToList();
        }

        public ReviewVote Get(int id)
        {
            return db.ReviewVotes.Find(id);
        }

        public ReviewVote Update(ReviewVote obj)
        {
            var exobj = Get(obj.ReviewVoteId);
            obj.VoteDate = exobj.VoteDate;
            obj.UpdatedDate = DateTime.Now;
            db.Entry(exobj).CurrentValues.SetValues(obj);
            db.SaveChanges();
            return obj;
        }
    }
}
