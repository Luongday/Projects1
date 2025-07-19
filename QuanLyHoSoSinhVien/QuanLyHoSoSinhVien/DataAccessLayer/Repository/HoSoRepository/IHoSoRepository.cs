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
        public HoSo getHoSoById(string mahs);
        public DetailsProfileDto getHoSoByIdSinhVien(string masv);
        public void Save();
    }
}
