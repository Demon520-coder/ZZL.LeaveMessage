using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZL.LeaveMessage.DataAccess;
using ZZL.LeaveMessage.Entity;
using ZZL.LeaveMessage.Entity.DTO;
using ZZL.LeaveMessage.IService;

namespace ZZL.LeaveMessage.Service
{
    public class MessageService : IMessageService
    {
        private readonly MessageDao _messageDao;

        public MessageService()
        {
            _messageDao = new MessageDao();
        }

        public IEnumerable<MessageDto> GetMeesageList()
        {
            return _messageDao.GetMessageEntities();
        }
    }
}
