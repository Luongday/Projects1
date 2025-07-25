﻿using QuanLyHoSoSinhVien.DataAccessLayer.Entity;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.HoSoDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoSoSinhVien.PresentationLayer.Controller.HoSoController
{
    public interface IProfileController
    {
        public List<HoSoDto> getAllHoSo();

        public int TotalProfile();

        public HoSoDto getHoSoByMaHS(string mahs);

        public HoSoDto getHoSoByMaSV(string masv);

        public List<HoSoDto> getHoSoByTrangThai(string tt);

        public HoSoDto getHoSoTheoNhieuTieuChi(HoSoDto hoSoDto);
    }
}
