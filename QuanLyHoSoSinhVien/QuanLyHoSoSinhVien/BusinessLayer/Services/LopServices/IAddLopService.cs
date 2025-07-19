using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.LopDTO;

namespace QuanLyHoSoSinhVien.BusinessLayer.Services.LopServices
{
    public interface IAddLopService
    {
        public bool addNewLop(AddLopDto lop); 
    }
}
