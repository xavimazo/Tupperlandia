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
    public class SaleController : Controller
    {
        // GET: Sale
        public ActionResult Create()
        {
            var model = new Sale();
            var viewModel = new SaleViewModel
            {
                Sale = model
            };

            using (var db = new TupperwareContext())
            {
                viewModel.Stock = db.Stock.ToList();
                viewModel.Client = db.Clients.ToList();
                viewModel.Products = db.Products.ToList();
                viewModel.Dispatch = db.Dispatches.ToList();

            }
                return View("../Dashboard/Sale/Create", viewModel);
        }

        [HttpPost]
        public ActionResult Create(Sale sale)
        {
            using (var db = new TupperwareContext())
            {
                db.Sales.Add(sale);
                db.SaveChanges();
            }
            Session["Message"] = "La venta fue guardado exitosamente";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            using (var db = new TupperwareContext())
            {
                var sale = db.Sales.Find(Id);
                return View("../Dashboard/Sale/Delete", sale);
            }
        }

        public ActionResult DeleteConfirmation(int id)
        {
            using (var db = new TupperwareContext())
            {
                var SaleToRemove = db.Sales.Find(id);
                db.Sales.Remove(SaleToRemove);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (var db = new TupperwareContext())
            {
                var sale = db.Sales
                    .Include(s => s.Client)
                    .Include(s => s.Dispatch)
                    .Include(s => s.Product)
                    .Include(s => s.Stock)
                    .FirstOrDefault(s => s.Id == id);

                var Stock = db.Stock.ToList();
                var Client = db.Clients.ToList();
                var Products = db.Products.ToList();
                var Dispatch = db.Dispatches.ToList();

                var viewModel = new SaleViewModel
                {
                    Stock = Stock,
                    Products = Products,
                    Client = Client,
                    Dispatch = Dispatch
                };

                return View("../Dashboard/Sale/Edit", viewModel);
            }
        }

        [HttpPost]
        public ActionResult Edit(Sale sale)
        {
            using (var db = new TupperwareContext())
            {
                var SaleToEdit = db.Sales.Find(sale.Id);
                db.Entry(SaleToEdit).CurrentValues.SetValues(sale);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            var Sales = new List<Sale>();
            using (var db = new TupperwareContext())
            {
                Sales = db.Sales.Include(s => s.Client)
                                .Include(s => s.Dispatch)
                                .Include(s => s.Product)
                                .Include(s => s.Stock)
                                .ToList();
            }
            return View("../Dashboard/Sale/Index", Sales);
        }
    }
}