using Talks.Model.Base;
using Talks.Model.Dto;
using Talks.Model.Searcher.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talks.Dao;
using Talks.Dao.Impl;

namespace Talks.Service.Impl
{
    public class HomeServiceImpl : IHomeService
    {
        IHomeDao dao = new HomeDaoImpl();
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
            var list = dao.getList(searcher.PageSize);
           
            ///////////////////////////////////
            //count
           var count = dao.getCount();
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
