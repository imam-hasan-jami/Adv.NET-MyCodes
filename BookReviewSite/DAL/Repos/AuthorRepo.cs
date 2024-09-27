using DAL.EF.TableModels;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class AuthorRepo : Repo, IRepo<Author, int, Author>
    {
        public Author Create(Author obj)
        {
            db.Authors.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);
            db.Authors.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public List<Author> Get()
        {
            return db.Authors.ToList();
        }

        public Author Get(int id)
        {
            return db.Authors.Find(id);
        }

        public Author Update(Author obj)
        {
            var exobj = Get(obj.AuthorId);
            db.Entry(exobj).CurrentValues.SetValues(obj);
            db.SaveChanges();
            return obj;
        }
    }
}
