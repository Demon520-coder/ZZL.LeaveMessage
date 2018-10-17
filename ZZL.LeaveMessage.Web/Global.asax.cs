using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using ZZL.LeaveMessage.Common;
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
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //autofac注入
            AutofacHelper autoFac = new AutofacHelper();
            autoFac.Register();
        }


        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            if (Request.Url.ToString().Contains("log.axd"))
            {
                HttpCookie cookie = Request.Cookies["ticket"];
                if (cookie == null || cookie.Value.IsNullOrEmpty())
                {
                    Response.Redirect("~/BadRequest.html");
                    Response.End();
                }
                else
                {
                    //解密:
                    var ticket = FormsAuthentication.Decrypt(cookie.Value);
                    //判断是否过期：
                    if (ticket != null && !ticket.Expired && ticket.Name == "token")
                    {
                        //获取用户的身份信息：
                        if (ticket.UserData != "admin")
                        {
                            Response.Redirect("~/BadRequest.html");
                            Response.End();
                        }
                    }
                    else
                    {
                        Response.Redirect("~/BadRequest.html");
                        Response.End();
                    }

                }

            }

        }

    }
}
