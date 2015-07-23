using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talks.Model.Base;
using Talks.Model.Searcher.Base;

namespace Talks.Service.Impl
{
    public class BaseService
    {
        public PageInfo<T> BindList<T>(dynamic ViewBag, AbstractSearchModel searcher,
            Func<IList<T>> FGetLIst,
              Func<int> FCount
            )
        {
            searcher.SetPageParam();
            //回显查询条件
            ViewBag.Searcher = searcher;

            // start计算
            int start = 0;
            if (searcher.Page > 1)
            {
                start = (searcher.Page - 1) * searcher.PageSize;
            }
            // 页大小
            int size = searcher.PageSize;

            //list
            var list = FGetLIst();

            //count
            var count = FCount();

            Page<T> page = new Page<T>();
            page.PageSize = size;
            page.PageNum = searcher.Page;
            if (null != list && list.Count > 0)
            {
                page.AddRange(list);
            }
            // 最后设置总数，里面会计算分页是否合理
            page.Total = count;
            PageInfo<T> pageInfo = new PageInfo<T>(page);
            ViewBag.PageInfo = pageInfo;
            return pageInfo;

        }
    }
}
