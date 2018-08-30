using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tupperware_e_commerce.Models;

namespace Tupperware_e_commerce.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Create()
        {
            var model = new Product();
            var viewModel = new ProductViewModel
            {
                Product = model
            };

            using (var db = new TupperwareContext())
            {
                viewModel.Description = db.Descriptions.ToList();
            }

            return View("../Dashboard/Product/Create", viewModel);
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
                try
                {
                    db.Products.Remove(productToRemove);
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
                var product = db.Products.FirstOrDefault(s => s.ProductId == id);
                var description = db.Descriptions.ToList();

                var viewModel = new ProductViewModel
                {
                    Product = product,
                    Description = description
                };
                return View("../Dashboard/Product/Edit", viewModel);
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

        [HttpPost]
        public ActionResult SaveDescription(int id, int[] descriptions)
        {
            using (var db = new TupperwareContext())
            {

                var Product = db.Products.Find(id);
                Product.Description.Clear();

                foreach (var descriptionId in descriptions)
                {

                    var description = db.Descriptions.Find(descriptionId);

                    Product.Description.Add(description);
                }

                db.SaveChanges();
            }
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}