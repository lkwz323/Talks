using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talks.Dao.Base;
using Talks.Model.Dto;
using Talks.Model.Searcher.Base;

namespace Talks.Dao
{
    public interface ITalksDao : IBaseDao<TalksDto>
    {
        
    }
}
