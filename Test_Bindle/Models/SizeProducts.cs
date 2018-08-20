using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Test_Bindle.Models
{
    [Table("SizeProducts")]
    public class SizeProducts
    {
        public int Id { get; set; }

        public int SizeNumber { get; set; }
    }
}