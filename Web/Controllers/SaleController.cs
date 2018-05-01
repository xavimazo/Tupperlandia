using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tupperware_e_commerce.Controllers
{
    public class SaleController : Controller
    {
        // GET: Sale
        public ActionResult Create()
        {
            var model = new Sale();
            return View("../Dashboard/Sale/Create", model);
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
                var sale = db.Sales.Find(id);
                return View("../Dashboard/Client/Edit");
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
            var sales = new List<Sale>();
            using (var db = new TupperwareContext())
            {
                sales = db.Sales.ToList();
            }
            return View("../Dashboard/Sale/Index", sales);
        }
    }
}