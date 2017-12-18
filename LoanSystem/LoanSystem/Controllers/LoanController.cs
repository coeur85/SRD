using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LoanSystem.Models.DataB;
using System.Web.Mvc;

namespace LoanSystem.Controllers
{
    public class LoanController : Controller
    {
        private LoansSystemDBEntities db = new LoansSystemDBEntities();
        // GET: Loan
        public ActionResult Index()
        {

            return View(db.LonsRequests.ToList());
        }
    }
}