using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHoSoSinhVien.DataAccessLayer.Entity;
using QuanLyHoSoSinhVien.DataAccessLayer.Repository.HoSoRepository;
using QuanLyHoSoSinhVien.DataAccessLayer.Repository.StudentRepository;
using QuanLyHoSoSinhVien.DataAccessLayer.Repository.UserRepository;

namespace QuanLyHoSoSinhVien.BusinessLayer.Services.StudentServices
{
    public class StudentComandServicesImpl : IDeleteStudentService,IAddStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IHoSoRepository _hoSoRepository;
        private readonly IUserDAO _userDAO;

        public StudentComandServicesImpl(IStudentRepository studentRepository, IHoSoRepository _hoSoRepository,IUserDAO userDao)
        {
            _studentRepository = studentRepository;
            this._hoSoRepository = _hoSoRepository;
            this._userDAO = userDao;
        }

        public bool addStudent(SinhVien sv)
        {
            if (sv == null || string.IsNullOrEmpty(sv.masv) || string.IsNullOrEmpty(sv.tensv))
            {
                return false; // Invalid input
            }
            try
            {
                _studentRepository.addStudent(sv);
                _hoSoRepository.AddHoSo(new HoSo
                {
                    mahoso = "HS"+sv.masv , 
                    masv = sv.masv,
                    trangthaihoso = sv.trangthai == "Tốt nghiệp", 
                    NgayTao = DateTime.Now,
                    NgayCapNhat = DateTime.Now
                });
                _userDAO.addRegister(new User
                {
                    userId = sv.masv + "register",
                    userName = "SV" + sv.masv,
                    password = 1111.ToString(), // Default password
                    isAdmin = false
                });
                return true; 
            }
            catch (Exception ex)
            {
                return false; // Addition failed
            }
        }

        public bool delete(string ma)
        {
            if (string.IsNullOrEmpty(ma)||string.IsNullOrWhiteSpace(ma))
            {
                return false; // Invalid input
            }
            var student = _studentRepository.GetStudentId(ma);
            if (student == null) return false;
            string maHs = student?.HoSo.mahoso;
            try
            {
                User user = _userDAO.getUserForId(ma + "register");
                _studentRepository.deleteSinhVien(student);
                _userDAO.deleteUser(user);
                return true;
            }
            catch (Exception ex)
            {
                return false; // Deletion failed
            }
        }
    }
}
