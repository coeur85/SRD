using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KokiDB;

namespace KokiAccessorizeApp.Controllers.Web
{
    public class ProductPhotoController : Controller
    {

        KokiAccessorizeAppDBEntities db = new KokiAccessorizeAppDBEntities();
        // GET: ProductPhoto
        public ActionResult Index(int id)
        {
            var p = db.Products.Find(id);


            return View(p);
        }
    }
}