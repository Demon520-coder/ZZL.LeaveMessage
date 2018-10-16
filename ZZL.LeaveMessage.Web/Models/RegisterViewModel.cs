using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZZL.LeaveMessage.Web.Models
{
    public class RegisterViewModel
    {
        [DisplayName("用户名")]
        [Required(ErrorMessage = "用户名不能为空")]
        [MaxLength(10, ErrorMessage = "最多长度为10")]
        public string UserName { get; set; }

        [DisplayName("密码")]
        [Required(ErrorMessage = "密码不能为空")]
        public string Pwd { get; set; }

        [DisplayName("密码确认")]
        [Compare("Pwd", ErrorMessage = "密码输入不一致")]
        public string ConfirmPwd { get; set; }

        [DisplayName("验证码")]
        [Required(ErrorMessage = "验证码不能为空")]
        public string ValidateCode { get; set; }

        [DisplayName("邮箱")]
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+(\.[a-zA-Z0-9-]+)*\.[a-zA-Z0-9]{2,6}$", ErrorMessage = "邮箱输入不合法")]
        public string Email { get; set; }
    }
}