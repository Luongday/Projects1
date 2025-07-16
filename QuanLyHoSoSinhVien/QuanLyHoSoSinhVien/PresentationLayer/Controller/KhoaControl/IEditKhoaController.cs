using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoSoSinhVien.PresentationLayer.Controller.KhoaControl
{
    public interface IEditKhoaController
    {
        public bool editKhoa(string id,string tenKhoa);
    }
}
