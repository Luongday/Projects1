using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHoSoSinhVien.BusinessLayer.Services.LopServices;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.LopDTO;

namespace QuanLyHoSoSinhVien.PresentationLayer.Controller.LopControl
{
    public class LopControllerImpl : ILopController
    {
        IGetAllLop _getAllLop;

        public LopControllerImpl(IGetAllLop getAllLop)
        {
            _getAllLop = getAllLop;
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

        public int totalLop()
        {
            return _getAllLop.getAll().Count;
        }
    }
}
