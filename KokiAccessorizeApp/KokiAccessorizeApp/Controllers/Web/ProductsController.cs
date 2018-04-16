using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KokiDB;

namespace KokiAccessorizeApp.Controllers.Web
{
    public class ProductsController : Controller
    {
        // GET: Products
        KokiAccessorizeAppDBEntities db = new KokiAccessorizeAppDBEntities();
        public ActionResult Index()
        {
            var p = db.Products.OrderByDescending(x=> x.ProductID).ToList();
            string str = Request.QueryString["CategoryID"];
            if (!string.IsNullOrWhiteSpace(str))
            {
                int i = Convert.ToInt32(str);
                var c = db.ProductCategories.FirstOrDefault(x => x.CategoryID == i);
                ViewBag.PageName = c.CategoryName;
                p = p.Where(x => x.ProductCategoryID == i).ToList();
            }

            else { ViewBag.PageName = "All Products"; }
            

            return View(p);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            WepApp.WebPagesModels.ProductDetails PD = new WepApp.WebPagesModels.ProductDetails();

            var p = db.Products.Find(id);
            if (p == null) { return HttpNotFound(); }
            PD.Product = p;
            var o = p.ProductsOrders;

            List<Customer> cl = new List<Customer>();
            Customer c = new Customer();
            foreach (var item in o)
            {
                PD.TotalOrders += 1;
                PD.TotalsSales += item.Price;
                c = item.Order.Customer;
                if (!cl.Any(x => x.CustomerID == c.CustomerID)) { cl.Add(c); }
                PD.Orders.Add(item.Order);

            }
            PD.TotalCustomers = cl.Count;

            return View(PD);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            Product p = new Product();

            ViewBag.ProductCategoryID = new SelectList(db.ProductCategories, "CategoryID", "CategoryName", p.ProductCategoryID);
            return View(p);
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(Product p)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Products.Add(p);
                    db.SaveChanges();
                    _App.ui.Message.SuccessAddNew();
                   return RedirectToAction("index");
                }

                ViewBag.ProductCategoryID = new SelectList(db.ProductCategories, "CategoryID", "CategoryName");
                return View(p);
            }
            catch
            {
                ViewBag.ProductCategoryID = new SelectList(db.ProductCategories, "CategoryID", "CategoryName");
                return View(p);
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            var p = db.Products.Find(id);
            if (p == null) { return HttpNotFound(); }
            ViewBag.ProductCategoryID = new SelectList(db.ProductCategories, "CategoryID", "CategoryName", p.ProductCategoryID);
            return View(p);
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(Product p)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(p).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    _App.ui.Message.SuccessUpdate();
                return RedirectToAction("Index");
                }

                _App.ui.Message.addError("Invalid data !");
                ViewBag.ProductCategoryID = new SelectList(db.ProductCategories, "CategoryID", "CategoryName");
                return View(p);
               
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            var p = db.Products.Find(id);
            if (p == null) { return HttpNotFound(); }
            WepApp.WebPagesModels.DeleteProduct dp = new WepApp.WebPagesModels.DeleteProduct();
            dp.Product = p;
            if (p.ProductsOrders.Count > 0) { dp.CanBeDleted = false; }
            else
            {
                dp.CanBeDleted = true;
            }
           

            return View(dp);
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id , WepApp.WebPagesModels.DeleteProduct model )
        {
            var p = db.Products.Find(id);
            try
            {
                // TODO: Add delete logic here
               
                if (p.ProductsOrders.Count == 0)
                {

                    var photos = db.ProductPhotos.Where(x => x.ProductID == id).ToList();

                    foreach (var item in photos)
                    {

                        db.ProductPhotos.Remove(item);
                    }


                 //   p.ProductPhotos.Clear();
                    db.Products.Remove(p);
                    db.SaveChanges();
                    _App.ui.Message.SuccessDelete();
                    return RedirectToAction("Index");
                }

                _App.ui.Message.addError("Can not be deleted due to related orders !");
                return View(model);
               
            }
            catch ( Exception e)
            {
                // return View(e);
                throw e;
            }
        }
    }
}
