using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.NganhDTO;

namespace QuanLyHoSoSinhVien.BusinessLayer.Services.NganhServices
{
    public interface IEditNganhService
    {
        public bool editNganh(NganhDto nganh);
    }
}
