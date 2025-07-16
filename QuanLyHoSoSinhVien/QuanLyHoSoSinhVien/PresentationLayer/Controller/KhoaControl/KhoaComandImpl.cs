using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHoSoSinhVien.BusinessLayer.Services.KhoaServices;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.KhoaDTO;

namespace QuanLyHoSoSinhVien.PresentationLayer.Controller.KhoaControl
{
    public class KhoaComandImpl : IAddKhoaController,IDeleteKhoaController,IEditKhoaController
    {
        IAddNewKhoaService addKhoaService;
        IDeleteKhoaService deleteKhoaService;
        IEditKhoaService editKhoaService;

        public KhoaComandImpl(IAddNewKhoaService addKhoaService,IDeleteKhoaService dltKhoa, IEditKhoaService editKhoaService)
        {
            this.addKhoaService = addKhoaService;
            this.deleteKhoaService = dltKhoa;
            this.editKhoaService = editKhoaService;
        }

        public bool addKhoa(AddKhoaDto addKhoaDto)
        {
            if (addKhoaDto != null)
            {
                if (addKhoaService.add(addKhoaDto))
                {
                    return true;
                }
            }
            return false;
        }

        public bool DeleteById(String id)
        {
            if (id != null)
            {
                if (deleteKhoaService.deleteKhoaById(id))
                {
                    return true;
                }
            }
            return false ;
        }

        public bool editKhoa(string id,string tenKhoa)
        {
            KhoaDto khoa = new KhoaDto
            {
                maKhoa = id,
                tenKhoa = tenKhoa
            };
            if (!string.IsNullOrEmpty(id)||!string.IsNullOrEmpty(tenKhoa))
            {
                if (editKhoaService.editKhoa(khoa))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
