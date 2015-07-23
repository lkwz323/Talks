using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talks.Model;
using Talks.Model.Base;

namespace Talks.Service
{
    public interface IProductService
    {
       
        string InserProduct(Product product);

        PageInfo<Product> BindList(dynamic ViewBag, Model.Searcher.ProductSearcher searcher);
    }
}
