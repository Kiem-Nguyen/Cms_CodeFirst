using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Test_Bindle;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Spatial;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Test_Bindle.Areas.Admin.ViewModels
{
    public class LoginViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Password Must Be", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string PassWord { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int RoleType { get; set; }
        public string RememberMe { get; set; }
    }
}