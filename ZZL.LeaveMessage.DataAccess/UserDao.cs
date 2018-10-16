using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZL.LeaveMessage.DataAccess.Base;
using ZZL.LeaveMessage.Entity;

namespace ZZL.LeaveMessage.DataAccess
{
    public class UserDao : BaseDao<UserEntity>
    {
        public UserEntity GetUserByNameAndPwd(string userName, string pwd)
        {
            string sql = "SELECT * FROM TB_USER WHERE UserName=@userName AND Pwd=@pwd AND IsDeleted=0";

            return GetModel(sql, new { userName = userName, pwd = pwd });
        }

        public UserEntity GetUser(string userName)
        {
            string sql = "SELECT * FROM TB_USER WHERE UserName=@uname";

            return GetModel(sql, new { uname = userName });
        }

        public UserEntity GetUserById(int id)
        {
            string sql = "SELECT * FROM TB_USER WHERE Id=@id";

            return GetModel(sql, new { id = id });
        }

        public bool AddUser(UserEntity user)
        {
            string sql = "INSERT INTO TB_USER(UserName,Pwd,CreateTime,IsDeleted,Email) VALUES(@UserName,@Pwd,@CreateTime,@IsDeleted,@Email)";
            return Execute(sql, user) > 0;
        }
    }
}
