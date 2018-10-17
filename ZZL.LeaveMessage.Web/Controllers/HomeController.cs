using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZZL.LeaveMessage.Common;
using PagedList;
using ZZL.LeaveMessage.IService;
using System.Web.Security;
using ZZL.LeaveMessage.Web.Models;
using ZZL.LeaveMessage.Entity;

namespace ZZL.LeaveMessage.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly IUserService _userService;

        public HomeController(IMessageService messageService, IUserService userService)
        {
            _messageService = messageService;
            _userService = userService;
        }

        [AllowAnonymous]
        // GET: Home
        public ActionResult Index(int? pageIndex = 1, int? pageSize = 10)
        {
            pageIndex = pageIndex >= 1 ? pageIndex : 1;
            pageSize = pageSize >= 1 ? pageSize : 10;
            var list = _messageService.GetMeesageList();

            return View(list.ToPagedList(pageIndex.Value, pageSize.Value));
        }

        [AllowAnonymous]
        public ActionResult GetValidateCode()
        {
            ValidateCode validateCode = new ValidateCode();

            var codeBytes = validateCode.DrawValidateCode(validateCode._operCode);

            TempData["validateCode"] = validateCode._codeResult;

            return File(codeBytes, "image/bmp");
        }

        [HttpGet]
        public ActionResult LeaveMessage()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LeaveMessage(MessageViewModel message, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                //获得用户信息:
                var userEntity = _userService.GetUser(User.Identity.Name);
                if (userEntity != null)
                {
                    MessageEntity messageEntity = new MessageEntity
                    {
                        Title = message.Title?.Trim(),
                        Content = message.Content?.Trim(),
                        UserId = userEntity.Id
                    };

                    if (_messageService.Add(messageEntity))
                    {
                        if (returnUrl.IsNullOrEmpty())
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            returnUrl = HttpUtility.UrlDecode(returnUrl);
                            if (Url.IsLocalUrl(returnUrl))
                            {
                                return Redirect(returnUrl);
                            }
                            else
                            {
                                return CustomerErrorActionResult.BadRequestResult;
                            }
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("error", "留言失败");
                    }
                }
                else
                {
                    return RedirectToAction("Login", "Account");

                }
            }

            return View(message);
        }

    }
}