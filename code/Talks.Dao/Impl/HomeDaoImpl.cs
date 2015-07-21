using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talks.Model.Dto;

namespace Talks.Dao.Impl
{
    public class HomeDaoImpl : IHomeDao
    {
      
        public List<HomeDto> getList(int pageSize)
        {
            //list
            var list= new List<HomeDto>();
            return list;
        }

        public int getCount()
        {
            return 101;

        }



    }
}
