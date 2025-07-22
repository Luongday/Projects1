using QuanLyHoSoSinhVien.DataAccessLayer.Entity;

namespace QuanLyHoSoSinhVien.BusinessLayer.Services.StudentServices
{
    public interface IGetStudentForNganhService
    {
        public List<SinhVien> getStudentsByNganh(string tenNganh);
    }
}
