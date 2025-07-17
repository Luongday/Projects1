using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHoSoSinhVien.DataAccessLayer.Entity;
using QuanLyHoSoSinhVien.DataAccessLayer.Repository.NganhRepository;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.NganhDTO;

namespace QuanLyHoSoSinhVien.BusinessLayer.Services.NganhServices
{
    public class NganhCommandServiceImpl : IAddNganhService,IDeleteNganhService,IEditNganhService
    {
        INganhRepository nganhRepository;

        public NganhCommandServiceImpl(INganhRepository nganhRepository)
        {
            this.nganhRepository = nganhRepository;
        }

        public bool addNewNganh(AddNganhDto nganh)
        {
            Nganh ngh = nganhRepository.getAll().Where(ng => ng.manganh == nganh.maNganh).FirstOrDefault();
            if (ngh != null)
            {
                return false; // Nganh already exists
            }
            nganhRepository.addNganh(new DataAccessLayer.Entity.Nganh
            {
                manganh = nganh.maNganh??"",
                tennganh = nganh.tenNganh??"",
            });
            return true;
        }

        public bool deleteNganhWithId(string id)
        {
            if(string.IsNullOrEmpty(id))
            {
                return false; // Invalid ID
            }
            if(nganhRepository.getAll().Where(ng => ng.manganh == id).FirstOrDefault() == null)
            {
                return false; // Nganh not found
            }
            nganhRepository.deleteNganh(id);
            return true;
        }

        public bool editNganh(NganhDto nganh)
        {
            if(nganh == null || string.IsNullOrEmpty(nganh.maNganh))
            {
                return false; // Invalid Nganh data
            }
            Nganh existingNganh = nganhRepository.getAll().Where(ng => ng.manganh == nganh.maNganh).FirstOrDefault();
            if (existingNganh == null)
            {
                return false; // Nganh not found
            }
            existingNganh.manganh = nganh.maNganh ?? existingNganh.manganh;
            existingNganh.tennganh = nganh.tenNganh ?? existingNganh.tennganh;
            existingNganh.makhoa = nganhRepository.getAll().Where(ng => ng.Khoa.tenkhoa==nganh.khoa).FirstOrDefault().Khoa.tenkhoa?? existingNganh.makhoa;
            nganhRepository.editNganh(existingNganh);
            return true;
        }
    }
}
