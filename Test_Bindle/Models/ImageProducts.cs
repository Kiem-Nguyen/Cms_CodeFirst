using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Test_Bindle.Models
{
    [Table("ImageProducts")]
    public class ImageProducts
    {
        public int Id { get; set; }

        [StringLength(200)]
        public string Url { get; set; }

        [StringLength(200)]
        public string Url1 { get; set; }

        [StringLength(200)]
        public string Url2 { get; set; }

        [StringLength(200)]
        public string Url3 { get; set; }
    }
}