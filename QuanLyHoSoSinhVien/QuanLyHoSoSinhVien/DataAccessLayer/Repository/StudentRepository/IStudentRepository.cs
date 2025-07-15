using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuanLyHoSoSinhVien.DataAccessLayer.Entity;

namespace QuanLyHoSoSinhVien.DataAccessLayer.Repository.StudentRepository
{
    public interface IStudentRepository
    {
        public List<SinhVien> GetAllStudents();

        public SinhVien GetStudentId(string id);
    }
}
