using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHoSoSinhVien.DataAccessLayer.Entity;

namespace QuanLyHoSoSinhVien.BusinessLayer.Services.UserServices
{
    public interface IAddRegisterService
    {
        public bool addNewRegister(User newUser); 
    }
}
