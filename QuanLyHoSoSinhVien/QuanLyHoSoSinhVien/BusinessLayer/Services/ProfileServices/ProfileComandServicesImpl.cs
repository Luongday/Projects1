using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using QuanLyHoSoSinhVien.DataAccessLayer.Entity;
using QuanLyHoSoSinhVien.DataAccessLayer.Repository.HoSoRepository;
using QuanLyHoSoSinhVien.DataAccessLayer.Repository.StudentRepository;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.HoSoDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoSoSinhVien.BusinessLayer.Services.ProfileServices
{
    public class ProfileComandServicesImpl : IDeleteProfileServices, IEditProfileServices, IAddProfileServices
    {

        private readonly IHoSoRepository _hoSoRepository;
        private readonly IStudentRepository _studentRepository;

        public ProfileComandServicesImpl(IHoSoRepository hoSoRepository)
        {
            _hoSoRepository = hoSoRepository;
        }

        public bool AddProfile(HoSoDto hs)
        {
            return true;
        }

        public bool DeleteProfile(string mahs)
        {
            if(string.IsNullOrWhiteSpace(mahs) || string.IsNullOrEmpty(mahs)) return false;
            var hs = _hoSoRepository.getHoSoByMaHS(mahs);
            if (hs == null) return false;
         
            _hoSoRepository.DeleteProfile(hs.masv);
            _hoSoRepository.Save();
            
            return true;
        }

        public bool EditProfile(HoSoDto hs)
        {
            if(hs?.mahs == null || string.IsNullOrEmpty(hs.mahs) || string.IsNullOrWhiteSpace(hs.mahs)) return false;
            var tmp = _hoSoRepository.getHoSoByMaHS(hs.mahs);
            if (tmp == null) return false;
            
            if(!string.IsNullOrWhiteSpace(hs.masv)) tmp.masv = hs.masv;
            
            if(hs.trangthaihoso.HasValue) tmp.trangthaihoso = hs.trangthaihoso.Value;
            tmp.NgayCapNhat = DateTime.Now;

            _hoSoRepository.EditProfile(tmp);
            _hoSoRepository.Save();
            return true;
        }
    }
}
