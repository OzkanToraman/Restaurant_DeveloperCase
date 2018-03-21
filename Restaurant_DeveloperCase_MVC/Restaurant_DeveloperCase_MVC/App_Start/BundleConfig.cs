using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Restaurant_DeveloperCase_MVC.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/styles")
                .IncludeDirectory("~/Contents/Site/css", "*.css", true));
            bundles.Add(new ScriptBundle("~/bundles/scripts")
                .IncludeDirectory("~/Contents/Site/js", "*.js", true));

            BundleTable.EnableOptimizations = true;
        }
    }
}