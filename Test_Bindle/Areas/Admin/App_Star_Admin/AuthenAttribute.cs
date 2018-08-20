using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test_Bindle.Models;

namespace Test_Bindle.Areas.Admin.App_Star_Admin
{
    public class AuthenAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var master = HttpContext.Current.Session["products"];
            if (master == null)
            {
                HttpContext.Current.Session["Message"] = "Please login !";
                HttpContext.Current.Response.Redirect("/Admin/HomeAdmin/Login");
                return;
            }

            //var ActionName = (filterContext.ActionDescriptor.ControllerDescriptor.ControllerName + "/" + filterContext.ActionDescriptor.ActionName).ToLower();

            Cms dbc = new Cms();
            var count = dbc.Users.FirstOrDefault(x => x.UserName.Equals(master.ToString().Trim()));
            if (count == null && (count.RoleType == 1 || count.RoleType == 2))
            {
                HttpContext.Current.Session["Message"] = "You do not have permission to access this page, contact admin for more details";
                HttpContext.Current.Response.Redirect("/Admin/HomeAdmin/Login");
            }

            //var RoleIds = master.MasterRoles
            //    .Select(mr => mr.RoleId)
            //    .ToList();

            //count = dbc.ActionRoles
            //    .Where(ar => ar.WebAction.Name == ActionName
            //                 && RoleIds.Contains(ar.RoleId)).Count();
            //if (count > 0)
            //{
            //    return;
            //}

            return;
        }
    }
}