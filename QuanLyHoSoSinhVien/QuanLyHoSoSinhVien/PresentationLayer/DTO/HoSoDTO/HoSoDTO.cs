using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoSoSinhVien.PresentationLayer.DTO.HoSoDto
{
    public class HoSoDto
    {
        public string? mahs {  get; set; }

        public string? masv { get; set; }

        public DateTime? ngaytao { get; set; }

        public DateTime? ngaycapnhat { get; set; } = DateTime.Now;

        public bool? trangthaihoso { get; set; }

        public string TrangThaiText => trangthaihoso == true ? "Hoạt động" : "Không hoạt động";
    }
}
