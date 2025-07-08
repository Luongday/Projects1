using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoSoSinhVien.model
{
    public class SinhVien
    {
        [Key]
        public string? masv {  get; set; }

        [Required, MaxLength(30)]
        public string? tensv { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime NgaySinh { get; set; }

        [Required]
        public bool gt { get; set; }

        //[Required]
        //[MaxLength(50)]
        //public string? lop { get; set; }

        [Required]
        [MaxLength(50)]
        public string? dc { get; set; }

        [Required]
        [Phone]
        [MaxLength(10)]
        public string? sdt { get; set; }

        [ForeignKey("Lop")]
        public string? malop { get; set; }

        public Lop? Lop {  get; set; }

        public HoSo? HoSo { get; set; }
    }
}
