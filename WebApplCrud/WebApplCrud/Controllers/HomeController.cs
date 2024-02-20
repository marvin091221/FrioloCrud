using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplCrud.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var list = new List<user>();
            using (var db = new DBsys32Entities())
            {
                list = db.user.ToList();
            }

            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(user u)
        {
            using (var db = new DBsys32Entities())
            {
                var newUser = new user();
                newUser.username = u.username;
                newUser.password = u.password;

                db.user.Add(newUser);
                db.SaveChanges();

                TempData["msg"] = $"Username {newUser.username} Added successfully!";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Update(int id)
        {
            var u = new user();
            using (var db = new DBsys32Entities())
            {
                u = db.user.Find(id);
            }
            return View(u);
        }

        [HttpPost]
        public ActionResult Update(user u)
        {
            using (var db = new DBsys32Entities())
            {
                var newUser = db.user.Find(u.id);
                newUser.username = u.username;
                newUser.password = u.password;

                //db.user.Add(newUser);
                db.SaveChanges();

                TempData["msg"] = $"Username {newUser.username} has been updated successfully!";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var u = new user();
            using (var db = new DBsys32Entities())
            {
                u = db.user.Find(id);
                db.user.Remove(u);
                db.SaveChanges();

                TempData["msg"] = $"Username {u.username} has been deleted successfully!";
            }
            return RedirectToAction("Index");
        }
    }
}