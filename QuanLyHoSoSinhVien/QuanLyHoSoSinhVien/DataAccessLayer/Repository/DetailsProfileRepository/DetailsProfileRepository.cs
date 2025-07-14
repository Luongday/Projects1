using Microsoft.EntityFrameworkCore;
using QuanLyHoSoSinhVien.DataAccessLayer.Entity;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.DetailsProfileDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoSoSinhVien.DataAccessLayer.Repository.DetailsProfileRepository
{
    public class DetailsProfileRepository : IDetailsProfileRepository
    {
        private readonly DataContext _context = new DataContext();

        public DetailsProfileRepository(DataContext context)
        {
            _context = context;
        }

        public DetailsProfileDto GetAStudentById(string maSv)
        {
            return _context.SinhViens
                .Include(x => x.Lop).ThenInclude(x => x.nganh).ThenInclude(x => x.Khoa)
                .AsNoTracking()
                .Where(sv => sv.masv == maSv)
                .Select(sv => new DetailsProfileDto
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
                    tenLop = sv.Lop.tenlop,
                    tenNganh = sv.Lop.nganh.tennganh,
                    tenKhoa = sv.Lop.nganh.Khoa.tenkhoa
                })
                .FirstOrDefault();
        }

    }
}

