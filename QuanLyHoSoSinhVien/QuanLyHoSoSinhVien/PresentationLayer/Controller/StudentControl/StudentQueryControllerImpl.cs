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
    public class StudentQueryControllerImpl : IStudentController,IGetAStudentController,IGetAllStudentDangHocController,IGetSinhVienTamVangController,IGetAllStudentForLopController,IGetAllStudentForNganhController
    {
        IGetAllStudent getAllStudent;
        IGetAStudentWithMa getAStudentWithMa;
        IGetAllStudentDangHocService getAllStudentDangHocService;
        IGetAllStudentTamVang getAllStudentTamVang;
        IGetAllStudentForLopService getAllStudentForLopService;
        IGetStudentForNganhService getStudentForNganhService;
        public StudentQueryControllerImpl(IGetAllStudent getAllStudent,IGetAStudentWithMa getAStudent, IGetAllStudentDangHocService getAllStudentDangHocService, 
                                            IGetAllStudentTamVang getAllStudentTamVang, IGetAllStudentForLopService getAllStudentForLopService,
                                            IGetStudentForNganhService getStudentForNganhService)
        {
            this.getAllStudent = getAllStudent;
            this.getAStudentWithMa = getAStudent;
            this.getAllStudentDangHocService = getAllStudentDangHocService;
            this.getAllStudentTamVang = getAllStudentTamVang;
            this.getAllStudentForLopService = getAllStudentForLopService;
            this.getStudentForNganhService = getStudentForNganhService;
        }

        public List<StudentDto> getAllSinhVienTamVang()
        {
            return getAllStudentTamVang.getAllSinhVienTamVang().Select(sv=>new StudentDto
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

        public List<StudentDto> getAllStudentDangHoc()
        {
            return getAllStudentDangHocService.getAllStdentDangHoc().Select(sv => new StudentDto
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

        public List<StudentDto> getAllStudentForLop(string tenLop)
        {
            if (string.IsNullOrEmpty(tenLop))
            {
                return new List<StudentDto>();
            }
            List<SinhVien> lSinhVien = getAllStudentForLopService.getSinhVienForLop(tenLop);
            if (lSinhVien == null || lSinhVien.Count == 0)
            {
                return new List<StudentDto>();
            }
            return lSinhVien.Select(sv => new StudentDto
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

        public List<StudentDto> getStudentForNganhController(string maNganh)
        {
            if (string.IsNullOrEmpty(maNganh))
            {
                return new List<StudentDto>();
            }
            List<SinhVien> lSinhVien = getStudentForNganhService.getStudentsByNganh(maNganh);
            if (lSinhVien == null || lSinhVien.Count == 0)
            {
                return new List<StudentDto>();
            }
            return lSinhVien.Select(sv => new StudentDto
            {
                maSV = sv.masv??"",
                tenSv = sv.tensv??"",
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

        public int totalStudent()
        {
            int countStudent = 0;
            countStudent = getAllStudent.getAll().Count();
            return countStudent;
        }

        public int totalStudentDangHoc()
        {
            return getAllStudentDangHocService.getAllStdentDangHoc().Count();
        }

        public int totalStudentTamVang()
        {
            return getAllStudentTamVang.getAllSinhVienTamVang().Count();
        }
    }
}
