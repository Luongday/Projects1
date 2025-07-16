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
            _context.Khoas.Add(k);
            _context.SaveChanges(); 
        }

        public void delete(Khoa k)
        {
            _context.Khoas.Remove(k);
            _context.SaveChanges();
        }

        public void edit(Khoa updatedKhoa)
        {
            try
            {
                var existingKhoa = _context.Khoas.Find(updatedKhoa.makhoa);
                if (existingKhoa == null)
                {
                    throw new InvalidOperationException($"Khoa with ID {updatedKhoa.makhoa} not found.");
                }

                
                existingKhoa.tenkhoa = updatedKhoa.tenkhoa;

                int result = _context.SaveChanges();
                if (result <= 0)
                {
                    throw new InvalidOperationException("No changes were saved to the database.");
                }
                _context.Entry(existingKhoa).Reload();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error updating Khoa.", ex);
            }
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
