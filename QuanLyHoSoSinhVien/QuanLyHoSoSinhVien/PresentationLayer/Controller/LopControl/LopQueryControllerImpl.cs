using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHoSoSinhVien.BusinessLayer.Services.LopServices;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.LopDTO;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.NganhDTO;

namespace QuanLyHoSoSinhVien.PresentationLayer.Controller.LopControl
{
    public class LopQueryControllerImpl : ILopController,IGetLopWithMaController,IGetLopWithNameController,IGetLopForNganhController
    {
        IGetAllLop _getAllLop;
        IGetLopWithMaService _getLopWithMaService;
        IGetLopWithNameService _getLopWithNameService;
        IGetLopForNganhService _getLopForNganhService;

        public LopQueryControllerImpl(IGetAllLop getAllLop, IGetLopWithMaService getLopWithMaService, IGetLopWithNameService getLopWithNameService, IGetLopForNganhService getLopForNganhService)
        {
            _getAllLop = getAllLop;
            _getLopWithMaService = getLopWithMaService;
            _getLopWithNameService = getLopWithNameService;
            _getLopForNganhService = getLopForNganhService;
        }

        public List<LopDto> getAllLopWithFullInfor()
        {
            return _getAllLop.getAll().Select(lop => new LopDto
            {
                maLop = lop.malop,
                tenLop = lop.tenlop,
                nganh = lop.nganh?.tennganh ?? "",
                khoa = lop.nganh?.Khoa?.tenkhoa??"",
                siSo = lop.sinhViens?.Count??0
            }).ToList();
        }

        public List<LopDto> getLopForNganh(string tenNganh)
        {
            if (string.IsNullOrEmpty(tenNganh))
            {
                return new List<LopDto>();
            }
            var lops = _getLopForNganhService.getLopForNganh(tenNganh);
            return lops.Select(lop => new LopDto
            {
                maLop = lop.malop,
                tenLop = lop.tenlop,
                nganh = lop.nganh?.tennganh ?? "",
                khoa = lop.nganh?.Khoa?.tenkhoa ?? "",
                siSo = lop.sinhViens?.Count ?? 0
            }).ToList();
        }

        public LopDto getLopWithMa(string ma)
        {
            if (string.IsNullOrEmpty(ma))
            {
                return new LopDto { };
            }
            var lop = _getLopWithMaService.getLopWithMa(ma);
            if (lop == null)
            {
                return new LopDto { };
            }
            return new LopDto
            {
                maLop = lop.malop,
                tenLop = lop.tenlop,
                nganh = lop.nganh?.tennganh ?? "",
                khoa = lop.nganh?.Khoa?.tenkhoa ?? "",
                siSo = lop.sinhViens?.Count ?? 0
            };
        }

        public List<LopDto> getLopWithName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return new List<LopDto>();
            }
            var lops = _getLopWithNameService.getLopWithTen(name);
            return lops.Select(lop => new LopDto
            {
                maLop = lop.malop,
                tenLop = lop.tenlop,
                nganh = lop.nganh?.tennganh ?? "",
                khoa = lop.nganh?.Khoa?.tenkhoa ?? "",
                siSo = lop.sinhViens?.Count ?? 0
            }).ToList();
        }

        public int totalLop()
        {
            return _getAllLop.getAll().Count;
        }
    }
}
