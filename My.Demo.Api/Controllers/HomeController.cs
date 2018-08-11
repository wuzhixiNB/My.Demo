using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace My.Demo.Api.Controllers
{
    /// <summary>
    /// MVC默认路由
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// MVC默认Action(加载Api页面)
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
