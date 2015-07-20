using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using log4net;
using Talks.Dao.Base.DataAccess;

namespace Talks.Dao.Base
{
    public class BaseDao : DataAccessBase
    {
        #region =从数据库中查询数据=
        protected DataSet GetDataSet(string strSql, SqlParameter[] parameters)
        {
            return ExecuteDataset(strSql, parameters);
        }

        protected DataSet GetDataSetPage(string strSql, SqlParameter[] parameters,string orderBy,int start,int end)
        {
            var sql = this.WrapSqlWithPaging(strSql, orderBy, start, end);
            return ExecuteDataset(sql, parameters);
        }
        #endregion

        #region =从数据库中查询数据=
        protected long GetDataCount(string strSql, SqlParameter[] parameters)
        {
            var sql = WrapSqlWithCounting(strSql);
            object o = ExecuteScalar(sql, parameters);
            long i;
            long.TryParse((o ?? "").ToString(), out i);
            return i;
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

        private const string CountingSql = "SELECT COUNT(*) as cnt FROM ({0}) AS t ";

        private string WrapSqlWithCounting(string originSql)
        {
            return string.Format(CountingSql, originSql);
        }

    }
}
