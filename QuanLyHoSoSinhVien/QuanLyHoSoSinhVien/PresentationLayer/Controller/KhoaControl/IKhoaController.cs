﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.KhoaDTO;

namespace QuanLyHoSoSinhVien.PresentationLayer.Controller.KhoaControl
{
    public interface IKhoaController
    {
        public List<KhoaDto> getAllKhoaWithFullInfor();
        public KhoaDto getByMa(String id);
        public int totalKhoa();
    }
}
