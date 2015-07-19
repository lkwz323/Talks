using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talks.Model.Base
{
    public class Page<E> : List<E>
    {    

        /**不进行count查询*/
        private static int NO_SQL_COUNT = -1;
        /**进行count查询*/
        private static int SQL_COUNT = 0;


        /**页码，从1开始*/
        private int pageNum;
        public int PageNum
        {
            get { return pageNum; }
            set
            {
                //分页合理化，针对不合理的页码自动处理
                pageNum = (reasonable && value <= 0) ? 1 : value;
            }
        }
        /**页面大小*/
        public int PageSize { get; set; }
        /**起始行*/
        public int StartRow { get; private set; }
        /**末行*/
        public int EndRow { get; private set; }
        /**总数*/
        private long total;
       
        public long Total
        {
            get { return total; }
            set
            {
                this.total = value;
                if (PageSize > 0)
                {
                    Pages = (int)(total / PageSize + ((total % PageSize == 0) ? 0 : 1));
                }
                else
                {
                    Pages = 0;
                }
                //分页合理化，针对不合理的页码自动处理
                if (reasonable && PageNum > Pages)
                {
                    pageNum = Pages;
                    CalculateStartAndEndRow();
                }
            }
        }
        public List<E> Result { get { return this; } }
        /**总页数*/
        public int Pages { get; private set; }
        /**分页合理化*/
        private bool reasonable = true;

        public bool Reasonable
        {
            set
            {
                this.reasonable = value;
                //分页合理化，针对不合理的页码自动处理
                if (this.reasonable && this.pageNum <= 0)
                {
                    this.pageNum = 1;
                    CalculateStartAndEndRow();
                }
            }
        }

        public Page()
        {

        }

        public Page(int pageNum, int pageSize)
        {
            this.PageNum = pageNum;
            this.PageSize = pageSize;
            this.total = SQL_COUNT;
            CalculateStartAndEndRow();

        }

        public Page(int pageNum, int pageSize, bool count)
        {

            this.PageNum = pageNum;
            this.PageSize = pageSize;
            this.total = count ? SQL_COUNT : NO_SQL_COUNT;
            CalculateStartAndEndRow();
        }

        public Page(int pageNum, int pageSize, int total)
        {

            this.PageNum = pageNum;
            this.PageSize = pageSize;
            this.total = total;
            CalculateStartAndEndRow();
        }


        /**
         * 计算起止行号
         */
        private void CalculateStartAndEndRow()
        {
            this.StartRow = this.PageNum > 0 ? (this.PageNum - 1) * this.PageSize : 0;
            this.EndRow = this.StartRow + this.PageSize * (this.PageNum > 0 ? 1 : 0);
        }

        public bool IsCount { get { return this.total > NO_SQL_COUNT; } }

    }
}

