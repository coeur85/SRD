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
        public ActionResult Create(Customer customer)
        {
            try
            {
                // TODO: Add insert logic here
                db.Customers.Add(customer);
                db.SaveChanges();
                _App.ui.Message.SuccessAddNew();
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
            var cu = db.Customers.Find(id);
            return View(cu);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            try
            {
                // TODO: Add update logic here
                var oldcustomer = db.Customers.Find(customer.CustomerID);
                oldcustomer.UserInfo.FullName = customer.UserInfo.FullName;
                oldcustomer.Notes = customer.Notes;
                oldcustomer.PhoneNumber = customer.PhoneNumber;

                db.Entry(oldcustomer).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                _App.ui.Message.SuccessUpdate();

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
            var cu = db.Customers.Find(id);
            WepApp.WebPagesModels.DeleteCustomer customer = new WepApp.WebPagesModels.DeleteCustomer();
            customer.Customer = cu;
            if (cu.Orders.Count == 0) { customer.CanBeDleted = true; }
            else { customer.CanBeDleted = false; }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost]
        public ActionResult Delete( int id , FormCollection form)
        {
             var c = db.Customers.Find(id);
            try
            {
                // TODO: Add delete logic here
               
                db.Customers.Remove(c);
                _App.ui.Message.SuccessDelete();
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View( c);
            }
        }
    }
}
