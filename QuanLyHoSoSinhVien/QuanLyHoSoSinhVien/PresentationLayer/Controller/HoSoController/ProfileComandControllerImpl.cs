using QuanLyHoSoSinhVien.BusinessLayer.Services.ProfileServices;
using QuanLyHoSoSinhVien.DataAccessLayer.Entity;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.HoSoDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoSoSinhVien.PresentationLayer.Controller.HoSoController
{
    public class ProfileComandControllerImpl : IDeleteProfileController, IEditProfileController
    {
        private readonly IDeleteProfileServices _deleteProfileServices;
        private readonly IEditProfileServices _editProfileServices;
        public ProfileComandControllerImpl(IDeleteProfileServices deleteProfileServices, IEditProfileServices editProfileServices)
        {
            _deleteProfileServices = deleteProfileServices;
            _editProfileServices = editProfileServices;
        }

        public string DeleteProfile(string mahs)
        {

            if (string.IsNullOrWhiteSpace(mahs)) return "Mã hồ sơ không hợp lệ";

            try
            {
                var result = _deleteProfileServices.DeleteProfile(mahs);
                return result ? "Xóa thành công" : "Không tìm thấy hồ sơ để xóa";
            }
            catch (Exception ex)
            {
                return "Có lỗi xảy ra khi xóa hồ sơ";
            }
        }

        public string EditProfile(HoSoDto hs)
        {
            if (hs == null || string.IsNullOrWhiteSpace(hs.mahs)) return "Dữ liệu không hợp lệ";
            if (string.IsNullOrWhiteSpace(hs.masv))
                return "Mã sinh viên không được để trống";
            try
            {
                var result = _editProfileServices.EditProfile(hs);
                return result ? "Cập nhật hồ sơ thành công" : "Không tìm thấy hồ sơ cần sửa hoặc có lỗi xảy ra";
            }
            catch (Exception ex)
            {
                // Log error here if you have logging
                return "Có lỗi xảy ra khi cập nhật hồ sơ";
            }
        }
    }
}
