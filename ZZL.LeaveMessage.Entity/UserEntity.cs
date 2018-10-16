using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZZL.LeaveMessage.Entity
{
    public class UserEntity : BaseEntity
    {
        public string UserName { get; set; }

        public string Pwd { get; set; }

        public string Email { get; set; }

    }
}
