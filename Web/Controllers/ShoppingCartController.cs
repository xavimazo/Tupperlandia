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
    public class ShoppingCartController : Controller
    {
        // GET: Publication
        public ActionResult Create()
        {
            var model = new ShoppingCart();
            var viewModel = new ShoppingCartViewModel
            {
                ShoppingCart = model
            };

            using (var db = new TupperwareContext())
            {
                viewModel.Stock = db.Stock.ToList();
                viewModel.Dispatch = db.Dispatches.ToList();
                viewModel.Clients = db.Clients.ToList();
            }
            return View("../Dashboard/ShoppingCart/Create", viewModel);
        }

        [HttpPost]
        public ActionResult Create(ShoppingCart ShoppingCart)
        {
            using (var db = new TupperwareContext())
            {
                //var stock = db.Stock.Find(ShoppingCart.Stock.);
                //stock.Product = product;
                var dispatch = db.Dispatches.Find(ShoppingCart.Dispatch.DispatchId);
                ShoppingCart.Dispatch = dispatch;
                var client = db.Clients.Find(ShoppingCart.Client.ClientId);
                ShoppingCart.Client = client;
                db.ShoppingCarts.Add(ShoppingCart);
                db.SaveChanges();
            }
            Session["Message"] = "El carrito de ventas fue guardado exitosamente";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            using (var db = new TupperwareContext())
            {
                var shoppingCart = db.ShoppingCarts.Find(Id);
                return View("../Dashboard/ShoppingCart/Delete", shoppingCart);
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
                var ShoppingCart = db.ShoppingCarts.FirstOrDefault(s => s.CartId == id);
                var Stock = db.Stock.ToList();  
                var Dispatch = db.Dispatches.ToList();
                var Client = db.Clients.ToList();

                var viewModel = new ShoppingCartViewModel
                {
                    ShoppingCart = ShoppingCart,
                    Stock = Stock,
                    Dispatch = Dispatch,
                    Clients = Client,
                };
                return View("../Dashboard/ShoppingCart/Edit", viewModel);
            }
        }

        [HttpPost]
        public ActionResult Edit(ShoppingCart ShoppingCart)
        {
            using (var db = new TupperwareContext())
            {
                var ShoppingCartToEdit = db.ShoppingCarts.Find(ShoppingCart.CartId);
                ShoppingCart.CartId = ShoppingCart.CartId;
                //var stock = db.Stock.Find(ShoppingCart.Stock);
                //ShoppingCart.ProductId = stock.Product.ProductId;
                var Dispatch = db.Dispatches.Find(ShoppingCart.DispatchId);
                ShoppingCart.DispatchId = ShoppingCart.Dispatch.DispatchId;
                var Client = db.Clients.Find(ShoppingCart.ClientId);
                ShoppingCart.ClientId = ShoppingCart.Client.ClientId;

                db.Entry(ShoppingCartToEdit).CurrentValues.SetValues(ShoppingCart);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            var cart = new List<ShoppingCart>();
            using (var db = new TupperwareContext())
            {
               cart = db.ShoppingCarts.Include(s => s.Stock)
                               .Include(s => s.Client)
                               .Include(s => s.Dispatch)
                               .ToList();
            }
            return View("../Dashboard/ShoppingCart/Index", cart);
        }
    }
}