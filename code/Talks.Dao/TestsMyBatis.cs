using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talks.Model;

namespace Talks.Dao
{
    public class TestsMyBatis
    {
        [Test]
        public void test() {
            ProductService getproductBl = new ProductService();
            getproductBl.InsertProduct(new Product()
            {
                ProductName = "Deskshop-54",
                SignDate = DateTime.Now,
                ProductCompany = "Auto-Desk"
            });
        }
    }
}
