namespace Test_Bindle.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Cms : DbContext
    {
        public Cms()
            : base("name=Cms")
        {
        }

        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<ImageProducts> ImageProducts { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<SaleProducts> SaleProducts { get; set; }
        public virtual DbSet<SizeProducts> SizePriducts { get; set; }
        public virtual DbSet<TypeProducts> TypeProducts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Role)
                .HasForeignKey(e => e.RoleType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.PassWord)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsFixedLength();
        }
    }
}
