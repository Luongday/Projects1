using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHoSoSinhVien.BusinessLayer.Services.StudentServices;
using QuanLyHoSoSinhVien.DataAccessLayer.Entity;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.StudentDTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace QuanLyHoSoSinhVien.PresentationLayer.Controller.StudentControl
{
    public class StudentControllerImpl : IStudentController,IGetAStudentController
    {
        IGetAllStudent getAllStudent;
        IGetAStudentWithMa getAStudentWithMa;
        public StudentControllerImpl(IGetAllStudent getAllStudent,IGetAStudentWithMa getAStudent)
        {
            this.getAllStudent = getAllStudent;
            this.getAStudentWithMa = getAStudent;
        }

        public List<StudentDto> getAllStudentWithFullInfor()
        {
            return getAllStudent.getAll().Select(sv => new StudentDto
            {
                maSV = sv.masv,
                tenSv = sv.tensv,
                ngaySinh = sv.NgaySinh,
                GioiTinh = sv.gt ? "Nam" : "Nữ",
                diaChi = sv.dc,
                danToc = sv.dantoc,
                tonGiao = sv.tongiao,
                email = sv.email,
                sdt = sv.sdt,
                cccd = sv.cccd,
                noiSinh = sv.noisinh,
                trangThai = sv.trangthai,
                tenLop = sv.Lop?.tenlop ?? "",
                tenNganh = sv.Lop?.nganh?.tennganh ?? "",
                tenKhoa = sv.Lop?.nganh?.Khoa?.tenkhoa ?? ""
            }).ToList();
        }

        public StudentDto getAStudent(string ma)
        {
            if(string.IsNullOrEmpty(ma))
            {
                return new StudentDto { };
            }
            SinhVien sv =  getAStudentWithMa.getAStudentForMa(ma)??new SinhVien { };
            StudentDto student = new StudentDto
            {
                maSV = sv.masv ?? "",
                tenSv = sv.tensv ?? "",
                ngaySinh = sv.NgaySinh,
                GioiTinh = sv.gt ? "Nam" : "Nữ",
                diaChi = sv.dc,
                danToc = sv.dantoc,
                tonGiao = sv.tongiao,
                email = sv.email,
                sdt = sv.sdt,
                cccd = sv.cccd,
                noiSinh = sv.noisinh,
                trangThai = sv.trangthai,
                tenLop = sv.Lop?.tenlop ?? "",
                tenNganh = sv.Lop?.nganh?.tennganh ?? "",
                tenKhoa = sv.Lop?.nganh?.Khoa?.tenkhoa ?? ""
            };
            return student;
        }

        public int totalStudent()
        {
            int countStudent = 0;
            countStudent = getAllStudent.getAll().Count();
            return countStudent;
        }
    }
}
