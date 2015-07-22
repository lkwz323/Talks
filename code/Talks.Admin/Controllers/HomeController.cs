using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Talks.Model;
using Talks.Model.Searcher;
using Talks.Service;


namespace Talks.Admin.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {

        [Inject]
        public IProductService productService { get; set; }

        public ActionResult Index(HomeSearcher searcher)
        {
            searcher.PageSize = 10;
            //homeService.BindDataList(ViewBag, searcher);
            return View();
        }
        public ActionResult Index2()
        {
            var product = new Product()
            {
                ProductID = Guid.NewGuid().ToString(),
                Name = "Name_" + Guid.NewGuid().ToString(),
                Category = "category",
                Company = "vancl",
                Description = "hahaha",
                Price = 100.01M,

            };
            var id = productService.InserProduct(product);
            return Content(id);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}