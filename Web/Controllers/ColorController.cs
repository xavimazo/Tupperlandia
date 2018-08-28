using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tupperware_e_commerce.Controllers
{
    public class ColorController : Controller
    {
        // GET: Product
        public ActionResult Create()
        {
            var model = new Color();
            return View("../Dashboard/Color/Create", model);
        }

        [HttpPost]
        public ActionResult Create(Color Color)
        {
            using (var db = new TupperwareContext())
            {
                if (db.Colors.Any(p => p.ColorDescription == Color.ColorDescription))
                    throw new Exception("Ya se agrego ese color");

                db.Colors.Add(Color);
                db.SaveChanges();
            }

            Session["Message"] = "El nuevo color fue guardado exitosamente";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (var db = new TupperwareContext())
            {
                var color = db.Colors.Find(id);
                return View("../Dashboard/Color/Delete", color);
            }
        }

        public ActionResult DeleteConfirmation(int id)
        {
            using (var db = new TupperwareContext())
            {
                var colorToRemove = db.Colors.Find(id);
                db.Colors.Remove(colorToRemove);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (var db = new TupperwareContext())
            {
                var color = db.Colors.Find(id);
                return View("../Dashboard/Color/Edit", color);
            }
        }

        [HttpPost]
        public ActionResult Edit(Color color)
        {
            using (var db = new TupperwareContext())
            {
                var colorToEdit = db.Colors.Find();
                db.Entry(colorToEdit).CurrentValues.SetValues(color.ColorId);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            var color = new List<Color>();

            using (var db = new TupperwareContext())
            {
                color = db.Colors.ToList();
            }

            return View("../Dashboard/Color/Index", color);
        }
    }
}