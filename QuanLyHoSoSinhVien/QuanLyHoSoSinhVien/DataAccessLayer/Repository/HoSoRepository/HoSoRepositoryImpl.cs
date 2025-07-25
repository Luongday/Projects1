using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using QuanLyHoSoSinhVien.DataAccessLayer.Entity;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.DetailsProfileDTO;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.HoSoDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoSoSinhVien.DataAccessLayer.Repository.HoSoRepository
{
    public class HoSoRepositoryImpl : IHoSoRepository
    {
        DataContext _context;

        public HoSoRepositoryImpl(DataContext context)
        {
            _context = context;
        }

        public void AddHoSo(HoSo hs)
        {
            if (hs == null) return;
            _context.HoSos.Add(hs);
        }

        public void DeleteProfile(HoSo hs)
        {
            if (string.IsNullOrEmpty(hs.mahoso) || string.IsNullOrWhiteSpace(hs.mahoso)) return;
            if (hs == null) return;
            var entity = _context.HoSos.FirstOrDefault(x => x.mahoso == hs.mahoso);
            if (entity != null)
            {
                entity.trangthaihoso = false;
            }
        }

        public void EditProfile(HoSo hs)
        {
            var entity = _context.HoSos.FirstOrDefault(x => x.mahoso == hs.mahoso);
            if (entity != null)
            {
                entity.masv = hs.masv;
                entity.trangthaihoso = hs.trangthaihoso;
                entity.NgayCapNhat = hs.NgayCapNhat;
            }
        }

        public List<HoSo> getAllHoSo()
        {
            List<HoSo> list = _context.HoSos.ToList();

            return list;
        }

        public HoSo getHoSoAll(HoSoDto hsdto)
        {
            if (hsdto == null) return null;
            var query = _context.HoSos.AsQueryable();

            if(!string.IsNullOrEmpty(hsdto.mahs) && !string.IsNullOrWhiteSpace(hsdto.mahs))
            {
                query = query.Where(hs => hs.mahoso == hsdto.mahs);
            }

            if(!string.IsNullOrEmpty(hsdto.masv) && !string.IsNullOrWhiteSpace(hsdto.masv))
            {
                query = query.Where(hs => hs.masv == hsdto.masv);
            }

            if(!string.IsNullOrEmpty(hsdto.TrangThaiText) && !string.IsNullOrWhiteSpace(hsdto.TrangThaiText))
            {
                query = query.Where(hs => hs.trangthaihoso == hsdto.trangthaihoso);
            }

            if (query.Count() < 0) return null;

            return query.FirstOrDefault();
        }

        public HoSo getHoSoByMaHS(string mahs)
        {
            if (string.IsNullOrEmpty(mahs) || string.IsNullOrWhiteSpace(mahs)) return null;
            var tmp = _context.HoSos.Where(x => x.mahoso == mahs).FirstOrDefault();
            return tmp;
        }

        public HoSo getHoSoByMaSV(string masv)
        {
            if(string.IsNullOrEmpty(masv) || string.IsNullOrWhiteSpace(masv)) return null;
            var tmp = _context.HoSos.Where(hs => hs.masv == masv).FirstOrDefault();
            return tmp;
        }

        public List<HoSo> getHoSoByTrangThai(string tt)
        {
            if(string.IsNullOrEmpty(tt) || string.IsNullOrWhiteSpace(tt)) return null;
            var tmp = _context.HoSos.Where(hs => (hs.trangthaihoso == true ? "Hoạt động" : "Không hoạt động") == tt).ToList();
            return tmp;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
