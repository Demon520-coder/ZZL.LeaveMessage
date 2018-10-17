using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZL.LeaveMessage.DataAccess.Base;
using ZZL.LeaveMessage.Entity;
using ZZL.LeaveMessage.Entity.DTO;
using Dapper;

namespace ZZL.LeaveMessage.DataAccess
{
    public class MessageDao : BaseDao<MessageEntity>
    {
        public IEnumerable<MessageDto> GetMessageEntities()
        {
            string sql = @"SELECT M.*,U.UserName FROM TB_MESSAGE AS M INNER JOIN TB_USER AS U 
                           ON M.UserId=U.Id AND U.IsDeleted=0  WHERE M.IsDeleted=0";

            return Con.Query<MessageDto>(sql);
        }

        public bool Add(MessageEntity message)
        {
            string sql = @"INSERT INTO TB_MESSAGE(Title,Content,UserId,CreateTime,IsDeleted) VALUES(@Title,@Content,@UserId,@CreateTime,@IsDeleted)";

            return Con.Execute(sql, message) > 0;
        }
    }
}
