﻿using QuanLyHoSoSinhVien.DataAccessLayer.Entity;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.DetailsProfileDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoSoSinhVien.BusinessLayer.Services.DetailsProefileServices
{
    public interface IEditDetailsProfileServices
    {
        public bool EditDetailsProfile(DetailsProfileDto detailsProfileDto);
    }
}
