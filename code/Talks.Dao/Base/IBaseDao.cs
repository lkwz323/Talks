using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talks.Model.Searcher.Base;

namespace Talks.Dao.Base
{
    public interface IBaseDao<T>
    {
         List<T> GetList(AbstractSearchModel search);

         long GetCount(AbstractSearchModel search);
    }
}
