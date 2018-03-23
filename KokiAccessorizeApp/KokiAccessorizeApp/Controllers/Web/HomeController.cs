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

            WepApp.WebPagesModels.HomePage Home = new WepApp.WebPagesModels.HomePage();



            foreach (var item in db.OrderStatus)
            {

                if (item.Orders.Count > 0)
                {
                Home.Orders.Add(new WepApp.OrderStatus { OrderSatuesNAme = item.StatusName, OrdersCount = item.Orders.Count, StatusID = item.StatusID });

                }
            }

            foreach (var item in db.ProductCategories)
            {
                Home.Categories.Add(new WepApp.categories { CategoryName = item.CategoryName, ProductCount = item.Products.Count });
            }



            return View(Home);
        }
    }
}