using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManagementSystem.DTOs;
using TaskManagementSystem.EF;

namespace TaskManagementSystem.Controllers
{
    public class RegistrationController : Controller
    {
        taskDBEntities db = new taskDBEntities();
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(RegistrationDTO r)
        {
            if (ModelState.IsValid)
            {
                var rg = Convert(r);
                db.Users.Add(rg);
                db.SaveChanges();
                return RedirectToAction("Index", "Login");
            }
            return View(r);
        }

        public static RegistrationDTO Convert(User u)
        {
            return new RegistrationDTO()
            {
                Id = u.Id,
                Name = u.Name,
                Pass = u.Pass,
                Type = u.Type
            };
        }
        public static User Convert(RegistrationDTO r)
        {
            return new User()
            {
                Id = r.Id,
                Name = r.Name,
                Pass = r.Pass,
                Type = r.Type
            };
        }
        public static List<RegistrationDTO> Convert(List<User> users)
        {
            var list = new List<RegistrationDTO>();
            foreach (var u in users)
            {
                var rg = Convert(u);
                list.Add(rg);
            }
            return list;
        }
    }
}