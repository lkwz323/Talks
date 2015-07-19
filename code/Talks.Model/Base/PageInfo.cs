using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talks.Model.Base
{
    public class PageInfo<T>
    {
        // 当前页
        public int PageNum { get; set; }
        // 每页的数量
        public int PageSize { get; private set; }
        // 当前页的数量
        public int Size { get; private set; }
        // 由于startRow和endRow不常用，这里说个具体的用法
        // 可以在页面中"显示startRow到endRow 共size条数据"

        // 当前页面第一个元素在数据库中的行号
        public int StartRow { get; private set; }
        // 当前页面最后一个元素在数据库中的行号
        public int EndRow { get; private set; }
        // 总记录数
        public long Total { get; private set; }
        // 总页数
        public int Pages { get; private set; }
        // 结果集
        public Page<T> DataList { get; private set; }

        // 第一页
        public int FirstPage { get; private set; }
        // 前一页
        public int PrePage { get; private set; }
        // 下一页
        public int NextPage { get; private set; }
        // 最后一页
        public int LastPage { get; private set; }

        // 是否为第一页
        public bool IsFirstPage { get; private set; }
        // 是否为最后一页
        public bool IsLastPage { get; private set; }
        // 是否有前一页
        public bool HasPreviousPage { get; private set; }
        // 是否有下一页
        public bool HasNextPage { get; private set; }
        // 导航页码数
        public int NavigatePages { get; private set; }
        // 所有导航页号
        public int[] NavigatepageNums { get; private set; }

        /**
         * 包装Page对象
         *
         * @param list
         */
        public PageInfo(Page<T> page)
            : this(page, 8)
        {

        }

        /**
         * 包装Page对象
         *
         * @param list
         *            page结果
         * @param navigatePages
         *            页码数量
         */
        public PageInfo(Page<T> page, int navigatePages)
        {
            IsFirstPage = false;
            IsLastPage = false;
            HasPreviousPage = false;
            HasNextPage = false;


            this.PageNum = page.PageNum;
            this.PageSize = page.PageSize;

            this.Total = page.Total;
            this.Pages = page.Pages;
            this.DataList = page;
            this.Size = page.Count;
            // 由于结果是>startRow的，所以实际的需要+1
            if (this.Size == 0)
            {
                this.StartRow = 0;
                this.EndRow = 0;
            }
            else
            {
                this.StartRow = page.StartRow + 1;
                // 计算实际的endRow（最后一页的时候特殊）
                this.EndRow = this.StartRow - 1 + this.Size;
            }
            this.NavigatePages = navigatePages;
            // 计算导航页
            CalcNavigatepageNums();
            // 计算前后页，第一页，最后一页
            CalcPage();
            // 判断页面边界
            JudgePageBoudary();

        }

        /**
         * 计算导航页
         */
        private void CalcNavigatepageNums()
        {
            // 当总页数小于或等于导航页码数时
            if (Pages <= NavigatePages)
            {
                NavigatepageNums = new int[Pages];
                for (int i = 0; i < Pages; i++)
                {
                    NavigatepageNums[i] = i + 1;
                }
            }
            else
            { // 当总页数大于导航页码数时
                NavigatepageNums = new int[NavigatePages];
                int startNum = PageNum - NavigatePages / 2;
                int endNum = PageNum + NavigatePages / 2;

                if (startNum < 1)
                {
                    startNum = 1;
                    // (最前navigatePages页
                    for (int i = 0; i < NavigatePages; i++)
                    {
                        NavigatepageNums[i] = startNum++;
                    }
                }
                else if (endNum > Pages)
                {
                    endNum = Pages;
                    // 最后navigatePages页
                    for (int i = NavigatePages - 1; i >= 0; i--)
                    {
                        NavigatepageNums[i] = endNum--;
                    }
                }
                else
                {
                    // 所有中间页
                    for (int i = 0; i < NavigatePages; i++)
                    {
                        NavigatepageNums[i] = startNum++;
                    }
                }
            }
        }

        /**
         * 计算前后页，第一页，最后一页
         */
        private void CalcPage()
        {
            if (NavigatepageNums != null && NavigatepageNums.Length > 0)
            {
                FirstPage = NavigatepageNums[0];
                LastPage = NavigatepageNums[NavigatepageNums.Length - 1];
                if (PageNum > 1)
                {
                    PrePage = PageNum - 1;
                }
                if (PageNum < Pages)
                {
                    NextPage = PageNum + 1;
                }
            }
        }

        /**
         * 判定页面边界
         */
        private void JudgePageBoudary()
        {
            IsFirstPage = PageNum == 1;
            IsLastPage = PageNum == Pages;
            HasPreviousPage = PageNum > 1;
            HasNextPage = PageNum < Pages;
        }

    }
}
