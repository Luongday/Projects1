using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHoSoSinhVien.DataAccessLayer.Entity;
using QuanLyHoSoSinhVien.DataAccessLayer.Repository.LopRepository;
using QuanLyHoSoSinhVien.DataAccessLayer.Repository.NganhRepository;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.LopDTO;

namespace QuanLyHoSoSinhVien.BusinessLayer.Services.LopServices
{
    public class LopComandServiceImpl : IAddLopService,IDeleteLopService,IEditLopService
    {
        private readonly ILopRepository lopRepository;
        private readonly INganhRepository nganhRepository;
        public LopComandServiceImpl(ILopRepository lopRepository, INganhRepository NganhRepository)
        {
            this.lopRepository = lopRepository;
            this.nganhRepository = NganhRepository;
        }

        public bool addNewLop(AddLopDto lop)
        {
            if(lop == null || string.IsNullOrEmpty(lop.maLop))
            {
                return false; // Invalid Lop data
            }
            var existingLop = lopRepository.getByMa(lop.maLop);
            if (existingLop != null)
            {
                return false; // Lop already exists
            }
            var nganh = nganhRepository.getAll().FirstOrDefault(n => n.tennganh == lop.tenNganh).manganh;
            lopRepository.addLop(new DataAccessLayer.Entity.Lop
            {
                malop = lop.maLop ?? "",
                tenlop = lop.tenLop ?? "",
                manganh = nganh ?? ""
            });
            return true;
        }

        public bool deleteLop(string id)
        {
            if(string.IsNullOrEmpty(id)) {  return false; }
            var l = lopRepository.getByMa(id);
            if (l == null) { return false; }
            lopRepository.deleteLop(l);
            return true;
        }

        public bool editLop(LopDto newLop)
        {
            if (newLop == null) { }
            if (lopRepository.getByMa(newLop.maLop) == null)
            {
                return false;
            }
            var nganh = nganhRepository.getAll().FirstOrDefault(n => n.tennganh == newLop.nganh).manganh;
            lopRepository.editLop(new Lop
            {
                malop = newLop.maLop??"",
                tenlop = newLop.tenLop ??"",
                manganh = nganh??""
            });
            return true;
        }
    }
}
