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
        DataContext _context;

        public NganhRepositoryImpl(DataContext context)
        {
            _context = context;
        }

        public void addNganh(Nganh nganh)
        {
            _context.Nganhs.Add(nganh);
            _context.SaveChanges();
        }

        public void deleteNganh(string id)
        {
            _context.Nganhs.Remove(_context.Nganhs.Find(id));
            _context.SaveChanges();
        }

        public void editNganh(Nganh nganhNew)
        {
            try
            {
                var existingNganh = _context.Nganhs.Find(nganhNew.manganh);
                if (existingNganh == null)
                {
                    throw new InvalidOperationException($"Khoa with ID {nganhNew.manganh} not found.");
                }
                existingNganh.manganh = nganhNew.manganh;
                existingNganh.tennganh = nganhNew.tennganh;
                existingNganh.makhoa = nganhNew.makhoa;
                int result = _context.SaveChanges();
                if (result <= 0)
                {
                    throw new InvalidOperationException("No changes were saved to the database.");
                }
                _context.Entry(existingNganh).Reload();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error updating Khoa.", ex);
            }
        }

        public List<Nganh> getAll()
        {
            return _context.Nganhs.Include(nganh => nganh.Lop)
                .Include(nganh=>nganh.Khoa)
                .ToList();    
        }
    }
}
