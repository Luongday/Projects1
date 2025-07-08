using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoSoSinhVien.model
{
    public class HoSo
    {
        [Key]
        public string? mahoso {  get; set; }

        [ForeignKey("SinhVien")]
        public string? masv { get; set; }

        public string? tensv { get; set; }

        public DateTime Ngaysinh { get; set; }

        public bool gt {  get; set; }

        public string? dc { get; set; }

        public string? sdt { get; set; }
        
        public string? tenlop { get; set; }

        public string? tenkhoa { get; set; }

        public string? tennghanh { get; set; }
        [MaxLength(50)]
        [EmailAddress]
        public string? email { get; set; }

        [MaxLength(20)]
        public string? cccd { get; set; }

        [MaxLength(100)]
        public string? noisinh { get; set; }

        [MaxLength(50)]
        public string? tongiao { get; set; }

        [MaxLength(50)]
        public string? dantoc { get; set; }
        [MaxLength(20)]
        public string? trangthai { get; set; }
        public SinhVien? SinhVien { get; set; }
    }
}
