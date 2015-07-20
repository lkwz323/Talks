using Talks.Model.Searcher.Base;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talks.Model.Dto;

namespace Talks.Model.Searcher
{
    public class HomeSearcher : AbstractSearchModel
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Name { get; set; }

        public string Type { get; set; }





        public override SqlParameter[] GetParams()
        {
            throw new NotImplementedException();
        }

        public override string Sql
        {
            get { throw new NotImplementedException(); }
        }

        public override string OrderBy
        {
            get { throw new NotImplementedException(); }
        }
    }
}
