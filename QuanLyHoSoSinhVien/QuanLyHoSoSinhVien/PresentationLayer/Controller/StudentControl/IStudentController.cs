﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.StudentDTO;

namespace QuanLyHoSoSinhVien.PresentationLayer.Controller.StudentControl
{
    public interface IStudentController
    {
        public List<StudentDto> getAllStudentWithFullInfor();
        public int totalStudent();
        public int totalStudentTamVang();
        public int totalStudentDangHoc();
    }
}
