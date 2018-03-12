using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KokiDB;

namespace KokiAccessorizeApp.Controllers.Web
{
    public class ProductsOrdersController : Controller
    {

        KokiAccessorizeAppDBEntities db = new KokiAccessorizeAppDBEntities();

        // GET: ProductsOrders
        public ActionResult Index(int id)
        {

            var order = db.Orders.Find(id);
            return View(order);
        }

        // GET: ProductsOrders/Details/5
        

        // GET: ProductsOrders/Create
        public ActionResult Create(int id)
        {
            var order = db.Orders.Find(id);
            ViewBag.ProductID = new SelectList(db.Products.Where(x => order.ProductsOrders.Any(y => x.ProductID != y.ProductID)).ToList(), "FullName", "ProductID"); ;
            ProductsOrder pro = new ProductsOrder();
            pro.Order = order;
            pro.OrderID = order.OrderID;
            return View(pro);
        }

        // POST: ProductsOrders/Create
        [HttpPost]
        public ActionResult Create(ProductsOrder product)
        {
            try
            {
                db.ProductsOrders.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index" , new { id = product.OrderID });
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsOrders/Edit/5
        public ActionResult Edit(int id)
        {

            var pro = db.ProductsOrders.Find(id);
            var list = db.Products.Where(x => pro.Order.ProductsOrders.Any(y => x.ProductID != y.ProductID)).ToList();
            list.Add(pro.Product);
            ViewBag.ProductID = new SelectList(list, "FullName", "ProductID", pro.ProductID); ;
            return View(pro);
        }

        // POST: ProductsOrders/Edit/5
        [HttpPost]
        public ActionResult Edit(ProductsOrder product)
        {
            try
            {
                // TODO: Add update logic here
                var old = db.ProductsOrders.Find(product.POID);
                old.ProductID = product.ProductID;
                old.Price = product.Price;
                old.Qantaty = product.Qantaty;
                db.Entry(old).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();


                return RedirectToAction("Index", new { id = product.OrderID });
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsOrders/Delete/5
        public ActionResult Delete(int id)
        {
            var pro = db.ProductsOrders.Find(id);
            return View();
        }

        // POST: ProductsOrders/Delete/5
        [HttpPost]
        public ActionResult Delete(ProductsOrder pro)
        {
            try
            {
                // TODO: Add delete logic here
                var or = pro.OrderID;
                var old = db.ProductsOrders.Find(pro.POID);

                db.ProductsOrders.Remove(old);

                return RedirectToAction("Index", new { id= or });
            }
            catch
            {
                return View(pro);
            }
        }
    }
}
