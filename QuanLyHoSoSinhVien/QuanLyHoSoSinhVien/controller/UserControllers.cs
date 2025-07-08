using QuanLyHoSoSinhVien.DAOHoSoSV;
using QuanLyHoSoSinhVien.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoSoSinhVien.controller
{
    public class UserControllers
    {
        UserDAO userDAO = new UserDAO();
        DataContext _context = new DataContext();
        public bool checkRole(String userName, String passWord)
        {
            model.User user = userDAO.getById(userName,passWord);
            return user.isAdmin;
        }
        public bool hasUser(String userName,String passWord) {
            if (userName == null || passWord == null)
            {
                return false;
            }
            return userDAO.getById(userName,passWord) != null;
        }
    }
}
