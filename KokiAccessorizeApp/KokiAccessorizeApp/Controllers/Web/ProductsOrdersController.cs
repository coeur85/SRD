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


        public ActionResult CheckOut(int id)
        {

            var order = db.Orders.Find(id);

            if (order.ProductsOrders.Count == 0) { _App.ui.Message.addError("Must add at least one item !"); return RedirectToAction("index", new { id = id }); }

            return View(order);
        }



        // GET: ProductsOrders/Details/5


        // GET: ProductsOrders/Create
        public ActionResult Create(int id)
        {
            var order = db.Orders.Find(id);
            ViewBag.ProductID = new SelectList(db.Products.ToList().Where(x => !order.ProductsOrders.ToList().Any(y => x.ProductID == y.ProductID)).ToList(), "ProductID", "FullName", 0); ;
            ProductsOrder pro = new ProductsOrder
            {
                Order = order,
                OrderID = order.OrderID
            };
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
                _App.ui.Message.SuccessAddNew();
                return RedirectToAction("Index" , new { id = product.OrderID });
            }
            catch (Exception e)
            {
                throw e;
              //  return View();
            }
        }

        // GET: ProductsOrders/Edit/5
        public ActionResult Edit(int id)
        {

            var pro = db.ProductsOrders.Find(id);
            var list = db.Products.ToList().Where(x => !pro.Order.ProductsOrders.ToList().Any(y => x.ProductID == y.ProductID)).ToList();
            list.Add(pro.Product);
            ViewBag.ProductID = new SelectList(list, "ProductID", "FullName", pro.ProductID); ;
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
                old.CosePrice = product.CosePrice;
                db.Entry(old).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                _App.ui.Message.SuccessUpdate();
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
            return View(pro);
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
                db.SaveChanges();
                _App.ui.Message.SuccessDelete();
                return RedirectToAction("Index", new { id= or });
            }
            catch
            {
                return View(pro);
            }
        }
    }
}
