using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyNhanSu.Models
{
    public class TinTuc
    {
        [Key]
        [Display(Name = "Mã số")]
        public string ID { get; set; }
        [Display(Name = "Tác giả")]
        public string Author { get; set; }
        [Display(Name = "Hình ảnh")]
        public string QuanLyAnh { get; set; }
       
        [Display(Name = "Nội dung")]
        public string Context { get; set; }
    }
}