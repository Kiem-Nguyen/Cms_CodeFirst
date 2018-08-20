using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
 using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Test_Bindle.Models
{
    [Table("Products")]
    public class Products
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Summary { get; set; }

        [StringLength(500)]
        public string Decription { get; set; }
        
        public double Prices { get; set; }

        public int Type { get; set; }

        public int Size { get; set; }

        public int Image { get; set; }

        public int Sale { get; set; }

        public virtual TypeProducts TypeProduct { get; set; }

        public virtual SizeProducts SizeProduct { get; set; }

        public virtual ImageProducts ImageProduct { get; set; }

        public virtual SaleProducts SaleProduct { get; set; }
    }
}