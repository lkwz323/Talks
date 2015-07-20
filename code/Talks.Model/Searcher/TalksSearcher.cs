using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talks.Model.Dto;
using Talks.Model.Searcher.Base;

namespace Talks.Model.Searcher
{
    public class TalksSearcher : AbstractSearchModel
    {
        private string sql = "";
        public string Id { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 演讲者
        /// </summary>
        public string Speaker { get; set; }
        /// <summary>
        /// 分类
        /// </summary>
        public string Category { get; set; }


        public override System.Data.SqlClient.SqlParameter[] GetParams()
        {
            return null;
        }

        public override string Sql
        {
            get { return sql; }
        }

        public override string OrderBy
        {
            get { return " AddTime desc"; }
        }
    }
}
