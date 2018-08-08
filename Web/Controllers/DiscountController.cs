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
    public class DiscountController : Controller
    {
        // GET: Client
        public ActionResult Create()
        {
            var model = new Discount();
            return View("../Dashboard/Discount/Create", model);
        }

        [HttpPost]
        public ActionResult Create(Discount discounts)
        {
            using (var db = new TupperwareContext())
            {
                db.Discounts.Add(discounts);
                db.SaveChanges();
            }
            Session["Message"] = "El porcentage de descuento fue guardado exitosamente";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (var db = new TupperwareContext())
            {
                var discount = db.Discounts.Find(id);
                return View("../Dashboard/Discount/Delete", discount);
            }
        }

        public ActionResult DeleteConfirmation(int id)
        {
            using (var db = new TupperwareContext())
            {
                var DiscountToRemove = db.Discounts.Find(id);
                db.Discounts.Remove(DiscountToRemove);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (var db = new TupperwareContext())
            {
                var discount = db.Discounts.Find(id);
                return View("../Dashboard/Discount/Edit");
            }
        }

        [HttpPost]
        public ActionResult Edit(Discount Discounts)
        {
            using (var db = new TupperwareContext())
            {
                var discountToEdit = db.Discounts.Find(Discounts.DiscountId);
                db.Entry(discountToEdit).CurrentValues.SetValues(Discounts);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            var Discounts = new List<Discount>();
            using (var db = new TupperwareContext())
            {
                Discounts = db.Discounts.ToList();
            }
            return View("../Dashboard/Discount/Index", Discounts);
        }
    }
}