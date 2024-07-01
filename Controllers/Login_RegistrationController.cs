using Ecom_Food_Cart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static System.Collections.Specialized.BitVector32;

namespace Ecom_Food_Cart.Controllers
{
    public class Login_RegistrationController : Controller
    {
        ecom_databaseEntities ecom_DatabaseEntities;

        // GET: Login_Registration
        public ActionResult Index()
        {
            return View();
        }

        // Admin

        public ActionResult Admin_Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Admin_Login(tbl_admin tbl_Admin)
        {
            if (tbl_Admin != null)
            {
                if (ModelState.IsValid)
                {
                    ecom_DatabaseEntities = new ecom_databaseEntities();

                    var obj = ecom_DatabaseEntities.tbl_admin.Where(
                           e => e.email.Equals(tbl_Admin.email) && e.password.Equals(tbl_Admin.password)).FirstOrDefault();

                    if (obj != null)
                    {
                        Session["Admin_UserName"] = obj.user_name;
                        Session["Admin_Password"] = obj.password;
                        TempData["ToastMessage"] = "Login Successfull !!!!";

                        return RedirectToAction("Dashboard", "Admin_Dashboard");
                    }
                    else
                    {
                        TempData["ToastMessage"] = "Inavlid Email or Password";
                    }
                }
            }
            return View(tbl_Admin);
        }


        public ActionResult Admin_Register()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Admin_Register(tbl_admin tbl_Admin)
        {
            if (tbl_Admin != null)
            {
                if (ModelState.IsValid)
                {
                    ecom_DatabaseEntities = new ecom_databaseEntities();
                    ecom_DatabaseEntities.tbl_admin.Add(tbl_Admin);
                    ecom_DatabaseEntities.SaveChanges();
                    return RedirectToAction("Admin_Login", "Login_Registration");
                }
            }
            return View(tbl_Admin);
        }




        // User

        public ActionResult User_Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult User_Login(tbl_user tbl_User)
        {
            if (tbl_User != null)
            {
                if (ModelState.IsValid)
                {
                    ecom_DatabaseEntities = new ecom_databaseEntities();

                    var obj = ecom_DatabaseEntities.tbl_user.Where(
                           e => e.email.Equals(tbl_User.email) && e.password.Equals(tbl_User.password)).FirstOrDefault();

                    if (obj != null)
                    {
                        Session["User_UserName"] = obj.user_name;
                        Session["User_Password"] = obj.password;
                        return RedirectToAction("Index", "User_Home");
                    }
                }
            }
            return View(tbl_User);
        }


        public ActionResult User_Register()
        {
            return View();
        }


        [HttpPost]
        public ActionResult User_Register(tbl_user tbl_User)
        {
            if (tbl_User != null)
            {
                if (ModelState.IsValid)
                {
                    ecom_DatabaseEntities = new ecom_databaseEntities();

                    ecom_DatabaseEntities.tbl_user.Add(tbl_User);
                    ecom_DatabaseEntities.SaveChanges();

                    return RedirectToAction("User_Login", "Login_Registration");
                }
            }
            return View(tbl_User);
        }

    }
}