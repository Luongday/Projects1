using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHoSoSinhVien.DataAccessLayer.Entity;
using QuanLyHoSoSinhVien.DataAccessLayer.Repository.NganhRepository;

namespace QuanLyHoSoSinhVien.BusinessLayer.Services.NganhServices
{
    public class NganhQueryServiceImpl : IGetAllNganhService
    {
        DataContext _context = new DataContext();
        INganhRepository _nganhRepository;

        public NganhQueryServiceImpl(INganhRepository nganhRepository)
        {
            _nganhRepository = nganhRepository;
        }

        public List<Nganh> getAll()
        {
            var lNganh = _nganhRepository.getAll();
            return lNganh??new List<Nganh>();
        }
    }
}
