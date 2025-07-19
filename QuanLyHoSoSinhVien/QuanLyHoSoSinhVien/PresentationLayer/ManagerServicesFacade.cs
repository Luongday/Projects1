using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHoSoSinhVien.PresentationLayer.Controller.DetailsProfileController;
using QuanLyHoSoSinhVien.PresentationLayer.Controller.HoSoController;
using QuanLyHoSoSinhVien.PresentationLayer.Controller.KhoaControl;
using QuanLyHoSoSinhVien.PresentationLayer.Controller.LopControl;
using QuanLyHoSoSinhVien.PresentationLayer.Controller.NganhControl;
using QuanLyHoSoSinhVien.PresentationLayer.Controller.StudentControl;
using QuanLyHoSoSinhVien.PresentationLayer.Controller.UserControl;

namespace QuanLyHoSoSinhVien.PresentationLayer
{
    public class ManagerServicesFacade
    {
        public  IStudentController studentController { get; }
        public INganhControllers nganhControllers { get; }
        public ILopController lopController { get; }
        public IKhoaController KhoaController { get; }
        public IAddKhoaController addKhoaController { get; }
        public IDeleteKhoaController deleteKhoaController { get; }
        public IProfileController hoSoController { get; }
        public IEditKhoaController editKhoaController { get; }
        public IAddNganhController addNganhController { get; }
        public IDeleteNganhController deleteNganhController { get; }
        public IEditNganhController editnganhController { get; }
        public IDetailsProfileController detailsProfileController { get; }
        
        public IDeleteProfileController deleteProfileController { get; }

        public IEditProfileController editProfileController { get; }

        public IAddLopController addLopController { get; }
        public IGetAStudentController getAStudent { get; }
        public IDeleteLopController deleteLopController { get; }
        public IEditLopController editLopController { get; }
        public ManagerServicesFacade(IStudentController studentController, INganhControllers nganhControllers, 
                                     ILopController lopController,IKhoaController khoaController,
                                     IAddKhoaController addKhoaController, IProfileController hoSoController,
                                     IDeleteKhoaController deleteKhoaController, IEditKhoaController editKhoaController,
                                     IAddNganhController addNganhController, IDeleteNganhController deleteNganhController,
                                     IEditNganhController editNganhController, IDetailsProfileController detailsProfileController,
                                     IDeleteProfileController deleteProfileController, IEditProfileController editProfileController,
                                      IAddLopController addLopController, IGetAStudentController getAStudent,
                                      IDeleteLopController deleteLopController , IEditLopController editLopController)
                                     
        {
            this.studentController = studentController;
            this.nganhControllers = nganhControllers;
            this.lopController = lopController;
            this.KhoaController = khoaController;
            this.addKhoaController = addKhoaController;
            this.hoSoController = hoSoController;
            this.deleteKhoaController = deleteKhoaController;
            this.editKhoaController = editKhoaController;
            this.addNganhController = addNganhController;
            this.deleteNganhController = deleteNganhController;
            this.editnganhController = editNganhController;
            this.addLopController = addLopController;
            this.detailsProfileController = detailsProfileController;
            this.editProfileController = editProfileController;
            this.deleteProfileController = deleteProfileController;
            this.getAStudent = getAStudent;
            this.deleteLopController = deleteLopController;
            this.editLopController = editLopController;
        }
    }
}
