using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuanLyHoSoSinhVien.DataAccessLayer.Entity;
using QuanLyHoSoSinhVien.DataAccessLayer.Repository.StudentRepository;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.StudentDTO;

namespace QuanLyHoSoSinhVien.BusinessLayer.Services.StudentServices
{
    public class SinhVienQueryImpl : IGetAllStudent,IGetAStudentWithMa,IGetAllStudentDangHocService,IGetAllStudentTamVang
    {
        IStudentRepository studentRepo;

        public SinhVienQueryImpl(IStudentRepository studentRepo)
        {
            this.studentRepo = studentRepo;
        }

        public List<SinhVien> getAll()
        {
            return studentRepo.GetAllStudents();
        }

        public List<SinhVien> getAllSinhVienTamVang()
        {
            var lStudent = studentRepo.GetAllStudents()
                 .Where(sv => sv.trangthai.Contains("Tạm dừng"))
                 .ToList();
            if (lStudent == null)
            {
                return new List<SinhVien>();
            }
            return lStudent;
        }

        public List<SinhVien> getAllStdentDangHoc()
        {
            var lStudent = studentRepo.GetAllStudents()
                .Where(sv => sv.trangthai.Contains("Đang học"))
                .ToList();
            if (lStudent == null)
            {
                return new List<SinhVien>();
            }
            return lStudent;
        }

        public SinhVien getAStudentForMa(string maSV)
        {
            if (string.IsNullOrEmpty(maSV))
            {
                new StudentDto { };
            }
            return studentRepo.GetStudentId(maSV);
        }
    }
}
