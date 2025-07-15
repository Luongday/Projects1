using QuanLyHoSoSinhVien.DataAccessLayer.Entity;
using QuanLyHoSoSinhVien.DataAccessLayer.Repository.HoSoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoSoSinhVien.BusinessLayer.Services.ProfileServices
{
    public class HoSoQueryImpl : IGetAllHoSoServices
    {

        IHoSoRepository _hoSoRepository;

        public HoSoQueryImpl(IHoSoRepository hoSoRepository)
        {
            _hoSoRepository = hoSoRepository;
        }

        public List<HoSo> getAllHoSo()
        {
            return _hoSoRepository.getAllHoSo();

        }
    }
}
