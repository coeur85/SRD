
using System.Web;
using System.Web.Optimization;

namespace LoanSystem
{
    public static class BundelConfig
    {
        public static void RegesterBundels(BundleCollection bundels) 
        {




            bundels.Add(new StyleBundle("~/App/Css").Include(
              "~/_Design/Css/MyStyles.css",
               "~/_Design/css/minified/aui-production.min.css",
               "~/_Design/themes/minified/fides/color-schemes/dark-blue.min.css",
               "~/_Design/themes/minified/fides/common.min.css",
               "~/_Design/css/minified/widgets/nprogress.css",
               "~/_Design/themes/minified/fides/animations.min.css",
               "~/_Design/themes/minified/fides/responsive.min.css"));



            bundels.Add(new ScriptBundle("~/App/Js").Include(
         //   "~/_Design/Js/jquery-2.0.3.js",
         //   "~/_Design/js/minified/aui-production.min.js",
             "~/_Design/js/aui-production.js",
             "~/_Design/js/minified/widgets/nprogress.js",
                "~/Scripts/jquery.validate.js",
            "~/Scripts/jquery.validate.unobtrusive.js"
           // "~/_Design/js/minified/core/raphael.min.js",
          //  "~/_Design/js/minified/widgets/charts-justgage.min.js",
         //   "~/Scripts/App_Settings.js"
         ));
          
        }

    }
}