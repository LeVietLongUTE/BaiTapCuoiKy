using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ModelEF.Model
{
    public partial class LeVietLongContext : DbContext
    {
        public LeVietLongContext()
            : base("name=LeVietLongContext")
        {
        }

        public virtual DbSet<LoaiSanPham> LoaiSanPham { get; set; }
        public virtual DbSet<SanPham> SanPham { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<UserAccount> UserAccount { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoaiSanPham>()
                .HasMany(e => e.SanPham)
                .WithRequired(e => e.LoaiSanPham)
                .HasForeignKey(e => e.categoryID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.UnitCost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<UserAccount>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<UserAccount>()
                .Property(e => e.Password)
                .IsUnicode(false);
        }
    }
}
