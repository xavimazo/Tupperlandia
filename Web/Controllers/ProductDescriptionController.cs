using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tupperware_e_commerce.Controllers
{
    public class ProductDescriptionController : Controller
    {
        // GET: Product
        public ActionResult Create()
        {
            var model = new Product();
            return View("../Dashboard/ProductDescription/Create", model);
        }

        [HttpPost]
        public ActionResult Create(ProductDescription description)
        {
            using (var db = new TupperwareContext())
            {
                if (db.ProductDescriptions.Any(p => p.PDescription == description.PDescription))
                    throw new Exception("Ya se agrego una descripcion igual");

                db.ProductDescriptions.Add(description);
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
                var description = db.ProductDescriptions.Find(id);
                return View("../Dashboard/ProductDescription/Delete", description);
            }
        }

        public ActionResult DeleteConfirmation(int id)
        {
            using (var db = new TupperwareContext())
            {
                var descriptionToRemove = db.ProductDescriptions.Find(id);
                db.ProductDescriptions.Remove(descriptionToRemove);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (var db = new TupperwareContext())
            {
                var description = db.ProductDescriptions.Find(id);
                return View("../Dashboard/ProductDescription/Edit", description);
            }
        }

        [HttpPost]
        public ActionResult Edit(ProductDescription description)
        {
            using (var db = new TupperwareContext())
            {
                var descriptionToEdit = db.ProductDescriptions.Find(description.ProductDescriptionId);
                db.Entry(descriptionToEdit).CurrentValues.SetValues(description);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            var descriptions = new List<Product>();

            using (var db = new TupperwareContext())
            {
                descriptions = db.Products.ToList();
            }

            return View("../Dashboard/ProductDescription/Index", descriptions);
        }
    }
}