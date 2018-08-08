using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tupperware_e_commerce.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult Create()
        {
            var model = new Client();
            return View("../Dashboard/Client/Create", model);
        }

        [HttpPost]
        public ActionResult Create(Client client)
        {
            using (var db = new TupperwareContext())
            {
                db.Clients.Add(client);
                db.SaveChanges();
            }
            Session["Message"] = "El cliente fue guardado exitosamente";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (var db = new TupperwareContext())
            {
                var client = db.Clients.Find(id);
                return View("../Dashboard/Client/Delete", client);
            }
        }

        public ActionResult DeleteConfirmation(int id)
        {
            using (var db = new TupperwareContext())
            {
                var ClientToRemove = db.Clients.Find(id);
                db.Clients.Remove(ClientToRemove);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (var db = new TupperwareContext())
            {
                var client = db.Clients.Find(id);
                return View("../Dashboard/Client/Edit");
            }
        }

        [HttpPost]
        public ActionResult Edit(Client client)
        {
            using (var db = new TupperwareContext())
            {
                var ClientToEdit = db.Clients.Find(client.ClientId);
                db.Entry(ClientToEdit).CurrentValues.SetValues(client);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            var clients = new List<Client>();
            using (var db = new TupperwareContext())
            {
                clients = db.Clients.ToList();
            }
                return View("../Dashboard/Client/Index", clients);
        }
    }
}