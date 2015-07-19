using Talks.Model.Base;
using Talks.Model.Dto;
using Talks.Model.Searcher.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talks.Service.Impl
{
    public class HomeServiceImpl : IHomeService
    {
        public PageInfo<HomeDto> BindDataList(dynamic ViewBag, AbstractSearchModel searcher)
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

            //----------------------------------------------------------------------
            ///////////////////////////////////
            //list
            List<HomeDto> list = new List<HomeDto>();
            for (var i = 0; i < 10; i++)
            {
                list.Add(new HomeDto() { Id = i, Name = Guid.NewGuid().ToString() });
            }
            ///////////////////////////////////
            //count
            var count = 101;
            ///////////////////////////////////
            //-----------------------------------------------------------------------
           
            Page<HomeDto> page = new Page<HomeDto>();
            page.PageSize = size;
            page.PageNum=searcher.Page;
            if (null != list && list.Count > 0)
            {
                page.AddRange(list);
            }
            // 最后设置总数，里面会计算分页是否合理
            page.Total = count;
            PageInfo<HomeDto> pageInfo = new PageInfo<HomeDto>(page);
            ViewBag.PageInfo = pageInfo;
            return pageInfo;

        }
    }
}
