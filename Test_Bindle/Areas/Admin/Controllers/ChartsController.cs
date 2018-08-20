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
    public class ChartsController : Controller
    {
        // GET: Admin/Charts
        public ActionResult Charts_Js()
        {
            return View();
        }
        public ActionResult Charts_flot()
        {
            return View();
        }
        public ActionResult Charts_peity()
        {
            return View();
        }
    }
}