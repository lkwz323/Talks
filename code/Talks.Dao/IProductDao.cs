using IBatisNet.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talks.Model;

namespace Talks.Dao
{
    public interface IProductDao : IDao
    {
        IList<Product> GetProductList(Model.Searcher.ProductSearcher searcher);
        int GetProductCount(Model.Searcher.ProductSearcher searcher);
        string InsertProduct(Product product);
    }
}
