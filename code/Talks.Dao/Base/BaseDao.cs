using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using log4net;
using Talks.Dao.Base.TuanDataAccess;

namespace Talks.Dao.Base
{
    public class BaseDao : DataAccessBase
    {
        #region =从数据库中查询数据=
        protected DataSet GetDataSet(string strSql, SqlParameter[] parameters)
        {
            DataSet dataSet;
            using (var connection = ConnFactory.CreateConnection(true))
            {
                connection.Open();
                dataSet = GetDataSet(connection, strSql, parameters);
            }
            return dataSet;
        }
        #endregion
        #region =从数据库中查询数据=
        protected DataSet GetDataSetRead(string strSql, SqlParameter[] parameters)
        {
            DataSet dataSet;
            using (var connection = ConnFactory.CreateConnection())
            {
                connection.Open();
                dataSet = GetDataSet(connection, strSql, parameters);
            }
            return dataSet;
        }
        #endregion

       

        #region =从数据库中查询数据=
        protected DataSet GetDataSet(SqlConnection connection, string strSql, SqlParameter[] parameters)
        {
            var dataSet = new DataSet();
            using (var command = new SqlCommand(strSql, connection))
            {
                if (parameters != null && parameters.Length > 0)
                {
                    command.Parameters.AddRange(parameters);
                }
                try
                {
                    var adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataSet);

                }
                catch (Exception ex)
                {
                    Logger.Error("DaBase执行查询出错:" + ex.Message + ":" + strSql, ex);
                }
            }
            return dataSet;
        }
        #endregion

        #region ConverDataRowValueToValue
        public string GetStr(object o)
        {
            return o == null || o is DBNull ? "" : o.ToString();
        }

        public int GetInt(object o)
        {
            int i;
            int.TryParse((o ?? "").ToString(), out i);
            return i;
        }

        public decimal GetDec(object o)
        {
            return o == null || o is DBNull ? 0 : (decimal)o;
        }

        public DateTime GetDateTime(object o)
        {
            return o == null || o is DBNull ? DateTime.MinValue : (DateTime)o;
        }

        public bool GetBool(object o)
        {
            return o != null && !(o is DBNull) && (bool)o;
        }
        #endregion

        private const string PagingSql = "SELECT * FROM (SELECT ROW_NUMBER() OVER (ORDER BY {1}) AS DataRowNumber, * FROM ({0}) AS OriginDataTable ) AS DataTableWithRowNumber WHERE DataRowNumber BETWEEN {2} AND {3} ORDER BY DataRowNumber ASC;";

        public string WrapSqlWithPaging(string originSql, string orderByClause, int start, int end)
        {
            return string.Format(PagingSql, originSql, orderByClause, start, end);
        }
    }
}
