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
            var list = new List<User>();
            using (var db = new DBsys32Entities())
            {
                list = db.User.ToList();
            }

            return View(list);
            //return View(_UserRepo.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User u)
        {
            using (var db = new DBsys32Entities())
            {
                var newUser = new User();
                newUser.username = u.username;
                newUser.password = u.password;

                db.User.Add(newUser);
                db.SaveChanges();

                TempData["msg"] = $"username {newUser.username} Added successfully!";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Update(int id)
        {
            var u = new User();
            using (var db = new DBsys32Entities())
            {
                u = db.User.Find(id);
            }
            return View(u);
        }

        [HttpPost]
        public ActionResult Update(User u)
        {
            using (var db = new DBsys32Entities())
            {
                var newUser = db.User.Find(u.id);
                newUser.username = u.username;
                newUser.password = u.password;

                //db.User.Add(newUser);
                db.SaveChanges();

                TempData["msg"] = $"username {newUser.username} has been updated successfully!";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var u = new User();
            using (var db = new DBsys32Entities())
            {
                u = db.User.Find(id);
                db.User.Remove(u);
                db.SaveChanges();

                TempData["msg"] = $"username {u.username} has been deleted successfully!";
            }
            return RedirectToAction("Index");
        }
    }
}