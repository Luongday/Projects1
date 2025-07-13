using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoSoSinhVien.PresentationLayer.DTO.UserDTO
{
    public class UserDto
    {
        public String userName { get; set; }
        public String passWord { get; set; }
        public bool isAdmin { get; set; }
    }
}
