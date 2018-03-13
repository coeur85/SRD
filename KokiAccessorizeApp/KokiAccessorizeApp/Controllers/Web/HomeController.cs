using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KokiDB;

namespace KokiAccessorizeApp.Controllers.Web
{
    public class HomeController : Controller
    {
        // GET: Home
        KokiAccessorizeAppDBEntities db = new KokiAccessorizeAppDBEntities();
        public ActionResult Index()
        {

            //_App.ui.Message.addSuccess("test ok");
            //_App.ui.Message.addError("add error");

            var oord = db.Orders.FirstOrDefault(x=> x.OrderID  == 5);

            return View(oord);
        }
    }
}