using QuanLyHoSoSinhVien.DataAccessLayer.Entity;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.HoSoDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoSoSinhVien.BusinessLayer.Services.ProfileServices
{
    public interface ISearchProfileServices
    {
        public HoSo searchProfileForMaHs(string mahs);

        public HoSo searchProfileForMaSv(string msv);

        public List<HoSo> searchProfileForTt(string trangthai);

        public HoSo getHoSoAll(HoSoDto hoSoDto);
    }
}
