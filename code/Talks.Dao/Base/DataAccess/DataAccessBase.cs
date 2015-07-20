
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Talks.Dao.Base.DataAccess
{
    /// <summary>
    /// 数据库访问基类
    /// </summary>
    public class DataAccessBase
    {
        /// <summary>
        /// 连接串工厂
        /// </summary>
        protected DataBaseConnectionFactory ConnFactory = DataBaseConnectionFactory.Current;
        /// <summary>
        /// 日志记录者
        /// </summary>
        protected log4net.ILog Logger = log4net.LogManager.GetLogger("GP");

        #region DataSet is not Null or DataSet Contains Table
        /// <summary>
        /// dataSet是否不为空
        /// </summary>
        /// <param name="ds">The ds.</param>
        /// <returns>
        /// 	<c>true</c> if [is not null] [the specified ds]; otherwise, <c>false</c>.
        /// </returns>
        protected bool IsNotNull(DataSet ds)
        {
            return ds == null;
        }

        /// <summary>
        /// dataset是否包含表
        /// </summary>
        /// <param name="ds">The ds.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <returns>
        /// 	<c>true</c> if [is contain table] [the specified ds]; otherwise, <c>false</c>.
        /// </returns>
        protected bool IsContainTable(DataSet ds, string tableName)
        {
            return ds != null && ds.Tables != null && ds.Tables.Contains(tableName);
        }

        /// <summary>
        /// DataSet是否包含表并且表中有记录
        /// </summary>
        /// <param name="ds">The ds.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <returns>
        /// 	<c>true</c> if [is this table contain rows] [the specified ds]; otherwise, <c>false</c>.
        /// </returns>
        protected bool IsThisTableContainRows(DataSet ds, string tableName)
        {
            return IsContainTable(ds, tableName) && ds.Tables[tableName].Rows.Count > 0;
        }
        #endregion

        #region ExecuteNonQuery

        protected int ExecuteNonQuery(SqlConnection connection, string commandText)
        {
            return ExecuteNonQuery(connection, commandText, (SqlParameter[])null);
        }

        protected int ExecuteNonQuery(SqlConnection connection, string commandText, SqlParameter[] commandParameters)
        {
            return SqlHelper.ExecuteNonQuery(connection, CommandType.Text, commandText, commandParameters);
        }

        protected int ExecuteNonQuery(SqlTransaction transaction, string commandText)
        {
            return ExecuteNonQuery(transaction, commandText, (SqlParameter[])null);
        }

        protected int ExecuteNonQuery(SqlTransaction transaction, string commandText, SqlParameter[] commandParameters)
        {
            return SqlHelper.ExecuteNonQuery(transaction, CommandType.Text, commandText, commandParameters);
        }
        #endregion ExecuteNonQuery

        #region ExecuteDataset
        protected DataSet ExecuteDataset(SqlConnection connection, string commandText)
        {
            return ExecuteDataset(connection, commandText, (SqlParameter[])null);
        }


        protected DataSet ExecuteDataset(SqlConnection connection, string commandText, SqlParameter[] commandParameters)
        {
            return SqlHelper.ExecuteDataset(connection, CommandType.Text, commandText, commandParameters);
        }


        protected DataSet ExecuteDataset(SqlTransaction transaction, string commandText)
        {

            return ExecuteDataset(transaction, commandText, (SqlParameter[])null);
        }


        protected DataSet ExecuteDataset(SqlTransaction transaction, string commandText, SqlParameter[] commandParameters)
        {
            return SqlHelper.ExecuteDataset(transaction, CommandType.Text, commandText, commandParameters);
        }

        #endregion ExecuteDataset

        #region ExecuteReader
        protected SqlDataReader ExecuteReader(SqlConnection connection, string commandText)
        {
            return ExecuteReader(connection, commandText, (SqlParameter[])null);
        }


        protected SqlDataReader ExecuteReader(SqlConnection connection, string commandText, SqlParameter[] commandParameters)
        {
            return SqlHelper.ExecuteReader(connection, CommandType.Text, commandText, commandParameters);
        }

        protected SqlDataReader ExecuteReader(SqlTransaction transaction, string commandText)
        {
            return ExecuteReader(transaction, commandText, (SqlParameter[])null);
        }


        protected SqlDataReader ExecuteReader(SqlTransaction transaction, string commandText, SqlParameter[] commandParameters)
        {
            return SqlHelper.ExecuteReader(transaction, CommandType.Text, commandText, commandParameters);
        }
        #endregion ExecuteReader

        #region ExecuteScalar

        protected object ExecuteScalar(SqlConnection connection, string commandText)
        {
            return ExecuteScalar(connection, commandText, (SqlParameter[])null);
        }


        protected object ExecuteScalar(SqlConnection connection, string commandText, SqlParameter[] commandParameters)
        {
            return SqlHelper.ExecuteScalar(connection, CommandType.Text, commandText, commandParameters);
        }


        protected object ExecuteScalar(SqlTransaction transaction, string commandText)
        {
            return ExecuteScalar(transaction, commandText, (SqlParameter[])null);
        }


        protected static object ExecuteScalar(SqlTransaction transaction, string commandText, SqlParameter[] commandParameters)
        {
            return SqlHelper.ExecuteScalar(transaction, CommandType.Text, commandText, commandParameters);
        }

        #endregion ExecuteScalar


        #region ExecuteNonQuery 

        protected int ExecuteNonQuery(string commandText)
        {
            return ExecuteNonQuery(commandText, (SqlParameter[])null);
        }

        protected int ExecuteNonQuery(string commandText, SqlParameter[] commandParameters)
        {
            using (SqlConnection connection = ConnFactory.CreateConnection())
            {
                connection.Open();
                return SqlHelper.ExecuteNonQuery(connection, CommandType.Text, commandText, commandParameters);
            }
        }
        #endregion ExecuteNonQuery 

        #region ExecuteDataset 
        protected DataSet ExecuteDataset(string commandText)
        {
            return ExecuteDataset(commandText, (SqlParameter[])null);
        }


        protected DataSet ExecuteDataset(string commandText, SqlParameter[] commandParameters)
        {
            using (SqlConnection connection = ConnFactory.CreateConnection())
            {
                connection.Open();
                return SqlHelper.ExecuteDataset(connection, CommandType.Text, commandText, commandParameters);
            }
        }
        #endregion ExecuteDataset 

        #region ExecuteScalar 

        protected object ExecuteScalar(string commandText)
        {
            return ExecuteScalar(commandText, (SqlParameter[])null);
        }


        protected object ExecuteScalar(string commandText, SqlParameter[] commandParameters)
        {
            using (SqlConnection connection = ConnFactory.CreateConnection())
            {
                connection.Open();
                return SqlHelper.ExecuteScalar(connection, CommandType.Text, commandText, commandParameters);
            }
        }
        #endregion ExecuteScalar 
    }
}
