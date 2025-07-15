using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuanLyHoSoSinhVien.DataAccessLayer.Entity;

namespace QuanLyHoSoSinhVien.DataAccessLayer.Repository.LopRepository
{
    public class LopRepositoryImpl : ILopRepository
    {
        DataContext _dataContext = new DataContext();
        public List<Lop> getAll()
        {
            return _dataContext.Lops.Include(lop=>lop.nganh)
                .ThenInclude(nganh=>nganh.Khoa)
                .Include(lop=>lop.sinhViens)
                .ToList();
        }
    }
}
