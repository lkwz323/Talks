using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talks.Model.Base
{
    public abstract class BaseDto 
    {
        public abstract void Bind(DataRow dr);
    }
}
