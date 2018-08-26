using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tupperware_e_commerce.Controllers
{
    public class CategorieController : Controller
    {
        // GET: Client
        public ActionResult Create()
        {
            var model = new Categorie();
            return View("../Dashboard/Categorie/Create", model);
        }

        [HttpPost]
        public ActionResult Create(Categorie Categorie)
        {
            using (var db = new TupperwareContext())
            {
                db.Categories.Add(Categorie);
                db.SaveChanges();
            }
            Session["Message"] = "La categoria fue guardada exitosamente";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (var db = new TupperwareContext())
            {
                var Categorie = db.Categories.Find(id);
                return View("../Dashboard/Categorie/Delete", Categorie);
            }
        }

        public ActionResult DeleteConfirmation(int id)
        {
            using (var db = new TupperwareContext())
            {
                var CategorieToRemove = db.Categories.Find(id);
                db.Categories.Remove(CategorieToRemove);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (var db = new TupperwareContext())
            {
                var Categorie = db.Categories.Find(id);
                return View("../Dashboard/Categorie/Edit", Categorie);
            }
        }

        [HttpPost]
        public ActionResult Edit(Categorie Categorie)
        {
            using (var db = new TupperwareContext())
            {
                var CategorieToEdit = db.Categories.Find(Categorie.CategorieId);
                db.Entry(CategorieToEdit).CurrentValues.SetValues(Categorie);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            var Categorie = new List<Categorie>();
            using (var db = new TupperwareContext())
            {
                Categorie = db.Categories.ToList();
            }
                return View("../Dashboard/Categorie/Index", Categorie);
        }
    }
}