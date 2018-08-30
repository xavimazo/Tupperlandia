using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tupperware_e_commerce.Controllers
{
    public class DescriptionController : Controller
    {
        // GET: Product
        public ActionResult Create()
        {
            var model = new Description();
            return View("../Dashboard/Description/Create", model);
        }

        [HttpPost]
        public ActionResult Create(Description description)
        {
            using (var db = new TupperwareContext())
            {
                if (db.Descriptions.Any(p => p.DescriptionText == description.DescriptionText))
                    throw new Exception("Ya se agrego una descripcion");

                db.Descriptions.Add(description);
                db.SaveChanges();
            }

            Session["Message"] = "La descripcion fue guardada exitosamente";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (var db = new TupperwareContext())
            {
                var description = db.Descriptions.Find(id);
                return View("../Dashboard/Description/Delete", description);
            }
        }

        public ActionResult DeleteConfirmation(int id)
        {
            using (var db = new TupperwareContext())
            {
                var descriptionToRemove = db.Descriptions.Find(id);
                try
                {
                    db.Descriptions.Remove(descriptionToRemove);
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
                var description = db.Descriptions.Find(id);
                return View("../Dashboard/Description/Edit", description);
            }
        }

        [HttpPost]
        public ActionResult Edit(Description description)
        {
            using (var db = new TupperwareContext())
            {
                var descriptionToEdit = db.Descriptions.Find(description.DescriptionId);
                db.Entry(descriptionToEdit).CurrentValues.SetValues(description);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            var descriptions = new List<Description>();

            using (var db = new TupperwareContext())
            {
                descriptions = db.Descriptions.ToList();
            }

            return View("../Dashboard/Description/Index", descriptions);
        }
    }
}