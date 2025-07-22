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
    public class UserControllerImpl : IUserController,IEditRegisterController
    {
        private readonly IUserService _userService;
        private readonly IEditRegisterService _editRegisterService;

        public UserControllerImpl(IUserService userService, IEditRegisterService editRegisterService)
        {
            _userService = userService;
            _editRegisterService = editRegisterService;
        }

        public bool editRegister(UserDto userDto)
        {
            if(userDto == null || string.IsNullOrEmpty(userDto.userName) || string.IsNullOrEmpty(userDto.passWord)||
                string.IsNullOrWhiteSpace(userDto.userName)||string.IsNullOrWhiteSpace(userDto.passWord))
            {
                return false;
            }
            UserDto user = new UserDto
            {
                userId = userDto.userId,
                userName = userDto.userName,
                passWord = userDto.passWord,
                isAdmin = userDto.isAdmin
            };
            return _editRegisterService.editRegister(user);
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
