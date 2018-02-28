
using System.Web;
using System.Web.Optimization;

namespace RetailApp
{
    public static class BundelConfig
    {

       // private static readonly string BaseUrl = System.Configuration.ConfigurationManager.AppSettings["CdnBaseUrl"];
        public static void RegesterBundels(BundleCollection bundels) 
        {




            bundels.Add(new StyleBundle("~/App/Css").Include(
              "~/Theme/css/flat-jooza.css",
              "~/Theme/css/bootstrap-toggle.min.css",
               "~/Theme/css/jquery.gritter.css",
               "~/Theme/css/jquery.datatables.css",
              "~/Theme/css/style.default.css",
              "~/Theme/css/style.default-rtl.css",
              "~/Theme/css/LoanAppCss.css"
              
             

               ));



            bundels.Add(new ScriptBundle("~/App/Js").Include(

                 "~/Theme/js/jquery-1.11.1.min.js",
                 "~/Theme/js/jquery-migrate-1.2.1.min.js",
                 "~/Theme/js/jquery-ui-1.10.3.min.js",
                 "~/Theme/js/bootstrap.min.js",
                 "~/Theme/js/modernizr.min.js",
                 "~/Theme/js/jquery.sparkline.min.js",
                 "~/Theme/js/toggles.min.js",
                 "~/Theme/js/retina.min.js",
                 "~/Theme/js/jquery.cookies.js",
                 "~/Theme/js/flot/jquery.flot.min.js",
                 "~/Theme/js/flot/jquery.flot.resize.min.js",
                 "~/Theme/js/flot/jquery.flot.spline.min.js",
                 "~/Theme/js/morris.min.js",
                 "~/Theme/js/raphael-2.1.0.min.js",
                 "~/Theme/js/custom.js",
                 "~/Theme/js/jquery.validate.min.js",
                 "~/Theme/js/jquery.datatables.min.js",
                 "~/Theme/js/jquery.gritter.min.js",
                 "~/Theme/js/bootstrap-toggle.min.js",
              //    "~/Theme/js/toggles.min.js",
                 "~/Theme/js/gmaps.js"
                
                 






         ));
          
        }

    }
}