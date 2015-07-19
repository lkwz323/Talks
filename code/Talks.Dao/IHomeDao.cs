using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talks.Model.Dto;

namespace Talks.Dao
{
    public interface IHomeDao
    {
        List<HomeDto> getList(int pageSize);

        int getCount();
    }
}
