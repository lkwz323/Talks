using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talks.Model.Base;
using Talks.Model.Searcher.Base;

namespace Talks.Dao.Base
{
    public class BaseSearchDao<T> : BaseDao where T : BaseDto, new()
    {
        public List<T> GetList(AbstractSearchModel search)
        {

            var ds = GetDataSetPage(search.Sql, search.GetParams(), search.OrderBy, search.Start, search.End);
            var list = new List<T>();
            if (ds == null || ds.Tables == null || ds.Tables.Count == 0)
            {
                return list;
            }
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                var d = new T();
                d.Bind(dr);
                list.Add(d);
            }
            return list;
        }

        public long GetCount(AbstractSearchModel search)
        {
            long cnt = GetDataCount(search.Sql, search.GetParams());
            return cnt;
        }
    }
}
