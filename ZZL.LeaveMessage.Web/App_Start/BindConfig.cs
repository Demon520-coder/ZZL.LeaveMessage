using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace ZZL.LeaveMessage.Web.App_Start
{
    public class BindConfig
    {
        public static void RegisterBundle(BundleCollection bundles)
        {
            bundles.Add(new Bundle("~/bundle/jquery").Include("~/Content/Js/jquery-{version}.js"));
            bundles.Add(new Bundle("~/bundle/bootstrap/js").Include("~/Content/Js/bootstrap.js"));
            bundles.Add(new Bundle("~/bundle/bootstrap/css").Include("~/Content/Css/bootstrap.css"
                , "~/Content/Css/bootstrap-grid.css", "~/Content/Css/bootstrap-reboot.css"));
        }
    }
}