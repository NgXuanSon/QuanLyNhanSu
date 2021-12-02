using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyNhanSu.Models
{
 
        [Table("PhongBans")]
        public class PhongBan
        {
            [Key]
            [StringLength(10)]
            [Display(Name = "Mã phòng ban")]
            public string MaPB { get; set; }
            [Display(Name = "Tên phòng ban")]
            public string TenPB { get; set; }
             public virtual ICollection<ChucVu> ChucVus { get; set; }

    }
}