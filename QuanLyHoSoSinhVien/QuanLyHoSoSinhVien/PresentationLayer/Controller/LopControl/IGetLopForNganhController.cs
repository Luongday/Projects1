using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.LopDTO;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.NganhDTO;

namespace QuanLyHoSoSinhVien.PresentationLayer.Controller.LopControl
{
    public interface IGetLopForNganhController
    {
        public List<LopDto> getLopForNganh(string tenNganh);
    }
}
