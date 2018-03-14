using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KokiDB;

namespace KokiAccessorizeApp.Controllers.Web
{
    public class CustomersController : Controller
    {


        KokiAccessorizeAppDBEntities db = new KokiAccessorizeAppDBEntities();
        // GET: Customers
        public ActionResult Index()
        {

            return View(db.Customers.OrderByDescending(x=> x.CustomerID).ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int id)
        {
            var c = db.Customers.Find(id);

            return View(c);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            Customer c = new Customer();
            return View(c);
        }

        // POST: Customers/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customers/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customers/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
