using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Test_Bindle.Models
{
    [Table("TypeProducts")]
    public class TypeProducts
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string NameType { get; set; }
    }
}