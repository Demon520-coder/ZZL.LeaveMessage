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

    [Authorize]
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

            var name = User.Identity.Name;
            //FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, "token", DateTime.Now, DateTime.Now.AddDays(1), false, "admin");

            //HttpCookie cookie = new HttpCookie("ticket");
            //cookie.Value = FormsAuthentication.Encrypt(ticket);
            //cookie.HttpOnly = true;
            //cookie.Expires = DateTime.Now.AddDays(1);
            //var reqCookie = Request.Cookies["ticket"];
            //if (reqCookie != null)
            //{
            //    reqCookie.Expires = DateTime.Now.AddYears(-1);
            //    Response.Cookies.Add(reqCookie);
            //}

            //Response.Cookies.Add(cookie);

            return View();
        }


        [AllowAnonymous]
        public ActionResult GetValidateCode()
        {
            ValidateCode validateCode = new ValidateCode();

            var codeBytes = validateCode.DrawValidateCode(validateCode._operCode);

            TempData["validateCode"] = validateCode._codeResult;

            return File(codeBytes, "image/bmp");
        }
    }
}