using QuanLyHoSoSinhVien.BusinessLayer.Services.DetailsProefileServices;
using QuanLyHoSoSinhVien.DataAccessLayer.Entity;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.DetailsProfileDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoSoSinhVien.PresentationLayer.Controller.DetailsProfileController
{
    public class DetailsProfileControllerImpl : IDetailsProfileController
    {
        private readonly IGetInforStudent _getInfoStudent; 
        public DetailsProfileControllerImpl(IGetInforStudent getInforStudent)
        {
            this._getInfoStudent = getInforStudent;
        }

        public DetailsProfileDto getAStudentWithFullInfor(string maSv)
        {
            return _getInfoStudent.getAStudentInfo(maSv);
        }
    }
}

