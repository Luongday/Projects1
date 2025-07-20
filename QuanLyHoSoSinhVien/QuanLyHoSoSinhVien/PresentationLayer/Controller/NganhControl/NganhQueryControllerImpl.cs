using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHoSoSinhVien.BusinessLayer.Services.NganhServices;
using QuanLyHoSoSinhVien.DataAccessLayer.Entity;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.NganhDTO;

namespace QuanLyHoSoSinhVien.PresentationLayer.Controller.NganhControl
{
    public class NganhQueryControllerImpl : INganhControllers,IGetNganhForNameController,IGetNganhForKhoaController,IGetNganhForIdController
    {
        IGetAllNganhService _getAllNganh;
        IGetNganhForNameService _getNganhForNameService;
        IGetNganhForKhoaService _getNganhForKhoaService;
        IGetNganhForIdService _getNganhForIdService;

        public NganhQueryControllerImpl(IGetAllNganhService getAllNganh, IGetNganhForNameService getNganhForNameService, IGetNganhForKhoaService getNganhForKhoaService,
                                        IGetNganhForIdService getNganhForIdService)
        {
            _getAllNganh = getAllNganh;
            _getNganhForNameService = getNganhForNameService;
            _getNganhForKhoaService = getNganhForKhoaService;
            _getNganhForIdService = getNganhForIdService;
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

        public List<NganhDto> getNganhForId(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new List<NganhDto>();
            }
            List<NganhDto> lNganh = _getNganhForIdService.getNganhForId(id).Select(x => new NganhDto
            {
                maNganh = x.manganh ?? "",
                tenNganh = x.tennganh ?? "",
                khoa = x.Khoa?.tenkhoa ?? "",
                soLop = x.Lop?.Count ?? 0
            }).ToList();
            return lNganh;
        }

        public List<NganhDto> getNganhForKhoa(string tenKhoa)
        {
            if (string.IsNullOrEmpty(tenKhoa))
            {
                return new List<NganhDto>();
            }
            List<NganhDto> lNganh = _getNganhForKhoaService.getNganhForKhoa(tenKhoa).Select(x => new NganhDto
            {
                maNganh = x.manganh ?? "",
                tenNganh = x.tennganh ?? "",
                khoa = x.Khoa?.tenkhoa ?? "",
                soLop = x.Lop?.Count ?? 0
            }).ToList();
            return lNganh;
        }

        public List<NganhDto> getNganhForName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return new List<NganhDto>();
            }
            List<NganhDto> lNganh = _getNganhForNameService.getNganhForName(name).Select(x => new NganhDto
            {
                maNganh = x.manganh ?? "",
                tenNganh = x.tennganh ?? "",
                khoa = x.Khoa?.tenkhoa ?? "",
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
