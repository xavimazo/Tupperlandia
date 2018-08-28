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
    public class LineController : Controller
    {
        public ActionResult Create()
        {
            var model = new Line();
             return View("../Dashboard/Line/Create", model);
        }

        [HttpPost]
        public ActionResult Create(Line line)
        {
            using (var db = new TupperwareContext())
            {
                db.Lines.Add(line);
                db.SaveChanges();
            }
            Session["Message"] = "La nueva linea fue agregada";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (var db = new TupperwareContext())
            {
                var line = db.Lines.Find(id);
                return View("../Dashboard/Line/Delete", line);
            }
        }

        public ActionResult DeleteConfirmation(int id)
        {
            using (var db = new TupperwareContext())
            {
                var LineToRemove = db.Lines.Find(id);
                db.Lines.Remove(LineToRemove);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (var db = new TupperwareContext())
            {
                var line = db.Lines.Find(id);
                return View("../Dashboard/Line/Edit", line);
            }
        }

        [HttpPost]
        public ActionResult Edit(Line line)
        {
            using (var db = new TupperwareContext())
            {
                var LineToEdit = db.Lines.Find(line.LineId);
                db.Entry(LineToEdit).CurrentValues.SetValues(line);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            var Line = new List<Line>();
            using (var db = new TupperwareContext())
            {
                Line = db.Lines.ToList();
            }
            return View("../Dashboard/Line/Index", Line);
        }
    }
}