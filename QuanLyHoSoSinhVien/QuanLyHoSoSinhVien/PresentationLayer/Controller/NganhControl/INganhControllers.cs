using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.NganhDTO;

namespace QuanLyHoSoSinhVien.PresentationLayer.Controller.NganhControl
{
    public interface INganhControllers
    {
        public List<NganhDto> getAllNganhWithFullInfor();
        public int totalNganh();
    }
}
