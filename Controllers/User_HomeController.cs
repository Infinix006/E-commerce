using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecom_Food_Cart.Controllers
{
    public class User_HomeController : Controller
    {
        // GET: User_Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Shop()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}