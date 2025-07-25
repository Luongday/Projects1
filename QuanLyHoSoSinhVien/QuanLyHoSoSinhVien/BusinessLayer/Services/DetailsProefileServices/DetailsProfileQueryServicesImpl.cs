using QuanLyHoSoSinhVien.DataAccessLayer.Entity;
using QuanLyHoSoSinhVien.DataAccessLayer.Repository.DetailsProfileRepository;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.DetailsProfileDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoSoSinhVien.BusinessLayer.Services.DetailsProefileServices
{
    public class DetailsProfileQueryServicesImpl : ITakeADetailsProfileOfTheStudentServices
    {
        private readonly IDetailsProfileRepository _detailsProfileRepository;
        public DetailsProfileQueryServicesImpl(IDetailsProfileRepository detailsProfileRepository)
        {
            this._detailsProfileRepository = detailsProfileRepository;
        }

        public DetailsProfileDto MapToDto(SinhVien sv)
        {
            if (sv == null) return new DetailsProfileDto { };
            return new DetailsProfileDto{
                maSV = sv.masv,
                tenSv = sv.tensv,
                ngaySinh = sv.NgaySinh,
                GioiTinh = sv.gt == true ? "Nam" : "Nữ",
                diaChi = sv.dc,
                danToc = sv.dantoc,
                tonGiao = sv.tongiao,
                email = sv.email,
                sdt = sv.sdt,
                cccd = sv.cccd,
                noiSinh = sv.noisinh,
                trangThai = sv.trangthai,
                tenLop = sv.Lop?.tenlop,
                tenNganh = sv.Lop?.nganh?.tennganh,
                tenKhoa = sv.Lop?.nganh?.Khoa?.tenkhoa
            };
        }


        public SinhVien TakeInfoAStudent(string masv)
        {
            if(string.IsNullOrEmpty(masv) || string.IsNullOrWhiteSpace(masv)) return new SinhVien { };

            var tmp = _detailsProfileRepository.TakeInfoAStudentById(masv);
            if(tmp == null) return new SinhVien { };
            return tmp;
        }
    }
}

