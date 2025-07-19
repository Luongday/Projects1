using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.LopDTO;

namespace QuanLyHoSoSinhVien.PresentationLayer.Controller.LopControl
{
    public interface IEditLopController
    {
        public bool editLop(LopDto lop);
    }
}
