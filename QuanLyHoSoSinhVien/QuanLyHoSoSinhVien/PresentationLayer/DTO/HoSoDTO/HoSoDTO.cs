using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoSoSinhVien.PresentationLayer.DTO.HoSoDto
{
    public class HoSoDto
    {
        [DisplayName("Mã hồ sơ")]
        public string? mahs {  get; set; }

        [DisplayName("Mã sinh viên")]
        public string? masv { get; set; }
        [DisplayName("Ngày tạo")]
        public DateTime? ngaytao { get; set; }
        [DisplayName("Ngày cập nhật")]
        public DateTime? ngaycapnhat { get; set; } = DateTime.Now;
        public bool? trangthaihoso { get; set; }
        [DisplayName("Trạng thái hồ sơ")]
        public string TrangThaiText => trangthaihoso == true ? "Hoạt động" : "Không hoạt động";
    }
}
