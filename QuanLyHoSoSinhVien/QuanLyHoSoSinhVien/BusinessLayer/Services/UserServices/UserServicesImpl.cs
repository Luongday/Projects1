using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHoSoSinhVien.DataAccessLayer.Entity;
using QuanLyHoSoSinhVien.DataAccessLayer.Repository.UserRepository;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyHoSoSinhVien.BusinessLayer.Services.UserServices
{
    public class UserServicesImpl : IUserService
    {
        private readonly IUserDAO userDAO;
        DataContext _context = new DataContext();
        public UserServicesImpl(IUserDAO userDAO)
        {
            this.userDAO = userDAO;
        }
        public bool checkRole(string userName, string passWord)
        {
            User user = userDAO.getById(userName,passWord);
            return user.isAdmin;
        }
        public bool hasUser(string userName,string passWord) {
            if (userName == null || passWord == null)
            {
                return false;
            }
            return userDAO.getById(userName,passWord) != null;
        }
        public User getUser(string userName, string passWord)
        {
            User user = userDAO.getById(userName, passWord);
            return user;
        }
    }
}
