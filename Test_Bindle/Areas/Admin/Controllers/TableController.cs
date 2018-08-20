using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test_Bindle.Areas.Admin.App_Star_Admin;
using Test_Bindle.Models;

namespace Test_Bindle.Areas.Admin.Controllers
{
    [Authen]
    public class TableController : Controller
    {
        // GET: Admin/Table
        public ActionResult Basic()
        {
            return View();
        }
        
        public ActionResult Account()
        {
            using (var db = new Cms())
            {
                var allAccount = db.Users.ToList();

                return View(allAccount);
            }
        }

        [HttpPost]
        public ActionResult RegisterByAdmin(User user)
        {
            using (var db = new Cms())
            {
                var userTable = db.Users;
                var result = userTable.FirstOrDefault(x =>
                    x.UserName.Equals(user.UserName));
                if (result == null)
                {
                    var registerUser = new User()
                    {
                        UserName = user.UserName,
                        PassWord = user.PassWord == "" ? "1" : user.PassWord,
                        Role = db.Roles.FirstOrDefault(x => x.Id == user.RoleType),
                        RoleType = user.RoleType,
                        Email = user.Email
                    };

                    db.Users.Add(registerUser);
                    db.SaveChanges();

                    return Redirect("Account");
                }

                ViewBag.Mess = "UserName is exit, please register other user !!!";
                return Redirect("Account");
            }
        }

        [HttpPost]
        public ActionResult EditAccount(User user)
        {
            using (var db = new Cms())
            {
                var acc = db.Users.FirstOrDefault(x => x.UserName.Equals(user.UserName));
                if(acc != null)
                {
                    acc.Email = user.Email;
                    if(!string.IsNullOrWhiteSpace(user.PassWord))
                        acc.PassWord = user.PassWord;
                    acc.Role = db.Roles.FirstOrDefault(x => x.Id == user.RoleType);
                    acc.RoleType = user.RoleType;
                }

                db.SaveChanges();
                return Redirect("Account");
            }
        }

        [HttpPost]
        public ActionResult DeleteAccount(int id)
        {
            using (var db = new Cms())
            {
                var nameUserLogin = Session["products"];
                var user = db.Users.FirstOrDefault(x => x.UserName.Equals(nameUserLogin.ToString().Trim()));
                var account = db.Users.FirstOrDefault(x => x.Id == id);
                
                if ((user == null || user.RoleType == 3) && (account.RoleType == 3 || account.RoleType == 4))
                    return Json(new { success = false, mess = "You can't permission delete user have type Admin or Supper Admin" });

                db.Users.Remove(account ?? throw new InvalidOperationException());
                db.SaveChanges();
                return Json(new { success = true, mess = "Deleted !!!" });

            }
        }
    }
}