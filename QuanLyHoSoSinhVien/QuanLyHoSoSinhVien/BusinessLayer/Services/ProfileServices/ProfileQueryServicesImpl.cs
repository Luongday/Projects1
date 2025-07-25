using QuanLyHoSoSinhVien.DataAccessLayer.Entity;
using QuanLyHoSoSinhVien.DataAccessLayer.Repository.HoSoRepository;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.HoSoDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoSoSinhVien.BusinessLayer.Services.ProfileServices
{
    public class ProfileQueryServicesImpl : IGetAllHoSoServices, ITakeProfileByIdServices, ISearchProfileServices
    {

        IHoSoRepository _hoSoRepository;

        public ProfileQueryServicesImpl(IHoSoRepository hoSoRepository)
        {
            _hoSoRepository = hoSoRepository;
        }

        public List<HoSo> getAllHoSo()
        {
            var tmp = _hoSoRepository.getAllHoSo();
            return tmp;
        }

        public HoSo getHoSoAll(HoSoDto hoSoDto)
        {
            if (hoSoDto == null) return null;
            if (string.IsNullOrEmpty(hoSoDto.mahs) || string.IsNullOrWhiteSpace(hoSoDto.mahs) || hoSoDto.trangthaihoso == null) return null;
            var tmp = _hoSoRepository.getHoSoAll(hoSoDto);

            return tmp;
        }

        public HoSo searchProfileForMaHs(string mahs)
        {
            if (string.IsNullOrEmpty(mahs) || string.IsNullOrWhiteSpace(mahs)) return null;

            var tmp = _hoSoRepository.getHoSoByMaHS(mahs);
            return tmp;
        }

        public HoSo searchProfileForMaSv(string msv)
        {
            if(string.IsNullOrEmpty(msv) || string.IsNullOrWhiteSpace(msv)) return null;

            var tmp = _hoSoRepository.getHoSoByMaSV(msv);
            return tmp;
        }

        public List<HoSo> searchProfileForTt(string trangthai)
        {
            if (string.IsNullOrEmpty(trangthai) || string.IsNullOrWhiteSpace(trangthai)) return null;

            var tmp = _hoSoRepository.getHoSoByTrangThai(trangthai);
            return tmp;
        }

        public HoSo TakeProfileById(string mahs)
        {
            if(string.IsNullOrEmpty(mahs) || string.IsNullOrWhiteSpace(mahs))
            {
                return null;
            }

            var hs = _hoSoRepository.getHoSoByMaHS(mahs);
            return hs;
        }
    }
}
