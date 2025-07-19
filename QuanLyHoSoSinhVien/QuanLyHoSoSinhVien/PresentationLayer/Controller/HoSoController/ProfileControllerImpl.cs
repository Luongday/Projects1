using QuanLyHoSoSinhVien.BusinessLayer.Services.ProfileServices;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.HoSoDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoSoSinhVien.PresentationLayer.Controller.HoSoController
{
    public class ProfileControllerImpl : IProfileController
    {
        IGetAllHoSoServices _getAllHoSoServices;

        public ProfileControllerImpl(IGetAllHoSoServices getAllHoSoServices)
        {
            _getAllHoSoServices = getAllHoSoServices;
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

        public int TotalProfile()
        {
            return _getAllHoSoServices.getAllHoSo().Count;
        }
    }
}
