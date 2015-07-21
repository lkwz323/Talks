using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talks.Model;

namespace Talks.Dao
{
    public class ProductService
    {
        public void InsertProduct(Product getproduct)
        {
            //ISqlMapper _getsqlManager = null;
            //DomSqlMapBuilder getdombuilder = new DomSqlMapBuilder();

            //if (getdombuilder != null)
            //    ProductService._getsqlmapper = getdombuilder.Configure() as SqlMapper;
            //_getsqlManager = Mapper.Instance();

            //if (_getsqlManager != null)
            //    _getsqlManager.Insert("InsertProduct", getproduct);
        }
    }
}
