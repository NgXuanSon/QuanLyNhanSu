using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyNhanSu.Models
{
    
        [Table("BangLuongs")]
        public class BangLuong
        {
            [Key]
            [Display(Name = "Tên nhân viên")]
            public string TenNV { get; set; }
            [Display(Name = "Tiền lương")]
            public string Luong { get; set; }
            [Display(Name = "Phụ cấp")]
            public string Phucap { get; set; }
            public virtual NhanVien NhanViens { get; set; }
        }
}