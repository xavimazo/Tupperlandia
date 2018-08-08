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
            var model = new ShoppingCart();
            var viewModel = new SaleViewModel
            {
                ShoppingCart = model
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
        public ActionResult Create(ShoppingCart shoppingCart)
        {
            using (var db = new TupperwareContext())
            {
                db.ShoppingCarts.Add(shoppingCart);
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
                var cart = db.ShoppingCarts.Find(Id);
                return View("../Dashboard/Sale/Delete", cart);
            }
        }

        public ActionResult DeleteConfirmation(int id)
        {
            using (var db = new TupperwareContext())
            {
                var CartToRemove = db.ShoppingCarts.Find(id);
                db.ShoppingCarts.Remove(CartToRemove);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (var db = new TupperwareContext())
            {
                var sale = db.ShoppingCarts
                    .Include(s => s.CartId)
                    .Include(s => s.Amount)
                    .Include(s => s.CartDate)
                    .Include(s => s.Stock)
                    .Include(s => s.Dispatch)
                    .Include(s => s.Client)
                    .FirstOrDefault(s => s.CartId == id);

                var CartId = db.ShoppingCarts.ToList();
                var Amount = db.ShoppingCarts.ToList();
                var CartDate = db.ShoppingCarts.ToList();
                var Stock = db.Stock.ToList();
                var Dispatch = db.Dispatches.ToList();
                var Client = db.Clients.ToList();

                var viewModel = new SaleViewModel
                {
                    Stock = Stock,
                    Dispatch = Dispatch,
                    Client =  Client
                };

                return View("../Dashboard/Sale/Edit", viewModel);
            }
        }

        [HttpPost]
        public ActionResult Edit(ShoppingCart shoppingCart)
        {
            using (var db = new TupperwareContext())
            {
                var CartToEdit = db.ShoppingCarts.Find(shoppingCart.CartId);
                db.Entry(CartToEdit).CurrentValues.SetValues(shoppingCart);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            var shoppingCarts = new List<ShoppingCart>();
            using (var db = new TupperwareContext())
            {
                shoppingCarts = db.ShoppingCarts.Include(s => s.CartId)
                                .Include(s => s.Amount)
                                .Include(s => s.CartDate)
                                .Include(s => s.Stock)
                                .Include(s => s.Dispatch)
                                .Include(s => s.Client)
                                .ToList();
            }
            return View("../Dashboard/Sale/Index", shoppingCarts);
        }
    }
}