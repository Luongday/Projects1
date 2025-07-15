using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHoSoSinhVien.BusinessLayer.Services.StudentServices;

namespace QuanLyHoSoSinhVien.test
{
    public class test
    {
        IGetAllStudent getAllStudentTest;

        public test(IGetAllStudent getAllStudentTest)
        {
            this.getAllStudentTest = getAllStudentTest;
        }
    }
}
