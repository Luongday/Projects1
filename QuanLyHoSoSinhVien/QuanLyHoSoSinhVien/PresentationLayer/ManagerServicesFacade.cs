using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public ManagerServicesFacade(IStudentController studentController, INganhControllers nganhControllers, 
                                     ILopController lopController,IKhoaController khoaController,
                                     IAddKhoaController addKhoaController)
        {
            this.studentController = studentController;
            this.nganhControllers = nganhControllers;
            this.lopController = lopController;
            this.KhoaController = khoaController;
            this.addKhoaController = addKhoaController;
        }
    }
}
