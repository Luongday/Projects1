using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHoSoSinhVien.DataAccessLayer.Entity;
using QuanLyHoSoSinhVien.DataAccessLayer.Repository.LopRepository;

namespace QuanLyHoSoSinhVien.BusinessLayer.Services.LopServices
{
    public class LopQueryIServicempl : IGetAllLop,IGetLopWithMaService,IGetLopWithNameService,IGetLopForNganhService
    {
        ILopRepository lopRepository;

        public LopQueryIServicempl(ILopRepository lopRepository)
        {
            this.lopRepository = lopRepository;
        }

        public List<Lop> getAll()
        {
            return lopRepository.getAll() ?? new List<Lop>();  
        }

        public List<Lop> getLopForNganh(string tenNganh)
        {
            if (string.IsNullOrEmpty(tenNganh))
            {
                return new List<Lop> { };
            }
            List<Lop> allLops = lopRepository.getAll().Where(l => l.nganh.tennganh == tenNganh).ToList();
            if (allLops == null || allLops.Count <= 0)
            {
                return new List<Lop> { };
            }
            return allLops;
        }

        public Lop getLopWithMa(string ma)
        {
            if (string.IsNullOrEmpty(ma))
            {
                return new Lop { }; 
            }
            return lopRepository.getByMa(ma) ?? new Lop { }; 
        }

        public List<Lop> getLopWithTen(string tenLop)
        {
            if (string.IsNullOrEmpty(tenLop))
            {
                return new List<Lop> { };
            }
            List<Lop> allLops = lopRepository.getAll().Where(l=>l.tenlop==tenLop).ToList();
            if (allLops == null || allLops.Count <= 0)
            {
                return new List<Lop> { };
            }
            return allLops;
        }
    }
}
