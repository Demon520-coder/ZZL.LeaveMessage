using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZZL.LeaveMessage.Common;
using PagedList;
using ZZL.LeaveMessage.IService;
using System.Web.Security;

namespace ZZL.LeaveMessage.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly IMessageService _messageService;

        public HomeController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        // GET: Home
        public ActionResult Index()
        {
            //var t = Convert.ToInt32("x");
            var list = _messageService.GetMeesageList();

            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, "token", DateTime.Now, DateTime.Now.AddDays(1), false, "admin");

            HttpCookie cookie = new HttpCookie("ticket");
            cookie.Value = FormsAuthentication.Encrypt(ticket);
            cookie.HttpOnly = true;
            cookie.Expires = DateTime.Now.AddDays(1);
            var reqCookie = Request.Cookies["ticket"];
            if (reqCookie != null)
            {
                reqCookie.Expires = DateTime.Now.AddYears(-1);
                Response.Cookies.Add(reqCookie);
            }

            Response.Cookies.Add(cookie);

            return View();
        }



        public ActionResult GetValidateCode()
        {
            ValidateCode validateCode = new ValidateCode(ValidateType.AllLetter);
            
            var codeBytes = validateCode.DrawValidateCode();

            return File(codeBytes, "image/bmp");
        }
    }
}