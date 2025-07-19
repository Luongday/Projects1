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
    public class SinhVienQueryImpl : IGetAllStudent,IGetAStudentWithMa
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
