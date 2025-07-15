using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHoSoSinhVien.DataAccessLayer.Entity;
using QuanLyHoSoSinhVien.DataAccessLayer.Repository.KhoaRepository;

namespace QuanLyHoSoSinhVien.BusinessLayer.Services.KhoaServices
{
    public class GetAllKhoa : IGetAllKhoa
    {
        IKhoaRepository khoaRepository;

        public GetAllKhoa(IKhoaRepository khoaRepository)
        {
            this.khoaRepository = khoaRepository;
        }

        public List<Khoa> getAll()
        {
            return khoaRepository.getAll()??new List<Khoa>();
        }
    }
}
