using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyNhanSu.Models
{

        [Table("NhanViens")]
        public class NhanVien
        {
            [Key]
            [Display(Name = "Mã nhân viên")]
            public string IDNV { get; set; }
            [StringLength(50)]
            [Display(Name = "Tên nhân viên")]
            public string TenNV { get; set; }
            [Display(Name = "Giới tính")]
            public string GioiTinh { get; set; }
            [Display(Name = "Tuổi")]
            public int Tuoi { get; set; }
            [Display(Name = "Số điện thoại")]
            public string SDT { get; set; }
            [StringLength(100)]
            public string Email { get; set; }
            [StringLength(255)]
            [Display(Name = "Địa chỉ")]
            public string DiaChi { get; set; }
            [Display(Name = "Ngày vào làm")]
            public DateTime NgayVaolam { get; set; }
        public virtual ICollection<BangLuong> BangLuongs { get; set; }
        public virtual ICollection<ChamCong> ChamCongs { get; set; }
        public virtual ICollection<KhenThuong> KhenThuongs { get; set; }
        public virtual ICollection<KyLuat> KyLuat { get; set; }
    }
}