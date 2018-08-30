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
                viewModel.Discount = db.Discounts.ToList();
                viewModel.Categories = db.Categories.ToList();
                viewModel.Capacities = db.Capacities.ToList();
                viewModel.Lines = db.Lines.ToList();
                viewModel.Colors = db.Colors.ToList();
                viewModel.Origins = db.Origins.ToList();
            }

            return View("../Dashboard/Stock/Create", viewModel);
        }

        [HttpPost]
        public ActionResult Create(Stock stock)
        {
            using (var db = new TupperwareContext())
            {
                var product = db.Products.Find(stock.Product.ProductId);
                stock.Product = product;
                var category = db.Categories.Find(stock.Categorie.CategorieId);
                stock.Categorie = category;
                var line = db.Lines.Find(stock.Line.LineId);
                stock.Line = line;
                var stockstatus = db.StockStatuses.Find(stock.StockStatus.StockStatusId);
                stock.StockStatus = stockstatus;
                var capacity = db.Capacities.Find(stock.Capacity.CapacityId);
                stock.Capacity = capacity;
                var color = db.Colors.Find(stock.Color.ColorId);
                stock.Color = color;
                var origin = db.Origins.Find(stock.Origin.OriginId);
                stock.Origin = origin;
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
                var discounts = db.Discounts.ToList();
                var Categorie = db.Categories.ToList();
                var Lines = db.Lines.ToList();
                var Capacities = db.Capacities.ToList();
                var Origins = db.Origins.ToList();
                var Color = db.Colors.ToList();

                var viewModel = new StockViewModel
                {
                    Stock = stock,
                    Products = products,
                    StockStatus = StockStatus,
                    Discount = discounts,
                    Categories = Categorie,
                    Lines = Lines,
                    Capacities = Capacities,
                    Colors = Color,
                    Origins = Origins
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
                stock.StockId = stock.StockId;
                var product = db.Products.Find(stock.ProductId);
                stock.ProductId = stock.Product.ProductId;
                var category = db.Categories.Find(stock.CategorieId);
                stock.CategorieId = stock.Categorie.CategorieId;
                var line = db.Lines.Find(stock.LineId);
                stock.LineId = stock.Line.LineId;
                var stockstatus = db.StockStatuses.Find(stock.StockStatusId);
                stock.StockStatusId = stock.StockStatus.StockStatusId;
                var capacity = db.Capacities.Find(stock.Capacity.CapacityId);
                stock.CapacityId = stock.Capacity.CapacityId;
                var color = db.Colors.Find(stock.ColorId);
                stock.ColorId = stock.Color.ColorId;
                var origin = db.Origins.Find(stock.OriginId);
                stock.OriginId = stock.Origin.OriginId;

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
                               .Include(s => s.Categorie)
                               .Include(s => s.Discount)
                               .Include(S => S.Line)
                               .Include(s => s.Capacity)
                               .Include(s => s.Color)
                               .Include(S => S.Origin)
                               .ToList();
            }
            return View("../Dashboard/Stock/Index", stock);
        }
    }
}