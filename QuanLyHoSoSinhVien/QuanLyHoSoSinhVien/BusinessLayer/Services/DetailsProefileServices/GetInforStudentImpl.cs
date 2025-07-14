using QuanLyHoSoSinhVien.DataAccessLayer.Entity;
using QuanLyHoSoSinhVien.DataAccessLayer.Repository.DetailsProfileRepository;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.DetailsProfileDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoSoSinhVien.BusinessLayer.Services.DetailsProefileServices
{
    public class GetInforStudentImpl : IGetInforStudent
    {
        private readonly IDetailsProfileRepository _detailsProfileRepository;
        public GetInforStudentImpl(IDetailsProfileRepository detailsProfileRepository)
        {
            this._detailsProfileRepository = detailsProfileRepository;
        }
        public DetailsProfileDto getAStudentInfo(string maSv)
        {
            return _detailsProfileRepository.GetAStudentById(maSv);
        }
    }
}

