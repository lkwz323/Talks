using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Talks.Model.Searcher;
using Talks.Service;


namespace Talks.Admin.Controllers
{
     [Authorize]
    public class HomeController : Controller
    {
        IHomeService homeService ;

        public ActionResult Index(HomeSearcher searcher)
        {
            searcher.PageSize = 10;
            //homeService.BindDataList(ViewBag, searcher);
            return View();
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