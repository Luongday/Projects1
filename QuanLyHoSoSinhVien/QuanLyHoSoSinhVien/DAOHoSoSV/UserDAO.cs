using Microsoft.VisualBasic.ApplicationServices;
using QuanLyHoSoSinhVien.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoSoSinhVien.DAOHoSoSV
{
    public class UserDAO
    {
        DataContext _context = new DataContext();
        public List<model.User> getAllUser() { 
            List<model.User> list = new List<model.User>();
            list = _context.Users.ToList();
            return list;
        }

        public model.User getById(String userName, String passWord)
        {
            using var db = new DataContext();
            var user =db.Users.Where(x => x.userName.Equals(userName)&&x.password.Equals(passWord)).FirstOrDefault();
            if (user == null)
            {
                return null;
            }
            return user;
            //return 
        }
    }
}
