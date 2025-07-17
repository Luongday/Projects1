using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHoSoSinhVien.BusinessLayer.Services.NganhServices;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.NganhDTO;

namespace QuanLyHoSoSinhVien.PresentationLayer.Controller.NganhControl
{
    public class NganhComandControllerImpl : IAddNganhController,IDeleteNganhController,IEditNganhController
    {
        IAddNganhService nganhService;
        IDeleteNganhService deleteNganhService;
        IEditNganhService editNganhService;
        public NganhComandControllerImpl(IAddNganhService nganhService, IDeleteNganhService deleteNganhService, IEditNganhService editNganhService)
        {
            this.nganhService = nganhService;
            this.deleteNganhService = deleteNganhService;
            this.editNganhService = editNganhService;
        }

        public bool addNewNganh(AddNganhDto newNganh)
        {
            string maNganh = newNganh.maNganh ?? "";
            string tenNganh = newNganh.tenNganh ?? "";
            if(string.IsNullOrEmpty(maNganh) || string.IsNullOrEmpty(tenNganh))
            {
                return false; // Invalid input
            }
            if (nganhService.addNewNganh(newNganh)){
                return true;
            }
            return false;
        }

        public bool deleteNganhWithId(string id)
        {
            if(string.IsNullOrEmpty(id))
            {
                return false; // Invalid ID
            }
            if (deleteNganhService.deleteNganhWithId(id))
            {
                return true;
            }
            return false;
        }

        public bool editNganh(NganhDto nganh)
        {
            if (nganh == null || string.IsNullOrEmpty(nganh.maNganh))
            {
                return false; // Invalid Nganh data
            }
            if(editNganhService.editNganh(nganh))
            {
                return true;
            }
            return false;
        }
    }
}
