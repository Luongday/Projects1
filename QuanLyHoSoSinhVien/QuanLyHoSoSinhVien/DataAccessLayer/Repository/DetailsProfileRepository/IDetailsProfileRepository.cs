using QuanLyHoSoSinhVien.BusinessLayer.Services.StudentServices;
using QuanLyHoSoSinhVien.DataAccessLayer.Entity;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.DetailsProfileDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoSoSinhVien.DataAccessLayer.Repository.DetailsProfileRepository
{
    public interface IDetailsProfileRepository
    {
        public SinhVien TakeInfoAStudentById(string masv);

        public void EditDetailsProfile(DetailsProfileDto sv);

        public void Save();
    }
}
