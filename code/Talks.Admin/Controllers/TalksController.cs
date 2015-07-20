using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Talks.Admin.Controllers
{
    public class TalksController : Controller
    {
        // GET: Talks
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}