using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataBaseModel.Entity;

namespace RetailApp.Controllers
{
    public class ItemPricesController : Controller
    {
        // GET: ItemPrices


        RetailEntities db = new RetailEntities();
        public ActionResult Index()
        {
            var it = db.sys_item_units.ToList();

            return View(it);
        }
    }
}