using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QuanLyNhanSu.Models
{
    public partial class QuanLyNhanSuDBContext : DbContext
    {
        public QuanLyNhanSuDBContext()
            : base("name=QuanLyNhanSuDBContext")
        {
        }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<PhongBan> PhongBans { get; set; }
        public virtual DbSet<ChucVu> ChucVus { get; set; }
        public virtual DbSet<ChamCong> ChamCongs { get; set; }
        public virtual DbSet<BangLuong> BangLuongs { get; set; }
        public virtual DbSet<KhenThuong> KhenThuongs { get; set; }
        public virtual DbSet<KyLuat> KyLuats { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<TinTuc>TinTucs { get; set; }
  





        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NhanVien>()
               .Property(e => e.IDNV)
               .IsUnicode(false);
            modelBuilder.Entity<PhongBan>()
               .Property(e => e.MaPB)
               .IsUnicode(false);
            modelBuilder.Entity<ChucVu>()
              .Property(e => e.IDChucVu)
              .IsUnicode(false);
        }
        public System.Data.Entity.DbSet<QuanLyNhanSu.Models.Role> Roles { get; set; }

      
    }
}
