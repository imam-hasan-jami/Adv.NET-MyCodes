using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using TaskManagementSystem.Auth;
using TaskManagementSystem.DTOs;
using TaskManagementSystem.EF;

namespace TaskManagementSystem.Controllers
{
    [Logged]
    public class TaskController : Controller
    {
        taskDBEntities db = new taskDBEntities();
        public ActionResult Index(string status = "all", string category = "all")
        {
            var tasks = db.Tasks.ToList();

            if (status.ToLower() != "all")
            {
                tasks = tasks.Where(t => t.Status.Equals(status, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (category.ToLower() != "all")
            {
                int categoryId = ConvertCategoryToId(category);
                tasks = tasks.Where(t => t.CId == categoryId).ToList();
            }

            var convertedTasks = tasks.Select(ConvertTaskToDTO).ToList(); // Assuming you have a method to convert tasks to DTOs
            return View(convertedTasks);
        }

        private int ConvertCategoryToId(string category)
        {
            // Implement this method based on your category naming and ID mapping
            // Example:
            switch (category.ToLower())
            {
                case "category1": return 1; // Assuming '1' is the ID for Category1
                case "category2": return 2; // Assuming '2' is the ID for Category2
                case "category3": return 3; // Assuming '3' is the ID for Category3
                default: return 0; // Default or unknown category
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(TaskDTO t)
        {
            if (ModelState.IsValid)
            {
                var ts = Convert(t);
                db.Tasks.Add(ts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var exobj = db.Tasks.Find(id);
            return View(exobj);

        }
        [HttpPost]
        public ActionResult Edit(Task t)
        {
            var exobj = db.Tasks.Find(t.Id);
            exobj.Name = t.Name;
            exobj.CId = t.CId;
            exobj.Status = t.Status;
            exobj.Markas = t.Markas;
            exobj.Progress = t.Progress;

            //caution in using this method
            //db.Entry(exobj).CurrentValues.SetValues(s);

            //for delete
            //db.Students.Remove(exobj);
            //db.SaveChanges();
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var exobj = db.Tasks.Find(id);
            return View(exobj);
        }
        [HttpPost]
        public ActionResult Delete(Task t)
        {
            var exobj = db.Tasks.Find(t.Id);
            db.Tasks.Remove(exobj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var task = db.Tasks.Include("Subtasks").FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return HttpNotFound();
            }

            var taskDto = ConvertTaskToDTO(task);
            taskDto.Subtasks = task.Subtasks.Select(ConvertSubtaskToDTO).ToList();

            return View(taskDto);
        }

        private static TaskDTO ConvertTaskToDTO(Task t)
        {
            return new TaskDTO
            {
                Id = t.Id,
                Name = t.Name,
                CId = t.CId,
                Status = t.Status,
                Markas = t.Markas,
                Progress = t.Progress,
                Subtasks = t.Subtasks.Select(ConvertSubtaskToDTO).ToList() // Ensure you add a Subtasks property to TaskDTO
            };
        }

        private static SubtaskDTO ConvertSubtaskToDTO(Subtask s)
        {
            return new SubtaskDTO
            {
                Id = s.Id,
                Name = s.Name,
                TId = s.TId
            };
        }
        /*[HttpPost]
        public ActionResult Details(Task t)
        {
            var exobj = db.Tasks.Find(t.Id);
            return View(exobj);
        }*/

        public static TaskDTO Convert(Task t)
        {
            return new TaskDTO()
            {
                Id = t.Id,
                Name = t.Name,
                CId = t.CId,
                Status = t.Status,
                Markas = t.Markas,
                Progress = t.Progress
            };
        }
        public static Task Convert(TaskDTO t)
        {
            return new Task()
            {
                Id = t.Id,
                Name = t.Name,
                CId = t.CId,
                Status = t.Status,
                Markas = t.Markas,
                Progress = t.Progress
            };
        }
        public static List<TaskDTO> Convert(List<Task> tasks)
        {
            var list = new List<TaskDTO>();
            foreach (var t in tasks)
            {
                var ts = Convert(t);
                list.Add(ts);
            }
            return list;
        }
    }
}