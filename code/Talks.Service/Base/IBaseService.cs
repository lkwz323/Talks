using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talks.Dao.Base;
using Talks.Model.Base;
using Talks.Model.Searcher.Base;

namespace Talks.Service.Base
{
    public interface IBaseService<T>
    {
        PageInfo<T> BindDataList(dynamic ViewBag, AbstractSearchModel searcher);
        IBaseDao<T> GetDao();
    }
}
