using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Pecunia.PresentationMVC
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundle)
        {
            bundle.Add(
                // [~/scripts/jqueryBundle] name is user defined 
                new ScriptBundle("~/scripts/jqueryBundle")
                .Include(
                    // file path must matches exactly 
                    "~/Scripts/jquery-3.4.1.js",
                    "~/Scripts/umd/popper.js"
                    )
             );

            bundle.Add(
                // [~/scripts/validatorBundle] name is user defined 
                new ScriptBundle("~/scripts/validatorBundle")
                .Include(
                    // file path must matches exactly 
                    "~/Scripts/jquery.validate.js",
                    "~/Scripts/jquery.validate.unobtrusive.js"
                    )
             );

            bundle.Add(
                // [~/scripts/bootstrapBundle] name is user defined 
                new ScriptBundle("~/scripts/bootstrapBundle")
                .Include(
                    // file path must matches exactly 
                    "~/Scripts/jquery-3.4.1.js",
                    "~/Scripts/umd/popper.js",
                    "~/Scripts/bootstrap.js"
                    )
             );


            /////////////admin and employee bundle
            //bundle for jquery and popper.js
            bundle.Add(new ScriptBundle("~/scripts/jquery").Include("~/Scripts/jquery-3.4.1.js", "~/Scripts/umd/popper.js"));

            //bundle for validation
            bundle.Add(new ScriptBundle("~/scripts/jqueryvalidation").Include("~/Scripts/jquery.validate.js", "~/Scripts/jquery.validate.unobtrusive.js"));

            //bundle for bootstrap
            bundle.Add(new ScriptBundle("~/scripts/bootstrap").Include("~/Scripts/bootstrap.js"));

            //bootstrap for style
            bundle.Add(new StyleBundle("~/styles/bootstrap").Include("~/Content/bootstrap.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}