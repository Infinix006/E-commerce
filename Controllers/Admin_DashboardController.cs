using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecom_Food_Cart.Controllers
{
    public class Admin_DashboardController : Controller
    {
        string cs = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
        string cmd = string.Empty;
        SqlConnection sqlConnection = null;
        SqlCommand SqlCommand = null;

        // GET: Admin_Dashboard
        public ActionResult Index()
        {       
            return View();
        }

        public ActionResult Dashboard()
        {
            try
            {
                cmd = "ORDERS";
                sqlConnection = new SqlConnection(cs);
                SqlCommand = new SqlCommand(cmd, sqlConnection);

                sqlConnection.Open();

                ViewBag.orders = Convert.ToInt32(SqlCommand.ExecuteScalar());

                cmd = "SALES";
                SqlCommand = new SqlCommand(cmd, sqlConnection);

                ViewBag.sales = Convert.ToInt32(SqlCommand.ExecuteScalar());

                cmd = "CUSTOMER";
                SqlCommand = new SqlCommand(cmd, sqlConnection);

                ViewBag.customers = Convert.ToInt32(SqlCommand.ExecuteScalar());

                sqlConnection.Close();
            }
            catch (Exception ex)
            {

            }
            return View();
        }
    }
}