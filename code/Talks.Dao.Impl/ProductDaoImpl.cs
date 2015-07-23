using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talks.Dao.Impl.Base;
using Talks.Model;

namespace Talks.Dao.Impl
{
    public class ProductDaoImpl :  IProductDao
    {
        public IList<Product> GetAllProduct()
        {
            var list = BaseDao.QueryForList<Product>("GetALLProduct");
            return list;
        }

        public string InsertProduct(Model.Product product)
        {
            return BaseDao.Insert<Product>("InsertProduct", product);
        }

        public IList<Product> GetProductList(Model.Searcher.ProductSearcher searcher)
        {
            var list = BaseDao.QueryForList<Product>("GetProductList",searcher);
            return list;
        }

        public int GetProductCount(Model.Searcher.ProductSearcher searcher)
        {
            var count = BaseDao.Count("GetProductCount", searcher);
            return count;
        }
    }
}
