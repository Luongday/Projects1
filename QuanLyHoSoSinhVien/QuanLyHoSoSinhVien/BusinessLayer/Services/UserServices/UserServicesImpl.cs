using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHoSoSinhVien.DataAccessLayer.Entity;
using QuanLyHoSoSinhVien.DataAccessLayer.Repository.UserRepository;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.UserDTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyHoSoSinhVien.BusinessLayer.Services.UserServices
{
    public class UserServicesImpl : IUserService,IEditRegisterService
    {
        private readonly IUserDAO userDAO;
        DataContext _context = new DataContext();
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
    }
}
