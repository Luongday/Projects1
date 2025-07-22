using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.UserDTO;

namespace QuanLyHoSoSinhVien.BusinessLayer.Services.UserServices
{
    public interface IEditRegisterService
    {
        public bool editRegister(UserDto user);
    }
}
