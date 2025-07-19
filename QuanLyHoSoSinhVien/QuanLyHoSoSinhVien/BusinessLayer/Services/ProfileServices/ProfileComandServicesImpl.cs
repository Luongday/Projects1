using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using QuanLyHoSoSinhVien.DataAccessLayer.Entity;
using QuanLyHoSoSinhVien.DataAccessLayer.Repository.HoSoRepository;
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
            if(string.IsNullOrWhiteSpace(mahs)) return false;
            var hs = _hoSoRepository.getHoSoById(mahs);
            if (hs == null) return false;

            //Soft delete
            _hoSoRepository.DeleteProfile(hs);
            _hoSoRepository.Save();
            return true;
        }

        public bool EditProfile(HoSoDto hs)
        {
            if(hs?.mahs == null) return false;
            var tmp = _hoSoRepository.getHoSoById(hs.mahs);
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
