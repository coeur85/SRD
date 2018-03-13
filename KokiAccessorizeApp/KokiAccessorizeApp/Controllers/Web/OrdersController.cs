using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KokiDB;

namespace KokiAccessorizeApp.Controllers.Web
{
    public class OrdersController : Controller
    {
        // GET: Orders

        KokiAccessorizeAppDBEntities db = new KokiAccessorizeAppDBEntities();

        private ICollection<Order> orders()
        {
            return db.Orders.OrderByDescending(x => x.OrderDate).ToList();

        }
        private void LoadDD(int cus, int pro)
        {

            var q = from c in db.Customers select new { CustomerName = c.UserInfo.FullName, CustomerID = c.CustomerID };
         //   var p = from pr in db.Products select new { ProductName = pr.FullName , ProductID = pr.ProductID };


            ViewBag.CustomerID = new SelectList(q, "CustomerID", "CustomerName", cus );
           // ViewBag.ProductID = new SelectList(p, "ProductID", "ProductName", pro);
            

        }




        public ActionResult Index()
        {
            return View(orders());
        }


        public ActionResult Create()
        {
            Order o = new Order();
            o.OrderDate = DateTime.Now;
            LoadDD(0, 0);
            return View(o);
        }

        [HttpPost]
        public ActionResult Create(Order order)
        {

            if (ModelState.IsValid)
            {
                order.OrderDate = DateTime.Now;
                order.OrderStatusID = 1;
                db.Orders.Add(order);
                db.SaveChanges();
                _App.ui.Message.SuccessAddNew();
              return  RedirectToAction("index", "ProductsOrders", new { id = order.OrderID });
            }


            LoadDD(0, 0);
            return View(order);
        }
        public ActionResult Edit(int id)
        {
            Order o = new Order();
            o = db.Orders.Find(id);
           
            
            LoadDD(o.CustomerID,0);
            return View(o);
        }

        [HttpPost]
        public ActionResult Edit(Order order)
        {
            if (ModelState.IsValid)
            {

                var oldorder = db.Orders.Find(order.OrderID);
                oldorder.CustomerID = order.CustomerID;
                db.Entry(oldorder).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                RedirectToAction("index", "ProductsOrders", new { id = order.OrderID });
            }


            LoadDD(order.CustomerID, 0);
            return View(order);
        }




       




    }
}