using QuanLyHoSoSinhVien.BusinessLayer.Services.ProfileServices;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.HoSoDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoSoSinhVien.PresentationLayer.Controller.HoSoController
{
    public class HoSoControllerImpl : IHoSoController
    {
        IGetAllHoSoServices _getAllHoSoServices;

        public HoSoControllerImpl(IGetAllHoSoServices getAllHoSoServices)
        {
            _getAllHoSoServices = getAllHoSoServices;
        }

        public List<HoSoDTO> getAllHoSo()
        {
            return _getAllHoSoServices.getAllHoSo().Select(hs => new HoSoDTO
            {
                mahs = hs.mahoso,
                masv = hs.masv,
                ngaytao = hs.NgayTao,
                ngaycapnhat = hs.NgayCapNhat,
                trangthaihoso = hs.trangthaihoso
            }).ToList();
        }
    }
}
