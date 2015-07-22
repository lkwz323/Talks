using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talks.Model;

namespace Talks.Service
{
    public interface IValueCalculater
    {
        decimal ValueProducts(params Product[] products);
    }
}
