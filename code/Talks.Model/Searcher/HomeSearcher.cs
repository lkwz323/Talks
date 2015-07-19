using Talks.Model.Searcher.Base;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talks.Model.Searcher
{
    public class HomeSearcher : AbstractSearchModel
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Name { get; set; }

        public string Type { get; set; }


        public override System.Data.SqlClient.SqlParameter[] GetParams()
        {
            List<SqlParameter> list = new List<SqlParameter>();
            return list.ToArray();
        }

        public override string GetWheres()
        {
            string where="";
            return where;
        }
    }
}
