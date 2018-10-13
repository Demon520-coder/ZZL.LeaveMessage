using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZZL.LeaveMessage.Common;
using PagedList;
using ZZL.LeaveMessage.IService;

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
            var list = _messageService.GetMeesageList();

            return View();
        }
    }
}