using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHoSoSinhVien.BusinessLayer.Services.KhoaServices;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.KhoaDTO;

namespace QuanLyHoSoSinhVien.PresentationLayer.Controller.KhoaControl
{
    public class KhoaControllerImpl : IKhoaController
    {
        IGetAllKhoa getAllKhoa;

        public KhoaControllerImpl(IGetAllKhoa getAllKhoa)
        {
            this.getAllKhoa = getAllKhoa;
        }

        public List<KhoaDto> getAllKhoaWithFullInfor()
        {
            return getAllKhoa.getAll().Select(khoa => new KhoaDto
            {
                maKhoa = khoa.makhoa,
                tenKhoa = khoa.tenkhoa,
                soNganh = khoa.Nganh?.Count ?? 0,
                soLop = khoa.Nganh?.SelectMany(n => n.Lop)?.Count() ?? 0
            }).ToList()??new List<KhoaDto>();    
        }

        public int totalKhoa()
        {
            return getAllKhoa.getAll().Count;
        }
    }
}
