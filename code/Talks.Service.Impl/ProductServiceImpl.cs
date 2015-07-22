using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talks.Dao;

namespace Talks.Service.Impl
{
    public class ProductServiceImpl : IProductService
    {
        [Inject]
        public IProductDao productDao { get; set; }

        public IList<Model.Product> GetAllProduct()
        {
            return productDao.GetAllProduct();
        }

        public string InserProduct(Model.Product product)
        {
           return productDao.InserProduct(product);
        }
    }
}
