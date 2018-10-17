
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ZZL.LeaveMessage.Entity;
using ZZL.LeaveMessage.Entity.DTO;

namespace ZZL.LeaveMessage.IService
{
    public interface IMessageService
    {
        IEnumerable<MessageDto> GetMeesageList();

        bool Add(MessageEntity message);
    }
}