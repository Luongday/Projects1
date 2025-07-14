using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuanLyHoSoSinhVien.DataAccessLayer.Entity;

namespace QuanLyHoSoSinhVien.DataAccessLayer.Repository.KhoaRepository
{
    public class KhoaRepositoryImpl : IKhoaRepository
    {
        DataContext _context = new DataContext();

        public List<Khoa> getAll()
        {
            return _context.Khoas.Include(khoa=>khoa.Nganh)
                .ThenInclude(Nganh=>Nganh.Lop)
                .ToList();
        }
    }
}
