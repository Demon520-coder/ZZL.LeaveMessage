using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZZL.LeaveMessage.Web
{
    public class LoginFilterAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// 授权验证
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.Request.IsAuthenticated)
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.Result = new JsonResult()
                    {
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        Data = new
                        {
                            msg = "登陆超时",
                            isOk = false
                        }
                    };

                    return;

                }
                else
                {
                    filterContext.Result = new RedirectResult("/Account/Login");
                    return;
                }
            }
            
            
            base.OnAuthorization(filterContext);
        }
    }
}