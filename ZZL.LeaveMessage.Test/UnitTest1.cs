using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZZL.LeaveMessage.Common;
using ZZL.LeaveMessage.Entity;
using ZZL.LeaveMessage.IService;
using ZZL.LeaveMessage.Service;

namespace ZZL.LeaveMessage.Test
{
    [TestClass]
    public class UnitTest1
    {
        private IUserService _userService;

        public UnitTest1()
        {
            _userService = new UserService();
        }

        [TestMethod]
        public void ConfigHelperTest()
        {
            var result = ConfigHelper.GetAppSettingsByKey(null);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void UserServiceTest()
        {
            var result = _userService.GetUser("admin");
            var user = _userService.GetUserById(1);
            //var rows = _userService.AddUser(new UserEntity() { UserName = "zzl", Pwd = "123456" });
            //Assert.IsTrue(rows == 1);
            var name =typeof(MessageService).Assembly.GetName().Name;
        }


        [TestMethod]
        public void MD5Test()
        {
            var result = "123456".CreateToMD5(false);
          
        }
    }
}
