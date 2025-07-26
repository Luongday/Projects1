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
    public class DetailsProfileRepositoryImpl : IDetailsProfileRepository
    {
        private readonly DataContext _context = new DataContext();

        public DetailsProfileRepositoryImpl(DataContext context)
        {
            _context = context;
        }

        public void EditDetailsProfile(DetailsProfileDto sv)
        {
            var entity = _context.SinhViens.Include(s => s.Lop)
                .ThenInclude(p => p.nganh)
                .ThenInclude(g => g.Khoa)
                .Include(s => s.HoSo)
                .FirstOrDefault(x => x.masv == sv.maSV);
            if(entity != null && sv.maSV != null)
            {
                entity.tensv = sv.tenSv;
                entity.NgaySinh = sv.ngaySinh;
                entity.gt = sv.GioiTinh == "Nam" ? true : false;
                entity.dc = sv.diaChi;
                entity.sdt = sv.sdt;
                entity.dantoc = sv.danToc;
                entity.tongiao = sv.tonGiao;
                entity.email = sv.email;
                entity.cccd = sv.cccd;
                entity.noisinh = sv.noiSinh;
                entity.trangthai = sv.trangThai;
            var hs = _context.HoSos.FirstOrDefault(x => x.mahoso == entity.HoSo.mahoso);
                if(hs != null)
                {
                    hs.masv = sv.maSV;
                    if (sv.trangThai.Contains("Đang học", StringComparison.OrdinalIgnoreCase))
                    {
                        hs.trangthaihoso = false;
                    }
                    else if (sv.trangThai.Contains("Tốt nghiệp", StringComparison.OrdinalIgnoreCase))
                    {
                        hs.trangthaihoso = true;
                    }
                    hs.NgayCapNhat = DateTime.Now;
                }
                if (entity.malop != null)
                {
                    var lop = _context.Lops.FirstOrDefault(x => x.malop == entity.malop);
                    if (lop != null)
                    {
                        lop.tenlop = sv.tenLop;
                        if (!string.IsNullOrEmpty(lop.manganh))
                        {
                            var nganh = _context.Nganhs.FirstOrDefault(x => x.manganh == lop.manganh);
                            if (nganh != null)
                            {
                                nganh.tennganh = sv.tenNganh;
                                if (!string.IsNullOrEmpty(nganh.makhoa))
                                {
                                    var khoa = _context.Khoas.FirstOrDefault(x => x.makhoa == nganh.makhoa);
                                    if (khoa != null)
                                    {
                                        khoa.tenkhoa = sv.tenKhoa;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
         
        public void Save()
        {
            _context.SaveChanges();
        }

        public SinhVien TakeInfoAStudentById(string masv)
        {
            return _context.SinhViens
                .Include(x => x.Lop)
                .ThenInclude(n => n.nganh)
                .ThenInclude(k => k.Khoa)
                .AsNoTracking()
                .FirstOrDefault(sv => sv.masv == masv);
        }

    }
}

