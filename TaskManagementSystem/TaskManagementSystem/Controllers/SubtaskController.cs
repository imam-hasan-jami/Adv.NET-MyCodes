using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaskManagementSystem.Controllers
{
    public class SubtaskController : Controller
    {
        // GET: Subtask
        public ActionResult Index()
        {
            return View();
        }
    }
}