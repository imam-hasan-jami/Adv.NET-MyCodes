using DAL.EF;
using DAL.EF.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class PersonRepo
    {
        static Context db = new Context();
        public static List<Person> Get()
        {
            /*Dummy data
            List<Person> list = new List<Person>();
            list.Add(new Person() { Id = 1, Name = "P1" });
            list.Add(new Person() { Id = 2, Name = "P2" });
            return list;*/

            return db.Persons.ToList();
        }

        public static Person Get(int id)
        {
            /*find id using singleOrDefault
            var person = db.Persons.SingleOrDefault(x=> x.Id == id);*/

            return db.Persons.Find(id);
        }

        //if return type is void, then use static void
        /*public static void Create(Person p)
        {
            db.Persons.Add(p);
            db.SaveChanges();
        }*/

        //if return type is bool, then use static bool
        public static bool Create(Person p)
        {
            db.Persons.Add(p);
            return db.SaveChanges() > 0;
        }

        public static bool Update(Person p)
        {
            var exobj = Get(p.Id);
            if (exobj != null)
            {
                exobj.Name = p.Name;
                db.SaveChanges();
                return true;
            }
            return false;

            /*var exobj = Get(p.Id);
            db.Entry(exobj).CurrentValues.SetValues(p);
            return db.SaveChanges() > 0;*/
        }

        public static bool Delete(int id)
        {
            var exobj = Get(id);
            if (exobj != null)
            {
                db.Persons.Remove(exobj);
                db.SaveChanges();
                return true;
            }
            return false;

            /*var exobj = Get(id);
            db.Persons.Remove(exobj);
            return db.SaveChanges() > 0;*/
        }
    }
}
