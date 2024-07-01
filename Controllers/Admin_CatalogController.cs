using Ecom_Food_Cart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Ecom_Food_Cart.Controllers
{
    public class Admin_CatalogController : Controller
    {
        ecom_databaseEntities ecom_DatabaseEntities;
        string cs = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
        string cmd = string.Empty;

        // GET: Admin_Catalog
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Categories()
        {
            List<tbl_categories> Category_List = new List<tbl_categories>();
            cmd = "ALLCATEGORYDATA";

            SqlConnection conn = new SqlConnection(cs);
            SqlCommand command = new SqlCommand(cmd, conn);
                       
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();

            sqlDataAdapter.Fill(dt);

            foreach(DataRow dr in dt.Rows)
            {
                Category_List.Add(new tbl_categories
                {
                    categoryId = Convert.ToInt32(dr["categoryId"]),
                    category_Name = dr["category_Name"].ToString(),
                    sort_Order = Convert.ToInt32(dr["sort_Order"])
                });
            }
            return View(Category_List);
        }

        public ActionResult AddCategories()
        {
            return View();
        }

       

        [HttpPost]
        public ActionResult AddCategories(tbl_categories tbl_Categories)
        {
           
            cmd = $"insert into tbl_category values (@Category_Name, @Sort_Order)";

            try
            {
                SqlConnection conn = new SqlConnection(cs);
                SqlCommand command = new SqlCommand(cmd, conn);

                command.Parameters.Add("@Category_Name", tbl_Categories.category_Name);
                command.Parameters.Add("@Sort_Order", tbl_Categories.sort_Order);


                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();


                return Json(new { success = true });
            }
            catch (Exception ex)
            {

            }
            return RedirectToAction("Categories");
        }


        public ActionResult EditCategories(int id)
        {
            tbl_categories category = null;
            cmd = "GETCATEGORYBYID";

            SqlConnection conn = new SqlConnection(cs);
            SqlCommand command = new SqlCommand(cmd, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@categoryId", id);

            conn.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                category = new tbl_categories
                {
                    categoryId = Convert.ToInt32(reader["categoryId"]),
                    category_Name = reader["category_Name"].ToString(),
                    sort_Order = Convert.ToInt32(reader["sort_Order"])
                };
            }
            conn.Close();
            return View(category);
        }

        [HttpPost]
        public ActionResult UpdateCategory(tbl_categories category)
        {
            cmd = "UPDATECATEGORY";

            SqlConnection conn = new SqlConnection(cs);
            SqlCommand command = new SqlCommand(cmd, conn);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@categoryId", category.categoryId);
            command.Parameters.AddWithValue("@category_Name", category.category_Name);
            command.Parameters.AddWithValue("@sort_Order", category.sort_Order);

            conn.Open() ;
            int i = command.ExecuteNonQuery();
            conn.Close();

            return RedirectToAction("Categories");
        }


        public ActionResult Products()
        {
            List<tbl_products> products = new List<tbl_products>();
            cmd = "ALLPRODUCTDATA";

            SqlConnection conn = new SqlConnection(cs);
            SqlCommand command = new SqlCommand(cmd, conn);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            foreach(DataRow dr in dt.Rows)
            {
                products.Add(new tbl_products
                {
                    category_Name = dr["category_Name"].ToString(),
                    product_Name = dr["product_Name"].ToString(),
                    price = Convert.ToDecimal(dr["price"]),
                    quantity = Convert.ToInt32(dr["quantity"])
                });
            }

            return View(products);
        }

        public ActionResult AddProducts()
        {
            List<tbl_categories> Category_List = new List<tbl_categories>();
            SqlConnection conn = new SqlConnection(cs);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "ALLCATEGORYDATA";

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sqlDataAdapter.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                Category_List.Add(new tbl_categories
                {
                    categoryId = Convert.ToInt32(dr["categoryId"]),
                    category_Name = dr["category_Name"].ToString()
                });
            }

            ViewBag.categorylist = Category_List;

            return View();
        }

        
    }
}