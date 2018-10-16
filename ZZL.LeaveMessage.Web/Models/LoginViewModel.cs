using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZZL.LeaveMessage.Web.Models
{
    [Bind(Include = "UserName,PassWord,ValidateCode")]
    public class LoginViewModel
    {
        [DisplayName("用户名")]
        [Required(ErrorMessage = "用户名不能为空")]
        public string UserName { get; set; }
        [DisplayName("密码")]
        [Required(ErrorMessage = "密码不能为空")]
        public string PassWord { get; set; }

        [DisplayName("验证码")]
        [Required(ErrorMessage ="验证码不能为空")]
        public string ValidateCode { get; set; }

        public bool Remember { get; set; }
    }
}