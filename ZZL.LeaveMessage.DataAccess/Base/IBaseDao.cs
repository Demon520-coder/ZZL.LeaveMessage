using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZZL.LeaveMessage.DataAccess.Base
{
    public interface IBaseDao<T> where T : class, new()
    {
        //封装所有的增删改查方法;
        IEnumerable<T> GetAll(string sql);

        IEnumerable<T> GetList(string sql, object objParam = null);

        T GetModel(string sql, object objParam = null);

        int Execute(string sql, object objParam = null, IDbTransaction tran = null);

        IEnumerable<T> GetPagedList(string sql, out int total, object objParam = null);

    }
}
