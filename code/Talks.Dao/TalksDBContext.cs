using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talks.Model.Dto;

namespace Talks.Dao
{
    public class TalksDBContext : DbContext
    {
        public TalksDBContext()
            : base("name=TalksDB")
        {
        }
        /// <summary>
        /// 测试用
        /// </summary>
        public DbSet<HomeDto> HomeDtos { get;set;}

    }
}
