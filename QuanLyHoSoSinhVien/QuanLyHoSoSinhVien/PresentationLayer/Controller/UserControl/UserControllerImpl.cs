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
    public class UserControllerImpl : IUserController,IEditRegisterController,IAddRegisterController
    {
        private readonly IUserService _userService;
        private readonly IEditRegisterService _editRegisterService;
        private readonly IAddRegisterService _addRegisterService;

        public UserControllerImpl(IUserService userService, IEditRegisterService editRegisterService, IAddRegisterService addRegisterService)
        {
            _userService = userService;
            _editRegisterService = editRegisterService;
            _addRegisterService = addRegisterService;
        }

        public bool addRegisterController(UserDto newUser)
        {
            if (newUser == null) { 
                return false;
            }
            if(string.IsNullOrEmpty(newUser.userName) || string.IsNullOrEmpty(newUser.passWord) || string.IsNullOrWhiteSpace(newUser.userName) || string.IsNullOrWhiteSpace(newUser.passWord))
            {
                return false;
            }
            User user = new User
            {
                userId = newUser.userName+"register",
                userName = newUser.userName,
                password = newUser.passWord,
                isAdmin = newUser.isAdmin
            };
            if (_addRegisterService.addNewRegister(user))
            {
                return true;
            }
            return false;
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
