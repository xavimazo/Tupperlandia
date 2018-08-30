using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tupperware_e_commerce.Models;
using System.Data.Entity;

namespace Tupperware_e_commerce.Controllers
{
    public class UserController : Controller
    {
        // GET: Client
        public ActionResult Create()
        {
            var model = new User();
            return View("../Dashboard/User/Create", model);
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            using (var db = new TupperwareContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
            Session["Message"] = "El usuario fue guardado exitosamente";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (var db = new TupperwareContext())
            {
                var user = db.Users.Find(id);
                return View("../Dashboard/User/Delete", user);
            }
        }

        public ActionResult DeleteConfirmation(int id)
        {
            using (var db = new TupperwareContext())
            {
                var UserToRemove = db.Users.Find(id);
                try
                {
                    db.Users.Remove(UserToRemove);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    Session["Message"] = "No se puede eliminar";
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (var db = new TupperwareContext())
            {
                var user = db.Users.FirstOrDefault(s => s.UserId == id);
                return View("../Dashboard/User/Edit", user);
            }
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            using (var db = new TupperwareContext())
            {
                var UserToEdit = db.Users.Find(user.UserId);
                db.Entry(UserToEdit).CurrentValues.SetValues(user);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            var user = new List<User>();
            using (var db = new TupperwareContext())
            {
                user = db.Users.ToList();
            }
            return View("../Dashboard/User/Index", user);
        }
    }
}