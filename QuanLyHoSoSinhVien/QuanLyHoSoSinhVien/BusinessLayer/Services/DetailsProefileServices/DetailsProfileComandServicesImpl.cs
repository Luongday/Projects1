using Microsoft.EntityFrameworkCore.Update.Internal;
using QuanLyHoSoSinhVien.DataAccessLayer.Repository.DetailsProfileRepository;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.DetailsProfileDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoSoSinhVien.BusinessLayer.Services.DetailsProefileServices
{
    public class DetailsProfileComandServicesImpl : IEditDetailsProfileServices
    {
        private readonly IDetailsProfileRepository _detailsProfileRepository;

        public DetailsProfileComandServicesImpl(IDetailsProfileRepository detailsProfileRepository)
        {
            _detailsProfileRepository = detailsProfileRepository;
        }

        public bool EditDetailsProfile(DetailsProfileDto detailsProfileDto)
        {
             if (detailsProfileDto == null) return false;
             if (detailsProfileDto.maSV == null || string.IsNullOrEmpty(detailsProfileDto.maSV) || string.IsNullOrWhiteSpace(detailsProfileDto.maSV)) return false;

            _detailsProfileRepository.EditDetailsProfile(detailsProfileDto);
            _detailsProfileRepository.Save();
            return true;
        }
    }
}
