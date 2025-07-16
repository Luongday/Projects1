using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.KhoaDTO;

namespace QuanLyHoSoSinhVien.BusinessLayer.Services.KhoaServices
{
    public interface IEditKhoaService
    {
        public bool editKhoa(KhoaDto newKhoa);
    }
}
