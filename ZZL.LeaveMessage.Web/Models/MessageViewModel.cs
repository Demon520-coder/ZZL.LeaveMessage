using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZZL.LeaveMessage.Web.Models
{
    public class MessageViewModel
    {
        [DisplayName("标题")]
        [Required(ErrorMessage ="标题不能为空")]
        public string Title { get; set; }

        [DisplayName("内容")]
        [Required(ErrorMessage ="留言内容不能为空")]
        [MaxLength(500,ErrorMessage ="留言内容字数最多为500个")]
        public string Content { get; set; }
    }
}