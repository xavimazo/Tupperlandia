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
    public class DispatchController : Controller
    {
        public ActionResult Create()
        {
            var model = new Dispatch();
            return View("../Dashboard/Dispatch/Create", model);
        }

        [HttpPost]
        public ActionResult Create(Dispatch dispatch)
        {
            using (var db = new TupperwareContext())
            {
                db.Dispatches.Add(dispatch);
                db.SaveChanges();
            }
            Session["Message"] = "El nuevo tipo de entrega fue guardado exitosamente";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (var db = new TupperwareContext())
            {
                var dispatch = db.Dispatches.Find(id);
                return View("../Dashboard/Dispatch/Delete", dispatch);
            }
        }

        public ActionResult DeleteConfirmation(int id)
        {
            using (var db = new TupperwareContext())
            {
                var DispatchToRemove = db.Dispatches.Find(id);
                db.Dispatches.Remove(DispatchToRemove);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (var db = new TupperwareContext())
            {
                var dispatch = db.Dispatches.Find(id);
                return View("../Dashboard/Dispatches/Edit");
            }
        }

        [HttpPost]
        public ActionResult Edit(Dispatch dispatch)
        {
            using (var db = new TupperwareContext())
            {
                var dispatchToEdit = db.Dispatches.Find(dispatch.DispatchId);
                db.Entry(dispatchToEdit).CurrentValues.SetValues(dispatch);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            var Dispatch = new List<Dispatch>();
            using (var db = new TupperwareContext())
            {
                Dispatch = db.Dispatches.ToList();
            }
            return View("../Dashboard/Dispatch/Index", Dispatch);
        }
    }
}