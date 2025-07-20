using Microsoft.VisualBasic.ApplicationServices;
using QuanLyHoSoSinhVien.DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoSoSinhVien.DataAccessLayer.Repository.UserRepository
{
    public class UserDAO : IUserDAO
    {
        DataContext _context;

        public UserDAO(DataContext context)
        {
            _context = context;
        }

        public List<Entity.User> getAllUser() { 
            List<Entity.User> list = new List<Entity.User>();
            list = _context.Users.ToList();
            return list;
        }

        public Entity.User getById(string userName, string passWord)
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

        public List<SinhVien> get10()
        {
            List<SinhVien> list = new List<SinhVien>();
            list = _context.SinhViens.OrderBy(sv => sv.masv).Take(10).ToList();

            return list;

        }

        public void addRegister(Entity.User user)
        {
            _context.Add(user);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                Console.WriteLine($"An error occurred while adding the user: {ex.Message}");
            }
        }
    }
}
