using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManagementSystem.DTOs;
using TaskManagementSystem.EF;

namespace TaskManagementSystem.Controllers
{
    public class LoginController : Controller
    {
        taskDBEntities db = new taskDBEntities();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginDTO l)
        {
            if (ModelState.IsValid)
            {
                var user = (from u in db.Users
                            where u.Name.Equals(l.Name) &&
                            u.Pass.Equals(l.Password)
                            select u).SingleOrDefault();
                if (user == null)
                {
                    TempData["Msg"] = "User not found / Name Password mismatch";
                    return RedirectToAction("Index");
                }
                Session["user"] = user;
                TempData["Msg"] = "Login Successfull";
                if (user.Type.Equals("Admin"))
                {
                    return RedirectToAction("Index", "Task");
                }
                return RedirectToAction("Index", "Home");
            }
            return View(l);
        }
    }
}