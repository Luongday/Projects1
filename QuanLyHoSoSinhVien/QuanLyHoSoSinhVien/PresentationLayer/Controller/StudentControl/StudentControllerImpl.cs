using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHoSoSinhVien.BusinessLayer.Services.StudentServices;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.StudentDTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace QuanLyHoSoSinhVien.PresentationLayer.Controller.StudentControl
{
    public class StudentControllerImpl : IStudentController
    {
        IGetAllStudent getAllStudent;

        public StudentControllerImpl(IGetAllStudent getAllStudent)
        {
            this.getAllStudent = getAllStudent;
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
    }
}
