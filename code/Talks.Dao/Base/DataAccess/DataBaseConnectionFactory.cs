using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;

namespace Talks.Dao.Base.DataAccess
{
    /// <summary>
    /// 连接串工厂
    /// </summary>
    public class DataBaseConnectionFactory
    {
        public static DataBaseConnectionFactory Current = new DataBaseConnectionFactory();
        public static readonly string DBConn = "DefaultConnection";
        /// <summary>
        /// 连接串
        /// </summary>
        private readonly string ConnectionString;

        /// <summary>
        /// 构造函数<see cref="DataBaseConnectionFactory"/> class.
        /// </summary>
        public DataBaseConnectionFactory()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings[DBConn].ConnectionString;
        }
  
        /// <summary>
        /// 数据库链接
        /// </summary>
        /// <returns></returns>
        public SqlConnection CreateConnection()
        {
            return new SqlConnection(ConnectionString);
        }

       

       
    }
}
