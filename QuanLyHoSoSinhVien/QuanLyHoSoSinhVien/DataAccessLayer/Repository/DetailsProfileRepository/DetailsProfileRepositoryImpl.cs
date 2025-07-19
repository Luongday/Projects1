using Microsoft.EntityFrameworkCore;
using QuanLyHoSoSinhVien.DataAccessLayer.Entity;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.DetailsProfileDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoSoSinhVien.DataAccessLayer.Repository.DetailsProfileRepository
{
    public class DetailsProfileRepositoryImpl : IDetailsProfileRepository
    {
        private readonly DataContext _context = new DataContext();

        public DetailsProfileRepositoryImpl(DataContext context)
        {
            _context = context;
        }

        public SinhVien TakeInfoAStudentById(string masv)
        {
            return _context.SinhViens
                .Include(x => x.Lop)
                .ThenInclude(n => n.nganh)
                .ThenInclude(k => k.Khoa)
                .AsNoTracking()
                .FirstOrDefault(sv => sv.masv == masv);
        }
    }
}

