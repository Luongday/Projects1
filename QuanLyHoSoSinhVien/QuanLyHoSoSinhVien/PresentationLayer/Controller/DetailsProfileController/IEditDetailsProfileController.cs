using QuanLyHoSoSinhVien.PresentationLayer.DTO.DetailsProfileDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoSoSinhVien.PresentationLayer.Controller.DetailsProfileController
{
    public interface IEditDetailsProfileController
    {
        public string EditDetailsProfile(DetailsProfileDto detailsProfileDto);
    }
}
