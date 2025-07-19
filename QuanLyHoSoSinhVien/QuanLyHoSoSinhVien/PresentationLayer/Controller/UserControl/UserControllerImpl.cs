using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHoSoSinhVien.BusinessLayer.Services.UserServices;
using QuanLyHoSoSinhVien.DataAccessLayer.Entity;
using QuanLyHoSoSinhVien.DataAccessLayer.Repository.UserRepository;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.UserDTO;

namespace QuanLyHoSoSinhVien.PresentationLayer.Controller.UserControl
{
    public class UserControllerImpl : IUserController
    {
        private readonly IUserService _userService;

        public UserControllerImpl(IUserService userService)
        {
            _userService = userService;
        }

        public UserDto UserInfor(string userName, string passWord)
        {
            if(_userService.hasUser(userName, passWord))
            {
                User user =  _userService.getUser(userName, passWord);
                UserDto userInfor = new UserDto();
                userInfor.userId = user.userId??"";
                userInfor.userName = userName;
                userInfor.passWord = passWord;
                userInfor.isAdmin = user.isAdmin;
                return userInfor;
            }
            return null;
        }
    }
}
