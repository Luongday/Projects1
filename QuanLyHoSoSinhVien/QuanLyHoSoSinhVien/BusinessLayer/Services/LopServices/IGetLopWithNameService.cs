﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHoSoSinhVien.DataAccessLayer.Entity;

namespace QuanLyHoSoSinhVien.BusinessLayer.Services.LopServices
{
    public interface IGetLopWithNameService
    {
        public List<Lop> getLopWithTen(string tenLop);
    }
}
