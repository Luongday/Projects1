using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHoSoSinhVien.BusinessLayer.Services.KhoaServices;
using QuanLyHoSoSinhVien.DataAccessLayer.Entity;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.KhoaDTO;

namespace QuanLyHoSoSinhVien.PresentationLayer.Controller.KhoaControl
{
    public class KhoaQueryControllerImpl : IKhoaController
    {
        IGetAllKhoa getAllKhoa;
        IGetKhoaForId getbyID;

        public KhoaQueryControllerImpl(IGetAllKhoa getAllKhoa, IGetKhoaForId getbyID)
        {
            this.getAllKhoa = getAllKhoa;
            this.getbyID = getbyID;
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

        public KhoaDto getByMa(string id)
        {
            Khoa k = getbyID.GetById(id);
            KhoaDto khoa = new KhoaDto { 
                maKhoa = id,
                tenKhoa = k.tenkhoa,
                soNganh = k.Nganh?.Count ?? 0,
                soLop = k.Nganh?.SelectMany(n => n.Lop)?.Count() ?? 0
            };
            return khoa;
        }

        public int totalKhoa()
        {
            return getAllKhoa.getAll().Count;
        }
    }
}
