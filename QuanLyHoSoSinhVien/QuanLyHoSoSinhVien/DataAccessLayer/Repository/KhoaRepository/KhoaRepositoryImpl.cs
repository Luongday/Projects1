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

        public void AddNew(Khoa k)
        {
            _context.Add(k);
            _context.SaveChanges(); 
        }

        public List<Khoa> getAll()
        {
            return _context.Khoas.Include(khoa=>khoa.Nganh)
                .ThenInclude(Nganh=>Nganh.Lop)
                .ToList();
        }

        public Khoa GetByMa(string id)
        {
            return _context.Khoas.Find(id);
        }
    }
}
