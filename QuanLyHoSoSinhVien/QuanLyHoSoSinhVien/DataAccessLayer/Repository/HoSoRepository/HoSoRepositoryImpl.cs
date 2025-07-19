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
    internal class HoSoRepositoryImpl : IHoSoRepository
    {
        DataContext _context;

        public HoSoRepositoryImpl(DataContext context)
        {
            _context = context;
        }

        public void AddHoSo(HoSo hs)
        {
            _context.HoSos.Add(hs);
        }

        public void DeleteProfile(HoSo hs)
        {
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

        public HoSo getHoSoById(string mahs)
        {
            return _context.HoSos.FirstOrDefault(hs => hs.mahoso == mahs);
        }

        public DetailsProfileDto getHoSoByIdSinhVien(string masv)
        {
            return null;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
