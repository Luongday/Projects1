﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoSoSinhVien.model
{
    public class User
    {
        [Key]
        public int userId {  get; set; }

        [Required]
        [MaxLength(20)]
        public string? userName { get; set; }

        [Required]
        [MaxLength(20)]
        public string? password { get; set; }
        [Required]
        public bool isAdmin { get; set; }
    }
}
