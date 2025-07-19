using QuanLyHoSoSinhVien.DataAccessLayer.Entity;
using QuanLyHoSoSinhVien.DataAccessLayer.Repository.HoSoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoSoSinhVien.BusinessLayer.Services.ProfileServices
{
    public class ProfileQueryServicesImpl : IGetAllHoSoServices, ITakeProfileByIdServices
    {

        IHoSoRepository _hoSoRepository;

        public ProfileQueryServicesImpl(IHoSoRepository hoSoRepository)
        {
            _hoSoRepository = hoSoRepository;
        }

        public List<HoSo> getAllHoSo()
        {
            return _hoSoRepository.getAllHoSo();
        }

        public HoSo TakeProfileById(string mahs)
        {
            var hs = _hoSoRepository.getHoSoById(mahs);

            if(hs == null) return new HoSo { };

            return hs;
        }
    }
}
