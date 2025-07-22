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

        public Entity.User getUserWithUserNamePass(string userName, string passWord)
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

        public void editRegister(Entity.User user)
        {
            var existingUser = _context.Users.Find(user.userId);
            if (existingUser != null)
            {
                existingUser.userName = user.userName;
                existingUser.password = user.password;
                existingUser.isAdmin = user.isAdmin;
                try
                {
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    // Log the exception or handle it as needed
                    Console.WriteLine($"An error occurred while updating the user: {ex.Message}");
                }
            }
            else
            {
                throw new InvalidOperationException("User not found.");
            }
        }

        public Entity.User getUserForId(string userId)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrWhiteSpace(userId))
            {
                return new Entity.User { };
            }
            return _context.Users.Find(userId);
        }
    }
}
