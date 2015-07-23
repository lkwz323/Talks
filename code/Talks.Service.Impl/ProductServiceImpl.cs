using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talks.Dao;
using Talks.Model;
using Talks.Model.Base;

namespace Talks.Service.Impl
{
    public class ProductServiceImpl : BaseService, IProductService
    {
        [Inject]
        public IProductDao productDao { get; set; }


        public PageInfo<Product> BindList(dynamic viewBag, Model.Searcher.ProductSearcher searcher)
        {
            //list
            Func<IList<Product>> funList = () => productDao.GetProductList(searcher);
            //count
            Func<int> funCount = () => productDao.GetProductCount(searcher);
            //query and bind
            return BindList<Product>(viewBag, searcher, funList, funCount);


        }

        public string InserProduct(Model.Product product)
        {
            return productDao.InsertProduct(product);
        }
    }
}
