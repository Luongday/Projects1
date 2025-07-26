using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHoSoSinhVien.DataAccessLayer.Entity;
using QuanLyHoSoSinhVien.DataAccessLayer.Repository.UserRepository;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.UserDTO;

namespace QuanLyHoSoSinhVien.BusinessLayer.Services.UserServices
{
    public class UserServicesImpl : IUserService,IEditRegisterService,IAddRegisterService
    {
        private readonly IUserDAO userDAO;
        public UserServicesImpl(IUserDAO userDAO)
        {
            this.userDAO = userDAO;
        }
        public bool checkRole(string userName, string passWord)
        {
            User user = userDAO.getUserWithUserNamePass(userName,passWord);
            return user.isAdmin;
        }
        public bool hasUser(string userName,string passWord) {
            if (userName == null || passWord == null)
            {
                return false;
            }
            return userDAO.getUserWithUserNamePass(userName,passWord) != null;
        }
        public User getUser(string userName, string passWord)
        {
            User user = userDAO.getUserWithUserNamePass(userName, passWord);
            return user;
        }

        public bool editRegister(UserDto user)
        {
            if (user == null || string.IsNullOrEmpty(user.userName) || string.IsNullOrEmpty(user.passWord)
                ||string.IsNullOrWhiteSpace(user.userName)||string.IsNullOrWhiteSpace(user.passWord))
            {
                return false; // Invalid input
            }
            try
            {
                var existingUser = userDAO.getUserForId(user.userId);
                if (existingUser == null)
                {
                    return false; // User does not exist
                }

                userDAO.editRegister(new User
                {
                    userId = existingUser.userId,
                    userName = user.userName,
                    password = user.passWord,
                    isAdmin = user.isAdmin
                });

                return true; // Update successful
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                Console.WriteLine($"An error occurred while editing the user: {ex.Message}");
                return false; // Update failed
            }
        }

        public bool addNewRegister(User newUser)
        {
            if(!string.IsNullOrEmpty(newUser.userName))
            {
                if (userDAO.getUserWithUserNamePass(newUser.userName,newUser.password) != null)
                {
                    return false; // User already exists
                }
            }
            else
            {
                return false; // Invalid user name
            }
            if (string.IsNullOrEmpty(newUser.password) || string.IsNullOrWhiteSpace(newUser.password))
            {
                return false; // Invalid password
            }
            if(newUser.isAdmin == null)
            {
                return false; // Invalid admin status
            }
            if (newUser == null)
            {
                return false;
            }
            User user = new User
            {
                userId = newUser.userId,
                userName = newUser.userName,
                password = newUser.password,
                isAdmin = newUser.isAdmin
            };
            userDAO.addRegister(user);
            return true;
        }
    }
}
