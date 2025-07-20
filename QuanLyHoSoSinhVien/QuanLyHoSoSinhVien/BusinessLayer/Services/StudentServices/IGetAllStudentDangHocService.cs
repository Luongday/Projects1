using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHoSoSinhVien.DataAccessLayer.Entity;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.StudentDTO;

namespace QuanLyHoSoSinhVien.BusinessLayer.Services.StudentServices
{
    public interface IGetAllStudentDangHocService
    {
        public List<SinhVien> getAllStdentDangHoc();
    }
}
