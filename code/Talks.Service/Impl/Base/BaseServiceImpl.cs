using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talks.Dao.Base;
using Talks.Model.Base;
using Talks.Model.Searcher.Base;
using Talks.Service.Base;

namespace Talks.Service.Impl.Base
{
    public abstract class BaseServiceImpl<T>:IBaseService<T>
    {
        public abstract IBaseDao<T> GetDao();

        public PageInfo<T> BindDataList(dynamic ViewBag, AbstractSearchModel searcher)
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
            //db query and or mapping

            var dao = GetDao();
            //list
            var list = dao.GetList(searcher);

            //count
            var count = dao.GetCount(searcher);


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
