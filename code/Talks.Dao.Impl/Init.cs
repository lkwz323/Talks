using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talks.Dao.Impl
{
    public class Init
    {
        //Inject绑定接口与实现
        public static void Bind(StandardKernel kernel)
        {
            kernel.Bind<IProductDao>().To<ProductDaoImpl>();
        }
    }
}
