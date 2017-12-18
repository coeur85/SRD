using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoanSystem.Models.DataB;

namespace LoanSystem.Controllers
{
    public class BanksController : Controller
    {



        private LoansSystemDBEntities db = new LoansSystemDBEntities();

        // GET: Banks
        public ActionResult Index()
        {

            // ViewBag.msg = "All loaded !";
         

            return View(db.Banks.ToList());
        }

        // GET: Banks/Details/5
        public ActionResult Details(int id)
        {
            var  b = db.Banks.Where(x => x.BankID == id).FirstOrDefault();
            return View(b);
        }

        // GET: Banks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Banks/Create
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

        // GET: Banks/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Banks/Edit/5
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

        // GET: Banks/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Banks/Delete/5
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
