using Talks.Model.Base;
using Talks.Model.Dto;
using Talks.Model.Searcher.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talks.Service
{
    public interface IHomeService
    {
        PageInfo<HomeDto> BindDataList(dynamic ViewBag, AbstractSearchModel searcher);
    }
}
