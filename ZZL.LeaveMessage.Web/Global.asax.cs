using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ZZL.LeaveMessage.Web.App_Start;

namespace ZZL.LeaveMessage.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BindConfig.RegisterBundle(BundleTable.Bundles);
            //autofac注入
            AutofacHelper autoFac = new AutofacHelper();
            autoFac.Register();
        }      
    }
}
