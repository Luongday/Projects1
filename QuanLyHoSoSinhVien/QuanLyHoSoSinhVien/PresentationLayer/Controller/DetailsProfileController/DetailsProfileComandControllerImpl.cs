using QuanLyHoSoSinhVien.BusinessLayer.Services.DetailsProefileServices;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.DetailsProfileDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoSoSinhVien.PresentationLayer.Controller.DetailsProfileController
{
    internal class DetailsProfileComandControllerImpl : IEditDetailsProfileController
    {
        IEditDetailsProfileServices _edit;

        public DetailsProfileComandControllerImpl(IEditDetailsProfileServices edit)
        {
            _edit = edit;
        }

        public string EditDetailsProfile(DetailsProfileDto detailsProfileDto)
        {
            if(detailsProfileDto == null || string.IsNullOrWhiteSpace(detailsProfileDto.maSV))
            {
                return "Dữ liệu không hợp lệ";
            }

            try
            {
                var result = _edit.EditDetailsProfile(detailsProfileDto);

                return result ? "Cập nhật hồ sơ thành công" : "Không tìm thấy hồ sơ sinh viên";
            }
            catch (Exception ex) {
                return "Có lỗi xảy ra khi cập nhật";
            }
        }
    }
}
