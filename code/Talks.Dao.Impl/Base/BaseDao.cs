using IBatisNet.DataMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talks.Dao.Impl.Base
{
    public static class BaseDao
    {
        public static string Insert<T>(string statementName, T t)
        {
            ISqlMapper iSqlMapper = Mapper.Instance();
            if (iSqlMapper != null)
            {
                return (string)iSqlMapper.Insert(statementName, t);
            }
            return null;
        }

        public static int Update<T>(string statementName, T t)
        {
            ISqlMapper iSqlMapper = Mapper.Instance();
            if (iSqlMapper != null)
            {
                return iSqlMapper.Update(statementName, t);
            }
            return 0;
        }

        public static int Delete(string statementName, int primaryKeyId)
        {
            ISqlMapper iSqlMapper = Mapper.Instance();
            if (iSqlMapper != null)
            {
                return iSqlMapper.Delete(statementName, primaryKeyId);
            }
            return 0;
        }

        public static T Get<T>(string statementName, string primaryKeyId) where T : class
        {
            ISqlMapper iSqlMapper = Mapper.Instance();
            if (iSqlMapper != null)
            {
                return iSqlMapper.QueryForObject<T>(statementName, primaryKeyId);
            }
            return null;
        }

        public static IList<T> QueryForList<T>(string statementName, object parameterObject = null)
        {
            ISqlMapper iSqlMapper = Mapper.Instance();
            if (iSqlMapper != null)
            {
                return iSqlMapper.QueryForList<T>(statementName, parameterObject);
            }
            return null;
        }
    }
}
