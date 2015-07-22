using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Talks.Model;
using Talks.Service;

namespace Talks.Admin.Controllers
{
    public class ShoppingCartController : Controller
    {
        [Inject]
        public IValueCalculater calculator{get;set;}
        protected Product[] products;

        public ShoppingCartController()
        {
            //this.calculator = calcuParam;
            products = new[]{
                                new Product(){Name="Kayak" , Price=275M},
                                new Product(){Name="Lifejacket" , Price=48.95M},
                                new Product(){Name="Scooceer ball" , Price=19.5M},
                                new Product(){Name="Stadium" , Price=79550M}
                            };
        }

        public virtual decimal CalculatStockValue()
        {
            decimal totalPrice = calculator.ValueProducts(products);
            return totalPrice;
        }
       
        // GET: ShoppingCart
        public ActionResult Index()
        {
            return Content(CalculatStockValue()+"");
        }
    }

    
}