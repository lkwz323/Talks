using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talks.Model.Dto;
using Talks.Service.Base;

namespace Talks.Service
{
    public interface ITalksService : IBaseService<TalksDto>
    {
    }
}
