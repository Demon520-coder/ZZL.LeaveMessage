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
            var name = typeof(MessageService).Assembly.GetName().Name;
        }


        [TestMethod]
        public void MD5Test()
        {
            var result = "123456".CreateToMD5(false);

        }

        [TestMethod]
        public void ValidateCodeTest()
        {
            ValidateCode validate = new ValidateCode(ValidateType.Mix);
            //var code = validate.CreateValidateCode();
            //byte[] byts = validate.DrawValidateCode();
            //Assert.IsTrue(validate._code.IsInt());
        }

        [TestMethod]
        public void OperValidateCode()
        {
            ValidateCode validate = new ValidateCode();

        }

        [TestMethod]
        public void CloneTest()
        {
            var cloneObj = (UserService)_userService.CloneObj(); //浅复制;
            var depetCloneObj = (UserService)_userService.Clone(); //深度复制;
            Assert.AreSame(_userService, cloneObj);
            Assert.AreSame(_userService, depetCloneObj);
        }
    }
}
