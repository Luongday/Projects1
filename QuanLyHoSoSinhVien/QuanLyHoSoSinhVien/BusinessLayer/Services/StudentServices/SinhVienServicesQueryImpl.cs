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
    public class SinhVienServicesQueryImpl : IGetAllStudent,IGetAStudentWithMa,IGetAllStudentDangHocService,IGetAllStudentTamVang,IGetAllStudentForLopService,IGetStudentForNganhService
    {
        IStudentRepository studentRepo;

        public SinhVienServicesQueryImpl(IStudentRepository studentRepo)
        {
            this.studentRepo = studentRepo;
        }

        public List<SinhVien> getAll()
        {
            return studentRepo.GetAllStudents();
        }

        public List<SinhVien> getAllSinhVienTotNghiep()
        {
            var lStudent = studentRepo.GetAllStudents()
                 .Where(sv => sv.trangthai.Contains("Tốt nghiệp"))
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
            if (string.IsNullOrEmpty(maSV)||string.IsNullOrWhiteSpace(maSV))
            {
                return new SinhVien { };
            }
            var student = studentRepo.GetStudentId(maSV);
            return student;
        }

        public List<SinhVien> getSinhVienForLop(string tenLop)
        {
            if (string.IsNullOrEmpty(tenLop) || string.IsNullOrWhiteSpace(tenLop))
            {
                return new List<SinhVien>();
            }
            var lStudent = studentRepo.GetAllStudents()
                .Where(sv => sv.Lop.tenlop.Contains(tenLop,StringComparison.OrdinalIgnoreCase))
                .ToList();
            if (lStudent == null)
            {
                return new List<SinhVien>();
            }
            return lStudent;
        }

        public List<SinhVien> getStudentsByNganh(string ten)
        {
            if(string.IsNullOrEmpty(ten))
            {
                return new List<SinhVien>();
            }
            var lStudent = studentRepo.GetAllStudents()
                .Where(sv => sv.Lop.nganh.tennganh.Contains(ten))
                .ToList();
            return lStudent;
        }
    }
}
