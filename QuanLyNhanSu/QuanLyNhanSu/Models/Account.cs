﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyNhanSu.Models
{

        [Table("Accounts")]
        public class Account
        {
            [Key]
            [Required(ErrorMessage = "Username không được để trống")]
            public string UserName { get; set; }
            [Required(ErrorMessage = "Password không được để trống")]
            //Định nghĩa Datatype
            [DataType(DataType.Password)]
            public string PassWord { get; set; }
            public string RoleID { get; set; }
        }
}