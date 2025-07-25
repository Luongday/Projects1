using QuanLyHoSoSinhVien.BusinessLayer.Services.ProfileServices;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.HoSoDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Gaming.Input.ForceFeedback;

namespace QuanLyHoSoSinhVien.PresentationLayer.Controller.HoSoController
{
    public class ProfileQueryControllerImpl : IProfileController
    {
        IGetAllHoSoServices _getAllHoSoServices;
        ITakeProfileByIdServices _takeProfileByIdServices;
        ISearchProfileServices _searchProfileByIdServices;
        
        public ProfileQueryControllerImpl(IGetAllHoSoServices getAllHoSoServices, ITakeProfileByIdServices takeProfileByIdServices, ISearchProfileServices searchProfileByIdServices)
        {
            this._getAllHoSoServices = getAllHoSoServices;
            this._takeProfileByIdServices = takeProfileByIdServices;
            this._searchProfileByIdServices = searchProfileByIdServices;
        }

        public List<HoSoDto> getAllHoSo()
        {
            return _getAllHoSoServices.getAllHoSo().Select(hs => new HoSoDto
            {
                mahs = hs.mahoso,
                masv = hs.masv,
                ngaytao = hs.NgayTao,
                ngaycapnhat = hs.NgayCapNhat,
                trangthaihoso = hs.trangthaihoso
            }).ToList();
        }

        public HoSoDto getHoSoByMaHS(string mahs)
        {
            if (string.IsNullOrEmpty(mahs) || string.IsNullOrWhiteSpace(mahs))
            {
                return null;
            }

            var tmp = _searchProfileByIdServices.searchProfileForMaHs(mahs);

            if (tmp == null) return null;

            return new HoSoDto
            {
                mahs = tmp.mahoso,
                masv = tmp.masv,
                ngaytao = tmp.NgayTao,
                ngaycapnhat = tmp.NgayCapNhat,
                trangthaihoso = tmp.trangthaihoso
            };
        }

        public HoSoDto getHoSoByMaSV(string masv)
        {
            if(string.IsNullOrEmpty(masv) || string.IsNullOrWhiteSpace(masv))
            {
                return null;
            }

            var tmp = _searchProfileByIdServices.searchProfileForMaSv(masv);

            if (tmp == null) return null;

            return new HoSoDto
            {
                mahs = tmp.mahoso,
                masv = tmp.masv,
                ngaytao = tmp.NgayTao,
                ngaycapnhat = tmp.NgayCapNhat,
                trangthaihoso = tmp.trangthaihoso
            };
        }

        public List<HoSoDto> getHoSoByTrangThai(string tt)
        {
            if (string.IsNullOrEmpty(tt) || string.IsNullOrWhiteSpace(tt)) return null;

            var tmp = _searchProfileByIdServices.searchProfileForTt(tt);

            if (tmp == null) return null;

            return tmp.Select(hs => new HoSoDto
            {
                mahs = hs.mahoso,
                masv = hs.masv,
                ngaytao = hs.NgayTao,
                ngaycapnhat=hs.NgayCapNhat,
                trangthaihoso = hs.trangthaihoso,
            }).ToList();
        }

        public HoSoDto getHoSoTheoNhieuTieuChi(HoSoDto hoSoDto)
        {
            if(hoSoDto == null) return null;

            var tmp = _searchProfileByIdServices.getHoSoAll(hoSoDto);

            if(tmp == null) return null;

            return new HoSoDto 
            {
                mahs = tmp.mahoso,
                masv = tmp.masv,
                ngaytao = tmp.NgayTao,
                ngaycapnhat = tmp.NgayCapNhat,
                trangthaihoso = tmp.trangthaihoso
            };
        }

        public int TotalProfile()
        {
            return _getAllHoSoServices.getAllHoSo().Count;
        }
    }
}
