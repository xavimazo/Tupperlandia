using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Tupperware_e_commerce.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Create()
        {
            var model = new Product();
            return View("../Dashboard/Product/Create", model);
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            using (var db = new TupperwareContext())
            {
                if (db.Products.Any(p => p.ProductName == product.ProductName))
                    throw new Exception("Ya se agrego un producto con ese nombre");

                db.Products.Add(product);
                db.SaveChanges();
            }

            Session["Message"] = "El producto fue guardado exitosamente";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (var db = new TupperwareContext())
            {
                var product = db.Products.Find(id);
                return View("../Dashboard/Product/Delete", product);
            }
        }

        public ActionResult DeleteConfirmation(int id)
        {
            using (var db = new TupperwareContext())
            {
                var productToRemove = db.Products.Find(id);
                db.Products.Remove(productToRemove);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            using(var db = new TupperwareContext())
            {
                var product = db.Products.Find(id);
                return View("../Dashboard/Product/Edit", product);
            }
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            using (var db = new TupperwareContext())
            {
                var productToEdit = db.Products.Find(product.ProductId);
                db.Entry(productToEdit).CurrentValues.SetValues(product);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            var products = new List<Product>();

            using (var db = new TupperwareContext())
            {
                products = db.Products.ToList();
            }

            return View("../Dashboard/Product/Index", products);
        }
    }
}