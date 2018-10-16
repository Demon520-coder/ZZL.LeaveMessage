using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZL.LeaveMessage.DataAccess;
using ZZL.LeaveMessage.DataAccess.Base;
using ZZL.LeaveMessage.Entity;
using ZZL.LeaveMessage.IService;

namespace ZZL.LeaveMessage.Service
{
    public class UserService :  IUserService
    {
        private readonly UserDao _userDao;

        public UserService()
        {
            _userDao = new UserDao();
        }

        public bool Register(UserEntity user)
        {
            return _userDao.AddUser(user);
        }

        public UserEntity GetUser(string userName)
        {
            return _userDao.GetUser(userName);
        }

        public UserEntity GetUserById(int id)
        {
            return _userDao.GetUserById(id);
        }

        public UserEntity Login(string userName, string pwd)
        {
            return _userDao.GetUserByNameAndPwd(userName, pwd);
        }
    }
}
