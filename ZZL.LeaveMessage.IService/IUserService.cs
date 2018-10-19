using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZL.LeaveMessage.DataAccess;
using ZZL.LeaveMessage.DataAccess.Base;
using ZZL.LeaveMessage.Entity;

namespace ZZL.LeaveMessage.IService
{
    public interface IUserService : ICloneable
    {
        UserEntity GetUser(string userName);

        UserEntity GetUserById(int id);

        bool Register(UserEntity user);

        UserEntity Login(string userName, string pwd);

        IUserService CloneObj();
    }
}
