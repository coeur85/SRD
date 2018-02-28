
using System.Web;
using System.Web.Optimization;

namespace KokiAccessorizeApp
{
    public static class BundelConfig
    {

       // private static readonly string BaseUrl = System.Configuration.ConfigurationManager.AppSettings["CdnBaseUrl"];
        public static void RegesterBundels(BundleCollection bundels) 
        {



           // bundels.Add( new )

            bundels.Add(new StyleBundle("~/App/Css").Include(
              "~/Theme/assets/css/normalize.css",
              "~/Theme/assets/css/bootstrap.min.css",
              "~/Theme/assets/css/font-awesome.min.css",
              "~/Theme/assets/css/themify-icons.css.css",
              "~/Theme/assets/css/flag-icon.min.css",
              "~/Theme/assets/css/cs-skin-elastic.css",
                //css/animate.css
                "~/Theme/assets/css/animate.css",
              "~/Theme/assets/scss/style.css",
             // "~/Theme/assets/css/lib/vector-map/jqvmap.min.css",
               "~/Theme/assets/css/fonts.google.apis.css"
               ));



            bundels.Add(new ScriptBundle("~/App/Js").Include(

                 "~/Theme/assets/js/vendor/jquery-2.1.4.min.js",
                 "~/Theme/assets/js/popper.min.js",
                 "~/Theme/assets/js/plugins.js",
                 "~/Theme/assets/js/main.js",
                "~/Theme/assets/js/lib/chart-js/Chart.bundle.js"
                // "~/Theme/assets/js/dashboard.js",
             //  "~/Theme/assets/js/widgets.js"
                 //"~/Theme/assets/js/lib/vector-map/jquery.vmap.js",
                 //"~/Theme/js/jquery.cookies.js",
                 //"~/Theme/js/flot/jquery.flot.min.js",
                 //"~/Theme/js/flot/jquery.flot.resize.min.js",
                 //"~/Theme/js/flot/jquery.flot.spline.min.js",
                 //"~/Theme/js/morris.min.js",
                 //"~/Theme/js/raphael-2.1.0.min.js",
                 //"~/Theme/js/custom.js",
                 //"~/Theme/js/jquery.validate.min.js",
                 //"~/Theme/js/jquery.datatables.min.js",
                 //"~/Theme/js/jquery.gritter.min.js",
                 //"~/Theme/js/bootstrap-toggle.min.js"
          //    "~/Theme/js/toggles.min.js",
          //   "~/Theme/js/gmaps.js"






         ));

           BundleTable.EnableOptimizations = false ;

        }

    }
}