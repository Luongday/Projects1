using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.KhoaDTO;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.NganhDTO;

namespace QuanLyHoSoSinhVien.PresentationLayer.Controller.NganhControl
{
    public interface IGetNganhForKhoaController
    {
        public List<NganhDto> getNganhForKhoa(string tenKhoa);
    }
}
