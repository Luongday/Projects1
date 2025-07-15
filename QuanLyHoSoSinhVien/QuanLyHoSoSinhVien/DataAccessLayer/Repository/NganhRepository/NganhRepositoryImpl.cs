using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuanLyHoSoSinhVien.DataAccessLayer.Entity;

namespace QuanLyHoSoSinhVien.DataAccessLayer.Repository.NganhRepository
{
    public class NganhRepositoryImpl : INganhRepository
    {
        DataContext _context = new DataContext();

        public List<Nganh> getAll()
        {
            return _context.Nganhs.Include(nganh => nganh.Lop)
                .Include(nganh=>nganh.Khoa)
                .ToList();    
        }
    }
}
