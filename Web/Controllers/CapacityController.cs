using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tupperware_e_commerce.Controllers
{
    public class CapacityController : Controller
    {
        // GET: Product
        public ActionResult Create()
        {
            var model = new Capacity();
            return View("../Dashboard/Capacity/Create", model);
        }

        [HttpPost]
        public ActionResult Create(Capacity Capacity)
        {
            using (var db = new TupperwareContext())
            {
                if (db.Capacities.Any(p => p.CapacityDescription == Capacity.CapacityDescription))
                    throw new Exception("Ya se agrego esa capacidad");

                db.Capacities.Add(Capacity);
                db.SaveChanges();
            }

            Session["Message"] = "La capacidad fue guardada exitosamente";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (var db = new TupperwareContext())
            {
                var capacity = db.Capacities.Find(id);
                return View("../Dashboard/Capacity/Delete", capacity);
            }
        }

        public ActionResult DeleteConfirmation(int id)
        {
            using (var db = new TupperwareContext())
            {
                var capacityToRemove = db.Capacities.Find(id);
                db.Capacities.Remove(capacityToRemove);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (var db = new TupperwareContext())
            {
                var capacity = db.Capacities.Find(id);
                return View("../Dashboard/Capacity/Edit", capacity);
            }
        }

        [HttpPost]
        public ActionResult Edit(Capacity Capacity)
        {
            using (var db = new TupperwareContext())
            {
                var capacityToEdit = db.Capacities.Find(Capacity.CapacityId);
                db.Entry(capacityToEdit).CurrentValues.SetValues(Capacity);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            var capacity = new List<Capacity>();

            using (var db = new TupperwareContext())
            {
                capacity = db.Capacities.ToList();
            }

            return View("../Dashboard/Capacity/Index", capacity);
        }
    }
}