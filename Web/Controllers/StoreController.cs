using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Tupperware_e_commerce.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        public ActionResult Index()
        {
            IList<Stock> stock = new List<Stock>();
            using (var db = new TupperwareContext())
            {
                stock = db.Stock.Include(s => s.Product).ToList();
            }
            return View(stock);
        }
    }
}