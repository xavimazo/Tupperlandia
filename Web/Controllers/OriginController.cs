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
    public class OriginController : Controller
    {
        public ActionResult Create()
        {
            var model = new Origin();
            return View("../Dashboard/Origin/Create", model);
        }

        [HttpPost]
        public ActionResult Create(Origin origin)
        {
            using (var db = new TupperwareContext())
            {
                db.Origins.Add(origin);
                db.SaveChanges();
            }
            Session["Message"] = "El nuevo origen fue guardado exitosamente";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (var db = new TupperwareContext())
            {
                var origin = db.Origins.Find(id);
                return View("../Dashboard/Origin/Delete", origin);
            }
        }

        public ActionResult DeleteConfirmation(int id)
        {
            using (var db = new TupperwareContext())
            {
                var OriginToRemove = db.Origins.Find(id);
                try
                {
                    db.Origins.Remove(OriginToRemove);
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
                var origin = db.Origins.Find(id);
                return View("../Dashboard/Origin/Edit", origin);
            }
        }

        [HttpPost]
        public ActionResult Edit(Origin origin)
        {
            using (var db = new TupperwareContext())
            {
                var originToEdit = db.Origins.Find(origin.OriginId);
                db.Entry(originToEdit).CurrentValues.SetValues(origin);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            var origin = new List<Origin>();
            using (var db = new TupperwareContext())
            {
                origin = db.Origins.ToList();
            }
            return View("../Dashboard/Origin/Index", origin);
        }
    }
}