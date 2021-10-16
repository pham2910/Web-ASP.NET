using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Models.EF
{
    public partial class ReviewDbContext : DbContext
    {
        public ReviewDbContext()
            : base("name=ReviewDbContext")
        {
        }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Field> Fields { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .Property(e => e.Web)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.Reviews)
                .WithOptional(e => e.Company)
                .HasForeignKey(e => e.ComId);

            modelBuilder.Entity<User>()
                .Property(e => e.Pwd)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Companies)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.UserRequest);

            modelBuilder.Entity<Admin>()
                .Property(e => e.Pwd)
                .IsUnicode(false);
        }
    }
}
