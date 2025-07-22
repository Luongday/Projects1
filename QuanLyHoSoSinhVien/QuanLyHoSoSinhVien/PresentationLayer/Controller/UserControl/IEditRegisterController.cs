using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.UserDTO;

namespace QuanLyHoSoSinhVien.PresentationLayer.Controller.UserControl
{
    public interface IEditRegisterController
    {
        public bool editRegister(UserDto userDto); 
    }
}
