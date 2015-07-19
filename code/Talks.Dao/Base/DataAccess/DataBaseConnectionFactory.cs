using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;

namespace Talks.Dao.Base.TuanDataAccess
{
    /// <summary>
    /// 连接串工厂
    /// </summary>
    public class DataBaseConnectionFactory
    {
        public static DataBaseConnectionFactory Current = new DataBaseConnectionFactory();

        /// <summary>
        /// 只读库连接串
        /// </summary>
        private readonly string ConnectionStringRead;
        /// <summary>
        /// 写库连接串
        /// </summary>
        private readonly string ConnectionStringWrite;



        /// <summary>
        /// 根据连接串key读取配置文件中的连接串
        /// </summary>
        /// <param name="key">数据库连接串key.</param>
        /// <returns></returns>
        protected string GetConnectionString(string key)
        {
            var connStr = ConfigurationManager.ConnectionStrings[key].ConnectionString;
            return connStr;
        }





        /// <summary>
        /// 获取配置值.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        protected string GetAppSetting(string key)
        {
            return ConfigurationManager.AppSettings[key] ?? "";
        }


        /// <summary>
        /// 只读库.
        /// </summary>
        /// <returns></returns>
        protected SqlConnection CreateConnectionRead()
        {
            return new SqlConnection(ConnectionStringRead);
        }

        /// <summary>
        /// 写库.
        /// </summary>
        /// <returns></returns>
        protected SqlConnection CreateConnectionWrite()
        {
            return new SqlConnection(ConnectionStringWrite);
        }

        /// <summary>
        /// 构造函数<see cref="DataBaseConnectionFactory"/> class.
        /// </summary>
        public DataBaseConnectionFactory()
        {
            ConnectionStringRead = GetConnectionString(DataBaseConfigKeys.TuanReadKey);
            ConnectionStringWrite = GetConnectionString(DataBaseConfigKeys.TuanWriteKey);
        }

        /// <summary>
        /// 数据库链接
        /// </summary>
        /// <param name="isWrite">写库<c>true</c> [is write].</param>
        /// <returns></returns>
        public SqlConnection CreateConnection(bool isWrite = false)
        {
            return isWrite ? CreateConnectionWrite() : CreateConnectionRead();
        }





    }
}
