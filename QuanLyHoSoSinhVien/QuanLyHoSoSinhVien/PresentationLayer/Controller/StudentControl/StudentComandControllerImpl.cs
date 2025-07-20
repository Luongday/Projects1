using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHoSoSinhVien.BusinessLayer.Services.LopServices;
using QuanLyHoSoSinhVien.BusinessLayer.Services.StudentServices;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.StudentDTO;

namespace QuanLyHoSoSinhVien.PresentationLayer.Controller.StudentControl
{
    public class StudentComandControllerImpl : IDeleteStudentController,IAddStudentController
    {
        IDeleteStudentService _deleteStudentService;
        IAddStudentService _addStudentService;
        IGetLopWithNameService _getLopWithNameService;

        public StudentComandControllerImpl(IDeleteStudentService deleteStudentService, IAddStudentService addStudentService, IGetLopWithNameService _getLopWithNameService)
        {
            _deleteStudentService = deleteStudentService;
            _addStudentService = addStudentService;
            this._getLopWithNameService = _getLopWithNameService;
        }

        public bool addStudent(StudentDto student)
        {
            if (student == null || string.IsNullOrEmpty(student.maSV) || string.IsNullOrEmpty(student.tenSv))
            {
                return false; // Invalid input
            }
            var lop = _getLopWithNameService.getLopWithTen(student.tenLop);
            _addStudentService.addStudent(new DataAccessLayer.Entity.SinhVien
            {
                masv = student.maSV,
                tensv = student.tenSv,
                NgaySinh = student.ngaySinh,
                gt = student.GioiTinh.Contains("Nam")?true:false,
                dc = student.diaChi,
                dantoc = student.danToc,
                tongiao = student.tonGiao,
                email = student.email,
                sdt = student.sdt,
                cccd = student.cccd,
                noisinh = student.noiSinh,
                trangthai = student.trangThai,
                malop = lop.FirstOrDefault()?.malop
            });
            return true; 
        }

        public bool deleteStudent(string ma)
        {
            if (string.IsNullOrEmpty(ma))
            {
                return false; // Invalid input
            }
            if (_deleteStudentService.delete(ma))
            {
                return true; // Deletion successful
            }
            return false; // Deletion failed
        }
    }
}
