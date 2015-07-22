using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talks.Service.Impl
{
    public class Init
    {
        //Inject绑定接口与实现
        public static void Bind(StandardKernel kernel)
        {
            kernel.Bind<IProductService>().To<ProductServiceImpl>();

        }
    }
}
