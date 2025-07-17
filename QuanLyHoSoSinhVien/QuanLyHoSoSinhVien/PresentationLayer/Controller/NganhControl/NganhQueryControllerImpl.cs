using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHoSoSinhVien.BusinessLayer.Services.NganhServices;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.NganhDTO;

namespace QuanLyHoSoSinhVien.PresentationLayer.Controller.NganhControl
{
    public class NganhQueryControllerImpl : INganhControllers
    {
        IGetAllNganhService _getAllNganh;

        public NganhQueryControllerImpl(IGetAllNganhService getAllNganh)
        {
            _getAllNganh = getAllNganh;
        }

        public List<NganhDto> getAllNganhWithFullInfor()
        {
            List<NganhDto> lNganh =  _getAllNganh.getAll().Select(x => new NganhDto
            {
                maNganh = x.manganh??"",
                tenNganh = x.tennganh??"",
                khoa = x.Khoa?.tenkhoa??"",
                soLop = x.Lop?.Count ?? 0
            }).ToList();
            return lNganh;

        }

        public int totalNganh()
        {
            return _getAllNganh.getAll().Count;
        }
    }
}
