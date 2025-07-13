using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHoSoSinhVien.DataAccessLayer.Entity;

namespace QuanLyHoSoSinhVien.BusinessLayer.Services.UserServices
{
    public interface IUserService
    {
        public bool checkRole(string userName, string passWord);
        public bool hasUser(string userName, string passWord);
        public User getUser(string userName, string passWord);
    }
}
