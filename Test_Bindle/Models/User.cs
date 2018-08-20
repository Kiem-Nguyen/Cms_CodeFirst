namespace Test_Bindle.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string UserName { get; set; }

        [StringLength(100)]
        public string PassWord { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public int RoleType { get; set; }

        public virtual Role Role { get; set; }
    }
}
