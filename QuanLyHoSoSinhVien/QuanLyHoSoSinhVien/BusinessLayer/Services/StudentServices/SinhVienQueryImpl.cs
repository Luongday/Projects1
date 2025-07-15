using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuanLyHoSoSinhVien.DataAccessLayer.Entity;
using QuanLyHoSoSinhVien.DataAccessLayer.Repository.StudentRepository;

namespace QuanLyHoSoSinhVien.BusinessLayer.Services.StudentServices
{
    public class SinhVienQueryImpl : IGetAllStudent
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

        public SinhVien getByID(string id)
        {
            throw new NotImplementedException();
        }
    }
}
