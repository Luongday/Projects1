using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHoSoSinhVien.BusinessLayer.Services.KhoaServices;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.KhoaDTO;

namespace QuanLyHoSoSinhVien.PresentationLayer.Controller.KhoaControl
{
    public class KhoaComandImpl : IAddKhoaController
    {
        IAddNewKhoaService addKhoaService;

        public KhoaComandImpl(IAddNewKhoaService addKhoaService)
        {
            this.addKhoaService = addKhoaService;
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
    }
}
