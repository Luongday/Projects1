using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoSoSinhVien.DataAccessLayer.Entity
{
    public class HoSo
    {
        [Key]
        public string? mahoso {  get; set; }
        [ForeignKey("SinhVien")]
        public string? masv { get; set; }
        [DataType(DataType.Date)]
        public DateTime NgayTao { get; set; } = DateTime.Now;
        [DataType(DataType.Date)]
        public DateTime NgayCapNhat { get; set; }
        [MaxLength(20)]
        public string? trangthaihoso { get; set; }
        public SinhVien? SinhVien { get; set; }
    }
}
