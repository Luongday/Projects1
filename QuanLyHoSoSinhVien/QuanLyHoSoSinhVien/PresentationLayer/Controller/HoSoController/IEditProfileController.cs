using QuanLyHoSoSinhVien.DataAccessLayer.Entity;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.HoSoDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoSoSinhVien.PresentationLayer.Controller.HoSoController
{
    public interface IEditProfileController
    {
        public string EditProfile(HoSoDto hs);
    }
}
