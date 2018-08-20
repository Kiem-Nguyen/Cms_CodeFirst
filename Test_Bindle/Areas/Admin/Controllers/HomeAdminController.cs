using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test_Bindle.Areas.Admin.App_Star_Admin;
using Test_Bindle.Areas.Admin.ViewModels;
using Test_Bindle.Models;

namespace Test_Bindle.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        [Authen]
        public ActionResult Home()
        {
            return View();
        }
        
        public ActionResult Login()
        {
            ViewBag.Error = null;
            ViewBag.User = null;
            return View();
        }
        
        [HttpPost]
        public ActionResult CheckLogin(LoginViewModel user)
        {
            using (var db = new Cms())
            {
                var userTable = db.Users;
                var result = userTable.FirstOrDefault(x =>
                    x.UserName.Equals(user.UserName) && x.PassWord.Equals(user.PassWord));
                if (result == null)
                {
                    ViewBag.Error = "UserName or PassWord is not true, Please try again";
                    ViewBag.User = user.UserName;
                    return View($"Login");
                }
                if (result.Role.Type.Equals("admin") && result.Role.Type.Equals("super_admin"))
                {
                    ViewBag.Error = "You do not have permission to access this page, contact admin for more details";
                    ViewBag.User = user.UserName;
                    return View($"Login");
                }

                if (user.RememberMe == "true")
                {
                    Response.Cookies["UserName"].Value = user.UserName;
                    Response.Cookies["PassWord"].Value = user.PassWord;
                    Response.Cookies["UserName"].Expires = DateTime.Now.AddMonths(2);
                    Response.Cookies["PassWord"].Expires = DateTime.Now.AddMonths(2);
                }
                else
                {
                    Response.Cookies["UserName"].Expires = DateTime.Now.AddMonths(-1);
                    Response.Cookies["PassWord"].Expires = DateTime.Now.AddMonths(-1);
                }

                Session["products"] = result.UserName;
                return Redirect("Home");
            }
        }
        
        public ActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult CheckRegister(User user, string rePass)
        {
            using (var db = new Cms())
            {
                var userTable = db.Users;
                var result = userTable.FirstOrDefault(x =>
                    x.UserName.Equals(user.UserName) && x.PassWord.Equals(user.PassWord));
                if (result == null && rePass != user.PassWord)
                {

                    ViewBag.Mess = "Success";
                    ViewBag.User = user;
                    var registerUser = new User()
                    {
                        UserName = user.UserName,
                        PassWord = user.PassWord,
                        Role = db.Roles.FirstOrDefault(x => x.Type == "user"),
                        Email = user.Email
                    };

                    db.Users.Add(registerUser);
                    db.SaveChanges();

                    return Redirect("Login");
                }

                ViewBag.Mess = "UserName is exit, please register other user !!!";
                return Redirect("Register");
            }
        }
        
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CheckPass(string userName, string email)
        {
            try
            {
                using (var db = new Cms())
                {
                    var userTable = db.Users;
                    var result = userTable.FirstOrDefault(x =>
                        x.UserName.Equals(userName) && x.Email.Equals(email));

                    return result != null ? Json(new { success = true, data = result.PassWord }) : Json(new { success = false });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        public ActionResult Logout()
        {
            Session.Remove("products");
            return Redirect($"Login");
        }

    }
}