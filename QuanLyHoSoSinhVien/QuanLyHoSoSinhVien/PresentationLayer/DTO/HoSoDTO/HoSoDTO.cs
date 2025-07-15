using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoSoSinhVien.PresentationLayer.DTO.HoSoDTO
{
    public class HoSoDTO
    {
        public string mahs {  get; set; }

        public string? masv { get; set; }

        public DateTime? ngaytao { get; set; }

        public DateTime? ngaycapnhat { get; set; }

        public bool? trangthaihoso { get; set; }
    }
}
