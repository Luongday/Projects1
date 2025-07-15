using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHoSoSinhVien.DataAccessLayer.Entity;

namespace QuanLyHoSoSinhVien.BusinessLayer.Services.KhoaServices
{
    public interface IGetKhoaForId
    {
        public Khoa GetById(String id);
    }
}
