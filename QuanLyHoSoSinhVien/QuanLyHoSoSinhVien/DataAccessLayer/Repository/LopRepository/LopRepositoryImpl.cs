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
        DataContext _dataContext;

        public LopRepositoryImpl(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void addLop(Lop lop)
        {
            _dataContext.Lops.Add(lop);
            _dataContext.SaveChanges();
        }

        public List<Lop> getAll()
        {
            return _dataContext.Lops.Include(lop=>lop.nganh)
                .ThenInclude(nganh=>nganh.Khoa)
                .Include(lop=>lop.sinhViens)
                .ToList();
        }

        public Lop getByMa(string id)
        {
            return _dataContext.Lops.Find(id);
        }

        public void deleteLop(Lop lop)
        {
            _dataContext.Remove(lop);
            _dataContext.SaveChanges();
        }

        public void editLop(Lop lop)
        {
            try
            {
                var existingLop = _dataContext.Lops.Find(lop.malop);
                if (existingLop == null)
                {
                    throw new InvalidOperationException($"Lop with ID {lop.malop} not found.");
                }
               // existingLop.malop = lop.malop;
                existingLop.tenlop = lop.tenlop;
                existingLop.manganh = lop.manganh;
                int result = _dataContext.SaveChanges();
                if (result <= 0)
                {
                    throw new InvalidOperationException("No changes were saved to the database.");
                }
                _dataContext.Entry(existingLop).Reload();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error updating Lop.", ex);
            }
        }
    }
}
