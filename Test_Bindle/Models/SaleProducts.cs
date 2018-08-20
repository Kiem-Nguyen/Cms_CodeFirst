using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Test_Bindle.Models
{
    [Table("SaleProducts")]
    public class SaleProducts
    {
        public int Id { get; set; }

        public double Sale { get; set; }

        [StringLength(100)]
        public string Name { get; set; }
    }
}