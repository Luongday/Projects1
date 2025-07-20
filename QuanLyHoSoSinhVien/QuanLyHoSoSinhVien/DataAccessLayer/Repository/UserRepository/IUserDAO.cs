using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHoSoSinhVien.DataAccessLayer.Entity;

namespace QuanLyHoSoSinhVien.DataAccessLayer.Repository.UserRepository
{
    public interface IUserDAO
    {
        public List<Entity.User> getAllUser();
        public Entity.User getById(string userName, string passWord);
        public List<SinhVien> get10();
        public void addRegister(User user);
    }
}
