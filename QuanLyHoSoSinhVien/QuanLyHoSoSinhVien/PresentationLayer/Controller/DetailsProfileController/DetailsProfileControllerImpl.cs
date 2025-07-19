using QuanLyHoSoSinhVien.BusinessLayer.Services.DetailsProefileServices;
using QuanLyHoSoSinhVien.DataAccessLayer.Entity;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.DetailsProfileDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoSoSinhVien.PresentationLayer.Controller.DetailsProfileController
{
    public class DetailsProfileControllerImpl : IDetailsProfileController
    {
        private readonly ITakeADetailsProfileOfTheStudentServices _getInfoStudent; 
        public DetailsProfileControllerImpl(ITakeADetailsProfileOfTheStudentServices getInforStudent)
        {
            this._getInfoStudent = getInforStudent;
        }

        public DetailsProfileDto takeAStudentWithFullInfor(string masv)
        {
            var sv = _getInfoStudent.TakeInfoAStudent(masv);
            return _getInfoStudent.MapToDto(sv);
        }
    }
}

