using QuanLyHoSoSinhVien.DataAccessLayer.Entity;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.HoSoDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoSoSinhVien.BusinessLayer.Services.ProfileServices
{
    public interface IEditProfileServices
    {
        public bool EditProfile(HoSoDto hs);
    }
}
