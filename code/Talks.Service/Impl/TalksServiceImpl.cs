using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talks.Dao;
using Talks.Dao.Base;
using Talks.Dao.Impl;
using Talks.Model.Dto;
using Talks.Service.Impl.Base;

namespace Talks.Service.Impl
{
    public class TalksServiceImpl :  BaseServiceImpl<TalksDto>,ITalksService
    {
        ITalksDao dao = new TalksDaoImpl();
        public override IBaseDao<TalksDto> GetDao()
        {
            return dao;
        }

      
    }
}
