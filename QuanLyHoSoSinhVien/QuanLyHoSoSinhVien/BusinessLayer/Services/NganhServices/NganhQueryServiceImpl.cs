using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHoSoSinhVien.DataAccessLayer.Entity;
using QuanLyHoSoSinhVien.DataAccessLayer.Repository.NganhRepository;

namespace QuanLyHoSoSinhVien.BusinessLayer.Services.NganhServices
{
    public class NganhQueryServiceImpl : IGetAllNganhService,IGetNganhForNameService,IGetNganhForKhoaService
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

        public List<Nganh> getNganhForKhoa(string tenKhoa)
        {
            if (string.IsNullOrEmpty(tenKhoa))
            {
                return new List<Nganh>();
            }
            var lNganh = _nganhRepository.getAll().Where(ng => ng.Khoa.tenkhoa == tenKhoa).ToList();
            return lNganh ?? new List<Nganh>();
        }

        public List<Nganh> getNganhForName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return new List<Nganh>();
            }
            var lNganh = _nganhRepository.getAll().Where(ng=>ng.tennganh==name).ToList();
            return lNganh?? new List<Nganh>();
        }
    }
}
