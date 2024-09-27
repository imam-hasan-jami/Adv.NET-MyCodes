using DAL.EF.TableModels;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class BookRepo : Repo, IRepo<Book, int, Book>
    {
        public Book Create(Book obj)
        {
            db.Books.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);
            db.Books.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public List<Book> Get()
        {
            return db.Books.ToList();
        }

        public Book Get(int id)
        {
            return db.Books.Find(id);
        }

        public Book Update(Book obj)
        {
            var exobj = Get(obj.BookId);
            db.Entry(exobj).CurrentValues.SetValues(obj);
            db.SaveChanges();
            return obj;
        }
    }
}
