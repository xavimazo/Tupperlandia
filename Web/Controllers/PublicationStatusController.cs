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
    public class PublicationStatusController : Controller
    {
        // GET: Client
        public ActionResult Create()
        {
            var model = new PublicationStatus();
            return View("../Dashboard/PublicationStatus/Create", model);
        }

        [HttpPost]
        public ActionResult Create(PublicationStatus publicationStatuses)
        {
            using (var db = new TupperwareContext())
            {
                db.PublicationStatuses.Add(publicationStatuses);
                db.SaveChanges();
            }
            Session["Message"] = "El estado de publicación fue guardado exitosamente";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (var db = new TupperwareContext())
            {
                var PublicationStatus = db.PublicationStatuses.Find(id);
                return View("../Dashboard/PublicationStatus/Delete", PublicationStatus);
            }
        }

        public ActionResult DeleteConfirmation(int id)
        {
            using (var db = new TupperwareContext())
            {
                var StatusToRemove = db.PublicationStatuses.Find(id);
                db.PublicationStatuses.Remove(StatusToRemove);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (var db = new TupperwareContext())
            {
                var PublicationStatus = db.PublicationStatuses.Find(id);
                return View("../Dashboard/PublicationStatus/Edit");
            }
        }

        [HttpPost]
        public ActionResult Edit(PublicationStatus PublicationStatuses)
        {
            using (var db = new TupperwareContext())
            {
                var PublicationStatusToEdit = db.PublicationStatuses.Find(PublicationStatuses.Id);
                db.Entry(PublicationStatusToEdit).CurrentValues.SetValues(PublicationStatuses);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            var PublicationStatus = new List<PublicationStatus>();
            using (var db = new TupperwareContext())
            {
                PublicationStatus = db.PublicationStatuses.ToList();
            }
            return View("../Dashboard/PublicationStatus/Index", PublicationStatus);
        }
    }
}