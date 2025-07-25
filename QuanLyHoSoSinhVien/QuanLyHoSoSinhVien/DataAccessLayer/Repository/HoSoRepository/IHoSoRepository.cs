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
    public interface IHoSoRepository
    {
        public List<HoSo> getAllHoSo();
        public void DeleteProfile(HoSo hs);
        public void EditProfile(HoSo hs);
        public void AddHoSo(HoSo hs);
        public HoSo getHoSoByMaHS(string mahs);
        public HoSo getHoSoByMaSV(string masv);
        public List<HoSo> getHoSoByTrangThai(string tt);
        public HoSo getHoSoAll(HoSoDto hsdto);
        public void Save();
    }
}
