using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KokiDB;

namespace KokiAccessorizeApp.Controllers.Web
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        

        // GET: Login
        public ActionResult Index()
        {

            WepApp.WebPagesModels.loginModel lm = new WepApp.WebPagesModels.loginModel();
            return View(lm);
        }


        [HttpPost]
        public ActionResult Index(WepApp.WebPagesModels.loginModel model)
        {
            KokiAccessorizeAppDBEntities db = new KokiAccessorizeAppDBEntities();

            var u = db.Administrators.Where(x => x.LoginName == model.username && x.LoginPassword == model.password).FirstOrDefault();

            if (u != null) { _App.Current.User = u.UserInfo; return RedirectToAction("index", "home"); }
            else { model.message = "Wrong user name or password!"; }


         
            return View(model);
        }
    }
}