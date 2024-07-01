using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecom_Food_Cart.Controllers
{
    public class Admin_CustomersController : Controller
    {
        // GET: Admin_Customers
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Customers()
        {
            return View();
        }
    }
}