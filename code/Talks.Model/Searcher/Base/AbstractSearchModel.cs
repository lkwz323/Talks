using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talks.Model.Searcher.Base
{
    public abstract class AbstractSearchModel
    {
        public abstract SqlParameter[] GetParams();

        public abstract string Sql { get; }

        public abstract string OrderBy { get; }



        /**
         * 分页号
         */
        private int page = 0;
        public int Page
        {
            get
            {
                if (page < 1)
                {
                    page = 1;
                }
                return page;

            }
            set
            {
                this.page = value;
            }
        }

        /**
         * 每页记录数
         */
        public int PageSize = 20;

        /**
         * 获取列表的开始位置
         * 
         * @return the start
         */
        public int Start
        {
            get
            {
                if (page < 1)
                {
                    page = 1;
                }
                return (page - 1) * PageSize;
            }

        }


        /**
         * 获取列表的结束位置
         * 
         * @return the limit
         */
        public int Limit
        {
            get { return  PageSize; }
        }

        public int End {
            get { return Start + PageSize; }
        }



        public void SetPageParam()
        {

            //获取属性信息
            var myproperties = this.GetType().GetProperties();
            string pars = "";
            var idx = 0;
            foreach (var p in myproperties)
            {
                if (idx++ > 100)
                {
                    break;
                }
                if (p.Name == "Page"
                    || p.Name == "Start"
                    || p.Name == "Limit"
                    || p.Name == "PageSize"
                    || !p.CanRead)
                {
                    continue;
                }
                
                try
                {
                    var v =p.GetValue(this,null)+ "";
                    if (v == null || v == "")
                    {
                        continue;
                    }
                    pars += "&"+p.Name + "=" + v ;
                }
                catch { }


            }


            PageParam = pars.TrimEnd('&');
        }

        public string PageParam
        {
            get;
            set;
        }
    }
}

