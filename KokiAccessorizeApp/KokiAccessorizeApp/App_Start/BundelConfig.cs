
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
               "~/Theme/assets/css/lib/datatable/dataTables.bootstrap.min.css",
               "~/Theme/assets/css/fonts.google.apis.css"
               ));



            bundels.Add(new ScriptBundle("~/App/Js").Include(

                 "~/Theme/assets/js/vendor/jquery-1.11.1.min.js",
                    "~/Theme/assets/js/vendor/jquery-ui-1.10.3.min.js",
                "~/Theme/assets/js/popper.min.js",
                "~/Theme/assets/js/plugins.js",
             //    "~/Theme/assets/js/main.js",
            //    "~/Theme/assets/js/lib/chart-js/Chart.bundle.js",
                 "~/Theme/assets/js/lib/data-table/datatables.min.js",
                 "~/Theme/assets/js/lib/data-table/dataTables.bootstrap.min.js",
              //     "~/Theme/assets/js/lib/data-table/dataTables.buttons.min.js",
              //      "~/Theme/assets/js/lib/data-table/buttons.bootstrap.min.js",
                //     "~/Theme/assets/js/lib/data-table/jszip.min.js",
               //       "~/Theme/assets/js/lib/data-table/pdfmake.min.js",
               //        "~/Theme/assets/js/lib/data-table/vfs_fonts.js",
               //         "~/Theme/assets/js/lib/data-table/buttons.html5.min.js",
                //        "~/Theme/assets/js/lib/data-table/buttons.print.min.js",
                //        "~/Theme/assets/js/lib/data-table/buttons.colVis.min.js",
                 //       "~/Theme/assets/js/lib/data-table/datatables-init.js",
                      "~/Theme/assets/js/jquery.validate.min.js",
                         "~/Theme/assets/js/Globalint.js"













         ));

            BundleTable.EnableOptimizations = false;

        }

    }
}