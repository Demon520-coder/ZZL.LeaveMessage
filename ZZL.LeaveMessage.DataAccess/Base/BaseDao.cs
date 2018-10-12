using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZL.LeaveMessage.Common;

namespace ZZL.LeaveMessage.DataAccess.Base
{
    public class BaseDao<T> : IBaseDao<T> where T : class, new()
    {      
        public BaseDao()
        {
            
        }

        public SqlConnection Con
        {
            get
            {
                return new SqlConnection(ConfigHelper.GetConString("con"));
            }
        }

        public IDbTransaction Tran
        {
            get
            {
                return Con.BeginTransaction();
            }
        }

        public IEnumerable<T> GetAll(string sql)
        {
            using (Con)
            {
                return Con.Query<T>(sql);
            }
        }

        public IEnumerable<T> GetList(string sql, object objParam = null)
        {
            using (Con)
            {
                return Con.Query<T>(sql, objParam);
            }
        }

        public T GetModel(string sql, object objParam = null)
        {
            using (Con)
            {
                return Con.QueryFirstOrDefault<T>(sql, objParam);
            }
        }

        public IEnumerable<T> GetPagedList(string sql, out int total, object objParam = null)
        {
            using (Con)
            {
                var multip = Con.QueryMultiple(sql, objParam);

                total = multip.Read<int>().Single();

                return multip.Read<T>();
            }
        }

        public int Execute(string sql, object objParam = null, IDbTransaction tran = null)
        {
            using (Con)
            {
                return Con.Execute(sql, objParam, tran);
            }
        }


    }
}
