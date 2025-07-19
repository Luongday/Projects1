using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHoSoSinhVien.DataAccessLayer.Entity;
using QuanLyHoSoSinhVien.DataAccessLayer.Repository.LopRepository;

namespace QuanLyHoSoSinhVien.BusinessLayer.Services.LopServices
{
    public class LopQueryIServicempl : IGetAllLop
    {
        ILopRepository lopRepository;

        public LopQueryIServicempl(ILopRepository lopRepository)
        {
            this.lopRepository = lopRepository;
        }

        public List<Lop> getAll()
        {
            return lopRepository.getAll() ?? new List<Lop>();   
        }
    }
}
