using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuanLyHoSoSinhVien.DataAccessLayer.Entity;

namespace QuanLyHoSoSinhVien.DataAccessLayer.Repository.StudentRepository
{
    public class StudentRepositoryImpl : IStudentRepository
    {
        DataContext _context = new DataContext();
        public List<SinhVien> GetAllStudents()
        {
            var danhSach = _context.SinhViens.Include(sv=>sv.Lop)
                .ThenInclude(lop=>lop.nganh)
                .ThenInclude(nganh=>nganh.Khoa).ToList();
            return danhSach;
        }

        public SinhVien GetStudentId(string id)
        {
            var sinhvien = _context.SinhViens
                .Include(sv=>sv.Lop)
                .ThenInclude(lop=>lop.nganh)
                .ThenInclude(nganh=>nganh.Khoa)
                .Where(sv => sv.masv == id).FirstOrDefault();
            return sinhvien;
        }
    }
}
