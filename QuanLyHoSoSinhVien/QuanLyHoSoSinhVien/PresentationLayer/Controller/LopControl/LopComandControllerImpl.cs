using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHoSoSinhVien.BusinessLayer.Services.LopServices;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.LopDTO;

namespace QuanLyHoSoSinhVien.PresentationLayer.Controller.LopControl
{
    public class LopComandControllerImpl : IAddLopController,IDeleteLopController,IEditLopController
    {
        IAddLopService addLopService;
        IDeleteLopService deleteLopService;
        IEditLopService editLopService;

        public LopComandControllerImpl(IAddLopService addLopService, IDeleteLopService deleteLopService,IEditLopService editLopService)
        { 
            this.addLopService = addLopService;
            this.deleteLopService = deleteLopService;
            this.editLopService = editLopService;
        }

        public bool addLop(AddLopDto newLop)
        {
            if (newLop == null || string.IsNullOrEmpty(newLop.maLop))
            {
                return false; // Invalid Lop data
            }
            if (addLopService.addNewLop(newLop))
            {
                return true; // Lop added successfully
            }
            else
            {
                return false; // Lop already exists or other error
            }
        }

        public bool deleteLop(string id)
        {
            if(string.IsNullOrEmpty(id)) {return false;}
            if (deleteLopService.deleteLop(id))
            {
                return true;
            }
            return false;
        }

        public bool editLop(LopDto lop)
        {
            if (lop == null || string.IsNullOrEmpty(lop.maLop))
            {
                return false;
            }
            if (editLopService.editLop(lop))
            {
                return true;
            }
            return false;
        }
    }
}
