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
    public class GetAllStudentImpl : IGetAllStudent
    {
        IStudentRepository studentRepo;

        public GetAllStudentImpl(IStudentRepository studentRepo)
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
