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
        TalksDBContext db = new TalksDBContext();
        public List<HomeDto> getList(int pageSize)
        {
            //list
            var list = db.HomeDtos.Take(pageSize).ToList();
            return list;
        }

        public int getCount()
        {
            ///////////////////////////////////
            //count
            int count = 101;
            return count;
        }



    }
}
