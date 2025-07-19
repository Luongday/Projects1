using QuanLyHoSoSinhVien.DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoSoSinhVien.BusinessLayer.Services.ProfileServices
{
    public interface ITakeProfileByIdServices
    {
        public HoSo TakeProfileById(string mahs);
    }
}
