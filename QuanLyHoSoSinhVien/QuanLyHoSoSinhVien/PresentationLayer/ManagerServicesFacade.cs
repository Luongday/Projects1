using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHoSoSinhVien.PresentationLayer.Controller.StudentControl;
using QuanLyHoSoSinhVien.PresentationLayer.Controller.UserControl;

namespace QuanLyHoSoSinhVien.PresentationLayer
{
    public class ManagerServicesFacade
    {
        public  IStudentController studentController { get; }

        public ManagerServicesFacade(IStudentController studentController)
        {
            this.studentController = studentController;
        }
    }
}
