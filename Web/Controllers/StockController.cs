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
    public class StockController : Controller
    {
        // GET: Publication
        public ActionResult Create()
        {
            var model = new Stock();
            var viewModel = new StockViewModel
            {
                Stock = model
            };

            using (var db = new TupperwareContext())
            {
                viewModel.Products = db.Products.ToList();
                viewModel.StockStatus = db.StockStatuses.ToList();
                //viewModel.Discounts = db.Discounts.ToList();
            }

            return View("../Dashboard/Stock/Create", viewModel);
        }

        [HttpPost]
        public ActionResult Create(Stock stock)
        {
            using (var db = new TupperwareContext())
            {
                db.Stock.Add(stock);
                db.SaveChanges();
            }
            Session["Message"] = "El stock fue guardado exitosamente";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            using (var db = new TupperwareContext())
            {
                var stock = db.Stock.Find(Id);
                return View("../Dashboard/Stock/Delete", stock);
            }
        }

        public ActionResult DeleteConfirmation(int id)
        {
            using (var db = new TupperwareContext())
            {
                var StockToRemove = db.Stock.Find(id);
                db.Stock.Remove(StockToRemove);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (var db = new TupperwareContext())
            {
                var stock = db.Stock.Include(s => s.Product).FirstOrDefault(s => s.StockId == id);
                var products = db.Products.ToList();
                var StockStatus = db.StockStatuses.ToList();
                //var discounts = db.Discounts.ToList();

                var viewModel = new StockViewModel
                {
                    Stock = stock,
                    Products = products,
                    StockStatus = StockStatus,
                    //Discounts = discounts
                };
                return View("../Dashboard/Stock/Edit", viewModel);
            }
        }

        [HttpPost]
        public ActionResult Edit(Stock stock)
        {
            using (var db = new TupperwareContext())
            {
                var StockToEdit = db.Stock.Find(stock.StockId);
                db.Entry(StockToEdit).CurrentValues.SetValues(stock);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            var stock = new List<Stock>();
            using (var db = new TupperwareContext())
            {
               stock = db.Stock.Include(s => s.Product)
                               .Include(s => s.StockStatus)
                               .ToList();
            }
            return View("../Dashboard/Stock/Index", stock);
        }
    }
}