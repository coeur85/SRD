using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace _app
{
    public class ui
    {

        //static ExcelGPS_MVC.Models.DataB.PSi cu = new ExcelGPS_MVC.Models.DataB.PSi();
        //public static ExcelGPS_MVC.Models.DataB.PSi currentUsr { get {

        //    if (!HttpContext.Current.User.Identity.IsAuthenticated) { System.Web.Security.FormsAuthentication.RedirectToLoginPage(); return cu;  }


        //    if (cu.LoginName == null) { 
        //       ExcelGPS_MVC.Models.DataB.MedicalCenterEntities DB = new ExcelGPS_MVC.Models.DataB.MedicalCenterEntities();
        //       cu = DB.PSis.FirstOrDefault(x => x.LoginName.ToLower() == HttpContext.Current.User.Identity.Name);
        //    }

        //    if (cu == null) { System.Web.Security.FormsAuthentication.RedirectToLoginPage(); }


        //       return cu;
        //}
        //    set { cu = value; }
        //}
        

       


        private static string txt = null;

        public static string msg { get { return txt; } set { txt = value; } }
  }

    


}

