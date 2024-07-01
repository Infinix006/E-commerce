using Ecom_Food_Cart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Ecom_Food_Cart.Controllers
{
    public class Admin_SalesController : Controller
    {
        string cs = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
        string cmd = string.Empty;

        // GET: Admin_Sales
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Order()
        {
            List<tbl_orders> orders = new List<tbl_orders>();
            cmd = "ALLORDERDATA";

            SqlConnection conn = new SqlConnection(cs);
            SqlCommand Command = new SqlCommand(cmd, conn);

            SqlDataAdapter adapter = new SqlDataAdapter(Command);
            DataTable dt = new DataTable();

            adapter.Fill(dt);

            foreach(DataRow dr in dt.Rows)
            {
                orders.Add(new tbl_orders
                {
                    orderId = Convert.ToInt32(dr["orderID"]),
                    customer = dr["customer"].ToString(),
                    product_Name = dr["product_Name"].ToString(),
                    status = dr["status"].ToString(),
                    order_total = Convert.ToDecimal(dr["order_total"]),
                    order_date = dr["order_date"].ToString()
                });
               
            }

            return View(orders);
        }


        public ActionResult Return()
        {
            return View();
        }
    }
}