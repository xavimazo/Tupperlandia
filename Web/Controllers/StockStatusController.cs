﻿using Data;
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
    public class StockStatusController : Controller
    {
        // GET: Client
        public ActionResult Create()
        {
            var model = new StockStatus();
            return View("../Dashboard/PublicationStatus/Create", model);
        }

        [HttpPost]
        public ActionResult Create(StockStatus StockStatuses)
        {
            using (var db = new TupperwareContext())
            {
                db.StockStatuses.Add(StockStatuses);
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
                var PublicationStatus = db.StockStatuses.Find(id);
                return View("../Dashboard/PublicationStatus/Delete", PublicationStatus);
            }
        }

        public ActionResult DeleteConfirmation(int id)
        {
            using (var db = new TupperwareContext())
            {
                var StatusToRemove = db.StockStatuses.Find(id);
                db.StockStatuses.Remove(StatusToRemove);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (var db = new TupperwareContext())
            {
                var PublicationStatus = db.StockStatuses.Find(id);
                return View("../Dashboard/PublicationStatus/Edit");
            }
        }

        [HttpPost]
        public ActionResult Edit(StockStatus StockStatuses)
        {
            using (var db = new TupperwareContext())
            {
                var PublicationStatusToEdit = db.StockStatuses.Find(StockStatuses.StockStatusId);
                db.Entry(PublicationStatusToEdit).CurrentValues.SetValues(StockStatuses);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            var PublicationStatus = new List<StockStatus>();
            using (var db = new TupperwareContext())
            {
                PublicationStatus = db.StockStatuses.ToList();
            }
            return View("../Dashboard/PublicationStatus/Index", PublicationStatus);
        }
    }
}