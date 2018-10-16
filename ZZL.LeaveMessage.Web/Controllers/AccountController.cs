using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ZZL.LeaveMessage.Common;
using ZZL.LeaveMessage.Entity;
using ZZL.LeaveMessage.IService;
using ZZL.LeaveMessage.Web.Models;

namespace ZZL.LeaveMessage.Web.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel loginModel, string returnUrl)
        {
            string code = TempData["validateCode"]?.ToString();

            if (ModelState.IsValid)
            {
                if (loginModel.ValidateCode == code)
                {
                    UserEntity userEntity = _userService.Login(loginModel.UserName, loginModel.PassWord.CreateToMD5());
                    if (userEntity == null)
                    {
                        ModelState.AddModelError("error", "用户名或密码错误");

                        return View(loginModel);
                    }
                    else
                    {
                        //跳转
                        if (returnUrl.IsNullOrEmpty())
                        {
                            return RedirectToAction("Index", "Home");
                        }

                        returnUrl = HttpUtility.UrlDecode(returnUrl);

                        if (Url.IsLocalUrl(returnUrl))
                        {
                            //写入cookie信息;
                            FormsAuthentication.SetAuthCookie(userEntity.UserName, false);

                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return CustomerErrorActionResult.NotFundResult;
                        }
                    }
                }


                ModelState.AddModelError("error", "验证码错误");

            }

            return View(loginModel);
        }


        public ActionResult LoginOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public ActionResult Register(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;

            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel register, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var code = TempData["validateCode"]?.ToString();
                if (code == register.ValidateCode)
                {
                    //注册:
                    UserEntity userEntity = new UserEntity();
                    userEntity.UserName = register.UserName?.Trim();
                    userEntity.Pwd = register.Pwd?.Trim().CreateToMD5();
                    userEntity.Email = register.Email?.Trim();

                    if (_userService.Register(userEntity))
                    {
                        //成功
                        if (returnUrl.IsNullOrEmpty())
                        {
                            return RedirectToAction("Login", "Account");
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

                    ModelState.AddModelError("error", "注册失败");
                }
            }


            return View(register);

        }

    }
}