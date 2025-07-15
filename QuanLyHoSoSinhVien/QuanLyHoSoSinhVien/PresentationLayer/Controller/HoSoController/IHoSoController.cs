using QuanLyHoSoSinhVien.PresentationLayer.DTO.HoSoDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoSoSinhVien.PresentationLayer.Controller.HoSoController
{
    public interface IHoSoController
    {
        public List<HoSoDTO> getAllHoSo();
    }
}
